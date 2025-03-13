using System.Net;
using System.Text.Json;
using HotelBooking.src.App.Dtos;

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

        var errorResponse = new ApiResponse<object> {
            Successful = false,
            Errors = ["Invalid JSON payload."]
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorResponse = new ApiResponse<object> {
            Successful = false,
            Errors = ["An error occurred while processing the request."]
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}
