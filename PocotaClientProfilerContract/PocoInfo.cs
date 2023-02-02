using System;

namespace Net.Leksi.Pocota.Client;

public class PocoInfo
{
    public Type Type { get; init; }
    public string Label { get; init; }
    public PocoState State { get; init; }
    public WeakReference<IPoco> Item { get; init; }

    public PocoInfo(Type type, string label, PocoState state, WeakReference<IPoco> item)
    {
        Type = type;
        Label = label;
        State = state;
        Item = item;
    }
}
