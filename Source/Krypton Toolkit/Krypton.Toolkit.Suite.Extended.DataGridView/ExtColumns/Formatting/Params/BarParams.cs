#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;
using System.Xml;

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// Parameters for Bar formatting
    /// </summary>
    /// <seealso cref="IFormatParams" />
    public class BarParams : IFormatParams
    {
        /// <summary>
        /// The bar color
        /// </summary>
        public Color BarColour;
        /// <summary>
        /// The gradient fill
        /// </summary>
        public bool GradientFill;
        /// <summary>
        /// The proportion value
        /// </summary>
        public double ProportionValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="BarParams"/> class.
        /// </summary>
        /// <param name="barColour">Color of the bar.</param>
        /// <param name="gradientFill">if set to <c>true</c> [gradient fill].</param>
        public BarParams(Color barColour, bool gradientFill)
        {
            BarColour = barColour;
            GradientFill = gradientFill;
        }

        /// <summary>
        /// Crée un objet qui est une copie de l'instance actuelle.
        /// </summary>
        /// <returns>
        /// Nouvel objet qui est une copie de cette instance.
        /// </returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Persists the parameters.
        /// </summary>
        /// <param name="writer">The XML writer.</param>
        void IFormatParams.Persist(XmlWriter writer)
        {
            writer.WriteElementString("BarColour", BarColour.ToArgb().ToString());
            writer.WriteElementString("GradientFill", CommonHelper.BoolToString(GradientFill));
        }
    }
}