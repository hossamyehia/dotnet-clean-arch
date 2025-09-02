// <copyright file="MenuMappingConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.Menus.Queries.GetMenus;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.MenuAggregate;

using Mapster;

using MenuItem = BuberDinner.Domain.MenuAggregate.Entities.MenuItem;
using MenuSection = BuberDinner.Domain.MenuAggregate.Entities.MenuSection;

namespace BuberDinner.Api.Common.Mapping;

/// <summary>
/// Mapping configuration for menu-related types.
/// </summary>
public class MenuMappingConfig : IRegister
{
    /// <inheritdoc/>
    public void Register(TypeAdapterConfig config)
    {
        // Mapping For GetMenus
        config.NewConfig<GetMenusQueries, GetMenusQuery>();

        // Mapping For CreateMenu
        config.NewConfig<(CreateMenuRequest Reqest, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Reqest);

        // Common Mapping
        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value.ToString() : null)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(d => d.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(m => m.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}