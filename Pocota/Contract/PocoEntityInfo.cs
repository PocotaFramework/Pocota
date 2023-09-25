namespace Net.Leksi.Pocota.Common;

public class PocoEntityInfo<T>: PocoInfo<T> where T : class
{
    internal PocoEntityInfo(Contract contract) : base(contract) { }

    public PocoEntityInfo<T> PrimaryKey(Func<T, object> name)
    {
        Contract.PrimaryKey(name);
        return this;
    }
    public PocoEntityInfo<T> AccessSelector(Func<T, object> name)
    {
        Contract.AccessSelector(name);
        return this;
    }

    public PocoEntityInfo<T> Calculated(Func<T, object> name)
    {
        Contract.Calculated(name);
        return this;
    }

    public PocoEntityInfo<T> Link<T1>(Func<T, object> from, Func<T1, object> to) where T1 : class
    {
        Contract.Link<T, T1>(from, to);
        return this;
    }

}
