using CatsCommon.Filters;
using System;

namespace CatsClient;

public class CatFilter : CatFilterPoco
{
    public override string? NameRegex 
    { 
        get => base.NameRegex; 
        set => base.NameRegex = string.IsNullOrWhiteSpace(value) ? null : value.Trim(); 
    }
    public CatFilter(IServiceProvider services) : base(services)
    {
    }
}
