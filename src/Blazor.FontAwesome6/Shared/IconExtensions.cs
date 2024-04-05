using System.Collections.Immutable;
using System.Globalization;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Rocket.Surgery.Blazor.FontAwesome6;

internal static class IconExtensions
{
    public static string ToTransform(this ITransformIcon icon, ITransformIcon? overrides)
    {
        var sb = new StringBuilder();
        ApplyTransform(icon, sb, overrides);
        return sb.ToString();
    }

    public static string ToClass(this ISharedIcon icon, ISharedIcon? overrides, bool stack = false, string? @class = null)
    {
        var sb = new StringBuilder();
        ApplyClass(icon, sb, overrides, stack, @class);
        return sb.ToString();
    }

    public static string ToStyle(this ISharedIcon icon, ISharedIcon? overrides, string? style = null)
    {
        var sb = new StringBuilder();
        ApplyStyle(icon, sb, overrides, style);
        return sb.ToString();
    }

    public static bool ApplyStyle(this ISharedIcon icon, StringBuilder sb, ISharedIcon? overrides, string? style = null, Action? changing = null)
    {
        var hasChanges = false;
        if (!string.IsNullOrWhiteSpace(style))
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(style);
        }

        if (overrides is IIcon { PrimaryOpacity: { } op2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-primary-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", op2);
        }
        else if (icon is IIcon { PrimaryOpacity: { } op and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-primary-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", op);
        }

        if (overrides is IIcon { PrimaryColor: { } pc2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-primary-color: ").Append(pc2);
        }
        else if (icon is IIcon { PrimaryColor: { } pc, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-primary-color: ").Append(pc);
        }

        if (overrides is IIcon { SecondaryOpacity: { } so2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-secondary-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", so2);
        }
        else if (icon is IIcon { SecondaryOpacity: { } so and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-secondary-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", so);
        }

        if (overrides is IIcon { SecondaryColor: { } sc2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-secondary-color: ").Append(sc2);
        }
        else if (icon is IIcon { SecondaryColor: { } sc, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-secondary-color: ").Append(sc);
        }

        if (overrides is IIcon { PullMargin: { } pm2, Pull: not IconPull.None, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-pull-margin: ").Append(pm2);
        }
        else if (icon is IIcon { PullMargin: { } pm, Pull: not IconPull.None, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-pull-margin: ").Append(pm);
        }

        if (overrides is IIcon { StackZIndex: { Length: > 0, } stackZIndex2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-stack-z-index: ").Append(stackZIndex2);
        }
        else if (icon is IIcon { StackZIndex: { Length: > 0, } stackZIndex, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-stack-z-index: ").Append(stackZIndex);
        }

        if (overrides is IIcon { InverseColor: { Length: > 0, } inverseColor2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-inverse: ").Append(inverseColor2);
        }
        else if (icon is IIcon { InverseColor: { Length: > 0, } inverseColor, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-inverse: ").Append(inverseColor);
        }

        if (overrides is IIcon { RotateBy: { } rotateBy2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-rotate-angle: ").Append(rotateBy2);
        }
        else if (icon is IIcon { RotateBy: { } rotateBy, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-rotate-angle: ").Append(rotateBy);
        }

        if (overrides is IAnimationIcon { AnimationDelay: { } animationDelay2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-animation-delay: ").Append(animationDelay2);
        }
        else if (icon is IAnimationIcon { AnimationDelay: { } animationDelay, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-animation-delay: ").Append(animationDelay);
        }

        if (overrides is IAnimationIcon { AnimationDirection: { } animationDirection2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-animation-direction: ").Append(animationDirection2);
        }
        else if (icon is IAnimationIcon { AnimationDirection: { } animationDirection, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-animation-direction: ").Append(animationDirection);
        }

        if (overrides is IAnimationIcon { AnimationDuration: { } animationDuration2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-animation-duration: ").Append(animationDuration2);
        }
        else if (icon is IAnimationIcon { AnimationDuration: { } animationDuration, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-animation-duration: ").Append(animationDuration);
        }

        if (overrides is IAnimationIcon { AnimationIterationCount: { } animationIterationCount2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-animation-iteration-count: ").Append(animationIterationCount2);
        }
        else if (icon is IAnimationIcon { AnimationIterationCount: { } animationIterationCount, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-animation-iteration-count: ").Append(animationIterationCount);
        }

        if (overrides is IAnimationIcon { AnimationTiming: { } animationTiming2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-animation-timing: ").Append(animationTiming2);
        }
        else if (icon is IAnimationIcon { AnimationTiming: { } animationTiming, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-animation-timing: ").Append(animationTiming);
        }

        if (overrides is IAnimationIcon { BeatScale: { } beatScale2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-beat-scale: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", beatScale2);
        }
        else if (icon is IAnimationIcon { BeatScale: { } beatScale and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-beat-scale: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", beatScale);
        }

        if (overrides is IAnimationIcon { FadeOpacity: { } fadeOpacity2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-fade-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", fadeOpacity2);
        }
        else if (icon is IAnimationIcon { FadeOpacity: { } fadeOpacity and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-fade-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", fadeOpacity);
        }

        if (overrides is IAnimationIcon { BeatFadeOpacity: { } beatFadeOpacity2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-beat-fade-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", beatFadeOpacity2);
        }
        else if (icon is IAnimationIcon { BeatFadeOpacity: { } beatFadeOpacity and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-beat-fade-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", beatFadeOpacity);
        }

        if (overrides is IAnimationIcon { BeatFadeScale: { } beatFadeScale2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-beat-fade-scale: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", beatFadeScale2);
        }
        else if (icon is IAnimationIcon { BeatFadeScale: { } beatFadeScale and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-beat-fade-scale: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", beatFadeScale);
        }

        if (overrides is IAnimationIcon { BounceRebound: { } bounceRebound2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-rebound: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceRebound2);
        }
        else if (icon is IAnimationIcon { BounceRebound: { } bounceRebound and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-rebound: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceRebound);
        }

        if (overrides is IAnimationIcon { BounceHeight: { } bounceHeight2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-height: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceHeight2);
        }
        else if (icon is IAnimationIcon { BounceHeight: { } bounceHeight and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-height: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceHeight);
        }

        if (overrides is IAnimationIcon { BounceStartScaleX: { } bounceStartScaleX2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-start-scale-x: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceStartScaleX2);
        }
        else if (icon is IAnimationIcon { BounceStartScaleX: { } bounceStartScaleX and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-start-scale-x: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceStartScaleX);
        }

        if (overrides is IAnimationIcon { BounceStartScaleY: { } bounceStartScaleY2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-start-scale-y: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceStartScaleY2);
        }
        else if (icon is IAnimationIcon { BounceStartScaleY: { } bounceStartScaleY and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-start-scale-y: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceStartScaleY);
        }

        if (overrides is IAnimationIcon { BounceJumpScaleX: { } bounceJumpScaleX2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-jump-scale-x: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceJumpScaleX2);
        }
        else if (icon is IAnimationIcon { BounceJumpScaleX: { } bounceJumpScaleX and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-jump-scale-x: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceJumpScaleX);
        }

        if (overrides is IAnimationIcon { BounceJumpScaleY: { } bounceJumpScaleY2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-jump-scale-y: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceJumpScaleY2);
        }
        else if (icon is IAnimationIcon { BounceJumpScaleY: { } bounceJumpScaleY and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-jump-scale-y: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceJumpScaleY);
        }

        if (overrides is IAnimationIcon { BounceLandScaleX: { } bounceLandScaleX2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-land-scale-x: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceLandScaleX2);
        }
        else if (icon is IAnimationIcon { BounceLandScaleX: { } bounceLandScaleX and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-land-scale-x: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceLandScaleX);
        }

        if (overrides is IAnimationIcon { BounceLandScaleY: { } bounceLandScaleY2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-land-scale-y: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceLandScaleY2);
        }
        else if (icon is IAnimationIcon { BounceLandScaleY: { } bounceLandScaleY and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-bounce-land-scale-y: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", bounceLandScaleY);
        }

        if (overrides is IAnimationIcon { FlipX: { } flipX2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-flip-x: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", flipX2);
        }
        else if (icon is IAnimationIcon { FlipX: { } flipX and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-flip-x: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", flipX);
        }

        if (overrides is IAnimationIcon { FlipY: { } flipY2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-flip-y: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", flipY2);
        }
        else if (icon is IAnimationIcon { FlipY: { } flipY and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-flip-y: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", flipY);
        }

        if (overrides is IAnimationIcon { FlipZ: { } flipZ2 and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-flip-z: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", flipZ2);
        }
        else if (icon is IAnimationIcon { FlipZ: { } flipZ and (> 0.001), })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-flip-z: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", flipZ);
        }

        if (overrides is IAnimationIcon { FlipAngle: { } flipAngle2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-flip-angle: ").Append(flipAngle2);
        }
        else if (icon is IAnimationIcon { FlipAngle: { } flipAngle, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-flip-angle: ").Append(flipAngle);
        }

        if (overrides is IIcon { Border: true, BorderColor: { } borderColor2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-border-color: ").Append(borderColor2);
        }
        else if (icon is IIcon { Border: true, BorderColor: { } borderColor, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-border-color: ").Append(borderColor);
        }

        if (overrides is IIcon { Border: true, BorderPadding: { } borderPadding2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-border-padding: ").Append(borderPadding2);
        }
        else if (icon is IIcon { Border: true, BorderPadding: { } borderPadding, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-border-padding: ").Append(borderPadding);
        }

        if (overrides is IIcon { Border: true, BorderRadius: { } borderRadius2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-border-radius: ").Append(borderRadius2);
        }
        else if (icon is IIcon { Border: true, BorderRadius: { } borderRadius, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-border-radius: ").Append(borderRadius);
        }

        if (overrides is IIcon { Border: true, BorderStyle: { } borderStyle2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-border-style: ").Append(borderStyle2);
        }
        else if (icon is IIcon { Border: true, BorderStyle: { } borderStyle, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-border-style: ").Append(borderStyle);
        }

        if (overrides is IIcon { Border: true, BorderWidth: { } borderWidth2, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-border-width: ").Append(borderWidth2);
        }
        else if (icon is IIcon { Border: true, BorderWidth: { } borderWidth, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(";--fa-border-width: ").Append(borderWidth);
        }

        return hasChanges;
    }

    public static ImmutableDictionary<string, string> ApplyStyle(this ISharedIcon icon, ISharedIcon? overrides)
    {
        var results = ImmutableDictionary.CreateBuilder<string, string>();

        if (overrides is IIcon { PrimaryOpacity: { } op2 and (> 0.001), })
            results.Add("--fa-primary-opacity", $"{op2:F2}");
        else if (icon is IIcon { PrimaryOpacity: { } op and (> 0.001), }) results.Add("--fa-primary-opacity", $"{op:F2}");

        if (overrides is IIcon { PrimaryColor: { } pc2, })
            results.Add("--fa-primary-color", $"{pc2}");
        else if (icon is IIcon { PrimaryColor: { } pc, }) results.Add("--fa-primary-color", $"{pc}");

        if (overrides is IIcon { SecondaryOpacity: { } so2 and (> 0.001), })
            results.Add("--fa-secondary-opacity", $"{so2:F2}");
        else if (icon is IIcon { SecondaryOpacity: { } so and (> 0.001), }) results.Add("--fa-secondary-opacity", $"{so:F2}");

        if (overrides is IIcon { SecondaryColor: { } sc2, })
            results.Add("--fa-secondary-color", $"{sc2}");
        else if (icon is IIcon { SecondaryColor: { } sc, }) results.Add("--fa-secondary-color", $"{sc}");

        if (overrides is IIcon { PullMargin: { } pm2, Pull: not IconPull.None, })
            results.Add("--fa-pull-margin", $"{pm2}");
        else if (icon is IIcon { PullMargin: { } pm, Pull: not IconPull.None, }) results.Add("--fa-pull-margin", $"{pm}");

        if (overrides is IIcon { StackZIndex: { Length: > 0, } stackZIndex2, })
            results.Add("--fa-stack-z-index", $"{stackZIndex2}");
        else if (icon is IIcon { StackZIndex: { Length: > 0, } stackZIndex, }) results.Add("--fa-stack-z-index", $"{stackZIndex}");

        if (overrides is IIcon { InverseColor: { Length: > 0, } inverseColor2, })
            results.Add("--fa-inverse", $"{inverseColor2}");
        else if (icon is IIcon { InverseColor: { Length: > 0, } inverseColor, }) results.Add("--fa-inverse", $"{inverseColor}");

        if (overrides is IIcon { RotateBy: { } rotateBy2, })
            results.Add("--fa-rotate-angle", $"{rotateBy2}");
        else if (icon is IIcon { RotateBy: { } rotateBy, }) results.Add("--fa-rotate-angle", $"{rotateBy}");

        if (overrides is IAnimationIcon { AnimationDelay: { } animationDelay2, })
            results.Add("--fa-animation-delay", $"{animationDelay2}");
        else if (icon is IAnimationIcon { AnimationDelay: { } animationDelay, }) results.Add("--fa-animation-delay", $"{animationDelay}");

        if (overrides is IAnimationIcon { AnimationDirection: { } animationDirection2, })
            results.Add("--fa-animation-direction", $"{animationDirection2}");
        else if (icon is IAnimationIcon { AnimationDirection: { } animationDirection, }) results.Add("--fa-animation-direction", $"{animationDirection}");

        if (overrides is IAnimationIcon { AnimationDuration: { } animationDuration2, })
            results.Add("--fa-animation-duration", $"{animationDuration2}");
        else if (icon is IAnimationIcon { AnimationDuration: { } animationDuration, }) results.Add("--fa-animation-duration", $"{animationDuration}");

        if (overrides is IAnimationIcon { AnimationIterationCount: { } animationIterationCount2, })
            results.Add("--fa-animation-iteration-count", $"{animationIterationCount2}");
        else if (icon is IAnimationIcon { AnimationIterationCount: { } animationIterationCount, })
            results.Add("--fa-animation-iteration-count", $"{animationIterationCount}");

        if (overrides is IAnimationIcon { AnimationTiming: { } animationTiming2, })
            results.Add("--fa-animation-timing", $"{animationTiming2}");
        else if (icon is IAnimationIcon { AnimationTiming: { } animationTiming, }) results.Add(";--fa-animation-timing", $"{animationTiming}");

        if (overrides is IAnimationIcon { BeatScale: { } beatScale2 and (> 0.001), })
            results.Add("--fa-beat-scale", $"{beatScale2:F2}");
        else if (icon is IAnimationIcon { BeatScale: { } beatScale and (> 0.001), }) results.Add("--fa-beat-scale", $"{beatScale:F2}");

        if (overrides is IAnimationIcon { FadeOpacity: { } fadeOpacity2 and (> 0.001), })
            results.Add("--fa-fade-opacity", $"{fadeOpacity2:F2}");
        else if (icon is IAnimationIcon { FadeOpacity: { } fadeOpacity and (> 0.001), }) results.Add("--fa-fade-opacity", $"{fadeOpacity:F2}");

        if (overrides is IAnimationIcon { BeatFadeOpacity: { } beatFadeOpacity2 and (> 0.001), })
            results.Add("--fa-beat-fade-opacity", $"{beatFadeOpacity2:F2}");
        else if (icon is IAnimationIcon { BeatFadeOpacity: { } beatFadeOpacity and (> 0.001), }) results.Add("--fa-beat-fade-opacity", $"{beatFadeOpacity:F2}");

        if (overrides is IAnimationIcon { BeatFadeScale: { } beatFadeScale2 and (> 0.001), })
            results.Add("--fa-beat-fade-scale", $"{beatFadeScale2:F2}");
        else if (icon is IAnimationIcon { BeatFadeScale: { } beatFadeScale and (> 0.001), }) results.Add("--fa-beat-fade-scale", $"{beatFadeScale:F2}");

        if (overrides is IAnimationIcon { BounceRebound: { } bounceRebound2 and (> 0.001), })
            results.Add("--fa-bounce-rebound", $"{bounceRebound2:F2}");
        else if (icon is IAnimationIcon { BounceRebound: { } bounceRebound and (> 0.001), }) results.Add("--fa-bounce-rebound", $"{bounceRebound:F2}");

        if (overrides is IAnimationIcon { BounceHeight: { } bounceHeight2 and (> 0.001), })
            results.Add("--fa-bounce-height", $"{bounceHeight2:F2}");
        else if (icon is IAnimationIcon { BounceHeight: { } bounceHeight and (> 0.001), }) results.Add("--fa-bounce-height", $"{bounceHeight:F2}");

        if (overrides is IAnimationIcon { BounceStartScaleX: { } bounceStartScaleX2 and (> 0.001), })
            results.Add("--fa-bounce-start-scale-x", $"{bounceStartScaleX2:F2}");
        else if (icon is IAnimationIcon { BounceStartScaleX: { } bounceStartScaleX and (> 0.001), })
            results.Add("--fa-bounce-start-scale-x", $"{bounceStartScaleX:F2}");

        if (overrides is IAnimationIcon { BounceStartScaleY: { } bounceStartScaleY2 and (> 0.001), })
            results.Add("--fa-bounce-start-scale-y", $"{bounceStartScaleY2:F2}");
        else if (icon is IAnimationIcon { BounceStartScaleY: { } bounceStartScaleY and (> 0.001), })
            results.Add("--fa-bounce-start-scale-y", $"{bounceStartScaleY:F2}");

        if (overrides is IAnimationIcon { BounceJumpScaleX: { } bounceJumpScaleX2 and (> 0.001), })
            results.Add("--fa-bounce-jump-scale-x", $"{bounceJumpScaleX2:F2}");
        else if (icon is IAnimationIcon { BounceJumpScaleX: { } bounceJumpScaleX and (> 0.001), })
            results.Add("--fa-bounce-jump-scale-x", $"{bounceJumpScaleX:F2}");

        if (overrides is IAnimationIcon { BounceJumpScaleY: { } bounceJumpScaleY2 and (> 0.001), })
            results.Add("--fa-bounce-jump-scale-y", $"{bounceJumpScaleY2:F2}");
        else if (icon is IAnimationIcon { BounceJumpScaleY: { } bounceJumpScaleY and (> 0.001), })
            results.Add("--fa-bounce-jump-scale-y", $"{bounceJumpScaleY:F2}");

        if (overrides is IAnimationIcon { BounceLandScaleX: { } bounceLandScaleX2 and (> 0.001), })
            results.Add("--fa-bounce-land-scale-x", $"{bounceLandScaleX2:F2}");
        else if (icon is IAnimationIcon { BounceLandScaleX: { } bounceLandScaleX and (> 0.001), })
            results.Add("--fa-bounce-land-scale-x", $"{bounceLandScaleX:F2}");

        if (overrides is IAnimationIcon { BounceLandScaleY: { } bounceLandScaleY2 and (> 0.001), })
            results.Add("--fa-bounce-land-scale-y", $"{bounceLandScaleY2:F2}");
        else if (icon is IAnimationIcon { BounceLandScaleY: { } bounceLandScaleY and (> 0.001), })
            results.Add("--fa-bounce-land-scale-y", $"{bounceLandScaleY:F2}");

        if (overrides is IAnimationIcon { FlipX: { } flipX2 and (> 0.001), })
            results.Add("--fa-flip-x", $"{flipX2:F2}");
        else if (icon is IAnimationIcon { FlipX: { } flipX and (> 0.001), }) results.Add("--fa-flip-x", $"{flipX:F2}");

        if (overrides is IAnimationIcon { FlipY: { } flipY2 and (> 0.001), })
            results.Add("--fa-flip-y", $"{flipY2:F2}");
        else if (icon is IAnimationIcon { FlipY: { } flipY and (> 0.001), }) results.Add("--fa-flip-y", $"{flipY:F2}");

        if (overrides is IAnimationIcon { FlipZ: { } flipZ2 and (> 0.001), })
            results.Add("--fa-flip-z", $"{flipZ2:F2}");
        else if (icon is IAnimationIcon { FlipZ: { } flipZ and (> 0.001), }) results.Add("--fa-flip-z", $"{flipZ:F2}");

        if (overrides is IAnimationIcon { FlipAngle: { } flipAngle2, })
            results.Add("--fa-flip-angle", flipAngle2);
        else if (icon is IAnimationIcon { FlipAngle: { } flipAngle, }) results.Add("--fa-flip-angle", flipAngle);

        if (overrides is IIcon { Border: true, BorderColor: { } borderColor2, })
            results.Add("--fa-border-color", borderColor2);
        else if (icon is IIcon { Border: true, BorderColor: { } borderColor, }) results.Add("--fa-border-color", borderColor);

        if (overrides is IIcon { Border: true, BorderPadding: { } borderPadding2, })
            results.Add("--fa-border-padding", borderPadding2);
        else if (icon is IIcon { Border: true, BorderPadding: { } borderPadding, }) results.Add("--fa-border-padding", borderPadding);

        if (overrides is IIcon { Border: true, BorderRadius: { } borderRadius2, })
            results.Add("--fa-border-radius", borderRadius2);
        else if (icon is IIcon { Border: true, BorderRadius: { } borderRadius, }) results.Add("--fa-border-radius", borderRadius);

        if (overrides is IIcon { Border: true, BorderStyle: { } borderStyle2, })
            results.Add("--fa-border-style", borderStyle2);
        else if (icon is IIcon { Border: true, BorderStyle: { } borderStyle, }) results.Add("--fa-border-style", borderStyle);

        if (overrides is IIcon { Border: true, BorderWidth: { } borderWidth2, })
            results.Add("--fa-border-width", borderWidth2);
        else if (icon is IIcon { Border: true, BorderWidth: { } borderWidth, }) results.Add("--fa-border-width", borderWidth);

        return results.ToImmutable();
    }

    public static bool ApplyTransform(this ITransformIcon icon, StringBuilder sb, ITransformIcon? overrides, Action? changing = null)
    {
        var hasChanges = false;

        if (overrides is { Grow: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("grow-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", overrides.Grow);
        }
        else if (icon is { Grow: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("grow-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Grow);
        }

        if (overrides is { Shrink: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("shrink-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", overrides.Shrink);
        }
        else if (icon is { Shrink: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("shrink-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Shrink);
        }

        if (overrides is { Rotate: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("rotate-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", overrides.Rotate);
        }
        else if (icon is { Rotate: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("rotate-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Rotate);
        }

        if (overrides is { Up: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("up-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", overrides.Up);
        }
        else if (icon is { Up: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("up-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Up);
        }

        if (overrides is { Down: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("down-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", overrides.Down);
        }
        else if (icon is { Down: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("down-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Down);
        }

        if (overrides is { Left: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("left-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", overrides.Left);
        }
        else if (icon is { Left: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("left-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Left);
        }

        if (overrides is { Right: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("right-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", overrides.Right);
        }
        else if (icon is { Right: < -0.001 or > 0.001, })
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append("right-").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", icon.Right);
        }

        if (overrides is { FlipTransform: { } flipTransform2, } && flipTransform2 != IconFlip.None)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(Icon.ToString(flipTransform2));
        }
        else if (icon is { FlipTransform: { } flipTransform, } && flipTransform != IconFlip.None)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(Icon.ToString(flipTransform));
        }

        return hasChanges;
    }

    public static void ApplyName(StringBuilder sb, string name)
    {
        sb.Append("fa-");
        if (string.IsNullOrWhiteSpace(name))
            // default icon
            sb.Append("bomb");
        else
            sb.Append(name);
    }

    public static ImmutableArray<string> ApplyClass(this ISharedIcon icon, ISharedIcon? overrides, bool stack = false)
    {
        var results = ImmutableArray.CreateBuilder<string>();
        if (icon is IIcon { } i)
        {
            if (overrides is IIcon { Inverse: true, } || ( overrides is null or IIcon { Inverse: null, } && i is { Inverse: true, } ))
                results.Add("fa-inverse");

            if (overrides is IIcon { Pull: not IconPull.None, } overrides2)
                results.Add(Icon.ToString(overrides2.Pull));
            else if (i is { Pull: not IconPull.None, }) results.Add(Icon.ToString(i.Pull));

            if (overrides is IIcon { SwapOpacity: true, } || ( overrides is null or IIcon { SwapOpacity: null, } && i is { SwapOpacity: true, } ))
                results.Add("fa-swap-opacity");

            if (overrides is IIcon { RotateBy: { }, } || i is { RotateBy: { }, }) results.Add("fa-rotate-by");
        }


        if (overrides is { CssClass: { Length: > 0, } cssClass2, })
            results.AddRange(cssClass2.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        else if (icon is { CssClass: { Length: > 0, } cssClass, }) results.AddRange(cssClass.Split(' ', StringSplitOptions.RemoveEmptyEntries));

        if (overrides is { FixedWidth: true, } || ( overrides is null or { FixedWidth: null, } && icon is { FixedWidth: true, } )) results.Add("fa-fw");

        if (overrides is { Border: true, } || ( overrides is null or { Border: null, } && icon is { Border: true, } )) results.Add("fa-border");

        var size = overrides is { } && overrides.Size != IconSize.Normal ? overrides.Size : icon.Size;
        results.Add(Icon.ToString(size, stack));

        if (overrides is IAnimationIcon { Animation: not IconAnimation.None, } animationIcon2 && animationIcon2.Animation != IconAnimation.None)
        {
            results.Add(Icon.ToString(animationIcon2.Animation));
        }
        else if (icon is IAnimationIcon { Animation: not IconAnimation.None, } animationIcon && animationIcon.Animation != IconAnimation.None)
        {
            results.Add(Icon.ToString(animationIcon.Animation));
        }
        else
        {
            var animation = IconAnimation.None;
            if (overrides is IAnimationComponent animationOverrides)
            {
                animation = animationOverrides switch
                            {
                                { Beat: true, }      => IconAnimation.Beat,
                                { BeatFade: true, }  => IconAnimation.BeatFade,
                                { Bounce: true, }    => IconAnimation.Bounce,
                                { Spin: true, }      => IconAnimation.Spin,
                                { Flip: true, }      => IconAnimation.Flip,
                                { Shake: true, }     => IconAnimation.Shake,
                                { SpinPulse: true, } => IconAnimation.SpinPulse,
                                { Fade: true, }      => IconAnimation.Fade,
                                _                    => animation,
                            };
                if (animationOverrides is { Reverse: true, }) animation |= IconAnimation.Reverse;
            }

            if (animation is (IconAnimation.Reverse or IconAnimation.None) && icon is IAnimationComponent iconOverrides)
            {
                animation = iconOverrides switch
                            {
                                { Beat: true, }      => IconAnimation.Beat,
                                { BeatFade: true, }  => IconAnimation.BeatFade,
                                { Bounce: true, }    => IconAnimation.Bounce,
                                { Spin: true, }      => IconAnimation.Spin,
                                { Flip: true, }      => IconAnimation.Flip,
                                { Shake: true, }     => IconAnimation.Shake,
                                { SpinPulse: true, } => IconAnimation.SpinPulse,
                                { Fade: true, }      => IconAnimation.Fade,
                                _                    => animation,
                            };
                if (iconOverrides is { Reverse: true, }) animation |= IconAnimation.Reverse;
            }

            if (animation != IconAnimation.None) results.Add(Icon.ToString(animation));
        }

        return results.ToImmutable();
    }

    public static void ApplyClass(this ISharedIcon icon, StringBuilder sb, ISharedIcon? overrides, bool stack = false, string? @class = null)
    {
        if (icon is IIcon { } i)
        {
            sb.Append(Icon.ToPrefix(i.Family, i.Style));
            sb.Append(' ');

            ApplyName(sb, i.Name);
            if (overrides is IIcon { Inverse: true, } || ( overrides is null or IIcon { Inverse: null, } && i is { Inverse: true, } )) sb.Append(" fa-inverse");

            if (overrides is IIcon { Pull: not IconPull.None, } overrides2)
            {
                sb.Append(' ');
                sb.Append(Icon.ToString(overrides2.Pull));
            }
            else if (i is { Pull: not IconPull.None, })
            {
                sb.Append(' ');
                sb.Append(Icon.ToString(i.Pull));
            }

            if (overrides is IIcon { SwapOpacity: true, } || ( overrides is null or IIcon { SwapOpacity: null, } && i is { SwapOpacity: true, } ))
                sb.Append(" fa-swap-opacity");

            if (overrides is IIcon { RotateBy: { }, } || i is { RotateBy: { }, }) sb.Append(" fa-rotate-by");
        }


        if (!string.IsNullOrWhiteSpace(@class))
        {
            sb.Append(' ');
            sb.Append(@class);
        }

        if (overrides is { CssClass: { Length: > 0, } cssClass2, })
        {
            sb.Append(' ');
            sb.Append(cssClass2);
        }
        else if (icon is { CssClass: { Length: > 0, } cssClass, })
        {
            sb.Append(' ');
            sb.Append(cssClass);
        }

        if (overrides is { FixedWidth: true, } || ( overrides is null or { FixedWidth: null, } && icon is { FixedWidth: true, } )) sb.Append(" fa-fw");

        if (overrides is { Border: true, } || ( overrides is null or { Border: null, } && icon is { Border: true, } )) sb.Append(" fa-border");

        var size = overrides is { } && overrides.Size != IconSize.Normal ? overrides.Size : icon.Size;
        sb.Append(Icon.ToString(size, stack));

        if (overrides is IAnimationIcon { Animation: not IconAnimation.None, } animationIcon2 && animationIcon2.Animation != IconAnimation.None)
        {
            sb.Append(Icon.ToString(animationIcon2.Animation));
        }
        else if (icon is IAnimationIcon { Animation: not IconAnimation.None, } animationIcon && animationIcon.Animation != IconAnimation.None)
        {
            sb.Append(Icon.ToString(animationIcon.Animation));
        }
        else
        {
            var animation = IconAnimation.None;
            if (overrides is IAnimationComponent animationOverrides)
            {
                animation = animationOverrides switch
                            {
                                { Beat: true, }      => IconAnimation.Beat,
                                { BeatFade: true, }  => IconAnimation.BeatFade,
                                { Bounce: true, }    => IconAnimation.Bounce,
                                { Spin: true, }      => IconAnimation.Spin,
                                { Flip: true, }      => IconAnimation.Flip,
                                { Shake: true, }     => IconAnimation.Shake,
                                { SpinPulse: true, } => IconAnimation.SpinPulse,
                                { Fade: true, }      => IconAnimation.Fade,
                                _                    => animation,
                            };
                if (animationOverrides is { Reverse: true, }) animation |= IconAnimation.Reverse;
            }

            if (animation is (IconAnimation.Reverse or IconAnimation.None) && icon is IAnimationComponent iconOverrides)
            {
                animation = iconOverrides switch
                            {
                                { Beat: true, }      => IconAnimation.Beat,
                                { BeatFade: true, }  => IconAnimation.BeatFade,
                                { Bounce: true, }    => IconAnimation.Bounce,
                                { Spin: true, }      => IconAnimation.Spin,
                                { Flip: true, }      => IconAnimation.Flip,
                                { Shake: true, }     => IconAnimation.Shake,
                                { SpinPulse: true, } => IconAnimation.SpinPulse,
                                { Fade: true, }      => IconAnimation.Fade,
                                _                    => animation,
                            };
                if (iconOverrides is { Reverse: true, }) animation |= IconAnimation.Reverse;
            }

            if (animation != IconAnimation.None) sb.Append(Icon.ToString(animation));
        }
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
