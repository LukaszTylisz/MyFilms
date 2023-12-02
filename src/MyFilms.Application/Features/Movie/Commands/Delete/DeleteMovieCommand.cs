using MediatR;

namespace MyFilms.Application.Features.Movie.Commands.Delete;

public class DeleteMovieCommand : IRequest, IRequest<int>
{
    public int Id { get; set; }
}