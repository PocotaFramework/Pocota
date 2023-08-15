namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class PropertyDescriptor
{
    public string Name { get; set; }
    public Node? Node { get; set; }
    public Type Type { get; set; }
    public bool IsCollection { get; set; }
    public bool IsReadOnly { get; set; }
}
