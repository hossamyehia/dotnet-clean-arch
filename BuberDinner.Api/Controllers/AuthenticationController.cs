using BuberDinner.Api.Authentication;
using BuberDinner.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;
using BuberDinner.Application.Common.Errors.FluentResult_ApproachErrorHandling;
using FluentResults;
using ErrorOr;
// using BuberDinner.Application.Common.Errors;
// using OneOf;

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

        // FluentResult approach
        // Result<AuthenticationResult> registerResult = _authenticationService.Register(
        //     request.FirstName,
        //     request.LastName,
        //     request.Email,
        //     request.Password
        // );

        // if (registerResult.IsFailed)
        // {
        //     var firstError = registerResult.Errors[0];
        //     var (statusCode, message) = firstError switch
        //     {
        //         DuplicateEmailError => (409, "Email already exists"),
        //         // AnotherCustomError => (400, firstError.Message),
        //         _ => (500, "An unexpected error occurred")
        //     };
        //     return Problem(statusCode: statusCode, title: message);
        // }
        // return Ok(MapAuthResult(registerResult.Value));
        // OneOf approach
        // OneOf<AuthenticationResult, IError_OneOf> registerResult = _authenticationService.Register();
        // return registerResult.Match(
        //     result => Ok(MapAuthResult(result)),
        //     error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
        // );
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

