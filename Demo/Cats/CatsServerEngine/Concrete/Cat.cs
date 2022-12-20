using CatsCommon.Model;

namespace CatsServerEngine;

public class Cat : CatPoco
{
    public Cat(IServiceProvider services) : base(services)
    {
    }
}
