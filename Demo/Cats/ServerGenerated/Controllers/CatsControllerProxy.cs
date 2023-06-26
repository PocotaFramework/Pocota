///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Contract.CatsControllerProxy                       //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-26T21:54:53                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Demo.Cats.Contract;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

public class CatsControllerProxy : ControllerProxy
{
    [Route("/api/v1.0/cats/{filter?}")]
    public void FindCats(string? filter) 
    {
        ICatFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        JsonSerializerOptions jsonSerializerOptions = pocoContext.CreateJsonSerializerOptions();
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindCats(filter1);
    }

    [Route("/api/v1.0/cats/1/{cat}")]
    public void GetCat(string cat) 
    {
        ICat cat1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        JsonSerializerOptions jsonSerializerOptions = pocoContext.CreateJsonSerializerOptions();
        if (cat is { })
        {
            cat1 = JsonSerializer.Deserialize<ICat>(HttpUtility.UrlDecode(cat), jsonSerializerOptions)!;
        }
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.GetCat(cat1);
    }

    [Route("/api/v1.0/breeds/{filter?}")]
    public void FindBreeds(string? filter) 
    {
        IBreedFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        JsonSerializerOptions jsonSerializerOptions = pocoContext.CreateJsonSerializerOptions();
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<IBreedFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindBreeds(filter1);
    }

    [Route("/api/v1.0/catteries/{filter?}")]
    public void FindCatteries(string? filter) 
    {
        ICatteryFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        JsonSerializerOptions jsonSerializerOptions = pocoContext.CreateJsonSerializerOptions();
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatteryFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindCatteries(filter1);
    }

    [Route("/api/v1.0/litters/with/cats/{filter?}")]
    public void FindLittersWithCats(string? filter) 
    {
        ICatFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        JsonSerializerOptions jsonSerializerOptions = pocoContext.CreateJsonSerializerOptions();
        if (filter is { })
        {
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindLittersWithCats(filter1);
    }

    [Route("/api/v1.0/exteriors")]
    public void FindExteriors() 
    {
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindExteriors();
    }

    [Route("/api/v1.0/titles")]
    public void FindTitles() 
    {
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindTitles();
    }

    [Route("/api/v1.0/catcontract/update")]
    public override void Update()
    {
        base.Update();
    }
}