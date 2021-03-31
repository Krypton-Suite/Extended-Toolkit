using System.ComponentModel;
using System.Drawing;

namespace Cyotek.Windows.Forms.Colour.Picker
{
    public class EditColourCancelEventArgs : CancelEventArgs
    {
        #region Constructors

        public EditColourCancelEventArgs(Color color, int colorIndex)
        {
            this.Colour = color;
            this.ColourIndex = colorIndex;
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