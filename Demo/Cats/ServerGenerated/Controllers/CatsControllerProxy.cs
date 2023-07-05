///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Contract.CatsControllerProxy                       //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-05T17:56:50                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

public class CatsControllerProxy : ControllerProxy
{
    private static readonly PropertyUse s_findCatsPropertyUse = new()
    {
        Property = CatPoco.s_Property,
        Properties = new PropertyUse[] {
            new()
            {
                Property = CatPoco.s_CatteryProperty,
                Path = "Cattery",
                Properties = new PropertyUse[] {
                    new()
                    {
                        Property = CatteryPoco.s_NameEngProperty,
                        Path = "Cattery.NameEng",
                    },
                    new()
                    {
                        Property = CatteryPoco.s_NameNatProperty,
                        Path = "Cattery.NameNat",
                    },
                }.ToImmutableList()
            },
            new()
            {
                Property = CatPoco.s_NameNatProperty,
                Path = "NameNat",
            },
            new()
            {
                Property = CatPoco.s_BreedProperty,
                Path = "Breed",
                Properties = new PropertyUse[] {
                    new()
                    {
                        Property = BreedPoco.s_CodeProperty,
                        Path = "Breed.Code",
                    },
                    new()
                    {
                        Property = BreedPoco.s_GroupProperty,
                        Path = "Breed.Group",
                    },
                    new()
                    {
                        Property = BreedPoco.s_NameNatProperty,
                        Path = "Breed.NameNat",
                    },
                    new()
                    {
                        Property = BreedPoco.s_NameEngProperty,
                        Path = "Breed.NameEng",
                    },
                }.ToImmutableList()
            },
            new()
            {
                Property = CatPoco.s_LitterWithCatsProperty,
                Path = "LitterWithCats",
                Properties = new PropertyUse[] {
                    new()
                    {
                        Property = LitterWithCatsPoco.s_CatsProperty,
                        Path = "LitterWithCats.Cats",
                    },
                }.ToImmutableList()
            },
        }.ToImmutableList()
    };
    private static readonly PropertyUse s_getCatPropertyUse = new()
    {
        Property = CatPoco.s_Property,
        Properties = new PropertyUse[] {
            new()
            {
                Property = CatPoco.s_CatteryProperty,
                Path = "Cattery",
            },
            new()
            {
                Property = CatPoco.s_NameNatProperty,
                Path = "NameNat",
            },
            new()
            {
                Property = CatPoco.s_BreedProperty,
                Path = "Breed",
                Properties = new PropertyUse[] {
                    new()
                    {
                        Property = BreedPoco.s_CodeProperty,
                        Path = "Breed.Code",
                    },
                    new()
                    {
                        Property = BreedPoco.s_GroupProperty,
                        Path = "Breed.Group",
                    },
                }.ToImmutableList()
            },
            new()
            {
                Property = CatPoco.s_LitterWithCatsProperty,
                Path = "LitterWithCats",
            },
            new()
            {
                Property = CatPoco.s_NameEngProperty,
                Path = "NameEng",
            },
            new()
            {
                Property = CatPoco.s_GenderProperty,
                Path = "Gender",
            },
            new()
            {
                Property = CatPoco.s_LitterProperty,
                Path = "Litter",
                Properties = new PropertyUse[] {
                    new()
                    {
                        Property = LitterPoco.s_FemaleProperty,
                        Path = "Litter.Female",
                        Properties = new PropertyUse[] {
                            new()
                            {
                                Property = CatPoco.s_CatteryProperty,
                                Path = "Litter.Female.Cattery",
                            },
                        }.ToImmutableList()
                    },
                    new()
                    {
                        Property = LitterPoco.s_OrderProperty,
                        Path = "Litter.Order",
                    },
                }.ToImmutableList()
            },
            new()
            {
                Property = CatPoco.s_ExteriorProperty,
                Path = "Exterior",
            },
            new()
            {
                Property = CatPoco.s_TitleProperty,
                Path = "Title",
            },
            new()
            {
                Property = CatPoco.s_DescriptionProperty,
                Path = "Description",
            },
        }.ToImmutableList()
    };
    private static readonly PropertyUse s_findBreedsPropertyUse = new()
    {
        Property = BreedPoco.s_Property,
        Properties = new PropertyUse[] {
            new()
            {
                Property = BreedPoco.s_CodeProperty,
                Path = "Code",
            },
            new()
            {
                Property = BreedPoco.s_GroupProperty,
                Path = "Group",
            },
            new()
            {
                Property = BreedPoco.s_NameNatProperty,
                Path = "NameNat",
            },
            new()
            {
                Property = BreedPoco.s_NameEngProperty,
                Path = "NameEng",
            },
        }.ToImmutableList()
    };
    private static readonly PropertyUse s_findCatteriesPropertyUse = new()
    {
        Property = CatteryPoco.s_Property,
        Properties = new PropertyUse[] {
            new()
            {
                Property = CatteryPoco.s_NameEngProperty,
                Path = "NameEng",
            },
            new()
            {
                Property = CatteryPoco.s_NameNatProperty,
                Path = "NameNat",
            },
        }.ToImmutableList()
    };
    private static readonly PropertyUse s_findLittersWithCatsPropertyUse = new()
    {
        Property = LitterWithCatsPoco.s_Property,
        Properties = new PropertyUse[] {
            new()
            {
                Property = LitterWithCatsPoco.s_CatsProperty,
                Path = "Cats",
            },
        }.ToImmutableList()
    };
    private static readonly PropertyUse s_findExteriorsPropertyUse = new()
    {
    };
    private static readonly PropertyUse s_findTitlesPropertyUse = new()
    {
    };

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindCats/{filter?}")]
    public void FindCats(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findCatsPropertyUse;
        pocoContext.ExpectedOutputType = typeof(IList<ICat>);
        pocoContext.ControllerContext = ControllerContext;
        ICatFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        controller.FindCats(filter1);
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/GetCat/{cat}")]
    public void GetCat(string cat) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_getCatPropertyUse;
        pocoContext.ExpectedOutputType = typeof(ICat);
        pocoContext.ControllerContext = ControllerContext;
        ICat cat1 = default!;
        if (cat is { })
        {
            cat1 = JsonSerializer.Deserialize<ICat>(HttpUtility.UrlDecode(cat), pocoContext.JsonSerializerOptions)!;
        }
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        controller.GetCat(cat1);
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindBreeds/{filter?}")]
    public void FindBreeds(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findBreedsPropertyUse;
        pocoContext.ExpectedOutputType = typeof(IList<IBreed>);
        pocoContext.ControllerContext = ControllerContext;
        IBreedFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<IBreedFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        controller.FindBreeds(filter1);
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindCatteries/{filter?}")]
    public void FindCatteries(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findCatteriesPropertyUse;
        pocoContext.ExpectedOutputType = typeof(IList<ICattery>);
        pocoContext.ControllerContext = ControllerContext;
        ICatteryFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatteryFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        controller.FindCatteries(filter1);
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindLittersWithCats/{filter?}")]
    public void FindLittersWithCats(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findLittersWithCatsPropertyUse;
        pocoContext.ExpectedOutputType = typeof(IList<ILitterWithCats>);
        pocoContext.ControllerContext = ControllerContext;
        ICatFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        controller.FindLittersWithCats(filter1);
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindExteriors")]
    public void FindExteriors() 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findExteriorsPropertyUse;
        pocoContext.ExpectedOutputType = typeof(IList<String>);
        pocoContext.ControllerContext = ControllerContext;
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        controller.FindExteriors();
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindTitles")]
    public void FindTitles() 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findTitlesPropertyUse;
        pocoContext.ExpectedOutputType = typeof(IList<String>);
        pocoContext.ControllerContext = ControllerContext;
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        controller.FindTitles();
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/Update")]
    public override void Update()
    {
        base.Update();
    }
}