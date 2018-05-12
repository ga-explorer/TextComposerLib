﻿using System.Collections.Generic;
using TextComposerLib.Diagrams.SVG.Elements.Containers;
using TextComposerLib.Text.Linear;

namespace TextComposerLib.Diagrams.SVG.Elements
{
    public static class SvgElementUtils
    {
        public static SvgElementGroup GetDescendantGroup(this SvgElement parentElement, string descendantId)
        {
            return parentElement.Contents.GetDescendantElement(descendantId, false) as SvgElementGroup;
        }

        public static Dictionary<string, SvgElement> GetElementsDictionary(this SvgElement parentElement)
        {
            var dict = new Dictionary<string, SvgElement>();

            var stack = new Stack<SvgElement>();
            stack.Push(parentElement);

            while (stack.Count > 0)
            {
                var element = stack.Pop();

                if (element.HasId)
                    dict.Add(element.Id, element);

                foreach (var childElement in element.ChildElements)
                    stack.Push(childElement);
            }

            return dict;
        }

        public static string ToText(this Dictionary<string, SvgElement> dict)
        {
            var composer = new LinearComposer();

            foreach (var pair in dict)
            {
                composer
                    .AppendLineAtNewLine(pair.Key)
                    .IncreaseIndentation()
                    .AppendLine(pair.Value)
                    .DecreaseIndentation()
                    .AppendLine();
            }

            return composer.ToString();
        }

        public static SvgElement GetSvgElement(this Dictionary<string, SvgElement> svgElementsDictionary, string id)
        {
            SvgElement element;
            return svgElementsDictionary.TryGetValue(id, out element) ? element : null;
        }
    }
}
