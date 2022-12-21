using Net.Leksi.Pocota.Common;
using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

public interface IPoco: INotifyPropertyChanged, INotifyPocoChanged
{
    PocoState PocoState { get; }
    void AcceptChanges();
    void CancelChanges();
    bool IsModified(string property);
    bool IsLoaded(Type @interface);
    bool IsLoaded<T>();
    void TouchProperty(string property);
    void Invalidate();
}
