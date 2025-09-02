// <copyright file="AverageRating.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

/// <summary>
/// AverageRating Value Object.
/// </summary>
/// <remarks>
/// Represents the average rating value and the number of ratings.
/// </remarks>
public sealed class AverageRating : ValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AverageRating"/> class.
    /// </summary>
    /// <param name="value">The average rating value (between 0 and 5).</param>
    /// <param name="numRatings">The number of ratings contributing to the average.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is not between 0 and 5.</exception>
    private AverageRating(float value, int numRatings = 0)
    {
        if (value < 0 || value > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Average rating must be between 0 and 5.");
        }

        this.Value = value;
        this.NumRatings = numRatings;
    }

    /// <summary>
    /// Gets the average rating value.
    /// </summary>
    public float Value { get; private set; }

    /// <summary>
    /// Gets the number of ratings contributing to the average.
    /// </summary>
    public int NumRatings { get; private set; }

    /// <summary>
    /// Creates a new instance of <see cref="AverageRating"/> with the specified value and
    /// number of ratings.
    /// </summary>
    /// <param name="value">The average rating value (between 0 and 5).</param>
    /// <param name="numRatings">The number of ratings contributing to the average.</param>
    /// <returns>A new instance of <see cref="AverageRating"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is not between 0 and 5.</exception>
    public static AverageRating Create(float value, int numRatings) => new(value, numRatings);

    /// <summary>
    /// Adds a new rating and updates the average rating accordingly.
    /// </summary>
    /// <param name="rating">The new rating to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when the rating is null.</exception>
    public void AddNewRating(Rating rating)
    {
        ArgumentNullException.ThrowIfNull(rating);

        this.Value = ((this.Value * this.NumRatings) + rating.Value) / (this.NumRatings + 1);
        this.NumRatings++;
    }

    /// <summary>
    /// Removes a rating and updates the average rating accordingly.
    /// </summary>
    /// <param name="rating">The rating to remove.</param>
    /// <exception cref="ArgumentNullException">Thrown when the rating is null.</exception>
    public void RemoveRating(Rating rating)
    {
        ArgumentNullException.ThrowIfNull(rating);

        if (this.NumRatings == 0)
        {
            throw new InvalidOperationException("No ratings to remove.");
        }

        this.Value = ((this.Value * this.NumRatings) - rating.Value) / (this.NumRatings - 1);
        this.NumRatings--;
    }

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}