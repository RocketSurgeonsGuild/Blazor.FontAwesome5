using System.Collections.Immutable;
using MediatR;
using Rocket.Surgery.LaunchPad.Foundation;
using StrawberryShake;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetIconsFromKit
{
    public record Request(string Name) : IStreamRequest<IconModel>;

    class Handler : IStreamRequestHandler<Request, IconModel>
    {
        private readonly IFontAwesome _fontAwesome;

        public Handler(IFontAwesome fontAwesome)
        {
            _fontAwesome = fontAwesome;
        }
        public async IAsyncEnumerable<IconModel> Handle(Request request, CancellationToken cancellationToken)
        {
            var styles = await _fontAwesome.GetKitStyles.ExecuteAsync(request.Name, cancellationToken);
            styles.EnsureNoErrors();
            var icons = styles
                       .Data.Me.Kit.Release.FamilyStyles
                       .ToAsyncEnumerable()
                       .SelectManyAwait(
                            async style =>
                            {
                                var iconFamily = Enum.Parse<Family>(style.Family, true);
                                var iconStyle = Enum.Parse<Style>(style.Style);
                                var icons = await _fontAwesome.GetReleaseIcons.ExecuteAsync(
                                    request.Name,
                                    iconFamily,
                                    iconStyle,
                                    cancellationToken
                                );

                                icons.EnsureNoErrors();
                                return icons.Data.Release.Icons
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
                                                     };
                                                 }
                                             ).ToAsyncEnumerable();
                            }
                        );
            await foreach (var icon in icons.ConfigureAwait(false))
            {
                yield return icon;
            }
        }
    }
}
