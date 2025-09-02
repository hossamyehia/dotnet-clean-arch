// <copyright file="GetMenusQueries.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Contracts.Menus;

/// <summary>
/// Query for getting menus.
/// </summary>
/// <param name="PageNumber">The page number.</param>
/// <param name="PageSize">Size of the page.</param>
public record class GetMenusQueries(int PageNumber, int PageSize);