namespace Net.Leksi.Pocota.Client
{
    public class CrudCommandExecutedEventArgs: CrudCommandExecutingEventArgs
    {
        public object? Result { get; init; }

        public CrudCommandExecutedEventArgs(object? result, ApiCallContext? callOptions):base(callOptions)
        {
            Result = result;
        }
    }
}