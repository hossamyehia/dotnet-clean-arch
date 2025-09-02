using System;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    public float Value { get; private set; }

    public int NumRatings { get; private set; }

    private AverageRating(float value, int numRatings = 0)
    {
        if (value < 0 || value > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Average rating must be between 0 and 5.");
        }
        Value = value;
        NumRatings = numRatings;
    }

    public static AverageRating Create(float value, int numRatings) => new(value, numRatings);

    public void AddNewRating(Rating rating)
    {
        ArgumentNullException.ThrowIfNull(rating);

        Value = (Value * NumRatings + rating.Value) / (NumRatings + 1);
        NumRatings++;
    }

    internal void RemoveRating(Rating rating)
    {
        ArgumentNullException.ThrowIfNull(rating);

        if (NumRatings == 0)
        {
            throw new InvalidOperationException("No ratings to remove.");
        }

        Value = (Value * NumRatings - rating.Value) / (NumRatings - 1);
        NumRatings--;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
