using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Demo.Cats.Common;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

[PocoContract("Cats", Version = "v1.0", RoutePrefix = "/api")]
[Poco(typeof(ICat), PrimaryKey = new object[] { "IdCat", typeof(int), "IdCattery", "Cattery.IdCattery" })]
[Poco(typeof(IBreed), PrimaryKey = new object[] { "IdBreed", "Code", "IdGroup", "Group" })]
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
        "Cattery.*",
        "LitterWithCats.Cats",
        "LitterWithCats.Strings",
        "LitterWithCats.Lists",
        "LitterWithCats.CatFilter",
    })]
    IList<ICat> FindCats(ICatFilter? filter);

    ICat GetCat(ICat cat);

    IList<IBreed> FindBreeds(IBreedFilter? filter);

    IList<ICattery> FindCatteries(ICatteryFilter? filter);

    IList<ILitterWithCats> FindLittersWithCats(ICatFilter? filter);

    IList<string> FindExteriors();

    IList<string> FindTitles();

}
