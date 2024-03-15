using System.Collections.Immutable;
using MediatR;
using StrawberryShake;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetIconsFromRelease
{
    public record Request(string Version) : IRequest<ImmutableArray<IconModel>>;

    class Handler : IRequestHandler<Request, ImmutableArray<IconModel>>
    {
        private readonly IFontAwesome _fontAwesome;

        public Handler(IFontAwesome fontAwesome)
        {
            _fontAwesome = fontAwesome;
        }
        public async Task<ImmutableArray<IconModel>> Handle(Request request, CancellationToken cancellationToken)
        {
            var styles = await _fontAwesome.GetReleaseStyles.ExecuteAsync(request.Version, cancellationToken);
            styles.EnsureNoErrors();
            var icons = styles
                       .Data.Release.FamilyStyles
                       .ToAsyncEnumerable()
                       .SelectManyAwait(
                            async style =>
                            {
                                var iconFamily = Enum.TryParse<Family>(style.Family, true, out var _f) ? _f : default;
                                var iconStyle = Enum.TryParse<Style>(style.Style, true, out var _s) ? _s : default;
                                var icons = await _fontAwesome.GetReleaseIcons.ExecuteAsync(
                                    request.Version,
                                    iconFamily,
                                    iconStyle,
                                    cancellationToken
                                );

                                icons.EnsureNoErrors();
                                return icons.Data.Release.Icons
                                            .Where(z => z.Svgs?.Any() == true)
                                     .Select(
                                          icon =>
                                          {

                                              var svg = icon.Svgs.Single();
                                              return new IconModel()
                                              {
                                                  Categories = Constants.Categories[icon.Id].ToImmutableHashSet(),
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
                                                  Aliases = icon is { Shim.Id.Length: > 0 }
                                                      ? ImmutableArray.Create(icon.Shim.Id)
                                                      : ImmutableArray<string>.Empty,
                                              };
                                          }
                                      ).ToAsyncEnumerable();
                            }
                        );

            return ( await icons.ToArrayAsync(cancellationToken) ).ToImmutableArray();
        }
    }
}
