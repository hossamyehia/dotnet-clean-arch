using System.Text.Json;

namespace BuberDinner.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred while processing the request.");
            await HandleExceptionAsync(context, ex);
        }
        finally
        {
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                _logger.LogWarning("Resource not found: {Path}", context.Request.Path);
                await HandleExceptionAsync(context, new NotFoundException("Resource not found"));
            }
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            ArgumentNullException => StatusCodes.Status400BadRequest,
            ArgumentException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;

        var result = JsonSerializer.Serialize(new { error = exception.Message });
        return context.Response.WriteAsync(result);
    }

    private class NotFoundException : Exception
    {
        public NotFoundException() { }

        public NotFoundException(string message)
            : base(message) { }

        public NotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
