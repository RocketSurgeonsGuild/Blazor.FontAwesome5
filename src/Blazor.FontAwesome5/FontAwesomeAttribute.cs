namespace Rocket.Surgery.Blazor.FontAwesome5;

[AttributeUsage(AttributeTargets.Field)]
public class FontAwesomeAttribute : Attribute
{
    public IconStyle IconStyle { get; }
    public string Name { get; }

    public FontAwesomeAttribute(IconStyle iconStyle, string name)
    {
        IconStyle = iconStyle;
        Name = name;
    }
}
