using Net.Leksi.Pocota.Common;

namespace CatsClient;

[PocoContract(IsClient = true)]

[Poco(typeof(IViewCatHeart))]
[Poco(typeof(IMainWindowHeart))]
[Poco(typeof(ITracedPocosHeart))]

public interface ICatsFormHeartsContract
{

}