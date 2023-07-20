using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public class PropertyUse
{
    private readonly IList<PropertyUse>? _properties = null;
    public Property? Property { get; init; } = null;
    public string Path { get; init; } = string.Empty;
    public IList<PropertyUse>? Properties
    {
        get => _properties;
        init
        {
            if(value is { })
            {
                _properties = value;
                foreach (PropertyUse pu in _properties)
                {
                    pu.Parent = this;
                }
            }
        }
    }
    public PropertyUse? Parent { get; private set; } = null;
}
