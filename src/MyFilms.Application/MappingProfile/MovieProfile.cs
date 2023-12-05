using AutoMapper;
using MyFilms.Application.Features.Movie.Commands.Create;
using MyFilms.Application.Features.Movie.Commands.Update;
using MyFilms.Application.Features.Movie.Queries.GetAllMoviesQuery;
using MyFilms.Application.Features.Movie.Queries.GetMovieByIdQuery;
using MyFilms.Domain;

namespace MyFilms.Application.MappingProfile;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>().ReverseMap();
        CreateMap<Movie, MovieByIdDto>().ReverseMap();
        CreateMap<CreateMovieCommand, Movie>();
        CreateMap<UpdateMovieCommand, Movie>();
    }
}