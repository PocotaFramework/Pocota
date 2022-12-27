using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Server;

public class BuildingScript
{
    public const string KeyOnly = "<KeyOnly>";

    private readonly IServiceProvider _services;
    private readonly Dictionary<string, Action<BuildingEventArgs>> _handlers = new();

    private BuildingScriptMapping? _mapping = null;

    private bool _hasExternalMapping = false;

    public BuildingScriptMapping? Mapping { 
        get => _hasExternalMapping ? _mapping : null; 
        set
        {
            _hasExternalMapping = value is { };
            _mapping = value;
        }
    }

    public bool WithTrace { get; set; } = false;

    public BuildingScript(IServiceProvider services)
    {
        _services = services;
    }

    public void AddPathMapEntry(string path, string? fieldName, Type? converterType = null)
    {
        if (_hasExternalMapping)
        {
            throw new InvalidOperationException("Cannot add path map entry to external mapping!");
        }
        if(_mapping is null)
        {
            _mapping = new BuildingScriptMapping();
        }
        _mapping.AddPathMapEntry(path, fieldName, converterType);
    }

    public void AddPathHandler(string path, Action<BuildingEventArgs> handler)
    {
        _handlers.Add(path, handler);
    }

    public void Run(BuildingEventArgs args)
    {
        bool success = true;
        if (args.IsKeyRequest)
        {
            if(_handlers.TryGetValue(args.PathSelector!, out Action<BuildingEventArgs>? handler))
            {
                handler.Invoke(args);
            }
            if(args.PrimaryKey is { })
            {
                if(!SetValue(args.PathSelector!, args, null))
                {
                    foreach (string key in args.PrimaryKey.NotAssignedFields)
                    {
                        string keyPath = Regex.Replace($"{args.PathSelector}/{key}", "/+", "/");
                        if (!SetValue(keyPath, args, key))
                        {
                            success = false;
                            break;
                        }
                        if (args.PrimaryKey.NotAssignedFields.Contains(key))
                        {
                            args.Skip();
                            break;
                        }
                    }
                }
            }
            else
            {
                success = false;
            }
        }
        else
        {
            if (_handlers.TryGetValue(args.PathSelector!, out Action<BuildingEventArgs>? handler))
            {
                handler.Invoke(args);
            }
            else
            {
                success = SetValue(args.PathSelector!, args);
            }
        }
        if (success)
        {
            args.BuildingContext.Log?.UpdateEntry(null, BuildingEventResult.Matched);
        }
    }

    private bool SetValue(string path, BuildingEventArgs args, string? key = null)
    {
        if (WithTrace)
        {
            Console.WriteLine(path);
        }
        string? fieldName = null;
        if (!(_mapping?.FieldsMap.TryGetValue(path, out fieldName) ?? false))
        {
            if (!args.IsKeyRequest || key is { })
            {
                fieldName = Regex.Replace(path, "/+", string.Empty);
            }
        }
        else if (fieldName is null)
        {
            args.SetDefault();
            return true;
        }
        else if (args.IsKeyRequest && fieldName.Equals(KeyOnly))
        {
            args.SetKeyOnly();
            return false;
        }
        if(fieldName is { })
        {
            try
            {
                int pos = args.DataReader!.GetOrdinal(fieldName);
                if (args.DataReader![fieldName] == DBNull.Value)
                {
                    if (!args.IsKeyRequest)
                    {
                        args.SetDefault();
                    }
                }
                else
                {
                    if (args.IsKeyRequest)
                    {
                        args.PrimaryKey[key!] = args.DataReader![fieldName];
                    }
                    else
                    {
                        if (_mapping?.Converters.TryGetValue(path, out Type? type) ?? false)
                        {
                            args.Value = (_services.GetRequiredService(type) as IValueConverter)!.ConvertBack(args.DataReader![fieldName], args.DataReader.GetFieldType(pos));
                        }
                        else
                        {
                            args.Value = Convert.ChangeType(args.DataReader![fieldName], args.PropertyType);
                        }
                    }
                }
                return true;
            }
            catch (IndexOutOfRangeException)
            {
            }
        }
        return false;
    }
}
