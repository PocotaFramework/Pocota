///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Contract.CatsControllerProxy                       //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-28T18:37:14                                                        //
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
    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindCats/{filter?}")]
    public void FindCats(string? filter) 
    {
        ICatFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
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
        ICat cat1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
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
        IBreedFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
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
        ICatteryFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
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
        ICatFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
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
        ICatsController controller = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)controller).ControllerContext = ControllerContext;
        controller.FindExteriors();
    }

    [Route("/api/v1.0/Net/Leksi/Pocota/Demo/Cats/Contract/ICatContract/FindTitles")]
    public void FindTitles() 
    {
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