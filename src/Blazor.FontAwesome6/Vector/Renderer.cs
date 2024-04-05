using System.Collections.Immutable;
using System.Text;
using System.Text.Unicode;

namespace Rocket.Surgery.Blazor.FontAwesome6.Vector;

public class Renderer
{
    public static Renderer Instance { get; } = new();

    public ImmutableArray<SvgContent> Render(ISvgIcon iconDefinition, SvgParameters? parameters = null)
    {
        parameters ??= new();

        if (RendererConfig.AutoA11y)
        {
            if (!string.IsNullOrEmpty(parameters.Title))
                parameters = parameters with
                {
                    Attributes = parameters.Attributes.SetItem(
                        "aria-labelledby",
                        $"{RendererConfig.ReplacementClass}-title-{parameters.TitleId ?? UniqueIdGenerator.NextUniqueId()}"
                    )
                };
            else
                parameters = parameters with
                {
                    Attributes = parameters.Attributes.SetItem("aria-hidden", "true").SetItem("focusable", "false"),
                };
        }

        return ImmutableArray.Create(MakeInlineSvgAbstract(parameters, iconDefinition));
    }

    public string RenderToHtml(ISvgIcon iconDefinition, SvgParameters? parameters = null) =>
        string.Join("", Render(iconDefinition, parameters).Select(x => x.ToHtml()));

    private SvgContent? AsFoundIcon(ISvgIcon? icon) =>
        icon switch
        {
            {
                VectorData: [var secondary, var primary]
            } => new()
            {
                Tag = "g",
                Classes = ImmutableArray.Create($"{RendererConfig.CssPrefix}-{DUOTONE_CLASSES.GROUP}"),
                Children = ImmutableArray.Create(
                    new SvgContent
                    {
                        Tag = "path",
                        Classes = ImmutableArray.Create($"{RendererConfig.CssPrefix}-{DUOTONE_CLASSES.SECONDARY}"),
                        Attributes =
                            ImmutableDictionary<string, string>.Empty.AddRange(
                                [new("fill", "currentColor"), new("d", Encoding.UTF8.GetString(secondary.AsSpan()))]
                            )
                    },
                    new SvgContent
                    {
                        Tag = "path",
                        Classes = ImmutableArray.Create($"{RendererConfig.CssPrefix}-{DUOTONE_CLASSES.PRIMARY}"),
                        Attributes =
                            ImmutableDictionary<string, string>.Empty.AddRange(
                                [new("fill", "currentColor"), new("d", Encoding.UTF8.GetString(primary.AsSpan()))]
                            )
                    }
                )
            },
            {
                VectorData: [var vector]
            } => new()
            {
                Tag = "path",
                Attributes = ImmutableDictionary<string, string>.Empty.AddRange(
                    [new("fill", "currentColor"), new("d", Encoding.UTF8.GetString(vector.AsSpan())),]
                )
            },
            _ => null
        };

    private SvgContent MakeInlineSvgAbstract(SvgParameters parameters, ISvgIcon icon)
    {
        var refIcon = icon.Mask ?? icon;
        var width = refIcon.Width;
        var height = refIcon.Height;

        var isUploadedIcon = icon.Prefix == "fak";

        var content = new SvgContent
        {
            Attributes = parameters.Attributes.AddRange(
                [
                    new("data-prefix", icon.Prefix),
                    new("data-icon", icon.Name),
                    new("role", CollectionExtensions.GetValueOrDefault(parameters.Attributes, "role", "img")),
                    new("xmlns", "http://www.w3.org/2000/svg"),
                    new("viewBox", $"0 0 {width} {height}"),
                ]
            ),
            Styles = parameters.Styles,
            Classes = parameters.Classes.AddRange(new[] { RendererConfig.ReplacementClass, icon.Name }),
        };

        if (isUploadedIcon && !parameters.Classes.Contains("fa-fw"))
            content = content with { Attributes = content.Attributes.Add("width", $"{( width / height ) * 16 * 0.0625}em") };

        if (!string.IsNullOrEmpty(parameters.Title))
            content = content with
            {
                Attributes = content.Attributes.Remove("title"),
                Children = content.Children.Add(
                    new()
                    {
                        Tag = "title",
                        Attributes = ImmutableDictionary<string, string>.Empty.Add(
                            "id",
                            content.Attributes.ContainsKey("aria-labelledby")
                                ? content.Attributes["aria-labelledby"]
                                : $"title-{parameters.TitleId ?? UniqueIdGenerator.NextUniqueId()}"
                        ),
                        Children = ImmutableArray.Create(new SvgContent() { Text = parameters.Title })
                    }
                )
            };

        var args = new SvgArgs
        {
            Children = content.Children,
            Icon = icon,
            IconContent = AsFoundIcon(icon)!,
            Mask = icon.Mask,
            MaskContent = AsFoundIcon(icon.Mask),
            Transform = parameters.Transform,
            Attributes = content.Attributes,
            Classes = content.Classes,
            Styles = content.Styles
        };

        var result = icon is { Mask: { } }
            ? GenerateAbstractMask(args)
            : GenerateAbstractIcon(args);

        args = args with
        {
            Children = result.Children,
        };

        return parameters.Symbol != null ? AsSymbol(args) : AsIcon(args);
    }

    private static readonly ImmutableDictionary<string, string> AllSpace = new Dictionary<string, string>
    {
        { "width", "100%" },
        { "height", "100%" },
        { "x", "0" },
        { "y", "0" }
    }.ToImmutableDictionary();

    private string GetStyleString(ImmutableDictionary<string, string> styles) => string.Join(";", styles.Select(s => $"{s.Key}: {s.Value}"));

    private ImmutableDictionary<string, string> SetStyleAttribute(ImmutableDictionary<string, string> attributes, ImmutableDictionary<string, string> styles)
        => attributes.SetItem("style", GetStyleString(styles));


    private static SvgContent FillBlack(SvgContent element)
    {
        return element with { Attributes = element.Attributes.SetItem("fill", "black") };
    }

    private record SvgTransformParameters
    {
        public SvgTransform Transform { get; init; } = SvgTransform.None;
        public double? ContainerWidth { get; init; }
        public double IconWidth { get; init; }
    }

    private record SvgTransformResult
    {
        public ImmutableDictionary<string, string> Outer { get; init; } = ImmutableDictionary<string, string>.Empty;
        public ImmutableDictionary<string, string> Inner { get; init; } = ImmutableDictionary<string, string>.Empty;
        public ImmutableDictionary<string, string> Path { get; init; } = ImmutableDictionary<string, string>.Empty;
    }


    private SvgContent GenerateAbstractIcon(SvgArgs parameters)
    {
        var styleString = GetStyleString(parameters.Styles);
        if (!string.IsNullOrEmpty(styleString))
            parameters = parameters with
            {
                Attributes = SetStyleAttribute(parameters.Attributes, parameters.Styles)
            };

        SvgContent? nextChild = null;

        if (parameters.Transform != SvgTransform.None)
            nextChild = GenerateAbstractTransformGrouping(
                new()
                {
                    Main = parameters.Icon,
                    MainContent = parameters.IconContent,
                    Transform = parameters.Transform,
                    ContainerWidth = parameters.Icon.Width,
                    IconWidth = parameters.Icon.Width
                }
            );

        parameters = parameters with { Children = parameters.Children.Add(nextChild ?? parameters.IconContent) };

        return new SvgContent
        {
            Children = parameters.Children,
            Attributes = parameters.Attributes
        };
    }


    private class GenerateAbstractTransformGroupingParameters
    {
        public ISvgIcon Main { get; set; }
        public SvgContent MainContent { get; set; }
        public SvgTransform Transform { get; set; }
        public double ContainerWidth { get; set; }
        public double IconWidth { get; set; }
    }

    private SvgContent GenerateAbstractTransformGrouping(GenerateAbstractTransformGroupingParameters parameters)
    {
        var outer = ImmutableDictionary.CreateBuilder<string, string>();
        outer.Add("transform", $"translate({parameters.ContainerWidth / 2}, 256)");

        var innerTranslate = $"translate({parameters.Transform.X * 32}, {parameters.Transform.Y * 32}) ";
        var innerScale =
            $"scale({( parameters.Transform.Size / 16 ) * ( parameters.Transform.FlipX ? -1 : 1 )}, {( parameters.Transform.Size / 16 ) * ( parameters.Transform.FlipY ? -1 : 1 )}) ";
        var innerRotate = $"rotate({parameters.Transform.Rotate}, 0, 0)";

        var inner = ImmutableDictionary.CreateBuilder<string, string>();
        inner.Add("transform", $"{innerTranslate} {innerScale} {innerRotate}");

        var path = ImmutableDictionary.CreateBuilder<string, string>();
        path.Add("transform", $"translate({( parameters.IconWidth / 2 ) * -1}, -256)");

        var operations = new
        {
            Outer = outer.ToImmutable(),
            Inner = inner.ToImmutable(),
            Path = path.ToImmutable()
        };

        return new SvgContent
        {
            Tag = "g",
            Attributes = operations.Outer,
            Children = ImmutableArray.Create(
                new SvgContent
                {
                    Tag = "g",
                    Attributes = operations.Inner,
                    Children = ImmutableArray.Create(
                        new SvgContent
                        {
                            Tag = parameters.MainContent.Tag,
                            Children = parameters.MainContent.Children,
                            Attributes = parameters.MainContent.Attributes.AddRange(operations.Path)
                        }
                    )
                }
            )
        };
    }

    private SvgContent GenerateAbstractMask(SvgArgs parameters)
    {
        var trans = TransformForSvg(
            new SvgTransformParameters
            {
                Transform = parameters.Transform,
                ContainerWidth = parameters.Mask?.Width,
                IconWidth = parameters.Icon.Width
            }
        );

        var maskRect = new SvgContent
        {
            Tag = "rect",
            Attributes = new Dictionary<string, string>(AllSpace) { { "fill", "white" } }.ToImmutableDictionary()
        };

        var maskInnerGroupChildrenMixin = parameters.Children != null
            ? new { Children = parameters.Children.Select(FillBlack).ToList() }
            : new { Children = new List<SvgContent>() };

        var maskInnerGroup = new SvgContent
        {
            Tag = "g",
            Attributes = trans.Inner,
            Children = ImmutableArray<SvgContent>
                      .Empty.Add(
                           FillBlack(
                               new()
                               {
                                   Tag = parameters.IconContent.Tag,
                                   Attributes = parameters.IconContent.Attributes.AddRange(trans.Path)
                               }
                           )
                       )
                      .AddRange(maskInnerGroupChildrenMixin.Children)
        };

        var maskOuterGroup = new SvgContent
        {
            Tag = "g",
            Attributes = trans.Outer,
            Children = ImmutableArray<SvgContent>.Empty.Add(maskInnerGroup)
        };

        var maskId = $"mask-{UniqueIdGenerator.NextUniqueId()}";
        var clipId = $"clip-{UniqueIdGenerator.NextUniqueId()}";

        var maskTag = new SvgContent()
        {
            Tag = "mask",
            Attributes = AllSpace.AddRange([new("id", maskId), new("maskUnits", "userSpaceOnUse"), new("maskContentUnits", "userSpaceOnUse")]),
            Children = new List<SvgContent> { maskRect, maskOuterGroup }.ToImmutableArray()
        };

        var defs = new SvgContent
        {
            Tag = "defs",
            Children = new List<SvgContent>
            {
                new SvgContent
                {
                    Tag = "clipPath",
                    Attributes = new Dictionary<string, string> { { "id", clipId } }.ToImmutableDictionary(),
                    Children = parameters.MaskContent?.Children ?? ImmutableArray<SvgContent>.Empty
                },
                maskTag
            }.ToImmutableArray()
        };

        parameters = parameters with
        {
            Children = parameters
                      .Children.Add(defs)
                      .Add(
                           new()
                           {
                               Tag = "rect",
                               Attributes = AllSpace.AddRange(
                                   [new("fill", "currentColor"), new("clip-path", $"url(#{clipId})"), new("mask", $"url(#{maskId})")]
                               )
                           }
                       )
        };

        return new SvgContent
        {
            Children = parameters.Children,
            Attributes = parameters.Attributes
        };
    }

    private SvgTransformResult TransformForSvg(SvgTransformParameters parameters)
    {
        var innerTranslate = $"translate({parameters.Transform.X * 32}, {parameters.Transform.Y * 32}) ";
        var innerScale =
            $"scale({( parameters.Transform.Size / 16 ) * ( parameters.Transform.FlipX ? -1 : 1 )}, {( parameters.Transform.Size / 16 ) * ( parameters.Transform.FlipY ? -1 : 1 )}) ";
        var innerRotate = $"rotate({parameters.Transform.Rotate}, 0, 0)";

        return new SvgTransformResult
        {
            Outer = ImmutableDictionary<string, string>.Empty.Add("transform", $"translate({parameters.ContainerWidth / 2}, 256)"),
            Inner = ImmutableDictionary<string, string>.Empty.Add("transform", $"{innerTranslate} {innerScale} {innerRotate}"),
            Path = ImmutableDictionary<string, string>.Empty.Add("transform", $"translate({( parameters.IconWidth / 2 ) * -1}, -256)")
        };
    }

    private static SvgContent AsIcon(SvgArgs svgObject)
    {
        if (svgObject is { Transform: { } transform } && transform != SvgTransform.None && svgObject is { Mask: null })
        {
            var width = svgObject.Icon.Width;
            var height = svgObject.Icon.Height;
            var offset = new { X = width / (double)height / 2, Y = 0.5 };
            svgObject = svgObject with
            {
                Styles = svgObject.Styles.Add(
                    "transform-origin",
                    $"{offset.X + ( svgObject.Transform.X / 16 )}em {offset.Y + ( svgObject.Transform.Y / 16 )}em"
                )
            };
        }

        return new SvgContent
        {
            Tag = "svg",
            Attributes = svgObject.Attributes,
            Children = svgObject.Children,
            Classes = svgObject.Classes,
            Styles = svgObject.Styles,
        };
    }

    private static SvgContent AsSymbol(SvgArgs svgObject)
    {
        throw new NotImplementedException();
//        var id = svgObject.Icon.Symbol == "true" ? $"{svgObject.Icon.Prefix}-{svgObject.Icon.Name}" : svgObject.Icon.Symbol;
//
//        return new SvgContent
//        {
//            Tag = "svg",
//            Attributes = new Dictionary<string, string> { { "style", "display: none;" } }.ToImmutableDictionary(),
//            Children = new ImmutableArray<SvgContent>()
//            {
//                new SvgContent
//                {
//                    Tag = "symbol",
//                    Attributes = svgObject.Content.Attributes.SetItem("id", id),
//                    Children = svgObject.Children,
//                    Classes = svgObject.Classes,
//                    Styles = svgObject.Styles
//                }
//            }
//        };
    }
}
