using System;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menus = new();
    private readonly List<DinnerId> _dinners = new();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string profileImage { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public UserId UserId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public IReadOnlyList<MenuId> Menus => _menus.AsReadOnly();
    public IReadOnlyList<DinnerId> Dinners => _dinners.AsReadOnly();

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        this.profileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddMenu(MenuId menuId)
    {
        if (!_menus.Contains(menuId))
        {
            _menus.Add(menuId);
            UpdatedDateTime = DateTime.UtcNow;
        }
    }
    public void AddDinner(DinnerId dinnerId)
    {
        if (!_dinners.Contains(dinnerId))
        {
            _dinners.Add(dinnerId);
            UpdatedDateTime = DateTime.UtcNow;
        }
    }

    public void UpdateAverageRating(AverageRating newRating)
    {
        AverageRating = newRating;
        UpdatedDateTime = DateTime.UtcNow;
    }
}
