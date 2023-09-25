namespace Net.Leksi.Pocota.Common;

public class ParseContractEventArgs: EventArgs
{
    public ParseContractEventKind EventKind { get; init; }
    public bool IsStarting { get; init; } = false;

    public Type PocoType { get; init; } = null!;

}
