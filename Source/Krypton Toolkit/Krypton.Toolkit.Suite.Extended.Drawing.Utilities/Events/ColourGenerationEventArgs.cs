#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourGenerationEventArgs : EventArgs
    {
        #region Variables
        private Color _colour;

        private byte _alphaValue, _redValue, _greenValue, _blueValue;
        #endregion

        #region Properties
        /// <summary>Gets or sets the colour.</summary>
        /// <value>The colour.</value>
        public Color Colour { get => _colour; set => _colour = value; }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="ColourGenerationEventArgs" /> class.</summary>
        /// <param name="alphaValue">The alpha value.</param>
        /// <param name="redValue">The red value.</param>
        /// <param name="greenValue">The green value.</param>
        /// <param name="blueValue">The blue value.</param>
        public ColourGenerationEventArgs(byte alphaValue, byte redValue, byte greenValue, byte blueValue)
        {
            _alphaValue = alphaValue;

            _redValue = redValue;

            _greenValue = greenValue;

            _blueValue = blueValue;

            SetColour(alphaValue, redValue, greenValue, blueValue);
        }
        #endregion

        /// <summary>Sets the colour.</summary>
        /// <param name="alphaValue">The alpha value.</param>
        /// <param name="redValue">The red value.</param>
        /// <param name="greenValue">The green value.</param>
        /// <param name="blueValue">The blue value.</param>
        public void SetColour(byte alphaValue, byte redValue, byte greenValue, byte blueValue) => Colour = Color.FromArgb(alphaValue, redValue, greenValue, blueValue);

        /// <summary>Sets the colour.</summary>
        /// <param name="colour">The colour.</param>
        public void SetColour(Color colour) => Colour = colour;

        /// <summary>Gets the colour.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public Color GetColour() => Colour;
    }
}