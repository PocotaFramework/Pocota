using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Net.Leksi.Pocota.ORMGenerator;

public class DatabaseModel : PageModel
{
    internal DataSet DataSet { get; set; } = null!;
    internal Dictionary<Type, DataTypeModel>? DataTypeMap;
    public void OnGet([FromServices] Generator generator)
    {
        generator.RenderDatabase(this);
    }
}
