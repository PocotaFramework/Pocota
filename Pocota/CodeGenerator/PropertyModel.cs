namespace Net.Leksi.Pocota.Common;

internal class PropertyModel
{
    internal string Name { get; set; } = null!;
    internal bool IsNullable { get; set; } = false;
    internal string NullableSuffix => IsNullable ? "?" : string.Empty;
    internal string FieldReadOnly => IsList && IsReadOnly ? " readonly" : string.Empty;
    internal bool IsReadOnly { get; set; } = false;
    internal bool IsPoco { get; set; } = false;
    internal bool IsEntity { get; set; } = false;
    internal bool IsList { get; set; } = false;
    internal bool IsKeyPart { get; set; } = false;
    internal bool IsExtender { get; set; } = false;
    internal string Type { get; set; } = null!;
    internal string ObjectType { get; set; } = null!;
    internal string InstanceType { get; set; } = null!;
    internal string? ItemType { get; set; } = null;
    internal string? ItemObjectType { get; set; } = null;
    internal string FieldName { get; set; } = null!;
    internal string? ProxyFieldName { get; set; } = null;
    internal string AccessModeFieldName { get; set; } = null!;
    internal bool CanBeNull { get; set; } = false;
    internal string PropertyClass { get; set; } = null!;
    internal string PropertyField { get; set; } = null!;
    internal string AsTypeAsk = string.Empty;

}
