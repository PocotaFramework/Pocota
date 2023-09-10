using Net.Leksi.Pocota.Common;
using System.Text;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class PropertyDescriptor
{
    private static int s_genId = 0;

    public string Name { get; private init; } = $"P{++s_genId }";
    public Node? Node { get; set; } = null;
    public Type? Type { get; set; } = null;
    public bool IsCollection { get; set; } = false;
    public bool IsReadOnly { get; set; } = false;
    public bool IsNullable { get; set; } = true;
    public List<PropertyDescriptor>? References { get; set; } = null;
    public string? PrimaryKeyPartAlias { get; set; } = null;
    public bool IsAccess { get; set; } = false;
    public bool IsCalculated { get; set; } = false;
    public int Source { get; set; } = -1;

    public string TypeString => $"{(IsCollection ? "IList<" : string.Empty)}{(Type is { } ?  Util.MakeTypeName(Type) : Node!.Name)}{(IsCollection ? ">" : string.Empty)}{(IsNullable ? "?" : string.Empty)}";

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append($"{{pd<{Source}>");
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
