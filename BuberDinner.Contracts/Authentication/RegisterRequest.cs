// <copyright file="RegisterRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Api.Authentication;

/// <summary>
/// Register Request record.
/// </summary>
public record RegisterRequest
{
    /// <summary>
    /// Gets the first name of the user.
    /// </summary>
    public string FirstName { get; init; } = default!;

    /// <summary>
    /// Gets the last name of the user.
    /// </summary>
    public string LastName { get; init; } = default!;

    /// <summary>
    /// Gets the email address of the user.
    /// </summary>
    public string Email { get; init; } = default!;

    /// <summary>
    /// Gets the password of the user.
    /// </summary>
    public string Password { get; init; } = default!;
}