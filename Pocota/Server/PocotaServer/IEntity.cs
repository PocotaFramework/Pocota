namespace Net.Leksi.Pocota.Server;

public interface IEntity: IPrimaryKey, IPoco
{
    PropertyUse PropertyUse { get; }
    bool Changed { get; }
    void AcceptChanges();
    void AccessGiven();
}
