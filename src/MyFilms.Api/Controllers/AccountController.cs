using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFilms.Application.Features.User.Commands.Login;
using MyFilms.Application.Features.User.Commands.LogOut;
using MyFilms.Application.Features.User.Commands.Register;

namespace MyFilms.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
    {
        try
        {
            await _mediator.Send(new RegisterUserCommand(registerUserDto));
            return Ok();
        }
        catch (Exception e)
        {
            if (e.Message == "Email already exists")
            {
                return Conflict(e.Message);
            }
            return BadRequest(e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
    {
        try
        {
            var token = await _mediator.Send(new LoginUserCommand(loginUserDto));
            return Ok(token);
        }
        catch (Exception e)
        {
           if (e.Message == "Invalid email or password")
           {
               return Unauthorized(e.Message);
           }

           return BadRequest(e.Message);
        }
    
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _mediator.Send(new LogoutUserCommand());
        return NoContent();
    }
    
}