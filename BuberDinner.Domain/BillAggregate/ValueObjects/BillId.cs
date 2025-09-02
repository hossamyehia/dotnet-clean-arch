// <copyright file="BillId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects.ID;

namespace BuberDinner.Domain.BillAggregate.ValueObjects;

/// <summary>
/// BillId Value Object.
/// </summary>
public sealed class BillId : AbstractID<Guid, BillId>, IConvertableID<Guid, string, BillId>
{
    private BillId(Guid value)
        : base(value)
    {
    }

    /// <summary>
    /// Implicit conversion from string to Bill Id.
    /// </summary>
    /// <param name="billid">The string to convert.</param>
    /// <returns>The converted Bill Id.</returns>
    public static implicit operator BillId(string billid) => CreateFrom(billid);

    /// <summary>
    /// Creates a new unique BillId.
    /// </summary>
    /// <returns>BillId.</returns>
    public static BillId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Creates a new Bill Id from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new BillId.</returns>
    public static BillId CreateFrom(string value) => new(Guid.Parse(value));

    /// <summary>
    /// Creates a new BillId from a Guid.
    /// </summary>
    /// <param name="value">Guid value.</param>
    /// <returns>A new BillId.</returns>
    public static BillId Create(Guid value) => new(value);
}