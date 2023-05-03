using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

internal class PrimaryKeyHolder: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly int _position;
    private readonly IEntity _entity;

    public string Name => _entity.KeyNames[_position];

    public object? Value {
        get
        {
            return _entity.PrimaryKey is { } ? _entity.PrimaryKey.Value[_position] : null;
        }
        set
        {
            _entity.SetPrimaryKeyPart(Name, value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }
    }   

    internal PrimaryKeyHolder(IEntity entity, int position)
    {
        _entity = entity;
        _position = position;
    }
}
