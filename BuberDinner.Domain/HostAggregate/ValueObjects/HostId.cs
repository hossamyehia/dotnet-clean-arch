// <copyright file="HostId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

/// <summary>
/// HostId Value Object.
/// </summary>
public sealed class HostId : ValueObject
{
    private HostId(Guid value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the Identifier.
    /// </summary>
    public Guid Value { get; private set; }

    /// <summary>
    /// Creates a new unique HostId.
    /// </summary>
    /// <returns>A new HostId.</returns>
    public static HostId CreateUnique() => new(Guid.NewGuid());

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}