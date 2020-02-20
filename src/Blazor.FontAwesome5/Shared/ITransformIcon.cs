using System;
using System.Text;
using Rocket.Surgery.Blazor.FontAwesome5.Shared;

namespace Rocket.Surgery.Blazor.FontAwesome5
{
    interface ITransformIcon
    {
        double Grow { get; }
        double Shrink { get; }
        double Rotate { get; }
        double Up { get; }
        double Down { get; }
        double Left { get; }
        double Right { get; }
        IconFlip? Flip { get; }
    }

    static class TransformIconExtensions
    {
        public static string ToTransform(this ITransformIcon icon)
        {
            var sb = new StringBuilder();

            if (icon.Grow > 0.001)
            {
                sb.Append($"grow-{icon.Grow:F2} ");
            }

            if (icon.Shrink > 0.001)
            {
                sb.Append($"shrink-{icon.Shrink:F2} ");
            }

            if (Math.Abs(icon.Rotate) > 0.001)
            {
                sb.Append($"rotate-{icon.Rotate:F2} ");
            }

            if (icon.Up > 0.001)
            {
                sb.Append($"up-{icon.Up:F2} ");
            }

            if (icon.Down > 0.001)
            {
                sb.Append($"down-{icon.Down:F2} ");
            }

            if (icon.Left > 0.001)
            {
                sb.Append($"left-{icon.Left:F2} ");
            }

            if (icon.Right > 0.001)
            {
                sb.Append($"right-{icon.Right:F2} ");
            }

            if (icon.Flip.HasValue && icon.Flip != IconFlip.None)
            {
                sb.Append(Icon.ToString(icon.Flip.Value));
            }
            return sb.ToString();
        }
    }
}