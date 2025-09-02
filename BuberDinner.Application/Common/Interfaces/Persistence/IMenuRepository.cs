// <copyright file="IMenuRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

/// <summary>
/// Menu repository interface.
/// </summary>
public interface IMenuRepository
{
    /// <summary>
    /// Add a new menu.
    /// </summary>
    /// <param name="menu">Menu.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task AddMenu(Menu menu);

    /// <summary>
    /// Get a menu by its id.
    /// </summary>
    /// <param name="menuId">Menu id.</param>
    /// <returns>A menu.</returns>
    Task<Menu> GetMenu(MenuId menuId);

    /// <summary>
    /// Get all menus.
    /// </summary>
    /// <param name="pageNumber">Page number.</param>
    /// <param name="pageSize">Page size.</param>
    /// <returns>A list of menus.</returns>
    Task<List<Menu>> GetMenus(int pageNumber, int pageSize);
}