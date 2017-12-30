﻿using System.Collections.Generic;
using TextComposerLib.Diagrams.POVRay.SDL.Values;

namespace TextComposerLib.Diagrams.POVRay.SDL.Directives
{
    public sealed class SdlForDirective : SdlDirective
    {
        public string LoopVariable { get; set; }

        public ISdlScalarValue StartValue { get; set; }

        public ISdlScalarValue EndValue { get; set; }

        public ISdlScalarValue StepValue { get; set; }

        public List<ISdlStatement> Statements { get; private set; }


        public SdlForDirective()
        {
            Statements = new List<ISdlStatement>();
        }
    }
}
