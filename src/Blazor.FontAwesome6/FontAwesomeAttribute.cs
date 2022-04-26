namespace Rocket.Surgery.Blazor.FontAwesome6;

[AttributeUsage(AttributeTargets.Field)]
public sealed class FontAwesomeAttribute : Attribute
{
    public IconStyle IconStyle { get; }
    public string Name { get; }

    public FontAwesomeAttribute(IconStyle iconStyle, string name)
    {
        IconStyle = iconStyle;
        Name = name;
    }
}
