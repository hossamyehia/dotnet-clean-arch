// <copyright file="HostId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects.ID;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

/// <summary>
/// HostId Value Object.
/// </summary>
public sealed class HostId : AbstractID<Guid, HostId>, IConvertableID<Guid, string, HostId>
{
    private HostId(Guid value)
        : base(value)
    {
    }

    /// <summary>
    /// Implicit conversion from string to HostId.
    /// </summary>
    /// <param name="hostId">The string to convert.</param>
    /// <returns>The converted HostId.</returns>
    public static implicit operator HostId(string hostId) => CreateFrom(hostId);

    /// <summary>
    /// Creates a new unique HostId.
    /// </summary>
    /// <returns>HostId.</returns>
    public static HostId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Creates a new HostId from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new HostId.</returns>
    public static HostId CreateFrom(string value)
    {
        bool isValid = Guid.TryParse(value, out Guid iD);
        return isValid ? new HostId(iD) : HostId.CreateUnique();
    }

    /// <summary>
    /// Creates a new HostId from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new HostId.</returns>
    public static HostId Create(Guid value) => new(value);
}