using CatsCommon.Model;
using CatsContract;
using Net.Leksi.Pocota.Common;

namespace CatsServerMisc;

[Poco(typeof(ICat), Source = typeof(Cat))]
public interface ICatsServerContract: ICatsContract
{
}
