using AutoMapper;
using Moq;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Application.Features.Movie.Commands.Create;
using MyFilms.Application.MappingProfile;
using MyFilms.Application.Unit.Test.Mocks;
using Shouldly;

namespace MyFilms.Application.Unit.Test.Features.Movie.Commands;

public class CreateMovieCommandTests
{
    private readonly IMapper _mapper;
    private Mock<IMovieRepository> _mockRepo;
    public CreateMovieCommandTests()
    {
        _mockRepo = MockMovieTypeRepository.GetMockMovieRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MovieProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]

    public async Task Handle_ValidLeaveType()
    {
        var handler = new CreateMovieHandler(_mockRepo.Object,_mapper);

        await handler.Handle(new CreateMovieCommand() { Title = "Test1", Year = 2000
        }, CancellationToken.None);

        var leaveTypes = await _mockRepo.Object.GetAsync();
        leaveTypes.Count.ShouldBe(4);
    }
}