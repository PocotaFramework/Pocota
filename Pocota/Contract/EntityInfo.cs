namespace Net.Leksi.Pocota;

public class EntityInfo<T>: PocoInfo<T> where T : class
{
    internal EntityInfo(Contract contract): base(contract) { }
    public EntityInfo<T> PrimaryKey(Func<T, object[]> config)
    {
        _contract.MarkProperties(config, ContractEventKind.PrimaryKey);
        return this;
    }
    public EntityInfo<T> AccessSelector(Func<T, object[]> config)
    {
        _contract.MarkProperties(config, ContractEventKind.AccessSelector);
        return this;
    }
    public EntityInfo<T> Composition(Func<T, object[]> config)
    {
        _contract.MarkProperties(config, ContractEventKind.Composition);
        return this;
    }
}
