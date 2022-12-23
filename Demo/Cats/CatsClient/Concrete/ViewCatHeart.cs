using CatsCommon.Model;
using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace CatsClient;

public class ViewCatHeart : ViewCatHeartPoco
{
    private readonly CollectionViewSource _littersViewSource = new();

    public override CatPoco Cat
    {
        get => base.Cat;
        set
        {
            base.Cat = value;
            if (base.Cat is { })
            {
                _littersViewSource.Source = base.Cat.Litters;
                base.LittersView = _littersViewSource.View;
            }
        }
    }

    public ViewCatHeart(IServiceProvider services) : base(services)
    {
    }

    public override void LittersSelectionChanged(object sender, EventArgs e)
    {
        base.SelectedLitters.Clear();
        foreach (LitterPoco item in ((DataGrid)sender).SelectedItems)
        {
            base.SelectedLitters.Add(item);
        }
    }
}
