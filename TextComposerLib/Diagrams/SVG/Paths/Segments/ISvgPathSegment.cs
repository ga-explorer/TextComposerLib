using TextComposerLib.Diagrams.SVG.Values;

namespace TextComposerLib.Diagrams.SVG.Paths.Segments
{
    public interface ISvgPathSegment
    {
        string SegmentText(SvgValueLengthUnit unit);
    }
}