using CatsCommon.Filters;
using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace CatsClient;

public class MainWindowHeart : MainWindowHeartPoco
{
    private readonly List<CollectionViewSource> _collectionViewSources = new();

    public MainWindowHeart(IServiceProvider services) : base(services)
    {
        CatFilter = _services.GetRequiredService<CatFilterPoco>();
        AllBreeds = new List<IBreed>();
        AllCatteries = new List<ICattery>();
        AcceptCatFilterChanges();
        Breeds.CollectionChanged += (o, e) =>
        {
            if (AllBreeds.Count < Breeds.Count)
            {
                AllBreeds.Clear();
                AllBreeds.AddRange(Breeds.Select(v => v.As<IBreed>()!));
                AllBreedsCount = AllBreeds.Count;
            }
            BreedsCount = Breeds.Count;
        };
        Catteries.CollectionChanged += (o, e) =>
        {
            if (AllCatteries.Count < Catteries.Count)
            {
                AllCatteries.Clear();
                AllCatteries.AddRange(Catteries.Select(v => v.As<ICattery>()!));
                AllCatteriesCount = AllCatteries.Count;
            }
            CatteriesCount = Catteries.Count;
        };
    }

    public override void AcceptCatFilterChanges()
    {
        ((IPoco)CatFilter).AcceptChanges();
    }

    public override void CatsSelectionChanged(object sender, EventArgs e)
    {
        SelectedCats.Clear();
        foreach (IProjection<CatPoco> cat in ((DataGrid)sender).SelectedItems)
        {
            SelectedCats.Add(cat.As<CatPoco>()!);
        }
        IsCatSelected = SelectedCats.Count == 1;
        if (IsCatSelected)
        {
            SelectedCat = SelectedCats[0];
        }
        else
        {
            SelectedCat = null;
        }
    }

    protected override void OnProjectionCreated(Type @interface, IProjection projection)
    {
        ((IMainWindowHeart)projection).CatsViewSource = new CollectionViewSource();
        ((CollectionViewSource)((IMainWindowHeart)projection).CatsViewSource).Source = ((IMainWindowHeart)projection).Cats;
        base.OnProjectionCreated(@interface, projection);
    }

}
