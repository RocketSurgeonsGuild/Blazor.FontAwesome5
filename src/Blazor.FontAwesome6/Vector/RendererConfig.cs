namespace Rocket.Surgery.Blazor.FontAwesome6.Vector;

public class RendererConfig
{
    /// <summary>
    /// Automatically add accessibility features like aria-hidden?
    /// </summary>
    public bool AutoA11y { get; init; } = true;

    /// <summary>
    /// Class prefix for icons and CSS styles like fa-spin. This property was previously called familyPrefix. familyPrefix can still be used, but it may be confusing now with our Family icon styles.
    /// </summary>
    public string CssPrefix { get; init; } = "fa";

    /// <summary>
    /// Font Awesome Classic is the default if this is NOT specified. For Sharp icons, just add sharp in the same manner!
    /// </summary>
    public IconFamily FamilyDefault { get; init; } = IconFamily.Classic;

    /// <summary>
    /// Main CSS class for svg tags replacements. All replacements will have this class.
    /// </summary>
    public string ReplacementClass { get; init; } = "svg-inline--fa";

    /// <summary>
    /// If an icon’s style is not set or cannot be found, the icon’s default style will be 'solid'
    /// </summary>
    public IconStyle StyleDefault { get; init; } = IconStyle.Solid;
}
