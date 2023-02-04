using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Net.Leksi.Pocota.Client;

public class ViewTracedPocoCommand : ICommand
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

    private readonly IServiceProvider _services;

    public ViewTracedPocoCommand(IServiceProvider services)
    {
        _services= services;
    }

    public bool CanExecute(object? parameter)
    {
        return parameter is { } 
            && (
                (parameter is object[] values && values.Length > 0)
                || (values = new object[] { parameter }) == values
            )
            && (
                (
                    values.Where(v => v is WeakReference<IPoco>).FirstOrDefault() is WeakReference<IPoco> wr1
                    && wr1.TryGetTarget(out IPoco? poco1)
                    && poco1.PocoState is not PocoState.Finalized
                )
                || (
                    values.Where(v => v is WeakReference<IPoco>).FirstOrDefault() is WeakReference wr2
                    && wr2.Target is IPoco poco2
                    && poco2.PocoState is not PocoState.Finalized
                )
            )
            && (
                values.Length == 1 
                || (
                    values[1] is bool edit
                    && edit
                )
            );
    }

    public void Execute(object? parameter)
    {
        IPoco? poco = null;
        if (
            parameter is { }
            && CanExecute(parameter) 
            && (parameter is object[] values || (values = new object[] { parameter }) == values)
            && (
                (
                    values.Where(v => v is WeakReference<IPoco>).FirstOrDefault() is WeakReference<IPoco> wr1
                    && wr1.TryGetTarget(out IPoco? poco1)
                    && poco1.PocoState is not PocoState.Finalized
                    && (poco = poco1) == poco
                )
                || (
                    values.Where(v => v is WeakReference<IPoco>).FirstOrDefault() is WeakReference wr2
                    && wr2.Target is IPoco poco2
                    && poco2.PocoState is not PocoState.Finalized
                    && (poco = poco2) == poco
                )
            )
        )
        {
            try
            {
                _services.GetRequiredService<TracedPocos>().Dispatcher.Invoke(() =>
                {

                    ViewTracedPoco view = _services.GetRequiredService<ViewTracedPoco>();
                    _services.GetRequiredService<TracedPocos>().AddView(view);
                    view.Source = (PocoBase)poco;
                    view.Show();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}
