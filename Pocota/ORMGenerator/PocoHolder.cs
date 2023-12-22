using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Data;

namespace Net.Leksi.Pocota.ORMGenerator;

internal class PocoHolder
{
    internal Type Type { get; set; } = null!;
    internal object Poco { get; set; } = null!;
    internal PropertyUse? PropertyUse { get; set; } = null;
    internal List<PropertyHolder> Properties { get; private init; } = [];
    internal string? TableName { get; set; } = null;
    internal DataColumn[]? ForeignKey = null;
}
