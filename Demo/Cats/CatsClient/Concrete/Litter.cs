using CatsCommon.Model;
using System;

namespace CatsClient;

public class Litter : LitterPoco
{
    public Litter(IServiceProvider services) : base(services) { }

    public override CatPoco? Male
    {
        get => base.Male;
        set
        {
            if (base.Male?.Litters is { })
            {
                base.Male?.Litters.Remove(this);
            }
            base.Male = value;
            if (base.Male?.Litters is { } && !(base.Male?.Litters.Contains(this) ?? false))
            {
                base.Male?.Litters.Add(this);
            }
        }
    }

    public override CatPoco Female
    {
        get => base.Female;
        set
        {
            if (base.Female?.Litters is { })
            {
                base.Female?.Litters.Remove(this);
            }
            base.Female = value!;
            if (base.Female?.Litters is { } && !(base.Female?.Litters.Contains(this) ?? false))
            {
                base.Female?.Litters.Add(this);
            }
        }
    }
}
