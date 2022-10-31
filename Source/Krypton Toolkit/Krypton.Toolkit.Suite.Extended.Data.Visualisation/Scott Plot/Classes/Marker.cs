#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class Marker
    {
        // TODO: refactor this in the next major version of ScottPlot to add support for LineWidth, etc
        public static MarkerShape None => MarkerShape.NONE;
        public static MarkerShape FilledCircle => MarkerShape.FILLEDCIRCLE;
        public static MarkerShape OpenCircle => MarkerShape.OPENCIRCLE;
        public static MarkerShape FilledSquare => MarkerShape.FILLEDSQUARE;
        public static MarkerShape OpenSquare => MarkerShape.OPENSQUARE;
        public static MarkerShape FilledDiamond => MarkerShape.FILLEDDIAMOND;
        public static MarkerShape OpenDiamond => MarkerShape.OPENDIAMOND;
        public static MarkerShape Asterisk => MarkerShape.ASTERISK;
        public static MarkerShape HashTag => MarkerShape.HASHTAG;
        public static MarkerShape Cross => MarkerShape.CROSS;
        public static MarkerShape Eks => MarkerShape.EKS;
        public static MarkerShape VerticalBar => MarkerShape.VERTICALBAR;
        public static MarkerShape TriangleUp => MarkerShape.TRIUP;
        public static MarkerShape TriangleDown => MarkerShape.TRIDOWN;

        public static MarkerShape Random() => Random(new Random());

        public static MarkerShape Random(Random rand)
        {
            Array members = Enum.GetValues(typeof(MarkerShape));
            object randomMember = members.GetValue(rand.Next(members.Length));
            return (MarkerShape)randomMember;
        }
    }
}