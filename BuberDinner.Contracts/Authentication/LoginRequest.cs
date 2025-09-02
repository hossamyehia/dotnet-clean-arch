// <copyright file="LoginRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Api.Authentication;

public record LoginRequest
{
    /// <summary>
    /// Gets user email.
    /// </summary>
    public string Email { get; init; } = default!;

    /// <summary>
    /// Gets user password.
    /// </summary>
    public string Password { get; init; } = default!;
}