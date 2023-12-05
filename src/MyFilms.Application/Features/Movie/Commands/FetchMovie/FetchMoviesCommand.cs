﻿using MediatR;

namespace MyFilms.Application.Features.Movie.Commands.FetchMovie;

public class FetchMoviesCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public float Rate { get; set; }
}