using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

public interface IPoco: INotifyPropertyChanged, INotifyPocoChanged
{
    PocoState PocoState { get; }
    void AcceptChanges();
    void CancelChanges();
}
