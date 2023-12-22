using System.Data;

namespace Net.Leksi.Pocota.ORMGenerator;

internal class PropertyHolder
{
    internal IEntityProperty EntityProperty { get; set; } = null!;
    internal bool IsPrimaryKey { get; set; } = false;
    internal bool IsComposition { get; set; } = false;
    internal bool IsAuto { get; set; } = false;
    internal DataColumn[]? ForeignKey = null;
}
