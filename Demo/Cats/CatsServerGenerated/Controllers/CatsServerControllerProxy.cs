//////////////////////////////////////////////
// Controller Proxy                         //
// CatsServerMisc.CatsServerControllerProxy //
// Generated automatically from             //
// at 2022-12-19T17:40:43                   //
//////////////////////////////////////////////


using CatsCommon.Filters;
using CatsCommon.Model;
using CatsServerMisc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatsServerMisc;

public class CatsServerControllerProxy : Controller
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
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(filter, jsonSerializerOptions);
        }
        ICatsServerController contra = HttpContext.RequestServices.GetRequiredService<ICatsServerController>();
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
            cat1 = JsonSerializer.Deserialize<ICat>(cat, jsonSerializerOptions)!;
        }
        ICatsServerController contra = HttpContext.RequestServices.GetRequiredService<ICatsServerController>();
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
            filter1 = JsonSerializer.Deserialize<IBreedFilter?>(filter, jsonSerializerOptions);
        }
        ICatsServerController contra = HttpContext.RequestServices.GetRequiredService<ICatsServerController>();
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
            filter1 = JsonSerializer.Deserialize<ICatteryFilter?>(filter, jsonSerializerOptions);
        }
        ICatsServerController contra = HttpContext.RequestServices.GetRequiredService<ICatsServerController>();
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
            filter1 = JsonSerializer.Deserialize<ICatFilter?>(filter, jsonSerializerOptions);
        }
        ICatsServerController contra = HttpContext.RequestServices.GetRequiredService<ICatsServerController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindLittersWithCats(filter1);
    }

    [Route("/exteriors")]
    public void FindExteriors() 
    {
        ICatsServerController contra = HttpContext.RequestServices.GetRequiredService<ICatsServerController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindExteriors();
    }

    [Route("/titles")]
    public void FindTitles() 
    {
        ICatsServerController contra = HttpContext.RequestServices.GetRequiredService<ICatsServerController>();
        ((Controller)contra).ControllerContext = ControllerContext;
        contra.FindTitles();
    }

}