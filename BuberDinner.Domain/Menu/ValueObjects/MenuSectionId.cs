// <copyright file="MenuSectionId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

/// <summary>
/// Menu Section Id Value Object.
/// </summary>
public sealed class MenuSectionId : ValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MenuSectionId"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    private MenuSectionId(Guid value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the Identifier.
    /// </summary>
    public Guid Value { get; private set; }

    /// <summary>
    /// Creates a unique MenuSectionId.
    /// </summary>
    /// <returns>MenuSectionId.</returns>
    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}