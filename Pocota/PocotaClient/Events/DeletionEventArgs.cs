namespace Net.Leksi.Pocota.Client;

public class DeletionEventArgs: EventArgs
{
    internal bool IsPreRequest { get; init; }
    internal bool IsReferencedByEnvelope { get; set; } = false;

    public DeletionEventArgs(bool isPreRequest)
    {
        IsPreRequest = isPreRequest;
    }
}
