namespace MyFilms.Application.Features.Movie.Queries.GetAllMoviesQuery;

public class MovieDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public float Rate { get; set; }
}