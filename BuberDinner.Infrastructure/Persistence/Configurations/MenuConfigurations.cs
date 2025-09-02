// <copyright file="MenuConfigurations.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuration for the Menu entity.
/// </summary>
public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        this.ConfigureMenusTable(builder);
        this.ConfigureMenuSectionsTable(builder);
        this.ConfigureMenuDinnerIdsTable(builder);
        this.ConfigureMenuReviewIdsTable(builder);
    }

    /// <summary>
    /// Configures the menus table.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        // Primary key
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .HasConversion(
                id => id.Value,
                v => MenuId.Create(v));

        // Name
        builder.Property(m => m.Name)
            .HasMaxLength(100)
            .IsRequired();

        // Description
        builder.Property(m => m.Description)
            .HasMaxLength(100)
            .IsRequired();

        // Average rating
        builder.OwnsOne(m => m.AverageRating);

        // Host Id
        builder.Property(m => m.HostId)
                .HasConversion(
                    id => id.Value,
                    v => HostId.Create(v));
    }

    /// <summary>
    /// Configures the menu sections table.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, sb =>
        {
            // Table
            sb.ToTable("MenuSections");
            sb.WithOwner().HasForeignKey("MenuId");

            // Primary key
            sb.HasKey(nameof(MenuSection.Id), "MenuId");

            // Properties
            sb.Property(ms => ms.Id)
                .HasColumnName("MenuSectionId")
                .HasConversion(
                    id => id.Value,
                    v => MenuSectionId.Create(v));

            sb.Property(ms => ms.Name)
                .HasMaxLength(100)
                .IsRequired();

            sb.Property(ms => ms.Description)
                .HasMaxLength(100)
                .IsRequired();

            sb.OwnsMany(s => s.Items, ib =>
            {
                // Table
                ib.ToTable("MenuItems");
                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                // Primary key
                ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                // Properties
                ib.Property(mi => mi.Id)
                    .HasColumnName("MenuItemId")
                    .HasConversion(
                        id => id.Value,
                        v => MenuItemId.Create(v));

                ib.Property(mi => mi.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                ib.Property(mi => mi.Description)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            // Navigation
            sb.Navigation(s => s.Items).Metadata.SetField("_items");
            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        // Navigation
        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    /// <summary>
    /// Configures the menu dinner ids table.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dib =>
        {
            dib.ToTable("MenuDinnerIds");
            dib.WithOwner().HasForeignKey("MenuId");
            dib.HasKey("Id");
            dib.Property("Id").HasAnnotation("SqlServer:identity", "1, 1");

            dib.Property(md => md.Value)
                .HasColumnName("DinnerId")
;
        });

        // Navigation
        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    /// <summary>
    /// Configures the menu review ids table.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, rib =>
        {
            rib.ToTable("MenuReviewIds");
            rib.WithOwner().HasForeignKey("MenuId");
            rib.HasKey("Id");
            rib.Property("Id").HasAnnotation("SqlServer:identity", "1, 1");

            rib.Property(md => md.Value)
                .HasColumnName("ReviewId")
;
        });

        // Navigation
        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}