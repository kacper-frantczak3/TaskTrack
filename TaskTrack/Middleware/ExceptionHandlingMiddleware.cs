using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace TaskTrack.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
        catch  (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);

            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var problemDetails = new ProblemDetails
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Title = "Error occurred while processing request",
            Detail = exception.Message,
            Instance = context.Request.Path
        };

        if (exception is KeyNotFoundException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            problemDetails.Status = (int)HttpStatusCode.NotFound;
            problemDetails.Title = "Resource Not Found";
        }
        
        var jsonResponse = JsonSerializer.Serialize(problemDetails);
        await context.Response.WriteAsync(jsonResponse);
    }
}