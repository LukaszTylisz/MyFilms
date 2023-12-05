using MediatR;

namespace MyFilms.Application.Features.Movie.Commands.Create;

public class CreateMovieCommand : IRequest<Unit>
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public float Rate { get; set; }

}