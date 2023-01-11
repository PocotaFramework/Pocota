namespace CatsCommon.Model;

public interface ICatWithSiblings
{
    Gender Gender { get; set; }
    ILitterWithCats? Litter { get; set; }
}
