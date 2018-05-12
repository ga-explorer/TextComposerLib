﻿using System;
using System.Drawing;
using System.Text;
using TextComposerLib.Diagrams.SVG.Attributes;

namespace TextComposerLib.Diagrams.SVG.Styles.Properties
{
    public sealed class SvgSpvColor : SvgStylePropertyValue
    {
        private Color _colorValue;
        public Color ColorValue
        {
            get { return _colorValue; }
            set
            {
                _colorValue = value;
                IsValueComputed = true;
            }
        }

        private string _iccColorValue;
        public string IccColorValue
        {
            get { return _iccColorValue; }
            set
            {
                _iccColorValue = value ?? string.Empty;
                IsValueComputed = true;
            }
        }


        protected override string ValueComputedText 
            => new StringBuilder()
                .Append(ColorValue.ToSvgColorHexText())
                .Append(IccColorValue)
                .ToString();


        internal SvgSpvColor(SvgStyle parentElement, SvgAttributeInfo attributeInfo)
            : base(parentElement, attributeInfo)
        {
        }


        public override SvgStylePropertyValue CreateCopy()
        {
            var result = new SvgSpvColor(ParentStyle, AttributeInfo);

            if (IsValueStored)
            {
                result._colorValue = _colorValue;
                result._iccColorValue = _iccColorValue;
                result.ValueStoredText = ValueStoredText;

                return result;
            }

            result.ColorValue = ColorValue;
            result.IccColorValue = IccColorValue;

            return result;
        }

        public override SvgStylePropertyValue UpdateFrom(SvgStylePropertyValue sourcePropertyValue)
        {
            var source = sourcePropertyValue as SvgSpvColor;

            if (ReferenceEquals(source, null) || source.IsValueStored)
            {
                ValueStoredText = source?.ValueStoredText;

                return this;
            }

            ColorValue = source.ColorValue;
            IccColorValue = source.IccColorValue;

            return this;
        }

        public SvgStyle SetToCurrentColor()
        {
            ValueStoredText = "currentColor";

            return ParentStyle;
        }

        public SvgStyle SetToRgb(Color colorValue)
        {
            ColorValue = colorValue;

            return ParentStyle;
        }

        public SvgStyle SetToRgbPercent(double red, double green, double blue)
        {
            ColorValue = Color.FromArgb(
                (int)Math.Round(red * 255),
                (int)Math.Round(green * 255),
                (int)Math.Round(blue * 255)
            );

            return ParentStyle;
        }

        public SvgStyle SetToRgb(int red, int green, int blue)
        {
            ColorValue = Color.FromArgb(
                red, green, blue
            );

            return ParentStyle;
        }
    }
}