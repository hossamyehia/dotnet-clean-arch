// <copyright file="MenuResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Contracts.Menus;

/// <summary>
/// Menu Response record.
/// </summary>
public record MenuResponse(
    Guid Id,
    string Name,
    string Description,
    float AverageRating,
    List<MenuSectionResponse> Sections,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);

/// <summary>
/// Menu Section Response record.
/// </summary>
public record MenuSectionResponse(
    Guid Id,
    string Name,
    string Description,
    List<MenuItemResponse> Items);

/// <summary>
/// Menu Item Response record.
/// </summary>
public record MenuItemResponse(
    Guid Id,
    string Name,
    string Description);