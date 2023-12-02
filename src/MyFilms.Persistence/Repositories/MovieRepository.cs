using System.Text.Unicode;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Domain;
using MyFilms.Persistence.DatabaseContext;

namespace MyFilms.Persistence.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieDatabaseContext context) : base(context)
    {
    }
}