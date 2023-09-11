using Net.Leksi.Pocota.Common;
using System.Text;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class EntityNode: Node
{
    private List<PropertyDescriptor> _primaryKey = new();
    public override string Name => $"Entity{Id}";
    public List<PropertyDescriptor> PrimaryKey => Base is EntityNode @base ? @base.PrimaryKey : _primaryKey; 

    public string[] KeyDefinition => PrimaryKey.SelectMany(pk =>
    {
        Match match = Regex.Match(pk.Name, "^((?:P|Id)\\d+)+$");
        string[] parts = match.Groups[1].Captures.Select(c => c.Value).ToArray();
        if (parts.Length == 1)
        {
            if (parts[0].StartsWith("Id"))
            {
                return new string[] { $"\"{pk.PrimaryKeyPartAlias}\"", $"typeof({Util.MakeTypeName(pk.Type!)})" };
            }
            return new string[] { $"\"{pk.PrimaryKeyPartAlias}\"", $"\"{parts[0]}<{pk.Source}>\"" };
        }
        if (parts[1].StartsWith("Id"))
        {
            return new string[] { $"\"{pk.PrimaryKeyPartAlias}\"", $"\"{parts[0]}.{parts[1]}\"" };
        }
        EntityNode node = (Properties.Where(p => parts[0].Equals(p.Name)).First().Node as EntityNode)!;

        string search = string.Join(string.Empty, parts.Skip(1));
        PropertyDescriptor pd = node.PrimaryKey.Where(p => search.Equals(p.Name)).First()!;
        return new string[] { $"\"{pk.PrimaryKeyPartAlias}\"", $"\"{parts[0]}.{pd.PrimaryKeyPartAlias}\"" };
    }).ToArray();

    public string[] AccessProperties => Properties.Where(p => p.IsAccess).Select(p => $"{p.Name}{(p.IsCollection ? ".@" : string.Empty)}").ToArray();

    public EntityNode() 
    {
        NodeType = NodeType.Entity;
    }
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
