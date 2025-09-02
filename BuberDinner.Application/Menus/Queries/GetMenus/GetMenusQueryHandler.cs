// <copyright file="GetMenusQueryHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.GetMenus;

/// <summary>
/// Query handler for getting menus.
/// </summary>
public class GetMenusQueryHandler : IRequestHandler<GetMenusQuery, ErrorOr<List<Menu>>>
{
    private readonly IMenuRepository _menuRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetMenusQueryHandler"/> class.
    /// </summary>
    /// <param name="menuRepository">The menu repository.</param>
    public GetMenusQueryHandler(IMenuRepository menuRepository)
    {
        this._menuRepository = menuRepository;
    }

    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<ErrorOr<List<Menu>>> Handle(GetMenusQuery request, CancellationToken cancellationToken)
    {
        var menus = await this._menuRepository.GetMenus(request.PageNumber, request.PageSize);
        return menus;
    }
}