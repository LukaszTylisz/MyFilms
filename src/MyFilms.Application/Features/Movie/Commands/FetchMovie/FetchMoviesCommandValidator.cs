using FluentValidation;
using MyFilms.Application.Contracts.Persistence;

namespace MyFilms.Application.Features.Movie.Commands.FetchMovie;

public class FetchMoviesCommandValidator : AbstractValidator<FetchMoviesCommand>
{
    private readonly IMovieRepository _movieRepository;

    public FetchMoviesCommandValidator(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
        
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .MustAsync(MovieMustExist)
            .WithMessage("{PropertyName} does not exist");
  
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
  
        RuleFor(x => x.Year)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .InclusiveBetween(1900, 2000).WithMessage("{PropertyName} must be between 1900 and 2200");
        
        RuleFor(x => x.Rate)
            .NotEmpty().WithMessage("{PropertyName} can't be empty")
            .InclusiveBetween(1, 10).WithMessage("{PropertyName} must be between 1-10");
        
        RuleFor(x => x.Director)
            .NotEmpty().WithMessage("{PropertyName} can't be empty")
            .MaximumLength(40).WithMessage("{PropertyName} must be fewer than 40 characters");;
    }

    private async Task<bool> MovieMustExist(int id, CancellationToken token)
    {
        var movie = await _movieRepository.GetByIdAsync(id);
        return movie != null;
    }
}