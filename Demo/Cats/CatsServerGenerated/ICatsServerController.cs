/////////////////////////////////////////////////////////////////////
// Controller Interface                                            //
// CatsServerMisc.ICatsServerController                            //
// Generated automatically from CatsServerMisc.ICatsServerContract //
// at 2022-12-19T17:40:43                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatsServerMisc;

public interface ICatsServerController 
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
