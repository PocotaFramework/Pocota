namespace Net.Leksi.Pocota;

[Flags]
public enum PropertyUseFlags
{
    None = 0,
    Expected = 1,
    Mandatory = 2,
    AccessSelector = 4,
    PrimaryKey = 8,
}
