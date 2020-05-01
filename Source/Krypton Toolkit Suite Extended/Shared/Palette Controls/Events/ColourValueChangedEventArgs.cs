using System;
using System.Drawing;

namespace Krypton.Toolkit.Extended.Palette.Controls
{
    public class ColourValueChangedEventArgs : EventArgs
    {
        private Color _colour;

        public Color Colour { get => _colour; set => _colour = value; }

        public ColourValueChangedEventArgs(Color colour)
        {
            Colour = colour;
        }
    }
}