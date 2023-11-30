namespace Net.Leksi.Pocota;

public class PocoInfo<T> where T : class
{
    protected readonly Contract _contract;

    internal PocoInfo(Contract contract)
    {
        _contract = contract;
    }
}
