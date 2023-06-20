
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.LitterWithCatsPoco                          //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-20T19:08:45                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System.Collections.Generic;
using System.Xml;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterWithCatsPoco : Server.PocoBase, ILitterWithCats, Server.IPoco
{
    private LitterPoco _litter;
    private PropertyAccessMode _accessModeLitter = PropertyAccessMode.Forbidden;
    private List<CatPoco> _cats;
    private PropertyAccessMode _accessModeCats = PropertyAccessMode.Forbidden;
    public ILitter Litter
    {
        get
        {
            if(_accessModeLitter is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _litter;
        }
        set
        {

        }
    }
    public List<ICat> Cats
    {
        get
        {
            if(_accessModeCats is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _cats;
        }
        set
        {

        }
    }
}