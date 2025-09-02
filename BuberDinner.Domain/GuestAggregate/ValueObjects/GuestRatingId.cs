// <copyright file="GuestRatingId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

/// <summary>
/// Guest Rating Value Object.
/// </summary>
public sealed class GuestRatingId : ValueObject
{
    private GuestRatingId(Guid value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public Guid Value { get; private set; }

    /// <summary>
    /// Creates a new unique GuestRatingId.
    /// </summary>
    /// <returns>A new GuestRatingId.</returns>
    public static GuestRatingId CreateUnique() => new(Guid.NewGuid());

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}