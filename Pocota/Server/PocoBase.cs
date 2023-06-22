namespace Net.Leksi.Pocota.Server;

public class PocoBase : Common.PocoBase, IPoco
{
    private bool _isUnderConstruction = true;

    internal void CommitConstruction()
    {
        _isUnderConstruction = false;
    }

    protected override bool IsUnderConstruction => _isUnderConstruction;
}
