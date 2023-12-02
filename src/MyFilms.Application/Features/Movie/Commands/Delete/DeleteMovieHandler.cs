using AutoMapper;
using MediatR;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Application.Exceptions;

namespace MyFilms.Application.Features.Movie.Commands.Delete;

public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public DeleteMovieHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByIdAsync(request.Id);

        if (movie == null)
            throw new NotFoundException(nameof(Domain.Movie), request.Id);

        await _movieRepository.DeleteAsync(movie);
    }
}