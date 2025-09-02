// <copyright file="MenuSectionId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.ValueObjects.ID;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

/// <summary>
/// Menu Section Id Value Object.
/// </summary>
public sealed class MenuSectionId : AbstractID<Guid, MenuSectionId>, IConvertableID<Guid, string, MenuSectionId>
{
    private MenuSectionId(Guid value)
        : base(value)
    {
    }

    /// <summary>
    /// Implicit conversion from string to MenuSection Id.
    /// </summary>
    /// <param name="menuSectionId">The string to convert.</param>
    /// <returns>The converted MenuSection Id.</returns>
    public static implicit operator MenuSectionId(string menuSectionId) => CreateFrom(menuSectionId);

    /// <summary>
    /// Creates a new unique MenuSection Id.
    /// </summary>
    /// <returns>MenuSection Id.</returns>
    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Creates a new MenuSectionId from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new MenuSection Id.</returns>
    public static MenuSectionId CreateFrom(string value) => new(Guid.Parse(value));

    /// <summary>
    /// Creates a new MenuSectionId from a Guid.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new MenuSection Id.</returns>
    public static MenuSectionId Create(Guid value) => new(value);
}