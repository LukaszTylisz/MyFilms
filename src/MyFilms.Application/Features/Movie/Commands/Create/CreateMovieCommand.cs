using MediatR;

namespace MyFilms.Application.Features.Movie.Commands.Create;

public class CreateMovieCommand : IRequest<int>
{
    public string Title { get; set; }
    public int Year { get; set; }
}