namespace Net.Leksi.Pocota.Server;

public abstract class BindingContext
{
    public BindingContext? Parent { get; set; } = null;
    public Property Property { get; set; } = null!;
    public Dictionary<string, BindingContext> PropertiesContexts { get; init; } = new();
    public abstract void Process(PocoBase poco);
}
