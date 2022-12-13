using CatsCommon.Model;

namespace CatsCommon.Filters;

public interface ILitterFilter
{
    ICat Female { get; set; }
    ICat Male { get; set; }
}
