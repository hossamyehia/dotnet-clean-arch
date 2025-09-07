// <copyright file="MenuCreated.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.Events;

/// <summary>
/// Menu Created Event.
/// </summary>
/// <param name="Menu">The menu.</param>
public record class MenuCreated(Menu Menu) : IDomainEvent;