using System.Collections.Immutable;
using Humanizer;
using MediatR;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using StrawberryShake;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetIconsFromRelease
{
    public record Request(string Version) : IRequest<ImmutableArray<IconModel>>;

    private class Handler(IFontAwesome fontAwesome, CategoryProvider categoryProvider) : IRequestHandler<Request, ImmutableArray<IconModel>>
    {
        public async Task<ImmutableArray<IconModel>> Handle(Request request, CancellationToken cancellationToken)
        {
            var styles = await fontAwesome.GetReleaseStyles.ExecuteAsync(request.Version, cancellationToken);
            styles.EnsureNoErrors();
            var icons = styles
                       .Data.Release.FamilyStyles
                       .ToAsyncEnumerable()
                       .SelectManyAwait(
                            async style =>
                            {
                                var iconFamily = Enum.TryParse<Family>(style.Family.Pascalize(), true, out var _f) ? _f : default;
                                var iconStyle = Enum.TryParse<Style>(style.Style.Pascalize(), true, out var _s) ? _s : default;
                                var icons = await fontAwesome.GetReleaseIcons.ExecuteAsync(
                                    request.Version,
                                    iconFamily,
                                    iconStyle,
                                    cancellationToken
                                );

                                icons.EnsureNoErrors();
                                return icons
                                      .Data.Release.Icons
                                      .Where(z => z.Svgs?.Any() == true)
                                      .Select(
                                           icon =>
                                           {
                                               var svg = icon.Svgs.Single();
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
                                                   PathData = svg.PathData.Where(z => !string.IsNullOrWhiteSpace(z)).ToImmutableList(),
                                                   Aliases = ImmutableList<string>.Empty,
                                                   // shims are not working quiet like I expect
//                                                  Aliases = icon is { Shim.Id.Length: > 0 }
//                                                      ? ImmutableArray.Create(icon.Shim.Id)
//                                                      : ImmutableArray<string>.Empty,
                                               };
                                           }
                                       )
                                      .ToAsyncEnumerable();
                            }
                        );

            return [..await icons.ToArrayAsync(cancellationToken),];
        }
    }
}
