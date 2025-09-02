// <copyright file="ApiController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers;

/// <summary>
/// Base class for API controllers.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    /// <summary>
    /// Returns a problem response with the specified errors.
    /// </summary>
    /// <param name="errors">The list of errors to include in the response.</param>
    /// <returns>An IActionResult representing the problem response.</returns>
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count == 0)
        {
            return this.Problem();
        }

        this.HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return this.ValidationProblem(errors);
        }

        return this.Problem(errors[0]);
    }

    private ObjectResult Problem(Error error)
    {
        return this.Problem(
            statusCode: error.Type switch
                {
                    ErrorType.NotFound => StatusCodes.Status404NotFound,
                    ErrorType.Conflict => StatusCodes.Status409Conflict,
                    ErrorType.Validation => StatusCodes.Status400BadRequest,
                    ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError,
                },
            title: error.Description);
    }

    /// <summary>
    /// Returns a validation problem response with the specified errors.
    /// </summary>
    /// <param name="errors">The list of errors to include in the response.</param>
    /// <returns>An IActionResult representing the validation problem response.</returns>
    private ActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(error.Code, error.Description);
        }

        return this.ValidationProblem(modelStateDictionary);
    }
}