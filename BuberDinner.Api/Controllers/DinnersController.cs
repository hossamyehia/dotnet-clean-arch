// <copyright file="DinnersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

/// <summary>
/// Controller for handling dinner-related requests.
/// </summary>
[Route("dinners")]
[ApiController]
public class DinnersController : ApiController
{
    /// <summary>
    /// Returns a list of all dinners.
    /// </summary>
    /// <returns>An IActionResult representing the list of dinners.</returns>
    [HttpGet]
    public IActionResult GetAllDinners()
    {
        return this.Ok(new[] { "Dinner1", "Dinner2", "Dinner3" });
    }
}