using System.Globalization;
using System.Text;
using Rocket.Surgery.Blazor.FontAwesome6;

// ReSharper disable once CheckNamespace
namespace Rocket.Surgery.Blazor.FontAwesome5;

public interface IIcon : ITransformIcon
{
    IconStyle Style { get; }
    string Name { get; }
    IconSize Size { get; }
    IconAnimation Animation { get; }
    string? CssStyle { get; }
    string? CssClass { get; }
    bool FixedWidth { get; }
    IconPull Pull { get; }
    bool Border { get; }
    bool Inverse { get; }
    string? InverseColor { get; }
    Icon? Mask { get; }
    bool SwapOpacity { get; }
    double? PrimaryOpacity { get; }
    double? SecondaryOpacity { get; }
    string? PrimaryColor { get; }
    string? SecondaryColor { get; }


    string? AnimationDelay { get; }
    string? AnimationDirection { get; }
    string? AnimationDuration { get; }
    string? AnimationIterationCount { get; }
    string? AnimationTiming { get; }

    double? BeatScale { get; }
    double? FadeOpacity { get; }
    double? BeatFadeOpacity { get; }
    double? BeatFadeScale { get; }

    double? BounceRebound { get; }
    double? BounceHeight { get; }
    double? BounceStartScaleX { get; }
    double? BounceStartScaleY { get; }
    double? BounceJumpScaleX { get; }
    double? BounceJumpScaleY { get; }
    double? BounceLandScaleX { get; }
    double? BounceLandScaleY { get; }

    double? FlipX { get; }
    double? FlipY { get; }
    double? FlipZ { get; }
    string? FlipAngle { get; }

    string? BorderColor { get; }
    string? BorderPadding { get; }
    string? BorderRadius { get; }
    string? BorderStyle { get; }
    string? BorderWidth { get; }

    string? PullMargin { get; }

    string? StackZIndex { get; }
    string? RotateBy { get; }
}

public interface ITransformIcon
{
    double Grow { get; }
    double Shrink { get; }
    double Rotate { get; }
    double Up { get; }
    double Down { get; }
    double Left { get; }
    double Right { get; }
    IconFlip? FlipTransform { get; }
}

internal static class IconExtensions
{
    public static string ToTransform(this ITransformIcon icon)
    {
        var sb = new StringBuilder();
        ApplyTransform(icon, sb);
        return sb.ToString();
    }

    public static string ToClass(this IIcon icon, bool stack, string? @class = null)
    {
        var sb = new StringBuilder();
        ApplyClass(icon, sb, stack, @class);
        return sb.ToString();
    }

    public static string ToStyle(this IIcon icon, string? style = null)
    {
        var sb = new StringBuilder();
        ApplyStyle(icon, sb, style);
        return sb.ToString();
    }

    public static void ApplyStyle(this IIcon icon, StringBuilder sb, string? style = null)
    {
        if (!string.IsNullOrWhiteSpace(style))
        {
            sb.Append(style);
        }

        if (icon.PrimaryOpacity.HasValue)
        {
            sb.Append(";--fa-primary-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.PrimaryOpacity);
        }

        if (icon.PrimaryColor != null)
        {
            sb.Append(";--fa-primary-color: ").Append(icon.PrimaryColor);
        }

        if (icon.SecondaryOpacity.HasValue)
        {
            sb.Append(";--fa-secondary-opacity: ").AppendFormat(
                CultureInfo.InvariantCulture, "{0:F2}", icon.SecondaryOpacity
            );
        }

        if (icon.SecondaryColor != null)
        {
            sb.Append(";--fa-secondary-color: ").Append(icon.SecondaryColor);
        }

        if (icon.AnimationDelay != null)
        {
            sb.Append(";--fa-animation-delay: ").Append(icon.AnimationDelay);
        }

        if (icon.AnimationDirection != null)
        {
            sb.Append(";--fa-animation-direction: ").Append(icon.AnimationDirection);
        }

        if (icon.AnimationDuration != null)
        {
            sb.Append(";--fa-animation-duration: ").Append(icon.AnimationDuration);
        }

        if (icon.AnimationIterationCount != null)
        {
            sb.Append(";--fa-animation-iteration-count: ").Append(icon.AnimationIterationCount);
        }

        if (icon.AnimationTiming != null)
        {
            sb.Append(";--fa-animation-timing: ").Append(icon.AnimationTiming);
        }

        if (( icon.Animation & IconAnimation.Beat ) == IconAnimation.Beat && icon.BeatScale.HasValue)
        {
            sb.Append(";--fa-beat-scale: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.BeatScale);
        }

        if (( icon.Animation & IconAnimation.Fade ) == IconAnimation.Fade && icon.FadeOpacity.HasValue)
        {
            sb.Append(";--fa-fade-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.FadeOpacity);
        }

        if (( icon.Animation & IconAnimation.BeatFade ) == IconAnimation.BeatFade)
        {
            if (icon.BeatFadeOpacity.HasValue)
            {
                sb.Append(";--fa-beat-fade-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.BeatFadeOpacity);
            }

            if (icon.BeatFadeScale.HasValue)
            {
                sb.Append(";--fa-beat-fade-scale: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.BeatFadeScale);
            }
        }

        if (( icon.Animation & IconAnimation.Flip ) == IconAnimation.Flip)
        {
            if (icon.FlipX.HasValue)
            {
                sb.Append(";--fa-flip-x: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.FlipX);
            }

            if (( icon.Animation & IconAnimation.Flip ) == IconAnimation.Flip && icon.FlipY.HasValue)
            {
                sb.Append(";--fa-flip-y: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.FlipY);
            }

            if (( icon.Animation & IconAnimation.Flip ) == IconAnimation.Flip && icon.FlipZ.HasValue)
            {
                sb.Append(";--fa-flip-z: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.FlipZ);
            }

            if (( icon.Animation & IconAnimation.Flip ) == IconAnimation.Flip && icon.FlipAngle != null)
            {
                sb.Append(";--fa-flip-angle: ").Append(icon.FlipAngle);
            }
        }

        if (( icon.Animation & IconAnimation.Bounce ) == IconAnimation.Bounce)
        {
            if (icon.BounceRebound.HasValue)
            {
                sb.Append(";--fa-bounce-rebound: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.BounceRebound);
            }

            if (icon.BounceHeight.HasValue)
            {
                sb.Append(";--fa-bounce-height: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.BounceHeight);
            }

            if (icon.BounceStartScaleX.HasValue)
            {
                sb.Append(";--fa-bounce-start-scale-x").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.BounceStartScaleX);
            }

            if (icon.BounceStartScaleY.HasValue)
            {
                sb.Append(";--fa-bounce-start-scale-y").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.BounceStartScaleY);
            }

            if (icon.BounceJumpScaleX.HasValue)
            {
                sb.Append(";--fa-bounce-jump-scale-x").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.BounceJumpScaleX);
            }

            if (icon.BounceJumpScaleY.HasValue)
            {
                sb.Append(";--fa-bounce-jump-scale-y").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.BounceJumpScaleY);
            }

            if (icon.BounceLandScaleX.HasValue)
            {
                sb.Append(";--fa-bounce-land-scale-x").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.BounceLandScaleX);
            }

            if (icon.BounceLandScaleY.HasValue)
            {
                sb.Append(";--fa-bounce-land-scale-y").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.BounceLandScaleY);
            }
        }

        if (icon.Border)
        {
            if (icon.BorderColor != null)
            {
                sb.Append(";--fa-border-color: ").Append(icon.BorderColor);
            }

            if (icon.BorderPadding != null)
            {
                sb.Append(";--fa-border-padding: ").Append(icon.BorderPadding);
            }

            if (icon.BorderRadius != null)
            {
                sb.Append(";--fa-border-radius: ").Append(icon.BorderRadius);
            }

            if (icon.BorderStyle != null)
            {
                sb.Append(";--fa-border-style: ").Append(icon.BorderStyle);
            }

            if (icon.BorderWidth != null)
            {
                sb.Append(";--fa-border-width: ").Append(icon.BorderWidth);
            }
        }

        if (icon.Pull != IconPull.None)
        {
            if (icon.PullMargin != null)
            {
                sb.Append(";--fa-pull-margin: ").Append(icon.PullMargin);
            }
        }

        if (!string.IsNullOrWhiteSpace(icon.StackZIndex))
        {
            sb.Append(";--fa-stack-z-index: ").Append(icon.StackZIndex);
        }

        if (!string.IsNullOrWhiteSpace(icon.InverseColor ))
        {
            sb.Append(";--fa-inverse: ").Append(icon.InverseColor);
        }

        if (icon.RotateBy != null)
        {
            sb.Append(";--fa-rotate-angle: ").Append(icon.RotateBy);
        }
    }

    public static bool ApplyTransform(this ITransformIcon icon, StringBuilder sb, Action? changing = null)
    {
        var hasChanges = false;
        if (icon.Grow > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("grow-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Grow);
        }

        if (icon.Shrink > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("shrink-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Shrink);
        }

        if (Math.Abs(icon.Rotate) > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("rotate-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Rotate);
        }

        if (icon.Up > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("up-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Up);
        }

        if (icon.Down > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("down-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Down);
        }

        if (icon.Left > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("left-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Left);
        }

        if (icon.Right > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("right-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Right);
        }

        if (icon.FlipTransform.HasValue && icon.FlipTransform != IconFlip.None)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(Icon.ToString(icon.FlipTransform.Value));
        }

        return hasChanges;
    }

    public static void ApplyName(StringBuilder sb, string name)
    {
        sb.Append("fa-");
        if (string.IsNullOrWhiteSpace(name))
        {
            // default icon
            sb.Append("bomb");
        }
        else
        {
            sb.Append(name);
        }
    }

    public static void ApplyClass(this IIcon icon, StringBuilder sb, bool stack = false, string? @class = null)
    {
        sb.Append(Icon.ToPrefix(icon.Style));
        sb.Append(' ');
        ApplyName(sb, icon.Name);
        if (!string.IsNullOrWhiteSpace(@class))
        {
            sb.Append(' ');
            sb.Append(@class);
        }

        if (!string.IsNullOrWhiteSpace(icon.CssClass))
        {
            sb.Append(' ');
            sb.Append(icon.CssClass);
        }

        sb.Append(Icon.ToString(icon.Size, stack));

        if (icon.FixedWidth)
        {
            sb.Append(" fa-fw");
        }

        if (icon.Border)
        {
            sb.Append(" fa-border");
        }

        if (icon.Inverse)
        {
            sb.Append(" fa-inverse");
        }

        if (icon.Animation != IconAnimation.None)
        {
            sb.Append(Icon.ToString(icon.Animation));
        }

        if (icon.Pull != IconPull.None)
        {
            sb.Append(' ');
            sb.Append(Icon.ToString(icon.Pull));
        }

        if (icon.SwapOpacity)
        {
            sb.Append(" fa-swap-opacity");
        }

        if (icon.RotateBy != null)
        {
            sb.Append(" fa-rotate-by");
        }
    }

    public static string ToMask(this IIcon icon)
    {
        var sb = new StringBuilder();
        ApplyMask(icon, sb);
        return sb.ToString();
    }

    public static void ApplyMask(this IIcon icon, StringBuilder sb)
    {
        if (icon.Mask == null)
            return;
        sb.Append(Icon.ToPrefix(icon.Mask.Style));
        sb.Append(" fa-");
        sb.Append(icon.Mask.Name);
    }

    private static void AddSpaceIfChanged(ref bool hasChanges, StringBuilder sb, Action? changing)
    {
        if (hasChanges)
        {
            sb.Append(' ');
        }
        else
        {
            hasChanges = true;
            changing?.Invoke();
        }
    }
}
