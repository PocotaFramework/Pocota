using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Common;

public interface IJsonSerializerConfigurator
{
    IJsonSerializerConfigurator At(Type targetType);
    IJsonSerializerConfigurator At<TTarget>();
    IJsonSerializerConfigurator AddJsonConverter(Type converterType);
    IJsonSerializerConfigurator AddJsonConverter<TConverter>();
}
