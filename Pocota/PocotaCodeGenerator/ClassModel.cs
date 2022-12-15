using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Common;

public class ClassModel : PageModel
{
    public string ClassName { get; set; } = null!;
    public string NamespaceValue { get; set; } = null!;
    public HashSet<string> Usings { get; init; } = new();
    public bool IsAbstract { get; set; } = false;
    public bool IsEntity { get; set; } = false;
    public List<MethodModel> Methods { get; init; } = new();
    public List<PropertyModel> Properties { get; init; } = new();
    public List<ClassModel> Classes { get; init; } = new();
    public List<string> Interfaces { get; init; } = new();
    public ClassModel? Parent { get; set; } = null;
    public string? Interface { get; set; } = null;
    public bool IsClient { get; set; } = false;
    public string ControllerInterface { get; set; } = null!;




    public void OnGet([FromServices] IModelBuilder modelBuilder)
    {
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
