using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Common;

public class ClassModel: PageModel
{
    internal Type Contract { get; set; } = null!;
    internal string ClassName { get; set; } = null!;
    internal string NamespaceValue { get; set; } = null!;
    internal HashSet<string> Usings { get; private init; } = new();
    internal List<string> Interfaces { get; private init; } = new();
    internal PrimaryKeyModel? PrimaryKey { get; set; } = null;
    internal string? Interface { get; set; } = null;
    internal PocoKind? PocoKind { get; set; } = null;
    internal List<PropertyModel> Properties { get; private init; } = new();
    internal List<PropertyModel> AccessProperties { get; private init; } = new();
    internal List<ServiceModel> Services { get; private init; } = new();
    internal List<MethodModel> Methods { get; private init; } = new();
    internal AttributeModel? UpdateRouteAttribute { get; set; } = null;

    public void OnGet([FromServices] Generator generator)
    {
        if (HttpContext.Request.Path.Equals("/Controller"))
        {
            generator.BuildController(this);
        }
        else if (HttpContext.Request.Path.Equals($"/{generator.ClientLanguage}/Connector"))
        {
            generator.BuildConnector(this);
        }
        else if (HttpContext.Request.Path.Equals($"/{generator.ClientLanguage}/ClientImplementation"))
        {
            generator.BuildClientImplementation(this);
        }
        else if (HttpContext.Request.Path.Equals($"/ServerImplementation"))
        {
            generator.BuildServerImplementation(this);
        }
        else if (HttpContext.Request.Path.Equals("/PrimaryKey"))
        {
            generator.BuildPrimaryKey(this);
        }
        else if (HttpContext.Request.Path.Equals("/ServerContractConfigurator"))
        {
            generator.BuildServerContractConfigurator(this);
        }
        else if (HttpContext.Request.Path.Equals("/AllowAccessManager"))
        {
            generator.BuildAllowAccessManager(this);
        }

    }
}
