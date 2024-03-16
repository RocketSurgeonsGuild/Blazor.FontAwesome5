using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using MediatR;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetFileContentForIcons
{
    public record Request(ImmutableArray<IconModel> Icons, string Namespace, bool AsSvgIcon, CategoryProvider CategoryProvider) : IStreamRequest<FileContent>;
    public record FileContent(string FileName, string Content);

    class Handler : IStreamRequestHandler<Request, FileContent>
    {
        public async IAsyncEnumerable<FileContent> Handle(Request request, [EnumeratorCancellation] CancellationToken cancellationToken)
        {

            foreach (var iconSet in request.Icons
                                           .GroupBy(z => ( z.RawFamily, z.RawStyle ))
                                           .Select(group => group.GetIconFileContent(request.AsSvgIcon, request.Namespace)))
            {
                yield return new ("Icons/" + iconSet.FileName, iconSet.Content);
            }

            foreach (var category in request.CategoryProvider.Categories.Values)
            {
                var categoryIcons = request.Icons.Where(z => z.Categories.Contains(category));
                var categoryFileContent = categoryIcons.GetCategoryFileContent(category, request.AsSvgIcon, request.Namespace);
                yield return new ("Categories/" + categoryFileContent.FileName, categoryFileContent.Content);
            }
        }
    }
}
