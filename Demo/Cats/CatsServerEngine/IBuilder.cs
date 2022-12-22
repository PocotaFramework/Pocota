using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota.Server;
using System.Data.Common;

namespace CatsServerEngine;

public interface IBuilder
{
    void BuildBreeds(IBreedFilter? filter, BuildingOptions options);
    void BuildCat<T>(ICat self, BuildingOptions options);
    void BuildCats<T>(ICatFilter? filter, BuildingOptions options);
    void BuildCatteries(ICatteryFilter? filter, BuildingOptions options);
    void BuildExteriors(BuildingOptions options);
    void BuildLittersWithCats<T>(ICatFilter? filter, BuildingOptions options) where T : notnull;
    void BuildTitles(BuildingOptions options);
    IEnumerable<DbDataReader?> SpinCats(ICatFilter? filter);
}
