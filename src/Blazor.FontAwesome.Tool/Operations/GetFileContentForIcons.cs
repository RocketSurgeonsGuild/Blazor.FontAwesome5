using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Humanizer;
using MediatR;
using PrettyCode;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetFileContentForIcons
{
    public record Request(ImmutableArray<IconModel> Icons, string Namespace, bool AsSvgIcon) : IStreamRequest<FileContent>;
    public record FileContent(string FileName, string Content);

    class Handler(CategoryProvider categoryProvider) : IStreamRequestHandler<Request, FileContent>
    {
        public async IAsyncEnumerable<FileContent> Handle(Request request, [EnumeratorCancellation] CancellationToken cancellationToken)
        {

            foreach (var iconSet in request.Icons
                                           .Select(z => new CodeIconModel(z))
                                           .GroupBy(z => z.CodeStyleName)
                                           .Select(group => GetIconFileContent(group, request.AsSvgIcon, request.Namespace)))
            {
                yield return new ("Icons/" + iconSet.FileName, iconSet.Content);
            }

            foreach (var category in categoryProvider.Categories.Values)
            {
                var categoryIcons = request.Icons.Select(z => new CodeIconModel(z)).Where(z => z.Icon.Categories.Contains(category)).ToFrozenSet();
                if (categoryIcons.Count == 0) continue;

                var categoryFileContent = GetCategoryFileContent(categoryIcons, category, request.AsSvgIcon, request.Namespace);
                yield return new ("Categories/" + categoryFileContent.FileName, categoryFileContent.Content);
            }
        }
    }

    internal static (string FileName, string Content) GetIconFileContent(
        this IGrouping<string, CodeIconModel> models,
        bool svgMode,
        string @namespace
    )
    {
        var sb = new StringBuilder(new(), 4, ' ', "\n", 0);

        sb.AppendLine("using System;");
        sb.AppendLine("using System.Collections.Immutable;");
        sb.AppendLine($"using Rocket.Surgery.Blazor.FontAwesome6;");
        sb.AppendLine($"namespace {@namespace};");
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// Font Awesome {models.Key.Humanize()} Icons");
        sb.AppendLine("/// </summary>");
        sb.AppendLine("[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]");
        sb.AppendLine($"public static partial class Fa{models.Key}");
        sb.AppendLine("{");
        using (sb.Indent())
        {
            foreach (var s in models.OrderBy(z => z.Icon.Id))
            {
                AppendIconProperties(s, sb, svgMode, @namespace);
            }
        }

        sb.AppendLine("}");

        return ( $"Fa{models.Key}.cs", sb.ToString() );
    }

    internal static (string FileName, string Content) GetCategoryFileContent(
        IEnumerable<CodeIconModel> models,
        CategoryModel categoryModel,
        bool svgMode,
        string @namespace
    )
    {
        var sb = new StringBuilder(new(), 4, ' ', "\n", 0);

        sb.AppendLine("using System;");
        sb.AppendLine("using System.Collections.Immutable;");
        sb.AppendLine($"using Rocket.Surgery.Blazor.FontAwesome6;");
        sb.AppendLine($"namespace {@namespace}.Categories;");
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// Font Awesome {categoryModel.Label} Category Icons");
        sb.AppendLine("/// </summary>");
        sb.AppendLine("[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]");
        sb.AppendLine($"public static partial class Fa{categoryModel.Name.Humanize().Pascalize()}");
        sb.AppendLine("{");
        using (sb.Indent())
        {
            foreach (var s in models.GroupBy(z => z.Icon.Id).OrderBy(z => z.Key))
            {
                AppendIconCategoryProperties(s, categoryModel, sb, svgMode, @namespace);
            }
        }

        sb.AppendLine("}");

        return ( $"Fa{categoryModel.Name.Humanize().Pascalize()}.cs", sb.ToString() );
    }

    private static void AppendIconProperties(CodeIconModel icon, StringBuilder sb, bool svgMode, string @namespace)
    {
        sb.AppendLine($"private static {icon.IconClass(svgMode)}? f_{icon.CodeModelName};");
        EmitSummaryComment(icon, sb);
        if (svgMode)
        {
            string pathData = "ImmutableArray<string>.Empty";
            if (icon is { Icon.PathData.Count: 1 })
            {
                pathData = $"ImmutableArray.Create(\"{icon.Icon.PathData[0]}\"u8.ToArray().ToImmutableArray())";
            }
            else if (icon is { Icon.PathData.Count: 2 })
            {
                pathData =
                    $"ImmutableArray.Create(\"{icon.Icon.PathData[0]}\"u8.ToArray().ToImmutableArray(), \"{icon.Icon.PathData[1]}\"u8.ToArray().ToImmutableArray())";
            }

            sb.AppendLine(
                $"public static SvgIcon {icon.CodeModelName} => f_{icon.CodeModelName} ??= new SvgIcon(IconFamily.{icon.Icon.Family}, IconStyle.{icon.Icon.Style}, \"{icon.Icon.Id}\", \"{icon.Icon.Unicode}\", {icon.Icon.Width}, {icon.Icon.Height}, {pathData});"
            );
        }
        else
        {
            sb.AppendLine(
                $"public static Icon {icon.CodeModelName} => f_{icon.CodeModelName} ??= new Icon(IconFamily.{icon.Icon.Family}, IconStyle.{icon.Icon.Style}, \"{icon.Icon.Id}\", \"{icon.Icon.Unicode}\");"
            );
        }
        foreach (var alias in icon.CodeAliases)
        {
            EmitSummaryComment(icon, sb);
            sb.AppendLine($"public static {icon.IconClass(svgMode)} {alias} => global::{@namespace}.Fa{icon.CodeStyleName}.{icon.CodeModelName};");
        }
    }

    private static void AppendIconCategoryProperties(
        this IEnumerable<CodeIconModel> icons,
        CategoryModel categoryModel,
        StringBuilder sb,
        bool svgMode,
        string @namespace
    )
    {
        CodeIconModel rootCi;
        {
            var ci = rootCi = icons.First();
            sb.AppendLine("/// <summary>");
            sb.AppendLine($"/// {ci.Icon.Label}");
            sb.AppendLine($"/// <a href=\"{ci.RootHref}\">{ci.Icon.Label}</a>");
            sb.AppendLine("/// </summary>");
            sb.AppendLine("[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]");
            sb.AppendLine(
                $"public static partial class {ci.CodeModelName}{( categoryModel.Name.Equals(ci.Icon.Id, StringComparison.OrdinalIgnoreCase) ? "Icon" : "" )}"
            );
        }
        sb.AppendLine("{");
        using (sb.Indent())
        {
            foreach (var icon in icons
                                 .OrderBy(z => z.Icon.Family)
                                 .ThenBy(z => z.Icon.Style))
            {
                sb.AppendLine("/// <summary>");
                sb.AppendLine($"/// <a href=\"{icon.Href}\">{icon.Icon.Label}</a>");
                sb.AppendLine("/// </summary>");
                sb.AppendLine("[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]");
                sb.AppendLine($"public static { icon.IconClass(svgMode)} {icon.CodeStyleName} => global::{@namespace}.Fa{icon.CodeStyleName}.{rootCi.CodeModelName};");
            }
        }

        sb.AppendLine("}");
    }

    private static void EmitSummaryComment(CodeIconModel icon, StringBuilder sb)
    {
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// <a href=\"{icon.Href}\">{icon.Icon.Label}</a>");
        sb.AppendLine("/// </summary>");
    }
}
