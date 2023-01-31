using CatsCommon;
using CatsCommon.Model;
using System;
using System.Collections.Specialized;

namespace CatsClient;

public class Cat : CatPoco
{
    public Cat(IServiceProvider services) : base(services)
    {
    }

    protected override void LittersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        base.LittersCollectionChanged(sender, e);
        if (e.OldItems is { })
        {
            foreach (LitterPoco litter in e.OldItems)
            {
                if(Gender is Gender.Female || Gender is Gender.FemaleCastrate)
                {
                    litter.Female = null!;
                }
                else
                {
                    litter.Male = null!;
                }
            }
        }
    }

    public override LitterPoco? Litter 
    { 
        get => base.Litter;
        set 
        { 
            if(base.Litter != value)
            {
                if(base.Litter is { })
                {
                    base.Litter.Cats?.Remove(this);
                }
                base.Litter = value;
                if (base.Litter is { })
                {
                    base.Litter.Cats?.Add(this);
                }
            }
        }
    }

}
