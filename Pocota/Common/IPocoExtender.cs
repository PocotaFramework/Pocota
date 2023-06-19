namespace Net.Leksi.Pocota.Common;

public interface IPocoExtender<T> where T : class
{
    T Base { get; }
}
