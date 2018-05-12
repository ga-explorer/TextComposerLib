using System.Collections.Generic;
using TextComposerLib.Diagrams.SVG.Attributes;
using TextComposerLib.Diagrams.SVG.Styles.Properties;

namespace TextComposerLib.Diagrams.SVG.Styles
{
    public interface ISvgStyle
    {
        IEnumerable<SvgAttributeInfo> PropertyInfos { get; }

        IEnumerable<SvgAttributeInfo> ActivePropertyInfos { get; }

        IEnumerable<SvgStylePropertyValue> ActivePropertyValues { get; }

        string ActivePropertyValuesText { get; }

        SvgStyle BaseStyle { get; }

        bool IsSubStyle { get; }
    }
}