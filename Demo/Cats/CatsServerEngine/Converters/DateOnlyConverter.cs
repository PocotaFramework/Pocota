using Net.Leksi.Pocota;

namespace CatsServerEngineDebug.Converters;

public class DateOnlyConverter : IValueConverter
{
    public object Convert(object value, Type targetType)
    {
        throw new NotImplementedException();
    }

    public object ConvertBack(object value, Type sourceType)
    {
        if(sourceType == typeof(DateTime))
        {
            return DateOnly.FromDateTime((DateTime)value);
        }
        throw new NotImplementedException();
    }
}
