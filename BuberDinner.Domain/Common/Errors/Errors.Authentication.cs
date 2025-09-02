// <copyright file="Errors.Authentication.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

/// <summary>
/// Errors related to authentication.
/// </summary>
public static partial class Errors
{
    /// <summary>
    /// Authentication related errors.
    /// </summary>
    public static class Authentication
    {
        /// <summary>
        /// Gets error indicating invalid credentials.
        /// </summary>
        /// <returns>An <see cref="Error"/> representing invalid credentials.</returns>
        public static Error InvalidCredentials => Error.Unauthorized(code: "Authentication.InvalidCredentials", description: "The provided credentials are incorrect.");
    }
}