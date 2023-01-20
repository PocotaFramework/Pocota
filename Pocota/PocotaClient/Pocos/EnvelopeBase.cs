namespace Net.Leksi.Pocota.Client;

public abstract class EnvelopeBase : PocoBase, IEnvelope
{
    internal override bool IsEnvelope => true;

    public EnvelopeBase(IServiceProvider services) : base(services)
    {
    }
}
