namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class ExtenderNode: Node
{
    public override string InterfaceName => $"IExtender{Id}";
    public EntityNode Owner { get; internal init; } = null!;
}
