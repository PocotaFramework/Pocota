
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.LitterFilterPoco                            //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-21T22:13:55                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterFilterPoco : Server.PocoBase, Server.IPoco
{
    private CatPoco _female;
    private PropertyAccessMode _femaleAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco _male;
    private PropertyAccessMode _maleAccessMode = PropertyAccessMode.Forbidden;
    public CatPoco Female
    {
        get
        {
            if(_femaleAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _female;
        }
        set
        {

        }
    }
    public CatPoco Male
    {
        get
        {
            if(_maleAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _male;
        }
        set
        {

        }
    }
}