///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Contract.CatsControllerProxy                       //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-29T16:58:28                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

public class CatsControllerProxy : ControllerProxy
{
    private static readonly PropertyUse s_findCatsPropertyUse = new()
    {
        Property = CatPoco.s_Property,
        Properties = new() {
            new()
            {
                Property = CatPoco.s_NameNatProperty,
                Path = "NameNat",
            },
            new()
            {
                Property = CatPoco.s_BreedProperty,
                Path = "Breed",
                Properties = new() {
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
                }
            },
            new()
            {
                Property = CatPoco.s_CatteryProperty,
                Path = "Cattery",
                Properties = new() {
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
                }
            },
        }
    };
    private static readonly PropertyUse s_getCatPropertyUse = new()
    {
        Property = CatPoco.s_Property,
        Properties = new() {
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
        }
    };
    private static readonly PropertyUse s_findBreedsPropertyUse = new()
    {
        Property = BreedPoco.s_Property,
        Properties = new() {
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
        }
    };
    private static readonly PropertyUse s_findCatteriesPropertyUse = new()
    {
        Property = CatteryPoco.s_Property,
        Properties = new() {
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
        }
    };
    private static readonly PropertyUse s_findLittersWithCatsPropertyUse = new()
    {
        Property = LitterWithCatsPoco.s_Property,
        Properties = new() {
            new()
            {
                Property = LitterWithCatsPoco.s_LitterProperty,
                Path = "Litter",
            },
            new()
            {
                Property = LitterWithCatsPoco.s_CatsProperty,
                Path = "Cats",
            },
        }
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
        ICatFilter? filter1 = default!;
        JsonSerializerOptions jsonSerializerOptions = pocoContext.CreateJsonSerializerOptions();
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)controller).ControllerContext = ControllerContext;
        controller.FindCats(filter1);
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/GetCat/{cat}")]
    public void GetCat(string cat) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_getCatPropertyUse;
        pocoContext.ExpectedOutputType = typeof(ICat);
        ICat cat1 = default!;
        JsonSerializerOptions jsonSerializerOptions = pocoContext.CreateJsonSerializerOptions();
        if (cat is { })
        {
            cat1 = JsonSerializer.Deserialize<ICat>(HttpUtility.UrlDecode(cat), jsonSerializerOptions)!;
        }
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)controller).ControllerContext = ControllerContext;
        controller.GetCat(cat1);
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindBreeds/{filter?}")]
    public void FindBreeds(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findBreedsPropertyUse;
        pocoContext.ExpectedOutputType = typeof(IList<IBreed>);
        IBreedFilter? filter1 = default!;
        JsonSerializerOptions jsonSerializerOptions = pocoContext.CreateJsonSerializerOptions();
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<IBreedFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)controller).ControllerContext = ControllerContext;
        controller.FindBreeds(filter1);
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindCatteries/{filter?}")]
    public void FindCatteries(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findCatteriesPropertyUse;
        pocoContext.ExpectedOutputType = typeof(IList<ICattery>);
        ICatteryFilter? filter1 = default!;
        JsonSerializerOptions jsonSerializerOptions = pocoContext.CreateJsonSerializerOptions();
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatteryFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)controller).ControllerContext = ControllerContext;
        controller.FindCatteries(filter1);
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindLittersWithCats/{filter?}")]
    public void FindLittersWithCats(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findLittersWithCatsPropertyUse;
        pocoContext.ExpectedOutputType = typeof(IList<ILitterWithCats>);
        ICatFilter? filter1 = default!;
        JsonSerializerOptions jsonSerializerOptions = pocoContext.CreateJsonSerializerOptions();
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)controller).ControllerContext = ControllerContext;
        controller.FindLittersWithCats(filter1);
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindExteriors")]
    public void FindExteriors() 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findExteriorsPropertyUse;
        pocoContext.ExpectedOutputType = typeof(IList<String>);
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)controller).ControllerContext = ControllerContext;
        controller.FindExteriors();
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindTitles")]
    public void FindTitles() 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findTitlesPropertyUse;
        pocoContext.ExpectedOutputType = typeof(IList<String>);
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)controller).ControllerContext = ControllerContext;
        controller.FindTitles();
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/Update")]
    public override void Update()
    {
        base.Update();
    }
}