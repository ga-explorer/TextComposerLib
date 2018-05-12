using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TextComposerLib.Diagrams
{
    public static class DiagramsUtils
    {
        /// <summary>
        /// Interpolate between Color.White and this color using a number t between 0 and 1
        /// </summary>
        /// <param name="c2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Color LerpFromWhite(this Color c2, double t)
        {
            var c1 = Color.White;

            var s = 1.0d - t;
            return Color.FromArgb(
                (int)Math.Round(s * c1.A + t * c2.A),
                (int)Math.Round(s * c1.R + t * c2.R),
                (int)Math.Round(s * c1.G + t * c2.G),
                (int)Math.Round(s * c1.B + t * c2.B)
            );
        }

        /// <summary>
        /// Interpolate between Color.Black and this color using a number t between 0 and 1
        /// </summary>
        /// <param name="c2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Color LerpFromBlack(this Color c2, double t)
        {
            var c1 = Color.Black;

            var s = 1.0d - t;
            return Color.FromArgb(
                (int)Math.Round(s * c1.A + t * c2.A),
                (int)Math.Round(s * c1.R + t * c2.R),
                (int)Math.Round(s * c1.G + t * c2.G),
                (int)Math.Round(s * c1.B + t * c2.B)
            );
        }

        /// <summary>
        /// Interpolate between c1 and this color using a number t between 0 and 1
        /// </summary>
        /// <param name="c2"></param>
        /// <param name="c1"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Color LerpFromColor(this Color c2, Color c1, double t)
        {
            var s = 1.0d - t;
            return Color.FromArgb(
                (int)Math.Round(s * c1.A + t * c2.A),
                (int)Math.Round(s * c1.R + t * c2.R),
                (int)Math.Round(s * c1.G + t * c2.G),
                (int)Math.Round(s * c1.B + t * c2.B)
            );
        }

        /// <summary>
        /// Interpolate between this color and Color.White using a number t between 0 and 1
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Color LerpToWhite(this Color c1, double t)
        {
            var c2 = Color.White;

            var s = 1.0d - t;
            return Color.FromArgb(
                (int)Math.Round(s * c1.A + t * c2.A),
                (int)Math.Round(s * c1.R + t * c2.R),
                (int)Math.Round(s * c1.G + t * c2.G),
                (int)Math.Round(s * c1.B + t * c2.B)
            );
        }

        /// <summary>
        /// Interpolate between this color and Color.Black using a number t between 0 and 1
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Color LerpToBlack(this Color c1, double t)
        {
            var c2 = Color.Black;

            var s = 1.0d - t;
            return Color.FromArgb(
                (int)Math.Round(s * c1.A + t * c2.A),
                (int)Math.Round(s * c1.R + t * c2.R),
                (int)Math.Round(s * c1.G + t * c2.G),
                (int)Math.Round(s * c1.B + t * c2.B)
            );
        }

        /// <summary>
        /// Interpolate between this color and c1 using a number t between 0 and 1
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Color LerpToColor(this Color c1, Color c2, double t)
        {
            var s = 1.0d - t;
            return Color.FromArgb(
                (int)Math.Round(s * c1.A + t * c2.A),
                (int)Math.Round(s * c1.R + t * c2.R),
                (int)Math.Round(s * c1.G + t * c2.G),
                (int)Math.Round(s * c1.B + t * c2.B)
            );
        }

        /// <summary>
        /// Interpolate between Color.White and this color using a list of numbers each between 0 and 1
        /// </summary>
        /// <param name="c2"></param>
        /// <param name="tList"></param>
        /// <returns></returns>
        public static IEnumerable<Color> LerpFromWhite(this Color c2, IEnumerable<double> tList)
        {
            return tList.Select(t => c2.LerpFromWhite(t));
        }

        /// <summary>
        /// Interpolate between Color.Black and this color using a list of numbers each between 0 and 1
        /// </summary>
        /// <param name="c2"></param>
        /// <param name="tList"></param>
        /// <returns></returns>
        public static IEnumerable<Color> LerpFromBlack(this Color c2, IEnumerable<double> tList)
        {
            return tList.Select(t => c2.LerpFromBlack(t));
        }

        /// <summary>
        /// Interpolate between c1 and this color using a list of numbers each between 0 and 1
        /// </summary>
        /// <param name="c2"></param>
        /// <param name="c1"></param>
        /// <param name="tList"></param>
        /// <returns></returns>
        public static IEnumerable<Color> LerpFromWhite(this Color c2, Color c1, IEnumerable<double> tList)
        {
            return tList.Select(t => c2.LerpFromColor(c2, t));
        }

        /// <summary>
        /// Interpolate between this color and Color.White using a list of numbers each between 0 and 1
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="tList"></param>
        /// <returns></returns>
        public static IEnumerable<Color> LerpToWhite(this Color c1, IEnumerable<double> tList)
        {
            return tList.Select(t => c1.LerpToWhite(t));
        }

        /// <summary>
        /// Interpolate between this color and Color.Black using a list of numbers each between 0 and 1
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="tList"></param>
        /// <returns></returns>
        public static IEnumerable<Color> LerpToBlack(this Color c1, IEnumerable<double> tList)
        {
            return tList.Select(t => c1.LerpToBlack(t));
        }

        /// <summary>
        /// Interpolate between this color and c2 using a list of numbers each between 0 and 1
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="tList"></param>
        /// <returns></returns>
        public static IEnumerable<Color> LerpToWhite(this Color c1, Color c2, IEnumerable<double> tList)
        {
            return tList.Select(t => c1.LerpToColor(c2, t));
        }
    }
}
