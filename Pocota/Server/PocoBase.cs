namespace Net.Leksi.Pocota.Server;

public class PocoBase : Common.PocoBase, IPoco
{
    private bool _isUnderConstruction = true;

    public PocoBase(IServiceProvider services) : base(services) { }

    internal void CommitConstruction()
    {
        _isUnderConstruction = false;
    }

    protected override bool IsUnderConstruction => _isUnderConstruction;
}
