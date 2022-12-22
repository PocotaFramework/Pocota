using System;
using System.Globalization;
using System.Windows.Data;

namespace CatsClient;

public class NotNullToTrueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Console.WriteLine(value);
        return value is { };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
