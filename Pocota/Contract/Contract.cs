﻿
namespace Net.Leksi.Pocota;

public abstract class Contract: ContractBase
{
    public sealed override EntityInfo<T> Entity<T>()
    {
        EntityInfo<T> info = new(this);
        return info;
    }

    public sealed override PocoInfo<T> Envelope<T>()
    {
        PocoInfo<T> info = new(this);
        return info;
    }

    public sealed override void Output<T>(Func<T, object[]> config)
    {

    }

    public sealed override object Mandatory(object obj)
    {
        return obj;
    }

    internal void AccessSelector<T>(Func<T, object[]> config) where T : class
    {
        throw new NotImplementedException();
    }

    internal void PrimaryKey<T>(Func<T, object[]> config) where T : class
    {
        throw new NotImplementedException();
    }

}
