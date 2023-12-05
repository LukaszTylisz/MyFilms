using MediatR;
using Microsoft.AspNetCore.Identity;
using MyFilms.Application.Contracts.Persistence;

namespace MyFilms.Application.Features.User.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<Domain.User> _passwordHasher;

    public RegisterUserCommandHandler(IUserRepository userRepository,
        IPasswordHasher<Domain.User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (request.RegisterUserDto.Password != request.RegisterUserDto.ConfirmPassword)
        {
            throw new Exception("Password and Confirm Password do not match");
        }
        
        var userExists = await _userRepository.GetRecordByFilterAsync(u => u.Email == request.RegisterUserDto.Email, cancellationToken);
        if (userExists != null)
        {
            throw new Exception("Email already exists");
        }
        
        var userForHashing = new Domain.User
        {
            Email = request.RegisterUserDto.Email,
            PasswordHash = request.RegisterUserDto.Password 
        };
        
        var hashedPassword = _passwordHasher.HashPassword(userForHashing, userForHashing.PasswordHash);
        
        var newUser = new Domain.User
        {
            Email = request.RegisterUserDto.Email,
            FirstName = request.RegisterUserDto.Name,
            LastName = request.RegisterUserDto.Surname,
            PasswordHash = hashedPassword,
            RoleId = (int)request.RegisterUserDto.Role
        };

        await _userRepository.CreateAsync(newUser);
    }

}