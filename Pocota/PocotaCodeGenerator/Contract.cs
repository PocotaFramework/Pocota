namespace Net.Leksi.Pocota.Common;

internal class Contract
{
    private Contract? _baseContract = null;
    private int _numChildren = 0;

    internal bool HasChildren => _numChildren > 0;
    internal Contract? BaseContract 
    {
        get => _baseContract;
        set
        {
            if(_baseContract != value)
            {
                if (_baseContract is { })
                {
                    --_baseContract._numChildren;
                }
                _baseContract = value;
                if (_baseContract is { })
                {
                    ++_baseContract._numChildren;
                }
            }
        }
    }
    internal Type Interface { get; set; } = null!;
    internal Dictionary<Type, List<Type>> Projectors { get; init; } = new();
    internal Dictionary<Type, Type> SourcesByProjectors { get; init; } = new();
    internal Dictionary<Type, Type> Projections { get; init; } = new();
    internal Dictionary<Type, Dictionary<string, PrimaryKeyDefinition>> KeyDefinitions { get; init; } = new();

    internal Contract(Type @interface)
    {
        Interface = @interface;
    }

    internal SortedDictionary<string, PrimaryKeyDefinition>? GetKeyDefifnitions(Type type)
    {
        SortedDictionary<string, PrimaryKeyDefinition>? result = null;
        for(Contract? current = this; current is { }; current = current.BaseContract)
        {
            if(KeyDefinitions.TryGetValue(type, out Dictionary<string, PrimaryKeyDefinition>? dict))
            {
                foreach(string name in dict.Keys)
                {
                    (result ??= new SortedDictionary<string, PrimaryKeyDefinition>()).TryAdd(name, dict[name]);
                }
            }
        }
        return result;
    }

    internal Type? GetSource(Type type)
    {
        for (Contract? current = this; current is { }; current = current.BaseContract)
        {
            if (current.SourcesByProjectors[type] is Type result)
            {
                return result;
            }
        }
        return null;
    }
}
