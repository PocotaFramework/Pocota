using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using System;

namespace CatsClient;

public class Litter : LitterPoco
{
    private CatPoco? _savedFemale = null;
    protected override void DebugAccess(string selector)
    {
        if ("1".Equals(selector))
        {
            _savedFemale = Female;
        }
        else if ("2".Equals(selector))
        {
            ;
        }
        base.DebugAccess(selector);
    }


    public override CatPoco Female 
    { 
        get => base.Female;
        set
        {
            if(base.Female != value)
            {
                if(base.Female is { })
                {
                    base.Female.Litters?.Remove(this);
                }
                base.Female = value;
                if (base.Female is { })
                {
                    base.Female.Litters?.Add(this);
                }
                else if(base.Male is null)
                {
                    ((IEntity)this).Delete();
                }
            }
        }
    }

    public override CatPoco? Male 
    { 
        get => base.Male;
        set
        {
            if(base.Male != value)
            {
                if (base.Male is { })
                {
                    base.Male.Litters?.Remove(this);
                }
                base.Male = value;
                if (base.Male is { })
                {
                    base.Male.Litters?.Add(this);
                }
                else if (base.Female is null)
                {
                    ((IEntity)this).Delete();
                }
            }
        }
    }

    public Litter(IServiceProvider services) : base(services)
    {
    }

}
