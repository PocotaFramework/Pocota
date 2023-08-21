using System.ComponentModel;

namespace Net.Leksi.Pocota.Server;

public interface IEntity: IPoco
{
    public static PropertyChangedEventArgs AccessPropertyChangedEventArgs { get; private set; } = new(string.Empty);
}
