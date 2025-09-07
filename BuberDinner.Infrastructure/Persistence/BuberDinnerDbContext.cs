// <copyright file="BuberDinnerDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Infrastructure.Persistence.Configurations;
using BuberDinner.Infrastructure.Persistence.Interceptors;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BuberDinner.Infrastructure.Persistence;

/// <summary>
/// Database context for the BuberDinner application.
/// </summary>
public class BuberDinnerDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    /// <summary>
    /// Initializes a new instance of the <see cref="BuberDinnerDbContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <param name="publishDomainEventsInterceptor">The publish domain events interceptor.</param>
    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor)
        : base(options)
    {
        this._publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    /// <summary>
    /// Gets or sets the menus.
    /// </summary>
    /// <value>The menus.</value>
    public DbSet<Menu> Menus { get; set; } = null!;

    /// <summary>
    /// Configures the model.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(MenuConfigurations).Assembly);
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(pk => pk.ValueGenerated = ValueGenerated.Never);
        base.OnModelCreating(modelBuilder);
    }

    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.AddInterceptors(this._publishDomainEventsInterceptor);
}