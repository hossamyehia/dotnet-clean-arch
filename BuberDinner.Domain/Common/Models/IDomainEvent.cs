// <copyright file="IDomainEvent.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MediatR;

namespace BuberDinner.Domain.Common.Models;

/// <summary>
/// Domain Events Interface.
/// </summary>
public interface IDomainEvent : INotification
{
}