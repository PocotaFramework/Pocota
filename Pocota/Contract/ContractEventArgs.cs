namespace Net.Leksi.Pocota.Common;

public class ContractEventArgs: EventArgs
{
    public ContractEventKind EventKind { get; init; }
    public bool IsStarting { get; init; } = false;

}
