using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class TypefaceChangedEventArgs : EventArgs
    {
        #region Variables
        private Font _typeface;
        #endregion

        #region Properties
        public Font Typeface { get => _typeface; set => _typeface = value; }
        #endregion

        #region Constructor
        public TypefaceChangedEventArgs(Font typeface) => Typeface = typeface;
        #endregion
    }
}