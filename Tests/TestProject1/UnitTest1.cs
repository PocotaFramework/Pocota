using CatsCommon.Model;
using CatsServerEngine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Client;
using System.Collections.ObjectModel;
using System.Text;
using System.Collections;

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
            ProjectionList<CatPoco, ICatForListing> cats = new(source);

            cats.CollectionChanged += Cats_CollectionChanged;
            source.CollectionChanged += Cats_CollectionChanged;

            Console.WriteLine("Add");
            source.Add(host.Services.GetRequiredService<CatPoco>());
            Console.WriteLine("Add");
            source.Add(host.Services.GetRequiredService<CatPoco>());
            Console.WriteLine("Insert");
            CatPoco c1 = host.Services.GetRequiredService<CatPoco>();
            source.Insert(1, c1);
            Console.WriteLine("Move");
            source.Move(1, 2);
            Console.WriteLine("Remove");
            source.Remove(c1);
            Console.WriteLine("RemoveAt");
            source.RemoveAt(1);
            Console.WriteLine("SetItem");
            source[0] = host.Services.GetRequiredService<CatPoco>();
            Console.WriteLine("Clear");
            source.Clear();

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