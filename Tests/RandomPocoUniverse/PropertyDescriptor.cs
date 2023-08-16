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
    public bool IsPrimaryKeyPart { get; set; } = false;
    public List<PropertyDescriptor>? References { get; set; } = null;
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append("{pd");
        if (IsPrimaryKeyPart)
        {
            sb.Append("!");
        }
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
