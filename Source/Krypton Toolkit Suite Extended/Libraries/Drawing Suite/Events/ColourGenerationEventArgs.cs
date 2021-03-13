using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite.Events
{
    public class ColourGenerationEventArgs : EventArgs
    {
        #region Variables
        private Color _colour;

        private byte _alphaValue, _redValue, _greenValue, _blueValue;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set => _colour = value; }
        #endregion

        #region Constructors
        public ColourGenerationEventArgs(byte alphaValue, byte redValue, byte greenValue, byte blueValue)
        {
            _alphaValue = alphaValue;

            _redValue = redValue;

            _greenValue = greenValue;

            _blueValue = blueValue;

            ConstructColour(alphaValue, redValue, greenValue, blueValue);
        }

        private void ConstructColour(byte alphaValue, byte redValue, byte greenValue, byte blueValue) => Colour = Color.FromArgb(alphaValue, redValue, greenValue, blueValue);
        #endregion
    }
}