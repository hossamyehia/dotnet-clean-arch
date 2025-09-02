// <copyright file="AbstractID.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects.ID;

/// <summary>
/// Base Class For All IDs Value Objects.
/// </summary>
/// <typeparam name="TiD">The type of the identifier.</typeparam>
/// <typeparam name="T">The type of the ValueIDObject.</typeparam>
public abstract class AbstractID<TiD, T> : ValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AbstractID{TiD, T}"/> class.
    /// </summary>
    /// <param name="value">The value of the Abstract ID.</param>
    protected AbstractID(TiD value) => this.Value = value;

    /// <summary>
    /// Gets the value of the Abstract ID.
    /// </summary>
    public TiD Value { get; private set; } = default!;

    /// <inheritdoc/>
    public override string ToString() => this.Value!.ToString()!;

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value!;
    }
}