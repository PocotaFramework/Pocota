
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterWithCatsPoco                          //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-23T18:37:26                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System.Collections.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterWithCatsPoco : Server.PocoBase
{
    private LitterPoco _litter = null!;
    private PropertyAccessMode _litterAccessMode = PropertyAccessMode.Forbidden;
    private readonly List<CatPoco> _cats;
    private PropertyAccessMode _catsAccessMode = PropertyAccessMode.Forbidden;

    public LitterWithCatsPoco()
    {
        _cats = new();
    }

    public LitterPoco Litter
    {
        get
        {
            if(_litterAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _litter;
        }
        set
        {
            if(!IsUnderConstruction && _litterAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _litterAccessMode = PropertyAccessMode.ReadOnly;
            _litter = value;
        }
    }
    public List<CatPoco> Cats
    {
        get
        {
            if(_catsAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _cats;
        }
    }
}