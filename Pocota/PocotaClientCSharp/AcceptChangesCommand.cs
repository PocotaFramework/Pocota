using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Windows;
using System.Windows.Input;

namespace Net.Leksi.Pocota.Client;

public class AcceptChangesCommand : ICommand
{
    public Action<Action>? DispatcherWrapper { get; set; }

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
        IPoco? poco;
        return parameter is { } 
            && (
                (parameter is object[] values && values.Length > 0)
                || ((values = new object[] { parameter }) == values)
            )
            && (
                (values[0] is IProjection<IPoco> proj && proj.As<IPoco>() is IPoco poco1 && (poco = poco1) == poco)
                || (values[0] is WeakReference<IPoco> wr1 && wr1.TryGetTarget(out IPoco? poco2) && (poco = poco2) == poco)
                || (values[0] is WeakReference<PocoBase> wr2 && wr2.TryGetTarget(out PocoBase? poco3) && (poco = poco3) == poco)
            )
            && poco is not IEntity
            && poco.PocoState is PocoState pocoState
            && pocoState is not PocoState.Unchanged
            && (
                values.Length == 1
                || (
                    values[1] is bool edit && edit
                )
            );
    }

    public void Execute(object? parameter)
    {
        IPoco? poco;
        if (
            parameter is { }
            && CanExecute(parameter) 
            && (parameter is object[] values || (values = new object[] { parameter }) == values)
            && (
                (values[0] is IProjection<IPoco> proj && proj.As<IPoco>() is IPoco poco1 && (poco = poco1) == poco)
                || (values[0] is WeakReference<IPoco> wr1 && wr1.TryGetTarget(out IPoco? poco2) && (poco = poco2) == poco)
                || (values[0] is WeakReference<PocoBase> wr2 && wr2.TryGetTarget(out PocoBase? poco3) && (poco = poco3) == poco)
            )
        )
        {
            try
            {
                if(DispatcherWrapper is { })
                {
                    DispatcherWrapper.Invoke(() =>
                    {
                        poco.AcceptChanges();
                    });
                }
                else
                {
                    poco.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}
