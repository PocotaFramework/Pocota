using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public class ProjectionList<T, I> : ProjectionListBase<T, I>
    where I : class 
    where T : class
{
    
    public ProjectionList(IList<T> source):base(source) { }

}
