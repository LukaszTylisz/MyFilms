using MyFilms.Application.Features.Movie.Queries.GetAllMoviesQuery;
using MyFilms.Domain;

namespace MyFilms.Application.Contracts.Persistence;

public interface IMovieRepository : IGenericRepository<Movie>
{
    Task<List<MovieDto>> FetchMovies();
}