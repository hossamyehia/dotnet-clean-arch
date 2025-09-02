// <copyright file="LoginQueryHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

/// <summary>
/// Handler for logging in a user.
/// </summary>
public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginQueryHandler"/> class.
    /// </summary>
    /// <param name="jwtTokenGenerator">The JWT token generator.</param>
    /// <param name="userRepository">The user repository.</param>
    /// <param name="passwordHasher">The password hasher.</param>
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        this._jwtTokenGenerator = jwtTokenGenerator;
        this._userRepository = userRepository;
        this._passwordHasher = passwordHasher;
    }

    /// <inheritdoc/>
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var user = this._userRepository.GetUserByEmail(query.Email);
        if (user is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Verify the password
        if (!this._passwordHasher.VerifyPassword(password: query.Password, user.Password))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = this._jwtTokenGenerator.GenerateToken(user);

        // Return the JWT token
        return new AuthenticationResult
        {
            User = user,
            Token = token,
        };
    }
}