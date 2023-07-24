///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Contract.CatsController                                //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-24T18:11:45.                                                           //
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

#region DataProviderFactoryInterface
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

public interface IFindLittersDataProviderFactory: IDataProviderFactory
{
    DataProvider Create(ILitterFilter? filter);
}

public interface IFindExteriorsDataProviderFactory: IDataProviderFactory
{
    DataProvider Create();
}

public interface IFindTitlesDataProviderFactory: IDataProviderFactory
{
    DataProvider Create();
}

#endregion DataProviderFactoryInterface

#region DefaultDataProviderFactory
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

public class FindLittersDefaultDataProviderFactory: IFindLittersDataProviderFactory
{
    public DataProvider Create(ILitterFilter? filter)
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

#endregion DefaultDataProviderFactory

#region ProcessorFactoryInterface
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

public interface IFindLittersProcessorFactory: IProcessorFactory
    {
        IProcessor<ILitterWithCats> Create(ILitterFilter? filter);
    }

public interface IFindExteriorsProcessorFactory: IProcessorFactory
    {
        IProcessor<String> Create();
    }

public interface IFindTitlesProcessorFactory: IProcessorFactory
    {
        IProcessor<String> Create();
    }

#endregion ProcessorFactoryInterface

#region DefaultProcessorFactory
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

public class FindLittersDefaultProcessorFactory: IFindLittersProcessorFactory
{
    public IProcessor<ILitterWithCats> Create(ILitterFilter? filter)
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

#endregion DefaultProcessorFactory

public class CatsController : PocoController
{
#region PropertyUse
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
                    Property = CatteryPoco.s_IdCatteryProperty,
                    Path = "IdCattery",
                    IsAccessStuff = true,
                },
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
            }.ToImmutableList()
        };
    private static readonly PropertyUse s_findLittersPropertyUse = new()
        {
            Property = LitterPoco.s_Property,
            Properties = new PropertyUse[] {
                new()
                {
                    Property = LitterWithCatsPoco.s_MaleProperty,
                    Path = "Male",
                    Properties = new PropertyUse[] {
                        new()
                        {
                            Property = CatPoco.s_CatteryProperty,
                            Path = "Male.Cattery",
                            IsAccessStuff = true,
                        },
                    }.ToImmutableList()
                },
                new()
                {
                    Property = LitterWithCatsPoco.s_FemaleProperty,
                    Path = "Female",
                    Properties = new PropertyUse[] {
                        new()
                        {
                            Property = CatPoco.s_CatteryProperty,
                            Path = "Female.Cattery",
                            IsAccessStuff = true,
                        },
                    }.ToImmutableList()
                },
                new()
                {
                    Property = LitterPoco.s_OrderProperty,
                    Path = "Order",
                },
                new()
                {
                    Property = LitterWithCatsPoco.s_CatsProperty,
                    Path = "Cats",
                    IsAccessStuff = true,
                    Properties = new PropertyUse[] {
                        new()
                        {
                            Property = CatPoco.s_Property,
                            Path = "Cats.@",
                            IsAccessStuff = true,
                            Properties = new PropertyUse[] {
                                new()
                                {
                                    Property = CatPoco.s_CatteryProperty,
                                    Path = "Cats.@.Cattery",
                                    IsAccessStuff = true,
                                },
                            }.ToImmutableList()
                        },
                    }.ToImmutableList()
                },
                new()
                {
                    Property = LitterPoco.s_DateProperty,
                    Path = "Date",
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
#endregion PropertyUse

#region RequestHandler
    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindCats/{filter?}")]
    public void FindCats(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.ControllerContext = ControllerContext;
        ICatFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindCatsProcessorFactory>().Create(filter1).ProcessEnumerable(
                pocoContext.Build<ICat>(s_findCatsPropertyUse, HttpContext.RequestServices.GetRequiredService<IFindCatsDataProviderFactory>().Create(filter1), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/GetCat/{cat}")]
    public void GetCat(string cat) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.ControllerContext = ControllerContext;
        ICat cat1 = default!;
        if (cat is { })
        {
            cat1 = JsonSerializer.Deserialize<ICat>(HttpUtility.UrlDecode(cat), pocoContext.JsonSerializerOptions)!;
        }
        IEnumerator<ICat> en = pocoContext.Build<ICat>(s_getCatPropertyUse, HttpContext.RequestServices.GetRequiredService<IGetCatDataProviderFactory>().Create(cat1), true).GetEnumerator();
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
        pocoContext.ControllerContext = ControllerContext;
        IBreedFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<IBreedFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindBreedsProcessorFactory>().Create(filter1).ProcessEnumerable(
                pocoContext.Build<IBreed>(s_findBreedsPropertyUse, HttpContext.RequestServices.GetRequiredService<IFindBreedsDataProviderFactory>().Create(filter1), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindCatteries/{filter?}")]
    public void FindCatteries(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.ControllerContext = ControllerContext;
        ICatteryFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatteryFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindCatteriesProcessorFactory>().Create(filter1).ProcessEnumerable(
                pocoContext.Build<ICattery>(s_findCatteriesPropertyUse, HttpContext.RequestServices.GetRequiredService<IFindCatteriesDataProviderFactory>().Create(filter1), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindLittersWithCats/{filter?}")]
    public void FindLittersWithCats(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.ControllerContext = ControllerContext;
        ICatFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindLittersWithCatsProcessorFactory>().Create(filter1).ProcessEnumerable(
                pocoContext.Build<ILitterWithCats>(s_findLittersWithCatsPropertyUse, HttpContext.RequestServices.GetRequiredService<IFindLittersWithCatsDataProviderFactory>().Create(filter1), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindLitters/{filter?}")]
    public void FindLitters(string? filter) 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.ControllerContext = ControllerContext;
        ILitterFilter? filter1 = default!;
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ILitterFilter?>(HttpUtility.UrlDecode(filter), pocoContext.JsonSerializerOptions);
        }
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindLittersProcessorFactory>().Create(filter1).ProcessEnumerable(
                pocoContext.Build<ILitterWithCats>(s_findLittersPropertyUse, HttpContext.RequestServices.GetRequiredService<IFindLittersDataProviderFactory>().Create(filter1), false)
            ).Select(v => pocoContext.ConfirmAccess(v)).Select(v =>  v.Core),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindExteriors")]
    public void FindExteriors() 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.ControllerContext = ControllerContext;
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindExteriorsProcessorFactory>().Create().ProcessEnumerable(
                pocoContext.Build<String>(s_findExteriorsPropertyUse, HttpContext.RequestServices.GetRequiredService<IFindExteriorsDataProviderFactory>().Create(), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindTitles")]
    public void FindTitles() 
    {
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        pocoContext.ControllerContext = ControllerContext;
        JsonSerializer.Serialize(
            new Utf8JsonWriter(HttpContext.Response.Body),
            HttpContext.RequestServices.GetRequiredService<IFindTitlesProcessorFactory>().Create().ProcessEnumerable(
                pocoContext.Build<String>(s_findTitlesPropertyUse, HttpContext.RequestServices.GetRequiredService<IFindTitlesDataProviderFactory>().Create(), false)
            ).Select(v => pocoContext.ConfirmAccess(v)),
            pocoContext.JsonSerializerOptions
        );
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/Update")]
    public override void Update()
    {
        base.Update();
    }
#endregion RequestHandler
}
