using CatsCommon.Filters;
using CatsCommon.Model;
using CatsContract;
using CatsServerEngine;
using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota;
using Net.Leksi.Pocota.Server;
using System.Text.Json;

namespace CatsServerEngineDebug.ControllersImpl;

public class CatsController : Controller, ICatsController
{
    private const string AppJson = "application/json";

    public void FindBreeds(IBreedFilter? filter)
    {
        IBuilder builder = HttpContext.RequestServices.GetRequiredService<IBuilder>();
        HttpContext.Response.ContentType = AppJson;
        builder.BuildBreeds(filter, new BuildingOptions { Output = HttpContext.Response.Body });
    }

    public void FindCatteries(ICatteryFilter? filter)
    {
        IBuilder builder = HttpContext.RequestServices.GetRequiredService<IBuilder>();
        HttpContext.Response.ContentType = AppJson;
        builder.BuildCatteries(filter, new BuildingOptions { Output = HttpContext.Response.Body });
    }

    public void FindCats(ICatFilter? filter)
    {
        IBuilder builder = HttpContext.RequestServices.GetRequiredService<IBuilder>();
        HttpContext.Response.ContentType = AppJson;
        JsonSerializerOptions optionsOut = HttpContext.RequestServices.GetRequiredService<IPocoContext>().BindJsonSerializerOptions();

        builder.BuildCats<ICatForListing>(
            filter,
            new BuildingOptions { Output = HttpContext.Response.Body, JsonSerializerOptions = optionsOut }
        );
    }

    public void FindLittersWithCats(ICatFilter? filter)
    {
        IBuilder builder = HttpContext.RequestServices.GetRequiredService<IBuilder>();
        HttpContext.Response.ContentType = AppJson;
        JsonSerializerOptions optionsOut = HttpContext.RequestServices.GetRequiredService<IPocoContext>().BindJsonSerializerOptions();

        builder.BuildLittersWithCats(
            filter,
            new BuildingOptions { 
                Output = HttpContext.Response.Body, 
                JsonSerializerOptions = optionsOut, 
            }
        );
    }

    public void FindExteriors()
    {
        IBuilder builder = HttpContext.RequestServices.GetRequiredService<IBuilder>();
        HttpContext.Response.ContentType = AppJson;
        builder.BuildExteriors(
            new BuildingOptions { Output = HttpContext.Response.Body }
        );
    }

    public void FindTitles()
    {
        IBuilder builder = HttpContext.RequestServices.GetRequiredService<IBuilder>();
        HttpContext.Response.ContentType = AppJson;
        builder.BuildTitles(
            new BuildingOptions { Output = HttpContext.Response.Body }
        );
    }

    public void GetCat(ICat cat)
    {
        IBuilder builder = HttpContext.RequestServices.GetRequiredService<IBuilder>();
        HttpContext.Response.ContentType = AppJson;
        JsonSerializerOptions optionsOut = HttpContext.RequestServices.GetRequiredService<IPocoContext>().BindJsonSerializerOptions();

        builder.BuildCat<ICatForView>(
            cat,
            new BuildingOptions { Output = HttpContext.Response.Body, JsonSerializerOptions = optionsOut }
        );
    }

}
