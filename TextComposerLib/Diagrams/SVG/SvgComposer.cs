using TextComposerLib.Diagrams.SVG.Elements;
using TextComposerLib.Text.Linear;

namespace TextComposerLib.Diagrams.SVG
{
    public sealed class SvgComposer
    {
        private readonly LinearComposer _textComposer 
            = new LinearComposer();


        public SvgComposer Clear()
        {
            _textComposer.Clear();

            return this;
        }


        public SvgComposer AppendTag(SvgElement element)
        {
            _textComposer
                .AppendAtNewLine(element.TagText);

            return this;
        }

        public SvgComposer AppendTagBegin(SvgElement element)
        {
            _textComposer
                .AppendLineAtNewLine(element.BeginTagText)
                .IncreaseIndentation();

            return this;
        }

        public SvgComposer AppendTagBeginEnd(SvgElement element)
        {
            _textComposer
                .AppendLineAtNewLine(element.BeginEndTagText);

            return this;
        }

        public SvgComposer AppendTagEnd(SvgElement element)
        {
            _textComposer
                .DecreaseIndentation()
                .AppendLineAtNewLine(element.EndTagText);

            return this;
        }

        public SvgComposer AppendTagBegin(string elementName)
        {
            _textComposer
                .AppendAtNewLine("<")
                .Append(elementName)
                .AppendLine(">")
                .IncreaseIndentation();

            return this;
        }

        public SvgComposer AppendTagBeginEnd(string elementName)
        {
            _textComposer
                .AppendAtNewLine("<")
                .Append(elementName)
                .AppendLine("/>");

            return this;
        }

        public SvgComposer AppendTagEnd(string elementName)
        {
            _textComposer
                .DecreaseIndentation()
                .AppendAtNewLine("</")
                .Append(elementName)
                .AppendLine(">");

            return this;
        }


        public SvgComposer AppendSvgFileHeader()
        {
            _textComposer
                .AppendLine("<?xml version=\"1.0\"?>")
                .AppendLine("<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\" \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">")
                .AppendLine();

            return this;
        }
        

        //TODO: Complete this
        public SvgComposer RenderToPng(string filePath)
        {
            //You could use inkScape for this:
            //http://harriyott.com/2008/05/converting-svg-images-to-png-in-c

            /*
             public void ProcessRequest(HttpContext context)
            {
             context.Response.ContentType = "image/png";
             
             String svgXml = GetSvgImageXml(context);
             string svgFileName = GetSvgFileName(context);
             using (StreamWriter writer = new StreamWriter(svgFileName, false))
             {
              writer.Write(svgXml);
             }

             string pngFileName = GetPngFileName(context);

             string inkscapeArgs = 
              "-f " + svgFileName + " -e \"" +
              context.Server.MapPath(PngRelativeDirectory) + "\\" +
              pngFileName + "\"";

             Process inkscape = Process.Start(
               new ProcessStartInfo(
                "C:\\program files\\inkscape\\inkscape.exe",
                inkscapeArgs));
             inkscape.WaitForExit(3000);
             context.Server.Transfer(PngRelativeDirectory + pngFileName);
            }
            */

            return this;
        }

        public override string ToString()
        {
            return _textComposer.ToString();
        }
    }
}
