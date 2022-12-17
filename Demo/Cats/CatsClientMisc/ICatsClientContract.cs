using CatsClientMisc;
using CatsCommon.Model;
using Net.Leksi.Pocota.Common;

namespace CatsContract;

[Poco(typeof(ICat), Source = typeof(Cat))]
public interface ICatsClientContract: ICatsContract
{
}
