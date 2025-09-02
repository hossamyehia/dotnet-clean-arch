// <copyright file="ReservationStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.DinnerAggregate.Enums;

/// <summary>
/// Reservation Status Enum.
/// </summary>
public enum ReservationStatus
{
    /// <summary>
    /// The reservation is pending guest confirmation.
    /// </summary>
    PendingGuestConfirmation,

    /// <summary>
    /// The reservation is confirmed and reserved.
    /// </summary>
    Reserved,

    /// <summary>
    /// The reservation has been cancelled.
    /// </summary>
    Cancelled,
}