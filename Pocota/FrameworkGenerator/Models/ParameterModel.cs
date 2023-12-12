namespace Net.Leksi.Pocota.FrameworkGenerator;

internal class ParameterModel
{
    internal string Name { get; set; } = null!;
    internal string TypeName { get; set; } = null!;
    internal Type Type { get; set; } = null!;
    internal string Variable {  get; set; } = null!;
    internal bool IsNullable { get; set; }
}