namespace Net.Leksi.Pocota.Client;

public abstract class EnvelopeBase : PocoBase
{
    internal override bool IsEnvelope => true;

    public EnvelopeBase(IServiceProvider services) : base(services)
    {
    }
}
