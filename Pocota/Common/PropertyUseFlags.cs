namespace Net.Leksi.Pocota;

[Flags]
public enum PropertyUseFlags
{
    None = 0,
    Composition = 1,
    Expected = 2,
    Mandatory = 4,
    AccessSelector = 8,
    PrimaryKey = 16,
}
