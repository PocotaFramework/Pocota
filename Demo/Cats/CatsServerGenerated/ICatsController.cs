/////////////////////////////////////////////////////////////
// Controller Interface                                    //
// CatsContract.ICatsController                            //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-04-29T14:11:12                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatsContract;

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
