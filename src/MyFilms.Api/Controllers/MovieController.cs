using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFilms.Application.Features.Movie.Commands.Create;
using MyFilms.Application.Features.Movie.Commands.Delete;
using MyFilms.Application.Features.Movie.Commands.Update;
using MyFilms.Application.Features.Movie.Queries.GetAllMoviesQuery;
using MyFilms.Application.Features.Movie.Queries.GetMovieByIdQuery;

namespace MyFilms.Controllers;

public class MovieController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<MovieDto>> Get()
    {
        var movies = await _mediator.Send(new GetAllMoviesQuery());
        return movies;
    }

    [HttpGet("id")]
    public async Task<ActionResult<MovieByIdDto>> Get(int id)
    {
        var movieById = await _mediator.Send(new GetMovieByIdQuery(id));
        return movieById;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateMovieCommand movieCommand)
    {
        var response = await _mediator.Send(movieCommand);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateMovieCommand movieCommand)
    {
        await _mediator.Send(movieCommand);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMovieCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}