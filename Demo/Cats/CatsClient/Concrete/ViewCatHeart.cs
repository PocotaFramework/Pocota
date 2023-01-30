using CatsCommon;
using CatsCommon.Filters;
using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace CatsClient;

public class ViewCatHeart : ViewCatHeartPoco
{
    public override CatPoco Cat
    {
        get => base.Cat;
        set
        {
            if(base.Cat != value)
            {
                base.Cat = value;
                if (base.Cat is { })
                {
                    FindCatsCommand findCats = _services.GetRequiredService<FindCatsCommand>();
                    ICatFilter filter = _services.GetRequiredService<ICatFilter>();
                    if(base.Cat.Gender is Gender.Female || base.Cat.Gender is Gender.FemaleCastrate)
                    {
                        filter.Mother = base.Cat.As<ICat>();
                    }
                    else
                    {
                        filter.Father = base.Cat.As<ICat>();
                    }
                    findCats.Executed += FindCats_Executed;
                    findCats.Execute(new FindCatsCommand.Parameter { Filter = filter, Target = As<IViewCatHeart>()!.Children });
                }
            }
        }
    }

    private void FindCats_Executed(object sender, Net.Leksi.Pocota.Client.Crud.CrudCommandExecutedEventArgs args)
    {
        ;
    }

    public override bool FilterChildren 
    { 
        get => base.FilterChildren;
        set
        {
            if(base.FilterChildren != value)
            {
                base.FilterChildren = value;
            }
        }
    }

    public ViewCatHeart(IServiceProvider services) : base(services) 
    {
    }

    public override void LittersSelectionChanged(object sender, EventArgs e)
    {
        base.SelectedLitters.Clear();
        foreach (ILitter item in ((DataGrid)sender).SelectedItems)
        {
            base.SelectedLitters.Add(((IProjection)item).As<LitterPoco>()!);
        }
    }

    public override void ChildrenSelectionChanged(object sender, EventArgs e)
    {
        if (((DataGrid)sender).SelectedItems.Count == 1)
        {
            SelectedChild = ((IProjection<CatPoco>)((DataGrid)sender).SelectedItems[0]!).As<CatPoco>();
            IsChildSelected = true;
        }
        else
        {
            SelectedChild = null;
            IsChildSelected = false;
        }
    }

    public override void ChildrenFilter(object sender, EventArgs e)
    {
        if(e is FilterEventArgs args)
        {
            if (((IProjection<ICat>)args.Item).As<ICat>() is ICat cat)
            {
                args.Accepted = FilterChildren ? SelectedLitters.Contains(((IProjection<LitterPoco>)cat.Litter!).As<LitterPoco>()!) : true;
            }
            else
            {
                args.Accepted = false;
            }
        }
    }

    public override void SameLitterCatsSelectionChanged(object sender, EventArgs e)
    {
        if (((DataGrid)sender).SelectedItems.Count == 1)
        {
            SelectedSameLitterCat = ((IProjection<CatPoco>)((DataGrid)sender).SelectedItems[0]!).As<CatPoco>();
            IsSameLitterCatSelected = true;
        }
        else
        {
            SelectedSameLitterCat = null;
            IsSameLitterCatSelected = false;
        }
    }
}
