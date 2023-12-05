using MediatR;

namespace MyFilms.Application.Features.User.Commands.LogOut;

public record LogoutUserCommand() : IRequest<bool>;