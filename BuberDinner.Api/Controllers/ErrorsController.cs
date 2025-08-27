using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("Error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        
        var (statusCode, title) = exception switch
        {
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "You are not authorized to access this resource."),
            ArgumentNullException => (StatusCodes.Status400BadRequest, "A required argument was null."),
            ArgumentException => (StatusCodes.Status400BadRequest, "An argument was invalid."),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
        };
        
        return Problem(title: title, statusCode: statusCode);
    }
}