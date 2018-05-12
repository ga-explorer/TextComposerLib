﻿using TextComposerLib.Diagrams.SVG.Attributes;
using TextComposerLib.Diagrams.SVG.Elements.Categories;
using TextComposerLib.Diagrams.SVG.Values;

namespace TextComposerLib.Diagrams.SVG.Elements.Animation
{
    public sealed class SvgElementAnimateMotion : SvgElement, ISvgAnimationElement
    {
        public static SvgElementAnimateMotion Create()
        {
            return new SvgElementAnimateMotion();
        }

        public static SvgElementAnimateMotion Create(string id)
        {
            return new SvgElementAnimateMotion() { Id = id };
        }


        public override string ElementName => "animateMotion";


        //public SvgEavString<SvgElementAnimateMotion> Id
        //{
        //    get
        //    {
        //        var attrInfo = SvgAttributes.Id;

        //        ISvgAttributeValue attrValue;
        //        if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
        //            return attrValue as SvgEavString<SvgElementAnimateMotion>;

        //        var attrValue1 = new SvgEavString<SvgElementAnimateMotion>(this, attrInfo);
        //        AttributesTable.Add(attrInfo.Id, attrValue1);

        //        return attrValue1;
        //    }
        //}

        public SvgEavString<SvgElementAnimateMotion> XmlBase
        {
            get
            {
                var attrInfo = SvgAttributeUtils.XmlBase;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEavString<SvgElementAnimateMotion>;

                var attrValue1 = new SvgEavString<SvgElementAnimateMotion>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }

        public SvgEavString<SvgElementAnimateMotion> XmlLanguage
        {
            get
            {
                var attrInfo = SvgAttributeUtils.XmlLanguage;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEavString<SvgElementAnimateMotion>;

                var attrValue1 = new SvgEavString<SvgElementAnimateMotion>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }

        public SvgEavStruct<bool, SvgElementAnimateMotion> ExternalResourcesRequired
        {
            get
            {
                var attrInfo = SvgAttributeUtils.ExternalResourcesRequired;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEavStruct<bool, SvgElementAnimateMotion>;

                var attrValue1 = new SvgEavStruct<bool, SvgElementAnimateMotion>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }

        public SvgEavString<SvgElementAnimateMotion> From
        {
            get
            {
                var attrInfo = SvgAttributeUtils.From;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEavString<SvgElementAnimateMotion>;

                var attrValue1 = new SvgEavString<SvgElementAnimateMotion>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }

        public SvgEav<SvgValueAnimationCalcMode, SvgElementAnimateMotion> CalcMode
        {
            get
            {
                var attrInfo = SvgAttributeUtils.CalcMode;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEav<SvgValueAnimationCalcMode, SvgElementAnimateMotion>;

                var attrValue1 = new SvgEav<SvgValueAnimationCalcMode, SvgElementAnimateMotion>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }

        public SvgEav<SvgValueLengthsList, SvgElementAnimateMotion> KeyTimes
        {
            get
            {
                var attrInfo = SvgAttributeUtils.KeyTimes;

                ISvgAttributeValue attrValue;
                if (AttributesTable.TryGetValue(attrInfo.Id, out attrValue))
                    return attrValue as SvgEav<SvgValueLengthsList, SvgElementAnimateMotion>;

                var attrValue1 = new SvgEav<SvgValueLengthsList, SvgElementAnimateMotion>(this, attrInfo);
                AttributesTable.Add(attrInfo.Id, attrValue1);

                return attrValue1;
            }
        }


        private SvgElementAnimateMotion()
        {
        }
    }
}