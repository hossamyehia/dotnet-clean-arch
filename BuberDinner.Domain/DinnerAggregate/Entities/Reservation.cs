// <copyright file="Reservation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

/// <summary>
/// Represents a reservation made by a guest for a dinner event.
/// </summary>
/// <remarks>
/// A reservation includes details such as the number of guests, reservation status,
/// arrival time, and associated guest and bill information.
/// </remarks>
public sealed class Reservation : Entity<ReservationId>
{
    #pragma warning disable CS8618
    private Reservation()
    {
    }
    #pragma warning restore CS8618

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        ReservationStatus reservationStatus,
        DateTime arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        GuestId guestId,
        BillId billId)
        : base(reservationId)
    {
        this.GuestCount = guestCount;
        this.ReservationStatus = reservationStatus;
        this.ArrivalDateTime = arrivalDateTime;
        this.CreatedDateTime = createdDateTime;
        this.UpdatedDateTime = updatedDateTime;
        this.GuestId = guestId;
        this.BillId = billId;
    }

    /// <summary>
    /// Gets the number of guests for this reservation.
    /// </summary>
    public int GuestCount { get; private set; }

    /// <summary>
    /// Gets the current status of the reservation.
    /// </summary>
    public ReservationStatus ReservationStatus { get; private set; }

    /// <summary>
    /// Gets the scheduled arrival date and time for the reservation.
    /// </summary>
    public DateTime ArrivalDateTime { get; private set; }

    /// <summary>
    /// Gets the date and time when the reservation was created.
    /// </summary>
    public DateTime CreatedDateTime { get; private set; }

    /// <summary>
    /// Gets the date and time when the reservation was last updated.
    /// </summary>
    public DateTime UpdatedDateTime { get; private set; }

    /// <summary>
    /// Gets the identifier of the guest who made the reservation.
    /// </summary>
    public GuestId GuestId { get; private set; }

    /// <summary>
    /// Gets the identifier of the bill associated with this reservation.
    /// </summary>
    public BillId BillId { get; private set; }

    /// <summary>
    /// Creates a new reservation instance.
    /// </summary>
    /// <param name="guestCount">The number of guests in the reservation.</param>
    /// <param name="arrivalDateTime">The scheduled arrival date and time.</param>
    /// <param name="guestId">The identifier of the guest making the reservation.</param>
    /// <param name="billId">The identifier of the associated bill.</param>
    /// <returns>A new <see cref="Reservation"/> instance.</returns>
    public static Reservation Create(
        int guestCount,
        DateTime arrivalDateTime,
        GuestId guestId,
        BillId billId)
    {
        return new Reservation(
            ReservationId.CreateUnique(),
            guestCount,
            ReservationStatus.PendingGuestConfirmation,
            arrivalDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow,
            guestId,
            billId);
    }

    /// <summary>
    /// Confirms the reservation, changing its status to 'Reserved'.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the reservation is not in a state where it can be confirmed.</exception>
    public void Confirm()
    {
        if (this.ReservationStatus != ReservationStatus.PendingGuestConfirmation)
        {
            throw new InvalidOperationException("Only pending reservations can be confirmed.");
        }

        this.ReservationStatus = ReservationStatus.Reserved;
        this.UpdatedDateTime = DateTime.UtcNow;
    }

    /// <summary>
    /// Cancels the reservation, changing its status to 'Cancelled'.
    /// </summary>
    public void Cancel()
    {
        if (this.ReservationStatus == ReservationStatus.Cancelled)
        {
            throw new InvalidOperationException("Reservation is already cancelled.");
        }

        this.ReservationStatus = ReservationStatus.Cancelled;
        this.UpdatedDateTime = DateTime.UtcNow;
    }
}