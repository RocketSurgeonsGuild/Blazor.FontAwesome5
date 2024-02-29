using System.Globalization;
using System.Text;
using Rocket.Surgery.Blazor.FontAwesome6;

// ReSharper disable once CheckNamespace
namespace Rocket.Surgery.Blazor.FontAwesome6;

public interface IIcon : ITransformIcon, IAnimationIcon, ISharedIcon
{
    IconFamily Family { get; }
    IconStyle Style { get; }
    string Name { get; }
    IconPull Pull { get; }
    bool Inverse { get; }
    string? InverseColor { get; }
    Icon? Mask { get; }
    bool SwapOpacity { get; }
    double? PrimaryOpacity { get; }
    double? SecondaryOpacity { get; }
    string? PrimaryColor { get; }
    string? SecondaryColor { get; }

    string? PullMargin { get; }

    string? StackZIndex { get; }
    string? RotateBy { get; }
}

public interface ISharedIcon
{
    string? CssStyle { get; }
    string? CssClass { get; }
    bool FixedWidth { get; }
    IconSize Size { get; }
    bool Border { get; }
    string? BorderColor { get; }
    string? BorderPadding { get; }
    string? BorderRadius { get; }
    string? BorderStyle { get; }
    string? BorderWidth { get; }
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

public interface IAnimationIcon
{
     IconAnimation Animation { get;  }
     string? AnimationDelay { get;  }
     string? AnimationDirection { get;  }
     string? AnimationDuration { get;  }
     string? AnimationIterationCount { get;  }
     string? AnimationTiming { get;  }

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

}

internal static class IconExtensions
{
    public static string ToTransform(this ITransformIcon icon)
    {
        var sb = new StringBuilder();
        ApplyTransform(icon, sb);
        return sb.ToString();
    }

    public static string ToClass(this ISharedIcon icon, bool stack, string? @class = null)
    {
        var sb = new StringBuilder();
        ApplyClass(icon, sb, stack, @class);
        return sb.ToString();
    }

    public static string ToStyle(this ISharedIcon icon, string? style = null)
    {
        var sb = new StringBuilder();
        ApplyStyle(icon, sb, style);
        return sb.ToString();
    }

    public static void ApplyStyle(this ISharedIcon icon, StringBuilder sb, string? style = null)
    {
        if (!string.IsNullOrWhiteSpace(style))
        {
            sb.Append(style);
        }

        if (icon is IIcon iicon)
        {
            if (iicon.PrimaryOpacity.HasValue)
            {
                sb.Append(";--fa-primary-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", iicon.PrimaryOpacity);
            }

            if (iicon.PrimaryColor != null)
            {
                sb.Append(";--fa-primary-color: ").Append(iicon.PrimaryColor);
            }

            if (iicon.SecondaryOpacity.HasValue)
            {
                sb.Append(";--fa-secondary-opacity: ").AppendFormat(
                    CultureInfo.InvariantCulture, "{0:F2}", iicon.SecondaryOpacity
                );
            }

            if (iicon.SecondaryColor != null)
            {
                sb.Append(";--fa-secondary-color: ").Append(iicon.SecondaryColor);
            }


            if (iicon.Pull != IconPull.None)
            {
                if (iicon.PullMargin != null)
                {
                    sb.Append(";--fa-pull-margin: ").Append(iicon.PullMargin);
                }
            }

            if (!string.IsNullOrWhiteSpace(iicon.StackZIndex))
            {
                sb.Append(";--fa-stack-z-index: ").Append(iicon.StackZIndex);
            }

            if (!string.IsNullOrWhiteSpace(iicon.InverseColor ))
            {
                sb.Append(";--fa-inverse: ").Append(iicon.InverseColor);
            }

            if (iicon.RotateBy != null)
            {
                sb.Append(";--fa-rotate-angle: ").Append(iicon.RotateBy);
            }
        }

        if (icon is IAnimationIcon animationIcon)
        {
            if (animationIcon.AnimationDelay != null)
            {
                sb.Append(";--fa-animation-delay: ").Append(animationIcon.AnimationDelay);
            }

            if (animationIcon.AnimationDirection != null)
            {
                sb.Append(";--fa-animation-direction: ").Append(animationIcon.AnimationDirection);
            }

            if (animationIcon.AnimationDuration != null)
            {
                sb.Append(";--fa-animation-duration: ").Append(animationIcon.AnimationDuration);
            }

            if (animationIcon.AnimationIterationCount != null)
            {
                sb.Append(";--fa-animation-iteration-count: ").Append(animationIcon.AnimationIterationCount);
            }

            if (animationIcon.AnimationTiming != null)
            {
                sb.Append(";--fa-animation-timing: ").Append(animationIcon.AnimationTiming);
            }

            if (( animationIcon.Animation & IconAnimation.Beat ) == IconAnimation.Beat && animationIcon.BeatScale.HasValue)
            {
                sb.Append(";--fa-beat-scale: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.BeatScale);
            }

            if (( animationIcon.Animation & IconAnimation.Fade ) == IconAnimation.Fade && animationIcon.FadeOpacity.HasValue)
            {
                sb.Append(";--fa-fade-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.FadeOpacity);
            }

            if (( animationIcon.Animation & IconAnimation.BeatFade ) == IconAnimation.BeatFade)
            {
                if (animationIcon.BeatFadeOpacity.HasValue)
                {
                    sb.Append(";--fa-beat-fade-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.BeatFadeOpacity);
                }

                if (animationIcon.BeatFadeScale.HasValue)
                {
                    sb.Append(";--fa-beat-fade-scale: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.BeatFadeScale);
                }
            }

            if (( animationIcon.Animation & IconAnimation.Flip ) == IconAnimation.Flip)
            {
                if (animationIcon.FlipX.HasValue)
                {
                    sb.Append(";--fa-flip-x: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.FlipX);
                }

                if (( animationIcon.Animation & IconAnimation.Flip ) == IconAnimation.Flip && animationIcon.FlipY.HasValue)
                {
                    sb.Append(";--fa-flip-y: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.FlipY);
                }

                if (( animationIcon.Animation & IconAnimation.Flip ) == IconAnimation.Flip && animationIcon.FlipZ.HasValue)
                {
                    sb.Append(";--fa-flip-z: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.FlipZ);
                }

                if (( animationIcon.Animation & IconAnimation.Flip ) == IconAnimation.Flip && animationIcon.FlipAngle != null)
                {
                    sb.Append(";--fa-flip-angle: ").Append(animationIcon.FlipAngle);
                }
            }

            if (( animationIcon.Animation & IconAnimation.Bounce ) == IconAnimation.Bounce)
            {
                if (animationIcon.BounceRebound.HasValue)
                {
                    sb.Append(";--fa-bounce-rebound: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.BounceRebound);
                }

                if (animationIcon.BounceHeight.HasValue)
                {
                    sb.Append(";--fa-bounce-height: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.BounceHeight);
                }

                if (animationIcon.BounceStartScaleX.HasValue)
                {
                    sb.Append(";--fa-bounce-start-scale-x").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.BounceStartScaleX);
                }

                if (animationIcon.BounceStartScaleY.HasValue)
                {
                    sb.Append(";--fa-bounce-start-scale-y").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.BounceStartScaleY);
                }

                if (animationIcon.BounceJumpScaleX.HasValue)
                {
                    sb.Append(";--fa-bounce-jump-scale-x").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.BounceJumpScaleX);
                }

                if (animationIcon.BounceJumpScaleY.HasValue)
                {
                    sb.Append(";--fa-bounce-jump-scale-y").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.BounceJumpScaleY);
                }

                if (animationIcon.BounceLandScaleX.HasValue)
                {
                    sb.Append(";--fa-bounce-land-scale-x").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.BounceLandScaleX);
                }

                if (animationIcon.BounceLandScaleY.HasValue)
                {
                    sb.Append(";--fa-bounce-land-scale-y").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", animationIcon.BounceLandScaleY);
                }
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

    public static void ApplyClass(this ISharedIcon icon, StringBuilder sb, bool stack = false, string? @class = null)
    {
        if (icon is IIcon iicon)
        {
            sb.Append(Icon.ToPrefix(iicon.Family, iicon.Style));
            sb.Append(' ');
            ApplyName(sb, iicon.Name);

            if (iicon.Inverse)
            {
                sb.Append(" fa-inverse");
            }

            if (iicon.Pull != IconPull.None)
            {
                sb.Append(' ');
                sb.Append(Icon.ToString(iicon.Pull));
            }

            if (iicon.SwapOpacity)
            {
                sb.Append(" fa-swap-opacity");
            }

            if (iicon.RotateBy != null)
            {
                sb.Append(" fa-rotate-by");
            }
        }

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

        if (icon is IAnimationIcon animationIcon)
        {
            if (animationIcon.Animation != IconAnimation.None)
            {
                sb.Append(Icon.ToString(animationIcon.Animation));
            }
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
        sb.Append(Icon.ToPrefix(icon.Mask.Family, icon.Mask.Style));
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
