namespace Net.Leksi.Pocota.Server.Poco;

public abstract class EnvelopeBase: PocoBase, IEnvelope
{
    void IPoco.CheckAccess() { }
}
