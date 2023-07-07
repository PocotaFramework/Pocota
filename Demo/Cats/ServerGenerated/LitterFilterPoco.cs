
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterFilterPoco                            //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-07T17:04:43                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterFilterPoco : Pocota.Server.PocoBase, ILitterFilter
{

    #region Property classes
    public class PropertyClass: IProperty
    {
        public string Name => string.Empty;
        public Type Type => typeof(LitterFilterPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => false;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            throw new InvalidOperationException();
        }
        public object? GetValue(object target)
        {
            throw new InvalidOperationException();
        }
        public PropertyAccessMode GetAccess(object target)
        {
            throw new InvalidOperationException();
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
        }
    }
    public class FemalePropertyClass: IProperty
    {
        public string Name => "Female";
        public Type Type => typeof(CatPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterFilterPoco)target).Female = value1!;
        }
        public object? GetValue(object target)
        {
            return ((LitterFilterPoco)target).Female;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is LitterFilterPoco target1 ? target1._femaleAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterFilterPoco target1)
            {
                target1._femaleAccessMode  = mode;
            }
        }
    }
    public class MalePropertyClass: IProperty
    {
        public string Name => "Male";
        public Type Type => typeof(CatPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterFilterPoco)target).Male = value1!;
        }
        public object? GetValue(object target)
        {
            return ((LitterFilterPoco)target).Male;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is LitterFilterPoco target1 ? target1._maleAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterFilterPoco target1)
            {
                target1._maleAccessMode  = mode;
            }
        }
    }
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static FemalePropertyClass s_FemaleProperty = new();
    public static MalePropertyClass s_MaleProperty = new();
    #endregion Property fields

    #region fields
    private CatPoco _female = null!;
    private PropertyAccessMode _femaleAccessMode = PropertyAccessMode.Denied;
    private CatPoco _male = null!;
    private PropertyAccessMode _maleAccessMode = PropertyAccessMode.Denied;
    #endregion fields


    public LitterFilterPoco(IServiceProvider services) : base(services)
    {
    }

    #region properties
    public CatPoco Female
    {
        get
        {
            if(_femaleAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _female;
        }
        set
        {
            if(!IsUnderConstruction && _femaleAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _femaleAccessMode = PropertyAccessMode.Full;
            _female = value;
        }
    }
    ICat ILitterFilter.Female
    {
        get
        {
            return Female;
        }
       set
        {
            Female = (value as CatPoco)!;
        }
    }
    public CatPoco Male
    {
        get
        {
            if(_maleAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _male;
        }
        set
        {
            if(!IsUnderConstruction && _maleAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _maleAccessMode = PropertyAccessMode.Full;
            _male = value;
        }
    }
    ICat ILitterFilter.Male
    {
        get
        {
            return Male;
        }
       set
        {
            Male = (value as CatPoco)!;
        }
    }
    #endregion properties
}