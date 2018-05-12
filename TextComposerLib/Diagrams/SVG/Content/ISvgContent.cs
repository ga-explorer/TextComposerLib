namespace TextComposerLib.Diagrams.SVG.Content
{
    public interface ISvgContent
    {
        bool IsContentText { get; }

        bool IsContentComment { get; }

        bool IsContentElement { get; }
    }
}