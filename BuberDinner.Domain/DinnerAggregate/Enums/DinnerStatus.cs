// <copyright file="DinnerStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.DinnerAggregate.Enums;

/// <summary>
/// DinnerStatus Enum.
/// </summary>
public enum DinnerStatus
{
    /// <summary>
    /// The dinner is scheduled and has not started yet.
    /// </summary>
    Upcoming,

    /// <summary>
    /// The dinner is currently in progress.
    /// </summary>
    InProgress,

    /// <summary>
    /// The dinner has ended.
    /// </summary>
    Ended,

    /// <summary>
    /// The dinner has been cancelled.
    /// </summary>
    Cancelled,
}