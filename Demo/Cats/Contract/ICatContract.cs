﻿using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Demo.Cats.Common;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

[PocoContract("Cats", Version = "v1.0", RoutePrefix = "/api")]
[Poco(typeof(ICat), PrimaryKey = new object[] { "IdCat", typeof(int), "IdCattery", "Cattery.IdCattery" },
    AccessExtender = typeof(ICat), AccessProperties = new string[] { "Cattery" })]
[Poco(typeof(IBreed), PrimaryKey = new object[] { "IdBreed", "Code", "IdGroup", "Group" })]
[Poco(typeof(ICattery), PrimaryKey = new object[] { "IdCattery", typeof(int) },
    AccessExtender = typeof(ICattery), AccessProperties = new string[] { "IdCattery" })]
[Poco(typeof(ILitter), PrimaryKey = new object[] { "IdLitter", "Order", "IdFemale", "Female.IdCat", "IdFemaleCattery", "Female.IdCattery" },
    AccessExtender = typeof(ILitterWithCats), AccessProperties = new string[] { "Female.Cattery", "Male.Cattery", "Cats.@.Cattery" } )]
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
    })]
    IList<ICat> FindCats(ICatFilter? filter);

    ICat GetCat(ICat cat);

    IList<IBreed> FindBreeds(IBreedFilter? filter);

    IList<ICattery> FindCatteries(ICatteryFilter? filter);

    IList<ILitterWithCats> FindLittersWithCats(ICatFilter? filter);

    IList<ILitter> FindLitters(ILitterFilter? filter);

    IList<string> FindExteriors();

    IList<string> FindTitles();

}
