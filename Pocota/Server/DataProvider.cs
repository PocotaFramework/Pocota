namespace Net.Leksi.Pocota.Server;

public class DataProvider
{
    private int count = 5;

    public DataProviderRequest Request { get; set; } = DataProviderRequest.None;

    public bool Read()
    {
        if(count == 0)
        {
            return false;
        }
        --count;
        return true;
    }

    public object? this[string path]
    {
        get
        {
            Console.WriteLine(path);
            if (Request is DataProviderRequest.None)
            {
                throw new InvalidOperationException("Unspecified request");
            }
            return count;
            //return null;
        }
    }


}
