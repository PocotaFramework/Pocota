using CatsCommon.Model;

namespace CatsServerEngine;

public class Cat : CatBase
{
    public Cat(IServiceProvider services) : base(services)
    {
    }

    public override IList<ILitterForCat> test(IList<ICat> cats)
    {
        throw new NotImplementedException();
    }
}
