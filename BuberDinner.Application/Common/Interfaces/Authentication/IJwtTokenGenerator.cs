// <copyright file="IJwtTokenGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Common.Interfaces.Authentication;

/// <summary>
/// JWT Token Generator Interface.
/// </summary>
public interface IJwtTokenGenerator
{
    /// <summary>
    /// Generates a JWT token for the specified user.
    /// </summary>
    /// <param name="user">The user to generate the token for.</param>
    /// <returns>A JWT token as a string.</returns>
    string GenerateToken(User user);
}