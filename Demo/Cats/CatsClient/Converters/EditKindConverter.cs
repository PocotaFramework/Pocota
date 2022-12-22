using System;
using System.Windows.Markup;

namespace CatsClient;

public class EditKindConverter : MarkupExtension
{
    private static readonly EnumConverter _converter = new()
    {
        {EditKind.ReadOnly, "Просмотр" },
        {EditKind.EditInline, "Редактирование" },
    };

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return _converter;
    }
}
