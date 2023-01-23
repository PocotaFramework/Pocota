using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using System;
using System.Collections.Specialized;

namespace CatsClient;

public class Cat : CatPoco
{
    public Cat(IServiceProvider services) : base(services) { }

    protected override void LittersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        base.LittersCollectionChanged(sender, e);
        if (e.OldItems is { })
        {
            foreach (LitterPoco item in e.OldItems)
            {
                if(((IEntity)item).PocoState is not PocoState.Uncertain && ((IEntity)item).PocoState is not PocoState.Deleted)
                {
                    if (item.Female == this)
                    {
                        item.Female = null!;
                    }
                    else if (item.Male == this)
                    {
                        item.Male = null!;
                    }
                    if (item.Cats is { } && item.Cats.Count > 0)
                    {
                        if (Gender is Gender.Female || Gender is Gender.FemaleCastrate)
                        {
                            item.Female = this;
                        }
                        else
                        {
                            item.Male = this;
                        }
                        Litters.Add(item);
                        throw new InvalidOperationException();
                    }
                    if (item.Female is null && item.Male is null)
                    {
                        ((IEntity)item).Delete();
                    }
                }
            }
        }
    }

    protected override void LittersPocoChanged(object? sender, NotifyPocoChangedEventArgs e)
    {
        base.LittersPocoChanged(sender, e);
        for(int i = Litters.Count - 1; i >= 0; --i)
        {
            if (((IEntity)Litters[i]).PocoState is PocoState.Uncertain || ((IEntity)Litters[i]).PocoState is PocoState.Deleted)
            {
                Litters.RemoveAt(i);
            }
        }
    }
}
