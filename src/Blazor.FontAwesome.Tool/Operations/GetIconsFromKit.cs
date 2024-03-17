using System.Collections.Immutable;
using Humanizer;
using MediatR;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using Rocket.Surgery.LaunchPad.Foundation;
using StrawberryShake;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetIconsFromKit
{
    public record Request(string Name, CategoryProvider CategoryProvider) : IRequest<ImmutableArray<IconModel>>;

    class Handler(IFontAwesome fontAwesome) : IRequestHandler<Request, ImmutableArray<IconModel>>
    {
        public async Task<ImmutableArray<IconModel>> Handle(Request request, CancellationToken cancellationToken)
        {
            var styles = await fontAwesome.GetKitStyles.ExecuteAsync(request.Name, cancellationToken);
            styles.EnsureNoErrors();
            var icons = styles
                       .Data.Me.Kit.Release.FamilyStyles
                       .ToAsyncEnumerable()
                       .SelectManyAwait(
                            async style =>
                            {
                                var iconFamily = Enum.TryParse<Family>(style.Family, true, out var _f) ? _f : default;
                                var iconStyle = Enum.TryParse<Style>(style.Style, true, out var _s) ? _s : default;
                                var icons = await fontAwesome.GetKitIcons.ExecuteAsync(
                                    request.Name,
                                    iconFamily,
                                    iconStyle,
                                    cancellationToken
                                );

                                icons.EnsureNoErrors();
                                return icons
                                      .Data.Me.Kit.Release.Icons
                                      .Select(
                                           icon =>
                                           {
                                               var svg = icon.Svgs.SingleOrDefault();
                                               if (svg is null)
                                               {
                                                   return null;
                                               }
                                               return new IconModel()
                                               {
                                                   Categories = request.CategoryProvider.CategoryLookup[icon.Id].ToImmutableHashSet(),
                                                   RawFamily = style.Family,
                                                   RawStyle = style.Style,
                                                   Height = svg.Height,
                                                   Width = svg.Width,
                                                   Id = icon.Id,
                                                   Label = icon.Label,
                                                   Unicode = icon.Unicode,
                                                   PathData = svg.PathData.Where(z => !string.IsNullOrWhiteSpace(z)).ToImmutableArray(),
                                                   Prefix = svg.FamilyStyle.Prefix,
                                                   LongPrefix = ( iconFamily, iconStyle ) switch
                                                                {
                                                                    (_, Style.Brands) => "fa-brands",
                                                                    (Family.Duotone, _) => "fa-duotone",
                                                                    (Family.Classic, _) => $"fa-{style.Style.ToLowerInvariant()}",
                                                                    (_, _) => $"fa-{style.Family.ToLowerInvariant()} fa-{style.Style.ToLowerInvariant()}",
                                                                },
                                                   Aliases = ImmutableArray<string>.Empty,
                                                   // shims are not working quiet like I expect
//                                                  Aliases = icon is { Shim.Id.Length: > 0 }
//                                                      ? ImmutableArray.Create(icon.Shim.Id)
//                                                      : ImmutableArray<string>.Empty,
                                               };
                                           }
                                       )
                                      .Where(z => z is {})
                                      .ToAsyncEnumerable();
                            }
                        );
            var customIcons = styles
                             .Data.Me.Kit.Release.FamilyStyles
                             .ToAsyncEnumerable()
                             .SelectManyAwait(
                                  async style =>
                                  {
                                      var icons = await fontAwesome.GetKitCustomIcons.ExecuteAsync(
                                          request.Name,
                                          cancellationToken
                                      );

                                      icons.EnsureNoErrors();
                                      return icons
                                            .Data.Me.Kit.IconUploads.Select(
                                                 icon => new IconModel()
                                                 {
                                                     Categories = ImmutableHashSet<CategoryModel>.Empty,
                                                     RawFamily = style.Family,
                                                     RawStyle = style.Style,
                                                     Height = int.TryParse(icon.Height, out var h) ? h : 0,
                                                     Width = int.TryParse(icon.Width, out var w) ? w : 0,
                                                     Id = icon.Name,
                                                     Label = icon.Name,
                                                     Unicode = icon.Unicode.ToString(),
                                                     PathData = icon.PathData.Where(z => !string.IsNullOrWhiteSpace(z)).ToImmutableArray(),
                                                     Prefix = "fak",
                                                     LongPrefix = "fa-kit",
                                                     Aliases = ImmutableArray<string>.Empty,
                                                 }
                                             )
                                            .ToAsyncEnumerable();
                                  }
                              );
            return ( await icons.Concat(customIcons).ToArrayAsync(cancellationToken) ).ToImmutableArray();
        }
    }
}
