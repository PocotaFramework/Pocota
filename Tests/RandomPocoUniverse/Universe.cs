using System.Data;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class Universe
{
    public List<Node> Nodes { get; private set; } = new();
    public DataSet DataSet { get; private set; } = new();
    public string Sql { get; internal set; } = string.Empty;
}
