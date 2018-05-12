using System;
using System.Drawing;
using System.Text;
using TextComposerLib.Diagrams.SVG.Values;

namespace TextComposerLib.Diagrams.SVG
{
    public static class SvgComposerUtils
    {
        public static string ToSvgNumberText(this double numberValue, bool isPercent = false)
        {
            var numberText = Math.Abs(numberValue % 1) <= 0
                ? numberValue.ToString("#########0")
                : numberValue.ToString("G");

            return isPercent ? numberText + "%" : numberText;
        }

        public static string ToSvgLengthText(this double lengthValue, SvgValueLengthUnit unit)
        {
            return new StringBuilder(32)
                .Append(lengthValue.ToSvgNumberText())
                .Append(unit?.ValueText ?? string.Empty)
                .ToString();
        }

        public static string ToSvgAngleText(this double angleValue, SvgValueAngleUnit unit)
        {
            return new StringBuilder(32)
                .Append(angleValue.ToSvgNumberText())
                .Append(unit?.ValueText ?? string.Empty)
                .ToString();
        }


        public static string ToSvgColorHexText(this Color c)
        {
            return new StringBuilder()
                .Append("#")
                .Append(c.R.ToString("x2"))
                .Append(c.G.ToString("x2"))
                .Append(c.B.ToString("x2"))
                .ToString();
        }

        public static string ToSvgColorHexText(byte r, byte g, byte b)
        {
            return new StringBuilder()
                .Append("#")
                .Append(r.ToString("x2"))
                .Append(g.ToString("x2"))
                .Append(b.ToString("x2"))
                .ToString();
        }

        public static string ToSvgColorRgbText(this Color c)
        {
            return new StringBuilder()
                .Append("rgb(")
                .Append(c.R)
                .Append(",")
                .Append(c.G)
                .Append(",")
                .Append(c.B)
                .Append(")")
                .ToString();
        }

        public static string ToSvgColorRgbText(byte r, byte g, byte b)
        {
            return new StringBuilder()
                .Append("rgb(")
                .Append(r)
                .Append(",")
                .Append(g)
                .Append(",")
                .Append(b)
                .Append(")")
                .ToString();
        }

        public static string ToSvgColorRgbText(double r, double g, double b)
        {
            if (r < 0 || r > 1 || g < 0 || g > 1 || b < 0 || b > 1)
                throw new ArgumentOutOfRangeException();

            return new StringBuilder()
                .Append("rgb(")
                .Append((r * 100).ToSvgNumberText())
                .Append("%, ")
                .Append((g * 100).ToSvgNumberText())
                .Append("%, ")
                .Append((b * 100).ToSvgNumberText())
                .Append("%)")
                .ToString();
        }
    }
}
