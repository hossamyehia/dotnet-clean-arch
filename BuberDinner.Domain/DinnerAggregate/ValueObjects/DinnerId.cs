// <copyright file="DinnerId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects.ID;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

/// <summary>
/// DinnerId Value Object.
/// </summary>
public sealed class DinnerId : AbstractID<Guid, DinnerId>, IConvertableID<Guid, string, DinnerId>
{
    private DinnerId(Guid value)
        : base(value)
    {
    }

    /// <summary>
    /// Implicit conversion from string to Dinner Id.
    /// </summary>
    /// <param name="dinnerId">The string to convert.</param>
    /// <returns>The converted Dinner Id.</returns>
    public static implicit operator DinnerId(string dinnerId) => CreateFrom(dinnerId);

    /// <summary>
    /// Creates a new unique DinnerId.
    /// </summary>
    /// <returns>DinnerId.</returns>
    public static DinnerId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Creates a new Dinner Id from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new DinnerId.</returns>
    public static DinnerId CreateFrom(string value) => new(Guid.Parse(value));

    /// <summary>
    /// Creates a new DinnerId from a Guid.
    /// </summary>
    /// <param name="value">Guid value.</param>
    /// <returns>A new DinnerId.</returns>
    public static DinnerId Create(Guid value) => new(value);
}