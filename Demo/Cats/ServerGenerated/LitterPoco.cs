
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.LitterPoco                                  //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-20T22:04:33                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterPoco : Server.PocoBase, ILitter, IEntity
{
    private Int32 _order;
    private PropertyAccessMode _orderAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco _female;
    private PropertyAccessMode _femaleAccessMode = PropertyAccessMode.Forbidden;
    private DateOnly _date;
    private PropertyAccessMode _dateAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _male;
    private PropertyAccessMode _maleAccessMode = PropertyAccessMode.Forbidden;
    public Int32 Order
    {
        get
        {
            if(_orderAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _order;
        }
        set
        {

        }
    }
    public ICat Female
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
    public DateOnly Date
    {
        get
        {
            if(_dateAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _date;
        }
        set
        {

        }
    }
    public ICat? Male
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