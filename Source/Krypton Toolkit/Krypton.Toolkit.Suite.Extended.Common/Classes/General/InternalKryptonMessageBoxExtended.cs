﻿#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    /// Displays a message box that can contain text, buttons, and symbols that inform and instruct the user.
    /// Allows optional Font to be specified, if not then new Font(@"Segoe UI", 12F) will be used
    /// </summary>
    [ToolboxItem(false), ToolboxBitmap(typeof(InternalKryptonMessageBoxExtended), "ToolboxBitmaps.KryptonMessageBox.bmp"),
     DesignerCategory("code"), DesignTimeVisible(false)]
    public class InternalKryptonMessageBoxExtended : KryptonForm
    {
        #region System
        private void InitialiseComponent()
        {
            _panelMessage = new KryptonPanel();
            _panelMessageText = new KryptonPanel();
            _messageText = new KryptonWrapLabel();
            _panelMessageIcon = new KryptonPanel();
            _messageIcon = new PictureBox();
            _panelButtons = new KryptonPanel();
            _borderEdge = new KryptonBorderEdge();
            _button3 = new MessageButton();
            _button1 = new MessageButton();
            _button2 = new MessageButton();
            ((ISupportInitialize)(_panelMessage)).BeginInit();
            _panelMessage.SuspendLayout();
            ((ISupportInitialize)(_panelMessageText)).BeginInit();
            _panelMessageText.SuspendLayout();
            ((ISupportInitialize)(_panelMessageIcon)).BeginInit();
            _panelMessageIcon.SuspendLayout();
            ((ISupportInitialize)(_messageIcon)).BeginInit();
            ((ISupportInitialize)(_panelButtons)).BeginInit();
            _panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // _panelMessage
            // 
            _panelMessage.AutoSize = true;
            _panelMessage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _panelMessage.Controls.Add(_panelMessageText);
            _panelMessage.Controls.Add(_panelMessageIcon);
            _panelMessage.Dock = DockStyle.Top;
            _panelMessage.Location = new Point(0, 0);
            _panelMessage.Name = "_panelMessage";
            _panelMessage.Size = new Size(156, 52);
            _panelMessage.TabIndex = 0;
            // 
            // _panelMessageText
            // 
            _panelMessageText.AutoSize = true;
            _panelMessageText.Controls.Add(_messageText);
            _panelMessageText.Location = new Point(42, 0);
            _panelMessageText.Margin = new Padding(0);
            _panelMessageText.Name = "_panelMessageText";
            _panelMessageText.Padding = new Padding(5, 17, 5, 17);
            _panelMessageText.Size = new Size(88, 52);
            _panelMessageText.TabIndex = 1;
            // 
            // _messageText
            // 
            _messageText.AutoSize = false;
            _messageText.StateCommon.Font = new Font(@"Segoe UI", 9F);
            _messageText.ForeColor = Color.FromArgb(30, 57, 91);
            _messageText.LabelStyle = LabelStyle.NormalPanel;
            _messageText.Location = new Point(5, 18);
            _messageText.Margin = new Padding(0);
            _messageText.Name = "_messageText";
            _messageText.Size = new Size(78, 15);
            _messageText.Text = @"Message Text";
            // 
            // _panelMessageIcon
            // 
            _panelMessageIcon.AutoSize = true;
            _panelMessageIcon.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _panelMessageIcon.Controls.Add(_messageIcon);
            _panelMessageIcon.Location = new Point(0, 0);
            _panelMessageIcon.Margin = new Padding(0);
            _panelMessageIcon.Name = "_panelMessageIcon";
            _panelMessageIcon.Padding = new Padding(10, 10, 0, 10);
            _panelMessageIcon.Size = new Size(42, 52);
            _panelMessageIcon.TabIndex = 0;
            // 
            // _messageIcon
            // 
            _messageIcon.BackColor = Color.Transparent;
            _messageIcon.Location = new Point(10, 10);
            _messageIcon.Margin = new Padding(0);
            _messageIcon.Name = "_messageIcon";
            _messageIcon.Size = new Size(32, 32);
            _messageIcon.TabIndex = 0;
            _messageIcon.TabStop = false;
            // 
            // _panelButtons
            // 
            _panelButtons.Controls.Add(_borderEdge);
            _panelButtons.Controls.Add(_button3);
            _panelButtons.Controls.Add(_button1);
            _panelButtons.Controls.Add(_button2);
            _panelButtons.Dock = DockStyle.Top;
            _panelButtons.Location = new Point(0, 52);
            _panelButtons.Margin = new Padding(0);
            _panelButtons.Name = "_panelButtons";
            _panelButtons.PanelBackStyle = PaletteBackStyle.PanelAlternate;
            _panelButtons.Size = new Size(156, 26);
            _panelButtons.TabIndex = 0;
            // 
            // borderEdge
            // 
            _borderEdge.BorderStyle = PaletteBorderStyle.HeaderPrimary;
            _borderEdge.Dock = DockStyle.Top;
            _borderEdge.Location = new Point(0, 0);
            _borderEdge.Name = "_borderEdge";
            _borderEdge.Size = new Size(156, 1);
            _borderEdge.Text = @"kryptonBorderEdge1";
            // 
            // _button3
            // 
            _button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _button3.AutoSize = true;
            _button3.IgnoreAltF4 = false;
            _button3.Location = new Point(106, 0);
            _button3.Margin = new Padding(0);
            _button3.MinimumSize = new Size(50, 26);
            _button3.Name = "_button3";
            _button3.Size = new Size(50, 26);
            _button3.TabIndex = 2;
            _button3.Values.Text = @"B3";
            _button3.KeyDown += button_keyDown;
            // 
            // _button1
            // 
            _button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _button1.AutoSize = true;
            _button1.IgnoreAltF4 = false;
            _button1.Location = new Point(6, 0);
            _button1.Margin = new Padding(0);
            _button1.MinimumSize = new Size(50, 26);
            _button1.Name = "_button1";
            _button1.Size = new Size(50, 26);
            _button1.TabIndex = 0;
            _button1.Values.Text = @"B1";
            _button1.KeyDown += button_keyDown;
            // 
            // _button2
            // 
            _button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _button2.AutoSize = true;
            _button2.IgnoreAltF4 = false;
            _button2.Location = new Point(56, 0);
            _button2.Margin = new Padding(0);
            _button2.MinimumSize = new Size(50, 26);
            _button2.Name = "_button2";
            _button2.Size = new Size(50, 26);
            _button2.TabIndex = 1;
            _button2.Values.Text = @"B2";
            _button2.KeyDown += button_keyDown;
            // 
            // KryptonMessageBox
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(156, 78);
            Controls.Add(_panelButtons);
            Controls.Add(_panelMessage);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InternalKryptonMessageBoxExtended";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ((ISupportInitialize)(_panelMessage)).EndInit();
            _panelMessage.ResumeLayout(false);
            _panelMessage.PerformLayout();
            ((ISupportInitialize)(_panelMessageText)).EndInit();
            _panelMessageText.ResumeLayout(false);
            ((ISupportInitialize)(_panelMessageIcon)).EndInit();
            _panelMessageIcon.ResumeLayout(false);
            ((ISupportInitialize)(_messageIcon)).EndInit();
            ((ISupportInitialize)(_panelButtons)).EndInit();
            _panelButtons.ResumeLayout(false);
            _panelButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        #region Variables
        private readonly string _text;
        private readonly string _caption;
        private readonly MessageBoxButtons _buttons;
        private readonly MessageBoxIcon _icon;
        private readonly MessageBoxDefaultButton _defaultButton;
        private MessageBoxOptions _options; // TODO: What is this used for ?
        private KryptonPanel _panelMessage;
        private KryptonPanel _panelMessageText;
        private KryptonWrapLabel _messageText;
        private KryptonPanel _panelMessageIcon;
        private PictureBox _messageIcon;
        private KryptonPanel _panelButtons;
        private MessageButton _button1;
        private MessageButton _button2;
        private MessageButton _button3;
        private KryptonBorderEdge _borderEdge;
        private HelPlatformInvokenformation _helPlatformInvokenformation; // TODO: What is this used for ?
        private Font _messageboxTypeface;
        #endregion

        #region Static Fields
        private const int GAP = 10;
        private static readonly int _osMajorVersion;
        #endregion

        #region Properties
        public Font MessageBoxTypeface
        {
            get => _messageboxTypeface;
            set => _messageboxTypeface = value;
        }
        #endregion

        #region Internal Classes
        internal class HelPlatformInvokenformation
        {
            #region Properties
            /// <summary>
            /// Gets the HelpFilePath property.
            /// </summary>
            public string HelpFilePath { get; }

            /// <summary>
            /// Gets the Keyword property.
            /// </summary>
            public string Keyword { get; }

            /// <summary>
            /// Gets the Navigator property.
            /// </summary>
            public HelpNavigator Navigator { get; }

            /// <summary>
            /// Gets the Param property.
            /// </summary>
            public object Param { get; }
            #endregion

            #region Methods
            /// <summary>
            /// Initialize a new instance of the HelPlatformInvokenformation class.
            /// </summary>
            public HelPlatformInvokenformation()
            {
            }

            /// <summary>
            /// Initialize a new instance of the HelPlatformInvokenformation class.
            /// </summary>
            /// <param name="helpFilePath">Value for HelpFilePath.</param>
            public HelPlatformInvokenformation(string helpFilePath)
            {
                HelpFilePath = helpFilePath;
            }

            /// <summary>
            /// Initialize a new instance of the HelPlatformInvokenformation class.
            /// </summary>
            /// <param name="helpFilePath">Value for HelpFilePath.</param>
            /// <param name="keyword">Value for Keyword</param>
            public HelPlatformInvokenformation(string helpFilePath, string keyword)
            {
                HelpFilePath = helpFilePath;
                Keyword = keyword;
            }

            /// <summary>
            /// Initialize a new instance of the HelPlatformInvokenformation class.
            /// </summary>
            /// <param name="helpFilePath">Value for HelpFilePath.</param>
            /// <param name="navigator">Value for Navigator</param>
            public HelPlatformInvokenformation(string helpFilePath, HelpNavigator navigator)
            {
                HelpFilePath = helpFilePath;
                Navigator = navigator;
            }

            /// <summary>
            /// Initialize a new instance of the HelPlatformInvokenformation class.
            /// </summary>
            /// <param name="helpFilePath">Value for HelpFilePath.</param>
            /// <param name="navigator">Value for Navigator</param>
            /// <param name="param">Value for Param</param>
            public HelPlatformInvokenformation(string helpFilePath, HelpNavigator navigator, object param)
            {
                HelpFilePath = helpFilePath;
                Navigator = navigator;
                Param = param;
            }
            #endregion
        }

        [ToolboxItem(false)]
        internal class MessageButton : KryptonButton
        {
            #region Identity
            /// <summary>
            /// Gets and sets the ignoring of Alt+F4
            /// </summary>
            public bool IgnoreAltF4 { get; set; }

            #endregion

            #region Protected
            /// <summary>
            /// Processes Windows messages.
            /// </summary>
            /// <param name="m">The Windows Message to process. </param>
            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case PlatformInvoke.WM_KEYDOWN:
                    case PlatformInvoke.WM_SYSKEYDOWN:
                        if (IgnoreAltF4)
                        {
                            // Extract the keys being pressed
                            Keys keys = ((Keys)((int)m.WParam.ToInt64()));

                            // If the user standard combination ALT + F4
                            if ((keys == Keys.F4) && ((ModifierKeys & Keys.Alt) == Keys.Alt))
                            {
                                // Eat the message, so standard window proc does not close the window
                                return;
                            }
                        }
                        break;
                }

                base.WndProc(ref m);
            }
            #endregion
        }
        #endregion

        #region Constructors
        static InternalKryptonMessageBoxExtended()
        {
            _osMajorVersion = Environment.OSVersion.Version.Major;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalKryptonMessageBoxExtended"/> class.
        /// </summary>
        /// <param name="showOwner">The show owner. (Can be null)</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption. (Can be null)</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="helPlatformInvokenformation">The help information.</param>
        /// <param name="showCtrlCopy">The show control copy. (Can be null)</param>
        /// <param name="messageboxTypeface">The messagebox typeface. (Can be null)</param>
        private InternalKryptonMessageBoxExtended(IWin32Window showOwner, string text, string caption,
            MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton,
            MessageBoxOptions options, HelPlatformInvokenformation helPlatformInvokenformation, bool? showCtrlCopy,
            Font? messageboxTypeface)
        {
            #region Store Values
            _text = text;

            _caption = caption;

            _buttons = buttons;

            _icon = icon;

            _defaultButton = defaultButton;

            _options = options;

            _helPlatformInvokenformation = helPlatformInvokenformation;

            MessageBoxTypeface = messageboxTypeface ?? new Font(@"Segoe UI", 12F);

            #endregion

            // Create the form contents
            InitialiseComponent();

            // Update contents to match requirements
            UpdateText();

            UpdateIcon();

            UpdateButtons();

            UpdateDefault();

            UpdateHelp();

            UpdateTextExtra(showCtrlCopy);

            // Finally calculate and set form sizing
            UpdateSizing(showOwner);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }

            base.Dispose(disposing);
        }
        #endregion

        #region Public

        /// <summary>
        /// Displays a message box with specified text.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(null, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner, string text, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(owner, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with specified text and caption.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text and caption.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with specified text, caption, and buttons.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        MessageBoxButtons buttons, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text, caption, and buttons.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        MessageBoxButtons buttons, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, and default button.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, 0, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text, caption, buttons, icon, and default button.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, 0, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, and options.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text, caption, buttons, icon, default button, and options.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="displayHelpButton">Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        bool displayHelpButton, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, displayHelpButton ? new HelPlatformInvokenformation() : null, showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelPlatformInvokenformation(helpFilePath), showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelPlatformInvokenformation(helpFilePath), showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and HelpNavigator.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, HelpNavigator navigator, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelPlatformInvokenformation(helpFilePath, navigator), showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and Help keyword.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="keyword">The Help keyword to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, string keyword, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelPlatformInvokenformation(helpFilePath, keyword), showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and HelpNavigator.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, HelpNavigator navigator, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelPlatformInvokenformation(helpFilePath, navigator), showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and Help keyword.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="keyword">The Help keyword to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, string keyword, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelPlatformInvokenformation(helpFilePath, keyword), showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file, HelpNavigator, and Help toPlatformInvokec.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
        /// <param name="param">The numeric ID of the Help toPlatformInvokec to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, HelpNavigator navigator, object param, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelPlatformInvokenformation(helpFilePath, navigator, param), showCtrlCopy, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file, HelpNavigator, and Help toPlatformInvokec.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
        /// <param name="param">The numeric ID of the Help toPlatformInvokec to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">Defines the messagebox font.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, HelpNavigator navigator, object param, bool? showCtrlCopy = null, Font? messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelPlatformInvokenformation(helpFilePath, navigator, param), showCtrlCopy, messageboxTypeface);
        }
        #endregion

        #region Implementation
        private static DialogResult InternalShow(IWin32Window owner,
                                                 string text, string caption,
                                                 MessageBoxButtons buttons,
                                                 MessageBoxIcon icon,
                                                 MessageBoxDefaultButton defaultButton,
                                                 MessageBoxOptions options,
                                                 HelPlatformInvokenformation helPlatformInvokenformation, bool? showCtrlCopy, Font? messageboxTypeface = null)
        {
            // Check if trying to show a message box from a non-interactive process, this is not possible
            if (!SystemInformation.UserInteractive && ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0))
            {
                throw new InvalidOperationException("Cannot show modal dialog when non-interactive");
            }

            // Check if trying to show a message box from a service and the owner has been specified, this is not possible
            if ((owner != null) && ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0))
            {
                throw new ArgumentException(@"Cannot show message box from a service with an owner specified", nameof(options));
            }

            // Check if trying to show a message box from a service and help information is specified, this is not possible
            if ((helPlatformInvokenformation != null) && ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0))
            {
                throw new ArgumentException(@"Cannot show message box from a service with help specified", nameof(options));
            }

            // If help information provided or we are not a service/default desktop application then grab an owner for showing the message box
            IWin32Window showOwner = null;
            if ((helPlatformInvokenformation != null) || ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0))
            {
                // If do not have an owner passed in then get the active window and use that instead
                showOwner = owner ?? FromHandle(PlatformInvoke.GetActiveWindow());
            }

            // Show message box window as a modal dialog and then dispose of it afterwards
            using (InternalKryptonMessageBoxExtended ekmb = new InternalKryptonMessageBoxExtended(showOwner, text, caption, buttons, icon, defaultButton, options, helPlatformInvokenformation, showCtrlCopy, messageboxTypeface))
            {
                ekmb.StartPosition = showOwner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;

                return ekmb.ShowDialog(showOwner);
            }
        }

        private void UpdateText()
        {
            Text = (string.IsNullOrEmpty(_caption) ? string.Empty : _caption.Split(Environment.NewLine.ToCharArray())[0]);
            _messageText.StateCommon.Font = MessageBoxTypeface;
            _messageText.Text = _text;
        }

        private void UpdateTextExtra(bool? showCtrlCopy)
        {
            if (!showCtrlCopy.HasValue)
            {
                switch (_icon)
                {
                    case MessageBoxIcon.Error:
                    case MessageBoxIcon.Exclamation:
                        showCtrlCopy = true;
                        break;
                }
            }

            if (showCtrlCopy != null && showCtrlCopy.Value)
            {
                TextExtra = @"Ctrl+c to copy";
            }
        }

        private void UpdateIcon()
        {
            switch (_icon)
            {
                case MessageBoxIcon.None:
                    _panelMessageIcon.Visible = false;
                    _panelMessageText.Left -= _messageIcon.Right;

                    // Windows XP and before will Beep, Vista and above do not!
                    if (_osMajorVersion < 6)
                    {
                        SystemSounds.Beep.Play();
                    }

                    break;
                case MessageBoxIcon.Question:
                    _messageIcon.Image = ImageResources.Question_32_x_32;
                    SystemSounds.Question.Play();
                    break;
                case MessageBoxIcon.Information:
                    _messageIcon.Image = ImageResources.Information_32_x_32;
                    SystemSounds.Asterisk.Play();
                    break;
                case MessageBoxIcon.Warning:
                    _messageIcon.Image = ImageResources.Warning_32_x_32;
                    SystemSounds.Exclamation.Play();
                    break;
                case MessageBoxIcon.Error:
                    _messageIcon.Image = ImageResources.Critical_32_x_32;
                    SystemSounds.Asterisk.Play();
                    break;
                    //case MessageBoxIcon.Hand:
                    //    _messageIcon.Image = KryptonMessageBoxResources.KryptonMessageBox;
                    //    SystemSounds.Hand.Play();
                    //    break;
                    //case MessageBoxIcon.Stop:
                    //    SystemSounds.Asterisk.Play();
                    //    break;
            }
        }

        private void UpdateButtons()
        {
            switch (_buttons)
            {
                case MessageBoxButtons.OK:
                    _button1.Text = KryptonManager.Strings.OK;
                    _button1.DialogResult = DialogResult.OK;
                    _button1.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button2.Visible = _button3.Visible = false;
                    break;
                case MessageBoxButtons.OKCancel:
                    _button1.Text = KryptonManager.Strings.OK;
                    _button2.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.OK;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button3.Visible = false;
                    break;
                case MessageBoxButtons.YesNo:
                    _button1.Text = KryptonManager.Strings.Yes;
                    _button2.Text = KryptonManager.Strings.No;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button1.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button3.Visible = false;
                    ControlBox = false;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    _button1.Text = KryptonManager.Strings.Yes;
                    _button2.Text = KryptonManager.Strings.No;
                    _button3.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button3.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button3.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    break;
                case MessageBoxButtons.RetryCancel:
                    _button1.Text = KryptonManager.Strings.Retry;
                    _button2.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.Retry;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button3.Visible = false;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    _button1.Text = KryptonManager.Strings.Abort;
                    _button2.Text = KryptonManager.Strings.Retry;
                    _button3.Text = KryptonManager.Strings.Ignore;
                    _button1.DialogResult = DialogResult.Abort;
                    _button2.DialogResult = DialogResult.Retry;
                    _button3.DialogResult = DialogResult.Ignore;
                    _button1.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button3.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    ControlBox = false;
                    break;
            }

            // Do we ignore the Alt+F4 on the buttons?
            if (!ControlBox)
            {
                _button1.IgnoreAltF4 = true;
                _button2.IgnoreAltF4 = true;
                _button3.IgnoreAltF4 = true;
            }
        }

        private void UpdateDefault()
        {
            switch (_defaultButton)
            {
                case MessageBoxDefaultButton.Button2:
                    _button2.Select();
                    break;
                case MessageBoxDefaultButton.Button3:
                    _button3.Select();
                    break;
            }
        }

        private void UpdateHelp()
        {
        }

        private void UpdateSizing(IWin32Window showOwner)
        {
            Size messageSizing = UpdateMessageSizing(showOwner);
            Size buttonsSizing = UpdateButtonsSizing();

            // Size of window is calculated from the client area
            ClientSize = new Size(Math.Max(messageSizing.Width, buttonsSizing.Width),
                                  messageSizing.Height + buttonsSizing.Height);
        }

        private Size UpdateMessageSizing(IWin32Window? showOwner)
        {
            // Update size of the message label but with a maximum width
            using (Graphics g = CreateGraphics())
            {
                // Find size of the label, with a max of 2/3 screen width
                Screen screen = showOwner != null ? Screen.FromHandle(showOwner.Handle) : Screen.PrimaryScreen;
                SizeF scaledMonitorSize = screen.Bounds.Size;
                scaledMonitorSize.Width *= (2 / 3.0f);
                scaledMonitorSize.Height *= 0.95f;
                _messageText.UpdateFont();
                SizeF messageSize = g.MeasureString(_text, _messageText.Font, scaledMonitorSize);
                // SKC: Don't forget to add the TextExtra into the calculation
                SizeF captionSize = g.MeasureString($@"{_caption} {TextExtra}", _messageText.Font, scaledMonitorSize);

                float messageXSize = Math.Max(messageSize.Width, captionSize.Width);
                // Work out DPlatformInvoke adjustment factor
                float factorX = g.DpiX > 96 ? ((1.0f * g.DpiX) / 96) : 1.0f;
                float factorY = g.DpiX > 96 ? ((1.0f * g.DpiX) / 96) : 1.0f;
                messageSize.Width = messageXSize * factorX;
                messageSize.Height = messageSize.Height * factorY;

                // Always add on ad extra 5 PlatformInvokexels as sometimes the measure size does not draw the last 
                // character it contains, this ensures there is always definitely enough space for it all
                messageSize.Width += 5;
                _messageText.Size = Size.Ceiling(messageSize);
            }

            // Resize panel containing the message text
            Padding panelMessagePadding = _panelMessageText.Padding;
            _panelMessageText.Width = _messageText.Size.Width + panelMessagePadding.Horizontal;
            _panelMessageText.Height = _messageText.Size.Height + panelMessagePadding.Vertical;

            // Find size of icon area plus the text area added together
            Size panelSize = _panelMessageText.Size;
            if (_messageIcon.Image != null)
            {
                panelSize.Width += _panelMessageIcon.Width;
                panelSize.Height = Math.Max(panelSize.Height, _panelMessageIcon.Height);
            }

            // Enforce a minimum size for the message area
            panelSize = new Size(Math.Max(_panelMessage.Size.Width, panelSize.Width),
                                 Math.Max(_panelMessage.Size.Height, panelSize.Height));

            // Note that the width will be ignored in this update, but that is fine as 
            // it will be adjusted by the UpdateSizing method that is the caller.
            _panelMessage.Size = panelSize;
            return panelSize;
        }

        private Size UpdateButtonsSizing()
        {
            int numButtons = 1;

            // Button1 is always visible
            Size button1Size = _button1.GetPreferredSize(Size.Empty);
            Size maxButtonSize = new Size(button1Size.Width + GAP, button1Size.Height);

            // If Button2 is visible
            switch (_buttons)
            {
                case MessageBoxButtons.OKCancel:
                case MessageBoxButtons.YesNo:
                case MessageBoxButtons.YesNoCancel:
                case MessageBoxButtons.RetryCancel:
                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        numButtons++;
                        Size button2Size = _button2.GetPreferredSize(Size.Empty);
                        maxButtonSize.Width = Math.Max(maxButtonSize.Width, button2Size.Width + GAP);
                        maxButtonSize.Height = Math.Max(maxButtonSize.Height, button2Size.Height);
                    }
                    break;
            }

            // If Button3 is visible
            switch (_buttons)
            {
                case MessageBoxButtons.YesNoCancel:
                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        numButtons++;
                        Size button3Size = _button2.GetPreferredSize(Size.Empty);
                        maxButtonSize.Width = Math.Max(maxButtonSize.Width, button3Size.Width + GAP);
                        maxButtonSize.Height = Math.Max(maxButtonSize.Height, button3Size.Height);
                    }
                    break;
            }

            // Start positioning buttons 10 PlatformInvokexels from right edge
            int right = _panelButtons.Right - GAP;

            // If Button3 is visible
            switch (_buttons)
            {
                case MessageBoxButtons.YesNoCancel:
                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        _button3.Location = new Point(right - maxButtonSize.Width, GAP);
                        _button3.Size = maxButtonSize;
                        right -= maxButtonSize.Width + GAP;
                    }
                    break;
            }

            // If Button2 is visible
            switch (_buttons)
            {
                case MessageBoxButtons.OKCancel:
                case MessageBoxButtons.YesNo:
                case MessageBoxButtons.YesNoCancel:
                case MessageBoxButtons.RetryCancel:
                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        _button2.Location = new Point(right - maxButtonSize.Width, GAP);
                        _button2.Size = maxButtonSize;
                        right -= maxButtonSize.Width + GAP;
                    }
                    break;
            }

            // Button1 is always visible
            _button1.Location = new Point(right - maxButtonSize.Width, GAP);
            _button1.Size = maxButtonSize;

            // Size the panel for the buttons
            _panelButtons.Size = new Size((maxButtonSize.Width * numButtons) + (GAP * (numButtons + 1)), maxButtonSize.Height + (GAP * 2));

            // Button area is the number of buttons with gaps between them and 10 PlatformInvokexels around all edges
            return new Size((maxButtonSize.Width * numButtons) + (GAP * (numButtons + 1)), maxButtonSize.Height + (GAP * 2));
        }

        private void button_keyDown(object sender, KeyEventArgs e)
        {
            // Escape key kills the dialog if we allow it to be closed
            if ((e.KeyCode == Keys.Escape) && ControlBox)
            {
                Close();
            }
            else
            {
                // Pressing Ctrl+C should copy message text into the clipboard
                if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.C))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("---------------------------");
                    sb.AppendLine(_caption);
                    sb.AppendLine("---------------------------");
                    sb.AppendLine(_text);
                    sb.AppendLine("---------------------------");
                    sb.Append(_button1.Text);
                    sb.Append("   ");
                    if (_button2.Visible)
                    {
                        sb.Append(_button2.Text);
                        sb.Append("   ");
                        if (_button3.Visible)
                        {
                            sb.Append(_button3.Text);
                            sb.Append("   ");
                        }
                    }
                    sb.AppendLine("");
                    sb.AppendLine("---------------------------");

                    Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
                    Clipboard.SetText(sb.ToString(), TextDataFormat.UnicodeText);
                }
            }
        }
        #endregion
    }
}