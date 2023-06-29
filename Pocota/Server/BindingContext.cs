namespace Net.Leksi.Pocota.Server;

public abstract class BindingContext
{
    public BindingContext? Parent { get; set; } = null;
    public PropertyUse PropertyUse { get; set; } = null!;
    public Dictionary<string, BindingContext> PropertyUsesContexts { get; init; } = new();
    public abstract void Process(PocoBase poco);
    public int CurrentPropertyUse { get; set; }
}
