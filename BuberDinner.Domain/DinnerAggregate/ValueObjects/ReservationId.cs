// <copyright file="ReservationId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects.ID;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

/// <summary>
/// Represents a unique identifier for a reservation.
/// </summary>
/// <remarks>
/// This value object encapsulates a GUID to uniquely identify a reservation instance.
/// </remarks>
public sealed class ReservationId : AbstractID<Guid, ReservationId>, IConvertableID<Guid, string, ReservationId>
{
    private ReservationId(Guid value)
        : base(value)
    {
    }

    /// <summary>
    /// Implicit conversion from string to Reservation Id.
    /// </summary>
    /// <param name="dinnerId">The string to convert.</param>
    /// <returns>The converted Reservation Id.</returns>
    public static implicit operator ReservationId(string dinnerId) => CreateFrom(dinnerId);

    /// <summary>
    /// Creates a new unique ReservationId.
    /// </summary>
    /// <returns>ReservationId.</returns>
    public static ReservationId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Creates a new Reservation Id from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new ReservationId.</returns>
    public static ReservationId CreateFrom(string value) => new(Guid.Parse(value));

    /// <summary>
    /// Creates a new ReservationId from a Guid.
    /// </summary>
    /// <param name="value">Guid value.</param>
    /// <returns>A new ReservationId.</returns>
    public static ReservationId Create(Guid value) => new(value);
}