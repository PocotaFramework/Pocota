namespace Net.Leksi.Pocota.Client;

public class NotifyDeletionEventArgs: EventArgs
{
    internal bool IsPreRequest { get; init; }
    internal bool IsReferencedByEnvelope { get; set; } = false;

    public NotifyDeletionEventArgs(bool isPreRequest)
    {
        IsPreRequest = isPreRequest;
    }
}
