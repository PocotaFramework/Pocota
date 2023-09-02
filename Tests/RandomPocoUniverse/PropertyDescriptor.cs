using Net.Leksi.Pocota.Common;
using System.Text;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class PropertyDescriptor
{
    public string Name { get; set; } = null!;
    public Node? Node { get; set; } = null;
    public Type? Type { get; set; } = null;
    public bool IsCollection { get; set; } = false;
    public bool IsReadOnly { get; set; } = false;
    public bool IsNullable { get; set; } = true;
    public List<PropertyDescriptor>? References { get; set; } = null;
    public string? PrimaryKeyPartAlias { get; set; } = null;
    public bool IsAccess { get; set; } = false;

    public string TypeString => $"{(IsCollection ? "IList<" : string.Empty)}{(Type is { } ?  Util.MakeTypeName(Type) : Node!.InterfaceName)}{(IsCollection ? ">" : string.Empty)}{(IsNullable ? "?" : string.Empty)}";

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append("{pd");
        sb.Append(" ").Append(Name).Append(" ");
        if(Node is { })
        {
            sb.Append("&").Append(Node.Id);
            if(References is { })
            {
                sb.Append(", refs: [").Append(string.Join(',', References!.Select(p => p.ToString()))).Append("]");
            }
        }
        else
        {
            sb.Append(Type!.Name);
        }
        if (IsCollection)
        {
            sb.Append("[]");
        }
        sb.Append("}");
        return sb.ToString();
    }
}
