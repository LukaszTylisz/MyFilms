using Microsoft.EntityFrameworkCore;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Application.Features.Movie.Queries.GetAllMoviesQuery;
using MyFilms.Domain;
using MyFilms.Persistence.DatabaseContext;

namespace MyFilms.Persistence.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    private readonly IHttpClientFactory _clientFactory;

    public MovieRepository(MovieDatabaseContext context, IHttpClientFactory clientFactory) : base(context)
    {
        _clientFactory = clientFactory;
    }

    public async Task<List<MovieDto>> FetchMovies()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://filmy.programdemo.pl/swagger/index.html");
        var client = _clientFactory.CreateClient();
        HttpResponseMessage response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var movieDto = await response.Content.ReadAsAsync<List<MovieDto>>();
            foreach (var movie in movieDto)
            {
                if (!await _context.Movies.AnyAsync(m => m.Id == movie.Id))
                {
                    await _context.Movies.AddAsync(new Movie
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        Director = movie.Director,
                        Year = movie.Year,
                        Rate = movie.Rate
                    });
                    await _context.SaveChangesAsync();
                }
            }
            return movieDto;
        }
        else
        {
            return null;
        }
    }
}