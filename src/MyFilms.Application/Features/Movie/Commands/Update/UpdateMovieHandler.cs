using AutoMapper;
using MediatR;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Application.Exceptions;

namespace MyFilms.Application.Features.Movie.Commands.Update;

public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IMovieRepository _movieRepository;

    public UpdateMovieHandler(IMapper mapper, IMovieRepository movieRepository)
    {
        _mapper = mapper;
        _movieRepository = movieRepository;
    }
    public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateMovieValidator(_movieRepository);
        var validatorResult = await validator.ValidateAsync(request);

        if (validatorResult.Errors.Any())
            throw new BadRequestException("Invalid Movie", validatorResult);

        var movieUpdate = await _movieRepository.GetByIdAsync(request.Id) ??
                          throw new NotFoundException(nameof(Domain.Movie), request.Id);

        _mapper.Map(request, movieUpdate);

        await _movieRepository.UpdateAsync(movieUpdate);
        return Unit.Value;

    }
}