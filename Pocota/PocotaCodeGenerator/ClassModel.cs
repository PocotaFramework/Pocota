using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Common;

public class ClassModel : PageModel
{
    public string ClassName { get; internal set; } = null!;
    public string NamespaceValue { get; internal set; } = null!;
    public HashSet<string> Usings { get; init; } = new();
    public bool IsAbstract { get; internal set; } = false;
    public bool IsEntity { get; internal set; } = false;
    public List<MethodModel> Methods { get; init; } = new();
    public List<PropertyModel> Properties { get; init; } = new();
    public List<ClassModel> Classes { get; init; } = new();
    internal List<string> Projections { get; init; } = new();

    public void OnGet([FromServices] IModelBuilder modelBuilder)
    {
        Console.WriteLine("here");
        if (HttpContext.Request.Path.Equals("/ControllerInterface"))
        {
            modelBuilder.BuildControllerInterface(this, HttpContext.Request.Query["selector"][0]);
        }
        else if (HttpContext.Request.Path.Equals("/ControllerProxy"))
        {
            modelBuilder.BuildControllerProxy(this, HttpContext.Request.Query["selector"][0]);
        }
        else if (HttpContext.Request.Path.Equals($"/{(modelBuilder as CodeGenerator)!.ClientLanguage}/Connector"))
        {
            modelBuilder.BuildConnector(this, HttpContext.Request.Query["selector"][0]);
        }
        else if (HttpContext.Request.Path.Equals($"/{(modelBuilder as CodeGenerator)!.ClientLanguage}/ClientImplementation"))
        {
            modelBuilder.BuildClientImplementation(this, HttpContext.Request.Query["selector"][0]);
        }
        else if (HttpContext.Request.Path.Equals($"/ServerImplementation"))
        {
            modelBuilder.BuildServerImplementation(this, HttpContext.Request.Query["selector"][0]);
        }
    }
}
