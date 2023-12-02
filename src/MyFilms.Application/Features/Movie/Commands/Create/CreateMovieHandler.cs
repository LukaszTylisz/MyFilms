using AutoMapper;
using MediatR;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Application.Exceptions;

namespace MyFilms.Application.Features.Movie.Commands.Create;

public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, int>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public CreateMovieHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateMovieValidator(_movieRepository);
        var validatorResult = await validator.ValidateAsync(request);

        if (validatorResult.Errors.Any())
            throw new BadRequestException("Invalid Movie", validatorResult);

        var movieToCreate = _mapper.Map<Domain.Movie>(request);

        await _movieRepository.CreateAsync(movieToCreate);

        return movieToCreate.Id;
    }
}