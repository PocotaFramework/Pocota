using System.Collections.Immutable;

namespace Net.Leksi.Pocota.Server;

public class BuildingScriptMapping
{
    private Dictionary<string, string?> _fieldsMap = new();
    private Dictionary<string, Type> _converters = new();

    private ImmutableDictionary<string, string?>? _fieldsMapProp = null;
    private ImmutableDictionary<string, Type>? _convertersProp = null;

    internal ImmutableDictionary<string, string?> FieldsMap => _fieldsMapProp ??= _fieldsMap.ToImmutableDictionary();
    internal ImmutableDictionary<string, Type> Converters => _convertersProp ??= _converters.ToImmutableDictionary();

    public string Tag { get; init; }

    public BuildingScriptMapping(string tag = "")
    {
        Tag = tag;
    }

    public BuildingScriptMapping AddPathMapEntry(string path, string? fieldName, Type? converterType = null)
    {
        _fieldsMap.Add(path, fieldName);
        if (converterType is { })
        {
            if (!typeof(IValueConverter).IsAssignableFrom(converterType))
            {
                throw new ArgumentException($"{nameof(converterType)} must be assignable from {typeof(IValueConverter)} or null!");
            }
            _converters.Add(path, converterType);
        }
        return this;
    }

}
