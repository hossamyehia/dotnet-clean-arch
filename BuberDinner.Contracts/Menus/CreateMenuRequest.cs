// <copyright file="CreateMenuRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Contracts.Menus;

/// <summary>
/// Create Menu Request record.
/// </summary>
public record class CreateMenuRequest(
    string Name,
    string Description,
    List<MenuSection> Sections);

/// <summary>
/// Menu Section record.
/// </summary>
public record class MenuSection(
    string Name,
    string Description,
    List<MenuItem> Items);

/// <summary>
/// Menu Item record.
/// </summary>
public record class MenuItem(
    string Name,
    string Description);