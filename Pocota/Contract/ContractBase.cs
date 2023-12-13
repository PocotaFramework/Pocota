namespace Net.Leksi.Pocota;

public abstract class ContractBase
{
    public abstract string RoutePrefix { get; }
    public abstract void ConfigurePocos();
    public abstract EntityInfo<T> Entity<T>() where T : class;
    public abstract PocoInfo<T> Envelope<T>() where T : class;
    public abstract void Output<T>(Func<T, object[]> config) where T : class;
    public abstract object Mandatory(object obj);
    public abstract void Property(object obj, string propertyName, object? propertyValue);
}
