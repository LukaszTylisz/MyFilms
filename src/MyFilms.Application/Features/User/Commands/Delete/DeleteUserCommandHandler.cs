using MediatR;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Application.Exceptions;

namespace MyFilms.Application.Features.User.Commands.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user is null) 
            throw new NotFoundException($"User od id {request.Id} does not exist!!!", user);
        
        await _userRepository.DeleteAsync(user);
    }
}