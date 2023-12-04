using AutoMapper;
using Moq;
using MyFilms.Application.Contracts.Logging;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Application.Features.Movie.Queries.GetAllMoviesQuery;
using MyFilms.Application.MappingProfile;
using MyFilms.Application.Unit.Test.Mocks;
using Shouldly;

namespace MyFilms.Application.Unit.Test.Features.Movie.Queries;

public class GetMovieQueryHandlerTests
{
    private readonly Mock<IMovieRepository> _mockRepo;
    private IMapper _mapper;
    private Mock<IAppLogger<GetAllMoviesHandler>> _mockAppLogger;

    public GetMovieQueryHandlerTests()
    {
        _mockRepo = MockMovieTypeRepository.GetMockMovieRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MovieProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetAllMoviesHandler>>();
    }

    [Fact]
    public async Task GetLeaveTypeListTest()
    {
        var handler = new GetAllMoviesHandler(_mockRepo.Object,_mapper, _mockAppLogger.Object);

        var result = await handler.Handle(new GetAllMoviesQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<MovieDto>>();
        result.Count.ShouldBe(3);
    }
}