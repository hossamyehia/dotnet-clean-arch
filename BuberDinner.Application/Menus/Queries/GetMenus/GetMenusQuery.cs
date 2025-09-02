// <copyright file="GetMenusQuery.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.GetMenus;

/// <summary>
/// Query for getting menus.
/// </summary>
/// <param name="PageNumber">The page number.</param>
/// <param name="PageSize">Size of the page.</param>
public record class GetMenusQuery(
    int PageNumber,
    int PageSize) : IRequest<ErrorOr<List<Menu>>>;