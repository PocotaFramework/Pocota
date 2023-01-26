namespace Net.Leksi.Pocota.Client.Event;

public class NotifyModifiedPocosChangedEventArgs
{
    IEntity? AddedItem { get; init; }
    IEntity? RemovedItem { get; init; }

    public NotifyModifiedPocosChangedEventArgs(IEntity? add, IEntity? remove)
    {
        AddedItem = add;
        RemovedItem = remove;
    }
}
