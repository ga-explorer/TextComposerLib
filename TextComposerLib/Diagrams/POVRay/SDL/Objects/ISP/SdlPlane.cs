﻿using TextComposerLib.Diagrams.POVRay.SDL.Values;

namespace TextComposerLib.Diagrams.POVRay.SDL.Objects.ISP
{
    public class SdlPlane : SdlObject, ISdlIspObject
    {
        public ISdlVectorValue Normal { get; set; }

        public ISdlScalarValue Distance { get; set; }
    }
}
