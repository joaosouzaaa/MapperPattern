using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Domain.Middlewares;

public sealed class UnexpectedErrorMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new Error()
            {
                Key = "Unexpected error",
                Message = "An unexpected error happened."
            };

            var jsonContent = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(jsonContent);
        }
    }
}
