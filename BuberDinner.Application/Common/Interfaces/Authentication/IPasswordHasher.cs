// <copyright file="IPasswordHasher.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Application.Common.Interfaces.Authentication;

/// <summary>
/// Password Hasher interface.
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Hashes the password.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <returns>The hashed password.</returns>
    string HashPassword(string password);

    /// <summary>
    /// Verifies the password against the hash.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="hash">The hash.</param>
    /// <returns>True if the password matches the hash; otherwise, false.</returns>
    bool VerifyPassword(string password, string hash);
}