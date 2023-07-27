
///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatFilterPoco                                   //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-27T18:03:13.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatFilterPoco : Pocota.Server.PocoBase, ICatFilter
{

    #region Property classes
    public class PropertyClass: Property
    {
        public override string Name => string.Empty;
        public override Type Type => typeof(CatFilterPoco);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
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
    public class BreedPropertyClass: Property
    {
        public override string Name => "Breed";
        public override Type Type => typeof(BreedPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._breedAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            BreedPoco? value1 = value as BreedPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).Breed = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Breed;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._breedAccessMode  = mode;
            }
        }
    }
    public class CatteryPropertyClass: Property
    {
        public override string Name => "Cattery";
        public override Type Type => typeof(CatteryPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._catteryAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatteryPoco? value1 = value as CatteryPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).Cattery = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Cattery;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._catteryAccessMode  = mode;
            }
        }
    }
    public class BornAfterPropertyClass: Property
    {
        public override string Name => "BornAfter";
        public override Type Type => typeof(DateOnly);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._bornAfterAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            DateOnly? value1 = value as DateOnly?;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).BornAfter = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).BornAfter;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._bornAfterAccessMode  = mode;
            }
        }
    }
    public class BornBeforePropertyClass: Property
    {
        public override string Name => "BornBefore";
        public override Type Type => typeof(DateOnly);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._bornBeforeAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            DateOnly? value1 = value as DateOnly?;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).BornBefore = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).BornBefore;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._bornBeforeAccessMode  = mode;
            }
        }
    }
    public class NameRegexPropertyClass: Property
    {
        public override string Name => "NameRegex";
        public override Type Type => typeof(String);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._nameRegexAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).NameRegex = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).NameRegex;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._nameRegexAccessMode  = mode;
            }
        }
    }
    public class GenderPropertyClass: Property
    {
        public override string Name => "Gender";
        public override Type Type => typeof(Gender);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._genderAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            Gender? value1 = value as Gender?;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).Gender = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Gender;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._genderAccessMode  = mode;
            }
        }
    }
    public class ChildPropertyClass: Property
    {
        public override string Name => "Child";
        public override Type Type => typeof(CatPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._childAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).Child = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Child;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._childAccessMode  = mode;
            }
        }
    }
    public class SelfPropertyClass: Property
    {
        public override string Name => "Self";
        public override Type Type => typeof(CatPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._selfAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).Self = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Self;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._selfAccessMode  = mode;
            }
        }
    }
    public class MotherPropertyClass: Property
    {
        public override string Name => "Mother";
        public override Type Type => typeof(CatPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._motherAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).Mother = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Mother;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._motherAccessMode  = mode;
            }
        }
    }
    public class FatherPropertyClass: Property
    {
        public override string Name => "Father";
        public override Type Type => typeof(CatPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._fatherAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).Father = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Father;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._fatherAccessMode  = mode;
            }
        }
    }
    public class AncestorPropertyClass: Property
    {
        public override string Name => "Ancestor";
        public override Type Type => typeof(CatPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._ancestorAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).Ancestor = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Ancestor;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._ancestorAccessMode  = mode;
            }
        }
    }
    public class DescendantPropertyClass: Property
    {
        public override string Name => "Descendant";
        public override Type Type => typeof(CatPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._descendantAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).Descendant = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Descendant;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._descendantAccessMode  = mode;
            }
        }
    }
    public class LitterPropertyClass: Property
    {
        public override string Name => "Litter";
        public override Type Type => typeof(LitterPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._litterAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            LitterPoco? value1 = value as LitterPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).Litter = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).Litter;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._litterAccessMode  = mode;
            }
        }
    }
    public class ExteriorRegexPropertyClass: Property
    {
        public override string Name => "ExteriorRegex";
        public override Type Type => typeof(String);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._exteriorRegexAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).ExteriorRegex = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).ExteriorRegex;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._exteriorRegexAccessMode  = mode;
            }
        }
    }
    public class TitleRegexPropertyClass: Property
    {
        public override string Name => "TitleRegex";
        public override Type Type => typeof(String);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatFilterPoco target1 ? target1._titleRegexAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatFilterPoco)target).TitleRegex = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatFilterPoco)target).TitleRegex;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatFilterPoco target1)
            {
                target1._titleRegexAccessMode  = mode;
            }
        }
    }
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static BreedPropertyClass s_BreedProperty = new();
    public static CatteryPropertyClass s_CatteryProperty = new();
    public static BornAfterPropertyClass s_BornAfterProperty = new();
    public static BornBeforePropertyClass s_BornBeforeProperty = new();
    public static NameRegexPropertyClass s_NameRegexProperty = new();
    public static GenderPropertyClass s_GenderProperty = new();
    public static ChildPropertyClass s_ChildProperty = new();
    public static SelfPropertyClass s_SelfProperty = new();
    public static MotherPropertyClass s_MotherProperty = new();
    public static FatherPropertyClass s_FatherProperty = new();
    public static AncestorPropertyClass s_AncestorProperty = new();
    public static DescendantPropertyClass s_DescendantProperty = new();
    public static LitterPropertyClass s_LitterProperty = new();
    public static ExteriorRegexPropertyClass s_ExteriorRegexProperty = new();
    public static TitleRegexPropertyClass s_TitleRegexProperty = new();
    #endregion Property fields

    #region fields
    private BreedPoco? _breed = null;
    private PropertyAccessMode _breedAccessMode = PropertyAccessMode.NotSet;
    private CatteryPoco? _cattery = null;
    private PropertyAccessMode _catteryAccessMode = PropertyAccessMode.NotSet;
    private DateOnly? _bornAfter = null;
    private PropertyAccessMode _bornAfterAccessMode = PropertyAccessMode.NotSet;
    private DateOnly? _bornBefore = null;
    private PropertyAccessMode _bornBeforeAccessMode = PropertyAccessMode.NotSet;
    private String? _nameRegex = null;
    private PropertyAccessMode _nameRegexAccessMode = PropertyAccessMode.NotSet;
    private Gender? _gender = null;
    private PropertyAccessMode _genderAccessMode = PropertyAccessMode.NotSet;
    private CatPoco? _child = null;
    private PropertyAccessMode _childAccessMode = PropertyAccessMode.NotSet;
    private CatPoco? _self = null;
    private PropertyAccessMode _selfAccessMode = PropertyAccessMode.NotSet;
    private CatPoco? _mother = null;
    private PropertyAccessMode _motherAccessMode = PropertyAccessMode.NotSet;
    private CatPoco? _father = null;
    private PropertyAccessMode _fatherAccessMode = PropertyAccessMode.NotSet;
    private CatPoco? _ancestor = null;
    private PropertyAccessMode _ancestorAccessMode = PropertyAccessMode.NotSet;
    private CatPoco? _descendant = null;
    private PropertyAccessMode _descendantAccessMode = PropertyAccessMode.NotSet;
    private LitterPoco? _litter = null;
    private PropertyAccessMode _litterAccessMode = PropertyAccessMode.NotSet;
    private String? _exteriorRegex = null;
    private PropertyAccessMode _exteriorRegexAccessMode = PropertyAccessMode.NotSet;
    private String? _titleRegex = null;
    private PropertyAccessMode _titleRegexAccessMode = PropertyAccessMode.NotSet;


    #endregion fields

    #region properties


    public BreedPoco? Breed
    {
        get
        {
            if(_breedAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _breed;
        }
        set
        {
            if(_breedAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _breedAccessMode = PropertyAccessMode.Full;
            _breed = value;
        }
    }
    IBreed? ICatFilter.Breed
    {
        get
        {
            return Breed;
        }
       set
        {
            Breed = (value as BreedPoco)!;
        }
    }
    public CatteryPoco? Cattery
    {
        get
        {
            if(_catteryAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _cattery;
        }
        set
        {
            if(_catteryAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _catteryAccessMode = PropertyAccessMode.Full;
            _cattery = value;
        }
    }
    ICattery? ICatFilter.Cattery
    {
        get
        {
            return Cattery;
        }
       set
        {
            Cattery = (value as CatteryPoco)!;
        }
    }
    public DateOnly? BornAfter
    {
        get
        {
            if(_bornAfterAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _bornAfter;
        }
        set
        {
            if(_bornAfterAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _bornAfterAccessMode = PropertyAccessMode.Full;
            _bornAfter = value;
        }
    }
    DateOnly? ICatFilter.BornAfter
    {
        get
        {
            return BornAfter;
        }
       set
        {
            BornAfter = value;
        }
    }
    public DateOnly? BornBefore
    {
        get
        {
            if(_bornBeforeAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _bornBefore;
        }
        set
        {
            if(_bornBeforeAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _bornBeforeAccessMode = PropertyAccessMode.Full;
            _bornBefore = value;
        }
    }
    DateOnly? ICatFilter.BornBefore
    {
        get
        {
            return BornBefore;
        }
       set
        {
            BornBefore = value;
        }
    }
    public String? NameRegex
    {
        get
        {
            if(_nameRegexAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _nameRegex;
        }
        set
        {
            if(_nameRegexAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _nameRegexAccessMode = PropertyAccessMode.Full;
            _nameRegex = value;
        }
    }
    String? ICatFilter.NameRegex
    {
        get
        {
            return NameRegex;
        }
       set
        {
            NameRegex = value;
        }
    }
    public Gender? Gender
    {
        get
        {
            if(_genderAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _gender;
        }
        set
        {
            if(_genderAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _genderAccessMode = PropertyAccessMode.Full;
            _gender = value;
        }
    }
    Gender? ICatFilter.Gender
    {
        get
        {
            return Gender;
        }
       set
        {
            Gender = value;
        }
    }
    public CatPoco? Child
    {
        get
        {
            if(_childAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _child;
        }
        set
        {
            if(_childAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _childAccessMode = PropertyAccessMode.Full;
            _child = value;
        }
    }
    ICat? ICatFilter.Child
    {
        get
        {
            return Child;
        }
       set
        {
            Child = (value as CatPoco)!;
        }
    }
    public CatPoco? Self
    {
        get
        {
            if(_selfAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _self;
        }
        set
        {
            if(_selfAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _selfAccessMode = PropertyAccessMode.Full;
            _self = value;
        }
    }
    ICat? ICatFilter.Self
    {
        get
        {
            return Self;
        }
       set
        {
            Self = (value as CatPoco)!;
        }
    }
    public CatPoco? Mother
    {
        get
        {
            if(_motherAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _mother;
        }
        set
        {
            if(_motherAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _motherAccessMode = PropertyAccessMode.Full;
            _mother = value;
        }
    }
    ICat? ICatFilter.Mother
    {
        get
        {
            return Mother;
        }
       set
        {
            Mother = (value as CatPoco)!;
        }
    }
    public CatPoco? Father
    {
        get
        {
            if(_fatherAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _father;
        }
        set
        {
            if(_fatherAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _fatherAccessMode = PropertyAccessMode.Full;
            _father = value;
        }
    }
    ICat? ICatFilter.Father
    {
        get
        {
            return Father;
        }
       set
        {
            Father = (value as CatPoco)!;
        }
    }
    public CatPoco? Ancestor
    {
        get
        {
            if(_ancestorAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _ancestor;
        }
        set
        {
            if(_ancestorAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _ancestorAccessMode = PropertyAccessMode.Full;
            _ancestor = value;
        }
    }
    ICat? ICatFilter.Ancestor
    {
        get
        {
            return Ancestor;
        }
       set
        {
            Ancestor = (value as CatPoco)!;
        }
    }
    public CatPoco? Descendant
    {
        get
        {
            if(_descendantAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _descendant;
        }
        set
        {
            if(_descendantAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _descendantAccessMode = PropertyAccessMode.Full;
            _descendant = value;
        }
    }
    ICat? ICatFilter.Descendant
    {
        get
        {
            return Descendant;
        }
       set
        {
            Descendant = (value as CatPoco)!;
        }
    }
    public LitterPoco? Litter
    {
        get
        {
            if(_litterAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _litter;
        }
        set
        {
            if(_litterAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _litterAccessMode = PropertyAccessMode.Full;
            _litter = value;
        }
    }
    ILitter? ICatFilter.Litter
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
    public String? ExteriorRegex
    {
        get
        {
            if(_exteriorRegexAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _exteriorRegex;
        }
        set
        {
            if(_exteriorRegexAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _exteriorRegexAccessMode = PropertyAccessMode.Full;
            _exteriorRegex = value;
        }
    }
    String? ICatFilter.ExteriorRegex
    {
        get
        {
            return ExteriorRegex;
        }
       set
        {
            ExteriorRegex = value;
        }
    }
    public String? TitleRegex
    {
        get
        {
            if(_titleRegexAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _titleRegex;
        }
        set
        {
            if(_titleRegexAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _titleRegexAccessMode = PropertyAccessMode.Full;
            _titleRegex = value;
        }
    }
    String? ICatFilter.TitleRegex
    {
        get
        {
            return TitleRegex;
        }
       set
        {
            TitleRegex = value;
        }
    }
    #endregion properties

    public CatFilterPoco(IServiceProvider services) : base(services)
    {
    }

}