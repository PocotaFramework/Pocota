using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Net.Leksi.Pocota.Common;

public class PropertyUseModel: PageModel
{
    internal string Name { get; set; } = string.Empty;
    internal Type? Type { get; set; } = null;
    internal string? TypeName { get; set; } = null;
    internal string PropertyField { get; set; } = string.Empty;
    internal string Path { get; set; } = string.Empty;
    internal List<PropertyUseModel>? Properties { get; set; } = null;
    internal string Indentation { get; set; } = string.Empty;
    internal bool IsList { get; set; } = false;
    internal Type? ItemType { get; set; } = null;
    internal bool IsCore { get; set; } = false;
    internal bool IsAccessStuff { get; set; } = false;

    internal PropertyUseModel CloneAsChild(PropertyUseModel parent, int level = 0, int initialIndentation = 0)
    {
        if(level == 0)
        {
            initialIndentation = this.Indentation.Length / 2;
        }
        PropertyUseModel result = new ()
        {
            Name = this.Name,
            Type = this.Type,
            TypeName = this.TypeName,
            PropertyField = this.PropertyField,
            Path = $"{(string.IsNullOrEmpty(parent.Path) ? string.Empty : $"{parent.Path}.")}{this.Path}",
            Indentation = $"{parent.Indentation}{this.Indentation.Substring(0, this.Indentation.Length - initialIndentation)}",
            IsList = this.IsList,
            ItemType = this.ItemType,
            IsCore = this.IsCore,
            IsAccessStuff = this.IsAccessStuff,
        };
        if(Properties is { })
        {
            result.Properties = new List<PropertyUseModel>(this.Properties.Select(p => p.CloneAsChild(parent, level + 1, initialIndentation)));
        }
        return result;
    }

    public override string ToString()
    {
        return toIndentedString(0);
    }

    private string toIndentedString(int level)
    {
        string indentation = string.Format($"{{0,{level}}}", string.Empty).Replace(" ", "    ");
        StringBuilder sb = new();
        sb.Append(indentation).AppendLine("{")
            .Append(indentation).Append(nameof(Name)).Append(": ").Append(Name).AppendLine(",")
            .Append(indentation).Append(nameof(Path)).Append(": ").Append(Path).AppendLine(",")
        ;
        if(Properties is { })
        {
            sb.Append(indentation).Append(nameof(Properties)).AppendLine(": [");
            sb.Append(indentation).AppendLine("]");
        }
        sb.Append(indentation).AppendLine("}");
        return sb.ToString();
    }
}
