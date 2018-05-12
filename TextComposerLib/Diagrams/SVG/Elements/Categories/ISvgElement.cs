using TextComposerLib.Diagrams.SVG.Attributes;
using TextComposerLib.Diagrams.SVG.Content;

namespace TextComposerLib.Diagrams.SVG.Elements.Categories
{
    /// <summary>
    /// http://docs.w3cub.com/svg/element/
    /// </summary>
    public interface ISvgElement : ISvgContent
    {
        SvgContentsList Contents { get; }

        string ElementName { get; }

        string Id { get; }

        string ContentsText { get; }

        string AttributsText { get; }

        string BeginEndTagText { get; }

        string BeginTagText { get; }

        string EndTagText { get; }

        string TagText { get; }

        ISvgElement ClearAttributes();

        ISvgElement ClearAttribute(SvgAttributeInfo attributeInfo);

        ISvgElement ClearAttributes(params SvgAttributeInfo[] attributeInfoList);

        ISvgElement ClearDefaultAttributes(bool clearInChildren);
    }
}