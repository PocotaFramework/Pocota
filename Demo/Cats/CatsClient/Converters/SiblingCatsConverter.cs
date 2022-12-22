using CatsCommon.Model;
using Net.Leksi.Pocota.Common.Generic;
using System;
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
        if(
            targetType == typeof(string) 
            && value.GetType().IsGenericType 
            && typeof(ICollection<>).IsAssignableFrom(value.GetType().GetGenericTypeDefinition())
            && typeof(IProjection<CatPoco>).IsAssignableFrom(value.GetType().GetGenericArguments()[0])
        )
        {
            return string.Join(",", ((ICollection<IProjection<CatPoco>>)value).Select(v => v.Projector.NameNat));
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
