using System.Net;
using System.Text.Json;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BadHttpRequestException badRequestEx)
        {
            _logger.LogError(badRequestEx, "Bad request error occurred during JSON deserialization.");
            await HandleBadRequestAsync(context, badRequestEx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleBadRequestAsync(HttpContext context, BadHttpRequestException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var errorResponse = new
        {
            error = "Invalid JSON payload.",
            details = "The JSON request body is missing required properties or is malformed."
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorResponse = new
        {
            error = "An unexpected error occurred."
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}
