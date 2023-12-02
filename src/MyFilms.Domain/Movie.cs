
namespace MyFilms.Domain;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int? Director { get; set; }
    public int Year { get; set; }
    public float Rate { get; set; }
}