using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CatsClient;

internal class DateOnlyConverter : MarkupExtension, IValueConverter
{
    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is { })
        {
            if (targetType == typeof(string))
            {
                return ((DateOnly)value).ToString();
            }
            if (
                targetType == typeof(DateTime)
                || (targetType.IsGenericType && targetType == typeof(Nullable<>).MakeGenericType(new Type[] { typeof(DateTime) }))
            )
            {
                return ((DateOnly)value).ToDateTime(TimeOnly.MinValue);
            }
        }
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is { })
        {
            if (
                targetType == typeof(DateOnly)
                || (targetType.IsGenericType && targetType == typeof(Nullable<>).MakeGenericType(new Type[] { typeof(DateOnly) }))
            )
            {
                return DateOnly.Parse(((DateTime)value).ToString("yyyy-MM-dd"));
            }
        }
        return null;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}
