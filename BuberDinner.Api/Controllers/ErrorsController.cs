// <copyright file="ErrorsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

/// <summary>
/// Controller for handling errors.
/// </summary>
[Route("Error")]
public class ErrorsController : ControllerBase
{
    /// <summary>
    /// Returns an error response with a status code and title.
    /// </summary>
    /// <returns>An IActionResult representing the error response.</returns>
    public IActionResult Error()
    {
        Exception? exception = this.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, title) = exception switch
        {
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "You are not authorized to access this resource."),
            ArgumentNullException => (StatusCodes.Status400BadRequest, "A required argument was null."),
            ArgumentException => (StatusCodes.Status400BadRequest, "An argument was invalid."),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred"),
        };

        return this.Problem(title: title, statusCode: statusCode);
    }
}