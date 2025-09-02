// <copyright file="ReservationId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

/// <summary>
/// Represents a unique identifier for a reservation.
/// </summary>
/// <remarks>
/// This value object encapsulates a GUID to uniquely identify a reservation instance.
/// </remarks>
public sealed class ReservationId : ValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReservationId"/> class.
    /// </summary>
    /// <param name="value">The GUID value representing the reservation identifier.</param>
    private ReservationId(Guid value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the value of the reservation identifier.
    /// </summary>
    /// <value>The GUID value representing the reservation identifier.</value>
    public Guid Value { get; }

    /// <summary>
    /// Creates a new unique instance of <see cref="ReservationId"/>.
    /// </summary>
    /// <returns>A new unique instance of <see cref="ReservationId"/>.</returns>
    public static ReservationId CreateUnique() => new(Guid.NewGuid());

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}