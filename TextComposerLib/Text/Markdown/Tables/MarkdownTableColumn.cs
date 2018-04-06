using System;
using System.Collections.Generic;
using System.Linq;

namespace TextComposerLib.Text.Markdown.Tables
{
    public enum MarkdownTableColumnAlignment
    {
        Left, Center, Right
    }

    public sealed class MarkdownTableColumn : List<string>
    {
        public int ColumnIndex { get; internal set; }

        public string ColumnName { get; private set; }

        public string ColumnTitle { get; set; }

        public MarkdownTableColumnAlignment ColumnAlignment { get; set; } 
            = MarkdownTableColumnAlignment.Center;

        public int MarkdownWidth
        {
            get
            {
                var minWidth = Math.Max(5, string.IsNullOrEmpty(ColumnTitle) ? 0 : ColumnTitle.Length);

                return Math.Max(
                    this.Where(s => !string.IsNullOrEmpty(s)).Max(s => s.Length),
                    minWidth
                    );
            }
        }

        public string MarkdownTitle
            => ColumnTitle.PadRight(MarkdownWidth, ' ');

        public string MarkdownSeparator
        {
            get
            {
                if (ColumnAlignment == MarkdownTableColumnAlignment.Left)
                    return "".PadLeft(MarkdownWidth, '-');

                if (ColumnAlignment == MarkdownTableColumnAlignment.Right)
                    return ":".PadLeft(MarkdownWidth, '-');

                return ":" + ":".PadLeft(MarkdownWidth - 1, '-');
            }
        }

        public IEnumerable<string> MarkdownItems
            => this.Select(s => s.PadRight(MarkdownWidth));


        internal MarkdownTableColumn(int index, string name, string title = "")
        {
            if (string.IsNullOrEmpty(name.Trim()))
                throw new ArgumentNullException(nameof(name));

            ColumnIndex = index;
            ColumnName = name.Trim();
            ColumnTitle = title ?? "";
        }


        public string MarkdownItem(int index)
        {
            return ((index < 0 || index >= Count) ? "" : this[index]).PadRight(MarkdownWidth);
        }
    }
}
