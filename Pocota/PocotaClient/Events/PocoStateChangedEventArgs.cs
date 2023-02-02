namespace Net.Leksi.Pocota.Client;

public class PocoStateChangedEventArgs: EventArgs
{
    public PocoState OldState { get; init; }
    public PocoState NewState { get; init; }

    public PocoStateChangedEventArgs(PocoState oldState, PocoState newState)
    {
        OldState = oldState;
        NewState = newState;
    }
}
