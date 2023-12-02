using AutoMapper;
using MediatR;
using MyFilms.Application.Contracts.Logging;
using MyFilms.Application.Contracts.Persistence;

namespace MyFilms.Application.Features.Movie.Queries.GetAllMoviesQuery;

public class GetAllMoviesHandler : IRequestHandler<GetAllMoviesQuery, MovieDto>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetAllMoviesHandler> _logger;

    public GetAllMoviesHandler(IMovieRepository movieRepository, IMapper mapper, IAppLogger<GetAllMoviesHandler> logger)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<MovieDto> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetAsync();

        var data = _mapper.Map<MovieDto>(movies);
        
        _logger.LogInformation("Movies were retrieved successfully");

        return data;
    }
}