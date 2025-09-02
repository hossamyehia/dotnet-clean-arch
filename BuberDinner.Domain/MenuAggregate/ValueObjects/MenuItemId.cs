// <copyright file="MenuItemId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.ValueObjects.ID;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

/// <summary>
/// MenuItemId Value Object.
/// </summary>
public sealed class MenuItemId : AbstractID<Guid, MenuItemId>, IConvertableID<Guid, string, MenuItemId>
{
    private MenuItemId(Guid value)
        : base(value)
    {
    }

    /// <summary>
    /// Implicit conversion from string to MenuItem Id.
    /// </summary>
    /// <param name="menuItemId">The string to convert.</param>
    /// <returns>The converted MenuItem Id.</returns>
    public static implicit operator MenuItemId(string menuItemId) => CreateFrom(menuItemId);

    /// <summary>
    /// Creates a new unique MenuItem Id.
    /// </summary>
    /// <returns>MenuItem Id.</returns>
    public static MenuItemId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Creates a new MenuItemId from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new MenuItem Id.</returns>
    public static MenuItemId CreateFrom(string value) => new(Guid.Parse(value));

    /// <summary>
    /// Creates a new MenuItemId from a Guid.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new MenuItem Id.</returns>
    public static MenuItemId Create(Guid value) => new(value);
}