using CatsCommon;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace CatsClient;

public class StringToGenderConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is Gender gender ? new ComboBoxItem { Name = gender.ToString() } : null;
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is ComboBoxItem cbi)
        {
            return Enum.Parse<Gender>(cbi.Name);
        }
        return null;
    }
}
