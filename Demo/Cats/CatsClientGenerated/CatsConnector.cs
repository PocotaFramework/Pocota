/////////////////////////////////////////////////////////////
// Connector                                               //
// CatsContract.CatsConnector                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-24T16:07:37                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Filters;
using CatsCommon.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace CatsContract;

public class CatsConnector : Connector
{
    public CatsConnector(IServiceProvider services) : base(services) { }

    [Route("/cats")]
    public async Task FindCatsAsync(ICatFilter? filter, [DisallowNull]ApiCallContext context) 
    {
        try 
        {
            IPocoContext pocoContext = _services.GetRequiredService<IPocoContext>();
            JsonSerializerOptions jsonSerializerOptions = 
                    pocoContext.BindJsonSerializerOptions(context?.RequestJsonSerializerOptions, JsonSerializerOptionsKind.KeyOnly);      
            if (filter is { })
            {
                pocoContext.AddJsonConverters<ICatFilter?>(jsonSerializerOptions);
            }
            string? filter1 = filter is null 
                    ? "null" 
                    : HttpUtility.UrlEncode(JsonSerializer.Serialize<ICatFilter?>(filter, jsonSerializerOptions));
            string query = $"/cats/{filter1}/";
            context!.HttpRequest = new(HttpMethod.Get, query);
            await GetResponseAsyncEnumerator<ICatForListing>(context!);
        }
        catch(Exception){
            throw;
        }
    }

    [Route("/cats/1")]
    public async Task GetCatAsync(ICat cat, [DisallowNull]ApiCallContext context) 
    {
        try 
        {
            IPocoContext pocoContext = _services.GetRequiredService<IPocoContext>();
            JsonSerializerOptions jsonSerializerOptions = 
                    pocoContext.BindJsonSerializerOptions(context?.RequestJsonSerializerOptions, JsonSerializerOptionsKind.KeyOnly);      
            if (cat is { })
            {
                pocoContext.AddJsonConverters<ICat>(jsonSerializerOptions);
            }
            string cat1 = cat is null 
                    ? "null" 
                    : HttpUtility.UrlEncode(JsonSerializer.Serialize<ICat>(cat, jsonSerializerOptions));
            string query = $"/cats/1/{cat1}/";
            context!.HttpRequest = new(HttpMethod.Get, query);
            await GetResponseAsync<ICatForView>(context!);
        }
        catch(Exception){
            throw;
        }
    }

    [Route("/breeds")]
    public async Task FindBreedsAsync(IBreedFilter? filter, [DisallowNull]ApiCallContext context) 
    {
        try 
        {
            IPocoContext pocoContext = _services.GetRequiredService<IPocoContext>();
            JsonSerializerOptions jsonSerializerOptions = 
                    pocoContext.BindJsonSerializerOptions(context?.RequestJsonSerializerOptions, JsonSerializerOptionsKind.KeyOnly);      
            if (filter is { })
            {
                pocoContext.AddJsonConverters<IBreedFilter?>(jsonSerializerOptions);
            }
            string? filter1 = filter is null 
                    ? "null" 
                    : HttpUtility.UrlEncode(JsonSerializer.Serialize<IBreedFilter?>(filter, jsonSerializerOptions));
            string query = $"/breeds/{filter1}/";
            context!.HttpRequest = new(HttpMethod.Get, query);
            await GetResponseAsyncEnumerator<IBreed>(context!);
        }
        catch(Exception){
            throw;
        }
    }

    [Route("/catteries")]
    public async Task FindCatteriesAsync(ICatteryFilter? filter, [DisallowNull]ApiCallContext context) 
    {
        try 
        {
            IPocoContext pocoContext = _services.GetRequiredService<IPocoContext>();
            JsonSerializerOptions jsonSerializerOptions = 
                    pocoContext.BindJsonSerializerOptions(context?.RequestJsonSerializerOptions, JsonSerializerOptionsKind.KeyOnly);      
            if (filter is { })
            {
                pocoContext.AddJsonConverters<ICatteryFilter?>(jsonSerializerOptions);
            }
            string? filter1 = filter is null 
                    ? "null" 
                    : HttpUtility.UrlEncode(JsonSerializer.Serialize<ICatteryFilter?>(filter, jsonSerializerOptions));
            string query = $"/catteries/{filter1}/";
            context!.HttpRequest = new(HttpMethod.Get, query);
            await GetResponseAsyncEnumerator<ICattery>(context!);
        }
        catch(Exception){
            throw;
        }
    }

    [Route("/litters/with/cats")]
    public async Task FindLittersWithCatsAsync(ICatFilter? filter, [DisallowNull]ApiCallContext context) 
    {
        try 
        {
            IPocoContext pocoContext = _services.GetRequiredService<IPocoContext>();
            JsonSerializerOptions jsonSerializerOptions = 
                    pocoContext.BindJsonSerializerOptions(context?.RequestJsonSerializerOptions, JsonSerializerOptionsKind.KeyOnly);      
            if (filter is { })
            {
                pocoContext.AddJsonConverters<ICatFilter?>(jsonSerializerOptions);
            }
            string? filter1 = filter is null 
                    ? "null" 
                    : HttpUtility.UrlEncode(JsonSerializer.Serialize<ICatFilter?>(filter, jsonSerializerOptions));
            string query = $"/litters/with/cats/{filter1}/";
            context!.HttpRequest = new(HttpMethod.Get, query);
            await GetResponseAsyncEnumerator<ILitterWithCats>(context!);
        }
        catch(Exception){
            throw;
        }
    }

    [Route("/exteriors")]
    public async Task FindExteriorsAsync([DisallowNull]ApiCallContext context) 
    {
        try 
        {
            IPocoContext pocoContext = _services.GetRequiredService<IPocoContext>();
            JsonSerializerOptions jsonSerializerOptions = 
                    pocoContext.BindJsonSerializerOptions(context?.RequestJsonSerializerOptions, JsonSerializerOptionsKind.Ordinary);      
            string query = $"/exteriors/";
            context!.HttpRequest = new(HttpMethod.Get, query);
            await GetResponseAsyncEnumerator<String>(context!);
        }
        catch(Exception){
            throw;
        }
    }

    [Route("/titles")]
    public async Task FindTitlesAsync([DisallowNull]ApiCallContext context) 
    {
        try 
        {
            IPocoContext pocoContext = _services.GetRequiredService<IPocoContext>();
            JsonSerializerOptions jsonSerializerOptions = 
                    pocoContext.BindJsonSerializerOptions(context?.RequestJsonSerializerOptions, JsonSerializerOptionsKind.Ordinary);      
            string query = $"/titles/";
            context!.HttpRequest = new(HttpMethod.Get, query);
            await GetResponseAsyncEnumerator<String>(context!);
        }
        catch(Exception){
            throw;
        }
    }

}