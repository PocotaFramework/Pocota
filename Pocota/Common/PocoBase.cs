namespace Net.Leksi.Pocota.Common;

public abstract class PocoBase: IPoco
{
    protected abstract bool IsUnderConstruction {  get; }
}
