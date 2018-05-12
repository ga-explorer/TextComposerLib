using TextComposerLib.Diagrams.SVG.Styles.Properties;
using TextComposerLib.Diagrams.SVG.Styles.SubStyles;

namespace TextComposerLib.Diagrams.SVG.Styles
{
    public static class SvgStyleUtils
    {
        public static SvgSubStyleStroke CreateStrokeSubStyle(this SvgStyle baseStyle)
        {
            return SvgSubStyleStroke.Create(baseStyle);
        }

        public static SvgSubStyleFill CreateFillSubStyle(this SvgStyle baseStyle)
        {
            return SvgSubStyleFill.Create(baseStyle);
        }

        public static bool IsNullOrEmpty(this SvgStylePropertyValue propertyValue)
        {
            return ReferenceEquals(propertyValue, null) || 
                   propertyValue.IsValueEmpty;
        }
    }
}
