using Microsoft.Extensions.Options;
using Net.Leksi.RuntimeAssemblyCompiler;

namespace Net.Leksi.Pocota.Pipeline;

public class ServerLink
{
    public HttpClient GetClient(string serverImplementationProject, object? parameter, Action<HttpContext>? onRequest)
    {
        Project serverImpl = Project.Compile(serverImplementationProject);

        Type serverImplType = serverImpl.CompiledAssembly!.GetType("ServerImpl")!;

        object server = Activator.CreateInstance(serverImplType)!;
        Uri link = new Uri((string)serverImplType.GetMethod("GetServerLink")!.Invoke(server, [parameter, onRequest])!);

        HttpClient result = new();

        
        result.BaseAddress = new Uri($"{link.Scheme}://{link.Host}:{link.Port}");

        result.Send(new HttpRequestMessage(HttpMethod.Get, $"{link.AbsolutePath}{link.Query}"));

        return result;
    }

}
