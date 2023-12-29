using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;
public interface IEntity : IPrimaryKey, INotifyPropertyChanged, INotifyPocoStateChanged
{
    IProcessingInfo ProcessingInfo { get; }
    void Create();
    void Delete();
    void CancelChanges();
}
