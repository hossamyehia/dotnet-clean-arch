// <copyright file="MenuController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.Menus.Queries.GetMenus;
using BuberDinner.Contracts.Menus;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

/// <summary>
/// Controller for handling menu-related requests.
/// </summary>
/// <seealso cref="ApiController" />
[Route("hosts/{hostId}/menus")]
public class MenuController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator instance.</param>
    /// <param name="mapper">The mapper instance.</param>
    public MenuController(ISender mediator, IMapper mapper)
    {
        this._mediator = mediator;
        this._mapper = mapper;
    }

    /// <summary>
    /// Creates a new menu.
    /// </summary>
    /// <param name="request">The create menu request.</param>
    /// <param name="hostId">The host identifier.</param>
    /// <returns>An IActionResult representing the result of the menu creation.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateMenu([FromBody] CreateMenuRequest request, [FromRoute] string hostId)
    {
        var command = this._mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await this._mediator.Send(command);

        return createMenuResult.Match(
            result => this.Ok(this._mapper.Map<MenuResponse>(result)),
            errors => this.Problem(errors));
    }

    /// <summary>
    /// Returns a list of all menus.
    /// </summary>
    /// <param name="queries">The menu queries.</param>
    /// <returns>An IActionResult representing the list of menus.</returns>
    [HttpGet]
    public async Task<IActionResult> GetMenus([FromQuery] GetMenusQueries queries)
    {
        var query = this._mapper.Map<GetMenusQuery>(queries);
        var getMenusResult = await this._mediator.Send(query);

        return getMenusResult.Match(
            result => this.Ok(this._mapper.Map<List<MenuResponse>>(result)),
            errors => this.Problem(errors));
    }
}