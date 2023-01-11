using CatsCommon.Filters;
using CatsCommon.Model;
using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;

namespace CatsContract;

[PocoContract("Cats")]

[Poco(
    typeof(ICat), 
    Projections = new[] { typeof(ICatForListing), typeof(ICatAsParent), typeof(ICatForView), typeof(ICatWithSiblings), typeof(ICatAsSibling) },
    PrimaryKey = new object[] { "IdCat", typeof(int), "IdCattery", "Cattery.IdCattery" }
    )]
[Poco(
    typeof(IBreed),
    PrimaryKey = new object[] { "IdBreed", "Code", "IdGroup", "Group" }
    )]
[Poco(
    typeof(ICattery),
    PrimaryKey = new object[] { "IdCattery", typeof(int) }
    )]
[Poco(
    typeof(ILitter), 
    Projections = new[] { typeof(ILitterForCat), typeof(ILitterForDate), typeof(ILitterWithCats) },
    PrimaryKey = new object[] { "IdLitter", "Order", "IdFemale", "Female.IdCat", "IdFemaleCattery", "Female.IdCattery"}
    )]
[Poco(typeof(ICatFilter))]
[Poco(typeof(IBreedFilter))]
[Poco(typeof(ICatteryFilter))]
[Poco(typeof(ILitterFilter))]

public interface ICatsContract
{

    [Route("/cats")]
    IList<ICatForListing> FindCats(ICatFilter? filter);
    [Route("/cats/1")]
    ICatForView GetCat(ICat cat);

    [Route("/breeds")]
    IList<IBreed> FindBreeds(IBreedFilter? filter);

    [Route("/catteries")]
    IList<ICattery> FindCatteries(ICatteryFilter? filter);

    [Route("/litters/with/cats")]
    IList<ILitterWithCats> FindLittersWithCats(ICatFilter? filter);

    [Route("/exteriors")]
    IList<string> FindExteriors();

    [Route("/titles")]
    IList<string> FindTitles();
}
