namespace Rocket.Surgery.Blazor.FontAwesome6.Vector;

public static class RendererConfig
{
    /// <summary>
    /// Automatically add accessibility features like aria-hidden?
    /// </summary>
    public static bool AutoA11y { get; set; } = true;

    /// <summary>
    /// Class prefix for icons and CSS styles like fa-spin. This property was previously called familyPrefix. familyPrefix can still be used, but it may be confusing now with our Family icon styles.
    /// </summary>
    public static string CssPrefix { get; set; } = "fa";

    /// <summary>
    /// Font Awesome Classic is the default if this is NOT specified. For Sharp icons, just add sharp in the same manner!
    /// </summary>
    public static IconFamily FamilyDefault { get; set; } = IconFamily.Classic;

    /// <summary>
    /// Main CSS class for svg tags replacements. All replacements will have this class.
    /// </summary>
    public static string ReplacementClass { get; set; } = "svg-inline--fa";

    /// <summary>
    /// If an icon’s style is not set or cannot be found, the icon’s default style will be 'solid'
    /// </summary>
    public static IconStyle StyleDefault { get; set; } = IconStyle.Solid;
}
