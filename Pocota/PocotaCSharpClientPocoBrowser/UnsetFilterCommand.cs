using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using System;
using System.Windows.Input;
using static System.Formats.Asn1.AsnWriter;

namespace Net.Leksi.Pocota.Client;

public class UnsetFilterCommand : ICommand
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
    private readonly PocotaCore _core;

    public UnsetFilterCommand(IServiceProvider services)
    {
        _services = services;
        _core = (services.GetRequiredService<IPocota>() as PocotaCore)!;
    }

    public bool CanExecute(object? parameter)
    {
        return parameter is MethodParameterHolder mph && typeof(IProjection).IsAssignableFrom(_core.GetActualType(mph.Type)) && mph.Value is { };
    }

    public void Execute(object? parameter)
    {
        if (parameter is MethodParameterHolder mph && typeof(IProjection).IsAssignableFrom(_core.GetActualType(mph.Type)) && mph.Value is { })
        {
            mph.Value = null;
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
