#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

using Resources = Krypton.Toolkit.Suite.Extended.Messagebox.Properties.Resources;

using Timer = System.Windows.Forms.Timer;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    public partial class KryptonMessageBoxExtendedFormDevelopment : KryptonForm
    {
        #region Static Fields

        private const int GAP = 10;
        private static readonly int OS_MAJOR_VERSION;
        public const int WH_CALLWNDPROCRET = 12;

        private const int WM_CLOSE = 0x0010;

        #endregion

        #region Instance Fields

        private readonly bool _showCloseButton;

        private readonly string _text;
        private readonly string _caption;

        private readonly KryptonMessageBoxDefaultButton _defaultButton;
        private readonly MessageBoxOptions _options; // https://github.com/Krypton-Suite/Standard-Toolkit/issues/313
        // If help information provided or we are not a service/default desktop application then grab an owner for showing the message box
        private static /*readonly*/ IWin32Window? _showOwner;
        private readonly HelpInfo? _helpInfo;
        private readonly ContentAlignment _messageTextAlignment;

        private readonly Image? _applicationImage;

        private readonly KryptonMessageBoxExtendedData _messageBoxExtendedData;

        #endregion

        #region Extended Fields

        private readonly bool _showHelpButton;

        private readonly bool _openInExplorer;

        private readonly bool _useTimeOut;

        private readonly bool _showOptionalCheckBox;

        private readonly bool _useOptionalCheckBoxThreeState;

        private bool _optionalCheckBoxChecked;

        private readonly Color _messageTextColour;

        private readonly Color[]? _buttonTextColours = new Color[4];

        private readonly DialogResult _buttonOneCustomDialogResult;

        private readonly DialogResult _buttonTwoCustomDialogResult;

        private readonly DialogResult _buttonThreeCustomDialogResult;

        private readonly DialogResult _buttonFourDialogResult;

        private readonly Font _messageBoxTypeface;

        private readonly ExtendedMessageBoxButtons _buttons;

        private readonly ExtendedKryptonMessageBoxIcon _kryptonMessageBoxIcon;

        private readonly Image? _customKryptonMessageBoxIcon;

        private readonly string _buttonOneCustomText;

        private readonly string _buttonTwoCustomText;

        private readonly string _buttonThreeCustomText;

        private readonly string _buttonFourCustomText;

        private readonly string _applicationPath;

        private readonly string _checkBoxText;

        private readonly ExtendedKryptonMessageBoxMessageContainerType _messageContainerType;

        private readonly KryptonCommand? _linkLabelCommand;

        private readonly LinkArea _contentLinkArea;

        private readonly ProcessStartInfo? _linkLaunchArgument;

        private static PlatformInvoke.HookProc _hookProc;

        private static IntPtr _hHook;

        private Timer _timeOutTimer;

        private int _timeOut;

        private bool _timedOut;

        private DialogResult _result;

        private DialogResult _timerResult;

        private readonly PaletteRelativeAlign _richTextBoxTextAlignment;

        #endregion

        #region Identity

        static KryptonMessageBoxExtendedFormDevelopment()
        {
            OS_MAJOR_VERSION = Environment.OSVersion.Version.Major;

            _hookProc = new PlatformInvoke.HookProc(MessageBoxHookProc);

            _hHook = IntPtr.Zero;
        }

        public KryptonMessageBoxExtendedFormDevelopment()
        {
            InitializeComponent();
        }

        public KryptonMessageBoxExtendedFormDevelopment(KryptonMessageBoxExtendedData messageBoxExtendedData)
        {
            _messageBoxExtendedData = messageBoxExtendedData;

            // Create the form contents
            InitializeComponent();

            RightToLeftLayout = _messageBoxExtendedData.Options.HasFlag(MessageBoxOptions.RtlReading);

            // Update contents to match requirements
            UpdateText(_messageBoxExtendedData.Caption, messageBoxExtendedData.MessageText, _messageBoxExtendedData.Options, _messageBoxExtendedData.MessageContentAreaType);
            UpdateIcon(_messageBoxExtendedData.Icon);
            UpdateButtons(_messageBoxExtendedData.Buttons);
            UpdateDefault(_messageBoxExtendedData.DefaultButton);
            UpdateHelp(_messageBoxExtendedData.ShowHelpButton);
            UpdateTextExtra(_messageBoxExtendedData.ShowCtrlCopy);

            UpdateContentAreaType(_messageBoxExtendedData.MessageContentAreaType, _messageBoxExtendedData.MessageTextAlignment, _messageBoxExtendedData.RichTextBoxTextAlignment);

            UpdateContentLinkArea(_messageBoxExtendedData.ContentLinkArea);

            SetupOptionalCheckBox();

            // Finally calculate and set form sizing
            UpdateSizing(_messageBoxExtendedData.Owner);
        }

        #endregion

        #region Implementation

        private void UpdateText(string caption, string? text, MessageBoxOptions options, ExtendedKryptonMessageBoxMessageContainerType? contentAreaType)
        {
            // Set the text of the form
            Text = string.IsNullOrEmpty(caption) ? string.Empty : caption.Split(Environment.NewLine.ToCharArray())[0];

            switch (contentAreaType)
            {
                case ExtendedKryptonMessageBoxMessageContainerType.Normal:
                    kwlblMessageText.Text = text;

                    kwlblMessageText.RightToLeft = options.HasFlag(MessageBoxOptions.RightAlign) ? RightToLeft.Yes :
                        options.HasFlag(MessageBoxOptions.RtlReading) ? RightToLeft.Inherit : RightToLeft.No;
                    break;
                case ExtendedKryptonMessageBoxMessageContainerType.HyperLink:
                    klwlblMessageText.Text = text;

                    klwlblMessageText.RightToLeft = options.HasFlag(MessageBoxOptions.RightAlign)
                        ?
                        RightToLeft.Yes
                        : options.HasFlag(MessageBoxOptions.RtlReading)
                            ? RightToLeft.Inherit
                            : RightToLeft.No;
                    break;
                case ExtendedKryptonMessageBoxMessageContainerType.RichTextBox:
                    krtbMessageText.Text = text;

                    krtbMessageText.RightToLeft = options.HasFlag(MessageBoxOptions.RightAlign) ? RightToLeft.Yes :
                        options.HasFlag(MessageBoxOptions.RtlReading) ? RightToLeft.Inherit : RightToLeft.No;
                    break;
                case null:
                    kwlblMessageText.Text = text;

                    kwlblMessageText.RightToLeft = options.HasFlag(MessageBoxOptions.RightAlign) ? RightToLeft.Yes :
                        options.HasFlag(MessageBoxOptions.RtlReading) ? RightToLeft.Inherit : RightToLeft.No;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(contentAreaType), contentAreaType, null);
            }
        }

        private void UpdateText()
        {
            Text = string.IsNullOrEmpty(_caption) ? string.Empty : _caption.Split(Environment.NewLine.ToCharArray())[0];

            if (_messageContainerType == ExtendedKryptonMessageBoxMessageContainerType.Normal)
            {
                kwlblMessageText.Visible = true;
                kwlblMessageText.Text = _text;
                kwlblMessageText.StateCommon.Font = _messageBoxTypeface;

                kwlblMessageText.StateCommon.TextColor = _messageTextColour;
                kwlblMessageText.RightToLeft = _options.HasFlag(MessageBoxOptions.RightAlign)
                    ? RightToLeft.Yes
                    : _options.HasFlag(MessageBoxOptions.RtlReading)
                        ? RightToLeft.Inherit
                        : RightToLeft.No;

                krtbMessageText.Visible = false;

                klwlblMessageText.Visible = false;
            }
            else if (_messageContainerType == ExtendedKryptonMessageBoxMessageContainerType.RichTextBox)
            {
                krtbMessageText.Visible = true;

                krtbMessageText.Text = _text;

                krtbMessageText.StateCommon.Content.Color1 = _messageTextColour;

                krtbMessageText.StateCommon.Content.Font = _messageBoxTypeface;

                krtbMessageText.RightToLeft = _options.HasFlag(MessageBoxOptions.RightAlign)
                    ? RightToLeft.Yes
                    : _options.HasFlag(MessageBoxOptions.RtlReading)
                        ? RightToLeft.Inherit
                        : RightToLeft.No;

                kwlblMessageText.Visible = false;

                klwlblMessageText.Visible = false;
            }
            else if (_messageContainerType == ExtendedKryptonMessageBoxMessageContainerType.HyperLink)
            {
                klwlblMessageText.Visible = true;

                klwlblMessageText.Text = _text;

                klwlblMessageText.StateCommon.TextColor = _messageTextColour;

                klwlblMessageText.StateCommon.Font = _messageBoxTypeface;

                klwlblMessageText.RightToLeft = _options.HasFlag(MessageBoxOptions.RightAlign)
                    ? RightToLeft.Yes
                    : _options.HasFlag(MessageBoxOptions.RtlReading)
                        ? RightToLeft.Inherit
                        : RightToLeft.No;

                kwlblMessageText.Visible = false;

                krtbMessageText.Visible = false;
            }

            kcbOptionalCheckBox.StateCommon.ShortText.Color1 = _messageTextColour;

            kcbOptionalCheckBox.StateCommon.ShortText.Color2 = _messageTextColour;

            kcbOptionalCheckBox.StateCommon.ShortText.Font = _messageBoxTypeface;

            kcbOptionalCheckBox.RightToLeft = _options.HasFlag(MessageBoxOptions.RightAlign) ? RightToLeft.Yes :
                _options.HasFlag(MessageBoxOptions.RtlReading) ? RightToLeft.Inherit : RightToLeft.No;
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

        private void UpdateIcon(ExtendedKryptonMessageBoxIcon icon)
        {
            if (OSUtilities.IsAtLeastWindowsEleven)
            {
                switch (icon)
                {
                    case ExtendedKryptonMessageBoxIcon.None:
                        // Windows XP and before will Beep, Vista and above do not!
                        if (OS_MAJOR_VERSION < 6)
                        {
                            SystemSounds.Beep.Play();
                        }
                        break;
                    case ExtendedKryptonMessageBoxIcon.Hand:
                        _messageIcon.Image = Resources.Hand;
                        SystemSounds.Hand.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Question:
                        _messageIcon.Image = Resources.Question_Windows_11;
                        SystemSounds.Question.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Exclamation:
                        _messageIcon.Image = Resources.Warning_Windows_11;
                        SystemSounds.Exclamation.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Asterisk:
                        _messageIcon.Image = Resources.Asterisk_Windows_11;
                        SystemSounds.Asterisk.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Stop:
                        _messageIcon.Image = Resources.Stop;
                        SystemSounds.Asterisk.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Error:
                        _messageIcon.Image = Resources.Critical_Windows_11;
                        SystemSounds.Asterisk.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Warning:
                        _messageIcon.Image = Resources.Warning_Windows_11;
                        SystemSounds.Exclamation.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Information:
                        _messageIcon.Image = Resources.Information_Windows_11;
                        SystemSounds.Asterisk.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Shield:
                        _messageIcon.Image = Resources.UAC_Shield_Windows_11;
                        break;
                    case ExtendedKryptonMessageBoxIcon.WindowsLogo:
                        _messageIcon.Image = Resources.Windows11;
                        break;
                    case ExtendedKryptonMessageBoxIcon.Application:
                        if (_applicationImage != null)
                        {
                            _messageIcon.Image = _applicationImage;
                        }
                        else if (!string.IsNullOrEmpty(_applicationPath))
                        {
                            Image? sourceImage = GraphicsExtensions.ExtractIconFromFilePath(_applicationPath)?.ToBitmap();
                            Image? scaledImage = GraphicsExtensions.ScaleImage(sourceImage, new Size(32, 32));

                            _messageIcon.Image = scaledImage;
                        }
                        else
                        {
                            // Fall back to defaults
                            _messageIcon.Image = SystemIcons.Application.ToBitmap();
                        }
                        break;
                    case ExtendedKryptonMessageBoxIcon.SystemApplication:
                        _messageIcon.Image = SystemIcons.Application.ToBitmap();
                        break;
                }
            }
            else
            {
                switch (icon)
                {
                    case ExtendedKryptonMessageBoxIcon.None:
                        // Windows XP and before will Beep, Vista and above do not!
                        if (OS_MAJOR_VERSION < 6)
                        {
                            SystemSounds.Beep.Play();
                        }

                        break;
                    case ExtendedKryptonMessageBoxIcon.Hand:
                        _messageIcon.Image = Resources.Hand;
                        SystemSounds.Hand.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.SystemHand:
                        _messageIcon.Image = SystemIcons.Hand.ToBitmap();
                        SystemSounds.Hand.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Question:
                        _messageIcon.Image = Resources.Question;
                        SystemSounds.Question.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.SystemQuestion:
                        _messageIcon.Image = SystemIcons.Question.ToBitmap();
                        SystemSounds.Question.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Exclamation:
                        _messageIcon.Image = Resources.Warning;
                        SystemSounds.Exclamation.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.SystemExclamation:
                        _messageIcon.Image = SystemIcons.Warning.ToBitmap();
                        SystemSounds.Exclamation.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Asterisk:
                        _messageIcon.Image = OSUtilities.IsAtLeastWindowsEleven
                            ? Resources.Asterisk_Windows_11
                            : Resources.Asterisk;
                        SystemSounds.Asterisk.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.SystemAsterisk:
                        _messageIcon.Image = SystemIcons.Asterisk.ToBitmap();
                        SystemSounds.Asterisk.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Stop:
                        _messageIcon.Image = Resources.Stop;
                        SystemSounds.Asterisk.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Error:
                        _messageIcon.Image = Resources.Critical;
                        SystemSounds.Asterisk.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Warning:
                        _messageIcon.Image = Resources.Warning;
                        SystemSounds.Exclamation.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Information:
                        _messageIcon.Image = Resources.Information;
                        SystemSounds.Asterisk.Play();
                        break;
                    case ExtendedKryptonMessageBoxIcon.Shield:
                        if (OSUtilities.IsAtLeastWindowsEleven)
                        {
                            _messageIcon.Image = Resources.UAC_Shield_Windows_11;
                        }
                        else if (OSUtilities.IsWindowsTen)
                        {
                            _messageIcon.Image = Resources.UAC_Shield_Windows_10;
                        }
                        else
                        {
                            _messageIcon.Image = Resources.UAC_Shield_Windows_7;
                        }

                        break;
                    case ExtendedKryptonMessageBoxIcon.WindowsLogo:
                        // Because Windows 11 displays a  application icon,
                        // we need to rely on a image instead
                        if (OSUtilities.IsAtLeastWindowsEleven)
                        {
                            _messageIcon.Image = Resources.Windows11;
                        }
                        // Windows 10
                        else if (OSUtilities.IsWindowsTen)
                        {
                            _messageIcon.Image = Resources.Windows_8_and_10_Logo;
                        }
                        else
                        {
                            _messageIcon.Image = SystemIcons.WinLogo.ToBitmap();
                        }

                        break;
                    case ExtendedKryptonMessageBoxIcon.Application:
                        if (_applicationImage != null)
                        {
                            _messageIcon.Image = _applicationImage;
                        }
                        else if (!string.IsNullOrEmpty(_applicationPath))
                        {
                            Image? sourceImage = GraphicsExtensions.ExtractIconFromFilePath(_applicationPath)
                                ?.ToBitmap();
                            Image? scaledImage = GraphicsExtensions.ScaleImage(sourceImage, new Size(32, 32));

                            _messageIcon.Image = scaledImage;
                        }
                        else
                        {
                            // Fall back to defaults
                            _messageIcon.Image = SystemIcons.Application.ToBitmap();
                        }

                        break;
                    case ExtendedKryptonMessageBoxIcon.SystemApplication:
                        _messageIcon.Image = SystemIcons.Application.ToBitmap();
                        break;
                }
            }

            _messageIcon.Visible = _kryptonMessageBoxIcon != ExtendedKryptonMessageBoxIcon.None;
        }

        private void UpdateIcon()
        {
            switch (_kryptonMessageBoxIcon)
            {
                case ExtendedKryptonMessageBoxIcon.Custom:
                    if (_customKryptonMessageBoxIcon != null)
                    {
                        _messageIcon.Image = _customKryptonMessageBoxIcon;
                    }
                    else
                    {
                        _messageIcon.Image = SystemIcons.Application.ToBitmap();
                    }
                    break;
                case ExtendedKryptonMessageBoxIcon.None:
                    // Windows XP and before will Beep, Vista and above do not!
                    if (OS_MAJOR_VERSION < 6)
                    {
                        SystemSounds.Beep.Play();
                    }
                    break;
                case ExtendedKryptonMessageBoxIcon.Hand:
                    _messageIcon.Image = Properties.Resources.Hand;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.SystemHand:
                    _messageIcon.Image = SystemIcons.Hand.ToBitmap();
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Question:
                    _messageIcon.Image = Properties.Resources.Question;
                    SystemSounds.Question.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.SystemQuestion:
                    _messageIcon.Image = SystemIcons.Question.ToBitmap();
                    SystemSounds.Question.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Exclamation:
                    _messageIcon.Image = Properties.Resources.Warning;
                    SystemSounds.Exclamation.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.SystemExclamation:
                    _messageIcon.Image = SystemIcons.Exclamation.ToBitmap();
                    SystemSounds.Exclamation.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Asterisk:
                    _messageIcon.Image = Properties.Resources.Asterisk;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.SystemAsterisk:
                    _messageIcon.Image = SystemIcons.Asterisk.ToBitmap();
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Stop:
                    _messageIcon.Image = Properties.Resources.Stop;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Error:
                    _messageIcon.Image = Properties.Resources.Critical;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Warning:
                    _messageIcon.Image = Properties.Resources.Warning;
                    SystemSounds.Exclamation.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Information:
                    _messageIcon.Image = Properties.Resources.Information;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.Shield:
                    if (OSUtilities.IsAtLeastWindowsEleven)
                    {
                        _messageIcon.Image = Properties.Resources.UAC_Shield_Windows_11;
                    }
                    // Windows 10
                    else if (OSUtilities.IsWindowsTen)
                    {
                        _messageIcon.Image = Properties.Resources.UAC_Shield_Windows_10;
                    }
                    else
                    {
                        _messageIcon.Image = Properties.Resources.UAC_Shield_Windows_7;
                    }
                    break;
                case ExtendedKryptonMessageBoxIcon.WindowsLogo:
                    // Because Windows 11 displays a generic application icon,
                    // we need to rely on a image instead
                    if (OSUtilities.IsAtLeastWindowsEleven)
                    {
                        _messageIcon.Image = Properties.Resources.Windows11;
                    }
                    // Windows 10, 8.1 & 8
                    else if (OSUtilities.IsWindowsTen || OSUtilities.IsWindowsEightPointOne || OSUtilities.IsWindowsEight)
                    {
                        _messageIcon.Image = Properties.Resources.Windows_8_and_10_Logo;
                    }
                    else
                    {
                        _messageIcon.Image = SystemIcons.WinLogo.ToBitmap();
                    }
                    break;
                case ExtendedKryptonMessageBoxIcon.Application:
                    if (!string.IsNullOrEmpty(_applicationPath))
                    {
                        Image? tempImage = GraphicsExtensions.ExtractIconFromFilePath(_applicationPath)?.ToBitmap();
                        Bitmap? scaledImage = GraphicsExtensions.ScaleImage(tempImage, new Size(32, 32));

                        _messageIcon.Image = scaledImage;
                    }
                    else
                    {
                        _messageIcon.Image = SystemIcons.Application.ToBitmap();
                    }
                    break;
                case ExtendedKryptonMessageBoxIcon.SystemApplication:
                    _messageIcon.Image = SystemIcons.Application.ToBitmap();
                    break;
            }

            _messageIcon.Visible = _kryptonMessageBoxIcon != ExtendedKryptonMessageBoxIcon.None;

        }

        private void UpdateButtons(ExtendedMessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case ExtendedMessageBoxButtons.OK:
                    _button1.Text = KryptonManager.Strings.GeneralStrings.OK;
                    _button1.DialogResult = DialogResult.OK;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.OKCancel:
                    _button1.Text = KryptonManager.Strings.GeneralStrings.OK;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.Cancel;
                    _button1.DialogResult = DialogResult.OK;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.YesNo:
                    _button1.Text = KryptonManager.Strings.GeneralStrings.Yes;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.No;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    ControlBox = false;
                    break;
                case ExtendedMessageBoxButtons.YesNoCancel:
                    _button1.Text = KryptonManager.Strings.GeneralStrings.Yes;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.No;
                    _button3.Text = KryptonManager.Strings.GeneralStrings.Cancel;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button3.DialogResult = DialogResult.Cancel;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button3.Visible = true;
                    _button3.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.RetryCancel:
                    _button1.Text = KryptonManager.Strings.GeneralStrings.Retry;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.Cancel;
                    _button1.DialogResult = DialogResult.Retry;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.AbortRetryIgnore:
                    _button1.Text = KryptonManager.Strings.GeneralStrings.Abort;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.Retry;
                    _button3.Text = KryptonManager.Strings.GeneralStrings.Ignore;
                    _button1.DialogResult = DialogResult.Abort;
                    _button2.DialogResult = DialogResult.Retry;
                    _button3.DialogResult = DialogResult.Ignore;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button3.Visible = true;
                    _button3.Enabled = true;
                    ControlBox = false;
                    break;
                case ExtendedMessageBoxButtons.CancelTryContinue:
                    _button1.Text = KryptonManager.Strings.GeneralStrings.Cancel;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.TryAgain;
                    _button3.Text = KryptonManager.Strings.GeneralStrings.Continue;
                    _button1.DialogResult = DialogResult.Cancel;
#if NET6_0_OR_GREATER
                    _button2.DialogResult = DialogResult.TryAgain;
                    _button3.DialogResult = DialogResult.Continue;
#else
                    _button2.DialogResult = (DialogResult)10;
                    _button3.DialogResult = (DialogResult)11;
#endif
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button3.Visible = true;
                    _button3.Enabled = true;
                    break;
            }

            if (_messageBoxExtendedData.ShowActionButton != null)
            {
                //_button5.Text = _actionButtonText;
                //_button5.Visible = true;
                //_button5.Enabled = true;
                //_button5.KryptonCommand = _actionButtonCommand;
            }

            // Do we ignore the Alt+F4 on the buttons?
            if (!ControlBox)
            {
                _button1.IgnoreAltF4 = true;
                _button2.IgnoreAltF4 = true;
                _button3.IgnoreAltF4 = true;
                _button4.IgnoreAltF4 = true;
                //_button5.IgnoreAltF4 = true;
            }
        }

        private void UpdateButtons()
        {
            switch (_buttons)
            {
                case ExtendedMessageBoxButtons.OK:
                    _button1.Text = KryptonManager.Strings.GeneralStrings.OK;
                    _button1.DialogResult = DialogResult.OK;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.OKCancel:
                    _button1.Text = KryptonManager.Strings.GeneralStrings.OK;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.Cancel;
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
                    _button1.Text = KryptonManager.Strings.GeneralStrings.Yes;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.No;
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
                    _button1.Text = KryptonManager.Strings.GeneralStrings.Yes;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.No;
                    _button3.Text = KryptonManager.Strings.GeneralStrings.Cancel;
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
                    _button1.Text = KryptonManager.Strings.GeneralStrings.Retry;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.Cancel;
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
                    _button1.Text = KryptonManager.Strings.GeneralStrings.Abort;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.Retry;
                    _button3.Text = KryptonManager.Strings.GeneralStrings.Ignore;
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
                case ExtendedMessageBoxButtons.CancelTryContinue:
                    _button1.Text = KryptonManager.Strings.GeneralStrings.Cancel;
                    _button2.Text = KryptonManager.Strings.GeneralStrings.TryAgain;
                    _button3.Text = KryptonManager.Strings.GeneralStrings.Continue;
                    _button1.DialogResult = DialogResult.Cancel;
#if NET6_0_OR_GREATER
                    _button2.DialogResult = DialogResult.TryAgain;
                    _button3.DialogResult = DialogResult.Continue;
#else
                    _button2.DialogResult = (DialogResult)10;
                    _button2.DialogResult = (DialogResult)11;
#endif
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

        private void UpdateDefault(KryptonMessageBoxDefaultButton? defaultButton)
        {
            switch (defaultButton)
            {
                case KryptonMessageBoxDefaultButton.Button1:
                    //_button1.Select();
                    AcceptButton = _button1;
                    break;
                case KryptonMessageBoxDefaultButton.Button2:
                    //_button2.Select();
                    AcceptButton = _button2;
                    break;
                case KryptonMessageBoxDefaultButton.Button3:
                    //_button3.Select();
                    AcceptButton = _button3;
                    break;
                case KryptonMessageBoxDefaultButton.Button4:
                    AcceptButton = _showHelpButton ? _button4 : _button1;
                    break;
                //case KryptonMessageBoxDefaultButton.Button5:
                //    AcceptButton = _showActionButton ? _button5 : _button1;
                //    break;
                case null:
                    AcceptButton = _button1;
                    break;
                default:
                    AcceptButton = _showHelpButton ? _button4 : _button1;
                    break;
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

        private void UpdateHelp(bool? showHelpButton)
        {
            if (showHelpButton != null)
            {
                return;
            }

            MessageButton helpButton = _buttons switch
            {
                ExtendedMessageBoxButtons.OK => _button2,
                ExtendedMessageBoxButtons.OKCancel or ExtendedMessageBoxButtons.YesNo or ExtendedMessageBoxButtons.RetryCancel => _button3,
                ExtendedMessageBoxButtons.AbortRetryIgnore or ExtendedMessageBoxButtons.YesNoCancel => _button4,
                _ => throw new ArgumentOutOfRangeException()
            };
            if (helpButton != null)
            {
                helpButton.Visible = true;
                helpButton.Enabled = true;
                helpButton.Text = KryptonManager.Strings.GeneralStrings.Help;

                helpButton.KeyPress += (_, _) => LaunchHelp(_messageBoxExtendedData.Owner);

                helpButton.Click += (_, _) => LaunchHelp(_messageBoxExtendedData.Owner);
            }
        }

        /// <summary>
        /// When the user clicks the Help button, the Help file specified in the helpFilePath parameter
        /// is opened and the Help keyword topic identified by the keyword parameter is Displayed.
        /// The form that owns the message box (or the active form) also receives the HelpRequested event.
        /// </summary>
        private void LaunchHelp(IWin32Window? owner)
        {
            try
            {
                if (owner != null)
                {
                    Control? control = FromHandle(owner.Handle);

                    var mInfoMethod = control!.GetType().GetMethod(nameof(OnHelpRequested), BindingFlags.Instance | BindingFlags.NonPublic,
                        Type.DefaultBinder, [typeof(HelpEventArgs)], null)!;
                    mInfoMethod.Invoke(control, [new HelpEventArgs(MousePosition)]);
                    if (_helpInfo != null)
                    {
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
                }
            }
            catch
            {
                // Do nothing if failure to send to Parent
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
                ExtendedMessageBoxButtons.OKCancel or ExtendedMessageBoxButtons.YesNo or ExtendedMessageBoxButtons.RetryCancel => _button3,
                ExtendedMessageBoxButtons.AbortRetryIgnore or ExtendedMessageBoxButtons.YesNoCancel => _button4,
                _ => throw new ArgumentOutOfRangeException()
            };
            if (helpButton != null)
            {
                helpButton.Visible = true;
                helpButton.Enabled = true;
                helpButton.Text = KryptonManager.Strings.GeneralStrings.Help;
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
                Control control = FromHandle(_showOwner!.Handle);

                MethodInfo? mInfoMethod = control.GetType().GetMethod(@"OnHelpRequested", BindingFlags.Instance | BindingFlags.NonPublic,
                    Type.DefaultBinder, [typeof(HelpEventArgs)], null);
                if (mInfoMethod != null)
                {
                    mInfoMethod.Invoke(control, [new HelpEventArgs(MousePosition)]);
                }
                if (_helpInfo != null)
                {
                    if (string.IsNullOrWhiteSpace(_helpInfo.HelpFilePath))
                    {
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(_helpInfo!.Keyword))
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

        private void UpdateSizing(IWin32Window? showOwner)
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
            Size textSize;
            using (Graphics g = CreateGraphics())
            {
                // Find size of the label, with a max of 2/3 screen width
                Screen screen = showOwner != null ? Screen.FromHandle(showOwner.Handle) : Screen.PrimaryScreen;
                SizeF scaledMonitorSize = screen.Bounds.Size;
                scaledMonitorSize.Width *= 2 / 3.0f;
                scaledMonitorSize.Height *= 0.95f;

                kwlblMessageText.UpdateFont();
                SizeF messageSize = g.MeasureString(_text, kwlblMessageText.Font, scaledMonitorSize);
                // SKC: Don't forget to add the TextExtra into the calculation
                SizeF captionSize = g.MeasureString($@"{_caption} {TextExtra}", kwlblMessageText.Font, scaledMonitorSize);

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
            var right = 0;//_panelButtons.Right - GAP;

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
            //_panelButtons.Size = new Size((maxButtonSize.Width * numButtons) + (GAP * (numButtons + 1)), maxButtonSize.Height + (GAP * 2));

            // Button area is the number of buttons with gaps between them and 10 pixels around all edges
            return new Size(maxButtonSize.Width * numButtons + GAP * (numButtons + 1), maxButtonSize.Height + GAP * 2);
        }

        private void AnyKeyDown(object sender, KeyEventArgs e)
        {
            // Escape key kills the dialog if we allow it to be closed
            if (ControlBox
            && e.KeyCode == Keys.Escape
            )
            {
                Close();
            }
            else if (!e.Control
                 || e.KeyCode != Keys.C
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
            sb.AppendLine(kwlblMessageText.Text);
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

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (_openInExplorer)
                {
                    OpenInExplorer(e.Link.LinkData.ToString());
                }
                else
                {
                    if (_linkLabelCommand != null)
                    {
                        _linkLabelCommand.PerformExecute();
                    }
                    else if (_linkLaunchArgument != null)
                    {
                        Process.Start(_linkLaunchArgument);
                    }
                }
            }
            catch (Exception exc)
            {
                DebugUtilities.NotImplemented(exc.ToString());
            }
        }

        private void OpenInExplorer(string path)
        {
            try
            {
                Process.Start(@"explorer.exe", path);
            }
            catch (Exception e)
            {
                DebugUtilities.NotImplemented(e.ToString());
            }
        }

        private void UpdateContentLinkArea(LinkArea? contentLinkArea)
        {
            if (contentLinkArea != null)
            {
                klwlblMessageText.LinkArea = (LinkArea)contentLinkArea;
            }
        }

        private void UpdateContentAreaType(ExtendedKryptonMessageBoxMessageContainerType? messageContainerType, ContentAlignment? messageTextAlignment, PaletteRelativeAlign? richTextBoxTextAlignment)
        {
            switch (messageContainerType)
            {
                case ExtendedKryptonMessageBoxMessageContainerType.HyperLink:
                    klwlblMessageText.Visible = true;

                    kwlblMessageText.Visible = false;

                    klwlblMessageText.TextAlign = messageTextAlignment ?? ContentAlignment.MiddleLeft;

                    krtbMessageText.Visible = false;
                    break;
                case ExtendedKryptonMessageBoxMessageContainerType.Normal:
                    klwlblMessageText.Visible = false;

                    kwlblMessageText.Visible = true;

                    kwlblMessageText.TextAlign = messageTextAlignment ?? ContentAlignment.MiddleLeft;

                    krtbMessageText.Visible = false;
                    break;
                case ExtendedKryptonMessageBoxMessageContainerType.RichTextBox:
                    klwlblMessageText.Visible = false;

                    kwlblMessageText.Visible = false;

                    krtbMessageText.Visible = true;

                    krtbMessageText.StateCommon.Content.TextH = richTextBoxTextAlignment ?? PaletteRelativeAlign.Inherit;
                    break;
            }
        }

        [Obsolete("Obsolete")]
        private static void Initialize()
        {
            if (_hHook != IntPtr.Zero)
            {
                throw new NotSupportedException("multiple calls are not supported");
            }

            if (_showOwner != null)
            {
                _hHook = PlatformEvents.SetWindowsHookEx(WH_CALLWNDPROCRET, _hookProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
            }
        }

        private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return PlatformEvents.CallNextHookEx(_hHook, nCode, wParam, lParam);
            }

            CWPRETSTRUCT msg = (CWPRETSTRUCT)Marshal.PtrToStructure(lParam, typeof(CWPRETSTRUCT));
            IntPtr hook = _hHook;

            if (msg.message == (int)CbtHookAction.HCBT_ACTIVATE)
            {
                try
                {
                    CenterWindow(msg.hwnd);
                }
                finally
                {
                    PlatformEvents.UnhookWindowsHookEx(_hHook);
                    _hHook = IntPtr.Zero;
                }
            }

            return PlatformEvents.CallNextHookEx(hook, nCode, wParam, lParam);
        }

        private static void CenterWindow(IntPtr hChildWnd)
        {
            Rectangle recChild = new Rectangle(0, 0, 0, 0);
            bool success = PlatformEvents.GetWindowRect(hChildWnd, ref recChild);

            int width = recChild.Width - recChild.X;
            int height = recChild.Height - recChild.Y;

            Rectangle recParent = new Rectangle(0, 0, 0, 0);
            success = PlatformEvents.GetWindowRect(_showOwner!.Handle, ref recParent);

            Point ptCenter = new Point(0, 0);
            ptCenter.X = recParent.X + (recParent.Width - recParent.X) / 2;
            ptCenter.Y = recParent.Y + (recParent.Height - recParent.Y) / 2;


            Point ptStart = new Point(0, 0);
            ptStart.X = ptCenter.X - width / 2;
            ptStart.Y = ptCenter.Y - height / 2;

            ptStart.X = ptStart.X < 0 ? 0 : ptStart.X;
            ptStart.Y = ptStart.Y < 0 ? 0 : ptStart.Y;

            int result = PlatformEvents.MoveWindow(hChildWnd, ptStart.X, ptStart.Y, width,
                                height, false);
        }

        private void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = PlatformEvents.FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
            {
                PlatformEvents.SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }

            _timeOutTimer.Dispose();

            _timedOut = true;
        }

        private void SetupOptionalCheckBox()
        {
            kcbOptionalCheckBox.Visible = _showOptionalCheckBox;

            kcbOptionalCheckBox.Checked = _optionalCheckBoxChecked;

            kcbOptionalCheckBox.Text = _checkBoxText;

            kcbOptionalCheckBox.ThreeState = _useOptionalCheckBoxThreeState;
        }

        internal static bool ReturnCheckBoxCheckedValue()
        {
            KryptonMessageBoxExtendedFormDevelopment messageBoxExtendedForm = new KryptonMessageBoxExtendedFormDevelopment();

            return messageBoxExtendedForm._optionalCheckBoxChecked;
        }

        internal static CheckState ReturnCheckBoxCheckState()
        {
            KryptonMessageBoxExtendedFormDevelopment messageBoxExtendedForm = new KryptonMessageBoxExtendedFormDevelopment();

            return messageBoxExtendedForm.kcbOptionalCheckBox.CheckState;
        }

        private void OptionalCheckBox_CheckedChanged(object sender, EventArgs e) => _optionalCheckBoxChecked = kcbOptionalCheckBox.Checked;

        private void UpdateCloseButtonVisibility(bool? visible) => CloseBox = visible ?? true;

        #endregion
    }
}
