using System.Diagnostics.Contracts;

namespace Net.Leksi.Pocota.Common;

public class PocoInfo<T> where T : class
{
    protected Contract Contract { get; private init; }

    internal PocoInfo(Contract contract)
    {
        Contract = contract;
    }
}
