using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Demo.Cats.Common;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

[PocoContract("Cats", Version = "v1.0", RoutePrefix = "/api")]
[Poco(typeof(ICat), PrimaryKey = new object[] { "IdCat", typeof(int), "IdCattery", "Cattery.IdCattery" }, Projections = new Type[] { typeof(ICatShort) })]
[Poco(typeof(IBreed), PrimaryKey = new object[] { "IdBreed", "Code", "IdGroup", "Group" }, Projections = new Type[] { typeof(IBreedShort) })]
[Poco(typeof(ICattery), PrimaryKey = new object[] { "IdCattery", typeof(int) })]
[Poco(typeof(ILitter), PrimaryKey = new object[] { "IdLitter", "Order", "IdFemale", "Female.IdCat", "IdFemaleCattery", "Female.IdCattery" })]
[Poco(typeof(ICatFilter))]
[Poco(typeof(IBreedFilter))]
[Poco(typeof(ICatteryFilter))]
[Poco(typeof(ILitterFilter))]
[Poco(typeof(ILitterWithCats))]
public interface ICatContract
{
    [Properties(new string[] {
        "NameNat",
        "Breed.NameNat",
        "Breed.NameEng",
        "Cattery.*"
    })]
    [Route("/cats")]
    IList<ICat> FindCats(ICatFilter? filter);

    [Route("/cats/1")]
    ICat GetCat(ICat cat);

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
