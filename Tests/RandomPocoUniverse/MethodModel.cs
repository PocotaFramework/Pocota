namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

internal class MethodModel
{
    internal string Name { get; set; } = null!;
    internal string ReturnType { get; set; } = null!;
    internal string ReturnItemType { get; set; } = null!;
    internal List<MethodParameterModel> Parameters { get; private init; } = new();
    internal List<string> Properties { get; private init; } = new();
}