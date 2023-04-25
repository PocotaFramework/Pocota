using CatsCommon.Filters;
using Net.Leksi.Pocota.Server;
using System.Data.Common;

namespace CatsServerEngine;

public interface IStorage
{
    void CheckDatabase();
    DbDataReader GetBreeds(IBreedFilter? filter);
    DbDataReader GetCatteries(ICatteryFilter? filter);
    DbDataReader GetCats(ICatFilter? filter);
    DbDataReader GetLitter(IPrimaryKey? primaryKey);
    DbDataReader GetExteriors();
    DbDataReader GetTitles();
    DbDataReader GetCat(IPrimaryKey? primaryKey);
    DbDataReader GetLitters(ILitterFilter filter);
}
