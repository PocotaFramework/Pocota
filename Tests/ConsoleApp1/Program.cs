internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    internal KeyValuePair<string, string> Many2One<T1, T2>(Func<T1, T2> f) where T1 : class where T2 : class
    {

    }
}

public class C1
{
    public C2 P1 {  get; set; }
}

public class C2
{
    public List<C1> P1 { get; set; }
}

