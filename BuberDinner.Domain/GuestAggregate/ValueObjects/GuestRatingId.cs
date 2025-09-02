// <copyright file="GuestRatingId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects.ID;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

/// <summary>
/// Guest Rating Value Object.
/// </summary>
public sealed class GuestRatingId : AbstractID<Guid, GuestRatingId>, IConvertableID<Guid, string, GuestRatingId>
{
    private GuestRatingId(Guid value)
        : base(value)
    {
    }

    /// <summary>
    /// Implicit conversion from string to GuestRating Id.
    /// </summary>
    /// <param name="guestRatingId">String value.</param>
    /// <returns>A new GuestRating Id.</returns>
    public static implicit operator GuestRatingId(string guestRatingId) => CreateFrom(guestRatingId);

    /// <summary>
    /// Creates a new unique GuestRating Id.
    /// </summary>
    /// <returns>A new GuestRating Id.</returns>
    public static GuestRatingId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Creates a new GuestRating Id from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new GuestRating Id.</returns>
    public static GuestRatingId CreateFrom(string value) => new(Guid.Parse(value));

    /// <summary>
    /// Creates a new GuestRating Id from a Guid.
    /// </summary>
    /// <param name="value">Guid value.</param>
    /// <returns>A new GuestRating Id.</returns>
    public static GuestRatingId Create(Guid value) => new(value);
}