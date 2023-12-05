using MediatR;

namespace MyFilms.Application.Features.Movie.Commands.Update;

public class UpdateMovieCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public float Rate { get; set; }
}