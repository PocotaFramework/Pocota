﻿using CatsCommon.Filters;
using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CatsClient;

public class MainWindowHeart : MainWindowHeartPoco
{
    public MainWindowHeart(IServiceProvider services) : base(services)
    {
        CatFilter = _services.GetRequiredService<CatFilterPoco>();
        AllBreeds = new List<IBreed>();
        AllCatteries = new List<ICattery>();
        AcceptCatFilterChanges();
        Breeds.CollectionChanged += (o, e) =>
        {
            if(AllBreeds is { })
            {
                if (AllBreeds.Count < Breeds.Count)
                {
                    AllBreeds.Clear();
                    AllBreeds.AddRange(Breeds.Select(v => v.As<IBreed>()!));
                    AllBreedsCount = AllBreeds.Count;
                }
            }
            BreedsCount = Breeds.Count;
        };
        Catteries.CollectionChanged += (o, e) =>
        {
            if(AllCatteries is { })
            {
                if (AllCatteries.Count < Catteries.Count)
                {
                    AllCatteries.Clear();
                    AllCatteries.AddRange(Catteries.Select(v => v.As<ICattery>()!));
                    AllCatteriesCount = AllCatteries.Count;
                }
            }
            CatteriesCount = Catteries.Count;
        };
    }

    public override void AcceptCatFilterChanges()
    {
        ((IPoco)CatFilter)?.AcceptChanges();
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
}
