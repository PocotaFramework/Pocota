using Net.Leksi.Pocota.Common;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CatsClient;

public class ProjectionConverter : MarkupExtension, IValueConverter, IMultiValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Console.WriteLine($"Convert({value}, {targetType})");
        if(value is IProjection)
        {
            return ((IProjection)value).As(targetType);
        }
        return null;
    }

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Console.WriteLine($"ConvertBack({value}, {targetType})");
        if (value is IProjection)
        {
            return ((IProjection)value).As(targetType);
        }
        return null;
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
