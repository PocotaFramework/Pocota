using System.Collections.ObjectModel;

namespace Net.Leksi.Pocota.Client;

public class DoubleBufferingCollection<T>: Collection<T> where T : class
{
    public ICollection<T> Target { get; init; }

    public DoubleBufferingCollection(ICollection<T> target)
    {
        Target = target;
    }

    public void Align()
    {
        List<T> toRemove = Target.Where(v => !Contains(v)).ToList();
        List<T> toAdd = this.Where(v => !Target.Contains(v)).ToList();
        int count = Math.Max(toRemove.Count, toAdd.Count);
        for(int i = 0; i < count; i++)
        {
            if (i < toRemove.Count)
            {
                Target.Remove(toRemove[i]);
            }
            if (i < toAdd.Count)
            {
                Target.Add(toAdd[i]);
            }
        }
    }

    protected override void InsertItem(int index, T item)
    {
        base.InsertItem(index, item);
        if(Count > Target.Count && !Target.Contains(item))
        {
            Target.Add(item);
        }
    }
}
