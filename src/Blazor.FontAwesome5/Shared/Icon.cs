using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace Rocket.Surgery.Blazor.FontAwesome5.Shared
{
    [DebuggerDisplay("{Style} {Name}")]
    public class Icon
    {
        public Icon(Style style, string name)
        {
            Style = style;
            Name = name;
            _size = IconSize.Normal;
            _fixedWidth = false;
            _spin = false;
            _pulse = false;
            _pull = IconPull.None;
            _border = false;
            _inverse = false;
            _scale = 0;
            _horizontal = 0;
            _vertical = 0;
            _rotate = 0;
            _flip = IconFlip.None;
            _mask = default;
        }

        private Icon(
            Style style,
            string name,
            IconSize iconSize,
            bool fixedWidth,
            bool spin,
            bool pulse,
            IconPull pull,
            bool border,
            bool inverse,
            double scale,
            double horizontal,
            double vertical,
            double rotate,
            IconFlip flip,
            Icon? mask,
            string? cssClass,
            string? cssStyle)
        {
            Style = style;
            Name = name;
            _size = iconSize;
            _fixedWidth = fixedWidth;
            _spin = spin;
            _pulse = pulse;
            _pull = pull;
            _border = border;
            _inverse = inverse;
            _scale = scale;
            _horizontal = horizontal;
            _vertical = vertical;
            _rotate = rotate;
            _flip = flip;
            _mask = mask;
            _cssClass = cssClass;
            _cssStyle = cssStyle;
        }

        public Style Style { get; }
        public string Name { get; }
        internal readonly IconSize _size;
        internal readonly string _cssStyle;
        internal readonly string _cssClass;
        internal readonly bool _fixedWidth;
        internal readonly bool _spin;
        internal readonly bool _pulse;
        internal readonly IconPull _pull;
        internal readonly bool _border;

        internal readonly bool _inverse;

        // private readonly bool IsInStack;
        internal readonly double _scale;
        internal readonly double _horizontal;
        internal readonly double _vertical;
        internal readonly double _rotate;
        internal readonly IconFlip _flip;
        internal readonly Icon _mask;

        public static string ToPrefix(Style style) =>
            style switch
            {
                Style.Solid => "fas",
                Style.Regular => "far",
                Style.Light => "fal",
                Style.Duotone => "fad",
                Style.Brands => "fab",
                _ => throw new NotSupportedException()
            };

        public Icon Size(IconSize size) => new Icon(Style, Name, size, _fixedWidth, _spin, _pulse, _pull, _border,
            _inverse, _scale, _horizontal, _vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon FixedWidth(bool fixedWith = true) => new Icon(Style, Name, _size, fixedWith, _spin, _pulse, _pull,
            _border, _inverse, _scale, _horizontal, _vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon Spin(bool spin = true) => new Icon(Style, Name, _size, _fixedWidth, spin, _pulse, _pull, _border,
            _inverse, _scale, _horizontal, _vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon Pulse(bool pulse = true) => new Icon(Style, Name, _size, _fixedWidth, _spin, pulse, _pull, _border,
            _inverse, _scale, _horizontal, _vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon Pull(IconPull pull = IconPull.Left) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse,
            pull, _border, _inverse, _scale, _horizontal, _vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon Border(bool border = true) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull,
            border,
            _inverse, _scale, _horizontal, _vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon Inverse(bool inverse = true) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull,
            _border, inverse, _scale, _horizontal, _vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon Scale(double scale = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull, _border,
            _inverse, scale, _horizontal, _vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon Grow(double scale = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull, _border,
            _inverse, scale + Math.Abs(scale), _horizontal, _vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon Shrink(double scale = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull, _border,
            _inverse, scale - Math.Abs(scale), _horizontal, _vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon Horizontal(double horizontal = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull,
            _border, _inverse, _scale, horizontal, _vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon Left(double left = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull,
            _border, _inverse, _scale, _horizontal, _horizontal - Math.Abs(left), _rotate, _flip, _mask, _cssClass,
            _cssStyle);

        public Icon Right(double right = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull,
            _border, _inverse, _scale, _horizontal, _horizontal + Math.Abs(right), _rotate, _flip, _mask, _cssClass,
            _cssStyle);

        public Icon Vertical(double vertical = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull,
            _border, _inverse, _scale, _horizontal, vertical, _rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon Up(double up = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull,
            _border, _inverse, _scale, _vertical + Math.Abs(up), _vertical, _rotate, _flip, _mask, _cssClass,
            _cssStyle);

        public Icon Down(double down = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull,
            _border, _inverse, _scale, _vertical - Math.Abs(down), _vertical, _rotate, _flip, _mask, _cssClass,
            _cssStyle);

        public Icon Rotate(IconRotate rotate) =>
            rotate switch
            {
                IconRotate._0Deg => Rotate(),
                IconRotate._90Deg => Rotate(90),
                IconRotate._180Deg => Rotate(180),
                IconRotate._270Deg => Rotate(270),
                _ => throw new NotSupportedException(),
            };

        public Icon Rotate(double rotate = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull,
            _border,
            _inverse, _scale, _horizontal, _vertical, rotate, _flip, _mask, _cssClass, _cssStyle);

        public Icon RotateRight(double rotate = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull,
            _border,
            _inverse, _scale, _horizontal, _vertical, _rotate + Math.Abs(rotate), _flip, _mask, _cssClass, _cssStyle);

        public Icon RotateLeft(double rotate = 0) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse, _pull,
            _border,
            _inverse, _scale, _horizontal, _vertical, _rotate - Math.Abs(rotate), _flip, _mask, _cssClass, _cssStyle);

        public Icon Flip(IconFlip flip = IconFlip.None) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse,
            _pull, _border, _inverse, _scale, _horizontal, _vertical, _rotate, flip, _mask, _cssClass, _cssStyle);

        public Icon Mask(Icon? mask) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse,
            _pull, _border, _inverse, _scale, _horizontal, _vertical, _rotate, _flip, mask, _cssClass, _cssStyle);

        public Icon CssClass(string? cssClass) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse,
            _pull, _border, _inverse, _scale, _horizontal, _vertical, _rotate, _flip, _mask, cssClass, _cssStyle);

        public Icon CssStyle(string? cssStyle) => new Icon(Style, Name, _size, _fixedWidth, _spin, _pulse,
            _pull, _border, _inverse, _scale, _horizontal, _vertical, _rotate, _flip, _mask, _cssClass, cssStyle);

        public static string ToString(IconSize size, bool stack = false) => (size, stack) switch
        {
            (IconSize.ExtraSmall, true) => "fa-stack-xs",
            (IconSize.ExtraSmall, false) => "fa-xs",
            (IconSize.Small, true) => "fa-stack-sm",
            (IconSize.Small, false) => "fa-sm",
            (IconSize.Large, true) => "fa-stack-lg",
            (IconSize.Large, false) => "fa-lg",
            (IconSize._2X, true) => "fa-stack-2x",
            (IconSize._2X, false) => "fa-2x",
            (IconSize._3X, true) => "fa-stack-3x",
            (IconSize._3X, false) => "fa-3x",
            (IconSize._4X, true) => "fa-stack-4x",
            (IconSize._4X, false) => "fa-4x",
            (IconSize._5X, true) => "fa-stack-5x",
            (IconSize._5X, false) => "fa-5x",
            (IconSize._6X, true) => "fa-stack-6x",
            (IconSize._6X, false) => "fa-6x",
            (IconSize._7X, true) => "fa-stack-7x",
            (IconSize._7X, false) => "fa-7x",
            (IconSize._8X, true) => "fa-stack-8x",
            (IconSize._8X, false) => "fa-8x",
            (IconSize._9X, true) => "fa-stack-9x",
            (IconSize._9X, false) => "fa-9x",
            (IconSize._10X, true) => "fa-stack-10x",
            (IconSize._10X, false) => "fa-10x",
            (_, true) => "fa-stack-1x",
            (_, false) => "",
        };

        public static string ToString(IconPull pull) => pull switch
        {
            IconPull.Left => "fa-pull-left",
            IconPull.Right => "fa-pull-right",
            _ => throw new NotImplementedException()
        };

        public static string ToString(IconFlip flip)
        {
            if (( flip ) == IconFlip.Both)
            {
                return "flip-h flip-v";
            }

            if (( flip & IconFlip.Horizontal ) == IconFlip.Horizontal)
            {
                return "flip-h";
            }

            if (( flip & IconFlip.Vertical ) == IconFlip.Vertical)
            {
                return "flip-v";
            }

            return "";
        }

        public Dictionary<string, object> GetAttributes()
        {
            var data = new Dictionary<string, object>();

            if (string.IsNullOrWhiteSpace(_cssStyle))
            {
                data.Add("style", _cssStyle);
            }

            if (_mask != null)
            {
                data.Add("data-fa-mask", $"{ToPrefix(_mask.Style)} fa-{_mask.Name}");
            }

            var transform = new List<string>();

            if (_scale > 0.001)
            {
                transform.Add($"grow-{Math.Abs(_scale):F2}");
            }

            if (_scale > 0.001)
            {
                transform.Add($"shrink-{Math.Abs(_scale):F2}");
            }

            if (Math.Abs(_rotate) < 0.001)
            {
                transform.Add($"rotate-{_rotate:F2}");
            }

            if (_vertical > 0.001)
            {
                transform.Add($"up-{_vertical:F2}");
            }

            if (_vertical < -0.001)
            {
                transform.Add($"down-{Math.Abs(_vertical):F2}");
            }

            if (_horizontal < -0.001)
            {
                transform.Add($"left-{Math.Abs(_horizontal):F2}");
            }

            if (_horizontal > 0.001)
            {
                transform.Add($"right-{_horizontal:F2}");
            }

            if (_flip != IconFlip.None)
            {
                transform.Add(ToString(_flip));
            }

            if (transform.Any())
            {
                data.Add("data-fa-transform", string.Join(" ", transform));
            }

            return data;
        }

        public string ToClass()
        {
            var values = new List<string>() { ToPrefix(Style), $"fa-{Name}", };

            if (!string.IsNullOrWhiteSpace(_cssClass))
            {
                values.Add(_cssClass);
            }

            if (_size != IconSize.Normal)
            {
                var size = ToString(_size);
                values.Add(size);
            }

            if (_fixedWidth) values.Add("fa-fw");
            if (_border) values.Add("fa-border");
            if (_inverse) values.Add("fa-inverse");
            if (_spin) values.Add("fa-spinner");
            else if (_pulse) values.Add("fa-pulse");

            if (_pull != IconPull.None)
            {
                values.Add(ToString(_pull));
            }

            return string.Join(" ", values);
        }

        public MarkupString ToMarkup() => (MarkupString)ToString();

        public string ToIcon() =>
            $"<i class=\"{ToClass()}\" {string.Join(" ", GetAttributes().Select(z => $"{z.Key}=\"{z.Value}\""))}></i>";
    }
}