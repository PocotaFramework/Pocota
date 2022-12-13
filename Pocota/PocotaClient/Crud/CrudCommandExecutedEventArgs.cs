namespace Net.Leksi.Pocota.Client.Crud
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