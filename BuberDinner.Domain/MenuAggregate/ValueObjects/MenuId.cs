// <copyright file="MenuId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.ValueObjects.ID;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

/// <summary>
/// MenuId Value Object.
/// </summary>
public sealed class MenuId : AbstractID<Guid, MenuId>, IConvertableID<Guid, string, MenuId>
{
    private MenuId(Guid value)
        : base(value)
    {
    }

    /// <summary>
    /// Implicit conversion from string to MenuId.
    /// </summary>
    /// <param name="menuId">The string to convert.</param>
    /// <returns>The converted MenuId.</returns>
    public static implicit operator MenuId(string menuId) => CreateFrom(menuId);

    /// <summary>
    /// Creates a new unique MenuId.
    /// </summary>
    /// <returns>MenuId.</returns>
    public static MenuId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Creates a new MenuId from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new MenuId.</returns>
    public static MenuId CreateFrom(string value) => new(Guid.Parse(value));

    /// <summary>
    /// Creates a new MenuId from a Guid.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new MenuId.</returns>
    public static MenuId Create(Guid value) => new(value);
}