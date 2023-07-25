
///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryFilterPoco                               //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-25T17:11:02.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatteryFilterPoco : Pocota.Server.PocoBase, ICatteryFilter
{

    #region Property classes
    public class PropertyClass: Property
    {
        public override string Name => string.Empty;
        public override Type Type => typeof(CatteryFilterPoco);
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
    public class SearchRegexPropertyClass: Property
    {
        public override string Name => "SearchRegex";
        public override Type Type => typeof(String);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatteryFilterPoco target1 ? target1._searchRegexAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatteryFilterPoco)target).SearchRegex = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatteryFilterPoco)target).SearchRegex;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatteryFilterPoco target1)
            {
                target1._searchRegexAccessMode  = mode;
            }
        }
    }
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static SearchRegexPropertyClass s_SearchRegexProperty = new();
    #endregion Property fields

    #region fields
    private String? _searchRegex = null;
    private PropertyAccessMode _searchRegexAccessMode = PropertyAccessMode.NotSet;


    #endregion fields

    #region properties


    public String? SearchRegex
    {
        get
        {
            if(_searchRegexAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _searchRegex;
        }
        set
        {
            if(_searchRegexAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _searchRegexAccessMode = PropertyAccessMode.Full;
            _searchRegex = value;
        }
    }
    String? ICatteryFilter.SearchRegex
    {
        get
        {
            return SearchRegex;
        }
       set
        {
            SearchRegex = value;
        }
    }
    #endregion properties

    public CatteryFilterPoco(IServiceProvider services) : base(services)
    {
    }

}