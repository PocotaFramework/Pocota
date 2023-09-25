namespace Net.Leksi.Pocota.Common;

public class AddPocoEventArgs: ParseContractEventArgs
{
    public bool IsEntity { get; internal set; } = false;

    internal AddPocoEventArgs()
    {
        EventKind = ParseContractEventKind.AddPoco;
    }
}
