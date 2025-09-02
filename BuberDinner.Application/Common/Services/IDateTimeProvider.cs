// <copyright file="IDateTimeProvider.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Application.Common.Services;

/// <summary>
/// Provides the current date and time in UTC.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    /// Gets the current date and time in UTC.
    /// </summary>
    DateTime UtcNow { get; }
}