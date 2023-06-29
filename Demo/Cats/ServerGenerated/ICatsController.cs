///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Contract.ICatsController                           //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-29T18:22:37                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

public interface ICatsController : IPocotaController
{
    [ExpectedOutputType(typeof(IList<ICat>))]
    void FindCats(ICatFilter? filter);

    [ExpectedOutputType(typeof(ICat))]
    void GetCat(ICat cat);

    [ExpectedOutputType(typeof(IList<IBreed>))]
    void FindBreeds(IBreedFilter? filter);

    [ExpectedOutputType(typeof(IList<ICattery>))]
    void FindCatteries(ICatteryFilter? filter);

    [ExpectedOutputType(typeof(IList<ILitterWithCats>))]
    void FindLittersWithCats(ICatFilter? filter);

    [ExpectedOutputType(typeof(IList<String>))]
    void FindExteriors();

    [ExpectedOutputType(typeof(IList<String>))]
    void FindTitles();

}
