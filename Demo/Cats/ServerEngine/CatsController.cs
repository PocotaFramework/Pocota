using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Demo.Cats.Contract;
using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Server;

public class CatsController: ICatsController
{
    private readonly IServiceProvider _services;

    public CatsController(IServiceProvider services)
    {
        _services = services;
    }

    public void FindBreeds(IBreedFilter? filter)
    {
        throw new NotImplementedException();
    }

    public void FindCats(ICatFilter? filter)
    {
        DataProvider dp = _services.GetRequiredService<FindCatsDataProvider>();
        _services.GetRequiredService<IPocoContext>().Build(dp, null, true, true);
    }

    public void FindCatteries(ICatteryFilter? filter)
    {
        throw new NotImplementedException();
    }

    public void FindExteriors()
    {
        throw new NotImplementedException();
    }

    public void FindLittersWithCats(ICatFilter? filter)
    {
        throw new NotImplementedException();
    }

    public void FindTitles()
    {
        throw new NotImplementedException();
    }

    public void GetCat(ICat cat)
    {
        throw new NotImplementedException();
    }

    public IEntity Update(IEntity entity)
    {
        throw new NotImplementedException();
    }
}
