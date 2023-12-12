namespace Net.Leksi.Pocota.FrameworkGenerator;

internal class ParameterHolder
{
    internal string Name { get; set; } = null!;
    internal Type Type { get; set; } = null!;
    internal bool IsNullable { get; set; }
}