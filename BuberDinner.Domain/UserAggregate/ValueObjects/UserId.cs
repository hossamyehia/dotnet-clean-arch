// <copyright file="UserId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.ValueObjects.ID;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;

/// <summary>
/// UserId Value Object.
/// </summary>
public sealed class UserId : AbstractID<Guid, UserId>, IConvertableID<Guid, string, UserId>
{
    private UserId(Guid value)
        : base(value)
    {
    }

    /// <summary>
    /// Implicit conversion from string to UserId.
    /// </summary>
    /// <param name="userId">The string to convert.</param>
    /// <returns>The converted UserId.</returns>
    public static implicit operator UserId(string userId) => CreateFrom(userId);

    /// <summary>
    /// Creates a new unique UserId.
    /// </summary>
    /// <returns>UserId.</returns>
    public static UserId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Creates a new UserId from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new UserId.</returns>
    public static UserId CreateFrom(string value) => new(Guid.Parse(value));

    /// <summary>
    /// Creates a new UserId from a Guid.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new UserId.</returns>
    public static UserId Create(Guid value) => new(value);
}