using System;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DinnerStatus Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public string imgUrl { get; private set; }
    public Price Price { get; private set; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public Location Location { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

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
        DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        this.imgUrl = imgUrl;
        Price = price;
        Location = location;
        HostId = hostId;
        MenuId = menuId;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

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
        Name = name;
        Description = description;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        Location = location;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        UpdatedDateTime = DateTime.UtcNow;
    }
    public void Start()
    {
        if (Status != DinnerStatus.Upcoming)
        {
            throw new InvalidOperationException("Only upcoming dinners can be started.");
        }

        Status = DinnerStatus.InProgress;
        StartedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }
    public void End()
    {
        if (Status != DinnerStatus.InProgress)
        {
            throw new InvalidOperationException("Only in-progress dinners can be ended.");
        }

        Status = DinnerStatus.Ended;
        EndedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }
    public void Cancel()
    {
        if (Status == DinnerStatus.Ended)
        {
            throw new InvalidOperationException("Ended dinners cannot be cancelled.");
        }

        Status = DinnerStatus.Cancelled;
        UpdatedDateTime = DateTime.UtcNow;
    }
    public void AddReservation(Reservation reservation)
    {
        if (reservation is null)
        {
            throw new ArgumentNullException(nameof(reservation), "Reservation cannot be null.");
        }

        if (_reservations.Count >= MaxGuests)
        {
            throw new InvalidOperationException("Cannot add more reservations than the maximum number of guests allowed.");
        }

        _reservations.Add(reservation);
        UpdatedDateTime = DateTime.UtcNow;
    }
    public void RemoveReservation(Reservation reservation)
    {
        if (reservation is null)
        {
            throw new ArgumentNullException(nameof(reservation), "Reservation cannot be null.");
        }

        if (!_reservations.Remove(reservation))
        {
            throw new InvalidOperationException("Reservation not found in the dinner's reservations.");
        }

        UpdatedDateTime = DateTime.UtcNow;
    }
}
