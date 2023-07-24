
///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterFilterPoco                                //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-24T18:11:46.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterFilterPoco : Pocota.Server.PocoBase, ILitterFilter
{

    #region Property classes
    public class PropertyClass: Property
    {
        public override string Name => string.Empty;
        public override Type Type => typeof(LitterFilterPoco);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            throw new InvalidOperationException();
        }
        protected override void SetValue(object target, object? value)
        {
            throw new InvalidOperationException();
        }
        public override object? GetValue(object target)
        {
            throw new InvalidOperationException();
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
        }
    }
    public class FemalePropertyClass: Property
    {
        public override string Name => "Female";
        public override Type Type => typeof(CatPoco);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is LitterFilterPoco target1 ? target1._femaleAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterFilterPoco)target).Female = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((LitterFilterPoco)target).Female;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterFilterPoco target1)
            {
                target1._femaleAccessMode  = mode;
            }
        }
    }
    public class MalePropertyClass: Property
    {
        public override string Name => "Male";
        public override Type Type => typeof(CatPoco);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is LitterFilterPoco target1 ? target1._maleAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterFilterPoco)target).Male = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((LitterFilterPoco)target).Male;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
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
    private PropertyAccessMode _femaleAccessMode = PropertyAccessMode.NotSet;
    private CatPoco _male = null!;
    private PropertyAccessMode _maleAccessMode = PropertyAccessMode.NotSet;


    #endregion fields

    #region properties


    public CatPoco Female
    {
        get
        {
            if(_femaleAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _female;
        }
        set
        {
            if(_femaleAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
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
            if(_maleAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _male;
        }
        set
        {
            if(_maleAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
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

    public LitterFilterPoco(IServiceProvider services) : base(services)
    {
    }

}