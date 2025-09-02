// <copyright file="Rating.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

/// <summary>
/// Rating Value Object.
/// </summary>
public sealed class Rating : ValueObject
{
    private Rating(int value)
    {
        if (value < 1 || value > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Rating must be between 1 and 5.");
        }

        this.Value = value;
    }

    /// <summary>
    /// Gets the rating value (between 1 and 5).
    /// </summary>
    public int Value { get; private set; }

    /// <summary>
    /// Creates a new instance of <see cref="Rating"/> with the specified value.
    /// </summary>
    /// <param name="value">The rating value (between 1 and 5).</param>
    /// <returns>A new instance of <see cref="Rating"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is not between 1 and 5.</exception>
    public static Rating Create(int value) => new(value);

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}