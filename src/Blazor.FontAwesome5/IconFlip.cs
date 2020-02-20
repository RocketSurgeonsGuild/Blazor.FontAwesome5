using System;

namespace Rocket.Surgery.Blazor.FontAwesome5
{
    [Flags]
    public enum IconFlip
    {
        None = 0,
        Horizontal = 0b01,
        Vertical = 0b10,
        Both = 0b11,
    }
}