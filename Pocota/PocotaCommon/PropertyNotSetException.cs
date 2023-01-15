namespace Net.Leksi.Pocota.Common;

public class PropertyNotSetException : Exception
{
    public PropertyNotSetException(string? propertyName) : base($"The property {propertyName} is not set!")
    {
    }
}
