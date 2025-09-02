// <copyright file="Bill.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Domain.Bill;

/// <summary>
/// Bill Aggregate Root.
/// </summary>
public sealed class Bill : AggregateRoot<BillId>
{
    private Bill(BillId id, Price price, DateTime issuedDate, DateTime? paidDate)
        : base(id)
    {
        this.Price = price;
        this.IssuedDate = issuedDate;
        this.PaidDate = paidDate;
    }

    /// <summary>
    /// Gets the price.
    /// </summary>
    public Price Price { get; private set; }

    /// <summary>
    /// Gets the issued date.
    /// </summary>
    public DateTime IssuedDate { get; private set; }

    /// <summary>
    /// Gets the paid date.
    /// </summary>
    public DateTime? PaidDate { get; private set; }

    /// <summary>
    /// Gets a value indicating whether this instance is paid.
    /// </summary>
    public bool IsPaid => this.PaidDate.HasValue;

    /// <summary>
    /// Creates a new instance of <see cref="Bill"/>.
    /// </summary>
    /// <param name="price">The price.</param>
    /// <returns>A new instance of <see cref="Bill"/>.</returns>
    public static Bill Create(Price price)
    {
        return new Bill(
            BillId.CreateUnique(),
            price,
            DateTime.UtcNow,
            null);
    }

    /// <summary>
    /// Marks the bill as paid.
    /// </summary>
    public void MarkAsPaid()
    {
        if (this.IsPaid)
        {
            throw new InvalidOperationException("Bill is already paid.");
        }

        this.PaidDate = DateTime.UtcNow;
    }
}