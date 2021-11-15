using System;
using System.Text;
using Rocket.Surgery.Blazor.FontAwesome5.Shared;

namespace Rocket.Surgery.Blazor.FontAwesome5;

public interface IIcon : ITransformIcon
{
    IconStyle Style { get; }
    string Name { get; }
    IconSize Size { get; }
    string CssStyle { get; }
    string CssClass { get; }
    bool FixedWidth { get; }
    bool Spin { get; }
    bool Pulse { get; }
    IconPull Pull { get; }
    bool Border { get; }
    bool Inverse { get; }
    Icon? Mask { get; }
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
    IconFlip? Flip { get; }
}

static class IconExtensions
{
    public static string ToTransform(this ITransformIcon icon)
    {
        var sb = new StringBuilder();
        ApplyTransform(icon, sb);
        return sb.ToString();
    }
        
    public static string ToClass(this IIcon icon, bool stack, string @class = null)
    {
        var sb = new StringBuilder();
        ApplyClass(icon, sb, stack, @class);
        return sb.ToString();
    }

    public static bool ApplyTransform(this ITransformIcon icon, StringBuilder sb, Action? changing = null)
    {
        var hasChanges = false;
        if (icon.Grow > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append($"grow-{icon.Grow:F2}");
        }

        if (icon.Shrink > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append($"shrink-{icon.Shrink:F2}");
        }

        if (Math.Abs(icon.Rotate) > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append($"rotate-{icon.Rotate:F2}");
        }

        if (icon.Up > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append($"up-{icon.Up:F2}");
        }

        if (icon.Down > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append($"down-{icon.Down:F2}");
        }

        if (icon.Left > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append($"left-{icon.Left:F2}");
        }

        if (icon.Right > 0.001)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append($"right-{icon.Right:F2}");
        }

        if (icon.Flip.HasValue && icon.Flip != IconFlip.None)
        {
            AddSpaceIfChanged(ref hasChanges, sb, changing);
            sb.Append(Icon.ToString(icon.Flip.Value));
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

    public static void ApplyClass(this IIcon icon, StringBuilder sb, bool stack = false, string @class = null)
    {
        sb.Append(Icon.ToPrefix(icon.Style));
        sb.Append(" ");
        ApplyName(sb, icon.Name);
        if (!string.IsNullOrWhiteSpace(@class))
        {
            sb.Append(" ");
            sb.Append(@class);
        }

        if (!string.IsNullOrWhiteSpace(icon.CssClass))
        {
            sb.Append(" ");
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

        if (icon.Spin)
        {
            sb.Append(" fa-spinner");
        }
        else if (icon.Pulse)
        {
            sb.Append(" fa-pulse");
        }

        if (icon.Pull != IconPull.None)
        {
            sb.Append(" ");
            sb.Append(Icon.ToString(icon.Pull));
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
            sb.Append(" ");
        }
        else
        {
            hasChanges = true;
            changing?.Invoke();
        }
    }
}