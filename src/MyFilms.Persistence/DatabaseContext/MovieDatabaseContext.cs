using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyFilms.Application.Features.Movie.Queries.GetAllMoviesQuery;
using MyFilms.Domain;

namespace MyFilms.Persistence.DatabaseContext;

public class MovieDatabaseContext : DbContext
{
    public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
        modelBuilder.SeedData();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    
}