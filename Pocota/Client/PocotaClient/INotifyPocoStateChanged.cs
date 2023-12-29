namespace Net.Leksi.Pocota.Client;

public interface INotifyPocoStateChanged
{
    event PocoStateChangedEventHandler PocoStateChanged;
}
