﻿using System.Text.Json;
using System.Windows.Input;

namespace Net.Leksi.Pocota.Client.Crud;

public abstract class CrudCommand : ICommand
{
    public abstract event EventHandler? CanExecuteChanged;

    public event CrudCommandExecutingHandler? Executing;
    public event CrudCommandExecutingHandler? Received;
    public event CrudCommandExecutedEventHandler? Executed;
    public event ExceptionEventHandler? CoughtException;

    protected readonly IServiceProvider _services;
    protected Func<JsonSerializerOptions>? _requestJsonSerializerOptionsSupplier = null;
    protected Func<JsonSerializerOptions>? _responseJsonSerializerOptionsSupplier = null;

    public CrudCommand(IServiceProvider services)
    {
        _services = services;
    }

    public abstract bool CanExecute(object? parameter);

    public void Execute(object? parameter)
    {
        ApiCallContext callOptions = new ApiCallContext { CommandParameter = parameter, OnReceived = OnReceived, OnDone = OnExecuted, OnException = OnException };
        OnExecuting(callOptions);
        DoExecute(callOptions);
    }

    protected abstract void DoExecute(ApiCallContext callOptions);

    protected void OnReceived(ApiCallContext? callOptions)
    {
        Received?.Invoke(this, new CrudCommandExecutingEventArgs(callOptions));
    }

    protected void OnExecuting(ApiCallContext? callOptions)
    {
        Executing?.Invoke(this, new CrudCommandExecutingEventArgs(callOptions));
    }

    protected void OnExecuted(object? result, ApiCallContext? callOptions)
    {
        Executed?.Invoke(this, new CrudCommandExecutedEventArgs(result, callOptions));
    }

    protected void OnException(Exception exception, ApiCallContext? callOptions)
    {
        CoughtException?.Invoke(this, new ExceptionEventArgs(exception, callOptions));
    }

}