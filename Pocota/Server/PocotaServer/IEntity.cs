namespace Net.Leksi.Pocota.Server;

public interface IEntity: IPrimaryKey
{
    Type PrimaryKeyType { get; }
    IProcessingInfo ProcessingInfo { get; }
    PropertyUse PropertyUse { get; }
}
