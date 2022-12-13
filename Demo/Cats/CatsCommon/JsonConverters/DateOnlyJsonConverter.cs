﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace CatsCommon.JsonConverters;

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(((DateOnly)value).ToString("yyyy-MM-dd"));
    }
}
