// <copyright file="IAbstractID.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.Common.ValueObjects.ID;

/// <summary>
/// Force the creation of a new instance of the ID Object.
/// </summary>
/// <typeparam name="TFrom">The type of the identifier.</typeparam>
/// <typeparam name="T">The type of the ID Object.</typeparam>
public interface IAbstractID<TFrom, T>
{
    /// <summary>
    /// Creates a new instance of the T.
    /// </summary>
    /// <param name="value">The value of the identifier.</param>
    /// <returns>A new instance of the ID Object.</returns>
    public static abstract T CreateFrom(TFrom value);

    /// <summary>
    /// Creates a new instance of the T.
    /// </summary>
    /// <returns>A new instance of the ID Object.</returns>
    public static abstract T CreateUnique();
}