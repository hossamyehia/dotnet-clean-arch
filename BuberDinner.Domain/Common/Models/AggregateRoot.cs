// <copyright file="AggregateRoot.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.Common.Models;

/// <summary>
/// Base class for aggregate roots in the domain-driven design context.
/// An aggregate root is an entity that serves as the entry point for a cluster of related objects.
/// It ensures the integrity of the aggregate as a whole.
/// </summary>
/// <typeparam name="TId">The type of the identifier for the aggregate root.</typeparam>
/// <seealso cref="Entity{TId}"/>
public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{TId}"/> class.
    /// </summary>
    /// <param name="id">The identifier for the aggregate root.</param>
    protected AggregateRoot(TId id)
        : base(id)
    {
    }
}