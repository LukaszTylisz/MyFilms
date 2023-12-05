using AutoMapper;
using MediatR;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Application.Exceptions;

namespace MyFilms.Application.Features.Movie.Commands.FetchMovie;

public class FetchMoviesCommandHandler : IRequestHandler<FetchMoviesCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IMovieRepository _movieRepository;

    public FetchMoviesCommandHandler(IMapper mapper, IMovieRepository movieRepository)
    {
        _mapper = mapper;
        _movieRepository = movieRepository;
    }
    public async Task<Unit> Handle(FetchMoviesCommand request, CancellationToken cancellationToken)
    {
        await _movieRepository.FetchMovies();
        return Unit.Value;
    }
}