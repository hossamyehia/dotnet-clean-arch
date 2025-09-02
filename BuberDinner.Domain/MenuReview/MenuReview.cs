using System;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public Rating Rating { get; private set; }
    public string Comment { get; private set; }
    public MenuId MenuId { get; private set; }
    public HostId HostId { get; private set; }
    public GuestId GuestId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private MenuReview(
        MenuReviewId menuReviewId,
        Rating rating,
        string comment,
        MenuId menuId,
        HostId hostId,
        GuestId guestId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        MenuId = menuId;
        HostId = hostId;
        GuestId = guestId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

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
