using System;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
{
    public Price Price { get; private set; } 
    public DateTime IssuedDate { get; private set; }
    public DateTime? PaidDate { get; private set; }
    public bool IsPaid => PaidDate.HasValue;

    private Bill(BillId id, Price price, DateTime issuedDate, DateTime? paidDate)
        : base(id)
    {
        Price = price;
        IssuedDate = issuedDate;
        PaidDate = paidDate;
    }

    public static Bill Create(Price price)
    {
        return new Bill(
            BillId.CreateUnique(),
            price,
            DateTime.UtcNow,
            null);
    }

    public void MarkAsPaid()
    {
        if (IsPaid)
        {
            throw new InvalidOperationException("Bill is already paid.");
        }

        PaidDate = DateTime.UtcNow;
    }
}
