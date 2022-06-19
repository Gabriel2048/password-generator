using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace PasswordGenerator.Api.Middlewares;

/// <summary>
/// A middleware that catches validation exceptions and creates a 400 Bad Request response with the error message.
/// </summary>
public class ValidationErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException error)
        {
            var response = context.Response;
            response.ContentType = "application/json";


            response.StatusCode = (int)HttpStatusCode.BadRequest;


            var result = JsonSerializer.Serialize(new { message = error.Message });
            await response.WriteAsync(result);
        }
    }
}
