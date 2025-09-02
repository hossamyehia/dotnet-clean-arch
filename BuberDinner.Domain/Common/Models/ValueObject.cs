// <copyright file="ValueObject.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.Common.Models;

/// <summary>
/// Base class for value objects, which are immutable and compared by their properties.
/// </summary>
/// <remarks>
/// Value objects are used to represent concepts that do not have a distinct identity,
/// such as a date range or a monetary amount. They are compared based on their property values
/// rather than by reference.
/// </remarks>
public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        return Equals(a, b);
    }

    public static bool operator !=(ValueObject? a, ValueObject? b)
    {
        return !Equals(a, b);
    }

    /// <summary>
    /// When implemented in a derived class, returns the components of the value object
    /// that are used to determine equality.
    /// </summary>
    /// <returns>An enumeration of the components that define the value object.</returns>
    public abstract IEnumerable<object> GetEqualityComponents();

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return this.GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    /// <inheritdoc/>
    public bool Equals(ValueObject? other)
    {
        return this.Equals((object?)other);
    }
}