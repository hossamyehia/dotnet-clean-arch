// <copyright file="IHasDomainEvents.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.Common.Models;

/// <summary>
/// Has Domain Events Interface.
/// </summary>
public interface IHasDomainEvents
{
    /// <summary>
    /// Gets the domain events.
    /// </summary>
    public IReadOnlyList<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Clears the domain events.
    /// </summary>
    public void ClearDomainEvents();
}