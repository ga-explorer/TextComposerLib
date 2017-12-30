﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TextComposerLib.Text.Parametric
{
    public class ParametricComposer
    {
        /// <summary>
        /// Generate a formatted text from the given value. If the format string is empty or null
        /// the default value.ToString() method is used
        /// </summary>
        /// <param name="value"></param>
        /// <param name="formatString"></param>
        /// <returns></returns>
        protected static string GenerateFormattedText(int value, string formatString)
        {
            return
                String.IsNullOrEmpty(formatString)
                    ? value.ToString()
                    : value.ToString(formatString);
        }

        /// <summary>
        /// Generate text from the given template text and template parameters values. The values are assigned
        /// to parameters in the order the parameter appears in the template text
        /// </summary>
        /// <param name="leftDelimiter"></param>
        /// <param name="rightDelimiter"></param>
        /// <param name="templateText"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string GenerateFrom(string leftDelimiter, string rightDelimiter, string templateText, params string[] values)
        {
            var template = new ParametricComposer(leftDelimiter, rightDelimiter, templateText);

            return template.GenerateUsing(values);
        }

        private static void GenerateParameterText(StringBuilder s, int stringLength, string parameterValue)
        {
            var valueLines = parameterValue.SplitLines();

            var linePrefixLength = s.Length - stringLength;

            s.Append(valueLines[0]);

            if (valueLines.Length == 1)
                return;

            s.AppendLine();

            if (linePrefixLength == 0)
            {
                for (var i = 1; i < valueLines.Length; i++)
                {
                    s.Append(valueLines[i]);

                    if (i < valueLines.Length - 1)
                        s.AppendLine();
                }

                return;
            }

            var linePrefix = "".PadLeft(linePrefixLength);

            for (var i = 1; i < valueLines.Length; i++)
            {
                s.Append(linePrefix);

                s.Append(valueLines[i]);

                if (i < valueLines.Length - 1)
                    s.AppendLine();
            }
        }


        /// <summary>
        /// The left delimiter for the template parameters inside the template text
        /// </summary>
        public string LeftDelimiter { get; private set; }

        /// <summary>
        /// The right delimiter for the template parameters inside the template text
        /// </summary>
        public string RightDelimiter { get; private set; }

        /// <summary>
        /// The template text
        /// </summary>
        public string TemplateText { get; private set; }

        /// <summary>
        /// The text lines of this template
        /// </summary>
        private readonly List<PcLine> _templateTextLines = new List<PcLine>();

        /// <summary>
        /// If true (the dafault) reading and writting values to parameters not defined in the template
        /// is ignored and no errors are raised
        /// </summary>
        public bool IgnoreUndefinedParameters { get; set; }

        /// <summary>
        /// If true, when a parameter value has multiple lines the second and following lines are
        /// added with leading spaces equal to the characters before the parameter placeholder
        /// up to the beginning of line
        /// </summary>
        public bool AlignMultiLineParameterValues { get; set; }

        /// <summary>
        /// The parameters information of this text template
        /// </summary>
        private readonly Dictionary<string, PcParameter> _parameters =
            new Dictionary<string, PcParameter>();


        /// <summary>
        /// A list of parameter names for this template
        /// </summary>
        public IEnumerable<string> Parameters => _parameters.Keys;

        /// <summary>
        /// Get or set the value of a parameter with the given parameter name
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public string this[string parameterName]
        {
            get
            {
                PcParameter parameter;

                if (_parameters.TryGetValue(parameterName, out parameter))
                    return ReferenceEquals(parameter, null) ? String.Empty : parameter.ParameterValue;

                if (IgnoreUndefinedParameters)
                    return String.Empty;

                throw new KeyNotFoundException("Template parameter " + parameterName + " not defined!");
            }
            set
            {
                if (!_parameters.ContainsKey(parameterName))
                {
                    if (IgnoreUndefinedParameters)
                        return;

                    throw new KeyNotFoundException("Template parameter " + parameterName + " not defined!");
                }

                _parameters[parameterName].ParameterValue =
                    ReferenceEquals(value, null)
                    ? String.Empty
                    : value;
            }
        }


        /// <summary>
        /// Create a parametric text composer with the default delimiters # # and empty template text
        /// </summary>
        public ParametricComposer()
            : this("#", "#", String.Empty)
        {
        }

        /// <summary>
        /// Create a parametric text composer with the default delimiters # #
        /// </summary>
        /// <param name="templateText"></param>
        public ParametricComposer(string templateText)
            : this("#", "#", templateText)
        {
        }

        public ParametricComposer(string leftDelimiter, string rightDelimiter)
            : this(leftDelimiter, rightDelimiter, String.Empty)
        {
        }

        public ParametricComposer(string leftDelimiter, string rightDelimiter, string templateText)
        {
            LeftDelimiter = leftDelimiter;
            RightDelimiter = rightDelimiter;
            IgnoreUndefinedParameters = true;
            AlignMultiLineParameterValues = true;

            SetTemplateText(templateText);
        }


        /// <summary>
        /// Find the next occurance of a parameter placeholder inside the given line
        /// </summary>
        /// <param name="lineText"></param>
        /// <param name="startAt"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private int NextParameter(string lineText, int startAt, out PcParameter parameter)
        {
            //Find the first occurance of a left delimiter starting from nextSegmentStart
            var leftDelIndex =
                lineText.IndexOf(
                    LeftDelimiter,
                    startAt,
                    StringComparison.Ordinal
                    );

            while (true)
            {
                //No left delimiter is found. end search for parameter placeholder
                if (leftDelIndex < 0)
                {
                    parameter = null;
                    return -1;
                }

                //Find first occurance of a right delimiter starting after the left delimiter that was found
                var rightDelIndex =
                    lineText.IndexOf(
                        RightDelimiter,
                        leftDelIndex + LeftDelimiter.Length,
                        StringComparison.Ordinal
                        );

                //A right delimiter is not found. End search for parameter placeholder
                if (rightDelIndex <= leftDelIndex)
                {
                    parameter = null;
                    return -1;
                }

                //A right delimiter is found
                var startIndex = leftDelIndex + LeftDelimiter.Length;
                var endIndex = rightDelIndex - 1;
                var length = endIndex - startIndex + 1;

                //Read the text between the left and right delimiters
                var parameterName = lineText.Substring(startIndex, length);

                //If the text is not a legal parameter name try searching for a new left delimiter
                if (parameterName.All(c => c == '_' || Char.IsLetterOrDigit(c)) == false)
                {
                    leftDelIndex =
                        lineText.IndexOf(
                            LeftDelimiter,
                            leftDelIndex + 1,
                            StringComparison.Ordinal
                            );

                    continue;
                }

                //If the parameter name is not defined add it with an empty string value
                if (_parameters.TryGetValue(parameterName, out parameter) == false)
                {
                    parameter = new PcParameter(this, parameterName);
                    _parameters.Add(parameterName, parameter);
                }

                return leftDelIndex;
            }
        }

        /// <summary>
        /// Add a new line to the template and process its parameters
        /// </summary>
        /// <param name="lineText"></param>
        private void AddLine(string lineText)
        {
            var line = new PcLine(lineText);

            var nextSegmentStart = 0;

            PcParameter parameter;

            //Find the location of the next parameter in the line
            var nextParamLocation = NextParameter(lineText, nextSegmentStart, out parameter);

            while (nextParamLocation > -1)
            {
                //There is a fixed segment before this parameter placeholder; add it to the line
                if (nextParamLocation > nextSegmentStart)
                    nextSegmentStart = line.AddFixedSegment(nextSegmentStart, nextParamLocation - 1);

                //Add a parametric segment to the line
                nextSegmentStart = line.AddParametricSegment(nextSegmentStart, parameter);

                //Find the location of the next parameter in the line
                nextParamLocation = NextParameter(lineText, nextSegmentStart, out parameter);
            }

            //No more parameters are found; add the remaining as a fixed segment
            line.AddFixedSegment(nextSegmentStart, lineText.Length - 1);

            _templateTextLines.Add(line);
        }


        /// <summary>
        /// Returns true if the template contains a parameter with the given name
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public bool ContainsParameter(string paramName)
        {
            return _parameters.ContainsKey(paramName);
        }

        /// <summary>
        /// Set all template parameters values to empty strings
        /// </summary>
        public ParametricComposer ClearBindings()
        {
            var identNames = _parameters.Select(pair => pair.Key);

            foreach (var identName in identNames)
                _parameters[identName].ParameterValue = String.Empty;

            return this;
        }

        /// <summary>
        /// Change the parameter name delimiters and automatically extract the parameters. 
        /// All previous bindings are deleted
        /// </summary>
        /// <param name="leftDelimiter"></param>
        /// <param name="rightDelimiter"></param>
        public ParametricComposer SetDelimiters(string leftDelimiter, string rightDelimiter)
        {
            LeftDelimiter = leftDelimiter;
            RightDelimiter = rightDelimiter;

            SetTemplateText(TemplateText);

            return this;
        }

        /// <summary>
        /// Change the parameter name delimiters and automatically extract the parameters. 
        /// All previous bindings are deleted
        /// </summary>
        /// <param name="leftRightDelimiter"></param>
        public ParametricComposer SetDelimiters(string leftRightDelimiter)
        {
            LeftDelimiter = leftRightDelimiter;
            RightDelimiter = leftRightDelimiter;

            SetTemplateText(TemplateText);

            return this;
        }

        /// <summary>
        /// Change the parameter name delimiters and the template text and automatically extract the parameters. 
        /// All previous bindings are deleted
        /// </summary>
        /// <param name="leftDelimiter"></param>
        /// <param name="rightDelimiter"></param>
        /// <param name="templateText"></param>
        public ParametricComposer SetTemplate(string leftDelimiter, string rightDelimiter, string templateText)
        {
            LeftDelimiter = leftDelimiter;
            RightDelimiter = rightDelimiter;

            SetTemplateText(templateText);

            return this;
        }

        /// <summary>
        /// Change the template text and automatically extract the parameters. 
        /// All previous bindings are deleted
        /// </summary>
        /// <param name="templateText"></param>
        public ParametricComposer SetTemplateText(string templateText)
        {
            TemplateText = templateText;

            //Clear internal data
            _parameters.Clear();

            _templateTextLines.Clear();

            //If the template text is not set just return
            if (String.IsNullOrEmpty(TemplateText))
                return this;

            //Process and store separate lines of template text
            var textLines = TemplateText.SplitLines();

            foreach (var textLine in textLines)
                AddLine(textLine);

            return this;
        }

        /// <summary>
        /// Change the template text and automatically extract the parameters by loading text from a given file.
        /// All previous parameter bindings are deleted
        /// </summary>
        /// <param name="filePath"></param>
        public ParametricComposer LoadTemplateText(string filePath)
        {
            SetTemplateText(File.ReadAllText(filePath));

            return this;
        }


        /// <summary>
        /// Override parameters values using the supplied parameters values in the paramsValues array where 
        /// the even indexed strings in the array are parameter names and the odd indexed strings are thier values
        /// </summary>
        /// <param name="paramsValues"></param>
        public ParametricComposer SetParametersValues(params string[] paramsValues)
        {
            var length = paramsValues.Length;

            if (length == 0)
                return this;

            var evenLength = (length >> 1) << 1;

            for (var i = 0; i < evenLength; i += 2)
                this[paramsValues[i]] = paramsValues[i + 1];

            if (evenLength < length)
                this[paramsValues.Last()] = String.Empty;

            return this;
        }

        /// <summary>
        /// Override parameters values using the supplied parameters values in the paramsValues array where 
        /// the even indexed strings in the array are parameter names and the odd indexed strings are thier values
        /// The strings are extracted using ToString() on each array item
        /// </summary>
        /// <param name="paramsValues"></param>
        public ParametricComposer SetParametersValues(params object[] paramsValues)
        {
            var length = paramsValues.Length;

            if (length == 0)
                return this;

            var evenLength = (length >> 1) << 1;

            for (var i = 0; i < evenLength; i += 2)
                this[paramsValues[i].ToString()] = paramsValues[i + 1].ToString();

            if (evenLength < length)
                this[paramsValues.Last().ToString()] = String.Empty;

            return this;
        }

        /// <summary>
        /// Override parameters values using the given dictionary where the key is the parameter name and the
        /// value is the parameter value
        /// </summary>
        /// <param name="paramsValues"></param>
        public ParametricComposer SetParametersValues(IDictionary<string, string> paramsValues)
        {
            foreach (var paramName in _parameters.Keys)
            {
                string paramValue;

                if (paramsValues.TryGetValue(paramName, out paramValue))
                    this[paramName] = paramValue;
            }

            return this;
        }

        /// <summary>
        /// Override the parameters values using the given collection of list text builders where the key
        /// is the parameter name and the selected builder's output is the parameter value
        /// </summary>
        /// <param name="paramsValues"></param>
        public ParametricComposer SetParametersValues(IParametericComposerValueSource paramsValues)
        {
            foreach (var paramName in _parameters.Keys)
            {
                string paramValue;

                if (paramsValues.TryGetParameterValue(paramName, out paramValue))
                    this[paramName] = paramValue;
            }

            return this;
        }


        /// <summary>
        /// Generate text from the template using the current values of the template parameters
        /// </summary>
        /// <returns></returns>
        public string GenerateText()
        {
            var s = new StringBuilder();

            for (var i = 0; i < _templateTextLines.Count; i++)
            {
                var stringLength = s.Length;

                foreach (var lineSegment in _templateTextLines[i].LineSegments)
                    if (lineSegment.IsFixed)
                        s.Append(lineSegment.SegmentText);

                    else if (AlignMultiLineParameterValues)
                        GenerateParameterText(s, stringLength, lineSegment.SegmentParameter.ParameterValue);

                    else
                        s.Append(lineSegment.SegmentParameter.ParameterValue);

                if (i < _templateTextLines.Count - 1)
                    s.AppendLine();
            }

            return s.ToString();
        }

        /// <summary>
        /// Bind the template parameters with the given values.ToString() in the same order of parameter 
        /// use inside template text then generate the text from the template
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public string GenerateUsing(params object[] values)
        {
            var paramNames = _parameters.Select(pair => pair.Key).ToArray();

            var count = Math.Min(values.Length, paramNames.Length);

            for (var i = 0; i < count; i++)
                _parameters[paramNames[i]].ParameterValue = values[i].ToString();

            return GenerateText();
        }

        /// <summary>
        /// Bind the template parameters with the given values in the same order of parameter use inside
        /// template text then generate the text from the template
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public string GenerateUsing(params string[] values)
        {
            var paramNames = _parameters.Select(pair => pair.Key).ToArray();

            var count = Math.Min(values.Length, paramNames.Length);

            for (var i = 0; i < count; i++)
                _parameters[paramNames[i]].ParameterValue = values[i];

            return GenerateText();
        }


        public override string ToString()
        {
            return TemplateText;
        }
    }
}
