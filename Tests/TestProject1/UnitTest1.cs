using CatsServerEngine;
using Microsoft.Extensions.Hosting;

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
            IHost host = Host.CreateDefaultBuilder().ConfigureServices(services => 
            { 
            }).Build();
            Cat cat = new(host.Services);
        }
    }
}