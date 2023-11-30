namespace Net.Leksi.Pocota;

public class EntityInfo<T>: PocoInfo<T> where T : class
{
    internal EntityInfo(Contract contract): base(contract) { }
    public EntityInfo<T> PrimaryKey(Func<T, object[]> config)
    {
        _contract.PrimaryKey(config);
        return this;
    }
    public EntityInfo<T> AccessSelector(Func<T, object[]> config)
    {
        _contract.AccessSelector(config);
        return this;
    }
}
