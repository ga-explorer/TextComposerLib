﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TextComposerLib.Diagrams.SVG.Values
{
    public class SvgValuePointsList : SvgComputedValue
    {
        public static SvgValuePointsList Create()
        {
            return new SvgValuePointsList();
        }

        public static SvgValuePointsList Create(SvgValueLengthUnit unit)
        {
            return new SvgValuePointsList {Unit = unit};
        }

        public static SvgValuePointsList Create(double x, double y)
        {
            var pointsList = new SvgValuePointsList();

            return pointsList.AddPoint(x, y);
        }

        public static SvgValuePointsList Create(SvgValueLengthUnit unit, double x, double y)
        {
            var pointsList = new SvgValuePointsList { Unit = unit };

            return pointsList.AddPoint(x, y);
        }

        public static SvgValuePointsList Create(IEnumerable<Tuple<double, double>> points)
        {
            var pointsList = new SvgValuePointsList();

            return pointsList.AddPoints(points);
        }

        public static SvgValuePointsList Create(SvgValueLengthUnit unit, IEnumerable<Tuple<double, double>> points)
        {
            var pointsList = new SvgValuePointsList { Unit = unit };

            return pointsList.AddPoints(points);
        }

        public static SvgValuePointsList Create(params double[] points)
        {
            var pointsList = new SvgValuePointsList();

            return pointsList.AddPoints(points);
        }

        public static SvgValuePointsList Create(SvgValueLengthUnit unit, params double[] points)
        {
            var pointsList = new SvgValuePointsList { Unit = unit };

            return pointsList.AddPoints(points);
        }


        private readonly List<Tuple<double, double>> _pointsList
            = new List<Tuple<double, double>>();


        public IEnumerable<Tuple<double, double>> Points
            => _pointsList;

        private SvgValueLengthUnit _unit = SvgValueLengthUnit.None;
        public SvgValueLengthUnit Unit
        {
            get { return _unit; }
            set { _unit = value ?? SvgValueLengthUnit.None; }
        }

        public Tuple<double, double> this[int index]
            => _pointsList[index];

        public override string ValueText
        {
            get
            {
                if (_pointsList.Count == 0)
                    return string.Empty;

                var composer = new StringBuilder();

                foreach (var point in _pointsList)
                    composer.Append(point.Item1.ToSvgLengthText(_unit))
                        .Append(",")
                        .Append(point.Item2.ToSvgLengthText(_unit))
                        .Append(" ");

                composer.Length -= " ".Length;

                return composer.ToString();
            }
        }


        private SvgValuePointsList()
        {
        }


        public SvgValuePointsList ClearPoints()
        {
            _pointsList.Clear();

            return this;
        }

        public SvgValuePointsList AddPoint(double x, double y)
        {
            _pointsList.Add(new Tuple<double, double>(x, y));

            return this;
        }

        public SvgValuePointsList InsertPoint(int index, double x, double y)
        {
            _pointsList.Insert(index, new Tuple<double, double>(x, y));

            return this;
        }

        public SvgValuePointsList AddPoints(IEnumerable<Tuple<double, double>> pointsList)
        {
            _pointsList.AddRange(pointsList);

            return this;
        }

        public SvgValuePointsList InsertPoints(int index, IEnumerable<Tuple<double, double>> pointsList)
        {
            _pointsList.InsertRange(index, pointsList);

            return this;
        }

        public SvgValuePointsList AddPoints(params double[] pointsList)
        {
            if ((pointsList.Length & 1) != 0)
                throw new InvalidOperationException("An even number of coordinates is expected");

            for (var i = 0; i < pointsList.Length; i += 2)
                AddPoint(pointsList[i], pointsList[i + 1]);

            return this;
        }

        public SvgValuePointsList RemovePoint(int index)
        {
            _pointsList.RemoveAt(index);

            return this;
        }
    }
}