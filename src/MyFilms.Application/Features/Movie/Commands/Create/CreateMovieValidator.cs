using FluentValidation;
using MyFilms.Application.Contracts.Persistence;

namespace MyFilms.Application.Features.Movie.Commands.Create;

public class CreateMovieValidator : AbstractValidator<CreateMovieCommand>
{
    private readonly IMovieRepository _movieRepository;

    public CreateMovieValidator(IMovieRepository movieRepository)
    {      _movieRepository = movieRepository;
  
          RuleFor(x => x.Title)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");
  
          RuleFor(x => x.Year)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .InclusiveBetween(1900, 2000).WithMessage("{PropertyName} must be between 1900 and 2200");   
    }
}