// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate;

/// <summary>
/// Menu Aggregate Root.
/// </summary>
public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    private Menu(MenuId id, string name, string description, HostId hostId, AverageRating averageRating, DateTime createdDateTime, DateTime updatedDateTime)
        : base(id)
    {
        this.Name = name;
        this.Description = description;
        this.HostId = hostId;
        this.CreatedDateTime = createdDateTime;
        this.UpdatedDateTime = updatedDateTime;
        this.AverageRating = averageRating;
    }

    /// <summary>
    /// Gets the name of the menu.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the description of the menu.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Gets the average rating of the menu.
    /// </summary>
    public AverageRating AverageRating { get; private set; }

    /// <summary>
    /// Gets the host id of the menu.
    /// </summary>
    public HostId HostId { get; private set; }

    /// <summary>
    /// Gets the sections of the menu.
    /// </summary>
    public IReadOnlyList<MenuSection> Sections => this._sections.AsReadOnly();

    /// <summary>
    /// Gets the dinner ids associated with the menu.
    /// </summary>
    public IReadOnlyList<DinnerId> DinnerIds => this._dinnerIds.AsReadOnly();

    /// <summary>
    /// Gets the menu review ids associated with the menu.
    /// </summary>
    public IReadOnlyList<MenuReviewId> MenuReviewIds => this._menuReviewIds.AsReadOnly();

    /// <summary>
    /// Gets the date and time when the menu was created.
    /// </summary>
    public DateTime CreatedDateTime { get; private set; }

    /// <summary>
    /// Gets the date and time when the menu was last updated.
    /// </summary>
    public DateTime UpdatedDateTime { get; private set; }

    /// <summary>
    /// Creates a new instance of the <see cref="Menu"/> class.
    /// </summary>
    /// <param name="name">The name of the menu.</param>
    /// <param name="description">The description of the menu.</param>
    /// <param name="hostId">The host id of the menu.</param>
    /// <param name="sections">The sections of the menu.</param>
    /// <returns>A new instance of the <see cref="Menu"/> class.</returns>
    public static Menu Create(string name, string description, HostId hostId, List<MenuSection>? sections)
    {
        var currentDateTime = DateTime.UtcNow;
        var menu = new Menu(MenuId.CreateUnique(), name, description, hostId, AverageRating.Create(0, 0), currentDateTime, currentDateTime);
        menu.AddSections(sections!);
        return menu;
    }

    /// <summary>
    /// Adds a section to the menu.
    /// </summary>
    /// <param name="section">The section to add.</param>
    public void AddSection(MenuSection section) => this._sections.Add(section);

    /// <summary>
    /// Adds multiple sections to the menu.
    /// </summary>
    /// <param name="sections">The sections to add.</param>
    public void AddSections(List<MenuSection>? sections) => this._sections.AddRange(sections!);
}