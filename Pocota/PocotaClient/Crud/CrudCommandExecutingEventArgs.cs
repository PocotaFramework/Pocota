namespace Net.Leksi.Pocota.Client.Crud;

public class CrudCommandExecutingEventArgs: EventArgs
{
    public ApiCallContext? CallContext { get; init; }

    public CrudCommandExecutingEventArgs(ApiCallContext? callOptions)
    {
        CallContext = callOptions;
    }
}