using TextComposerLib.Diagrams.SVG.Elements;

namespace TextComposerLib.Diagrams.SVG.Compositions
{
    public interface ISvgGeometryComposerStyler
    {
        SvgElement ComposedElement { get; }

        ISvgGeometryComposerIDs ComposedElementsIDs { get; }

        SvgElement ApplyStyles();
    }
}