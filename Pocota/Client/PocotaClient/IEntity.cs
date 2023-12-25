namespace Net.Leksi.Pocota.Client;
public interface IEntity : IPrimaryKey
{
    Type PrimaryKeyType { get; }
    PocoState PocoState { get; }
    PropertyUse PropertyUse { get; }
}
