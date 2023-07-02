
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterWithCatsPoco                          //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-02T16:37:22                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System.Collections.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterWithCatsPoco : Pocota.Server.PocoBase, ILitterWithCats
{

    #region Property classes
    public class PropertyClass: IProperty
    {
        public string Name => string.Empty;
        public Type Type => typeof(LitterWithCatsPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            throw new InvalidOperationException();
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
        }
    }
    public class LitterPropertyClass: IProperty
    {
        public string Name => "Litter";
        public Type Type => typeof(LitterPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is LitterWithCatsPoco obj1 ? obj1._litterAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is LitterWithCatsPoco obj1)
            {
                obj1._litterAccessMode  = mode;
            }
        }
    }
    public class CatsPropertyClass: IProperty
    {
        public string Name => "Cats";
        public Type Type => typeof(IList<CatPoco>);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => true;
        public Type? ItemType => typeof(CatPoco);
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is LitterWithCatsPoco obj1 ? obj1._catsAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is LitterWithCatsPoco obj1)
            {
                obj1._catsAccessMode  = mode;
            }
        }
    }
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static LitterPropertyClass s_LitterProperty = new();
    public static CatsPropertyClass s_CatsProperty = new();
    #endregion Property fields

    #region fields
    private LitterPoco _litter = null!;
    private PropertyAccessMode _litterAccessMode = PropertyAccessMode.Forbidden;
    private IList<CatPoco> _cats = null!;
    private IList<ICat> _catsProxy = null!;
    private PropertyAccessMode _catsAccessMode = PropertyAccessMode.Forbidden;
    #endregion fields


    public LitterWithCatsPoco(IServiceProvider services) : base(services)
    {
    }

    #region properties
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
            _litterAccessMode = PropertyAccessMode.Full;
            _litter = value;
        }
    }
    ILitter ILitterWithCats.Litter
    {
        get
        {
            return Litter;
        }
       set
        {
            Litter = (value as LitterPoco)!;
        }
    }
    public IList<CatPoco> Cats
    {
        get
        {
            if(_catsAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _cats;
        }
        set
        {
            if(!IsUnderConstruction && _catsAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _catsAccessMode = PropertyAccessMode.Full;
            _cats = value;
            _catsProxy = new ListProxy<CatPoco, ICat>(_cats);
        }
    }
    IList<ICat> ILitterWithCats.Cats
    {
        get
        {
            return _catsProxy;
        }
       set
        {
            _catsProxy = value;
            _cats = new ListProxy<ICat, CatPoco>(_catsProxy);
        }
    }
    #endregion properties
}