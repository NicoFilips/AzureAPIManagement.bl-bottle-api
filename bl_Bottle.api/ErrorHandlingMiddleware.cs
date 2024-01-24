using System.Net;
using System.Text.Json;

namespace FlaschenPostAPI;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // Hier könnten Sie die Exception-Details anpassen, die an den Client zurückgegeben werden
        var result = JsonSerializer.Serialize(new { error = "An internal Exception were thrown" });
        return context.Response.WriteAsync(result);
    }
}