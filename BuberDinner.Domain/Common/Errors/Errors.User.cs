// <copyright file="Errors.User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

/// <summary>
/// User related errors.
/// </summary>
public static partial class Errors
{
    /// <summary>
    /// User related errors.
    /// </summary>
    public static class User
    {
        /// <summary>
        /// Gets if you already have an account, you can reset your password.
        /// </summary>
        /// <returns>An Error object representing a duplicate email error.</returns>
        public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "If you already have an account, you can reset your password.");
    }
}