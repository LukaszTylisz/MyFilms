using MediatR;

namespace MyFilms.Application.Features.Movie.Queries.GetMovieByIdQuery;

public class GetMovieByIdQuery : IRequest<MovieByIdDto>
{
    public int Id { get; set; }
}