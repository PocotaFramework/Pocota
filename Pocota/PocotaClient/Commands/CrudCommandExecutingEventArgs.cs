namespace Net.Leksi.Pocota.Client;

public class CrudCommandExecutingEventArgs : EventArgs
{
    public ApiCallContext? CallContext { get; init; }
    public bool IsInterrupted { get; private set; }

    public void Interrupt()
    {
        IsInterrupted = true;
    }

    public CrudCommandExecutingEventArgs(ApiCallContext? callOptions)
    {
        CallContext = callOptions;
    }
}