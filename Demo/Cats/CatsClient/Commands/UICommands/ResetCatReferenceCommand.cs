using CatsCommon.Filters;
using System;
using System.Reflection;
using System.Windows.Input;

namespace CatsClient;

public class ResetCatReferenceCommand : ICommand
{
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

    public event EventHandler? Executed;

    public bool CanExecute(object? parameter)
    {
        object[]? values = (object[]?)parameter;
        ICatFilter? filter = values?[0] as ICatFilter;
        PropertyInfo? prop = values is { } && values.Length > 1 && values[1] is string propName ? typeof(ICatFilter).GetProperty(propName) : null;
        return filter is { } && prop is { } && prop.GetValue(filter) is { };
    }

    public void Execute(object? parameter)
    {
        object[]? values = (object[]?)parameter;
        ICatFilter? filter = values?[0] as ICatFilter;
        string? propName = values is { } && values.Length > 1 ? values[1].ToString() : null;
        PropertyInfo ? prop = propName is { }  ? typeof(ICatFilter).GetProperty(propName) : null;
        if(prop is { } && filter is { })
        {
            prop.SetValue(filter, null);
            Executed?.Invoke(propName, new EventArgs());
        }
    }

}
