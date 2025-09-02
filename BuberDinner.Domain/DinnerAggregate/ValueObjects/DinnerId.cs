// <copyright file="DinnerId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

/// <summary>
/// DinnerId Value Object.
/// </summary>
public sealed class DinnerId : ValueObject
{
    private DinnerId(Guid value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the Identifier.
    /// </summary>
    public Guid Value { get; private set; }

    /// <summary>
    /// Creates a unique DinnerId.
    /// </summary>
    /// <returns>DinnerId.</returns>
    public static DinnerId CreateUnique() => new(Guid.NewGuid());

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}