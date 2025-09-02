// <copyright file="UserId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.User.ValueObjects;

/// <summary>
/// UserId Value Object.
/// </summary>
public sealed class UserId : ValueObject
{
    private UserId(Guid value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public Guid Value { get; private set; }

    /// <summary>
    /// Creates a new unique UserId.
    /// </summary>
    /// <returns>A new UserId.</returns>
    public static UserId CreateUnique() => new(Guid.NewGuid());

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }

    /// <inheritdoc/>
    public override string ToString() => this.Value.ToString();
}