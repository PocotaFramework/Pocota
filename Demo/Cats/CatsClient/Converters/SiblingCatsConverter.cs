﻿using CatsCommon.Model;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace CatsClient;

internal class SiblingCatsConverter : MarkupExtension, IValueConverter
{
    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is null)
        {
            return null;
        }
        if (
            targetType == typeof(string) 
            && value.GetType().IsGenericType 
            && typeof(IList).IsAssignableFrom(value.GetType())
            && typeof(IProjection<ICat>).IsAssignableFrom(value.GetType().GetGenericArguments()[0])
        )
        {
            //Console.WriteLine(((IList<ICatForListing>)value).Count);
            return string.Join(",", ((IList<ICatAsSibling>)value).Select(v => v.NameNat));
        }
        throw new NotImplementedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider services)
    {
        return this;
    }
}
