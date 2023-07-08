using Microsoft.Extensions.Primitives;
using Net.Leksi.Pocota.Common;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Server;

public class Middleware
{
    public static WebApplication UsePocotaExceptionsHandler(WebApplication app)
    {
        app.Use(Middleware.ExceptionsHandler);
        return app;
    }

    private static async Task ExceptionsHandler(HttpContext context, Func<Task> next)
    {
        context.Response.Headers.Add(Constants.ExceptionBoundaryHeaderName, new StringValues(Guid.NewGuid().ToString()));
        try
        {
            await next.Invoke();
        }
        catch (Exception ex)
        {
            if(ex is BuildingException buildingException)
            {
                Console.WriteLine(buildingException.GetExtendedMessage());
            }
            else
            {
                Console.WriteLine(ex);
            }
            await context.Response.WriteAsync($"{{{context.Response.Headers[Constants.ExceptionBoundaryHeaderName][0]}}}");
            JsonSerializerOptions options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
            options.Converters.Add(new ExceptionJsonConverter());
            await context.Response.WriteAsync(JsonSerializer.Serialize<Exception>(ex, options));
        }
    }
}
