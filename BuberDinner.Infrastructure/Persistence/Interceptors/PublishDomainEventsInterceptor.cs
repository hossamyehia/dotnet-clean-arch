// <copyright file="PublishDomainEventsInterceptor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BuberDinner.Infrastructure.Persistence.Interceptors;

/// <summary>
/// Interceptor for publishing domain events.
/// </summary>
public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IPublisher _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="PublishDomainEventsInterceptor"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public PublishDomainEventsInterceptor(IPublisher mediator) => this._mediator = mediator;

    /// <inheritdoc/>
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        this.PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    /// <inheritdoc/>
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await this.PublishDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    /// <summary>
    /// Publishes domain events.
    /// </summary>
    /// <param name="context">The database context.</param>
    private async Task PublishDomainEvents(DbContext? context)
    {
        if (context is null)
        {
            return;
        }

        var entitiesWithEvents = context?.ChangeTracker.Entries<IHasDomainEvents>()
            .Select(x => x.Entity)
            .Where(x => x.DomainEvents.Any());

        var events = entitiesWithEvents?
            .SelectMany(entity => entity.DomainEvents)
            .ToList();

        entitiesWithEvents?.ToList().ForEach(entity => entity.ClearDomainEvents());

        foreach (var @event in events!)
        {
            await this._mediator.Publish(@event);
        }
    }
}