// <copyright file="AuthenticationController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Api.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

/// <summary>
/// Controller for handling authentication-related requests.
/// </summary>
[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator instance.</param>
    /// <param name="mapper">The mapper instance.</param>
    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        this._mediator = mediator;
        this._mapper = mapper;
    }

    /// <summary>
    /// Handles the registration request.
    /// </summary>
    /// <param name="request">The registration request.</param>
    /// <returns>An IActionResult representing the result of the registration request.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = this._mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> registerResult = await this._mediator.Send(command);

        return registerResult.Match(
            result => this.Ok(this._mapper.Map<AuthenticationResponse>(result)),
            errors => this.Problem(errors));
    }

    /// <summary>
    /// Handles the login request.
    /// </summary>
    /// <param name="request">The login request.</param>
    /// <returns>An IActionResult representing the result of the login request.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var query = this._mapper.Map<LoginQuery>(request);
        ErrorOr<AuthenticationResult> loginResult = await this._mediator.Send(query);

        return loginResult.Match(
            result => this.Ok(this._mapper.Map<AuthenticationResponse>(result)),
            errors => this.Problem(errors));
    }
}