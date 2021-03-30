using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    [ToolboxItem(true), ToolboxBitmap(typeof(ExtendedKryptonMessageBox), "ToolboxBitmaps.KryptonMessageBox.bmp"),
     DefaultEvent("Show"), DesignerCategory("code"), Designer(typeof(ExtendedKryptonMessageBoxDesigner)),
     Description("")]
    public class ExtendedKryptonMessageBox : Component
    {
        #region Variables
        private bool _showCtrlCopy;
        private Font _messageboxTypeface;
        private IWin32Window _owner;
        private HelpInformation _helpInformation;
        #endregion

        #region Static Events
        public static event EventHandler Show;
        #endregion
    }
}