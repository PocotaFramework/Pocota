namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

[AttributeUsage(AttributeTargets.Assembly)]
public class BuilderPropertiesAttribute: Attribute
{
    public Dictionary<string, string> Properties { get; private init; } = new();

    public BuilderPropertiesAttribute(params string[] entries)
    {
        foreach (string entry in entries)
        {
            string[] parts = entry.Split('=', 2, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if(parts.Length == 2)
            {
                if(!Properties.TryAdd(parts[0], parts[1]))
                {
                    Properties[parts[0]] = parts[1];
                }
            }
            else
            {
                if (!Properties.TryAdd(parts[0], string.Empty))
                {
                    Properties[parts[0]] = string.Empty;
                }
            }
        }
    }
}
