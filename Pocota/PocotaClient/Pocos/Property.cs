namespace Net.Leksi.Pocota.Client;

public abstract class Property: Common.Property
{
    public abstract bool IsModified(object target);
    public abstract bool IsInitial(object target);
    public abstract void CancelChange(object target);
    public abstract void AcceptChange(object target);
    public abstract object? GetInitial(object target);
}
