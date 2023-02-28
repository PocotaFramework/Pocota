using System;
using System.Collections.Generic;
using System.Web;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Markup.Primitives;

namespace Net.Leksi.Pocota.Client;

[MarkupExtensionReturnType(typeof(Style))]
[ContentProperty("Styles")]
[DictionaryKeyProperty("TargetType")]
public class StyleCombiner : MarkupExtension
{
    public List<object> Styles { get; init; } = new();

    public Type TargetType { get; set; } = null!;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        Style result = new Style();
        foreach (var st in Styles)
        {
            Style? style = null!;
            if(
                (st is Style style1 && (style = style1) == style)
                || (st is StyleReference style2 && (style = style2.Style) == style)
            )
            {
                WalkMarkup(MarkupWriter.GetMarkupObjectFor(style), result, 0);
            }
        }
        return result;
    }

    private void WalkMarkup(MarkupObject mo, Style result, int level)
    {
        string indention = string.Format($"{{0,{level}}}", "").Replace(" ", "    ");
        foreach (var prop in mo.Properties)
        {
            try
            {
                Console.WriteLine($"{indention}{prop.Name}");
                if (prop.IsComposite)
                {
                    foreach (var item in prop.Items)
                    {
                        WalkMarkup(item, result, level + 1);
                    }
                }
            }
            catch (NullReferenceException)
            {
            }
        }
    }
}
