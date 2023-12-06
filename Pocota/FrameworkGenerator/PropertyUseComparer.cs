namespace Net.Leksi.Pocota.FrameworkGenerator;

public class PropertyUseComparer : IComparer<PropertyUse>
{
    int IComparer<PropertyUse>.Compare(PropertyUse? x, PropertyUse? y)
    {
        if (x is null && y is { }) return 1;
        if (x is { } && y is null) return -1;
        if(x is { } && y is { })
        {
            if(x.Flags != y.Flags) return -x.Flags.CompareTo(y.Flags);
            if (x.Children is { } && y.Children is null) return -1;
            if (x.Children is null && y.Children is { }) return 1;
            return x.Name.CompareTo(y.Name);
        }
        return 0;
    }
}
