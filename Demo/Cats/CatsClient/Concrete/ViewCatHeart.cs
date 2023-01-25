using CatsCommon;
using CatsCommon.Filters;
using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace CatsClient;

public class ViewCatHeart : ViewCatHeartPoco
{
    private readonly CollectionViewSource _littersViewSource = new();
    private readonly CollectionViewSource _childrenViewSource = new();

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
                    _littersViewSource.Source = base.Cat.Litters;
                    LittersView = _littersViewSource.View;
                    _childrenViewSource.Source = Children;
                    ChildrenView = _childrenViewSource.View;

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
                    findCats.Execute(new FindCatsCommand.Parameter { Filter = filter, Target = As<IViewCatHeart>()!.Children });
                }
            }
        }
    }

    public override bool FilterChildren 
    { 
        get => base.FilterChildren;
        set
        {
            if(base.FilterChildren != value)
            {
                base.FilterChildren = value;
                ApplyChildrenFilter();
            }
        }
    }

    private void ApplyChildrenFilter()
    {
        if (FilterChildren)
        {
            _childrenViewSource.Source = Children.Where(v => SelectedLitters.Contains(v.Litter!));
        }
        else
        {
            _childrenViewSource.Source = Children;
        }
        ChildrenView = _childrenViewSource.View;
    }

    public ViewCatHeart(IServiceProvider services) : base(services)
    {
        //_childrenViewSource.Filter += _childrenViewSource_Filter;
    }

    private void _childrenViewSource_Filter(object sender, FilterEventArgs e)
    {
        if(((IProjection<ICat>)e.Item).As<ICat>() is ICat cat)
        {
            e.Accepted = FilterChildren ? SelectedLitters.Contains(((IProjection<LitterPoco>)cat.Litter!).As<LitterPoco>()!) : true;
        }
        else
        {
            e.Accepted = false;
        }
    }

    public override void LittersSelectionChanged(object sender, EventArgs e)
    {
        base.SelectedLitters.Clear();
        foreach (LitterPoco item in ((DataGrid)sender).SelectedItems)
        {
            base.SelectedLitters.Add(item);
        }
        ApplyChildrenFilter();
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
}
