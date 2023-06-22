namespace Net.Leksi.Pocota.Common;

public abstract class PocoBase: IPoco
{
    protected const string s_noAccess = "No access";

    protected abstract bool IsUnderConstruction { get; }
}
