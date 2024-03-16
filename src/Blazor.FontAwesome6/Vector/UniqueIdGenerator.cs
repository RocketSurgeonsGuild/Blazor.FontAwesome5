using System.Text;

namespace Rocket.Surgery.Blazor.FontAwesome6.Vector;

public class UniqueIdGenerator
{
    private static readonly char[] IdPool = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private static readonly Random Random = new();

    public static string NextUniqueId()
    {
        int size = 12;
        var id = new StringBuilder(size);

        while (size-- > 0)
        {
            id.Append(IdPool[Random.Next(IdPool.Length)]);
        }

        return id.ToString();
    }
}