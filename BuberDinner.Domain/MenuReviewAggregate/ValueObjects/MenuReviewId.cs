// <copyright file="MenuReviewId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.ValueObjects.ID;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

/// <summary>
/// MenuReviewId Value Object.
/// </summary>
public sealed class MenuReviewId : AbstractID<Guid, MenuReviewId>, IConvertableID<Guid, string, MenuReviewId>
{
    private MenuReviewId(Guid value)
        : base(value)
    {
    }

    /// <summary>
    /// Implicit conversion from string to MenuReview Id.
    /// </summary>
    /// <param name="menuReviewId">The string to convert.</param>
    /// <returns>The converted MenuReview Id.</returns>
    public static implicit operator MenuReviewId(string menuReviewId) => CreateFrom(menuReviewId);

    /// <summary>
    /// Creates a new unique MenuReview Id.
    /// </summary>
    /// <returns>MenuReview Id.</returns>
    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Creates a new MenuReviewId from a string.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new MenuReview Id.</returns>
    public static MenuReviewId CreateFrom(string value) => new(Guid.Parse(value));

    /// <summary>
    /// Creates a new MenuReviewId from a Guid.
    /// </summary>
    /// <param name="value">String value.</param>
    /// <returns>A new MenuReview Id.</returns>
    public static MenuReviewId Create(Guid value) => new(value);
}