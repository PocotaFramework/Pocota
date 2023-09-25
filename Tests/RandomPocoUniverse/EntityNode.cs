using Microsoft.AspNetCore.Http;
using System.Text;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class EntityNode: Node
{
    public override string Name => $"Entity{Id}";
    public List<PropertyDescriptor> PrimaryKey { get; private init; } = new();
    public HashSet<PropertyDescriptor> CannotBePrimaryKey { get; private init; } = new();

    public List<string> AccessProperties { get; private init; } = new();
    public List<string> Calculated { get; private init; } = new();

    public override string ToString()
    {
        StringBuilder sb = new(base.ToString());
        if(PrimaryKey is { })
        {
            sb.Remove(sb.Length - 1, 1);
            sb.Append(", pk: [").Append(string.Join(',', PrimaryKey.Select(p => Properties.Contains(p) ? $"&{p.Name}" : p.ToString()))).Append("]}");
        }
        return sb.ToString();
    }
}
