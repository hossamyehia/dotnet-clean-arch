// <copyright file="AuthenticationResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Authentication.Common;

/// <summary>
/// Authentication Result record.
/// </summary>
public record AuthenticationResult
{
    /// <summary>
    /// Gets the user.
    /// </summary>
    public User User { get; init; } = default!;

    /// <summary>
    /// Gets the token.
    /// </summary>
    public string Token { get; init; } = default!;
}