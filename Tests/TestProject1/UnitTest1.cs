using CatsCommon.Model;
using CatsServerEngine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IHost host = GetHost();
            ICatForListing catForListing = host.Services.GetRequiredService<ICatForListing>();
            ICat cat = ((IProjection<ICat>)catForListing).As<ICat>()!;
            CatPoco catPoco = ((IProjection<CatPoco>)cat).Projector!;

            Console.WriteLine(cat == catForListing);
            Console.WriteLine(cat.Equals(catForListing));
            Console.WriteLine(cat.Equals(catPoco));
            Console.WriteLine(catForListing.Equals(catPoco));
        }

        private IHost GetHost()
        {
            return Host.CreateDefaultBuilder().ConfigureServices(services => 
            {
                services.AddPocota
                (
                    pocota =>
                    {
                        pocota.AddTransient<Cat>();
                    },
                    null
                );

            }).Build();
        }
    }
}