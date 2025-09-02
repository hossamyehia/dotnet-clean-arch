// <copyright file="GuestRating.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities;

/// <summary>
/// Guest Rating Entity.
/// </summary>
/// <param name="GuestRatingId">Guest Rating Id.</param>
/// <param name="HostId">Host Id.</param>
/// <param name="DinnerId">Dinner Id.</param>
/// <param name="Rating">Rating.</param>
/// <param name="CreatedDateTime">Created Date Time.</param>
/// <param name="UpdatedDateTime">Updated Date Time.</param>
/// <returns>Guest Rating.</returns>
public sealed class GuestRating : Entity<GuestRatingId>
{
    private GuestRating(
        GuestRatingId guestRatingId,
        HostId hostId,
        DinnerId dinnerId,
        int rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestRatingId)
    {
        this.HostId = hostId;
        this.DinnerId = dinnerId;
        this.Rating = rating;
        this.CreatedDateTime = createdDateTime;
        this.UpdatedDateTime = updatedDateTime;
    }

    /// <summary>
    /// Gets host Id.
    /// </summary>
    public HostId HostId { get; private set; }

    /// <summary>
    /// Gets dinner Id.
    /// </summary>
    public DinnerId DinnerId { get; private set; }

    /// <summary>
    /// Gets rating.
    /// </summary>
    public int Rating { get; private set; }

    /// <summary>
    /// Gets created date time.
    /// </summary>
    public DateTime CreatedDateTime { get; private set; }

    /// <summary>
    /// Gets updated date time.
    /// </summary>
    public DateTime UpdatedDateTime { get; private set; }

    /// <summary>
    /// Creates a new instance of <see cref="GuestRating"/>.
    /// </summary>
    /// <param name="hostId">Host Id.</param>
    /// <param name="dinnerId">Dinner Id.</param>
    /// <param name="rating">Rating.</param>
    /// <returns>A new instance of <see cref="GuestRating"/>.</returns>
    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        int rating)
    {
        return new(
            GuestRatingId.CreateUnique(), // In real scenario, use a better ID generation strategy
            hostId,
            dinnerId,
            rating,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}