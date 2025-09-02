// <copyright file="DateTimeProvider.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastructure.Services;

/// <summary>
/// Provides the current date and time in UTC.
/// </summary>
/// <remarks>
/// This implementation of <see cref="IDateTimeProvider"/> returns the current UTC date and time using <see cref="DateTime.UtcNow"/>.
/// </remarks>
public class DateTimeProvider : IDateTimeProvider
{
    /// <inheritdoc/>
    public DateTime UtcNow => DateTime.UtcNow;
}