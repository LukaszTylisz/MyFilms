using MediatR;
using MyFilms.Application.Features.User.UserContext;

namespace MyFilms.Application.Features.User.Commands.LogOut;

public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, bool>
{
    private readonly IIdentityService _identityService;

    public LogoutUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<bool> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.Logout();
    }
}