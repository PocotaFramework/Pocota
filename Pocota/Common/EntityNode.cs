namespace Net.Leksi.Pocota;

public class EntityNode
{
    public object? Entity { get; set; }
    public Dictionary<object, EntityNode>? Children;
    public string? Ref {  get; set; }
}
