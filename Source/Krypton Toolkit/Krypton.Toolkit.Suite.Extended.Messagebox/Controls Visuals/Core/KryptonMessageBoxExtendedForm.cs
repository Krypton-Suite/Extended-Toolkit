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

        private readonly bool _showOptionalCheckBox;

        private readonly bool _showOptionalLinkLabel;

        private readonly bool _showHelpButton;

        private readonly bool _showMoreDetailsUI;

        private readonly Color _messageTextColour;

        private readonly Color[] _buttonTextColours = new Color[4];

        private /*readonly*/ CheckState _optionalCheckBoxCheckState;

        private readonly DialogResult _buttonOneCustomDialogResult;

        private readonly DialogResult _buttonTwoCustomDialogResult;

        private readonly DialogResult _buttonThreeCustomDialogResult;

        private readonly DialogResult _buttonFourDialogResult;

        private readonly Font _messageBoxTypeface;

        private readonly ExtendedMessageBoxButtons _buttons;

        private readonly ExtendedKryptonMessageBoxIcon _kryptonMessageBoxIcon;

        private readonly KryptonCommand _linkCommand;

        private readonly int _maximumMoreDetailsDropDownHeight;

        private readonly Image _customKryptonMessageBoxIcon;

        private readonly string _collapseText;
        
        private readonly string _detailsText;

        private readonly string _expandText;

        private readonly string _buttonOneCustomText;

        private readonly string _buttonTwoCustomText;

        private readonly string _buttonThreeCustomText;

        private readonly string _buttonFourCustomText;

        private readonly string _optionalCheckBoxText;

        private readonly string _optionalLinkLabelText;

        private readonly string _optionalLinkLabelURL;

        #endregion

        #region Public

        /// <summary>Gets the state of the optional CheckBox check state.</summary>
        /// <value>The state of the optional CheckBox check state.</value>
        public CheckState OptionalCheckBoxCheckState { get => _optionalCheckBoxCheckState; private set => _optionalCheckBoxCheckState = value; }

        /// <summary>Gets the content layout panel.</summary>
        /// <value>The content layout panel.</value>
        public TableLayoutPanel ContentLayoutPanel => ktlpContent;

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
                                               int? maximumMoreDetailsDropDownHeight, 
                                               bool? showOptionalCheckBox, 
                                               CheckState? optionalCheckBoxCheckState,
                                               bool? showOptionalLinkLabel, 
                                               KryptonCommand linkCommand, 
                                               string optionalCheckBoxText, 
                                               string optionalLinkLabelText,
                                               string optionalLinkLabelURL)
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
            if (Environment.OSVersion.Version.Build >= 22000)
            {
                _messageBoxTypeface = messageBoxTypeface ?? new Font(@"Segoe UI Variable", 8.25F);
            }
            else
            {
                _messageBoxTypeface = messageBoxTypeface ?? new Font(@"Segoe UI", 8.25F);
            }

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
            _showOptionalCheckBox = showOptionalCheckBox ?? false;
            _showOptionalLinkLabel = showOptionalLinkLabel ?? false;
            _optionalCheckBoxCheckState = optionalCheckBoxCheckState ?? CheckState.Unchecked;
            _linkCommand = linkCommand;
            _optionalCheckBoxText = optionalCheckBoxText;
            _optionalLinkLabelText = optionalLinkLabelText;
            _optionalLinkLabelURL = optionalLinkLabelURL;

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

            SetupOptionalCheckBoxUI(_showOptionalCheckBox);

            SetupOptionalLinkLabelUI(_showOptionalLinkLabel);

            // Finally calculate and set form sizing
            UpdateSizing(showOwner);
        }
        #endregion Identity

        #region Methods
        private void UpdateText()
        {
            Text = string.IsNullOrEmpty(_caption) ? string.Empty : _caption.Split(Environment.NewLine.ToCharArray())[0];

            kwlMessageText.StateCommon.Font = _messageBoxTypeface;

            kwlMessageText.StateCommon.TextColor = _messageTextColour;

            kwlMessageText.Text = _text;
            kwlMessageText.RightToLeft = _options.HasFlag(MessageBoxOptions.RightAlign)
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
                    pbxMessageIcon.Image = _customKryptonMessageBoxIcon;
                    break;
                case ExtendedKryptonMessageBoxIcon.Question:
                    pbxMessageIcon.Image = Properties.Resources.Question;
                    SystemSounds.Question.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Exclamation:
                    pbxMessageIcon.Image = Properties.Resources.Warning;
                    SystemSounds.Exclamation.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Information:
                    pbxMessageIcon.Image = Properties.Resources.Information;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Warning:
                    pbxMessageIcon.Image = Properties.Resources.Warning;
                    SystemSounds.Exclamation.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Error:
                    pbxMessageIcon.Image = Properties.Resources.Critical;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Asterisk:
                    pbxMessageIcon.Image = Properties.Resources.Asterisk;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Hand:
                    pbxMessageIcon.Image = Properties.Resources.Hand;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Stop:
                    pbxMessageIcon.Image = Properties.Resources.Stop;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Shield:
                    pbxMessageIcon.Image = SystemIcons.Shield.ToBitmap();
                    break;
                case ExtendedKryptonMessageBoxIcon.WindowsLogo:
                    // Because Windows 11 displays a generic application icon,
                    // we need to rely on a image instead
                    if (Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= 22000)
                    {
                        pbxMessageIcon.Image = Properties.Resources.Windows11;
                    }
                    // Windows 10
                    else if (Environment.OSVersion.Version.Major == 10 && Environment.OSVersion.Version.Build <= 19044 /* RTM - 21H2 */)
                    {
                        pbxMessageIcon.Image = Properties.Resources.Windows_8_and_10_Logo;
                    }
                    else
                    {
                        pbxMessageIcon.Image = SystemIcons.WinLogo.ToBitmap();
                    }

                    break;
            }

            pbxMessageIcon.Visible = (_kryptonMessageBoxIcon != ExtendedKryptonMessageBoxIcon.None);

        }

        private void UpdateButtons()
        {
            switch (_buttons)
            {
                case ExtendedMessageBoxButtons.OK:
                    mbButton1.Text = KryptonManager.Strings.OK;
                    mbButton1.DialogResult = DialogResult.OK;
                    mbButton1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton1.Visible = true;
                    mbButton1.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.OkCancel:
                    mbButton1.Text = KryptonManager.Strings.OK;
                    mbButton2.Text = KryptonManager.Strings.Cancel;
                    mbButton1.DialogResult = DialogResult.OK;
                    mbButton2.DialogResult = DialogResult.Cancel;
                    mbButton1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton1.Visible = true;
                    mbButton1.Enabled = true;
                    mbButton2.Visible = true;
                    mbButton2.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.YesNo:
                    mbButton1.Text = KryptonManager.Strings.Yes;
                    mbButton2.Text = KryptonManager.Strings.No;
                    mbButton1.DialogResult = DialogResult.Yes;
                    mbButton2.DialogResult = DialogResult.No;
                    mbButton1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton1.Visible = true;
                    mbButton1.Enabled = true;
                    mbButton2.Visible = true;
                    mbButton2.Enabled = true;
                    ControlBox = false;
                    break;
                case ExtendedMessageBoxButtons.YesNoCancel:
                    mbButton1.Text = KryptonManager.Strings.Yes;
                    mbButton2.Text = KryptonManager.Strings.No;
                    mbButton3.Text = KryptonManager.Strings.Cancel;
                    mbButton1.DialogResult = DialogResult.Yes;
                    mbButton2.DialogResult = DialogResult.No;
                    mbButton3.DialogResult = DialogResult.Cancel;
                    mbButton1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton3.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton1.Visible = true;
                    mbButton1.Enabled = true;
                    mbButton2.Visible = true;
                    mbButton2.Enabled = true;
                    mbButton3.Visible = true;
                    mbButton3.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.RetryCancel:
                    mbButton1.Text = KryptonManager.Strings.Retry;
                    mbButton2.Text = KryptonManager.Strings.Cancel;
                    mbButton1.DialogResult = DialogResult.Retry;
                    mbButton2.DialogResult = DialogResult.Cancel;
                    mbButton1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton1.Visible = true;
                    mbButton1.Enabled = true;
                    mbButton2.Visible = true;
                    mbButton2.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.AbortRetryIgnore:
                    mbButton1.Text = KryptonManager.Strings.Abort;
                    mbButton2.Text = KryptonManager.Strings.Retry;
                    mbButton3.Text = KryptonManager.Strings.Ignore;
                    mbButton1.DialogResult = DialogResult.Abort;
                    mbButton2.DialogResult = DialogResult.Retry;
                    mbButton3.DialogResult = DialogResult.Ignore;
                    mbButton1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton3.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton1.Visible = true;
                    mbButton1.Enabled = true;
                    mbButton2.Visible = true;
                    mbButton2.Enabled = true;
                    mbButton3.Visible = true;
                    mbButton3.Enabled = true;
                    ControlBox = false;
                    break;
#if NET60_OR_GREATER
                case ExtendedMessageBoxButtons.CANCELTRYCONTINUE:
                    mbButton1.Text = KryptonManager.Strings.Cancel;
                    mbButton2.Text = KryptonManager.Strings.TryAgain;
                    mbButton3.Text = KryptonManager.Strings.Continue;
                    mbButton1.DialogResult = DialogResult.Cancel;
                    mbButton2.DialogResult = DialogResult.TryAgain;
                    mbButton3.DialogResult = DialogResult.Continue;
                    mbButton1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton3.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    mbButton1.Visible = true;
                    mbButton1.Enabled = true;
                    mbButton2.Visible = true;
                    mbButton2.Enabled = true;
                    mbButton3.Visible = true;
                    mbButton3.Enabled = true;
                    break;
#endif
            }

            if (_showMoreDetailsUI)
            {
                mbMoreDetails.StateCommon.Content.ShortText.Font = _messageBoxTypeface;

                mbMoreDetails.Visible = _showMoreDetailsUI;

                mbMoreDetails.Enabled = _showMoreDetailsUI;

                mbMoreDetails.Text = _expandText;
            }    

            // Do we ignore the Alt+F4 on the buttons?
            if (!ControlBox)
            {
                mbButton1.IgnoreAltF4 = true;
                mbButton2.IgnoreAltF4 = true;
                mbButton3.IgnoreAltF4 = true;
                mbButton4.IgnoreAltF4 = true;
            }
        }

        private void UpdateDefault()
        {
            switch (_defaultButton)
            {
                case KryptonMessageBoxDefaultButton.Button1:
                    mbButton1.Focus();
                    break;
                case KryptonMessageBoxDefaultButton.Button2:
                    mbButton2.Focus();
                    break;
                case KryptonMessageBoxDefaultButton.Button3:
                    mbButton3.Focus();
                    break;
                case KryptonMessageBoxDefaultButton.Button4:
                    mbButton4.Focus();
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
                ExtendedMessageBoxButtons.OK => mbButton2,
                ExtendedMessageBoxButtons.OkCancel or ExtendedMessageBoxButtons.YesNo or ExtendedMessageBoxButtons.RetryCancel => mbButton3,
                ExtendedMessageBoxButtons.AbortRetryIgnore or ExtendedMessageBoxButtons.YesNoCancel => mbButton4,
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
                kwlMessageText.UpdateFont();
                SizeF messageSize = g.MeasureString(_text, kwlMessageText.Font, scaledMonitorSize);
                // SKC: Don't forget to add the TextExtra into the calculation
                SizeF captionSize = g.MeasureString($@"{_caption} {TextExtra}", kwlMessageText.Font, scaledMonitorSize);

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
            if (pbxMessageIcon.Image != null)
            {
                return new Size(textSize.Width + pbxMessageIcon.Width, Math.Max(pbxMessageIcon.Height + 10, textSize.Height));
            }

            return textSize;
        }

        private Size UpdateButtonsSizing()
        {
            var numButtons = 1;

            // Button1 is always visible
            Size button1Size = mbButton1.GetPreferredSize(Size.Empty);
            Size maxButtonSize = new(button1Size.Width + GAP, button1Size.Height);

            // If Button2 is visible
            if (mbButton2.Enabled)
            {
                numButtons++;
                Size button2Size = mbButton2.GetPreferredSize(Size.Empty);
                maxButtonSize.Width = Math.Max(maxButtonSize.Width, button2Size.Width + GAP);
                maxButtonSize.Height = Math.Max(maxButtonSize.Height, button2Size.Height);
            }

            // If Button3 is visible
            if (mbButton3.Enabled)
            {
                numButtons++;
                Size button3Size = mbButton3.GetPreferredSize(Size.Empty);
                maxButtonSize.Width = Math.Max(maxButtonSize.Width, button3Size.Width + GAP);
                maxButtonSize.Height = Math.Max(maxButtonSize.Height, button3Size.Height);
            }
            // If Button4 is visible
            if (mbButton4.Enabled)
            {
                numButtons++;
                Size button4Size = mbButton4.GetPreferredSize(Size.Empty);
                maxButtonSize.Width = Math.Max(maxButtonSize.Width, button4Size.Width + GAP);
                maxButtonSize.Height = Math.Max(maxButtonSize.Height, button4Size.Height);
            }

            if (mbMoreDetails.Enabled)
            {
                numButtons++;

                Size moreDetailsSize = mbMoreDetails.GetPreferredSize(Size.Empty);

                moreDetailsSize.Width = Math.Max(maxButtonSize.Width, moreDetailsSize.Width + GAP);

                moreDetailsSize.Height = Math.Max(maxButtonSize.Height, moreDetailsSize.Height + GAP);
            }

            // Start positioning buttons 10 pixels from right edge
            var right = kpnlButtons.Right - GAP;

            var left = kpnlButtons.Left - GAP;

            // If Button4 is visible
            if (mbButton4.Enabled)
            {
                mbButton4.Location = new Point(right - maxButtonSize.Width, GAP);
                mbButton4.Size = maxButtonSize;
                right -= maxButtonSize.Width + GAP;
            }

            // If Button3 is visible
            if (mbButton3.Enabled)
            {
                mbButton3.Location = new Point(right - maxButtonSize.Width, GAP);
                mbButton3.Size = maxButtonSize;
                right -= maxButtonSize.Width + GAP;
            }

            // If Button2 is visible
            if (mbButton2.Enabled)
            {
                mbButton2.Location = new Point(right - maxButtonSize.Width, GAP);
                mbButton2.Size = maxButtonSize;
                right -= maxButtonSize.Width + GAP;
            }

            if (mbMoreDetails.Enabled)
            {
                mbMoreDetails.Location = new Point(4, GAP);

                mbMoreDetails.Size = maxButtonSize;

                left -= maxButtonSize.Width + GAP;
            }

            // Button1 is always visible
            mbButton1.Location = new Point(right - maxButtonSize.Width, GAP);
            mbButton1.Size = maxButtonSize;

            // Size the panel for the buttons
            kpnlButtons.Size = new Size((maxButtonSize.Width * numButtons) + (GAP * (numButtons + 1)), maxButtonSize.Height + (GAP * 2));

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
            sb.AppendLine(kwlMessageText.Text);
            sb.AppendLine(DIVIDER);
            sb.Append(mbButton1.Text).Append(BUTTON_TEXT_SPACER);
            if (mbButton2.Enabled)
            {
                sb.Append(mbButton2.Text).Append(BUTTON_TEXT_SPACER);
                if (mbButton3.Enabled)
                {
                    sb.Append(mbButton3.Text).Append(BUTTON_TEXT_SPACER);
                }

                if (mbButton4.Enabled)
                {
                    sb.Append(mbButton4.Text).Append(BUTTON_TEXT_SPACER);
                }
            }

            sb.AppendLine(string.Empty);
            sb.AppendLine(DIVIDER);

            Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
            Clipboard.SetText(sb.ToString(), TextDataFormat.UnicodeText);
        }

        private void SetupOptionalLinkLabelUI(bool showOptionalLinkLabel)
        {
            kpnlExpandableFooter.Visible = showOptionalLinkLabel;

            kllOptionalLink.Visible = showOptionalLinkLabel;

            kcbOptionalCheckBox.Visible = false;

            krtbMoreDetails.Visible = false;

            kllOptionalLink.StateCommon.ShortText.Font = _messageBoxTypeface;

            kllOptionalLink.Text = _optionalLinkLabelText;

            if (_linkCommand != null)
            {
                kllOptionalLink.KryptonCommand = _linkCommand;
            }
        }

        private void SetupOptionalCheckBoxUI(bool showOptionalCheckBox)
        {
            kpnlExpandableFooter.Visible = showOptionalCheckBox;

            kcbOptionalCheckBox.Visible = showOptionalCheckBox;

            kcbOptionalCheckBox.StateCommon.ShortText.Font = _messageBoxTypeface;

            kcbOptionalCheckBox.Text = _optionalCheckBoxText;

            krtbMoreDetails.Visible = false;

            kllOptionalLink.Visible = false;
        }

        private void MoreDetails_Click(object sender, EventArgs e) => UpdateMoreDetails();

        /// <summary>Updates the more details.</summary>
        private void UpdateMoreDetails()
        {
            int originalHeight = Size.Height;

            int newHeight;

            int originalFooterHeight = kpnlExpandableFooter.Size.Height;

            int newFooterHeight;

            krtbMoreDetails.StateCommon.Content.Font = _messageBoxTypeface;

            if (mbMoreDetails.Text == _expandText)
            {
                mbMoreDetails.Text = _collapseText;

                kpnlExpandableFooter.Visible = true;

                krtbMoreDetails.Visible = true;

                krtbMoreDetails.Text = _detailsText;
            }
            else if (mbMoreDetails.Text == _collapseText)
            {
                mbMoreDetails.Text = _expandText;

                kpnlExpandableFooter.Visible = false;

                krtbMoreDetails.Visible = false;
            }

            if (kpnlExpandableFooter.Visible)
            {
                newFooterHeight = originalFooterHeight + _maximumMoreDetailsDropDownHeight;

                kpnlExpandableFooter.Height = newFooterHeight;

                newHeight = originalFooterHeight + newFooterHeight;

                Height = newHeight;
            }
            else
            {
                kpnlExpandableFooter.Height = originalFooterHeight;

                Height = originalHeight;
            }
        }

        /// <summary>Setups the more details UI.</summary>
        /// <param name="showUI">if set to <c>true</c> [show UI].</param>
        private void SetupMoreDetailsUI(bool showUI)
        {
            mbMoreDetails.Visible = showUI;

            mbMoreDetails.Text = "E&xpand";

            if (showUI)
            {
                ContentLayoutPanel.RowStyles[2].Height = 0;
            }
        }

        private void kllOptionalLink_LinkClicked(object sender, EventArgs e) => ProcessLink();

        private void ProcessLink()
        {
            try
            {
                if (_linkCommand != null)
                {
                    _linkCommand.PerformExecute();
                }
                else
                {
                    Process.Start(_optionalLinkLabelURL);
                }
            }
            catch (Exception e)
            {
                KryptonMessageBox.Show($"Error: {e}", "Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
            }
        }

        private void kcbOptionalCheckBox_CheckedChanged(object sender, EventArgs e) => SetOptionalCheckBoxCheckStateValue(kcbOptionalCheckBox.CheckState);

        #endregion

        #region Protected

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        #endregion

        #region Setters & Getters

        /// <summary>Sets the optional CheckBox check state value.</summary>
        /// <param name="checkStateValue">The check state value.</param>
        private void SetOptionalCheckBoxCheckStateValue(CheckState checkStateValue) => OptionalCheckBoxCheckState = checkStateValue;

        /// <summary>Get optional the CheckBox check state value.</summary>
        /// <returns></returns>
        public CheckState GetOptionalCheckBoxCheckStateValue() => OptionalCheckBoxCheckState;

        #endregion
    }
}