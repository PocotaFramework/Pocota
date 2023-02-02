using Net.Leksi.Pocota.Common;

namespace CatsClient;

[PocoContract("CatsFormHearts", IsClient = true)]

[Poco(typeof(IViewCatHeart))]
[Poco(typeof(IMainWindowHeart))]

public interface ICatsFormHeartsContract
{

}