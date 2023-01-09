using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Common;

public abstract class ListJsonConverterBase<T>: JsonConverter<T> where T : class
{
    private static readonly Dictionary<Type, ListMembersHolder> s_members_holders = new();

    protected ListMembersHolder GetListMembersHolder(Type type)
    {
        if (!s_members_holders.TryGetValue(type, out ListMembersHolder? result))
        {
            lock (s_members_holders)
            {
                if (!s_members_holders.TryGetValue(type, out result))
                {
                    result = new ListMembersHolder();
                    Queue<Type> types = new();
                    types.Enqueue(type);
                    while (types.Count > 0)
                    {
                        Type now = types.Dequeue();
                        foreach (var m in now.GetMethods())
                        {
                            if ("Add".Equals(m.Name) && result.Add is null)
                            {
                                result.Add = m;
                            }
                            else if ("RemoveAt".Equals(m.Name) && result.RemoveAt is null)
                            {
                                result.RemoveAt = m;
                            }
                            else if ("Clear".Equals(m.Name) && result.Clear is null)
                            {
                                result.Clear = m;
                            }
                        }
                        foreach (var p in now.GetProperties())
                        {
                            if ("Count".Equals(p.Name) && result.Count is null)
                            {
                                result.Count = p;
                            }
                            else if ("Item".Equals(p.Name) && result.Item is null)
                            {
                                result.Item = p;
                            }
                        }
                        foreach (var intf in now.GetInterfaces())
                        {
                            types.Enqueue(intf);
                        }
                        if (now != typeof(object) && now.BaseType is { })
                        {
                            types.Enqueue(now.BaseType);
                        }
                    }
                    s_members_holders.Add(type, result);
                }
            }
        }
        return result;
    }

}
