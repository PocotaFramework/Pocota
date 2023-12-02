namespace Net.Leksi.Pocota;

public static class Util
{
    private const string s_void = "void";

    public static string MakeTypeName(Type type)
    {
        if (type == typeof(void))
        {
            return s_void;
        }
        if (!type.IsGenericType)
        {
            return type.Name;
        }
        if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            return MakeTypeName(type.GetGenericArguments()[0]);
        }
        return type.GetGenericTypeDefinition().Name.Substring(0, type.GetGenericTypeDefinition().Name.IndexOf('`'))
            + '<' + String.Join(',', type.GetGenericArguments().Select(v => MakeTypeName(v))) + '>';
    }

    public static void AddNamespaces(HashSet<string> namespaces, Type type)
    {
        if (type.IsGenericType)
        {
            string? ns = type.GetGenericTypeDefinition().Namespace;
            if (ns is { })
            {
                namespaces.Add(ns);
            }
            foreach (Type t in type.GetGenericArguments())
            {
                AddNamespaces(namespaces, t);
            }
        }
        else
        {
            if (type.Namespace is { })
            {
                namespaces.Add(type.Namespace);
            }
        }
    }

}
