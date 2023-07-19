namespace Net.Leksi.Pocota.Server;

public class AllowAccessManager : IAccessManager
{
    public void Confirm(PropertyUse propertyUse, object? value, Action<object?> onConfirm) 
    {
        onConfirm?.Invoke(value);
    }
}
