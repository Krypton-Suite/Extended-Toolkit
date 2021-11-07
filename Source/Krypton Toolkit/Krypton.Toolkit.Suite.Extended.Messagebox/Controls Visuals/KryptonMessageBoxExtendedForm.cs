using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    internal partial class KryptonMessageBoxExtendedForm : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonWrapLabel _messageText;
        private KryptonButton _button4;
        private KryptonButton _button3;
        private KryptonButton _button1;
        private KryptonButton _button2;
        private KryptonCheckBox _optionalCheckBox;
        private TableLayoutPanel tableLayoutPanel2;
        private KryptonPanel kryptonPanel2;
        private KryptonPanel kryptonPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox _messageIcon;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this._messageText = new Krypton.Toolkit.KryptonWrapLabel();
            this._messageIcon = new System.Windows.Forms.PictureBox();
            this.kryptonPanel3 = new Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._button2 = new Krypton.Toolkit.KryptonButton();
            this._button4 = new Krypton.Toolkit.KryptonButton();
            this._button3 = new Krypton.Toolkit.KryptonButton();
            this._button1 = new Krypton.Toolkit.KryptonButton();
            this._optionalCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(299, 55);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.kryptonPanel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.kryptonPanel3, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(308, 60);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.AutoSize = true;
            this.kryptonPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonPanel2.Controls.Add(this._messageText);
            this.kryptonPanel2.Controls.Add(this._messageIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(10, 0);
            this.kryptonPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(288, 20);
            this.kryptonPanel2.TabIndex = 0;
            // 
            // _messageText
            // 
            this._messageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this._messageText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._messageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this._messageText.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this._messageText.Location = new System.Drawing.Point(30, 0);
            this._messageText.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this._messageText.Name = "_messageText";
            this._messageText.Size = new System.Drawing.Size(98, 20);
            this._messageText.Text = "Message Text";
            this._messageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _messageIcon
            // 
            this._messageIcon.BackColor = System.Drawing.Color.Transparent;
            this._messageIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this._messageIcon.Location = new System.Drawing.Point(0, 0);
            this._messageIcon.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this._messageIcon.Name = "_messageIcon";
            this._messageIcon.Size = new System.Drawing.Size(30, 20);
            this._messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._messageIcon.TabIndex = 0;
            this._messageIcon.TabStop = false;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.AutoSize = true;
            this.kryptonPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonPanel3.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel3.Controls.Add(this._optionalCheckBox);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(10, 20);
            this.kryptonPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonPanel3.MinimumSize = new System.Drawing.Size(0, 30);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.kryptonPanel3.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel3.Size = new System.Drawing.Size(288, 30);
            this.kryptonPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this._button2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._button4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this._button3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this._button1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(36, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 2, 2, 3);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(252, 24);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // _button2
            // 
            this._button2.AutoSize = true;
            this._button2.Enabled = false;
            this._button2.Location = new System.Drawing.Point(70, 2);
            this._button2.Margin = new System.Windows.Forms.Padding(0, 0, 10, 3);
            this._button2.MinimumSize = new System.Drawing.Size(50, 26);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(50, 26);
            this._button2.TabIndex = 1;
            this._button2.Values.Text = "B2";
            this._button2.Visible = false;
            // 
            // _button4
            // 
            this._button4.AutoSize = true;
            this._button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._button4.Enabled = false;
            this._button4.Location = new System.Drawing.Point(190, 2);
            this._button4.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this._button4.MinimumSize = new System.Drawing.Size(50, 26);
            this._button4.Name = "_button4";
            this._button4.Size = new System.Drawing.Size(50, 26);
            this._button4.TabIndex = 2;
            this._button4.Values.Text = "B4";
            this._button4.Visible = false;
            // 
            // _button3
            // 
            this._button3.AutoSize = true;
            this._button3.Enabled = false;
            this._button3.Location = new System.Drawing.Point(130, 2);
            this._button3.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this._button3.MinimumSize = new System.Drawing.Size(50, 26);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(50, 26);
            this._button3.TabIndex = 2;
            this._button3.Values.Text = "B3";
            this._button3.Visible = false;
            // 
            // _button1
            // 
            this._button1.AutoSize = true;
            this._button1.Enabled = false;
            this._button1.Location = new System.Drawing.Point(10, 2);
            this._button1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this._button1.MinimumSize = new System.Drawing.Size(50, 26);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(50, 26);
            this._button1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this._button1.TabIndex = 0;
            this._button1.Values.Text = "B1";
            this._button1.Visible = false;
            // 
            // _optionalCheckBox
            // 
            this._optionalCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this._optionalCheckBox.Location = new System.Drawing.Point(0, 3);
            this._optionalCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this._optionalCheckBox.MinimumSize = new System.Drawing.Size(0, 21);
            this._optionalCheckBox.Name = "_optionalCheckBox";
            this._optionalCheckBox.Size = new System.Drawing.Size(36, 24);
            this._optionalCheckBox.StateCommon.Padding = new System.Windows.Forms.Padding(0);
            this._optionalCheckBox.TabIndex = 0;
            this._optionalCheckBox.Values.Text = "C1";
            // 
            // KryptonMessageBoxExtendedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 55);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonMessageBoxExtendedForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.KryptonMessageBoxExtendedForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.kryptonPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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

        private bool _showUACShieldOnAcceptButton, _showOptionalCheckBox, _isOptionalCheckBoxChecked;
        private Color _contentMessageColour, _buttonOneBackColourOne, _buttonOneBackColourTwo,
                      _buttonOneTextColourOne, _buttonOneTextColourTwo,
                      _buttonTwoBackColourOne, _buttonTwoBackColourTwo,
                      _buttonTwoTextColourOne, _buttonTwoTextColourTwo,
                      _buttonThreeBackColourOne, _buttonThreeBackColourTwo,
                      _buttonThreeTextColourOne, _buttonThreeTextColourTwo,
                      _optionalCheckBoxTextColourOne, _optionalCheckBoxTextColourTwo;
        private CheckState _optionalCheckBoxCheckState;
        private DialogResult _buttonOneCustomDialogResult, _buttonTwoCustomDialogResult, _buttonThreeCustomDialogResult;
        private ExtendedMessageBoxCustomButtonVisibility _visibility;
        private Font _messageBoxButtonTypeface, _messageBoxTypeface, _optionalCheckBoxTypeface;
        private float _buttonCornerRounding, _windowCornerRounding;
        private readonly string _optionalCheckBoxText, _copyButtonText, _buttonOneText, _buttonTwoText, _buttonThreeText;

        private void KryptonMessageBoxExtendedForm_Load(object sender, EventArgs e)
        {
            // Make sure that the "Form" is set to the auto size of the table
            ClientSize = tableLayoutPanel2.Size;
        }

        private Image _customMessageBoxIcon;
        private SoundPlayer _player;
        private Stream _soundStream;
        private int _timeoutSeconds;
        private Timer _timer;
        private KryptonCommand _buttonCommandOne, _buttonCommandTwo, _buttonCommandThree;
        #endregion

        #endregion

        #region Identity
        /// <summary>Initializes the <see cref="KryptonMessageBoxExtendedForm" /> class.</summary>
        static KryptonMessageBoxExtendedForm() => OS_MAJOR_VERSION = Environment.OSVersion.Version.Major;

        /// <summary>Initializes a new instance of the <see cref="KryptonMessageBoxExtendedForm" /> class.</summary>
        public KryptonMessageBoxExtendedForm() => InitializeComponent();

        /// <summary>Initializes a new instance of the <see cref="KryptonMessageBoxExtendedForm" /> class.</summary>
        /// <param name="showOwner">The show owner.</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="customButtonVisibility">The custom button visibility.</param>
        /// <param name="buttonOneText">The button one text.</param>
        /// <param name="buttonTwoText">The button two text.</param>
        /// <param name="buttonThreeText">The button three text.</param>
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
        /// <param name="buttonCornerRounding">The button corner rounding.</param>
        /// <param name="windowCornerRounding">The window corner rounding.</param>
        /// <param name="showUacShieldOnAcceptButton">The show uac shield on accept button.</param>
        /// <param name="showOptionalCheckBox">The show optional CheckBox.</param>
        /// <param name="isOptionalCheckBoxChecked">The is optional CheckBox checked.</param>
        /// <param name="optionalCheckBoxTextColourOne">The optional CheckBox text colour one.</param>
        /// <param name="optionalCheckBoxTextColourTwo">The optional CheckBox text colour two.</param>
        /// <param name="optionalCheckBoxTypeface">The optional CheckBox typeface.</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <param name="optionalCheckBoxCheckState">State of the optional CheckBox check.</param>
        internal KryptonMessageBoxExtendedForm(IWin32Window showOwner, string text, string caption,
                                               ExtendedMessageBoxButtons buttons,
                                               ExtendedMessageBoxCustomButtonVisibility? customButtonVisibility,
                                               string buttonOneText, string buttonTwoText, string buttonThreeText,
                                               ExtendedKryptonMessageBoxIcon icon, MessageBoxDefaultButton defaultButton,
                                               DialogResult? customButtonOneDialogResult, DialogResult? customButtonTwoDialogResult,
                                               DialogResult? customButtonThreeDialogResult, MessageBoxOptions options,
                                               HelpInfo helpInfo, bool? showCtrlCopy,
                                               Font? messageBoxButtonTypeface, Font? messageBoxTypeface,
                                               Color? contentMessageColour,
                                               Color? buttonOneBackColourOne, Color? buttonOneBackColourTwo,
                                               Color? buttonOneTextColourOne, Color? buttonOneTextColourTwo,
                                               Color? buttonTwoTextColourOne, Color? buttonTwoTextColourTwo,
                                               Color? buttonTwoBackColourOne, Color? buttonTwoBackColourTwo,
                                               Color? buttonThreeTextColourOne, Color? buttonThreeTextColourTwo,
                                               Color? buttonThreeBackColourOne, Color? buttonThreeBackColourTwo,
                                               float? buttonCornerRounding, float? windowCornerRounding,
                                               bool? showUacShieldOnAcceptButton, bool? showOptionalCheckBox,
                                               bool? isOptionalCheckBoxChecked, Color? optionalCheckBoxTextColourOne,
                                               Color? optionalCheckBoxTextColourTwo, Font? optionalCheckBoxTypeface,
                                               string optionalCheckBoxText, CheckState? optionalCheckBoxCheckState)
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
            _showUACShieldOnAcceptButton = showUacShieldOnAcceptButton ?? false;
            _showOptionalCheckBox = showOptionalCheckBox ?? false;
            _isOptionalCheckBoxChecked = isOptionalCheckBoxChecked ?? false;
            _visibility = customButtonVisibility ?? ExtendedMessageBoxCustomButtonVisibility.NONE;
            _buttonOneText = buttonOneText ?? string.Empty;
            _buttonTwoText = buttonTwoText ?? string.Empty;
            _buttonThreeText = buttonThreeText ?? string.Empty;
            _optionalCheckBoxText = optionalCheckBoxText ?? string.Empty;
            _optionalCheckBoxCheckState = optionalCheckBoxCheckState ?? CheckState.Unchecked;
            _buttonOneCustomDialogResult = customButtonOneDialogResult ?? DialogResult.None;
            _buttonTwoCustomDialogResult = customButtonTwoDialogResult ?? DialogResult.None;
            _buttonThreeCustomDialogResult = customButtonThreeDialogResult ?? DialogResult.None;
            _messageBoxButtonTypeface = messageBoxButtonTypeface ?? new Font(@"Segoe UI", 8.25F);
            _messageBoxTypeface = messageBoxTypeface ?? new Font(@"Segoe UI", 8.25F);
            _optionalCheckBoxTypeface = optionalCheckBoxTypeface ?? new Font(@"Segoe UI", 8.25F);
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
            _optionalCheckBoxTextColourOne = optionalCheckBoxTextColourOne ?? Color.Empty;
            _optionalCheckBoxTextColourTwo = optionalCheckBoxTextColourTwo ?? Color.Empty;
            _buttonCornerRounding = buttonCornerRounding ?? -1;
            _windowCornerRounding = windowCornerRounding ?? -1;

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
            AdjustCornerRounding(_windowCornerRounding);

            ConfigureOptionalCheckBox();

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

                case ExtendedKryptonMessageBoxIcon.WARNING:
                case ExtendedKryptonMessageBoxIcon.QUESTION:
                    _messageIcon.Image = Properties.Resources.Question;
                    SystemSounds.Question.Play();
                    break;

                case ExtendedKryptonMessageBoxIcon.EXCLAMATION:
                case ExtendedKryptonMessageBoxIcon.INFORMATION:
                    _messageIcon.Image = Properties.Resources.Information;
                    SystemSounds.Exclamation.Play();
                    break;


                case ExtendedKryptonMessageBoxIcon.ERROR:
                case ExtendedKryptonMessageBoxIcon.ASTERISK:
                    _messageIcon.Image = Properties.Resources.Asterisk;
                    SystemSounds.Asterisk.Play();
                    break;

                case ExtendedKryptonMessageBoxIcon.HAND:
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
                        case ExtendedMessageBoxCustomButtonVisibility.NONE:
                            _button1.Text = KryptonManager.Strings.OK;
                            _button1.DialogResult = DialogResult.OK;
                            _button1.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
                            _button1.Visible = true;
                            _button1.Enabled = true;
                            break;
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

            AlterButtonColours(_buttonOneBackColourOne, _buttonOneBackColourTwo,
                _buttonTwoBackColourOne, _buttonTwoBackColourTwo,
                _buttonThreeBackColourOne, _buttonThreeBackColourTwo,
                _buttonOneTextColourOne, _buttonOneTextColourTwo,
                _buttonTwoTextColourOne, _buttonTwoTextColourTwo,
                _buttonThreeTextColourOne, _buttonThreeTextColourTwo,
                _buttonCornerRounding);

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

            //if (_visibility != null)
            //{
            //    MessageButton helpButtonExtended = _visibility switch
            //    {

            //    };
            //}
            //else
            //{

            KryptonButton helpButton = _buttons switch
            {
                ExtendedMessageBoxButtons.CUSTOM => _visibility switch
                {
                    ExtendedMessageBoxCustomButtonVisibility.NONE => _button1,
                    ExtendedMessageBoxCustomButtonVisibility.ONEBUTTON => _button2,
                    ExtendedMessageBoxCustomButtonVisibility.TWOBUTTONS => _button3,
                    ExtendedMessageBoxCustomButtonVisibility.THREEBUTTONS => _button4,
                    _ => _button1 //throw new ArgumentOutOfRangeException()
                },
                ExtendedMessageBoxButtons.OK => _button2,
                ExtendedMessageBoxButtons.YESNO => _button3,
                ExtendedMessageBoxButtons.OKCANCEL => _button3,
                ExtendedMessageBoxButtons.RETRYCANCEL => _button3,
                ExtendedMessageBoxButtons.ABORTRETRYIGNORE => _button4,
                ExtendedMessageBoxButtons.YESNOCANCEL => _button4,
                _ => _button1 //throw new ArgumentOutOfRangeException()
            };

            if (helpButton != _button1)
            {
                helpButton.Visible = true;

                helpButton.Enabled = true;
                helpButton.Text = KryptonManager.Strings.Help;
                helpButton.StateCommon.Content.ShortText.Font = _messageBoxButtonTypeface;
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
        /// <param name="buttonCornerRounding"></param>
        /// <returns></returns>
        private void AlterButtonColours(Color buttonOneBackColourOne, Color buttonOneBackColourTwo,
            Color? buttonTwoBackColourOne, Color? buttonTwoBackColourTwo,
            Color? buttonThreeBackColourOne, Color? buttonThreeBackColourTwo,
            Color buttonOneTextColourOne, Color buttonOneTextColourTwo,
            Color? buttonTwoTextColourOne, Color? buttonTwoTextColourTwo,
            Color? buttonThreeTextColourOne, Color? buttonThreeTextColourTwo, float buttonCornerRounding)
        {
            _button1.StateCommon.Border.Rounding = buttonCornerRounding;
            _button1.StateCommon.Back.Color1 = buttonOneBackColourOne;
            _button1.StateCommon.Back.Color2 = buttonOneBackColourTwo;
            _button1.StateCommon.Content.ShortText.Color1 = buttonOneTextColourOne;
            _button1.StateCommon.Content.ShortText.Color2 = buttonOneTextColourTwo;

            _button2.StateCommon.Border.Rounding = buttonCornerRounding;
            _button2.StateCommon.Back.Color1 = buttonTwoBackColourOne ?? Color.Empty;
            _button2.StateCommon.Back.Color2 = buttonTwoBackColourTwo ?? Color.Empty;
            _button2.StateCommon.Content.ShortText.Color1 = buttonTwoTextColourOne ?? Color.Empty;
            _button2.StateCommon.Content.ShortText.Color2 = buttonTwoTextColourTwo ?? Color.Empty;

            _button3.StateCommon.Border.Rounding = buttonCornerRounding;
            _button3.StateCommon.Back.Color1 = buttonThreeBackColourOne ?? Color.Empty;
            _button3.StateCommon.Back.Color2 = buttonThreeBackColourTwo ?? Color.Empty;
            _button3.StateCommon.Content.ShortText.Color1 = buttonThreeTextColourOne ?? Color.Empty;
            _button3.StateCommon.Content.ShortText.Color2 = buttonThreeTextColourTwo ?? Color.Empty;
            // TODO: What values should be used for the help Button if it is #4
        }

        /// <summary>
        /// Adjusts the corner rounding.
        /// </summary>
        /// <param name="cornerRounding">The corner rounding.</param>
        /// <returns></returns>
        private void AdjustCornerRounding(float cornerRounding) => StateCommon.Border.Rounding = cornerRounding;

        /// <summary>
        /// Configures the optional CheckBox.
        /// </summary>
        private void ConfigureOptionalCheckBox()
        {
            _optionalCheckBox.Visible = _showOptionalCheckBox;

            _optionalCheckBox.Checked = _isOptionalCheckBoxChecked;

            _optionalCheckBox.Text = _optionalCheckBoxText;

            _optionalCheckBox.StateCommon.ShortText.Color1 = _optionalCheckBoxTextColourOne;

            _optionalCheckBox.StateCommon.ShortText.Color2 = _optionalCheckBoxTextColourTwo;

            _optionalCheckBox.StateCommon.ShortText.Font = _optionalCheckBoxTypeface;

            _optionalCheckBox.CheckState = _optionalCheckBoxCheckState;
        }

        /// <summary>
        /// Returns the optional CheckBox checked status.
        /// </summary>
        /// <returns>The optional CheckBox checked status.</returns>
        public bool ReturnOptionalCheckBoxCheckedStatus() => _optionalCheckBox.Checked;

        /// <summary>
        /// Returns the state of the optional CheckBox check.
        /// </summary>
        /// <returns>The check state of the optional CheckBox.</returns>
        public CheckState ReturnOptionalCheckBoxCheckState() => _optionalCheckBox.CheckState;
        #endregion

        #endregion
    }


}