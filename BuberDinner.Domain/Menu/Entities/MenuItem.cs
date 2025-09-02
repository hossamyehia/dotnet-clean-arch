// <copyright file="MenuItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

/// <summary>
/// Menu Item Entity.
/// </summary>
public sealed class MenuItem : Entity<MenuItemId>
{
    private MenuItem(MenuItemId id, string name, string description, decimal price)
        : base(id)
    {
        this.Name = name;
        this.Description = description;
        this.Price = price;
    }

    /// <summary>
    /// Gets the name of the menu item.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the description of the menu item.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Gets the price of the menu item.
    /// </summary>
    public decimal Price { get; private set; }

    /// <summary>
    /// Creates a new instance of the <see cref="MenuItem"/> class.
    /// </summary>
    /// <param name="name">The name of the menu item.</param>
    /// <param name="description">The description of the menu item.</param>
    /// <param name="price">The price of the menu item.</param>
    /// <returns>A new instance of the <see cref="MenuItem"/> class.</returns>
    public static MenuItem Create(string name, string description, decimal price)
    {
        return new(MenuItemId.CreateUnique(), name, description, price);
    }
}