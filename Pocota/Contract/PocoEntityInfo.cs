namespace Net.Leksi.Pocota.Common;

public class PocoEntityInfo<T>: PocoInfo<T> where T : class
{
    internal PocoEntityInfo(Contract contract) : base(contract) { }

    public PocoEntityInfo<T> PrimaryKey(Func<T, object> name)
    {
        Contract.PrimaryKey(name);
        return this;
    }
    public PocoEntityInfo<T> Access(Func<T, object> name)
    {
        Contract.Access(name);
        return this;
    }

}
