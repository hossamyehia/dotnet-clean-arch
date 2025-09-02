// <copyright file="IConvertableID.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.Common.ValueObjects.ID;

/// <summary>
/// Interface for Ensuring the possibility to convert the ID Object.
/// </summary>
/// <typeparam name="TId">The type of the identifier.</typeparam>
/// <typeparam name="TFrom">The type of the input parameter.</typeparam>
/// <typeparam name="T">The type of the ID Object.</typeparam>
public interface IConvertableID<TId, TFrom, T> : IAbstractID<TId, T>
    where T : AbstractID<TId, T>
{
    /// <summary>
    /// Creates a new instance of the T.
    /// </summary>
    /// <param name="value">The value of the identifier.</param>
    /// <returns>A new instance of the ID Object.</returns>
    public static abstract T CreateFrom(TFrom value);
}