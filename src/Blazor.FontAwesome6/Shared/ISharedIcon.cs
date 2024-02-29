namespace Rocket.Surgery.Blazor.FontAwesome6;

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
