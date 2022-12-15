using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Net.Leksi.Pocota.Client;

namespace Net.Leksi.Pocota.Common;

public class MethodModel
{
    internal string Name { get; set; } = null!;
    internal string ReturnType { get; set; } = null!;
    internal List<ParameterModel> Parameters { get; init; } = new();
    internal List<AttributeModel> Attributes { get; init; } = new();
    internal List<FilterModel> Filters { get; init; } = new();
    internal string ControllerVariable { get; set; } = "contra";
    internal string JsonSerializerOptionsVariable { get; set; } = "jsonSerializerOptions";
    internal List<string> CallParameters { get; init; } = new();
    internal string ExpectedOutputType { get; set; } = null!;
    internal string HttpMethod { get; set; } = "Get";
    internal string SerializerOptionsKind { get; set; } = JsonSerializerOptionsKind.Ordinary.ToString();
    internal string QueryString { get; set; } = String.Empty;
    internal string QueryVariable { get; set; } = "query";
    internal bool HasBody { get; set; } = false;
    internal string StringContentVariable { get; set; } = "stringContent";
    internal string ResponseVariable { get; set; } = "response";
    internal string DeserilizedType { get; set; } = null!;
    internal bool IsEnumerable { get; set; } = false;
    internal string PocoContextVariable { get; set; } = "pocoContext";
    internal string DateTimeVariable { get; set; } = "dt";
}
