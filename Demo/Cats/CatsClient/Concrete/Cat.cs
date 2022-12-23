using CatsCommon.Model;
using System;

namespace CatsClient;

public class Cat : CatPoco
{
    public Cat(IServiceProvider services) : base(services)
    {
    }
}
