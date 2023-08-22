using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface IEntity: IPoco
{
    event AccessPropertyChangedEventHandler? AccessPropertyChanged;
    PropertyAccessMode AccessMode { get; }
    void CheckAccess();
    IPrimaryKey PrimaryKey { get; }
}
