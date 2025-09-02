// <copyright file="UserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

/// <summary>
/// In-memory user repository for demonstration purposes.
/// </summary>
/// <remarks>Replace with a real database implementation in production.</remarks>
public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    /// <inheritdoc/>
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault<User>(u => u.Email == email);
    }

    /// <inheritdoc/>
    public void AddUser(User user)
    {
        _users.Add(user);
    }
}