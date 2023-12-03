namespace MyFilms.Application.Features.Movie.Queries.GetMovieByIdQuery;

public class MovieByIdDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public float Rate { get; set; }
}