// <copyright file="MenuSection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

/// <summary>
/// Menu Section Entity.
/// </summary>
public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    #pragma warning disable CS8618
    private MenuSection()
    {
    }
    #pragma warning restore CS8618

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
    /// <param name="items">The items of the menu section.</param>
    /// <returns>A new instance of the <see cref="MenuSection"/> class.</returns>
    public static MenuSection Create(string name, string description, List<MenuItem>? items = null)
    {
        var menuSection = new MenuSection(MenuSectionId.CreateUnique(), name, description);
        menuSection.AddItems(items!);
        return menuSection;
    }

    /// <summary>
    /// Adds a menu item to the menu section.
    /// </summary>
    /// <param name="menuItem">The menu item to add.</param>
    public void AddItem(MenuItem menuItem) => this._items.Add(menuItem);

    /// <summary>
    /// Adds a menu item to the menu section.
    /// </summary>
    /// <param name="menuItem">The menu item to add.</param>
    public void AddItems(List<MenuItem>? menuItem) => this._items.AddRange(menuItem!);

    /// <summary>
    /// Removes a menu item from the menu section.
    /// </summary>
    /// <param name="menuItem">The menu item to remove.</param>
    public void RemoveItem(MenuItem menuItem) => this._items.Remove(menuItem);
}