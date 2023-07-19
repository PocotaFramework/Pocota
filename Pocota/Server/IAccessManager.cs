namespace Net.Leksi.Pocota.Server;

public interface IAccessManager
{
    void Confirm(PropertyUse propertyUse, object? value, Action<object?> onConfirm);
}
