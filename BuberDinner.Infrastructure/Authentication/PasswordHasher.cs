// <copyright file="PasswordHasher.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Infrastructure.Authentication;

/// <summary>
/// Password Hasher implementation.
/// </summary>
/// <seealso cref="IPasswordHasher" />
/// <remarks>Uses BCrypt.Net-Next package.</remarks>
/// <seealso href="https://www.nuget.org/packages/BCrypt.Net-Next/">BCrypt.Net-Next package</seealso>
public class PasswordHasher : IPasswordHasher
{
    /// <inheritdoc/>
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    /// <inheritdoc/>
    public bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}