using Net.Leksi.Pocota.Common;
using System.Text;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class EntityNode: Node
{
    private List<PropertyDescriptor> _primaryKey = new();
    public override string Name => $"Entity{Id}";
    public List<PropertyDescriptor> PrimaryKey => Base is EntityNode @base ? @base.PrimaryKey : _primaryKey; 

    public string[] AccessProperties => Properties.Where(p => p.IsAccess).Select(p => $"{p.Name}{(p.IsCollection ? ".@" : string.Empty)}").ToArray();

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
