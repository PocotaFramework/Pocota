namespace Net.Leksi.Pocota.Client;

public class NotifyPocoStateChangedEventArgs: EventArgs
{
    public PocoState OldState { get; init; }
    public PocoState NewState { get; init; }

    public NotifyPocoStateChangedEventArgs(PocoState oldState, PocoState newState)
    {
        OldState = oldState;
        NewState = newState;
    }
}
