using AutoMapper;
using MyFilms.Application.Features.Movie.Commands.Create;
using MyFilms.Application.Features.Movie.Commands.Update;
using MyFilms.Application.Features.Movie.Queries.GetAllMoviesQuery;
using MyFilms.Domain;

namespace MyFilms.Application.MappingProfile;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<MovieDto, Movie>().ReverseMap();
        CreateMap<CreateMovieCommand, Movie>();
        CreateMap<UpdateMovieCommand, Movie>();
    }
}