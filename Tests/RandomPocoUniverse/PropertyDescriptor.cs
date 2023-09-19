using Net.Leksi.Pocota.Common;
using System.Text;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class PropertyDescriptor
{
    private static int s_genId = 0;

    public string Name { get; internal set; } = $"P{++s_genId }";
    public Node? Node { get; internal set; } = null;
    public Type? Type { get; internal set; } = null;
    public bool IsCollection { get; internal set; } = false;
    public bool IsReadOnly { get; internal set; } = false;
    public bool IsNullable { get; internal set; } = true;
    public bool IsAccess { get; internal set; } = false;
    public bool IsCalculated { get; internal set; } = false;
    public int Source { get; internal set; } = -1;
    public PropertyDescriptor? Link {  get; internal set; } = null;

    public string TypeString => $"{(IsCollection ? "IList<" : string.Empty)}{(Type is { } ?  Util.MakeTypeName(Type) : Node!.Name)}{(IsCollection ? ">" : string.Empty)}{(IsNullable ? "?" : string.Empty)}";

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append($"{{pd<{Source}>");
        sb.Append(" ").Append(Name).Append(" ");
        if(Node is { })
        {
            sb.Append("&").Append(Node.Id);
        }
        else if(Type is { })
        {
            sb.Append(Type.Name);
        }
        else
        {
            sb.Append("undefined");
        }
        if (IsCollection)
        {
            sb.Append("[]");
        }
        sb.Append("}");
        return sb.ToString();
    }
}
