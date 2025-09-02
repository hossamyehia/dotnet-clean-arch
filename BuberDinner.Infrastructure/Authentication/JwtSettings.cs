// <copyright file="JwtSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Infrastructure.Authentication;

/// <summary>
/// Settings for JWT (JSON Web Token) authentication.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Gets the secret key used for signing the JWT.
    /// </summary>
    public string Secret { get; init; } = null!;

    /// <summary>
    /// Gets the issuer of the JWT.
    /// </summary>
    public string Issuer { get; init; } = null!;

    /// <summary>
    /// Gets the audience for the JWT.
    /// </summary>
    public string Audience { get; init; } = null!;

    /// <summary>
    /// Gets the expiration time in minutes for the JWT.
    /// </summary>
    public int ExpiryMinutes { get; init; } = 60;
}