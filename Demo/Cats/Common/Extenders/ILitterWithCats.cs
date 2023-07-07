using Net.Leksi.Pocota.Common.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public interface ILitterWithCats: IExtender<ILitter>
{
    IList<ICat> Cats { get; set; }
    IList<string> Strings { get; set; }
    IList<IList<string>> Lists { get; set; }
    ICatFilter CatFilter { get; set; }
}
