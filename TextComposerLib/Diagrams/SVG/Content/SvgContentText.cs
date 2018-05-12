namespace TextComposerLib.Diagrams.SVG.Content
{
    public class SvgContentText : ISvgContent
    {
        public static SvgContentText Create(string commentText)
        {
            return new SvgContentText(commentText);
        }


        public bool IsContentText => true;

        public bool IsContentComment => false;

        public bool IsContentElement => false;

        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value?.ToHtmlSafeString() ?? string.Empty; }
        }


        private SvgContentText(string value)
        {
            _value = value?.ToHtmlSafeString() ?? string.Empty;
        }


        public override string ToString()
        {
            return _value;
        }
    }
}