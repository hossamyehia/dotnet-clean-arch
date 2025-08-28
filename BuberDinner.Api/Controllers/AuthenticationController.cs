using BuberDinner.Api.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;

using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Authentication.Common;

namespace BuberDinner.Api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    private ISender _mediator;
    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

        return registerResult.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
        );
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var query = new LoginQuery(
            request.Email,
            request.Password
        );
        ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(query);

        return loginResult.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult result)
    {
        return new AuthenticationResponse
        {
            Id = result.User.Id,
            FirstName = result.User.FirstName,
            LastName = result.User.LastName,
            Email = result.User.Email,
            Token = result.Token
        };
    }
}

