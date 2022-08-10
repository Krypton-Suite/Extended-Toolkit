#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    internal partial class KryptonMessageBoxExtendedForm : KryptonForm
    {
        #region Static Fields
        private const int GAP = 10;
        private static readonly int OS_MAJOR_VERSION;
        #endregion

        #region Instance Fields
        private readonly string _text;
        private readonly string _caption;
        
        private readonly KryptonMessageBoxDefaultButton _defaultButton;
        private readonly MessageBoxOptions _options; // https://github.com/Krypton-Suite/Standard-Toolkit/issues/313
        // If help information provided or we are not a service/default desktop application then grab an owner for showing the message box
        private readonly IWin32Window _showOwner;
        private readonly HelpInfo _helpInfo;

        #endregion

        #region Extended Fields

        private readonly bool _showHelpButton;

        private readonly bool _showMoreDetailsUI;

        private readonly Color _messageTextColour;

        private readonly Color[] _buttonTextColours = new Color[4];

        private readonly DialogResult _buttonOneCustomDialogResult;

        private readonly DialogResult _buttonTwoCustomDialogResult;

        private readonly DialogResult _buttonThreeCustomDialogResult;

        private readonly DialogResult _buttonFourDialogResult;

        private readonly Font _messageBoxTypeface;

        private readonly ExtendedMessageBoxButtons _buttons;

        private readonly ExtendedKryptonMessageBoxIcon _kryptonMessageBoxIcon;

        private readonly int _maximumMoreDetailsDropDownHeight;

        private readonly Image _customKryptonMessageBoxIcon;

        private readonly string _collapseText;
        
        private readonly string _detailsText;

        private readonly string _expandText;

        private readonly string _buttonOneCustomText;

        private readonly string _buttonTwoCustomText;

        private readonly string _buttonThreeCustomText;

        private readonly string _buttonFourCustomText;
        #endregion

        #region Public

        public TableLayoutPanel ContentLayoutPanel { get => ktlpContent; }

        #endregion

        #region Identity
        static KryptonMessageBoxExtendedForm() => OS_MAJOR_VERSION = Environment.OSVersion.Version.Major;

        public KryptonMessageBoxExtendedForm()
        {
            InitializeComponent();
        }


        internal KryptonMessageBoxExtendedForm(IWin32Window showOwner, string text, string caption,
                                               ExtendedMessageBoxButtons buttons,
                                               ExtendedKryptonMessageBoxIcon kryptonMessageBoxIcon,
                                               KryptonMessageBoxDefaultButton defaultButton,
                                               MessageBoxOptions options,
                                               HelpInfo helpInfo, bool? showCtrlCopy,
                                               Font messageBoxTypeface, 
                                               Image customKryptonMessageBoxIcon, bool? showHelpButton,
                                               Color? messageTextColour, Color[] buttonTextColours,
                                               DialogResult? buttonOneCustomDialogResult,
                                               DialogResult? buttonTwoCustomDialogResult,
                                               DialogResult? buttonThreeCustomDialogResult,
                                               DialogResult? buttonFourDialogResult,
                                               string buttonOneCustomText, string buttonTwoCustomText,
                                               string buttonThreeCustomText, string buttonFourCustomText,
                                               bool? showMoreDetailsUI, string moreDetailsText,
                                               string collapseText, string expandText,
                                               int? maximumMoreDetailsDropDownHeight)
        {
            // Store incoming values
            _text = text;
            _caption = caption;
            _buttons = buttons;
            _kryptonMessageBoxIcon = kryptonMessageBoxIcon;
            _defaultButton = defaultButton;
            _options = options;
            _helpInfo = helpInfo;
            _showOwner = showOwner;

            // Extended values
            _showMoreDetailsUI = showMoreDetailsUI ?? false;
            _messageBoxTypeface = messageBoxTypeface ?? new Font("Segoe UI", 8.25F);
            _customKryptonMessageBoxIcon = customKryptonMessageBoxIcon;
            _showHelpButton = showHelpButton ?? false;
            _messageTextColour = messageTextColour ?? Color.Empty;
            _buttonTextColours = buttonTextColours;
            _buttonOneCustomDialogResult = buttonOneCustomDialogResult ?? DialogResult.Yes;
            _buttonTwoCustomDialogResult = buttonTwoCustomDialogResult ?? DialogResult.No;
            _buttonThreeCustomDialogResult = buttonThreeCustomDialogResult ?? DialogResult.Cancel;
            _buttonFourDialogResult = buttonFourDialogResult ?? DialogResult.Retry;
            _buttonOneCustomText = buttonOneCustomText ?? KryptonManager.Strings.Yes;
            _buttonTwoCustomText = buttonTwoCustomText ?? KryptonManager.Strings.No;
            _buttonThreeCustomText = buttonThreeCustomText ?? KryptonManager.Strings.Cancel;
            _buttonFourCustomText = buttonFourCustomText ?? KryptonManager.Strings.Retry;
            _detailsText = moreDetailsText;
            _collapseText = collapseText ?? KryptonManager.Strings.Collapse;
            _expandText = expandText ?? KryptonManager.Strings.Expand;
            _maximumMoreDetailsDropDownHeight = maximumMoreDetailsDropDownHeight ?? 250;

            // Create the form contents
            InitializeComponent();

            RightToLeftLayout = _options.HasFlag(MessageBoxOptions.RtlReading);

            // Update contents to match requirements
            UpdateText();
            UpdateIcon();
            UpdateButtons();
            UpdateDefault();
            UpdateHelp();
            UpdateTextExtra(showCtrlCopy);

            SetupMoreDetailsUI(_showMoreDetailsUI);

            // Finally calculate and set form sizing
            UpdateSizing(showOwner);
        }
        #endregion Identity

        #region Methods
        private void UpdateText()
        {
            Text = string.IsNullOrEmpty(_caption) ? string.Empty : _caption.Split(Environment.NewLine.ToCharArray())[0];

            _messageText.StateCommon.Font = _messageBoxTypeface;

            _messageText.StateCommon.TextColor = _messageTextColour;

            _messageText.Text = _text;
            _messageText.RightToLeft = _options.HasFlag(MessageBoxOptions.RightAlign)
                ? RightToLeft.Yes
                : _options.HasFlag(MessageBoxOptions.RtlReading)
                    ? RightToLeft.Inherit
                    : RightToLeft.No;
        }

        private void UpdateTextExtra(bool? showCtrlCopy)
        {
            if (!showCtrlCopy.HasValue)
            {
                switch (_kryptonMessageBoxIcon)
                {
                    case ExtendedKryptonMessageBoxIcon.Error:
                    case ExtendedKryptonMessageBoxIcon.Exclamation:
                        showCtrlCopy = true;
                        break;
                }
            }

            if (showCtrlCopy == true)
            {
                TextExtra = @"Ctrl+c to copy";
            }
        }

        private void UpdateIcon()
        {
            switch (_kryptonMessageBoxIcon)
            {
                default:
                case ExtendedKryptonMessageBoxIcon.None:
                    // Windows XP and before will Beep, Vista and above do not!
                    if (OS_MAJOR_VERSION < 6)
                    {
                        SystemSounds.Beep.Play();
                    }

                    break;
                case ExtendedKryptonMessageBoxIcon.Custom:
                    _messageIcon.Image = _customKryptonMessageBoxIcon;
                    break;
                case ExtendedKryptonMessageBoxIcon.Question:
                    _messageIcon.Image = Properties.Resources.Question;
                    SystemSounds.Question.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Exclamation:
                    _messageIcon.Image = Properties.Resources.Warning;
                    SystemSounds.Exclamation.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Information:
                    _messageIcon.Image = Properties.Resources.Information;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Warning:
                    _messageIcon.Image = Properties.Resources.Warning;
                    SystemSounds.Exclamation.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Error:
                    _messageIcon.Image = Properties.Resources.Critical;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Asterisk:
                    _messageIcon.Image = Properties.Resources.Asterisk;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Hand:
                    _messageIcon.Image = Properties.Resources.Hand;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Stop:
                    _messageIcon.Image = Properties.Resources.Stop;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Shield:
                    _messageIcon.Image = SystemIcons.Shield.ToBitmap();
                    break;
                case ExtendedKryptonMessageBoxIcon.WindowsLogo:
                    // Because Windows 11 displays a generic application icon,
                    // we need to rely on a image instead
                    if (Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= 22000)
                    {
                        _messageIcon.Image = Properties.Resources.Windows11;
                    }
                    // Windows 10
                    else if (Environment.OSVersion.Version.Major == 10 && Environment.OSVersion.Version.Build <= 19044 /* RTM - 21H2 */)
                    {
                        _messageIcon.Image = Properties.Resources.Windows_8_and_10_Logo;
                    }
                    else
                    {
                        _messageIcon.Image = SystemIcons.WinLogo.ToBitmap();
                    }

                    break;
            }

            _messageIcon.Visible = (_kryptonMessageBoxIcon != ExtendedKryptonMessageBoxIcon.None);

        }

        private void UpdateButtons()
        {
            switch (_buttons)
            {
                case ExtendedMessageBoxButtons.OK:
                    _button1.Text = KryptonManager.Strings.OK;
                    _button1.DialogResult = DialogResult.OK;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.OkCancel:
                    _button1.Text = KryptonManager.Strings.OK;
                    _button2.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.OK;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.YesNo:
                    _button1.Text = KryptonManager.Strings.Yes;
                    _button2.Text = KryptonManager.Strings.No;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    ControlBox = false;
                    break;
                case ExtendedMessageBoxButtons.YesNoCancel:
                    _button1.Text = KryptonManager.Strings.Yes;
                    _button2.Text = KryptonManager.Strings.No;
                    _button3.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button3.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button3.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button3.Visible = true;
                    _button3.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.RetryCancel:
                    _button1.Text = KryptonManager.Strings.Retry;
                    _button2.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.Retry;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.AbortRetryIgnore:
                    _button1.Text = KryptonManager.Strings.Abort;
                    _button2.Text = KryptonManager.Strings.Retry;
                    _button3.Text = KryptonManager.Strings.Ignore;
                    _button1.DialogResult = DialogResult.Abort;
                    _button2.DialogResult = DialogResult.Retry;
                    _button3.DialogResult = DialogResult.Ignore;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button3.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button3.Visible = true;
                    _button3.Enabled = true;
                    ControlBox = false;
                    break;
#if NET60_OR_GREATER
                case ExtendedMessageBoxButtons.CANCELTRYCONTINUE:
                    _button1.Text = KryptonManager.Strings.Cancel;
                    _button2.Text = KryptonManager.Strings.TryAgain;
                    _button3.Text = KryptonManager.Strings.Continue;
                    _button1.DialogResult = DialogResult.Cancel;
                    _button2.DialogResult = DialogResult.TryAgain;
                    _button3.DialogResult = DialogResult.Continue;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button3.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button3.Visible = true;
                    _button3.Enabled = true;
                    break;
#endif
            }

            if (_showMoreDetailsUI)
            {
                _buttonDetails.StateCommon.Content.ShortText.Font = _messageBoxTypeface;

                _buttonDetails.Visible = _showMoreDetailsUI;

                _buttonDetails.Text = _expandText;
            }    

            // Do we ignore the Alt+F4 on the buttons?
            if (!ControlBox)
            {
                _button1.IgnoreAltF4 = true;
                _button2.IgnoreAltF4 = true;
                _button3.IgnoreAltF4 = true;
                _button4.IgnoreAltF4 = true;
            }
        }

        private void UpdateDefault()
        {
            switch (_defaultButton)
            {
                case KryptonMessageBoxDefaultButton.Button1:
                    _button1.Focus();
                    break;
                case KryptonMessageBoxDefaultButton.Button2:
                    _button2.Focus();
                    break;
                case KryptonMessageBoxDefaultButton.Button3:
                    _button3.Focus();
                    break;
                case KryptonMessageBoxDefaultButton.Button4:
                    _button4.Focus();
                    break;
            }
        }

        private void UpdateHelp()
        {
            if (_helpInfo == null)
            {
                return;
            }

            MessageButton helpButton = _buttons switch
            {
                ExtendedMessageBoxButtons.OK => _button2,
                ExtendedMessageBoxButtons.OkCancel or ExtendedMessageBoxButtons.YesNo or ExtendedMessageBoxButtons.RetryCancel => _button3,
                ExtendedMessageBoxButtons.AbortRetryIgnore or ExtendedMessageBoxButtons.YesNoCancel => _button4,
                _ => throw new ArgumentOutOfRangeException()
            };
            if (helpButton != null)
            {
                helpButton.Visible = true;
                helpButton.Enabled = true;
                helpButton.Text = KryptonManager.Strings.Help;
                helpButton.KeyPress += (_, _) => LaunchHelp();
                helpButton.Click += (_, _) => LaunchHelp();
            }
        }

        /// <summary>
        /// When the user clicks the Help button, the Help file specified in the helpFilePath parameter
        /// is opened and the Help keyword topic identified by the keyword parameter is Displayed.
        /// The form that owns the message box (or the active form) also receives the HelpRequested event.
        /// </summary>
        private void LaunchHelp()
        {
            try
            {
                Control control = FromHandle(_showOwner.Handle);

                MethodInfo mInfoMethod = control.GetType().GetMethod(@"OnHelpRequested", BindingFlags.Instance | BindingFlags.NonPublic,
                    Type.DefaultBinder, new[] { typeof(HelpEventArgs) }, null);
                if (mInfoMethod != null)
                {
                    mInfoMethod.Invoke(control, new object[] { new HelpEventArgs(MousePosition) });
                }
                if (string.IsNullOrWhiteSpace(_helpInfo.HelpFilePath))
                {
                    return;
                }

                if (!string.IsNullOrWhiteSpace(_helpInfo.Keyword))
                {
                    Help.ShowHelp(control, _helpInfo.HelpFilePath, _helpInfo.Keyword);
                }
                else
                {
                    Help.ShowHelp(control, _helpInfo.HelpFilePath, _helpInfo.Navigator, _helpInfo.Param);
                }
            }
            catch
            {
                // Do nothing if failure to send to Parent
            }

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
            Size textSize;
            using (Graphics g = CreateGraphics())
            {
                // Find size of the label, with a max of 2/3 screen width
                Screen screen = showOwner != null ? Screen.FromHandle(showOwner.Handle) : Screen.PrimaryScreen;
                SizeF scaledMonitorSize = screen.Bounds.Size;
                scaledMonitorSize.Width *= 2 / 3.0f;
                scaledMonitorSize.Height *= 0.95f;
                _messageText.UpdateFont();
                SizeF messageSize = g.MeasureString(_text, _messageText.Font, scaledMonitorSize);
                // SKC: Don't forget to add the TextExtra into the calculation
                SizeF captionSize = g.MeasureString($@"{_caption} {TextExtra}", _messageText.Font, scaledMonitorSize);

                var messageXSize = Math.Max(messageSize.Width, captionSize.Width);
                // Work out DPI adjustment factor
                messageSize.Width = messageXSize * FactorDpiX;
                messageSize.Height *= FactorDpiY;

                // Always add on ad extra 5 pixels as sometimes the measure size does not draw the last 
                // character it contains, this ensures there is always definitely enough space for it all
                messageSize.Width += 5;
                textSize = Size.Ceiling(messageSize);
            }

            // Find size of icon area plus the text area added together
            if (_messageIcon.Image != null)
            {
                return new Size(textSize.Width + _messageIcon.Width, Math.Max(_messageIcon.Height + 10, textSize.Height));
            }

            return textSize;
        }

        private Size UpdateButtonsSizing()
        {
            var numButtons = 1;

            // Button1 is always visible
            Size button1Size = _button1.GetPreferredSize(Size.Empty);
            Size maxButtonSize = new(button1Size.Width + GAP, button1Size.Height);

            // If Button2 is visible
            if (_button2.Enabled)
            {
                numButtons++;
                Size button2Size = _button2.GetPreferredSize(Size.Empty);
                maxButtonSize.Width = Math.Max(maxButtonSize.Width, button2Size.Width + GAP);
                maxButtonSize.Height = Math.Max(maxButtonSize.Height, button2Size.Height);
            }

            // If Button3 is visible
            if (_button3.Enabled)
            {
                numButtons++;
                Size button3Size = _button3.GetPreferredSize(Size.Empty);
                maxButtonSize.Width = Math.Max(maxButtonSize.Width, button3Size.Width + GAP);
                maxButtonSize.Height = Math.Max(maxButtonSize.Height, button3Size.Height);
            }
            // If Button4 is visible
            if (_button4.Enabled)
            {
                numButtons++;
                Size button4Size = _button4.GetPreferredSize(Size.Empty);
                maxButtonSize.Width = Math.Max(maxButtonSize.Width, button4Size.Width + GAP);
                maxButtonSize.Height = Math.Max(maxButtonSize.Height, button4Size.Height);
            }

            // Start positioning buttons 10 pixels from right edge
            var right = _panelButtons.Right - GAP;

            // If Button4 is visible
            if (_button4.Enabled)
            {
                _button4.Location = new Point(right - maxButtonSize.Width, GAP);
                _button4.Size = maxButtonSize;
                right -= maxButtonSize.Width + GAP;
            }

            // If Button3 is visible
            if (_button3.Enabled)
            {
                _button3.Location = new Point(right - maxButtonSize.Width, GAP);
                _button3.Size = maxButtonSize;
                right -= maxButtonSize.Width + GAP;
            }

            // If Button2 is visible
            if (_button2.Enabled)
            {
                _button2.Location = new Point(right - maxButtonSize.Width, GAP);
                _button2.Size = maxButtonSize;
                right -= maxButtonSize.Width + GAP;
            }

            // Button1 is always visible
            _button1.Location = new Point(right - maxButtonSize.Width, GAP);
            _button1.Size = maxButtonSize;

            // Size the panel for the buttons
            _panelButtons.Size = new Size((maxButtonSize.Width * numButtons) + (GAP * (numButtons + 1)), maxButtonSize.Height + (GAP * 2));

            // Button area is the number of buttons with gaps between them and 10 pixels around all edges
            return new Size((maxButtonSize.Width * numButtons) + (GAP * (numButtons + 1)), maxButtonSize.Height + (GAP * 2));
        }

        private void AnyKeyDown(object sender, KeyEventArgs e)
        {
            // Escape key kills the dialog if we allow it to be closed
            if (ControlBox
                && (e.KeyCode == Keys.Escape)
                )
            {
                Close();
            }
            else if (!e.Control
                     || (e.KeyCode != Keys.C)
                     )
            {
                return;
            }

            const string DIVIDER = @"---------------------------";
            const string BUTTON_TEXT_SPACER = @"   ";

            // Pressing Ctrl+C should copy message text into the clipboard
            var sb = new StringBuilder();

            sb.AppendLine(DIVIDER);
            sb.AppendLine(Text);
            sb.AppendLine(DIVIDER);
            sb.AppendLine(_messageText.Text);
            sb.AppendLine(DIVIDER);
            sb.Append(_button1.Text).Append(BUTTON_TEXT_SPACER);
            if (_button2.Enabled)
            {
                sb.Append(_button2.Text).Append(BUTTON_TEXT_SPACER);
                if (_button3.Enabled)
                {
                    sb.Append(_button3.Text).Append(BUTTON_TEXT_SPACER);
                }

                if (_button4.Enabled)
                {
                    sb.Append(_button4.Text).Append(BUTTON_TEXT_SPACER);
                }
            }

            sb.AppendLine(string.Empty);
            sb.AppendLine(DIVIDER);

            Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
            Clipboard.SetText(sb.ToString(), TextDataFormat.UnicodeText);
        }

        private void MoreDetails_Click(object sender, EventArgs e) => UpdateMoreDetails();

        private void UpdateMoreDetails()
        {
            int currentHeight = Height;

            krtbDetails.StateCommon.Content.Font = _messageBoxTypeface;

            if (_buttonDetails.Text == _expandText)
            {
                _buttonDetails.Text = _collapseText;

                //ContentLayoutPanel.RowStyles[2].Height = 40;

                kpnlDetails.Height = _maximumMoreDetailsDropDownHeight;

                Height = currentHeight + kpnlDetails.Height;

                krtbDetails.Text = _detailsText;
            }
            else if (_buttonDetails.Text == _collapseText)
            {
                _buttonDetails.Text = _expandText;

                ContentLayoutPanel.RowStyles[2].Height = 0;

                Height = currentHeight;
            }
        }

        private void SetupMoreDetailsUI(bool showUI)
        {
            _buttonDetails.Visible = showUI;

            _buttonDetails.Text = "E&xpand";

            if (showUI)
            {
                ContentLayoutPanel.RowStyles[2].Height = 0;
            }
        }
        #endregion

    }
}