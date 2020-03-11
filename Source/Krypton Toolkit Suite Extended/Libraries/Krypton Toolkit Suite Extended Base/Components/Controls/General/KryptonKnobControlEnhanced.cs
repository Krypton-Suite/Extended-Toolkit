using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    /// <summary>
    /// Summary description for KnobControl.
    /// </summary>
    //[ToolboxItem(false)]
    [DefaultEvent("ValueChanged"), ToolboxBitmap(typeof(Timer))]
    public class KryptonKnobControlEnhanced : UserControl
    {
        #region Enumerations
        public enum KnobPointerStyle
        {
            CIRCLE,
            LINE
        }    
        #endregion

       #region Constructor
       public KryptonKnobControlEnhanced()
       {

       }
       #endregion
    }
}