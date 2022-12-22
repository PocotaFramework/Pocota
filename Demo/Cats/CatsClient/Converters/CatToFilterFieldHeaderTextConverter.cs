using CatsCommon.Filters;
using CatsCommon.Model;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Markup;

namespace CatsClient;

public class CatToFilterFieldHeaderTextConverter : MarkupExtension, IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        object? filter = values?[0];
        PropertyInfo? prop = values is { } && values.Length > 1 && values[1] is string propName ? typeof(ICatFilter).GetProperty(propName) : null;
        if(filter is { } && prop is { } && prop.GetValue(filter) is ICat cat && cat.NameNat is { })
        {
            return cat.NameNat;
        }
        return string.Empty;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}
