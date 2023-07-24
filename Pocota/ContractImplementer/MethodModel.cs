namespace Net.Leksi.Pocota.Common;

internal class MethodModel
{
    internal string Name { get; set; } = null!;
    internal string ReturnType { get; set; } = null!;
    internal string OutputType { get; set; } = null!;
    internal string OutputItemType { get; set; } = null!;
    internal string AccessExtenderType { get; set; } = null!;
    internal bool IsListOutput { get; set; } = false;
    internal List<ParameterModel> Parameters { get; init; } = new();
    internal List<AttributeModel> Attributes { get; init; } = new();
    internal List<FilterModel> Filters { get; init; } = new();
    internal string PocoContextVariable { get; set; } = "pocoContext";
    internal List<string> CallParameters { get; init; } = new();
    internal string? PropertyUseVariable { get; set; } = null;
    internal PropertyUseModel? PropertyUse { get; set; } = null;
    internal string DataProviderFactoryInterface { get; set; } = null!;
    internal string ProcessorFactoryInterface { get; set; } = null!;
    internal string ProcessorInterface { get; set; } = null!;
    internal string? DefaultDataProviderFactoryName { get; set; } = null;
    internal string? DefaultProcessorFactoryName { get; set; } = null;
}
