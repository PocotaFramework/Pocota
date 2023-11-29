namespace Net.Leksi.Pocota.Server;

[Flags]
public enum PropertyUseKinds
{
    None = 0,
    Output = 1,
    AccessSelector = 2,
    Mandatory = 4,
    PrimaryKey = 8,
    Calculated = 16,
    Internal = 32,
}
