using CatsCommon.Filters;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Markup;

namespace CatsClient;

public class ResetCatFilterCommand : MarkupExtension, ICommand
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

    public bool CanExecute(object? parameter)
    {
         return parameter is ICatFilter && typeof(ICatFilter).GetProperties().Where(p => p.GetValue(parameter) != default).Count() is int count && count > 0;
    }

    public void Execute(object? parameter)
    {
        if (CanExecute(parameter))
        {
            foreach(PropertyInfo pi in typeof(ICatFilter).GetProperties())
            {
                pi.SetValue(parameter, default);
            }
            //((IPoco)parameter).AcceptChanges();
        }
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return new ResetCatFilterCommand();
    }
}
