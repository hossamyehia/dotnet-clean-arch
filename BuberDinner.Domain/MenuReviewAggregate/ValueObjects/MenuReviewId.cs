// <copyright file="MenuReviewId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

/// <summary>
/// MenuReviewId Value Object.
/// </summary>
public sealed class MenuReviewId : ValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MenuReviewId"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    private MenuReviewId(Guid value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the Identifier.
    /// </summary>
    public Guid Value { get; private set; }

    /// <summary>
    /// Creates a unique MenuReviewId.
    /// </summary>
    /// <returns>MenuReviewId.</returns>
    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}