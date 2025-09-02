// <copyright file="Host.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

/// <summary>
/// Host Aggregate Root.
/// </summary>
public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menus = new();
    private readonly List<DinnerId> _dinners = new();

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(hostId)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.ProfileImage = profileImage;
        this.AverageRating = averageRating;
        this.UserId = userId;
        this.CreatedDateTime = createdDateTime;
        this.UpdatedDateTime = updatedDateTime;
    }

    /// <summary>
    /// Gets first Name.
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Gets last Name.
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Gets profile Image.
    /// </summary>
    public string ProfileImage { get; private set; }

    /// <summary>
    /// Gets average Rating.
    /// </summary>
    public AverageRating AverageRating { get; private set; }

    /// <summary>
    /// Gets user Id.
    /// </summary>
    public UserId UserId { get; private set; }

    /// <summary>
    /// Gets created Date Time.
    /// </summary>
    public DateTime CreatedDateTime { get; private set; }

    /// <summary>
    /// Gets updated Date Time.
    /// </summary>
    public DateTime UpdatedDateTime { get; private set; }

    /// <summary>
    /// Gets menus.
    /// </summary>
    public IReadOnlyList<MenuId> Menus => this._menus.AsReadOnly();

    /// <summary>
    /// Gets dinners.
    /// </summary>
    public IReadOnlyList<DinnerId> Dinners => this._dinners.AsReadOnly();

    /// <summary>
    /// Creates a new instance of <see cref="Host"/>.
    /// </summary>
    /// <param name="firstName">First Name.</param>
    /// <param name="lastName">Last Name.</param>
    /// <param name="profileImage">Profile Image.</param>
    /// <param name="averageRating">Average Rating.</param>
    /// <param name="userId">User Id.</param>
    /// <returns>A new instance of <see cref="Host"/>.</returns>
    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    /// <summary>
    /// Adds a menu.
    /// </summary>
    /// <param name="menuId">Menu Id.</param>
    public void AddMenu(MenuId menuId)
    {
        if (!this._menus.Contains(menuId))
        {
            this._menus.Add(menuId);
            this.UpdatedDateTime = DateTime.UtcNow;
        }
    }

    /// <summary>
    /// Adds a dinner.
    /// </summary>
    /// <param name="dinnerId">Dinner Id.</param>
    public void AddDinner(DinnerId dinnerId)
    {
        if (!this._dinners.Contains(dinnerId))
        {
            this._dinners.Add(dinnerId);
            this.UpdatedDateTime = DateTime.UtcNow;
        }
    }

    /// <summary>
    /// Updates average rating.
    /// </summary>
    /// <param name="newRating">New Rating.</param>
    public void UpdateAverageRating(AverageRating newRating)
    {
        this.AverageRating = newRating;
        this.UpdatedDateTime = DateTime.UtcNow;
    }
}