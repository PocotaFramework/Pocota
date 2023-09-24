namespace Net.Leksi.Pocota.Common;

[Flags]
public enum UsePropertyKinds
{
    None = 0,
    Expected = 1,
    AccessSelector = 2,
    Mandatory = 4,
    PrimaryKey = 8,
}
