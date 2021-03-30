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
        private string _messageText, _caption;
        private MessageBoxButtons _buttons;
        private MessageBoxIcon _icon;
        private MessageBoxDefaultButton _defaultButton;
        #endregion

        #region Properties
        public bool ShowCtrlCopy { get => _showCtrlCopy; set => _showCtrlCopy = value; }

        public Font MessageBoxTypeface { get => _messageboxTypeface; set => _messageboxTypeface = value; }

        public IWin32Window Owner { get => _owner; set => _owner = value; }

        public HelpInformation HelpInformation { get => _helpInformation; set => _helpInformation = value; }

        public string MessageText { get => _messageText; set => _messageText = value; }

        public string Caption { get => _caption; set => _caption = value; }

        public MessageBoxButtons MessageBoxButtons { get => _buttons; set => _buttons = value; }

        public MessageBoxIcon MessageBoxIcon { get => _icon; set => _icon = value; }

        public MessageBoxDefaultButton MessageBoxDefaultButton { get => _defaultButton; set => _defaultButton = value; }
        #endregion

        #region Static Events
        public static event EventHandler Show;
        #endregion
    }
}