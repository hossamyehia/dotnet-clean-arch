using BuberDinner.Api.Authentication;
using BuberDinner.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;

namespace BuberDinner.Api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        return registerResult.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
        );
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        ErrorOr<AuthenticationResult> loginResult = _authenticationService.Login(request.Email, request.Password);

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

