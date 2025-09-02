// <copyright file="Price.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

/// <summary>
/// Price Value Object.
/// </summary>
public sealed class Price : ValueObject
{
    private Price(decimal amount, string currency)
    {
        this.Amount = amount;
        this.Currency = currency;
    }

    /// <summary>
    /// Gets the amount of the price.
    /// </summary>
    public decimal Amount { get; private set; }

    /// <summary>
    /// Gets the currency of the price.
    /// </summary>
    public string Currency { get; private set; }

    /// <summary>
    /// Creates a new instance of the <see cref="Price"/> class.
    /// </summary>
    /// <param name="amount">The amount of the price.</param>
    /// <param name="currency">The currency of the price.</param>
    /// <returns>A new instance of the <see cref="Price"/> class.</returns>
    public static Price Create(decimal amount, string currency) => new(amount, currency);

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Amount;
        yield return this.Currency;
    }
}