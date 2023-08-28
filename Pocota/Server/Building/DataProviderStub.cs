namespace Net.Leksi.Pocota.Server;

public class DataProviderStub : DataProvider
{
    protected override object? this[string path]
    {
        get
        {
            return DataProviderResponse.Miss;
        }
    }

    protected override bool Read()
    {
        return true;
    }

}
