// <copyright file="Guest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.Entities;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate;

/// <summary>
/// Guest Aggregate Root.
/// </summary>
public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcommingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<GuestRating> _ratings = new();

    #pragma warning disable CS8618
    private Guest()
    {
    }
    #pragma warning restore CS8618

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestId)
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
    /// Gets guest First Name.
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Gets guest Last Name.
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Gets guest Profile Image.
    /// </summary>
    public string ProfileImage { get; private set; }

    /// <summary>
    /// Gets guest Average Rating.
    /// </summary>
    public AverageRating AverageRating { get; private set; }

    /// <summary>
    /// Gets guest User Id.
    /// </summary>
    public UserId UserId { get; private set; }

    /// <summary>
    /// Gets guest Created Date Time.
    /// </summary>
    public DateTime CreatedDateTime { get; private set; }

    /// <summary>
    /// Gets guest Updated Date Time.
    /// </summary>
    public DateTime UpdatedDateTime { get; private set; }

    /// <summary>
    /// Gets guest Upcomming Dinner Ids.
    /// </summary>
    public IReadOnlyList<DinnerId> UpcommingDinnerIds => this._upcommingDinnerIds.AsReadOnly();

    /// <summary>
    /// Gets guest Past Dinner Ids.
    /// </summary>
    public IReadOnlyList<DinnerId> PastDinnerIds => this._pastDinnerIds.AsReadOnly();

    /// <summary>
    /// Gets guest Pending Dinner Ids.
    /// </summary>
    public IReadOnlyList<DinnerId> PendingDinnerIds => this._pendingDinnerIds.AsReadOnly();

    /// <summary>
    /// Gets guest Bill Ids.
    /// </summary>
    public IReadOnlyList<BillId> BillIds => this._billIds.AsReadOnly();

    /// <summary>
    /// Gets guest Menu Review Ids.
    /// </summary>
    public IReadOnlyList<MenuReviewId> MenuReviewIds => this._menuReviewIds.AsReadOnly();

    /// <summary>
    /// Gets guest Ratings.
    /// </summary>
    public IReadOnlyList<GuestRating> Ratings => this._ratings.AsReadOnly();

    /// <summary>
    /// Creates a new instance of <see cref="Guest"/>.
    /// </summary>
    /// <param name="firstName">First Name.</param>
    /// <param name="lastName">Last Name.</param>
    /// <param name="profileImage">Profile Image.</param>
    /// <param name="averageRating">Average Rating.</param>
    /// <param name="userId">User Id.</param>
    /// <returns>A new instance of <see cref="Guest"/>.</returns>
    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}