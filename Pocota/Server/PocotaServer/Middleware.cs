using Microsoft.Extensions.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota;

public class Middleware
{
    public static WebApplication UsePocotaExceptionsHandler(WebApplication app)
    {
        app.Use(Middleware.ExceptionsHandler);
        return app;
    }

    private static Task ExceptionsHandler(HttpContext context, Func<Task> next)
    {
        string exceptionBoundary = Guid.NewGuid().ToString();
        context.Response.Headers.Append(Constants.ExceptionBoundaryHeaderName, new StringValues(exceptionBoundary));
        try
        {
            return next.Invoke();
        }
        catch (Exception ex)
        {
            StreamWriter writer = new(context.Response.Body);
            Console.WriteLine(ex);
            writer.Write($"{{{exceptionBoundary}}}");
            JsonSerializerOptions options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
            options.Converters.Add(new ExceptionJsonConverter());
            writer.Write(JsonSerializer.Serialize<Exception>(ex, options));
            writer.Flush();
            return Task.CompletedTask;
        }
    }
}