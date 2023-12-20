using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Net.Leksi.Pocota.FrameworkGenerator.Models;
using System.Data;

namespace Net.Leksi.Pocota.FrameworkGenerator.Models;

public class DatabaseModel : PageModel
{
    internal DataSet DataSet { get; set; } = null!;
    internal Dictionary<Type, DataTypeModel>? DataTypeMap;
    public void OnGet([FromServices] Generator generator)
    {
        generator.RenderDatabase(this);
    }
}
