using System.Drawing;

namespace Net.Leksi.Pocota.FrameworkGenerator.Models;

internal class DataTypeModel
{
    internal string Name { get; set; } = null!;
    internal int Size { get; set; } = 0;
    internal List<string>? Check { get; set; }
}
