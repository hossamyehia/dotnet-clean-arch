// <copyright file="GuestId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects.ID;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

/// <summary>
/// GuestId Value Object.
/// </summary>
public sealed class GuestId : AbstractID<Guid, GuestId>, IAbstractID<string, GuestId>
{
    private GuestId(Guid value)
        : base(value)
    {
    }

    /// <summary>
    /// Implicit conversion from string to GuestId.
    /// </summary>
    /// <param name="guestId">String value.</param>
    /// <returns>A new GuestId.</returns>
    public static implicit operator GuestId(string guestId) => CreateFrom(guestId);

    /// <summary>
    /// Creates a new unique GuestId.
    /// </summary>
    /// <returns>A new GuestId.</returns>
    public static GuestId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Creates a new GuestId from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new GuestId.</returns>
    public static GuestId CreateFrom(string value) => new(Guid.Parse(value));
}