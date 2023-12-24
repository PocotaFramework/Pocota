namespace Net.Leksi.Pocota.Server;

public interface IEntity: IPrimaryKey
{
    Type PrimaryKeyType { get; }
    PocoState PocoState { get; }
    PropertyUse PropertyUse { get; }
    bool Changed { get; }
    void AcceptChanges();
    void AccessGiven();
}
