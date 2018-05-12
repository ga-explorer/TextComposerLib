﻿using TextComposerLib.Text.Linear;

namespace TextComposerLib.Diagrams.SVG.Content
{
    public sealed class SvgContentComment : ISvgContent
    {
        public static SvgContentComment Create(string commentText)
        {
            return new SvgContentComment(commentText);
        }


        public bool IsContentText => false;

        public bool IsContentComment => true;

        public bool IsContentElement => false;

        private string _commentText;
        public string CommentText
        {
            get { return _commentText; }
            set { _commentText = value ?? string.Empty; }
        }

        private SvgContentComment(string commentText)
        {
            _commentText = commentText ?? string.Empty;
        }


        public override string ToString()
        {
            if (string.IsNullOrEmpty(CommentText))
                return "<!-- -->";

            var composer = new LinearComposer();

            return composer
                .AppendLine("<!-- ")
                .IncreaseIndentation()
                .AppendLine(CommentText)
                .DecreaseIndentation()
                .AppendAtNewLine(" -->")
                .ToString();
        }
    }
}
