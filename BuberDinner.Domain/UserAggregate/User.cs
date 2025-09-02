// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.UserAggregate;

/// <summary>
/// User Aggregate Root.
/// </summary>
public sealed class User : AggregateRoot<UserId>
{
    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        string password)
        : base(id)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Password = password;
        this.CreatedDateTime = DateTime.UtcNow;
        this.UpdatedDateTime = DateTime.UtcNow;
    }

    /// <summary>
    /// Gets the first name.
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Gets the last name.
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Gets the email.
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Gets the password.
    /// </summary>
    public string Password { get; private set; }

    /// <summary>
    /// Gets the created date time.
    /// </summary>
    public DateTime CreatedDateTime { get; private set; }

    /// <summary>
    /// Gets the updated date time.
    /// </summary>
    public DateTime UpdatedDateTime { get; private set; }

    /// <summary>
    /// Creates a new instance of <see cref="User"/>.
    /// </summary>
    /// <param name="firstName">First name.</param>
    /// <param name="lastName">Last name.</param>
    /// <param name="email">Email.</param>
    /// <param name="password">Password.</param>
    /// <returns>A new instance of <see cref="User"/>.</returns>
    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new(
            id: UserId.CreateUnique(),
            firstName: firstName,
            lastName: lastName,
            email: email,
            password: password);
    }

    /// <summary>
    /// Updates the user.
    /// </summary>
    /// <param name="firstName">First name.</param>
    /// <param name="lastName">Last name.</param>
    /// <param name="email">Email.</param>
    /// <param name="password">Password.</param>
    public void Update(string firstName, string lastName, string email, string password)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Password = password;
        this.UpdatedDateTime = DateTime.UtcNow;
    }
}