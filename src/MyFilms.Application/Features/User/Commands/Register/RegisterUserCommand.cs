using MediatR;

namespace MyFilms.Application.Features.User.Commands.Register;

public record RegisterUserCommand(RegisterUserDto RegisterUserDto) : IRequest;
 