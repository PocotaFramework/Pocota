namespace Net.Leksi.Pocota;

internal class EntityNode
{
    internal object? Entity { get; set; }
    internal Dictionary<object, EntityNode>? Children;
    internal string? Ref {  get; set; }
}
