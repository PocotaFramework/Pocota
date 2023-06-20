namespace Net.Leksi.Pocota.Server;

public class PocoBase : Common.PocoBase, IPoco
{
    private bool _isUnderConstruction = false;

    internal void SetsUnderConstruction(bool isUnderConstruction)
    {
        _isUnderConstruction = isUnderConstruction;
    }

    protected override bool IsUnderConstruction => _isUnderConstruction;

}
