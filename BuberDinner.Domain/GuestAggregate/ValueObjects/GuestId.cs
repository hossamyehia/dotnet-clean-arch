// <copyright file="GuestId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

/// <summary>
/// GuestId Value Object.
/// </summary>
public sealed class GuestId : ValueObject
{
    private GuestId(Guid value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Creates a new unique GuestId.
    /// </summary>
    /// <returns>A new GuestId.</returns>
    public static GuestId CreateUnique() => new(Guid.NewGuid());

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}