// <copyright file="CreateMenuCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.MenuAggregate;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

/// <summary>
/// Create Menu Command record.
/// </summary>
/// <param name="Name">The name.</param>
/// <param name="Description">The description.</param>
/// <param name="Sections">The sections.</param>
/// <param name="HostId">The host identifier.</param>
public record CreateMenuCommand(
    string Name,
    string Description,
    List<MenuSectionCommand> Sections,
    string HostId) : IRequest<ErrorOr<Menu>>;

/// <summary>
/// Menu Section record.
/// </summary>
/// <param name="Name">The name.</param>
/// <param name="Description">The description.</param>
/// <param name="Items">The items.</param>
public record class MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items);

/// <summary>
/// Menu Item record.
/// </summary>
/// <param name="Name">The name.</param>
/// <param name="Description">The description.</param>
public record class MenuItemCommand(
    string Name,
    string Description);