using MediatR;

namespace MyFilms.Application.Features.Movie.Queries.GetMovieByIdQuery;

public record GetMovieByIdQuery(int id) : IRequest<MovieByIdDto>;
