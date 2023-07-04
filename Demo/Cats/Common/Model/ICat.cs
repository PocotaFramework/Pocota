﻿namespace Net.Leksi.Pocota.Demo.Cats.Common;

public interface ICat
{
    string? NameNat { get; set; }
    string? NameEng { get; set; }
    Gender Gender { get; set; }
    IBreed Breed { get; set; }
    ICattery Cattery { get; set; }
    ILitter? Litter { get; set; }
    string? Exterior { get; set; }
    string? Title { get; set; }
    string? Description { get; set; }
    //for test
    ILitterWithCats? LitterWithCats { get; set; }
}
