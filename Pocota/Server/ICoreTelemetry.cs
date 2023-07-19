namespace Net.Leksi.Pocota.Server;

public interface ICoreTelemetry
{
    void Receive(Dictionary<string, object> telemetry);
}
