// <copyright file="Dinner.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner;

/// <summary>
/// Dinner Aggregate Root.
/// </summary>
public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();

    private Dinner(
        DinnerId id,
        string name,
        string description,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        string imgUrl,
        Price price,
        Location location,
        HostId hostId,
        MenuId menuId,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime? startedDateTime,
        DateTime? endedDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        this.Name = name;
        this.Description = description;
        this.Status = status;
        this.IsPublic = isPublic;
        this.MaxGuests = maxGuests;
        this.ImgUrl = imgUrl;
        this.Price = price;
        this.Location = location;
        this.HostId = hostId;
        this.MenuId = menuId;
        this.StartDateTime = startDateTime;
        this.EndDateTime = endDateTime;
        this.StartedDateTime = startedDateTime;
        this.EndedDateTime = endedDateTime;
        this.CreatedDateTime = createdDateTime;
        this.UpdatedDateTime = updatedDateTime;
    }

    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Gets the status.
    /// </summary>
    public DinnerStatus Status { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the dinner is public.
    /// </summary>
    public bool IsPublic { get; private set; }

    /// <summary>
    /// Gets the maximum number of guests.
    /// </summary>
    public int MaxGuests { get; private set; }

    /// <summary>
    /// Gets the image URL.
    /// </summary>
    public string ImgUrl { get; private set; }

    /// <summary>
    /// Gets the price.
    /// </summary>
    public Price Price { get; private set; }

    /// <summary>
    /// Gets the reservations.
    /// </summary>
    public IReadOnlyList<Reservation> Reservations => this._reservations.AsReadOnly();

    /// <summary>
    /// Gets the host Id.
    /// </summary>
    public HostId HostId { get; private set; }

    /// <summary>
    /// Gets the menu Id.
    /// </summary>
    public MenuId MenuId { get; private set; }

    /// <summary>
    /// Gets the location.
    /// </summary>
    public Location Location { get; private set; }

    /// <summary>
    /// Gets the start date time.
    /// </summary>
    public DateTime StartDateTime { get; private set; }

    /// <summary>
    /// Gets the end date time.
    /// </summary>
    public DateTime EndDateTime { get; private set; }

    /// <summary>
    /// Gets the start date time.
    /// </summary>
    public DateTime? StartedDateTime { get; private set; }

    /// <summary>
    /// Gets the end date time.
    /// </summary>
    public DateTime? EndedDateTime { get; private set; }

    /// <summary>
    /// Gets the created date time.
    /// </summary>
    public DateTime CreatedDateTime { get; private set; }

    /// <summary>
    /// Gets the updated date time.
    /// </summary>
    public DateTime UpdatedDateTime { get; private set; }

    /// <summary>
    /// Creates a new instance of <see cref="Dinner"/>.
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="description">Description.</param>
    /// <param name="isPublic">Is public.</param>
    /// <param name="maxGuests">Max guests.</param>
    /// <param name="imgUrl">Image URL.</param>
    /// <param name="price">Price.</param>
    /// <param name="location">Location.</param>
    /// <param name="hostId">Host Id.</param>
    /// <param name="menuId">Menu Id.</param>
    /// <param name="startDateTime">Start date time.</param>
    /// <param name="endDateTime">End date time.</param>
    /// <returns>A new instance of <see cref="Dinner"/>.</returns>
    public static Dinner Create(
        string name,
        string description,
        bool isPublic,
        int maxGuests,
        string imgUrl,
        Price price,
        Location location,
        HostId hostId,
        MenuId menuId,
        DateTime startDateTime,
        DateTime endDateTime)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            DinnerStatus.Upcoming,
            isPublic,
            maxGuests,
            imgUrl,
            price,
            location,
            hostId,
            menuId,
            startDateTime,
            endDateTime,
            null,
            null,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    /// <summary>
    /// Updates the details.
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="description">Description.</param>
    /// <param name="isPublic">Is public.</param>
    /// <param name="maxGuests">Max guests.</param>
    /// <param name="price">Price.</param>
    /// <param name="location">Location.</param>
    /// <param name="startDateTime">Start date time.</param>
    /// <param name="endDateTime">End date time.</param>
    public void UpdateDetails(
        string name,
        string description,
        bool isPublic,
        int maxGuests,
        Price price,
        Location location,
        DateTime startDateTime,
        DateTime endDateTime)
    {
        this.Name = name;
        this.Description = description;
        this.IsPublic = isPublic;
        this.MaxGuests = maxGuests;
        this.Price = price;
        this.Location = location;
        this.StartDateTime = startDateTime;
        this.EndDateTime = endDateTime;
        this.UpdatedDateTime = DateTime.UtcNow;
    }

    // public void Start()
    // {
    //     if (this.Status != DinnerStatus.Upcoming)
    //     {
    //         throw new InvalidOperationException("Only upcoming dinners can be started.");
    //     }

    // this.Status = DinnerStatus.InProgress;
    //     this.StartedDateTime = DateTime.UtcNow;
    //     this.UpdatedDateTime = DateTime.UtcNow;
    // }

    // public void End()
    // {
    //     if (this.Status != DinnerStatus.InProgress)
    //     {
    //         throw new InvalidOperationException("Only in-progress dinners can be ended.");
    //     }

    // this.Status = DinnerStatus.Ended;
    //     this.EndedDateTime = DateTime.UtcNow;
    //     this.UpdatedDateTime = DateTime.UtcNow;
    // }

    // public void Cancel()
    // {
    //     if (this.Status == DinnerStatus.Ended)
    //     {
    //         throw new InvalidOperationException("Ended dinners cannot be cancelled.");
    //     }

    // this.Status = DinnerStatus.Cancelled;
    //     this.UpdatedDateTime = DateTime.UtcNow;
    // }

    // public void AddReservation(Reservation reservation)
    // {
    //     if (reservation is null)
    //     {
    //         throw new ArgumentNullException(nameof(reservation), "Reservation cannot be null.");
    //     }

    // if (this._reservations.Count >= this.MaxGuests)
    //     {
    //         throw new InvalidOperationException("Cannot add more reservations than the maximum number of guests allowed.");
    //     }

    // this._reservations.Add(reservation);
    //     this.UpdatedDateTime = DateTime.UtcNow;
    // }

    // public void RemoveReservation(Reservation reservation)
    // {
    //     if (reservation is null)
    //     {
    //         throw new ArgumentNullException(nameof(reservation), "Reservation cannot be null.");
    //     }

    // if (!this._reservations.Remove(reservation))
    //     {
    //         throw new InvalidOperationException("Reservation not found in the dinner's reservations.");
    //     }

    // this.UpdatedDateTime = DateTime.UtcNow;
    // }
}