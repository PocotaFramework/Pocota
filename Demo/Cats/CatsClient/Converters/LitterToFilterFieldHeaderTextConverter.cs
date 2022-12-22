using CatsCommon.Filters;
using CatsCommon.Model;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Markup;

namespace CatsClient;

public class LitterToFilterFieldHeaderTextConverter : MarkupExtension, IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        object? filter = values?[0];
        PropertyInfo? prop = values is { } && values.Length > 1 && values[1] is string propName ? typeof(ICatFilter).GetProperty(propName) : null;
        if (filter is { } && prop is { } && prop.GetValue(filter) is ILitter litter)
        {
            return $"{litter.Female.NameNat} ({litter.Date})";
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
