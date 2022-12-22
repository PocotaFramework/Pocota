using CatsCommon.Filters;
using CatsCommon.JsonConverters;
using CatsCommon.Model;
using CatsCommon;
using Net.Leksi.Pocota.Common;

namespace CatsServerEngine;

internal class JsonConfigurator
{
    internal static void Configure(IJsonSerializerConfiguration configuration)
    {
        configuration
               .At<ICatFilter>()
               .At<ICatForListing>()
               .At<ILitterForCat>()
                   .AddJsonConverter<DateOnlyJsonConverter>()
                   .AddJsonConverter<EnumJsonConverter<Gender>>()
               ;
    }
}