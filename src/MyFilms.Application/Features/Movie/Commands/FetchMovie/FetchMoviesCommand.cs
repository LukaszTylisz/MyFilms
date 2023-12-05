using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace MyFilms.Application.Features.Movie.Commands.FetchMovie;

public class FetchMoviesCommand : IRequest<Unit>
{
}