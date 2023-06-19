using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public interface ILitterWithCats: IPocoExtender<ILitter>
{
    IList<ICat> Cats { get; }

}
