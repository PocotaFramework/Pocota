using System.Text;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class EntityNode: Node
{
    public List<PropertyDescriptor> PrimaryKey { get; internal set; } = new();
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
