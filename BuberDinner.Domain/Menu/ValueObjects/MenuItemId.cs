// <copyright file="MenuItemId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

/// <summary>
/// MenuItemId Value Object.
/// </summary>
public sealed class MenuItemId : ValueObject
{
    private MenuItemId(Guid value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the Identifier.
    /// </summary>
    public Guid Value { get; private set; }

    /// <summary>
    /// Creates a unique MenuItemId.
    /// </summary>
    /// <returns>A new MenuItemId.</returns>
    public static MenuItemId CreateUnique() => new(Guid.NewGuid());

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}