﻿namespace TextComposerLib.Diagrams.SVG.Attributes
{
    public interface ISvgAttributeValue
    {
        string ValueText { get; }

        SvgAttributeInfo AttributeInfo { get; }

        int AttributeId { get; }

        string AttributeName { get; }


    }
}