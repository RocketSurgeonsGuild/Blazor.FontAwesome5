using System;

namespace Rocket.Surgery.Blazor.FontAwesome5 {
    [AttributeUsage(AttributeTargets.Enum)]
    public class FontAwesomeIconNameAttribute : Attribute
    {
        public string Name { get; }

        public FontAwesomeIconNameAttribute(string name)
        {
            Name = name;
        }
    }
}