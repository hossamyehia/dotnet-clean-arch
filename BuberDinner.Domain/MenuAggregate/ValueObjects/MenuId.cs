// <copyright file="MenuId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

/// <summary>
/// MenuId Value Object.
/// </summary>
public sealed class MenuId : ValueObject
{
    private MenuId(Guid value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the Identifier.
    /// </summary>
    public Guid Value { get; private set; }

    /// <summary>
    /// Creates a new unique MenuId.
    /// </summary>
    /// <returns>MenuId.</returns>
    public static MenuId CreateUnique() => new(Guid.NewGuid());

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}