namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    internal partial class KryptonMessageBoxExtendedForm : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private KryptonWrapLabel _messageText;
        private KryptonPanel _panelButtons;
        private KryptonBorderEdge _borderEdge;
        private MessageButton _button4;
        private MessageButton _button3;
        private MessageButton _button1;
        private MessageButton _button2;
        private PictureBox _messageIcon;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._messageText = new Krypton.Toolkit.KryptonWrapLabel();
            this._panelButtons = new Krypton.Toolkit.KryptonPanel();
            this._borderEdge = new Krypton.Toolkit.KryptonBorderEdge();
            this._button4 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button3 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button1 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button2 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._messageIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).BeginInit();
            this._panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(183, 63);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._messageText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._panelButtons, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._messageIcon, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(183, 63);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _messageText
            // 
            this._messageText.AutoSize = false;
            this._messageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this._messageText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._messageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this._messageText.Location = new System.Drawing.Point(49, 0);
            this._messageText.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this._messageText.Name = "_messageText";
            this._messageText.Size = new System.Drawing.Size(134, 42);
            this._messageText.Text = "Message Text";
            this._messageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _panelButtons
            // 
            this.tableLayoutPanel1.SetColumnSpan(this._panelButtons, 2);
            this._panelButtons.Controls.Add(this._borderEdge);
            this._panelButtons.Controls.Add(this._button4);
            this._panelButtons.Controls.Add(this._button3);
            this._panelButtons.Controls.Add(this._button1);
            this._panelButtons.Controls.Add(this._button2);
            this._panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelButtons.Location = new System.Drawing.Point(0, 42);
            this._panelButtons.Margin = new System.Windows.Forms.Padding(0);
            this._panelButtons.Name = "_panelButtons";
            this._panelButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._panelButtons.Size = new System.Drawing.Size(183, 21);
            this._panelButtons.TabIndex = 0;
            // 
            // _borderEdge
            // 
            this._borderEdge.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this._borderEdge.Dock = System.Windows.Forms.DockStyle.Top;
            this._borderEdge.Location = new System.Drawing.Point(0, 0);
            this._borderEdge.Margin = new System.Windows.Forms.Padding(2);
            this._borderEdge.Name = "_borderEdge";
            this._borderEdge.Size = new System.Drawing.Size(183, 1);
            this._borderEdge.Text = "kryptonBorderEdge1";
            // 
            // _button4
            // 
            this._button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button4.AutoSize = true;
            this._button4.Enabled = false;
            this._button4.IgnoreAltF4 = false;
            this._button4.Location = new System.Drawing.Point(183, 0);
            this._button4.Margin = new System.Windows.Forms.Padding(0);
            this._button4.MinimumSize = new System.Drawing.Size(38, 21);
            this._button4.Name = "_button4";
            this._button4.Size = new System.Drawing.Size(38, 23);
            this._button4.TabIndex = 2;
            this._button4.Values.Text = "B4";
            this._button4.Visible = false;
            // 
            // _button3
            // 
            this._button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button3.AutoSize = true;
            this._button3.Enabled = false;
            this._button3.IgnoreAltF4 = false;
            this._button3.Location = new System.Drawing.Point(146, 0);
            this._button3.Margin = new System.Windows.Forms.Padding(0);
            this._button3.MinimumSize = new System.Drawing.Size(38, 21);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(38, 23);
            this._button3.TabIndex = 2;
            this._button3.Values.Text = "B3";
            this._button3.Visible = false;
            // 
            // _button1
            // 
            this._button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button1.AutoSize = true;
            this._button1.Enabled = false;
            this._button1.IgnoreAltF4 = false;
            this._button1.Location = new System.Drawing.Point(70, 0);
            this._button1.Margin = new System.Windows.Forms.Padding(0);
            this._button1.MinimumSize = new System.Drawing.Size(38, 21);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(38, 23);
            this._button1.TabIndex = 0;
            this._button1.Values.Text = "B1";
            this._button1.Visible = false;
            // 
            // _button2
            // 
            this._button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button2.AutoSize = true;
            this._button2.Enabled = false;
            this._button2.IgnoreAltF4 = false;
            this._button2.Location = new System.Drawing.Point(108, 0);
            this._button2.Margin = new System.Windows.Forms.Padding(0);
            this._button2.MinimumSize = new System.Drawing.Size(38, 21);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(38, 23);
            this._button2.TabIndex = 1;
            this._button2.Values.Text = "B2";
            this._button2.Visible = false;
            // 
            // _messageIcon
            // 
            this._messageIcon.BackColor = System.Drawing.Color.Transparent;
            this._messageIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this._messageIcon.Location = new System.Drawing.Point(8, 4);
            this._messageIcon.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this._messageIcon.Name = "_messageIcon";
            this._messageIcon.Size = new System.Drawing.Size(33, 34);
            this._messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._messageIcon.TabIndex = 0;
            this._messageIcon.TabStop = false;
            // 
            // KryptonMessageBoxExtendedForm
            // 
            this.ClientSize = new System.Drawing.Size(183, 63);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonMessageBoxExtendedForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).EndInit();
            this._panelButtons.ResumeLayout(false);
            this._panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Static Fields
        private const int GAP = 10;
        private static readonly int OS_MAJOR_VERSION;
        #endregion

        #region Instance Fields

        #region Basic Fields
        private readonly string _text;
        private readonly string _caption;
        private readonly ExtendedMessageBoxButtons _buttons;
        private readonly ExtendedKryptonMessageBoxIcon _kryptonMessageBoxIcon;

        private readonly MessageBoxDefaultButton _defaultButton;
        private MessageBoxOptions _options; // https://github.com/Krypton-Suite/Standard-Toolkit/issues/313
        // If help information provided or we are not a service/default desktop application then grab an owner for showing the message box
        private readonly IWin32Window _showOwner;
        private readonly HelpInfo _helpInfo;
        #endregion

        #region Extended Fields
        private bool _showUACShieldOnAcceptButton, _useYesNoOrCancelButtonColours;
        private Color _contentMessageColour, _buttonOneBackColourOne, _buttonOneBackColourTwo,
                      _buttonOneTextColourOne, _buttonOneTextColourTwo,
                      _buttonTwoBackColourOne, _buttonTwoBackColourTwo,
                      _buttonTwoTextColourOne, _buttonTwoTextColourTwo,
                      _buttonThreeBackColourOne, _buttonThreeBackColourTwo,
                      _buttonThreeTextColourOne, _buttonThreeTextColourTwo,
                      _yesButtonBackColourOne, _yesButtonBackColourTwo,
                      _yesButtonTextColourOne, _yesButtonTextColourTwo,
                      _noButtonBackColourOne, _noButtonBackColourTwo,
                      _noButtonTextColourOne, _noButtonTextColourTwo;
        private DialogResult _buttonOneCustomDialogResult, _buttonTwoCustomDialogResult, _buttonThreeCustomDialogResult;
        private ExtendedMessageBoxCustomButtonVisibility _visibility;
        private Font _messageBoxButtonTypeface, _messageBoxTypeface;
        private float _cornerRounding;
        private readonly string _optionalCheckBoxText, _copyButtonText, _buttonOneText, _buttonTwoText, _buttonThreeText;
        private Image _customMessageBoxIcon;
        private SoundPlayer _player;
        private Stream _soundStream;
        private int _timeoutSeconds;
        private Timer _timer;
        private KryptonCommand _buttonCommandOne, _buttonCommandTwo, _buttonCommandThree;
        #endregion

        #endregion

        #region Identity
        static KryptonMessageBoxExtendedForm() => OS_MAJOR_VERSION = Environment.OSVersion.Version.Major;

        public KryptonMessageBoxExtendedForm() => InitializeComponent();


        /// <summary>Initializes a new instance of the <see cref="KryptonMessageBoxExtendedForm" /> class.</summary>
        /// <param name="showOwner">The show owner.</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="customButtonVisibility">The custom button visibility.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="customButtonOneDialogResult">The custom button one dialog result.</param>
        /// <param name="customButtonTwoDialogResult">The custom button two dialog result.</param>
        /// <param name="customButtonThreeDialogResult">The custom button three dialog result.</param>
        /// <param name="options">The options.</param>
        /// <param name="helpInfo">The help information.</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="messageBoxButtonTypeface">The message box button typeface.</param>
        /// <param name="messageBoxTypeface">The message box typeface.</param>
        /// <param name="useYesNoOrCancelButtonColours">The use yes no or cancel button colours.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneBackColourOne">The button one back colour one.</param>
        /// <param name="buttonOneBackColourTwo">The button one back colour two.</param>
        /// <param name="buttonOneTextColourOne">The button one text colour one.</param>
        /// <param name="buttonOneTextColourTwo">The button one text colour two.</param>
        /// <param name="buttonTwoTextColourOne">The button two text colour one.</param>
        /// <param name="buttonTwoTextColourTwo">The button two text colour two.</param>
        /// <param name="buttonTwoBackColourOne">The button two back colour one.</param>
        /// <param name="buttonTwoBackColourTwo">The button two back colour two.</param>
        /// <param name="buttonThreeTextColourOne">The button three text colour one.</param>
        /// <param name="buttonThreeTextColourTwo">The button three text colour two.</param>
        /// <param name="buttonThreeBackColourOne">The button three back colour one.</param>
        /// <param name="buttonThreeBackColourTwo">The button three back colour two.</param>
        /// <param name="yesButtonBackColourOne">The yes button back colour one.</param>
        /// <param name="yesButtonBackColourTwo">The yes button back colour two.</param>
        /// <param name="yesButtonTextColourOne">The yes button text colour one.</param>
        /// <param name="yesButtonTextColourTwo">The yes button text colour two.</param>
        /// <param name="noButtonBackColourOne">The no button back colour one.</param>
        /// <param name="noButtonBackColourTwo">The no button back colour two.</param>
        /// <param name="noButtonTextColourOne">The no button text colour one.</param>
        /// <param name="noButtonTextColourTwo">The no button text colour two.</param>
        /// <param name="cornerRounding">The corner rounding.</param>
        /// <param name="showUacShieldOnAcceptButton">The show uac shield on accept button.</param>
        internal KryptonMessageBoxExtendedForm(IWin32Window showOwner, string text, string caption,
                                               ExtendedMessageBoxButtons buttons,
                                               ExtendedMessageBoxCustomButtonVisibility? customButtonVisibility,
                                               ExtendedKryptonMessageBoxIcon icon, MessageBoxDefaultButton defaultButton,
                                               DialogResult? customButtonOneDialogResult, DialogResult? customButtonTwoDialogResult,
                                               DialogResult? customButtonThreeDialogResult, MessageBoxOptions options,
                                               HelpInfo helpInfo, bool? showCtrlCopy,
                                               Font? messageBoxButtonTypeface, Font? messageBoxTypeface,
                                               bool? useYesNoOrCancelButtonColours, Color? contentMessageColour,
                                               Color? buttonOneBackColourOne, Color? buttonOneBackColourTwo,
                                               Color? buttonOneTextColourOne, Color? buttonOneTextColourTwo,
                                               Color? buttonTwoTextColourOne, Color? buttonTwoTextColourTwo,
                                               Color? buttonTwoBackColourOne, Color? buttonTwoBackColourTwo,
                                               Color? buttonThreeTextColourOne, Color? buttonThreeTextColourTwo,
                                               Color? buttonThreeBackColourOne, Color? buttonThreeBackColourTwo,
                                               Color? yesButtonBackColourOne, Color? yesButtonBackColourTwo,
                                               Color? yesButtonTextColourOne, Color? yesButtonTextColourTwo,
                                               Color? noButtonBackColourOne, Color? noButtonBackColourTwo,
                                               Color? noButtonTextColourOne, Color? noButtonTextColourTwo,
                                               float? cornerRounding, bool? showUacShieldOnAcceptButton)
        {
            // Store incoming values
            _text = text;
            _caption = caption;
            _buttons = buttons;
            _kryptonMessageBoxIcon = icon;
            _defaultButton = defaultButton;
            _options = options;
            _helpInfo = helpInfo;
            _showOwner = showOwner;

            // Extended values
            _useYesNoOrCancelButtonColours = useYesNoOrCancelButtonColours ?? false;
            _showUACShieldOnAcceptButton = showUacShieldOnAcceptButton ?? false;
            _visibility = customButtonVisibility ?? ExtendedMessageBoxCustomButtonVisibility.NONE;
            _buttonOneCustomDialogResult = customButtonOneDialogResult ?? DialogResult.None;
            _buttonTwoCustomDialogResult = customButtonTwoDialogResult ?? DialogResult.None;
            _buttonThreeCustomDialogResult = customButtonThreeDialogResult ?? DialogResult.None;
            _messageBoxButtonTypeface = messageBoxButtonTypeface ?? new Font(@"Segoe UI", 8.25F);
            _messageBoxTypeface = messageBoxTypeface ?? new Font(@"Segoe UI", 8.25F);
            _contentMessageColour = contentMessageColour ?? Color.Empty;
            _buttonOneTextColourOne = buttonOneTextColourOne ?? Color.Empty;
            _buttonOneBackColourOne = buttonOneBackColourOne ?? Color.Empty;
            _buttonOneTextColourTwo = buttonOneTextColourTwo ?? Color.Empty;
            _buttonOneBackColourTwo = buttonOneBackColourTwo ?? Color.Empty;
            _buttonTwoTextColourOne = buttonTwoTextColourOne ?? Color.Empty;
            _buttonTwoBackColourOne = buttonTwoBackColourOne ?? Color.Empty;
            _buttonTwoTextColourTwo = buttonTwoTextColourTwo ?? Color.Empty;
            _buttonTwoBackColourTwo = buttonTwoBackColourTwo ?? Color.Empty;
            _buttonThreeTextColourOne = buttonThreeTextColourOne ?? Color.Empty;
            _buttonThreeBackColourOne = buttonThreeBackColourOne ?? Color.Empty;
            _buttonThreeTextColourTwo = buttonThreeTextColourTwo ?? Color.Empty;
            _buttonThreeBackColourTwo = buttonThreeBackColourTwo ?? Color.Empty;
            _yesButtonBackColourOne = yesButtonBackColourOne ?? Color.Green;
            _yesButtonTextColourOne = yesButtonTextColourOne ?? Color.Empty;
            _yesButtonBackColourTwo = yesButtonBackColourTwo ?? Color.Green;
            _yesButtonTextColourTwo = yesButtonTextColourTwo ?? Color.Empty;
            _noButtonBackColourOne = noButtonBackColourOne ?? Color.Red;
            _noButtonTextColourOne = noButtonTextColourOne ?? Color.Empty;
            _noButtonBackColourTwo = noButtonBackColourTwo ?? Color.Red;
            _noButtonTextColourTwo = noButtonTextColourTwo ?? Color.Empty;
            _cornerRounding = cornerRounding ?? -1;

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
            AdjustCornerRounding(_cornerRounding);

            // Finally calculate and set form sizing
            UpdateSizing(showOwner);
        }
        #endregion Identity

        #region Methods

        #region Basic Methods
        private void UpdateText()
        {
            Text = (string.IsNullOrEmpty(_caption) ? string.Empty : _caption.Split(Environment.NewLine.ToCharArray())[0]);

            _messageText.StateCommon.Font = _messageBoxTypeface;

            _messageText.StateCommon.TextColor = _contentMessageColour;

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
                    case ExtendedKryptonMessageBoxIcon.ERROR:
                    case ExtendedKryptonMessageBoxIcon.EXCLAMATION:
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
                case ExtendedKryptonMessageBoxIcon.CUSTOM:
                    _messageIcon.Image = _customMessageBoxIcon;

                    if (_player != null)
                    {
                        _player = new SoundPlayer(_soundStream);

                        _player.Play();
                    }
                    break;
                case ExtendedKryptonMessageBoxIcon.NONE:
                    // Windows XP and before will Beep, Vista and above do not!
                    if (OS_MAJOR_VERSION < 6)
                    {
                        SystemSounds.Beep.Play();
                    }

                    break;
                case ExtendedKryptonMessageBoxIcon.QUESTION:
                    _messageIcon.Image = Properties.Resources.Question;
                    SystemSounds.Question.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.EXCLAMATION:
                    _messageIcon.Image = Properties.Resources.Warning;

                    SystemSounds.Exclamation.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.INFORMATION:
                    _messageIcon.Image = Properties.Resources.Information;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.WARNING:
                    _messageIcon.Image = Properties.Resources.Warning;
                    SystemSounds.Exclamation.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.ERROR:
                    _messageIcon.Image = Properties.Resources.Critical;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.ASTERISK:
                    _messageIcon.Image = Properties.Resources.Asterisk;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.HAND:
                    _messageIcon.Image = Properties.Resources.Hand;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.STOP:
                    _messageIcon.Image = Properties.Resources.Stop;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.SHIELD:
                    _messageIcon.Image = SystemIcons.Shield.ToBitmap();
                    break;
                case ExtendedKryptonMessageBoxIcon.WINDOWSLOGO:
                    _messageIcon.Image = SystemIcons.WinLogo.ToBitmap();
                    break;
            }

            _messageIcon.Visible = (_kryptonMessageBoxIcon != ExtendedKryptonMessageBoxIcon.NONE); // || (_messageBoxIcon != MessageBoxIcon.None);

        }

        private void UpdateButtons()
        {
            switch (_buttons)
            {
                case ExtendedMessageBoxButtons.CUSTOM:
                    _button1.Text = _buttonOneText;
                    _button1.DialogResult = _buttonOneCustomDialogResult;
                    _button2.Text = _buttonTwoText;
                    _button2.DialogResult = _buttonTwoCustomDialogResult;
                    _button3.Text = _buttonThreeText;
                    _button3.DialogResult = _buttonThreeCustomDialogResult;
                    switch (_visibility)
                    {
                        case ExtendedMessageBoxCustomButtonVisibility.ONEBUTTON:
                            _button1.Visible = true;
                            _button1.Enabled = true;
                            break;
                        case ExtendedMessageBoxCustomButtonVisibility.TWOBUTTONS:
                            _button1.Visible = true;
                            _button1.Enabled = true;
                            _button2.Visible = true;
                            _button2.Enabled = true;
                            break;
                        case ExtendedMessageBoxCustomButtonVisibility.THREEBUTTONS:
                            _button1.Visible = true;
                            _button1.Enabled = true;
                            _button2.Visible = true;
                            _button2.Enabled = true;
                            _button3.Visible = true;
                            _button3.Enabled = true;
                            break;
                    }
                    break;
                case ExtendedMessageBoxButtons.OK:
                    _button1.Text = KryptonManager.Strings.OK;
                    _button1.DialogResult = DialogResult.OK;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button1.UseAsUACElevationButton = _showUACShieldOnAcceptButton;

                    if (_useYesNoOrCancelButtonColours)
                    {
                        AlterButtonColours(_buttonOneBackColourOne, _buttonOneBackColourTwo,
                            null, null, null, null,
                            _buttonOneTextColourOne, _buttonOneTextColourTwo,
                            null, null, null, null);
                    }
                    break;
                case ExtendedMessageBoxButtons.OKCANCEL:
                    _button1.Text = KryptonManager.Strings.OK;
                    _button2.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.OK;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button1.UseAsUACElevationButton = _showUACShieldOnAcceptButton;
                    break;
                case ExtendedMessageBoxButtons.YESNO:
                    _button1.Text = KryptonManager.Strings.Yes;
                    _button2.Text = KryptonManager.Strings.No;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button1.UseAsUACElevationButton = _showUACShieldOnAcceptButton;
                    ControlBox = false;
                    break;
                case ExtendedMessageBoxButtons.YESNOCANCEL:
                    _button1.Text = KryptonManager.Strings.Yes;
                    _button2.Text = KryptonManager.Strings.No;
                    _button3.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button3.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button3.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button3.Visible = true;
                    _button3.Enabled = true;
                    _button1.UseAsUACElevationButton = _showUACShieldOnAcceptButton;
                    break;
                case ExtendedMessageBoxButtons.RETRYCANCEL:
                    _button1.Text = KryptonManager.Strings.Retry;
                    _button2.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.Retry;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button1.UseAsUACElevationButton = _showUACShieldOnAcceptButton;
                    break;
                case ExtendedMessageBoxButtons.ABORTRETRYIGNORE:
                    _button1.Text = KryptonManager.Strings.Abort;
                    _button2.Text = KryptonManager.Strings.Retry;
                    _button3.Text = KryptonManager.Strings.Ignore;
                    _button1.DialogResult = DialogResult.Abort;
                    _button2.DialogResult = DialogResult.Retry;
                    _button3.DialogResult = DialogResult.Ignore;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button3.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button3.Visible = true;
                    _button3.Enabled = true;
                    _button2.UseAsUACElevationButton = _showUACShieldOnAcceptButton;
                    ControlBox = false;
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
            if (_helpInfo == null)
            {
                return;
            }

            MessageButton helpButton = _buttons switch
            {
                ExtendedMessageBoxButtons.OK => _button2,
                ExtendedMessageBoxButtons.OKCANCEL or ExtendedMessageBoxButtons.YESNO or ExtendedMessageBoxButtons.RETRYCANCEL => _button3,
                ExtendedMessageBoxButtons.ABORTRETRYIGNORE or ExtendedMessageBoxButtons.YESNOCANCEL => _button4,
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
        /// is opened and the Help keyword topic identified by the keyword parameter is displayed.
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
                scaledMonitorSize.Width *= (2 / 3.0f);
                scaledMonitorSize.Height *= 0.95f;
                _messageText.UpdateFont();
                SizeF messageSize = g.MeasureString(_text, _messageText.Font, scaledMonitorSize);
                // SKC: Don't forget to add the TextExtra into the calculation
                SizeF captionSize = g.MeasureString($@"{_caption} {TextExtra}", _messageText.Font, scaledMonitorSize);

                var messageXSize = Math.Max(messageSize.Width, captionSize.Width);
                // Work out DPI adjustment factor
                var factorX = g.DpiX > 96 ? ((1.0f * g.DpiX) / 96) : 1.0f;
                var factorY = g.DpiY > 96 ? ((1.0f * g.DpiY) / 96) : 1.0f;
                messageSize.Width = messageXSize * factorX;
                messageSize.Height *= factorY;

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
                    StringBuilder sb = new();

                    sb.AppendLine("---------------------------");
                    sb.AppendLine(Text);
                    sb.AppendLine("---------------------------");
                    sb.AppendLine(_messageText.Text);
                    sb.AppendLine("---------------------------");
                    sb.Append(_button1.Text);
                    sb.Append("   ");
                    if (_button2.Enabled)
                    {
                        sb.Append(_button2.Text);
                        sb.Append("   ");
                        if (_button3.Enabled)
                        {
                            sb.Append(_button3.Text);
                            sb.Append("   ");
                        }
                        if (_button4.Enabled)
                        {
                            sb.Append(_button4.Text);
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

        #region Extended Methods
        /// <summary>
        /// Alters the button colours.
        /// </summary>
        /// <param name="buttonOneBackColourOne">The button one back colour one.</param>
        /// <param name="buttonOneBackColourTwo">The button one back colour two.</param>
        /// <param name="buttonTwoBackColourOne">The button two back colour one.</param>
        /// <param name="buttonTwoBackColourTwo">The button two back colour two.</param>
        /// <param name="buttonThreeBackColourOne">The button three back colour one.</param>
        /// <param name="buttonThreeBackColourTwo">The button three back colour two.</param>
        /// <param name="buttonOneTextColourOne">The button one text colour one.</param>
        /// <param name="buttonOneTextColourTwo">The button one text colour two.</param>
        /// <param name="buttonTwoTextColourOne">The button two text colour one.</param>
        /// <param name="buttonTwoTextColourTwo">The button two text colour two.</param>
        /// <param name="buttonThreeTextColourOne">The button three text colour one.</param>
        /// <param name="buttonThreeTextColourTwo">The button three text colour two.</param>
        /// <returns></returns>
        private void AlterButtonColours(Color buttonOneBackColourOne, Color buttonOneBackColourTwo,
                                        Color? buttonTwoBackColourOne, Color? buttonTwoBackColourTwo,
                                        Color? buttonThreeBackColourOne, Color? buttonThreeBackColourTwo,
                                        Color buttonOneTextColourOne, Color buttonOneTextColourTwo,
                                        Color? buttonTwoTextColourOne, Color? buttonTwoTextColourTwo,
                                        Color? buttonThreeTextColourOne, Color? buttonThreeTextColourTwo)
        {
            _button1.StateCommon.Back.Color1 = buttonOneBackColourOne;

            _button1.StateCommon.Back.Color2 = buttonOneBackColourTwo;

            _button1.StateCommon.Content.ShortText.Color1 = buttonOneTextColourOne;

            _button1.StateCommon.Content.ShortText.Color2 = buttonOneTextColourTwo;

            _button2.StateCommon.Back.Color1 = buttonTwoBackColourOne ?? Color.Empty;

            _button2.StateCommon.Back.Color2 = buttonTwoBackColourTwo ?? Color.Empty;

            _button2.StateCommon.Content.ShortText.Color1 = buttonTwoTextColourOne ?? Color.Empty;

            _button2.StateCommon.Content.ShortText.Color2 = buttonTwoTextColourTwo ?? Color.Empty;

            _button3.StateCommon.Back.Color1 = buttonThreeBackColourOne ?? Color.Empty;

            _button3.StateCommon.Back.Color2 = buttonThreeBackColourTwo ?? Color.Empty;

            _button3.StateCommon.Content.ShortText.Color1 = buttonThreeTextColourOne ?? Color.Empty;

            _button3.StateCommon.Content.ShortText.Color2 = buttonThreeTextColourTwo ?? Color.Empty;
        }

        /// <summary>
        /// Adjusts the corner rounding.
        /// </summary>
        /// <param name="cornerRounding">The corner rounding.</param>
        /// <returns></returns>
        private void AdjustCornerRounding(float cornerRounding) => StateCommon.Border.Rounding = cornerRounding;

        #endregion

        #endregion
    }

    #region Types
    internal class HelpInfo
    {
        #region Instance Fields

        #endregion

        #region Identity

        /// <summary>
        /// Initialize a new instance of the HelpInfo class.
        /// </summary>
        /// <param name="helpFilePath">Value for HelpFilePath.</param>
        /// <param name="keyword">Value for Keyword</param>
        public HelpInfo(string helpFilePath = null, string keyword = null)
        : this(helpFilePath, keyword, !string.IsNullOrWhiteSpace(keyword) ? HelpNavigator.Topic : HelpNavigator.TableOfContents, null)
        {

        }

        /// <summary>
        /// Initialize a new instance of the HelpInfo class.
        /// </summary>
        /// <param name="helpFilePath">Value for HelpFilePath.</param>
        /// <param name="navigator">Value for Navigator</param>
        /// <param name="param"></param>
        public HelpInfo(string helpFilePath, HelpNavigator navigator, object param = null)
            : this(helpFilePath, null, navigator, param)
        {

        }

        /// <summary>
        /// Initialize a new instance of the HelpInfo class.
        /// </summary>
        /// <param name="helpFilePath">Value for HelpFilePath.</param>
        /// <param name="navigator">Value for Navigator</param>
        /// <param name="keyword">Value for Keyword</param>
        /// <param name="param"></param>
        private HelpInfo(string helpFilePath, string keyword, HelpNavigator navigator, object param)
        {
            HelpFilePath = helpFilePath;
            Keyword = keyword;
            Navigator = navigator;
            Param = param;
        }
        #endregion

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
    }

    #endregion

    #region MessageButton
    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    internal class MessageButton : KryptonButton
    {

        #region Instance Fields

        #endregion

        #region Identity
        public MessageButton()
        {
            IgnoreAltF4 = false;
            Visible = false;
            Enabled = false;
        }

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
                case PI.WM_.KEYDOWN:
                case PI.WM_.SYSKEYDOWN:
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
}