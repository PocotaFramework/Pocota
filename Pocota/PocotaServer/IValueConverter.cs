namespace Net.Leksi.Pocota.Server;

public interface IValueConverter
{
    object Convert(object value, Type targetType);
    object ConvertBack(object value, Type sourceType);
}
