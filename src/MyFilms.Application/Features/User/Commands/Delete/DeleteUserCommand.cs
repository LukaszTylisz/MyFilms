using MediatR;

namespace MyFilms.Application.Features.User.Commands.Delete;

public record DeleteUserCommand(int Id) : IRequest;