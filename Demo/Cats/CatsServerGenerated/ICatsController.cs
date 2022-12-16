//////////////////////////////////////////////////////////////
// Controller Interface                                     //
// Cats.Contract.ICatsController                            //
// Generated automatically from Cats.Contract.ICatsContract //
// at 2022-12-16T18:40:09                                   //
//////////////////////////////////////////////////////////////


using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota.Server;
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
