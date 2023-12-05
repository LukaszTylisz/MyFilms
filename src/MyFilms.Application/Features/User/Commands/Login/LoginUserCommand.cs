using MediatR;

namespace MyFilms.Application.Features.User.Commands.Login;

public record LoginUserCommand(LoginUserDto LoginUserDto) : IRequest<string>;