using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Primitives;
using Net.Leksi.Pocota.Common;

namespace CatsServerEngine;

public class Util
{
    internal static async Task ExceptionsHandler(HttpContext context, Func<Task> next)
    {
        try
        {
            await next.Invoke();
        }
        catch (Exception ex)
        {
            StringBuilder reportBuilder = new();
            reportBuilder.AppendLine("------------------------------ Request Fail Report ------------------------------")
                .AppendLine(DateTime.Now.ToString())
                .AppendLine(context.Request.Path)
                .AppendLine(ex.ToString())
                .AppendLine("---------------------------------------------------------------------------------");
            Console.WriteLine(reportBuilder.ToString());
            try
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"{{}}{JsonSerializer.Serialize(new { Detail = reportBuilder.ToString() })}");
            }
            catch (InvalidOperationException)
            {
                await context.Response.WriteAsync($"{{}}{JsonSerializer.Serialize(new { Detail = reportBuilder.ToString() })}");
            }
        }
    }

}
