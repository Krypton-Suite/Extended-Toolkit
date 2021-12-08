#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Settings.Resources;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    /// <summary>
    /// Displays a message box that can contain text, buttons, and symbols that inform and instruct the user.
    /// Allows optional Font to be specified, if not then new Font(@"Segoe UI", 12F) will be used
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ExtendedKryptonMessageBox), "ToolboxBitmaps.KryptonMessageBox.bmp")]
    [DesignerCategory("code")]
    [DesignTimeVisible(false)]
    internal class ExtendedKryptonMessageBox : KryptonForm
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
            _doNotShowAgainOption = new KryptonCheckBox();
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
            _panelButtons.Controls.Add(_doNotShowAgainOption);
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
            // _doNotShowAgainOption
            //
            _doNotShowAgainOption.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            _doNotShowAgainOption.AutoSize = true;
            _doNotShowAgainOption.Location = new Point(56, 0);
            _doNotShowAgainOption.Margin = new Padding(0);
            _doNotShowAgainOption.MinimumSize = new Size(50, 26);
            _doNotShowAgainOption.Name = "_doNotShowAgainOption";
            _doNotShowAgainOption.Size = new Size(50, 26);
            _doNotShowAgainOption.TabIndex = 1;
            _doNotShowAgainOption.Values.Text = @"&Do not show this again";
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
            Name = "ExtendedKryptonMessageBox";
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
        private HelpInformation _helpInformation; // TODO: What is this used for ?
        private Font _messageboxTypeface;
        private int _timeOut, _timeOutTimerDelay;
        private Timer _timer;
        private KryptonCheckBox _doNotShowAgainOption;
        private string _doNotShowAgainOptionText;
        private bool _doNotShowAgainOptionResult, _showDoNotShowAgainOption, _useTimeOutOption;
        private DialogResult _defaultTimeOutResponse;
        #endregion

        #region Static Fields
        private const int GAP = 10;
        private const string NULL_TEXT = "";
        private static readonly int _osMajorVersion;
        private const DialogResult DEFAULT_TIMEOUT_DIALOG_RESPONSE = DialogResult.None;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets a value indicating whether [do not show again option result].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [do not show again option result]; otherwise, <c>false</c>.
        /// </value>
        public bool DoNotShowAgainOptionResult { get { return _doNotShowAgainOptionResult; } set { _doNotShowAgainOptionResult = value; } }

        public bool ShowDoNotShowAgainOption { get { return _showDoNotShowAgainOption; } set { _showDoNotShowAgainOption = value; } }

        public bool UseTimeOutOption { get { return _useTimeOutOption; } set { _useTimeOutOption = value; } }

        public DialogResult DefaultTimeOutResponse { get { return _defaultTimeOutResponse; } set { _defaultTimeOutResponse = value; } }

        /// <summary>
        /// Gets or sets the message box typeface.
        /// </summary>
        /// <value>
        /// The message box typeface.
        /// </value>
        public Font MessageBoxTypeface { get { return _messageboxTypeface; } set { _messageboxTypeface = value; } }

        /// <summary>
        /// Gets or sets the time out for the <see cref="ExtendedKryptonMessageBox"/>.
        /// </summary>
        /// <value>
        /// The time out.
        /// </value>
        public int TimeOut { get { return _timeOut; } set { _timeOut = value; } }

        /// <summary>
        /// Gets or sets the time out timer delay.
        /// </summary>
        /// <value>
        /// The time out timer delay.
        /// </value>
        public int TimeOutTimerDelay { get { return _timeOutTimerDelay; } set { _timeOutTimerDelay = value; } }

        /// <summary>
        /// Gets or sets the do not show again option text.
        /// </summary>
        /// <value>
        /// The do not show again option text.
        /// </value>
        public string DoNotShowAgainOptionText { get { return _doNotShowAgainOptionText; } set { _doNotShowAgainOptionText = value; } }
        #endregion

        #region Internal Classes
        /// <summary>
        /// What is this class for?
        /// </summary>
        internal class HelpInformation
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
            /// Initialize a new instance of the HelpInformation class.
            /// </summary>
            public HelpInformation()
            {
            }

            /// <summary>
            /// Initialize a new instance of the HelpInformation class.
            /// </summary>
            /// <param name="helpFilePath">Value for HelpFilePath.</param>
            public HelpInformation(string helpFilePath)
            {
                HelpFilePath = helpFilePath;
            }

            /// <summary>
            /// Initialize a new instance of the HelpInformation class.
            /// </summary>
            /// <param name="helpFilePath">Value for HelpFilePath.</param>
            /// <param name="keyword">Value for Keyword</param>
            public HelpInformation(string helpFilePath, string keyword)
            {
                HelpFilePath = helpFilePath;
                Keyword = keyword;
            }

            /// <summary>
            /// Initialize a new instance of the HelpInformation class.
            /// </summary>
            /// <param name="helpFilePath">Value for HelpFilePath.</param>
            /// <param name="navigator">Value for Navigator</param>
            public HelpInformation(string helpFilePath, HelpNavigator navigator)
            {
                HelpFilePath = helpFilePath;
                Navigator = navigator;
            }

            /// <summary>
            /// Initialize a new instance of the HelpInformation class.
            /// </summary>
            /// <param name="helpFilePath">Value for HelpFilePath.</param>
            /// <param name="navigator">Value for Navigator</param>
            /// <param name="param">Value for Param</param>
            public HelpInformation(string helpFilePath, HelpNavigator navigator, object param)
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
                    case PI.WM_KEYDOWN:
                    case PI.WM_SYSKEYDOWN:
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
        static ExtendedKryptonMessageBox()
        {
            _osMajorVersion = Environment.OSVersion.Version.Major;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedKryptonMessageBox"/> class.
        /// </summary>
        /// <param name="showOwner">The show owner. (Can be null)</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption. (Can be null)</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="helpInformation">The help information.</param>
        /// <param name="showCtrlCopy">The show control copy. (Can be null)</param>
        /// <param name="topMost">Sets the topmost position.</param>
        /// <param name="messageboxTypeface">The messagebox typeface. (Can be null)</param>
        /// <param name="showDoNotShowAgainOption">Enables the UI elements for a "Do not show again" checkbox.</summary>
        /// <param name="doNotShowAgainOptionText">Specify the text on the "Do not show again" checkbox. (Default is "Do not show again")</summary>
        /// <param name="useTimeOutOption">Use a time out on the messagebox. (Default is set as false)</param>
        /// <param name="timeOut">Specify the time out time. (Default is set at 60 seconds)</param>
        /// <param name="timeOutDelay">Specify the time out delay timer. (Default is 250 milliseconds)</param>
        /// <param name="defaultTimeOutResponse">The default response on time out. (Default is OK)</param>
        /// <param name="button1Text">Sets the text on button 1. (Can be null)</param>
        /// <param name="button2Text">Sets the text on button 2. (Can be null)</param>
        /// <param name="button3Text">Sets the text on button 3. (Can be null)</param>
        private ExtendedKryptonMessageBox(IWin32Window showOwner, string text, string caption,
            MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton,
            MessageBoxOptions options, HelpInformation helpInformation, bool? showCtrlCopy, bool topMost,
            Font messageboxTypeface, bool showDoNotShowAgainOption, string doNotShowAgainOptionText,
            bool useTimeOutOption, int timeOut, int timeOutDelay, DialogResult defaultTimeOutResponse,
            string button1Text, string button2Text, string button3Text)
        {
            #region Store Values
            _text = text;

            _caption = caption;

            _buttons = buttons;

            _icon = icon;

            _defaultButton = defaultButton;

            _options = options;

            _helpInformation = helpInformation;

            TopMost = topMost;

            MessageBoxTypeface = messageboxTypeface ?? new Font(@"Segoe UI", 12F);

            ShowDoNotShowAgainOption = showDoNotShowAgainOption;

            DoNotShowAgainOptionText = doNotShowAgainOptionText;

            UseTimeOutOption = _useTimeOutOption;

            TimeOut = timeOut;

            TimeOutTimerDelay = timeOutDelay;

            #endregion

            // Create the form contents
            InitialiseComponent();

            // Update contents to match requirements
            UpdateText();

            UpdateIcon();

            if (button1Text == null && button2Text == null && button3Text == null)
            {
                UpdateButtons();
            }
            else
            {
                // More work needed
                UpdateButtons(button1Text, button2Text, button3Text);
            }

            UpdateDefault();

            UpdateHelp();

            SetUpShowDoNotShowAgainOptionElements(showDoNotShowAgainOption, doNotShowAgainOptionText);

            SetUpTimeOutDelayTimer(useTimeOutOption, timeOutDelay, new Timer());

            UpdateTextExtra(showCtrlCopy);

            // Finally calculate and set form sizing
            UpdateSizing(showOwner);

            // Arrange the 'Z' order, based on topmost
            if (topMost)
            {
                BringToFront();
            }
            else
            {
                SendToBack();
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed ToolkitSettingsResources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged ToolkitSettingsResources; <c>false</c> to release only unmanaged ToolkitSettingsResources.</param>
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
        public static DialogResult Show(string text, bool? showCtrlCopy = null, Font messageboxTypeface = null, bool topMost = true)
        {
            return InternalShow(null, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, topMost, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box in front of the specified object and with the specified text.
        /// </summary>
        /// <param name="owner">Owner of the modal dialog box.</param>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner, string text, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(owner, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, topMost, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with specified text and caption.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, topMost, messageboxTypeface);
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
                                        string text, string caption, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, topMost, messageboxTypeface);
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
                                        MessageBoxButtons buttons, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, topMost, messageboxTypeface);
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
                                        MessageBoxButtons buttons, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, topMost, messageboxTypeface);
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
                                        MessageBoxButtons buttons, MessageBoxIcon icon, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, topMost, messageboxTypeface);
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
                                        MessageBoxButtons buttons, MessageBoxIcon icon, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, topMost, messageboxTypeface);
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
                                        MessageBoxDefaultButton defaultButton, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, 0, null, showCtrlCopy, topMost, messageboxTypeface);
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
                                        MessageBoxDefaultButton defaultButton, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, 0, null, showCtrlCopy, topMost, messageboxTypeface);
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
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, null, showCtrlCopy, topMost, messageboxTypeface);
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
                                        MessageBoxButtons buttons, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null, string button1Text = null, string button2Text = null, string button3Text = null)
        {
            return InternalShow(null, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, topMost, messageboxTypeface, false, NULL_TEXT, false, 60, 250, DialogResult.OK, button1Text, button2Text, button3Text);
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
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, null, showCtrlCopy, topMost, messageboxTypeface);
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
                                        bool displayHelpButton, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, displayHelpButton ? new HelpInformation() : null, showCtrlCopy, topMost, messageboxTypeface);
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
                                        string helpFilePath, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelpInformation(helpFilePath), showCtrlCopy, topMost, messageboxTypeface);
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
                                        string helpFilePath, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelpInformation(helpFilePath), showCtrlCopy, topMost, messageboxTypeface);
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
                                        string helpFilePath, HelpNavigator navigator, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelpInformation(helpFilePath, navigator), showCtrlCopy, topMost, messageboxTypeface);
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
                                        string helpFilePath, string keyword, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelpInformation(helpFilePath, keyword), showCtrlCopy, topMost, messageboxTypeface);
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
                                        string helpFilePath, HelpNavigator navigator, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelpInformation(helpFilePath, navigator), showCtrlCopy, topMost, messageboxTypeface);
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
                                        string helpFilePath, string keyword, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelpInformation(helpFilePath, keyword), showCtrlCopy, topMost, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file, HelpNavigator, and Help topic.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">One of the System.Windows.Forms.MessageBoxButtons values that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the System.Windows.Forms.MessageBoxIcon values that specifies which icon to display in the message box.</param>
        /// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
        /// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
        /// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
        /// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
        /// <param name="param">The numeric ID of the Help topic to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, HelpNavigator navigator, object param, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelpInformation(helpFilePath, navigator, param), showCtrlCopy, topMost, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file, HelpNavigator, and Help topic.
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
        /// <param name="param">The numeric ID of the Help topic to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">Defines the messagebox font.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, HelpNavigator navigator, object param, bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelpInformation(helpFilePath, navigator, param), showCtrlCopy, topMost, messageboxTypeface);
        }

        /// <summary>
        /// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file, HelpNavigator, and Help topic.
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
        /// <param name="param">The numeric ID of the Help topic to display when the user clicks the Help button.</param>
        /// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
        /// <param name="messageboxTypeface">Defines the messagebox font.</param>
        /// <param name="showDoNotShowAgainOption">Displays the 'Do not show again' UI elements.</param>
        /// <param name="doNotShowAgainOptionText">Set your own 'Do not show again' text.</param>
        /// <param name="useTimeOutOption">Use the time out feature.</param>
        /// <param name="timeOut">Seconds until time out.</param>
        /// <param name="timeOutDelay">The timer interval.</param>
        /// <param name="defaultTimeOutResponse">What should the response be after timeout?</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner,
                                        string text, string caption,
                                        MessageBoxButtons buttons, MessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
                                        string helpFilePath, HelpNavigator navigator, object param,
                                        bool? showCtrlCopy = null, bool topMost = true, Font messageboxTypeface = null, bool showDoNotShowAgainOption = false,
                                        string doNotShowAgainOptionText = "Do n&ot show again", bool useTimeOutOption = false,
                                        int timeOut = 60, int timeOutDelay = 250,
                                        DialogResult defaultTimeOutResponse = DialogResult.OK)
        {
            return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelpInformation(helpFilePath, navigator, param), showCtrlCopy, topMost, messageboxTypeface, showDoNotShowAgainOption, doNotShowAgainOptionText, useTimeOutOption, timeOut, timeOutDelay, defaultTimeOutResponse);
        }
        #endregion

        #region Implementation
        private static DialogResult InternalShow(IWin32Window owner,
                                                 string text, string caption,
                                                 MessageBoxButtons buttons,
                                                 MessageBoxIcon icon,
                                                 MessageBoxDefaultButton defaultButton,
                                                 MessageBoxOptions options,
                                                 HelpInformation helpInformation, bool? showCtrlCopy, bool topMost, Font messageboxTypeface = null,
                                                 bool showDoNotShowAgainOption = false, string doNotShowAgainOptionText = "Do n&ot show again",
                                                 bool useTimeOutOption = false, int timeOut = 60, int timeOutDelay = 250,
                                                 DialogResult defaultTimeOutResponse = DialogResult.OK,
                                                 string button1Text = null, string button2Text = null, string button3Text = null)
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
            if ((helpInformation != null) && ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0))
            {
                throw new ArgumentException(@"Cannot show message box from a service with help specified", nameof(options));
            }

            // If help information provided or we are not a service/default desktop application then grab an owner for showing the message box
            IWin32Window showOwner = null;
            if ((helpInformation != null) || ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0))
            {
                // If do not have an owner passed in then get the active window and use that instead
                showOwner = owner ?? FromHandle(PI.GetActiveWindow());
            }

            // Show message box window as a modal dialog and then dispose of it afterwards
            using (ExtendedKryptonMessageBox ekmb = new ExtendedKryptonMessageBox(showOwner, text, caption, buttons, icon, defaultButton, options, helpInformation, showCtrlCopy, topMost, messageboxTypeface, showDoNotShowAgainOption, doNotShowAgainOptionText, useTimeOutOption, timeOut, timeOutDelay, defaultTimeOutResponse, button1Text, button2Text, button3Text))
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
                    _messageIcon.Image = ToolkitSettingsResources.Question_32_x_32;
                    SystemSounds.Question.Play();
                    break;
                case MessageBoxIcon.Information:
                    _messageIcon.Image = ToolkitSettingsResources.Information_32_x_32;
                    SystemSounds.Asterisk.Play();
                    break;
                case MessageBoxIcon.Warning:
                    _messageIcon.Image = ToolkitSettingsResources.Warning_32_x_32;
                    SystemSounds.Exclamation.Play();
                    break;
                case MessageBoxIcon.Error:
                    _messageIcon.Image = ToolkitSettingsResources.Critical_32_x_32;
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

        private void UpdateButtons(bool timeOutTimerEnabled, int timeOut, DialogResult defaultTimeOutResponse, MessageBoxDefaultButton defaultTimeOutButton)
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

            // Time out logic
            if (defaultTimeOutButton == MessageBoxDefaultButton.Button1)
            {
                _button1.Text = $"{ _button1.Text } ({ timeOut.ToString() })";
            }
            else if (defaultTimeOutButton == MessageBoxDefaultButton.Button2)
            {
                _button2.Text = $"{ _button2.Text } ({ timeOut.ToString() })";
            }
            else if (defaultTimeOutButton == MessageBoxDefaultButton.Button3)
            {
                _button3.Text = $"{ _button3.Text } ({ timeOut.ToString() })";
            }

            // Do we ignore the Alt+F4 on the buttons?
            if (!ControlBox)
            {
                _button1.IgnoreAltF4 = true;
                _button2.IgnoreAltF4 = true;
                _button3.IgnoreAltF4 = true;
            }
        }

        private void UpdateButtons(string button1Text, string button2Text, string button3Text)
        {
            switch (_buttons)
            {
                case MessageBoxButtons.OK:
                    _button1.Text = button1Text;
                    _button1.DialogResult = DialogResult.OK;
                    _button1.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button2.Visible = _button3.Visible = false;
                    break;
                case MessageBoxButtons.OKCancel:
                    _button1.Text = button1Text;
                    _button2.Text = button2Text;
                    _button1.DialogResult = DialogResult.OK;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button3.Visible = false;
                    break;
                case MessageBoxButtons.YesNo:
                    _button1.Text = button1Text;
                    _button2.Text = button2Text;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button1.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button3.Visible = false;
                    ControlBox = false;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    _button1.Text = button1Text;
                    _button2.Text = button2Text;
                    _button3.Text = button3Text;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button3.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button3.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    break;
                case MessageBoxButtons.RetryCancel:
                    _button1.Text = button1Text;
                    _button2.Text = button2Text;
                    _button1.DialogResult = DialogResult.Retry;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = MessageBoxTypeface;
                    _button3.Visible = false;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    _button1.Text = button1Text;
                    _button2.Text = button2Text;
                    _button3.Text = button3Text;
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

        private void SetUpShowDoNotShowAgainOptionElements(bool visible, string doNotShowAgainOptionText)
        {
            // Set visibility
            _doNotShowAgainOption.Visible = visible;

            // Set text
            _doNotShowAgainOption.Text = doNotShowAgainOptionText;

            // Set typeface based on MessageBoxTypeface
            _doNotShowAgainOption.StateCommon.ShortText.Font = MessageBoxTypeface;

            // Set up checked changed event
            _doNotShowAgainOption.CheckedChanged += new EventHandler(DoNotShowAgainOption_CheckedChanged);
        }

        private void SetUpTimeOutDelayTimer(bool enabled, int ticksInMilliseconds, Timer timeOutTimer)
        {
            // Initialise a new timer
            timeOutTimer = new Timer();

            // Enables the time out timer based on passed arguements
            timeOutTimer.Enabled = enabled;

            // Set the interval based on the passed arguements
            timeOutTimer.Interval = ticksInMilliseconds;

            // Setup the Tick event for the 'timeOutTimer'
            timeOutTimer.Tick += new EventHandler(TimeOutTimer_Tick);
        }

        private void UpdateSizing(IWin32Window showOwner)
        {
            Size messageSizing = UpdateMessageSizing(showOwner);
            Size buttonsSizing = UpdateButtonsSizing();

            // Size of window is calculated from the client area
            ClientSize = new Size(Math.Max(messageSizing.Width, buttonsSizing.Width),
                                  messageSizing.Height + buttonsSizing.Height);
        }

        private Size UpdateMessageSizing(IWin32Window showOwner)
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
                // Work out DPI adjustment factor
                float factorX = g.DpiX > 96 ? ((1.0f * g.DpiX) / 96) : 1.0f;
                float factorY = g.DpiY > 96 ? ((1.0f * g.DpiY) / 96) : 1.0f;
                messageSize.Width = messageXSize * factorX;
                messageSize.Height = messageSize.Height * factorY;

                // Always add on ad extra 5 pixels as sometimes the measure size does not draw the last 
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

            // Start positioning buttons 10 pixels from right edge
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

            // Button area is the number of buttons with gaps between them and 10 pixels around all edges
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

        #region Events
        private void DoNotShowAgainOption_CheckedChanged(object sender, EventArgs e)
        {
            DoNotShowAgainOptionResult = _doNotShowAgainOption.Checked;
        }

        private void TimeOutTimer_Tick(object sender, EventArgs e)
        {
            //? TODO: Update button text
            while (TimeOut > 0)
            {
                TimeOut--;

                UpdateButtons(UseTimeOutOption, TimeOut, DefaultTimeOutResponse, _defaultButton);
            }

            if (TimeOut == 0)
            {
                Hide(); // May need to find a more elegant solution
            }
        }
        #endregion
    }
}