using System.Collections.Immutable;
using MediatR;
using StrawberryShake;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetIconsFromRelease
{
    public record Request(string Version) : IStreamRequest<IconModel>;

    class Handler : IStreamRequestHandler<Request, IconModel>
    {
        private readonly IFontAwesome _fontAwesome;

        public Handler(IFontAwesome fontAwesome)
        {
            _fontAwesome = fontAwesome;
        }
        public async IAsyncEnumerable<IconModel> Handle(Request request, CancellationToken cancellationToken)
        {
            var styles = await _fontAwesome.GetReleaseStyles.ExecuteAsync(request.Version, cancellationToken);
            styles.EnsureNoErrors();
            var icons = styles
                       .Data.Release.FamilyStyles
                       .ToAsyncEnumerable()
                       .SelectManyAwait(
                            async style =>
                            {
                                var iconFamily = Enum.Parse<Family>(style.Family, true);
                                var iconStyle = Enum.Parse<Style>(style.Style);
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
                                                  Family = iconFamily,
                                                  Style = iconStyle,
                                                  Height = svg.Height,
                                                  Width = svg.Width,
                                                  Id = icon.Id,
                                                  Unicode = icon.Unicode,
                                                  PathData = svg.PathData.Where(z => !string.IsNullOrWhiteSpace(z)).ToImmutableArray(),
                                                  Prefix = svg.FamilyStyle.Prefix,
                                                  Aliases = ImmutableArray.Create(icon.Shim)
                                              };
                                          }
                                      ).ToAsyncEnumerable();
                            }
                        );
            await foreach (var icon in icons)
            {
                yield return icon;

            }
        }
    }
}
