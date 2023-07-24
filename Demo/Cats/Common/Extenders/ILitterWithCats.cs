using Net.Leksi.Pocota.Common.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public interface ILitterWithCats: IExtender<ILitter>
{
    IList<ICat> Cats { get; set; }
}
