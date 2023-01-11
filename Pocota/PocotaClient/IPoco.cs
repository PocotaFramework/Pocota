using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

public interface IPoco: INotifyPropertyChanged, INotifyPocoChanged
{
    PocoState PocoState { get; }
    void AcceptChanges();
    void CancelChanges();
    bool IsModified(string property);
    void TouchProperty(string property);
    void Invalidate();
}
