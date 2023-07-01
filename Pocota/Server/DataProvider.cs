namespace Net.Leksi.Pocota.Server;

public class DataProvider
{
    private int count = 5;

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
            return null;
        }
    }


}
