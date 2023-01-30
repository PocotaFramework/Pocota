using CatsCommon.Filters;
using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;

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
            ObservableCollection<CatPoco> source = new();
            Net.Leksi.Pocota.Client.ProjectionList<CatPoco, ICatForListing> cats = new(source);

            cats.CollectionChanged += Cats_CollectionChanged;
            source.CollectionChanged += Cats_CollectionChanged;

            Console.WriteLine("Add");
            cats.Add(host.Services.GetRequiredService<ICatForListing>());
            Console.WriteLine(cats.Count);
            Console.WriteLine("Add");
            cats.Add(host.Services.GetRequiredService<ICatForListing>());
            Console.WriteLine(cats.Count);
            Console.WriteLine("Insert");
            ICatForListing c1 = host.Services.GetRequiredService<ICatForListing>();
            cats.Insert(1, c1);
            Console.WriteLine(cats.Count);
            //Console.WriteLine("Move");
            //cats.Move(1, 2);
            //Console.WriteLine(cats.Count);
            Console.WriteLine("Remove");
            cats.Remove(c1);
            Console.WriteLine(cats.Count);
            Console.WriteLine("RemoveAt");
            cats.RemoveAt(1);
            Console.WriteLine(cats.Count);
            Console.WriteLine("SetItem");
            cats[0] = host.Services.GetRequiredService<ICatForListing>();
            Console.WriteLine(cats.Count);
            Console.WriteLine("Clear");
            cats.Clear();
            Console.WriteLine(cats.Count);

        }

        [Test]
        public void Test2()
        {
            Net.Leksi.Pocota.Client.ProjectionList<LitterPoco, ILitter> pl = new(new ObservableCollection<LitterPoco>());

            Console.WriteLine(pl is ICollection<IProjection<LitterPoco>>);
        }

        [Test]
        public void Test3()
        {
            IHost host = GetHost();
            CatFilterPoco cf = new(host.Services);
            Console.WriteLine(((Net.Leksi.Pocota.Client.IPoco)cf).PocoState);
        }

        private void Cats_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            StringBuilder sb1 = new();
            if (e.NewItems is { })
            {
                sb1.Append('[');
                IEnumerator en = e.NewItems?.GetEnumerator()!;
                while (en.MoveNext())
                {
                    sb1.Append(en.Current.ToString()).Append(',');
                }
                sb1[sb1.Length - 1] = ']';
            }
            else
            {
                sb1.Append("null");
            }
            StringBuilder sb2 = new();
            if (e.NewItems is { })
            {
                sb2.Append('[');
                IEnumerator en = e.NewItems?.GetEnumerator()!;
                while (en.MoveNext())
                {
                    sb2.Append(en.Current.ToString()).Append(',');
                }
                sb2[sb2.Length - 1] = ']';
            }
            else
            {
                sb2.Append("null");
            }
            Console.WriteLine($"{sender}: Action = {e.Action}: NewItems = {sb1}, OldItems = {sb2}, NewStartingIndex = {e.NewStartingIndex}, OldStartingIndex = {e.OldStartingIndex}");
        }

        private IHost GetHost()
        {
            return Host.CreateDefaultBuilder().ConfigureServices(services => 
            {
                PocotaExtensions.AddPocota(services, pocota =>
                {
                    pocota.AddTransient<CatFilterPoco>();
                },
                    null);

            }).Build();
        }
    }


}