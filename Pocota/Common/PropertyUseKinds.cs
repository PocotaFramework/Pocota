namespace Net.Leksi.Pocota;

[Flags]
public enum PropertyUseKinds
{
    None = 0,
    Mandatory = 1,
    AccessSelector = 2,
    PrimaryKey = 4,
}
