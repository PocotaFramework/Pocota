using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class EnumJsonConverter<T> : JsonConverter<T> where T : notnull
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return (T)Enum.Parse(typeToConvert, reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
