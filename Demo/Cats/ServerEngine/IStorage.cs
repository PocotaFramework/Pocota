using Net.Leksi.Pocota.Demo.Cats.Common;
using System.Data.Common;

namespace Net.Leksi.Pocota.Demo.Cats.Server;

public interface IStorage
{
    void CheckDatabase();
    DbDataReader? SelectCats(ICatFilter? filter);
}
