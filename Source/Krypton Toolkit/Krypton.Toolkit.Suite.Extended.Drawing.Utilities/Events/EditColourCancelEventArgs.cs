#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
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
