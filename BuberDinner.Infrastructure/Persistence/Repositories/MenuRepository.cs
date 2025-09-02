// <copyright file="MenuRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

/// <summary>
/// In-memory menu repository for demonstration purposes.
/// </summary>
public class MenuRepository : IMenuRepository
{
    private readonly BuberDinnerDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuRepository"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    public MenuRepository(BuberDinnerDbContext context)
    {
        this._dbContext = context;
    }

    /// <inheritdoc/>
    public Task AddMenu(Menu menu)
    {
        this._dbContext.Add(menu);
        this._dbContext.SaveChanges();
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task<Menu> GetMenu(MenuId menuId)
    {
        var menu = this._dbContext.Menus.SingleOrDefault(m => m.Id == menuId);
        return Task.FromResult(menu!);
    }

    /// <inheritdoc/>
    public Task<List<Menu>> GetMenus(int pageNumber = 1, int pageSize = 100) => Task.FromResult(this._dbContext.Menus.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
}