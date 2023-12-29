namespace Net.Leksi.Pocota;

public interface IEntityProperty: IProperty
{
    AccessFlags GetAccess(object obj);
    void SetAccess(object obj, AccessFlags access);
}
