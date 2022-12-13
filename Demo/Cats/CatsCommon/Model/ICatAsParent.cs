namespace CatsCommon.Model;

public interface ICatAsParent
{
    string? NameNat { get; }
    string? NameEng { get; }
    IBreed Breed { get; }
    ICattery Cattery { get; }
    ILitterForDate? Litter { get; }
    public string? Exterior { get; }
    public string? Title { get; }
}