﻿using System;
using System.Collections.Generic;
using TextComposerLib.Diagrams.SVG.Attributes;
using TextComposerLib.Diagrams.SVG.Elements.Categories;
using TextComposerLib.Diagrams.SVG.Transforms;
using TextComposerLib.Diagrams.SVG.Values;

namespace TextComposerLib.Diagrams.SVG.Elements.Shape
{
    public sealed class SvgElementPolygon : SvgElement, ISvgBasicShapeElement
    {
        public static SvgElementPolygon Create()
        {
            return new SvgElementPolygon();
        }

        public static SvgElementPolygon Create(string id)
        {
            return new SvgElementPolygon() { Id = id };
        }


        public override string ElementName => "polygon";


        //public SvgEavString<SvgElementPolygon> Id
        //{
        //    get
        //    {
        //        var attrInfo = SvgAttributes.Id;

        //        ISvgAttributeValue attrValue;
        //        if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
        //            return attrValue as SvgEavString<SvgElementPolygon>;

        //        var attrValue1 = new SvgEavString<SvgElementPolygon>(this, attrInfo);
        //        AttributesTable.Add(attrInfo.Id, attrValue1);

        //        return attrValue1;
        //    }
        //}

        public SvgEavString<SvgElementPolygon> XmlBase
        {
            get
            {
                var attrInfo = SvgAttributeUtils.XmlBase;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEavString<SvgElementPolygon>;

                var attrValue1 = new SvgEavString<SvgElementPolygon>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }

        public SvgEavString<SvgElementPolygon> XmlLanguage
        {
            get
            {
                var attrInfo = SvgAttributeUtils.XmlLanguage;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEavString<SvgElementPolygon>;

                var attrValue1 = new SvgEavString<SvgElementPolygon>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }

        public SvgEavStruct<bool, SvgElementPolygon> ExternalResourcesRequired
        {
            get
            {
                var attrInfo = SvgAttributeUtils.ExternalResourcesRequired;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEavStruct<bool, SvgElementPolygon>;

                var attrValue1 = new SvgEavStruct<bool, SvgElementPolygon>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }

        public SvgEavString<SvgElementPolygon> Class
        {
            get
            {
                var attrInfo = SvgAttributeUtils.Class;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEavString<SvgElementPolygon>;

                var attrValue1 = new SvgEavString<SvgElementPolygon>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }

        //public SvgEavStyle<SvgElementPolygon> Style
        //{
        //    get
        //    {
        //        var attrInfo = SvgAttributes.Style;

        //        ISvgAttributeValue attrValue;
        //        if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
        //            return attrValue as SvgEavStyle<SvgElementPolygon>;

        //        var attrValue1 = new SvgEavStyle<SvgElementPolygon>(this);
        //        AttributesTable.Add(attrInfo.Id, attrValue1);

        //        return attrValue1;
        //    }
        //}

        public SvgEav<SvgTransform, SvgElementPolygon> Transform
        {
            get
            {
                var attrInfo = SvgAttributeUtils.Transform;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEav<SvgTransform, SvgElementPolygon>;

                var attrValue1 = new SvgEav<SvgTransform, SvgElementPolygon>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }

        public SvgEav<SvgValuePointsList, SvgElementPolygon> Points
        {
            get
            {
                var attrInfo = SvgAttributeUtils.Points;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEav<SvgValuePointsList, SvgElementPolygon>;

                var attrValue1 = new SvgEav<SvgValuePointsList, SvgElementPolygon>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }


        private SvgElementPolygon()
        {
        }


        public SvgElementPolygon SetPoints(SvgValuePointsList points)
        {
            Points.SetTo(points);

            return this;
        }

        public SvgElementPolygon SetPoints(IEnumerable<Tuple<double, double>> points)
        {
            return SetPoints(SvgValuePointsList.Create(points));
        }

        public SvgElementPolygon SetPoints(SvgValueLengthUnit unit, IEnumerable<Tuple<double, double>> points)
        {
            return SetPoints(SvgValuePointsList.Create(unit, points));
        }

        public SvgElementPolygon SetPoints(params double[] points)
        {
            return SetPoints(SvgValuePointsList.Create(points));
        }

        public SvgElementPolygon SetPoints(SvgValueLengthUnit unit, params double[] points)
        {
            return SetPoints(SvgValuePointsList.Create(unit, points));
        }
    }
}