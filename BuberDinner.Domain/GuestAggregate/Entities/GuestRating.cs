// <copyright file="GuestRating.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate.Entities;

/// <summary>
/// Guest Rating Entity.
/// </summary>
public sealed class GuestRating : Entity<GuestRatingId>
{
    #pragma warning disable CS8618
    private GuestRating()
    {
    }
    #pragma warning restore CS8618

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