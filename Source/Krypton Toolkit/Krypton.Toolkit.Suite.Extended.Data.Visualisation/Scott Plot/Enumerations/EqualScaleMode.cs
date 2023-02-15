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
    /// <summary>
    /// Defines if/how axis scales (units per pixel) are matched between horizontal and vertical axes.
    /// </summary>
    public enum EqualScaleMode
    {
        /// <summary>
        /// Horizontal and vertical axes can be scaled independently. 
        /// Squares and circles may stretch to rectangles and ovals.
        /// </summary>
        Disabled,

        /// <summary>
        /// Axis scales are locked so geometry of squares and circles is preserved.
        /// After axes are set, the vertical scale (units per pixel) is applied to the horizontal axis.
        /// </summary>
        PreserveY,

        /// <summary>
        /// Axis scales are locked so geometry of squares and circles is preserved.
        /// After axes are set, the horizontal scale (units per pixel) is applied to the vertical axis.
        /// </summary>
        PreserveX,

        /// <summary>
        /// Axis scales are locked so geometry of squares and circles is preserved.
        /// After axes are set, the largest scale (most units per pixel) is applied to both axes.
        /// Apply the most zoomed-out scale to both axes.
        /// </summary>
        ZoomOut,


        /// <summary>
        /// Apply the scale of the larger axis to both axes.
        /// </summary>
        PreserveLargest,


        /// <summary>
        /// Apply the scale of the smaller axis to both axes.
        /// </summary>
        PreserveSmallest
    }
}