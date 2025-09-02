// <copyright file="AuthenticationResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Api.Authentication;

/// <summary>
/// Response returned after a successful authentication.
/// </summary>
public record AuthenticationResponse
{
    /// <summary>
    /// Gets the unique identifier of the authenticated user.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the first name of the authenticated user.
    /// </summary>
    public string FirstName { get; init; } = default!;

    /// <summary>
    /// Gets the last name of the authenticated user.
    /// </summary>
    public string LastName { get; init; } = default!;

    /// <summary>
    /// Gets the email of the authenticated user.
    /// </summary>
    public string Email { get; init; } = default!;

    /// <summary>
    /// Gets the JWT token issued upon successful authentication.
    /// </summary>
    public string Token { get; init; } = default!;
}