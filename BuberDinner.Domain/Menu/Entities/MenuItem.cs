using System;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }

    private MenuItem(MenuItemId id, string name, string description, decimal price) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public static MenuItem Create(string name, string description, decimal price)
    {
        return new(MenuItemId.CreateUnique(), name, description, price);
    }

    public IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return Name;
        yield return Description;
        yield return Price;
    }
}
