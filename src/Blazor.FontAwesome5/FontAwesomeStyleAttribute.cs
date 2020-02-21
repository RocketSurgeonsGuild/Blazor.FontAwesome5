using System;

namespace Rocket.Surgery.Blazor.FontAwesome5
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FontAwesomeStyleAttribute : Attribute
    {
        public IconStyle IconStyle { get; }

        public FontAwesomeStyleAttribute(IconStyle iconStyle)
        {
            IconStyle = iconStyle;
        }
    }
}