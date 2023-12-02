namespace Net.Leksi.Pocota;

public class ContractEventArgs: EventArgs
{
    public Type PocoType { get; set; } = null!;
    public ContractEventKind EventKind { get; set; }
    public PocoKind PocoKind { get; set; } = PocoKind.Envelope;
    public string? Property { get; set; }
}
