// <copyright file="Entity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.Common.Models;

/// <summary>
/// Base class for all entities in the domain.
/// </summary>
/// <typeparam name="TId">The type of the entity's identifier.</typeparam>
public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents
    where TId : notnull
{
    private readonly List<IDomainEvent> _domainEvents = new();

#pragma warning disable CS8618
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TId}"/> class.
    /// </summary>
    protected Entity()
    {
    }
#pragma warning restore CS8618

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
    /// Gets the collection of domain events associated with the entity.
    /// </summary>
    /// <value>The collection of domain events associated with the entity.</value>
    public IReadOnlyList<IDomainEvent> DomainEvents => this._domainEvents.AsReadOnly();

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

    /// <summary>
    /// Adds a domain event to the menu.
    /// </summary>
    /// <param name="domainEvent">The domain event to add.</param>
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        this._domainEvents.Add(domainEvent);
    }

    /// <inheritdoc />
    public void ClearDomainEvents()
    {
        this._domainEvents.Clear();
    }
}