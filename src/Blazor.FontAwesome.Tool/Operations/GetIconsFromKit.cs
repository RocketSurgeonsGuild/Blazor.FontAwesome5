using System.Collections.Immutable;
using Humanizer;
using MediatR;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using StrawberryShake;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetIconsFromKit
{
    public record Request(string Name) : IRequest<ImmutableArray<IconModel>>;

    private class Handler(IFontAwesome fontAwesome, CategoryProvider categoryProvider) : IRequestHandler<Request, ImmutableArray<IconModel>>
    {
        public async Task<ImmutableArray<IconModel>> Handle(Request request, CancellationToken cancellationToken)
        {
            var styles = await fontAwesome.GetKitStyles.ExecuteAsync(request.Name, cancellationToken);
            styles.EnsureNoErrors();
            var icons = styles
                       .Data!
                       .Me.Kit.Release.FamilyStyles
                       .ToAsyncEnumerable()
                       .SelectManyAwait(
                            async style =>
                            {
                                var iconFamily = IconModel.ParseFamily(style.Family) ?? throw new NotSupportedException($"Unknown family {style.Family}");
                                var iconStyle = IconModel.ParseStyle(style.Style) ?? throw new NotSupportedException($"Unknown style {style.Style}");
                                var icns = await fontAwesome.GetKitIcons.ExecuteAsync(
                                    request.Name,
                                    iconFamily,
                                    iconStyle,
                                    cancellationToken
                                );

                                icns.EnsureNoErrors();
                                return icns
                                      .Data!
                                      .Me.Kit.Release.Icons
                                      .Select(
                                           icon =>
                                           {
                                               var svg = icon.Svgs.SingleOrDefault();
                                               if (svg is null)
                                               {
                                                   return null;
                                               }

                                               return new IconModel
                                               {
                                                   Categories = categoryProvider.CategoryLookup[icon.Id].ToImmutableHashSet(),
                                                   RawFamily = style.Family,
                                                   RawStyle = style.Style,
                                                   Height = svg.Height,
                                                   Width = svg.Width,
                                                   Id = icon.Id,
                                                   Label = icon.Label,
                                                   Unicode = icon.Unicode,
                                                   PathData = [..svg.PathData.Where(z => !string.IsNullOrWhiteSpace(z)),],
                                                   Aliases = ImmutableList<string>.Empty,
                                                   // shims are not working quiet like I expect
//                                                  Aliases = icon is { Shim.Id.Length: > 0 }
//                                                      ? ImmutableArray.Create(icon.Shim.Id)
//                                                      : ImmutableArray<string>.Empty,
                                               };
                                           }
                                       )
                                      .Where(z => z is { })
                                      .ToAsyncEnumerable();
                            }
                        );
            var customIcons = styles
                             .Data!
                             .Me.Kit.Release.FamilyStyles
                             .ToAsyncEnumerable()
                             .SelectManyAwait(
                                  async style =>
                                  {
                                      var icns = await fontAwesome.GetKitCustomIcons.ExecuteAsync(
                                          request.Name,
                                          cancellationToken
                                      );

                                      icns.EnsureNoErrors();
                                      return icns
                                            .Data!
                                            .Me.Kit.IconUploads.Select(
                                                 icon => new IconModel
                                                 {
                                                     Categories = ImmutableHashSet<CategoryModel>.Empty,
                                                     RawFamily = style.Family,
                                                     RawStyle = style.Style,
                                                     Height = int.TryParse(icon.Height, out var h) ? h : 0,
                                                     Width = int.TryParse(icon.Width, out var w) ? w : 0,
                                                     Id = icon.Name,
                                                     Label = icon.Name,
                                                     Unicode = icon.Unicode.ToString(),
                                                     PathData = icon.PathData.Where(z => !string.IsNullOrWhiteSpace(z)).ToImmutableList(),
                                                     Prefix = "fak",
                                                     LongPrefix = "fa-kit",
                                                     Aliases = ImmutableList<string>.Empty,
                                                 }
                                             )
                                            .ToAsyncEnumerable();
                                  }
                              );
            return [..await icons.Concat(customIcons).ToArrayAsync(cancellationToken),];
        }
    }
}
