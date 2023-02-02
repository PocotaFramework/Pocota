namespace Net.Leksi.Pocota.Client;

public interface INotifyPocoChanged
{
    event EventHandler<PocoChangedEventArgs>? PocoChanged;
    event EventHandler<PocoStateChangedEventArgs>? PocoStateChanged;
}
