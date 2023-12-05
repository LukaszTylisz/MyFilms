using Microsoft.EntityFrameworkCore;
using MyFilms.Domain;

namespace MyFilms.Persistence;

public static class Seed
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie()
            {
                Id = 1, Title = "Universal Soldier", Director = "Roland Emmerich", Year = 1972, Rate = (float)6.5
            },
            new Movie()
            {
                Id = 2, Title = " Under Siege", Director = "Andrew Davis", Year = 1992, Rate = (float)6.5
            }
        );
    }
}