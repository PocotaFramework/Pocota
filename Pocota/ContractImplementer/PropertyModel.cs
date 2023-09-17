namespace Net.Leksi.Pocota.Common;

internal class PropertyModel
{
    internal string Name { get; set; } = null!;
    internal string FieldName { get; set; } = null!;
    internal string Type { get; set; } = null!;
    internal string Nullable { get; set; } = null!;
    internal bool IsReadonly { get; set; } = false;
    internal bool IsClass { get; set; } = false;
    internal bool IsCollection { get; set; } = false;
    internal string ItemType { get; set; } = null!;
    internal string ItemImplType { get; set; } = null!;
    internal PocoKind PocoKind { get; set; } = PocoKind.NotAPoco;
    internal bool IsAccess { get; set; } = false;
    internal string PropertyClass { get; set; } = null!;
    internal string PropertyField { get; set; } = null!;
}