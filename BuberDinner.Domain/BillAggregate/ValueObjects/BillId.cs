// <copyright file="BillId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects;

/// <summary>
/// BillId Value Object.
/// </summary>
public sealed class BillId : ValueObject
{
    private BillId(Guid value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the Identifier.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Creates a new unique BillId.
    /// </summary>
    /// <returns>A new BillId.</returns>
    public static BillId CreateUnique() => new(Guid.NewGuid());

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}