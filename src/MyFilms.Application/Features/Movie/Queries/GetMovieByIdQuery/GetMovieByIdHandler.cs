using AutoMapper;
using MediatR;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Application.Exceptions;

namespace MyFilms.Application.Features.Movie.Queries.GetMovieByIdQuery;

public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, MovieByIdDto>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetMovieByIdHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<MovieByIdDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByIdAsync(request.id) ??
                    throw new NotFoundException(nameof(Domain.Movie), request.id);

        var data = _mapper.Map<MovieByIdDto>(movie);

        return data;
    }
}