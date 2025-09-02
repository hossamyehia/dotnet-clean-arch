// <copyright file="MenuSection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

/// <summary>
/// Menu Section Entity.
/// </summary>
public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    private MenuSection(MenuSectionId id, string name, string description)
        : base(id)
    {
        this.Name = name;
        this.Description = description;
    }

    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Gets the items.
    /// </summary>
    public IReadOnlyList<MenuItem> Items => this._items.AsReadOnly();

    /// <summary>
    /// Creates a new instance of the <see cref="MenuSection"/> class.
    /// </summary>
    /// <param name="name">The name of the menu section.</param>
    /// <param name="description">The description of the menu section.</param>
    /// <returns>A new instance of the <see cref="MenuSection"/> class.</returns>
    public static MenuSection Create(string name, string description)
    {
        return new(MenuSectionId.CreateUnique(), name, description);
    }
}