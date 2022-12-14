namespace Net.Leksi.Pocota.Common;

public class MethodModel
{
    internal string Name { get; set; } = null!;
    internal string ReturnType { get; set; } = null!;
    internal bool CastReturn { get; set; } = false;
    internal List<ParameterModel> Parameters { get; init; } = new();
    internal List<AttributeModel> Attributes { get; init; } = new();
    internal string ExpectedOutputType { get; set; } = null!;

}
