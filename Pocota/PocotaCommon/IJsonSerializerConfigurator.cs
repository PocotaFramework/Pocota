using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Common;

public interface IJsonSerializerConfiguration
{
    IJsonSerializerConfiguration At(Type targetType);
    IJsonSerializerConfiguration At<TTarget>();
    IJsonSerializerConfiguration AddJsonConverter(Type converterType);
    IJsonSerializerConfiguration AddJsonConverter<TConverter>();
}
