using TextComposerLib.Diagrams.SVG.Elements;

namespace TextComposerLib.Diagrams.SVG.Compositions
{
    public interface ISvgGeometryComposer
    {
        ISvgGeometryComposerIDs ElementsIDs { get; }

        ISvgGeometryComposerStyler ElementsStyler { get; }

        SvgElement Compose(bool applyStyles);
    }
}