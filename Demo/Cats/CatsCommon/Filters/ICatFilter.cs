using CatsCommon.Model;

namespace CatsCommon.Filters;

public interface ICatFilter
{
    IBreed? Breed { get; set; }
    ICattery? Cattery { get; set; }
    DateOnly? BornAfter { get; set; }
    DateOnly? BornBefore { get; set; }
    string? NameRegex { get; set; }
    Gender? Gender { get; set; }
    ICat? Child { get; set; }
    ICat? Self { get; set; }
    ICat? Mother { get; set; }
    ICat? Father { get; set; }
    ICat? Ancestor { get; set; }
    ICat? Descendant { get; set; }
    ILitter? Litter { get; set; }
    string? ExteriorRegex { get; set; }
    string? TitleRegex { get; set; }
}
