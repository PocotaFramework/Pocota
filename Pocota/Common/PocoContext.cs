
using Microsoft.Extensions.DependencyInjection;

namespace Net.Leksi.Pocota;

public class PocoContext: IPocoContext
{
    private readonly IServiceProvider _services;
    private readonly IProcessingInfoProvider _infoProvider;
    private Dictionary<Type, EntityNode> _entitiesCache = new();

    public ProcessingStage ProcessingStage => _infoProvider.ProcessingStage;

    public PocoContext(IServiceProvider services)
    {
        _services = services;
        _infoProvider = _services.GetRequiredService<IProcessingInfoProvider>();
    }
    public T GetEntity<T>(IEnumerable<object> primaryKey) where T : class
    { 
        EntityNode node = FindEntity(typeof(T), primaryKey);
        if(node.Entity is null)
        {
            node.Entity = _services.GetRequiredService<T>();
        }
        return (T)node.Entity!;
    }
    internal EntityNode FindEntity(Type type, IEnumerable<object> primaryKey)
    {
        if (!_entitiesCache.TryGetValue(type, out EntityNode? current))
        {
            current = new EntityNode();
            _entitiesCache.Add(type, current);
        }

        foreach (object? part in primaryKey)
        {
            if (part == default)
            {
                throw new InvalidOperationException("Primary Key cannot have default part!");
            }
            if (current.Children is null)
            {
                current.Children = [];
            }
            if (!current.Children.TryGetValue(part, out EntityNode? node))
            {
                node = new EntityNode();
            }
            current = node;
        }

        return current;
    }
}
