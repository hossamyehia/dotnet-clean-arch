// <copyright file="MenuRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence;

/// <summary>
/// In-memory menu repository for demonstration purposes.
/// </summary>
public class MenuRepository : IMenuRepository
{
    private readonly List<Menu> _menus = new();

    /// <inheritdoc/>
    public Task AddMenu(Menu menu)
    {
        this._menus.Add(menu);
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task<Menu> GetMenu(MenuId menuId)
    {
        var menu = this._menus.SingleOrDefault(m => m.Id == menuId);
        return Task.FromResult(menu!);
    }

    /// <inheritdoc/>
    public Task<List<Menu>> GetMenus(int pageNumber, int pageSize) => Task.FromResult(this._menus);
}