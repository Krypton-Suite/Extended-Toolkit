using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    public class EditColourCancelEventArgs : CancelEventArgs
    {
        #region Constructors

        public EditColourCancelEventArgs(Color colour, int colourIndex)
        {
            this.Colour = colour;
            this.ColourIndex = colourIndex;
        }

        protected EditColourCancelEventArgs()
        { }

        #endregion

        #region Properties

        public Color Colour { get; protected set; }

        public int ColourIndex { get; protected set; }

        #endregion
    }
}
