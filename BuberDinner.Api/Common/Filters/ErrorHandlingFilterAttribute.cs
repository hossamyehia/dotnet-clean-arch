using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute: ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6",
            Title = "An error occurred while processing your request.",
            Detail = exception.Message,
            Status = (int)StatusCodes.Status500InternalServerError,
            Instance = context.HttpContext.Request.Path
        };

        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
    }
}
