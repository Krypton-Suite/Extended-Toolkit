using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Palette.Selectors
{
    public class ColourValuesChangedEventArgs : EventArgs
    {
        private Color[] _colours;

        public Color[] Colours { get => _colours; set => _colours = value; }

        public ColourValuesChangedEventArgs(Color[] colours)
        {
            Colours = colours;
        }
    }
}