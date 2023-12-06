namespace Net.Leksi.Pocota;

public interface IEntityProperty: IProperty
{
    Access GetAccess(object obj);
    void SetAccess(object obj, Access access);
}
