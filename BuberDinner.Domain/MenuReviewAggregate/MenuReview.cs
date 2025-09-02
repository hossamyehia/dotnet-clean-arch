// <copyright file="MenuReview.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;

/// <summary>
/// MenuReview Aggregate Root.
/// </summary>
public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    private MenuReview(
        MenuReviewId menuReviewId,
        Rating rating,
        string comment,
        MenuId menuId,
        HostId hostId,
        GuestId guestId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuReviewId)
    {
        this.Rating = rating;
        this.Comment = comment;
        this.MenuId = menuId;
        this.HostId = hostId;
        this.GuestId = guestId;
        this.CreatedDateTime = createdDateTime;
        this.UpdatedDateTime = updatedDateTime;
    }

    /// <summary>
    /// Gets the rating.
    /// </summary>
    public Rating Rating { get; private set; }

    /// <summary>
    /// Gets the comment.
    /// </summary>
    public string Comment { get; private set; }

    /// <summary>
    /// Gets the menu id.
    /// </summary>
    public MenuId MenuId { get; private set; }

    /// <summary>
    /// Gets the host id.
    /// </summary>
    public HostId HostId { get; private set; }

    /// <summary>
    /// Gets the guest id.
    /// </summary>
    public GuestId GuestId { get; private set; }

    /// <summary>
    /// Gets the created date time.
    /// </summary>
    public DateTime CreatedDateTime { get; private set; }

    /// <summary>
    /// Gets the updated date time.
    /// </summary>
    public DateTime UpdatedDateTime { get; private set; }

    /// <summary>
    /// Creates a new instance of <see cref="MenuReview"/>.
    /// </summary>
    /// <param name="rating">Rating.</param>
    /// <param name="comment">Comment.</param>
    /// <param name="menuId">Menu Id.</param>
    /// <param name="hostId">Host Id.</param>
    /// <param name="guestId">Guest Id.</param>
    /// <returns>A new instance of <see cref="MenuReview"/>.</returns>
    public static MenuReview Create(
        Rating rating,
        string comment,
        MenuId menuId,
        HostId hostId,
        GuestId guestId)
    {
        return new(
            MenuReviewId.CreateUnique(),
            rating,
            comment,
            menuId,
            hostId,
            guestId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}