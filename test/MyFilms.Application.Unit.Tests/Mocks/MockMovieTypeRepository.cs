using Moq;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Domain;

namespace MyFilms.Application.Unit.Test.Mocks;

public class MockMovieTypeRepository
{
    public static Mock<IMovieRepository> GetMockMovieRepository()
    {
        var movies = new List<Movie>
        {
            new Movie()
            {
                Id = 1,
                Title = "Rocky",
                Director = "John G. Avildsen",
                Year = 1976,
                Rate = (float)8.1
            },
            new Movie()
            {
                Id = 2,
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Year = 1972,
                Rate = (float)9.2
            },
            new Movie()
            {
                Id = 3,
                Title = "Saving Private Ryan",
                Director = "Steven Spielberg",
                Year = 1998,
                Rate = (float)8.8
            }
        };

        var mockRepo = new Mock<IMovieRepository>();
        
        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(movies);

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<Movie>()))
            .Returns((Movie movie) =>
            {
                movies.Add(movie);
                return Task.CompletedTask;
            });

        return mockRepo;
    }
}