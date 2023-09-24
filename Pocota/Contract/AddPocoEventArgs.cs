namespace Net.Leksi.Pocota.Common;

public class AddPocoEventArgs: ContractEventArgs
{
    public bool IsEntity { get; internal set; } = false;

    internal AddPocoEventArgs()
    {
        EventKind = ContractEventKind.AddPoco;
    }
}
