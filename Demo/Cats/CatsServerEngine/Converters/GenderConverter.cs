using CatsCommon;
using Net.Leksi.Pocota;

namespace CatsServerDebug.Converters;

public class GenderConverter : IValueConverter
{
    public object Convert(object value, Type targetType)
    {
        throw new NotImplementedException();
    }

    public object ConvertBack(object value, Type sourceType)
    {
        if(sourceType == typeof(string))
        {
            return value?.ToString()?.Trim() switch { 
                "F" => Gender.Female, 
                "M" => Gender.Male, 
                "FC" => Gender.FemaleCastrate, 
                _ => Gender.MaleCastrate 
            };
        }
        throw new NotImplementedException();
    }
}
