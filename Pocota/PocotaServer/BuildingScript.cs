using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Builder;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota;

public class BuildingScript
{
    public const string KeyOnly = "<KeyOnly>";

    private readonly IServiceProvider _services;
    private readonly Dictionary<string, string?> _fieldsMap = new();
    private readonly Dictionary<string, Type> _converters = new();
    private readonly Dictionary<string, Action<BuildingEventArgs>> _handlers = new();

    public bool WithTrace { get; set; } = false;

    public BuildingScript(IServiceProvider services)
    {
        _services = services;
    }

    public void AddPathMapEntry(string path, string? fieldName, Type? converterType = null)
    {
        _fieldsMap.Add(path, fieldName);
        if(converterType is { })
        {
            if (!typeof(IValueConverter).IsAssignableFrom(converterType))
            {
                throw new ArgumentException($"{nameof(converterType)} must be assignable from {typeof(IValueConverter)} or null!");
            }
            _converters.Add(path, converterType);
        }
    }

    public void AddPathHandler(string path, Action<BuildingEventArgs> handler)
    {
        _handlers.Add(path, handler);
    }

    public void Run(BuildingEventArgs args)
    {
        if (WithTrace)
        {
            Console.WriteLine(args.PathSelector);
        }
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
                    foreach (string key in args.PrimaryKey.Names.Where(name => args.PrimaryKey[name] == default))
                    {
                        string keyPath = Regex.Replace($"{args.PathSelector}/{key}", "/+", "/");
                        if (!SetValue(keyPath, args, key))
                        {
                            success = false;
                            break;
                        }
                        if (args.PrimaryKey[key] == default)
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
            args.BuildingContext.UpdateLogEntry(null, BuildingEventResult.Matched);
        }
    }

    private bool SetValue(string path, BuildingEventArgs args, string? key = null)
    {
        string? fieldName;
         if (!_fieldsMap.TryGetValue(path, out fieldName))
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
                        if (_converters.TryGetValue(path, out Type? type))
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
