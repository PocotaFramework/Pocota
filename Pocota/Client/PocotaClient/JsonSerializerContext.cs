using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Client;

internal class JsonSerializerContext(IServiceProvider services) : JsonConverterFactory
{
    private readonly Stack<PropertyUseContext> _stack = [];
    internal IServiceProvider Services => services;
    internal PropertyUse PropertyUse { get; set; } = null!;
    internal PropertyUse? CurrentPropertyUse
    {
        get
        {
            if (_stack.Count == 0)
            {
                return null;
            }
            PropertyUseContext cur = _stack.Peek();
            return cur.PropertyUse.Children![cur.ChildOffset];
        }
    }
    public override bool CanConvert(Type typeToConvert)
    {
        return false;
    }
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
    internal bool Push()
    {
        if(CurrentPropertyUse is { } && CurrentPropertyUse.Children is { } && CurrentPropertyUse.Children.Count > 0)
        {
            _stack.Push(new PropertyUseContext { PropertyUse = CurrentPropertyUse , ChildOffset = 0});
            return true;
        }
        return false;
    }
    internal bool Move()
    {
        if (_stack.Count > 0)
        {
            PropertyUseContext cur = _stack.Peek();
            if(cur.PropertyUse.Children is { } &&  cur.PropertyUse.Children.Count - 1 > cur.ChildOffset)
            {
                ++cur.ChildOffset;
                return true;
            }
        }
        return false;
    }
    internal bool Pop()
    {
        if (_stack.Count > 0)
        {
            _stack.Pop();
            return true;
        }
        return false;
    }
}
