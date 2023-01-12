//////////////////////////////////////
// Controller Proxy                 //
// CatsContract.CatsControllerProxy //
// Generated automatically from     //
// at 2023-01-12T11:37:42           //
//////////////////////////////////////


using CatsCommon.Filters;
using CatsCommon.Model;
using CatsContract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace CatsContract;

public class CatsControllerProxy : Controller
{

    [Route("/cats/{filter?}")]
    public void FindCats(string? filter) 
    {
        ICatFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        JsonSerializerOptions jsonSerializerOptions = pocoContext.BindJsonSerializerOptions();
        if (filter is { })
        {
            pocoContext.AddJsonConverters<ICatFilter?>(jsonSerializerOptions);
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindCats(filter1);
    }

    [Route("/cats/1/{cat}")]
    public void GetCat(string cat) 
    {
        ICat cat1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        JsonSerializerOptions jsonSerializerOptions = pocoContext.BindJsonSerializerOptions();
        if (cat is { })
        {
            pocoContext.AddJsonConverters<ICat>(jsonSerializerOptions);
            cat1 = JsonSerializer.Deserialize<ICat>(HttpUtility.UrlDecode(cat), jsonSerializerOptions)!;
        }
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.GetCat(cat1);
    }

    [Route("/breeds/{filter?}")]
    public void FindBreeds(string? filter) 
    {
        IBreedFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        JsonSerializerOptions jsonSerializerOptions = pocoContext.BindJsonSerializerOptions();
        if (filter is { })
        {
            pocoContext.AddJsonConverters<IBreedFilter?>(jsonSerializerOptions);
            filter1 = JsonSerializer.Deserialize<IBreedFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindBreeds(filter1);
    }

    [Route("/catteries/{filter?}")]
    public void FindCatteries(string? filter) 
    {
        ICatteryFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        JsonSerializerOptions jsonSerializerOptions = pocoContext.BindJsonSerializerOptions();
        if (filter is { })
        {
            pocoContext.AddJsonConverters<ICatteryFilter?>(jsonSerializerOptions);
            filter1 = JsonSerializer.Deserialize<ICatteryFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindCatteries(filter1);
    }

    [Route("/litters/with/cats/{filter?}")]
    public void FindLittersWithCats(string? filter) 
    {
        ICatFilter? filter1 = default!;
        IPocoContext pocoContext = HttpContext.RequestServices.GetRequiredService<IPocoContext>();
        JsonSerializerOptions jsonSerializerOptions = pocoContext.BindJsonSerializerOptions();
        if (filter is { })
        {
            pocoContext.AddJsonConverters<ICatFilter?>(jsonSerializerOptions);
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(HttpUtility.UrlDecode(filter), jsonSerializerOptions);
        }
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindLittersWithCats(filter1);
    }

    [Route("/exteriors")]
    public void FindExteriors() 
    {
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindExteriors();
    }

    [Route("/titles")]
    public void FindTitles() 
    {
        ICatsController contra = HttpContext.RequestServices.GetRequiredService<ICatsController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindTitles();
    }

}