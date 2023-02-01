namespace Net.Leksi.Pocota.Client;

public interface INotifyPocoChanged
{
    event EventHandler<NotifyPocoChangedEventArgs>? PocoChanged;
    event EventHandler<NotifyPocoStateChangedEventArgs>? PocoStateChanged;
}
