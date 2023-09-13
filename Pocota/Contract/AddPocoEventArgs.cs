namespace Net.Leksi.Pocota.Common;

public class AddPocoEventArgs: EventArgs
{
    public Type Type { get; internal set; } = null!;
    public bool IsEntity { get; internal set; } = false;
}
