using Net.Leksi.Pocota.Client.Core;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Net.Leksi.Pocota.Client;

public class WeakEventManager
{
    private readonly ConditionalWeakTable<object, HashSet<object[]>> _handlers = new();
    private readonly object _lock = new();

    public void AddHandler(object source, Delegate? handler)
    {
        if(handler is { })
        {
            if (!_handlers.TryGetValue(source, out HashSet<object[]>? set))
            {
                lock (_lock)
                {
                    if (!_handlers.TryGetValue(source, out set))
                    {
                        set = new HashSet<object[]>(WeakEventHandlersEqualityComparer.Instance);
                        _handlers.Add(source, set);
                    }
                }
            }
            lock (set)
            {
                set.Add(new object[] { handler.Method, new WeakReference(handler.Target) });
            }
        }
    }

    public void RemoveHandler(object source, Delegate? handler)
    {
        if (handler is { })
        {
            if (_handlers.TryGetValue(source, out HashSet<object[]>? set))
            {
                lock (set)
                {
                    set.Remove(new object[] { handler.Method, new WeakReference(handler.Target) });
                }
            }
        }
    }

    public void InvokeHandlers(object source, object[] args)
    {
        if (_handlers.TryGetValue(source, out HashSet<object[]>? set))
        {
            List<object[]> list;
            lock (set)
            {
                int numRemoved = set.RemoveWhere(v => !((WeakReference)v[1]).IsAlive);
                list = set.Where(v => ((WeakReference)v[1]).IsAlive).Select(v => new object[] { v[0], ((WeakReference)v[1]).Target! }).ToList();
            }
            foreach (object[] item in list)
            {
                ((MethodBase)item[0]).Invoke(item[1], args);
            }
        }
    }
}
