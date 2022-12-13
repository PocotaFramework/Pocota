using Net.Leksi.Pocota.Client.Crud;

namespace Net.Leksi.Pocota.Client;

public class ExceptionEventArgs : CrudCommandExecutingEventArgs
{
    public Exception Exception { get; init; }

    public ExceptionEventArgs(Exception exception, ApiCallContext callOptions) : base(callOptions)
    {
        Exception = exception;
    }
}