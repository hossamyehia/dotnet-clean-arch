using System;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; private set; }
    public ReservationStatus ReservationStatus { get; private set; }
    public DateTime ArrivalDateTime { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime updatedDateTime { get; private set; }
    public GuestId GuestId { get; private set; }
    public BillId BillId { get; private set; }

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        ReservationStatus reservationStatus,
        DateTime arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        GuestId guestId,
        BillId billId) : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        this.updatedDateTime = updatedDateTime;
        GuestId = guestId;
        BillId = billId;
    }

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

    public void Confirm()
    {
        if (ReservationStatus != ReservationStatus.PendingGuestConfirmation)
        {
            throw new InvalidOperationException("Only pending reservations can be confirmed.");
        }

        ReservationStatus = ReservationStatus.Reserved;
        updatedDateTime = DateTime.UtcNow;
    }
    public void Cancel()
    {
        if (ReservationStatus == ReservationStatus.Cancelled)
        {
            throw new InvalidOperationException("Reservation is already cancelled.");
        }

        ReservationStatus = ReservationStatus.Cancelled;
        updatedDateTime = DateTime.UtcNow;
    }
}
