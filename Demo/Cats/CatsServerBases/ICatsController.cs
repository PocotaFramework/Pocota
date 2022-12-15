//------------------------------
// MVC Controller interface 
// Cats.Contract.ICatsController
// (Generated automatically 2022-12-15T18:56:29)
//------------------------------

using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cats.Contract;

public interface ICatsController 
{
    [ExpectedOutputType(typeof(IList<ICatForListing>))]
    void FindCats(ICatFilter? filter);

    [ExpectedOutputType(typeof(ICatForView))]
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
