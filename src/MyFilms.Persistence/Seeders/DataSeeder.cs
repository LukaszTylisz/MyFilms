using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using MyFilms.Domain;
using MyFilms.Persistence.DatabaseContext;

namespace MyFilms.Persistence.Seeders
{
    public class DataSeeder 
    {
        private readonly MovieDatabaseContext _dbContext;
  

        public DataSeeder(MovieDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DataSeed()
        {
          //  var srcDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "src"));

            var usersJsonPath = Path.GetFullPath( "Seeders", "users.json");
            var moviesJsonPath = Path.GetFullPath("Seeders", "movies.json");

            if (!_dbContext.Users.Any())
            {
                var usersData = await File.ReadAllTextAsync(usersJsonPath);
                var users = JsonSerializer.Deserialize<List<User>>(usersData);

                if (users != null)
                {
                    foreach (var user in users)
                    {
                        _dbContext.Users.Add(user);
                    }
                }

                await _dbContext.SaveChangesAsync();
            }

            if (!_dbContext.Movies.Any())
            {
                var moviesData = await File.ReadAllTextAsync(moviesJsonPath);
                var movies = JsonSerializer.Deserialize<List<Movie>>(moviesData);

                if (movies != null)
                {
                    foreach (var movie in movies)
                    {
                        _dbContext.Movies.Add(movie);
                    }
                }

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}