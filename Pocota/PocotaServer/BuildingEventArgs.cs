using System.Data.Common;

namespace Net.Leksi.Pocota.Server;

public class BuildingEventArgs: EventArgs
{
    private string? _stringPath = null;
    private string? _stringPathSelector = null;
    private List<object>? _path = null;
    private readonly PocoContext _pocoContext;
    private int _pathLength = 0;
    private bool _isKeyRequest = false;
    private bool _keyOnly = false;

    internal object? InternalValue { get; set; } = null;
    internal List<object>? InternalPath { 
        get => _path; 
        set
        {
            _path = value;
            _pathLength = 0;
        }
    }

    internal BuildingContext BuildingContext { get; set; } = null!;

    public string? PathSelector
    {
        get
        {
            if(_pathLength != _path?.Count)
            {
                _stringPath = null;
                _stringPathSelector = null;
                _pathLength = _path?.Count ?? 0;
            }
            if (_stringPathSelector is null && _path is { })
            {
                _stringPathSelector = '/' + string.Join(
                    '/',
                    (_path.Count > 0 && _path[0] is int ? _path.Skip(1) : _path).Select(v => v is string
                        ? v.ToString()
                        : "[]")
                );
            }
            return _stringPathSelector;
        }
    }

    public string? StringPath
    {
        get
        {
            if (_pathLength != _path?.Count)
            {
                _stringPath = null;
                _stringPathSelector = null;
                _pathLength = _path?.Count ?? 0;
            }
            if (_stringPath is null && _path is { })
            {
                _stringPath = '/' + string.Join(
                    '/',
                    (_path.Count > 0 && _path[0] is int ? _path.Skip(1) : _path).Select(v => v is string
                        ? v.ToString()
                        : $"[{v.ToString()}]")
                );
            }
            return _stringPath;
        }
    }

    public bool IsKeyRequest
    {
        get => _isKeyRequest;
        internal set
        {
            _keyOnly = false;
            _isKeyRequest = value;
        }
    }
    public bool KeyOnly => _keyOnly;

    public IPrimaryKey? PrimaryKey { get; internal set; } = null;

    public bool IsNullable { get; internal set; } = true;
    public Type PropertyType { get; internal set; } = null!;
    public bool IsCollection { get; internal set; } = false;

    public object? Value
    {
        get
        {
            return InternalValue;
        }
        set
        {
            if (!IsMissed)
            {
                throw new InvalidOperationException("The request is already processed!");
            }
            InternalValue = Convert.ChangeType(value, PropertyType);
            IsMissed = false;
        }
    }

    public DbDataReader? DataReader { get; internal set; }

    public IServiceProvider Services => _pocoContext.Services;

    internal BuildingEventArgs(PocoContext pocoContext, BuildingContext buildingContext)
    {
        _pocoContext = pocoContext;
        BuildingContext = buildingContext;
    }

    public object? GetOwner(int uplevel)
    {
        if (uplevel <= 0 || uplevel > BuildingContext.BufferWriter!.Path.Count)
        {
            throw new ArgumentException($"{nameof(uplevel)} is out of order!");
        }
        return BuildingContext.BufferWriter.Path[BuildingContext.BufferWriter.Path.Count - uplevel].Value;
    }

    public void UseSpinner(IEnumerable<DbDataReader?> spinner,BuildingScript? buildingScript = null)
    {
        if (!IsMissed)
        {
            throw new InvalidOperationException("The request is already processed!");
        }
        BuildingContext.Spinners.Push(new SpinnerHolder { 
            Level = BuildingContext.Level + 1, 
            Spinner = spinner.GetEnumerator(),
            Script = buildingScript ?? Services.GetRequiredService<BuildingScript>(),
            PathPrefixLength = _path!.Count
        });
        IsMissed = false;
    }

    public object Instance(Type type)
    {
        if (_pocoContext.GetProbePlaceholder(type) is object placeholder)
        {
            return placeholder;
        }
        throw new ArgumentException($"{type} has not a placeholder!");
    }

    public object Instance<T>() where T : class
    {
        return Instance(typeof(T));
    }

    public void CreateInstance()
    {
        if (!IsMissed)
        {
            throw new InvalidOperationException("The request is already processed!");
        }
        InternalValue = Instance(PropertyType);
        IsMissed = false;
    }

    public void Touch()
    {
        if (!IsMissed)
        {
            throw new InvalidOperationException("The request is already processed!");
        }
        IsMissed = false;
    }

    public void SetKeyOnly()
    {
        if (!IsMissed)
        {
            throw new InvalidOperationException("The request is already processed!");
        }
        IsMissed = false;
        _keyOnly = true;
    }

    public void SetDefault()
    {
        if (!IsMissed)
        {
            throw new InvalidOperationException("The request is already processed!");
        }
        InternalValue = Convert.ChangeType(default, PropertyType);
        IsMissed = false;
    }

    public void Skip()
    {
        if (!IsKeyRequest && !IsCollection)
        {
            throw new InvalidOperationException($"{nameof(Skip)} can be called only at key requiest or collection!");
        }
        if (!IsMissed && !KeyOnly)
        {
            throw new InvalidOperationException("The request is already processed!");
        }
        InternalValue = _pocoContext.GetSkipPlaceholder(PropertyType!);
        IsMissed = false;
    }

    internal bool IsMissed { get; set; } = true;
}
