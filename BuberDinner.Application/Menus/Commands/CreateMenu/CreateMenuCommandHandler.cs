// <copyright file="CreateMenuCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

/// <summary>
/// Create Menu Command Handler.
/// </summary>
public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateMenuCommandHandler"/> class.
    /// </summary>
    /// <param name="menuRepository">The menu repository.</param>
    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        this._menuRepository = menuRepository;
    }

    /// <inheritdoc/>
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        Menu menu = Menu.Create(
            request.Name,
            request.Description,
            request.HostId,
            request.Sections.ConvertAll(s => MenuSection.Create(
                s.Name,
                s.Description,
                s.Items.ConvertAll(i => MenuItem.Create(i.Name, i.Description)))));

        await this._menuRepository.AddMenu(menu);
        return menu;
    }
}