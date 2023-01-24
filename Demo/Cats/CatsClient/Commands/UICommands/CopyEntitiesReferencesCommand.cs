using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace CatsClient;

public class CopyEntitiesReferencesCommand : ICommand
{
    private readonly IPocoContext _pocoContext;

    public event EventHandler? CanExecuteChanged
    {
        add
        {
            CommandManager.RequerySuggested += value;
        }
        remove
        {
            CommandManager.RequerySuggested -= value;
        }
    }

    public CopyEntitiesReferencesCommand(IServiceProvider services)
    {
        _pocoContext = services.GetRequiredService<IPocoContext>();
    }

    public bool CanExecute(object? parameter)
    {
        return parameter is { }
            && (
                (parameter is object[] values && values.Length > 0) 
                || (values = new object[] { parameter }) == values
            )
            && values.All(v => v is IProjection<IEntity>)
        ;
    }

    public void Execute(object? parameter)
    {
        if(
            parameter is { } && CanExecute(parameter)
            && (
                (parameter is object[] values && values.Length > 0)
                || (values = new object[] { parameter }) == values
            )
        )
        {
            DataObject data = new();
            string json = JsonSerializer.Serialize(
                values.Select(v => ((IProjection)v).As<IEntity>()!).Select(
                    v => new Tuple<string, object[]>(
                        v.GetType().FullName!, 
                        v.PrimaryKey!.Value.ToArray()
                    )
                )
            );
            data.SetData(
                typeof(IEntity),
                json
            );
            data.SetData(
                DataFormats.Text,
                json
            );
            Clipboard.Clear();

            Clipboard.SetDataObject(data);
        }
    }

    public IEntity[]? PasteEntitiesReferences()
    {
        DataObject retrievedData = (DataObject)Clipboard.GetDataObject();

        if (retrievedData.GetDataPresent(typeof(IEntity)))
        {
            string json = retrievedData.GetData(typeof(IEntity))?.ToString() ?? "[]";
            Tuple<string, string[]>[]? arr = JsonSerializer.Deserialize<Tuple<string, string[]>[]>(json);
            if(arr is {} && arr.Length > 0)
            {
                return arr.Select(v => 
                {
                    return _pocoContext.TryGetSource(Type.GetType(arr[0].Item1)!, arr[0].Item2, out object? result) ? (IEntity)result! : null!;
                }).Where(v => v is { }).ToArray();
            }
        }
        return null;
    }
}
