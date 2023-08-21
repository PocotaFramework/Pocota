namespace Net.Leksi.Pocota.Server;

public abstract class EnvelopeBase: PocoBase, IEnvelope
{
    protected EnvelopeBase(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override void CheckAccess() { }
}
