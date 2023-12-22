namespace Net.Leksi.Pocota;

[Flags]
public enum PropertyUseFlags
{
    None = 0,
    Auto = 1, 
    Composition = 2,
    Expected = 4,
    Mandatory = 8,
    AccessSelector = 16,
    PrimaryKey = 32,
}
