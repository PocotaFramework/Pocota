///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Contract.CatsController                                //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-22T09:17:59.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

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

public interface IFindCatsDataProviderFactory: IDataProviderFactory
{
    DataProvider Create(ICatFilter? filter);
}

public interface IGetCatDataProviderFactory: IDataProviderFactory
{
    DataProvider Create(ICat cat);
}

public interface IFindBreedsDataProviderFactory: IDataProviderFactory
{
    DataProvider Create(IBreedFilter? filter);
}

public interface IFindCatteriesDataProviderFactory: IDataProviderFactory
{
    DataProvider Create(ICatteryFilter? filter);
}

public interface IFindLittersWithCatsDataProviderFactory: IDataProviderFactory
{
    DataProvider Create(ICatFilter? filter);
}

public interface IFindExteriorsDataProviderFactory: IDataProviderFactory
{
    DataProvider Create();
}

public interface IFindTitlesDataProviderFactory: IDataProviderFactory
{
    DataProvider Create();
}

public class FindCatsDefaultDataProviderFactory: IFindCatsDataProviderFactory
{
    public DataProvider Create(ICatFilter? filter)
    {
        return new DataProviderStub();
    }
}

public class GetCatDefaultDataProviderFactory: IGetCatDataProviderFactory
{
    public DataProvider Create(ICat cat)
    {
        return new DataProviderStub();
    }
}

public class FindBreedsDefaultDataProviderFactory: IFindBreedsDataProviderFactory
{
    public DataProvider Create(IBreedFilter? filter)
    {
        return new DataProviderStub();
    }
}

public class FindCatteriesDefaultDataProviderFactory: IFindCatteriesDataProviderFactory
{
    public DataProvider Create(ICatteryFilter? filter)
    {
        return new DataProviderStub();
    }
}

public class FindLittersWithCatsDefaultDataProviderFactory: IFindLittersWithCatsDataProviderFactory
{
    public DataProvider Create(ICatFilter? filter)
    {
        return new DataProviderStub();
    }
}

public class FindExteriorsDefaultDataProviderFactory: IFindExteriorsDataProviderFactory
{
    public DataProvider Create()
    {
        return new DataProviderStub();
    }
}

public class FindTitlesDefaultDataProviderFactory: IFindTitlesDataProviderFactory
{
    public DataProvider Create()
    {
        return new DataProviderStub();
    }
}

public interface IFindCatsProcessorFactory: IProcessorFactory
    {
        IProcessor<ICat> Create(ICatFilter? filter);
    }

public interface IGetCatProcessorFactory: IProcessorFactory
    {
        IProcessor<ICat> Create(ICat cat);
    }

public interface IFindBreedsProcessorFactory: IProcessorFactory
    {
        IProcessor<IBreed> Create(IBreedFilter? filter);
    }

public interface IFindCatteriesProcessorFactory: IProcessorFactory
    {
        IProcessor<ICattery> Create(ICatteryFilter? filter);
    }

public interface IFindLittersWithCatsProcessorFactory: IProcessorFactory
    {
        IProcessor<ILitterWithCats> Create(ICatFilter? filter);
    }

public interface IFindExteriorsProcessorFactory: IProcessorFactory
    {
        IProcessor<String> Create();
    }

public interface IFindTitlesProcessorFactory: IProcessorFactory
    {
        IProcessor<String> Create();
    }

public class FindCatsDefaultProcessorFactory: IFindCatsProcessorFactory
{
    public IProcessor<ICat> Create(ICatFilter? filter)
    {
        return new FarNienteProcessor<ICat>();
    }
}

public class GetCatDefaultProcessorFactory: IGetCatProcessorFactory
{
    public IProcessor<ICat> Create(ICat cat)
    {
        return new FarNienteProcessor<ICat>();
    }
}

public class FindBreedsDefaultProcessorFactory: IFindBreedsProcessorFactory
{
    public IProcessor<IBreed> Create(IBreedFilter? filter)
    {
        return new FarNienteProcessor<IBreed>();
    }
}

public class FindCatteriesDefaultProcessorFactory: IFindCatteriesProcessorFactory
{
    public IProcessor<ICattery> Create(ICatteryFilter? filter)
    {
        return new FarNienteProcessor<ICattery>();
    }
}

public class FindLittersWithCatsDefaultProcessorFactory: IFindLittersWithCatsProcessorFactory
{
    public IProcessor<ILitterWithCats> Create(ICatFilter? filter)
    {
        return new FarNienteProcessor<ILitterWithCats>();
    }
}

public class FindExteriorsDefaultProcessorFactory: IFindExteriorsProcessorFactory
{
    public IProcessor<String> Create()
    {
        return new FarNienteProcessor<String>();
    }
}

public class FindTitlesDefaultProcessorFactory: IFindTitlesProcessorFactory
{
    public IProcessor<String> Create()
    {
        return new FarNienteProcessor<String>();
    }
}

public class CatsController : PocoController
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
                        Properties = new PropertyUse[] {
                            new()
                            {
                                Property = CatPoco.s_Property,
                                Path = "LitterWithCats.Cats.@",
                                Properties = new PropertyUse[] {
                                    new()
                                    {
                                        Property = CatPoco.s_CatteryProperty,
                                        Path = "LitterWithCats.Cats.@.Cattery",
                                    },
                                }.ToImmutableList()
                            },
                        }.ToImmutableList()
                    },
                    new()
                    {
                        Property = LitterWithCatsPoco.s_StringsProperty,
                        Path = "LitterWithCats.Strings",
                        Properties = new PropertyUse[] {
                            new()
                            {
                                Property = new FreeProperty(typeof(String)),
                                Path = "LitterWithCats.Strings.@",
                            },
                        }.ToImmutableList()
                    },
                    new()
                    {
                        Property = LitterWithCatsPoco.s_ListsProperty,
                        Path = "LitterWithCats.Lists",
                        Properties = new PropertyUse[] {
                            new()
                            {
                                Property = new FreeProperty(typeof(IList<String>)),
                                Path = "LitterWithCats.Lists.@",
                                Properties = new PropertyUse[] {
                                    new()
                                    {
                                        Property = new FreeProperty(typeof(String)),
                                        Path = "LitterWithCats.Lists.@.@",
                                    },
                                }.ToImmutableList()
                            },
                        }.ToImmutableList()
                    },
                    new()
                    {
                        Property = LitterWithCatsPoco.s_CatFilterProperty,
                        Path = "LitterWithCats.CatFilter",
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
                Properties = new PropertyUse[] {
                    new()
                    {
                        Property = CatPoco.s_Property,
                        Path = "Cats.@",
                        Properties = new PropertyUse[] {
                            new()
                            {
                                Property = CatPoco.s_CatteryProperty,
                                Path = "Cats.@.Cattery",
                            },
                        }.ToImmutableList()
                    },
                }.ToImmutableList()
            },
            new()
            {
                Property = LitterWithCatsPoco.s_StringsProperty,
                Path = "Strings",
                Properties = new PropertyUse[] {
                    new()
                    {
                        Property = new FreeProperty(typeof(String)),
                        Path = "Strings.@",
                    },
                }.ToImmutableList()
            },
            new()
            {
                Property = LitterWithCatsPoco.s_ListsProperty,
                Path = "Lists",
                Properties = new PropertyUse[] {
                    new()
                    {
                        Property = new FreeProperty(typeof(IList<String>)),
                        Path = "Lists.@",
                        Properties = new PropertyUse[] {
                            new()
                            {
                                Property = new FreeProperty(typeof(String)),
                                Path = "Lists.@.@",
                            },
                        }.ToImmutableList()
                    },
                }.ToImmutableList()
            },
            new()
            {
                Property = LitterWithCatsPoco.s_CatFilterProperty,
                Path = "CatFilter",
            },
        }.ToImmutableList()
    };
    private static readonly PropertyUse s_findExteriorsPropertyUse = new()
    {
        Property = new FreeProperty(typeof(String)),
    };
    private static readonly PropertyUse s_findTitlesPropertyUse = new()
    {
        Property = new FreeProperty(typeof(String)),
    };

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindCats/{filter?}")]
    public void FindCats(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findCatsPropertyUse;
        pocoContext.ControllerContext = ControllerContext;
        ICatFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindCatsProcessorFactory>().Create(filter1).ProcessEnumerable(
                pocoContext.Build<ICat>(HttpContext.RequestServices.GetRequiredService<IFindCatsDataProviderFactory>().Create(filter1), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/GetCat/{cat}")]
    public void GetCat(string cat) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_getCatPropertyUse;
        pocoContext.ControllerContext = ControllerContext;
        ICat cat1 = default!;
        if (cat is { })
        {
            cat1 = JsonSerializer.Deserialize<ICat>(HttpUtility.UrlDecode(cat), pocoContext.JsonSerializerOptions)!;
        }
        IEnumerator<ICat> en = pocoContext.Build<ICat>(HttpContext.RequestServices.GetRequiredService<IGetCatDataProviderFactory>().Create(cat1), true).GetEnumerator();
        if(en.MoveNext())
        {
            JsonSerializer.Serialize(
                new Utf8JsonWriter(HttpContext.Response.Body),
                pocoContext.ConfirmAccess(
                    HttpContext.RequestServices.GetRequiredService<IGetCatProcessorFactory>().Create(cat1).ProcessSingle(en.Current)
                ),
                pocoContext.JsonSerializerOptions
            );
        }
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindBreeds/{filter?}")]
    public void FindBreeds(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findBreedsPropertyUse;
        pocoContext.ControllerContext = ControllerContext;
        IBreedFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<IBreedFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindBreedsProcessorFactory>().Create(filter1).ProcessEnumerable(
                pocoContext.Build<IBreed>(HttpContext.RequestServices.GetRequiredService<IFindBreedsDataProviderFactory>().Create(filter1), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindCatteries/{filter?}")]
    public void FindCatteries(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findCatteriesPropertyUse;
        pocoContext.ControllerContext = ControllerContext;
        ICatteryFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatteryFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindCatteriesProcessorFactory>().Create(filter1).ProcessEnumerable(
                pocoContext.Build<ICattery>(HttpContext.RequestServices.GetRequiredService<IFindCatteriesDataProviderFactory>().Create(filter1), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindLittersWithCats/{filter?}")]
    public void FindLittersWithCats(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findLittersWithCatsPropertyUse;
        pocoContext.ControllerContext = ControllerContext;
        ICatFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindLittersWithCatsProcessorFactory>().Create(filter1).ProcessEnumerable(
                pocoContext.Build<ILitterWithCats>(HttpContext.RequestServices.GetRequiredService<IFindLittersWithCatsDataProviderFactory>().Create(filter1), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindExteriors")]
    public void FindExteriors() 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findExteriorsPropertyUse;
        pocoContext.ControllerContext = ControllerContext;
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindExteriorsProcessorFactory>().Create().ProcessEnumerable(
                pocoContext.Build<String>(HttpContext.RequestServices.GetRequiredService<IFindExteriorsDataProviderFactory>().Create(), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindTitles")]
    public void FindTitles() 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.PropertyUse = s_findTitlesPropertyUse;
        pocoContext.ControllerContext = ControllerContext;
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindTitlesProcessorFactory>().Create().ProcessEnumerable(
                pocoContext.Build<String>(HttpContext.RequestServices.GetRequiredService<IFindTitlesDataProviderFactory>().Create(), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/Update")]
    public override void Update()
    {
        base.Update();
    }
}