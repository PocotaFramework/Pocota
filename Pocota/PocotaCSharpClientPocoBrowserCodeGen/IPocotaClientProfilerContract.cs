using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Client;

[PocoContract("PocotaClientProfiler", IsClient = true)]

[Poco(typeof(ITracedPocosHeart))]

public interface IPocotaClientProfilerContract
{

}