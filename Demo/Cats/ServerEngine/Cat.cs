﻿using Net.Leksi.Pocota.Demo.Cats.Common;

namespace Net.Leksi.Pocota.Demo.Cats.Server
{
    public class Cat : CatPoco
    {
        public Cat(IServiceProvider services) : base(services) { }
    }
}
