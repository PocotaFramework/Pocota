using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Demo.Cats.Common;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

[PocoContract("Cats", Version = "v1.0", RoutePrefix = "/api")]
[Poco(typeof(ICat), PrimaryKey = new object[] { "IdCat", typeof(int), "IdCattery", "Cattery.IdCattery" },
    AccessProperties = new string[] { "Cattery" })]
[Poco(typeof(IBreed), PrimaryKey = new object[] { "IdBreed", "Code", "IdGroup", "Group" })]
[Poco(typeof(ICattery), PrimaryKey = new object[] { "IdCattery", typeof(int) },
    AccessProperties = new string[] { "IdCattery" })]
[Poco(typeof(ILitter), PrimaryKey = new object[] { "IdLitter", "Order", "IdFemale", "Female.IdCat", "IdFemaleCattery", "Female.IdCattery" },
    AccessProperties = new string[] { "Female", "Male", "Cats.@" } )]
[Poco(typeof(ICatFilter))]
[Poco(typeof(IBreedFilter))]
[Poco(typeof(ICatteryFilter))]
[Poco(typeof(ILitterFilter))]
[Poco(typeof(IPedigree))]
public interface ICatContract
{
    [Properties(new string[] {
        "NameNat",
        "Breed.NameNat",
        "Breed.NameEng",
        "Cattery.*",
    })]
    IList<ICat> FindCats(ICatFilter? filter);

    ICat GetCat(ICat cat);

    IList<IBreed> FindBreeds(IBreedFilter? filter);

    IList<ICattery> FindCatteries(ICatteryFilter? filter);

    IList<ILitter> FindLitters(ILitterFilter? filter);

    IList<string> FindExteriors();

    IList<string> FindTitles();

}
