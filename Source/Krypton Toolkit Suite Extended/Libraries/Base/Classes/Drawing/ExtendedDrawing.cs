using System.Drawing;

namespace Krypton.Toolkit.Extended.Base
{
    public class ExtendedDrawing
    {
        #region Constructor
        public ExtendedDrawing()
        {

        }
        #endregion

        #region Methods
        public Rectangle GetUpperLeft(int value) => new Rectangle(0, 0, value, value);

        //public Rectangle GetUpperRight(int value)=>new Rectangle(Wid)
        #endregion
    }
}