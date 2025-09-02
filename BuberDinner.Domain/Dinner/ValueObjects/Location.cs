// <copyright file="Location.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

/// <summary>
/// Location Value Object.
/// </summary>
public sealed class Location : ValueObject
{
    private Location(string name, string address, decimal latitude, decimal longitude)
    {
        this.Name = name;
        this.Address = address;
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the address.
    /// </summary>
    public string Address { get; private set; }

    /// <summary>
    /// Gets the latitude.
    /// </summary>
    public decimal Latitude { get; private set; }

    /// <summary>
    /// Gets the longitude.
    /// </summary>
    public decimal Longitude { get; private set; }

    /// <summary>
    /// Creates a new Location.
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="address">Address.</param>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    /// <returns>Location.</returns>
    public static Location Create(string name, string address, decimal latitude, decimal longitude) => new(name, address, latitude, longitude);

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Name;
        yield return this.Address;
        yield return this.Latitude;
        yield return this.Longitude;
    }
}