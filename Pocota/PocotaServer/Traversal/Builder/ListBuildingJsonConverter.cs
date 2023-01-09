using Net.Leksi.Pocota.Common;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Server;

internal class ListBuildingJsonConverter<T> : ListJsonConverterBase<T> where T : class
{
    private static readonly Type _itemType = typeof(T).GetGenericArguments()[0];

    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly PocoContext _pocoContext;
    private readonly object? _probe;

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

        try
        {
            writer.WriteStartArray();

            if (value == _probe)
            {
                value = (T)Activator.CreateInstance(typeof(T).GetGenericTypeDefinition().MakeGenericType(new Type[] { _itemType }))!;
            }

            ListMembersHolder membersHolder = GetListMembersHolder(value.GetType());

            if ((int)membersHolder.Count?.GetValue(value)! > 0)
            {
                membersHolder.Clear?.Invoke(value, null);
            }

            context.Stack.Push(value);


            Type itemType = _itemType;
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
                    membersHolder.Add!.Invoke(value, new[] { context.Target });
                }
                context.Target = null;
            }

            writer.WriteEndArray();
            context.Target = value;
        }
        finally
        {
            context.Stack.Pop(value);
        }
    }

}
