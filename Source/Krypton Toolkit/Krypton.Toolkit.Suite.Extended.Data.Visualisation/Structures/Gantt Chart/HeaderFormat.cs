#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// Format for painting chart header
    /// </summary>
    public struct HeaderFormat
    {
        /// <summary>
        /// Font color
        /// </summary>
        public Brush Colour { get; set; }
        /// <summary>
        /// Border and line colors
        /// </summary>
        public Pen Border { get; set; }
        /// <summary>
        /// Get or set the lighter color in the gradient
        /// </summary>
        public Color GradientLight { get; set; }
        /// <summary>
        /// Get or set the darker color in the gradient
        /// </summary>
        public Color GradientDark { get; set; }
    }
}