// <copyright file="IUserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.User;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

/// <summary>
/// User repository interface.
/// </summary>
/// <remarks>Define methods for user data access and manipulation.</remarks>
public interface IUserRepository
{
    /// <summary>
    /// Retrieves a user by email.
    /// </summary>
    /// <param name="email">The email of the user to retrieve.</param>
    /// <returns>The user with the specified email, or null if not found.</returns>
    User? GetUserByEmail(string email);

    /// <summary>
    /// Adds a new user to the repository.
    /// </summary>
    /// <param name="user">The user to add.</param>
    void AddUser(User user);
}