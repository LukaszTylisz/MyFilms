using MediatR;
using Microsoft.AspNetCore.Identity;
using MyFilms.Application.Contracts.Persistence;

namespace MyFilms.Application.Features.User.Commands.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher<Domain.User> _passwordHasher;

    public LoginUserCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider,
        IPasswordHasher<Domain.User> passwordHasher)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetRecordByFilterAsync(u => u.Email == request.LoginUserDto.Email, cancellationToken) ??
                   throw new Exception("Invalid email or password");
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.LoginUserDto.Password);

        if (result == PasswordVerificationResult.Failed) throw new Exception("Invalid email or password");
        
        return _jwtProvider.GenerateJwtToken(user);
    }
}