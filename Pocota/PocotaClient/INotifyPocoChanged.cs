namespace Net.Leksi.Pocota.Client;

public interface INotifyPocoChanged
{
    event PocoChangedEventHandler? PocoChanged;
    event PocoStateChangedEventHandler? PocoStateChanged;
}
