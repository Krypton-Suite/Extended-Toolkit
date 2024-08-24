#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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