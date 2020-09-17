using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class TypefaceChangedEventArgs : EventArgs
    {
        #region Variable
        private Font _typeface;
        #endregion

        #region Property
        public Font Typeface { get => _typeface; set => _typeface = value; }
        #endregion

        #region Constructor
        public TypefaceChangedEventArgs(Font typeface) => Typeface = typeface;
        #endregion
    }
}