using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Server;

internal class ListBuildingJsonConverter<T> : JsonConverter<T> where T : class
{
    private static readonly Type _itemType = typeof(T).GetGenericArguments()[0];
    private static readonly MethodInfo? _add;
    private static readonly MethodInfo? _clear;
    private static readonly MethodInfo? _removeAt;
    private static readonly PropertyInfo? _items;
    private static readonly PropertyInfo? _count;

    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly PocoContext _pocoContext;
    private readonly object? _probe;

    static ListBuildingJsonConverter()
    {
        Queue<Type> types = new();
        types.Enqueue(typeof(T));
        while (types.Count > 0)
        {
            Type now = types.Dequeue();
            foreach (var m in now.GetMethods())
            {
                if ("Add".Equals(m.Name) && _add is null)
                {
                    _add = m;
                }
                else if ("Clear".Equals(m.Name) && _clear is null)
                {
                    _clear = m;
                }
                else if ("RemoveAt".Equals(m.Name) && _removeAt is null)
                {
                    _removeAt = m;
                }
            }
            foreach (var p in now.GetProperties())
            {
                if ("Count".Equals(p.Name) && _count is null)
                {
                    _count = p;
                }
                else if ("Items".Equals(p.Name) && _items is null)
                {
                    _items = p;
                }
            }
            foreach (var intf in now.GetInterfaces())
            {
                types.Enqueue(intf);
            }
            if (now != typeof(object) && now.BaseType is { })
            {
                types.Enqueue(now.BaseType);
            }
        }
    }

    public ListBuildingJsonConverter(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
        _pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
        _probe = _pocoContext.GetProbePlaceholder<T>();
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        //Console.WriteLine(GetType() + " " + string.Join('\n', Environment.StackTrace.Split(new[] { '\n' }).Where(v => v.Contains(":line")).Skip(1).Take(1)));
        if (!(_pocoContext.GetTraversalContext(options) is PocoTraversalContext context))
        {
            throw new InvalidOperationException("Unproper using!");
        }
        
        writer.WriteStartArray();
        
        if (value == _probe)
        {
            value = (T)Activator.CreateInstance(typeof(T).GetGenericTypeDefinition().MakeGenericType(new Type[] { _itemType }))!;
        }
        else if((int)_count?.GetValue(value)! > 0)
        {
            _clear?.Invoke(value, null);
        }

        Type itemType = context.ItemType is { } ? context.ItemType : _itemType;
        context.ItemType = null;
        bool isHighLevel = context.IsHighLevel;
        context.IsHighLevel = false;

        object? itemProbe = _pocoContext.GetProbePlaceholder(itemType);
        object? itemSkip = _pocoContext.GetSkipPlaceholder(itemType);

        while (true)
        {
            context.IsHighLevel = isHighLevel;
            context.Target = null;

            context.IsListItem = true;

            JsonSerializer.Serialize(writer, itemProbe, itemType, options);

            if (context.Target is null)
            {
                break;
            }
            if (!PocoBase.ReferenceEquals(itemSkip, context.Target))
            {
                _add!.Invoke(value, new[] { context.Target });
            }
            context.Target = null;
        }

        writer.WriteEndArray();
        context.Target = value;
    }

}
