using FluentValidation;
using MyFilms.Application.Contracts.Persistence;

namespace MyFilms.Application.Features.Movie.Commands.Update;

public class UpdateMovieValidator : AbstractValidator<UpdateMovieCommand>
{
    private readonly IMovieRepository _movieRepository;

    public UpdateMovieValidator(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;

        RuleFor(x => x.Id)
            .NotNull()
            .MustAsync(MovieMustExist)
            .WithMessage("{PropertyName} does not exist");
        
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
        
        RuleFor(x => x.Director)
            .NotNull()
            .WithMessage("{PropertyName} does not exist");
        
        RuleFor(x => x.Year)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .InclusiveBetween(1900, 2000).WithMessage("{PropertyName} must be between 1900-2200");
    }

    private async Task<bool> MovieMustExist(int id, CancellationToken token)
    {
        var movie = await _movieRepository.GetByIdAsync(id);

        return movie != null;
    }
}