using CatsCommon;
using System;
using System.Windows.Markup;

namespace CatsClient;

public class GenderConverter : MarkupExtension
{
    internal static EnumConverter Converter { get; private set; } = new()
    {
        {Gender.Female, "Самка" },
        {Gender.Male, "Самец" },
        {Gender.FemaleCastrate, "Стерилизованная самка" },
        {Gender.MaleCastrate, "Стерилизованный самец" },
    };

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return Converter;
    }
}
