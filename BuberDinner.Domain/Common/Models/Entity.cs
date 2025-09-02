// <copyright file="Entity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.Common.Models;

/// <summary>
/// Base class for all entities in the domain.
/// </summary>
/// <typeparam name="TId">The type of the entity's identifier.</typeparam>
/// <seealso cref="IEquatable{Entity{TId}}"/>
public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TId}"/> class.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    protected Entity(TId id)
    {
        this.Id = id;
    }

    /// <summary>
    /// Gets or sets the identifier of the entity.
    /// </summary>
    /// <value>The identifier of the entity.</value>
    public TId Id { get; protected set; }

    /// <summary>
    /// Determines whether two specified entities have the same value.
    /// </summary>
    /// <param name="a">The first entity to compare.</param>
    /// <param name="b">The second entity to compare.</param>
    /// <returns>true if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise, false.</returns>
    public static bool operator ==(Entity<TId>? a, Entity<TId>? b)
    {
        return Equals(a, b);
    }

    /// <summary>
    /// Determines whether two specified entities have different values.
    /// </summary>
    /// <param name="a">The first entity to compare.</param>
    /// <param name="b">The second entity to compare.</param>
    /// <returns>true if the value of <paramref name="a"/> is different from the value of <paramref name="b"/>; otherwise, false.</returns>
    public static bool operator !=(Entity<TId>? a, Entity<TId>? b)
    {
        return !Equals(a, b);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> other && this.Id.Equals(other.Id);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    /// <inheritdoc/>
    public bool Equals(Entity<TId>? other)
    {
        return this.Equals((object?)other);
    }
}