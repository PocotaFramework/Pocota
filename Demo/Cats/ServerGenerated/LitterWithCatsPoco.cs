
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.LitterWithCatsPoco                          //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-21T22:13:55                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System.Collections.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterWithCatsPoco : Server.PocoBase, Server.IPoco
{
    private LitterPoco _litter;
    private PropertyAccessMode _litterAccessMode = PropertyAccessMode.Forbidden;
    private readonly List<CatPoco> _cats;
    private PropertyAccessMode _catsAccessMode = PropertyAccessMode.Forbidden;
    public LitterPoco Litter
    {
        get
        {
            if(_litterAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _litter;
        }
        set
        {

        }
    }
    public List<CatPoco> Cats
    {
        get
        {
            if(_catsAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _cats;
        }
    }
}