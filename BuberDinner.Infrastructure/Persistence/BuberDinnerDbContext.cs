// <copyright file="BuberDinnerDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BuberDinner.Infrastructure.Persistence;

/// <summary>
/// Database context for the BuberDinner application.
/// </summary>
public class BuberDinnerDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BuberDinnerDbContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options)
        : base(options)
    {
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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MenuConfigurations).Assembly);
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(pk => pk.ValueGenerated = ValueGenerated.Never);
        base.OnModelCreating(modelBuilder);
    }
}