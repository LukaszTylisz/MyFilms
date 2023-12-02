using MediatR;

namespace MyFilms.Application.Features.Movie.Queries.GetAllMoviesQuery;

public class GetAllMoviesQuery : IRequest<MovieDto>
{
}