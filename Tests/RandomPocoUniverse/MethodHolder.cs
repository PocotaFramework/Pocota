namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class MethodHolder
{
    public string Name { get; set; } = null!;
    public List<string> Properties { get; private init; } = new();
    public List<ParameterHolder> Parameters { get; private init; } = new();
}
