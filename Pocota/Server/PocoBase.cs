namespace Net.Leksi.Pocota.Server;

public class PocoBase : Common.PocoBase, IPoco
{
    protected const string s_notSet = "Not set";
    protected const string s_alreadySet = "Already set";

    public PocoBase(IServiceProvider services) : base(services) { }

}
