using System.Collections.Immutable;
using MediatR;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetIconsFromIconFamilies
{
    public record Request(string FilePath) : IRequest<Response>;
    public record Response(ImmutableArray<object> Icons);

    class Handler : IRequestHandler<Request, Response>
    {
        public Handler()
        {

        }
        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
