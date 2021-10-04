namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    internal partial class KryptonMessageBoxExtendedForm : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private KryptonWrapLabel _messageText;
        private KryptonPanel _panelControls;
        private KryptonBorderEdge _borderEdge;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private KryptonPanel _panelOptionalCheckBox;
        private KryptonCheckBox _optionalCheckBox;
        private KryptonPanel _panelButtons;
        private MessageButton _button4;
        private MessageButton _button3;
        private MessageButton _button2;
        private MessageButton _button1;
        private PictureBox _messageIcon;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonMessageBoxExtendedForm));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._messageText = new Krypton.Toolkit.KryptonWrapLabel();
            this._panelControls = new Krypton.Toolkit.KryptonPanel();
            this._borderEdge = new Krypton.Toolkit.KryptonBorderEdge();
            this._messageIcon = new System.Windows.Forms.PictureBox();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this._panelOptionalCheckBox = new Krypton.Toolkit.KryptonPanel();
            this._optionalCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this._panelButtons = new Krypton.Toolkit.KryptonPanel();
            this._button4 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button3 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button2 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button1 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelControls)).BeginInit();
            this._panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).BeginInit();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelOptionalCheckBox)).BeginInit();
            this._panelOptionalCheckBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).BeginInit();
            this._panelButtons.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this._panelControls, 0, 1);
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
            // _panelControls
            // 
            this.tableLayoutPanel1.SetColumnSpan(this._panelControls, 2);
            this._panelControls.Controls.Add(this.kryptonTableLayoutPanel1);
            this._panelControls.Controls.Add(this._borderEdge);
            this._panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelControls.Location = new System.Drawing.Point(0, 42);
            this._panelControls.Margin = new System.Windows.Forms.Padding(0);
            this._panelControls.Name = "_panelControls";
            this._panelControls.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._panelControls.Size = new System.Drawing.Size(183, 21);
            this._panelControls.TabIndex = 0;
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
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 2;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.Controls.Add(this._panelOptionalCheckBox, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this._panelButtons, 1, 0);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 1);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonTableLayoutPanel1.RowCount = 1;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(183, 20);
            this.kryptonTableLayoutPanel1.TabIndex = 5;
            // 
            // _panelOptionalCheckBox
            // 
            this._panelOptionalCheckBox.Controls.Add(this._optionalCheckBox);
            this._panelOptionalCheckBox.Location = new System.Drawing.Point(3, 3);
            this._panelOptionalCheckBox.Name = "_panelOptionalCheckBox";
            this._panelOptionalCheckBox.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._panelOptionalCheckBox.Size = new System.Drawing.Size(100, 14);
            this._panelOptionalCheckBox.TabIndex = 0;
            // 
            // _optionalCheckBox
            // 
            this._optionalCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._optionalCheckBox.Location = new System.Drawing.Point(0, 0);
            this._optionalCheckBox.Name = "_optionalCheckBox";
            this._optionalCheckBox.Size = new System.Drawing.Size(100, 14);
            this._optionalCheckBox.TabIndex = 0;
            this._optionalCheckBox.Values.Text = "CB1";
            // 
            // _panelButtons
            // 
            this._panelButtons.Controls.Add(this._button4);
            this._panelButtons.Controls.Add(this._button3);
            this._panelButtons.Controls.Add(this._button2);
            this._panelButtons.Controls.Add(this._button1);
            this._panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelButtons.Location = new System.Drawing.Point(109, 3);
            this._panelButtons.Name = "_panelButtons";
            this._panelButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._panelButtons.Size = new System.Drawing.Size(100, 14);
            this._panelButtons.TabIndex = 1;
            // 
            // _button4
            // 
            this._button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button4.AutoSize = true;
            this._button4.Enabled = false;
            this._button4.IgnoreAltF4 = false;
            this._button4.Location = new System.Drawing.Point(101, -4);
            this._button4.Margin = new System.Windows.Forms.Padding(0);
            this._button4.MinimumSize = new System.Drawing.Size(38, 21);
            this._button4.Name = "_button4";
            this._button4.Size = new System.Drawing.Size(38, 23);
            this._button4.TabIndex = 3;
            this._button4.Values.Text = "B4";
            this._button4.Visible = false;
            // 
            // _button3
            // 
            this._button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button3.AutoSize = true;
            this._button3.Enabled = false;
            this._button3.IgnoreAltF4 = false;
            this._button3.Location = new System.Drawing.Point(65, -4);
            this._button3.Margin = new System.Windows.Forms.Padding(0);
            this._button3.MinimumSize = new System.Drawing.Size(38, 21);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(38, 23);
            this._button3.TabIndex = 4;
            this._button3.Values.Text = "B3";
            this._button3.Visible = false;
            // 
            // _button2
            // 
            this._button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button2.AutoSize = true;
            this._button2.Enabled = false;
            this._button2.IgnoreAltF4 = false;
            this._button2.Location = new System.Drawing.Point(26, -4);
            this._button2.Margin = new System.Windows.Forms.Padding(0);
            this._button2.MinimumSize = new System.Drawing.Size(38, 21);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(38, 23);
            this._button2.TabIndex = 5;
            this._button2.Values.Text = "B2";
            this._button2.Visible = false;
            // 
            // _button1
            // 
            this._button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button1.AutoSize = true;
            this._button1.Enabled = false;
            this._button1.IgnoreAltF4 = false;
            this._button1.Location = new System.Drawing.Point(-12, -4);
            this._button1.Margin = new System.Windows.Forms.Padding(0);
            this._button1.MinimumSize = new System.Drawing.Size(38, 21);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(38, 23);
            this._button1.TabIndex = 6;
            this._button1.Values.Text = "B1";
            this._button1.Visible = false;
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
            ((System.ComponentModel.ISupportInitialize)(this._panelControls)).EndInit();
            this._panelControls.ResumeLayout(false);
            this._panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).EndInit();
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._panelOptionalCheckBox)).EndInit();
            this._panelOptionalCheckBox.ResumeLayout(false);
            this._panelOptionalCheckBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).EndInit();
            this._panelButtons.ResumeLayout(false);
            this._panelButtons.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Static Fields
        private const int GAP = 10;
        private static readonly int OS_MAJOR_VERSION;
        #endregion

        #region Instance Fields
        private readonly string _text, _optionalCheckBoxText, _copyButtonText, _buttonOneText, _buttonTwoText, _buttonThreeText;
        private readonly string _caption;
        private readonly ExtendedMessageBoxButtons _buttons;
        private readonly ExtendedMessageBoxCustomButtonOptions _customButtonOptions;
        private readonly ExtendedKryptonMessageBoxIcon _icon;
        private readonly MessageBoxDefaultButton _defaultButton;
        private AnchorStyles _optionalCheckBoxAnchor;
        private MessageBoxOptions _options; // https://github.com/Krypton-Suite/Standard-Toolkit/issues/313
                                            // If help information provided or we are not a service/default desktop application then grab an owner for showing the message box
        private bool _fade, _showOptionalCheckBox, _showCopyButton, _hasTimedOut, _showToolTips;
        private CheckState _optionalCheckBoxCheckState;
        private DialogResult _buttonOneResult, _buttonTwoResult, _buttonThreeResult;
        private Double _fadeIn, _fadeOut;
        public static bool _isOptionalCheckBoxChecked;
        private int _fadeSleepTimer, _timeOut, _blurRadius;
        private readonly MessageBoxIcon _messageBoxIcon;
        private Font _messageboxTypeface;
        private Image _customMessageBoxIcon;
        private Point _optionalCheckBoxLocation;
        private bool _useBlur;
        private bool? _useYesNoCancelButtonColour;
        private KryptonForm _parentWindow;
        private Color? _contentMessageColour, _buttonOneTextColour, _buttonTwoTextColour,
                       _buttonThreeTextColour, _yesButtonColour, _noButtonColour, _textColour,
                       _yesNoButtonTextColour;
        private readonly IWin32Window _showOwner;
        private readonly HelpInfo _helpInfo;
        private float _cornerRadius;
        #endregion

        #region Identity
        static KryptonMessageBoxExtendedForm() => OS_MAJOR_VERSION = Environment.OSVersion.Version.Major;

        /// <summary>Initializes a new instance of the <see cref="KryptonMessageBoxExtendedForm" /> class.</summary>
        public KryptonMessageBoxExtendedForm() => InitializeComponent();

        /// <summary>Initializes a new instance of the <see cref="KryptonMessageBoxExtendedForm" /> class.</summary>
        /// <param name="showOwner">The show owner.</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="helpInfo">The help information.</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="messageboxTypeface">The messagebox typeface.</param>
        /// <param name="showOptionalCheckBox">The show optional CheckBox.</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <param name="isOptionalCheckBoxChecked">The is optional CheckBox checked.</param>
        /// <param name="optionalCheckBoxCheckState">State of the optional CheckBox check.</param>
        /// <param name="optionalCheckBoxAnchor">The optional CheckBox anchor.</param>
        /// <param name="optionalCheckBoxLocation">The optional CheckBox location.</param>
        /// <param name="customMessageBoxIcon">The custom message box icon.</param>
        /// <param name="showCopyButton">The show copy button.</param>
        /// <param name="copyButtonText">The copy button text.</param>
        /// <param name="fade">The fade.</param>
        /// <param name="fadeSleepTimer">The fade sleep timer.</param>
        /// <param name="buttonOneCustomText">The button one custom text.</param>
        /// <param name="buttonTwoCustomText">The button two custom text.</param>
        /// <param name="buttonThreeCustomText">The button three custom text.</param>
        /// <param name="buttonOneCustomDialogResult">The button one custom dialog result.</param>
        /// <param name="buttonTwoCustomDialogResult">The button two custom dialog result.</param>
        /// <param name="buttonThreeCustomDialogResult">The button three custom dialog result.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="showToolTips">The show tool tips.</param>
        /// <param name="useBlur">The use blur.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window.</param>
        internal KryptonMessageBoxExtendedForm(IWin32Window showOwner, string text, string caption, ExtendedMessageBoxButtons buttons,
                                               ExtendedKryptonMessageBoxIcon icon, MessageBoxDefaultButton defaultButton,
                                               MessageBoxOptions options, HelpInfo helpInfo, bool? showCtrlCopy,
                                               Font messageboxTypeface, bool? showOptionalCheckBox, string optionalCheckBoxText,
                                               bool? isOptionalCheckBoxChecked, CheckState? optionalCheckBoxCheckState,
                                               AnchorStyles? optionalCheckBoxAnchor, Point? optionalCheckBoxLocation,
                                               Image customMessageBoxIcon, bool? showCopyButton, string copyButtonText,
                                               bool? fade, int? fadeSleepTimer, string buttonOneCustomText,
                                               string buttonTwoCustomText, string buttonThreeCustomText,
                                               DialogResult? buttonOneCustomDialogResult, DialogResult? buttonTwoCustomDialogResult,
                                               DialogResult? buttonThreeCustomDialogResult, float? cornerRadius,
                                               bool? showToolTips, bool? useBlur, bool? useYesNoCancelButtonColour,
                                               int? blurRadius, Color? contentMessageColour, Color? buttonOneTextColour,
                                               Color? buttonTwoTextColour, Color? buttonThreeTextColour,
                                               Color? yesButtonColour, Color? noButtonColour, Color? textColour,
                                               Color? yesNoButtonTextColour, KryptonForm? parentWindow)
        {
            #region Stored Values
            _showOwner = showOwner;

            _text = text;

            _caption = caption;

            _buttons = buttons;

            _icon = icon;

            _defaultButton = defaultButton;

            _options = options;

            _helpInfo = helpInfo;

            _messageboxTypeface = messageboxTypeface ?? new Font("Seoge UI", 9f);

            _showOptionalCheckBox = showOptionalCheckBox ?? false;

            _optionalCheckBoxText = optionalCheckBoxText;

            _isOptionalCheckBoxChecked = isOptionalCheckBoxChecked ?? false;

            _optionalCheckBoxCheckState = optionalCheckBoxCheckState ?? CheckState.Unchecked;

            _optionalCheckBoxAnchor = optionalCheckBoxAnchor ?? AnchorStyles.Top | AnchorStyles.Bottom;

            _optionalCheckBoxLocation = optionalCheckBoxLocation ?? new Point(12, 0);

            _customMessageBoxIcon = customMessageBoxIcon;

            _showCopyButton = showCopyButton ?? false;

            _copyButtonText = copyButtonText ?? "&Copy";

            _fade = fade ?? false;

            _fadeSleepTimer = fadeSleepTimer ?? 60;

            _buttonOneText = buttonOneCustomText ?? "&Yes";

            _buttonTwoText = buttonTwoCustomText ?? "&No";

            _buttonThreeText = buttonThreeCustomText ?? "&Cancel";

            _buttonOneResult = buttonOneCustomDialogResult ?? DialogResult.Yes;

            _buttonTwoResult = buttonTwoCustomDialogResult ?? DialogResult.No;

            _buttonThreeResult = buttonThreeCustomDialogResult ?? DialogResult.Cancel;

            _cornerRadius = cornerRadius ?? GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE;

            _showToolTips = showToolTips ?? false;

            _useBlur = useBlur ?? false;

            _useYesNoCancelButtonColour = useYesNoCancelButtonColour ?? false;

            _blurRadius = blurRadius ?? 0;

            _contentMessageColour = contentMessageColour ?? Color.Empty;

            _buttonOneTextColour = buttonOneTextColour ?? Color.Empty;

            _buttonTwoTextColour = buttonTwoTextColour ?? Color.Empty;

            _buttonThreeTextColour = buttonThreeTextColour ?? Color.Empty;

            _yesButtonColour = yesButtonColour ?? Color.Empty;

            _noButtonColour = noButtonColour ?? Color.Empty;

            _textColour = textColour ?? Color.Empty;

            _yesNoButtonTextColour = yesNoButtonTextColour ?? Color.Empty;

            _parentWindow = parentWindow ?? null;
            #endregion

            InitializeComponent();

            //RightToLeft = options.HasFlag(MessageBoxOptions.RtlReading);

            #region Setup Contents
            UpdateText();

            UpdateIcon();

            UpdateButtons();

            UpdateDefault();

            UpdateHelp();

            UpdateTextExtra(showCtrlCopy);

            // Finally calculate and set form sizing
            UpdateSizing(showOwner);

            ShowOptionalCheckBoxUI(showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation);

            ShowCopyButton(showCopyButton, copyButtonText);

            // Define a corner radius, default is GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE
            StateCommon.Border.Rounding = _cornerRadius;

            // Blur window
            if (_useBlur)
            {
                if (showOwner is KryptonForm)
                {
                    _parentWindow = (KryptonForm)showOwner;

                    _parentWindow.BlurValues.EnableBlur = _useBlur;

                    _parentWindow.BlurValues.BlurWhenFocusLost = _useBlur;

                    _parentWindow.BlurValues.Radius = Convert.ToByte(_blurRadius);
                }
                else if (_parentWindow != null)
                {
                    showOwner = parentWindow;

                    _parentWindow.BlurValues.EnableBlur = _useBlur;

                    _parentWindow.BlurValues.BlurWhenFocusLost = _useBlur;

                    _parentWindow.BlurValues.Radius = Convert.ToByte(_blurRadius);
                }
            }

            // Change Yes, No and Cancel button colours
            if (_useYesNoCancelButtonColour != null)
            {
                if (_yesButtonColour == null && _noButtonColour == null)
                {
                    ChangeAbortCancelNoYesButtonColour(buttons, Color.Green, Color.Red, Color.White);
                }
                else
                {
                    ChangeAbortCancelNoYesButtonColour(_buttons, yesButtonColour, noButtonColour, yesNoButtonTextColour);
                }
            }
            else
            {
                ChangeAbortCancelNoYesButtonColour(_buttons, Color.Empty, Color.Empty, Color.Empty);
            }
            #endregion
        }
        #endregion

        #region Implementation
        private void UpdateText()
        {
            Text = (string.IsNullOrEmpty(_caption) ? string.Empty : _caption.Split(Environment.NewLine.ToCharArray())[0]);

            if (_textColour != null || _textColour != Color.Empty)
            {
                _messageText.StateCommon.TextColor = (Color)_textColour;

                _optionalCheckBox.StateCommon.ShortText.Color1 = (Color)_textColour;

                _optionalCheckBox.StateCommon.ShortText.Color2 = (Color)_textColour;
            }
            else if (_contentMessageColour != null || _contentMessageColour != Color.Empty)
            {
                _messageText.StateCommon.TextColor = (Color)_contentMessageColour;
            }
            else
            {
                _messageText.StateCommon.TextColor = Color.Empty;

                _optionalCheckBox.StateCommon.ShortText.Color1 = Color.Empty;

                _optionalCheckBox.StateCommon.ShortText.Color2 = Color.Empty;
            }
        }

        private void UpdateTextExtra(bool? showCtrlCopy)
        {
            if (!showCtrlCopy.HasValue)
            {
                switch (_icon)
                {
                    case ExtendedKryptonMessageBoxIcon.ERROR:
                    case ExtendedKryptonMessageBoxIcon.EXCLAMATION:
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
                case ExtendedKryptonMessageBoxIcon.CUSTOM:
                    _messageIcon.Image = _customMessageBoxIcon;
                    break;
                case ExtendedKryptonMessageBoxIcon.NONE:
                    _messageIcon.Visible = false;
                    _messageText.Left -= _messageIcon.Right;

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
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.HAND:
                    _messageIcon.Image = Properties.Resources.Hand;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.STOP:
                    _messageIcon.Image = Properties.Resources.Stop;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.ASTERISK:
                    _messageIcon.Image = Properties.Resources.Critical;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.SHIELD:
                    _messageIcon.Image = SystemIcons.Shield.ToBitmap();
                    SystemSounds.Beep.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.WINDOWSLOGO:
                    _messageIcon.Image = SystemIcons.WinLogo.ToBitmap();
                    break;
            }
        }

        private void UpdateButtons()
        {
            switch (_buttons)
            {
                case ExtendedMessageBoxButtons.CUSTOM:
                    SetCustomButtonText(_customButtonOptions, _buttonOneText, _buttonOneResult, _buttonTwoText, _buttonTwoResult, _buttonThreeText, _buttonThreeResult);
                    break;
                case ExtendedMessageBoxButtons.OK:
                    _button1.Text = KryptonManager.Strings.OK;
                    _button1.DialogResult = DialogResult.OK;
                    _button1.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    _button2.Visible = _button3.Visible = false;
                    break;
                case ExtendedMessageBoxButtons.OKCANCEL:
                    _button1.Text = KryptonManager.Strings.OK;
                    _button2.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.OK;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    _button3.Visible = false;
                    break;
                case ExtendedMessageBoxButtons.YESNO:
                    _button1.Text = KryptonManager.Strings.Yes;
                    _button2.Text = KryptonManager.Strings.No;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button1.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    _button3.Visible = false;
                    ControlBox = false;
                    break;
                case ExtendedMessageBoxButtons.YESNOCANCEL:
                    _button1.Text = KryptonManager.Strings.Yes;
                    _button2.Text = KryptonManager.Strings.No;
                    _button3.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button3.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    _button3.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    break;
                case ExtendedMessageBoxButtons.RETRYCANCEL:
                    _button1.Text = KryptonManager.Strings.Retry;
                    _button2.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.Retry;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    _button3.Visible = false;
                    break;
                case ExtendedMessageBoxButtons.ABORTRETRYIGNORE:
                    _button1.Text = KryptonManager.Strings.Abort;
                    _button2.Text = KryptonManager.Strings.Retry;
                    _button3.Text = KryptonManager.Strings.Ignore;
                    _button1.DialogResult = DialogResult.Abort;
                    _button2.DialogResult = DialogResult.Retry;
                    _button3.DialogResult = DialogResult.Ignore;
                    _button1.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    _button3.StateCommon.Content.ShortText.Font = _messageboxTypeface;
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

        // TODO: Complete this
        private void SetCustomButtonText(ExtendedMessageBoxCustomButtonOptions customButtonOptions, string buttonOneText, DialogResult buttonOneResult, string buttonTwoText, DialogResult buttonTwoResult, string buttonThreeText, DialogResult buttonThreeResult)
        {
            throw new NotImplementedException();
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
            Padding panelMessagePadding = _messageText.Padding;
            _messageText.Width = _messageText.Size.Width + panelMessagePadding.Horizontal;
            _messageText.Height = _messageText.Size.Height + panelMessagePadding.Vertical;

            // Find size of icon area plus the text area added together
            Size panelSize = _messageText.Size;
            if (_messageIcon.Image != null)
            {
                panelSize.Width += _messageIcon.Width;
                panelSize.Height = Math.Max(panelSize.Height, _messageIcon.Height);
            }

            // Enforce a minimum size for the message area
            panelSize = new Size(Math.Max(_messageText.Size.Width, panelSize.Width),
                                 Math.Max(_messageText.Size.Height, panelSize.Height));

            // Note that the width will be ignored in this update, but that is fine as 
            // it will be adjusted by the UpdateSizing method that is the caller.
            _messageText.Size = panelSize;
            return panelSize;
        }

        private Size UpdateButtonsSizing()
        {
            int numButtons = 1;

            // Button1 is always visible
            Size button1Size = _button1.GetPreferredSize(Size.Empty);
            Size maxButtonSize = new(button1Size.Width + GAP, button1Size.Height);

            // TODO: Setup custom buttons

            // If Button2 is visible
            switch (_buttons)
            {
                case ExtendedMessageBoxButtons.CUSTOM:
                case ExtendedMessageBoxButtons.OK:
                case ExtendedMessageBoxButtons.YESNO:
                case ExtendedMessageBoxButtons.YESNOCANCEL:
                case ExtendedMessageBoxButtons.RETRYCANCEL:
                case ExtendedMessageBoxButtons.ABORTRETRYIGNORE:
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
                case ExtendedMessageBoxButtons.CUSTOM:
                case ExtendedMessageBoxButtons.YESNOCANCEL:
                case ExtendedMessageBoxButtons.ABORTRETRYIGNORE:
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
                case ExtendedMessageBoxButtons.CUSTOM:
                case ExtendedMessageBoxButtons.YESNOCANCEL:
                case ExtendedMessageBoxButtons.ABORTRETRYIGNORE:
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
                case ExtendedMessageBoxButtons.CUSTOM:
                case ExtendedMessageBoxButtons.OKCANCEL:
                case ExtendedMessageBoxButtons.YESNO:
                case ExtendedMessageBoxButtons.YESNOCANCEL:
                case ExtendedMessageBoxButtons.RETRYCANCEL:
                case ExtendedMessageBoxButtons.ABORTRETRYIGNORE:
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
                    StringBuilder sb = new();

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

        private void ChangeAbortCancelNoYesButtonColour(ExtendedMessageBoxButtons buttons, Color? yesButtonColour, Color? noButtonColour, Color? yesNoButtonTextColour)
        {
            switch (buttons)
            {
                case ExtendedMessageBoxButtons.CUSTOM:
                    break;
                case ExtendedMessageBoxButtons.OK:
                    if (yesButtonColour != null || yesButtonColour == Color.Empty)
                    {
                        _button1.StateCommon.Back.Color1 = (Color)yesButtonColour;

                        _button1.StateCommon.Back.Color2 = (Color)yesButtonColour;

                        _button1.StateCommon.Content.ShortText.Color1 = (Color)yesNoButtonTextColour;

                        _button1.StateCommon.Content.ShortText.Color2 = (Color)yesButtonColour;
                    }
                    else
                    {
                        _button1.StateCommon.Back.Color1 = Color.Empty;

                        _button1.StateCommon.Back.Color2 = Color.Empty;

                        _button1.StateCommon.Content.ShortText.Color1 = Color.Empty;

                        _button1.StateCommon.Content.ShortText.Color2 = Color.Empty;
                    }
                    break;
                case ExtendedMessageBoxButtons.OKCANCEL:
                    if (yesButtonColour != null || yesButtonColour == Color.Empty && noButtonColour != null || noButtonColour == Color.Empty)
                    {
                        _button1.StateCommon.Back.Color1 = (Color)noButtonColour;

                        _button1.StateCommon.Back.Color2 = (Color)noButtonColour;

                        _button2.StateCommon.Back.Color1 = (Color)yesButtonColour;

                        _button2.StateCommon.Back.Color2 = (Color)yesButtonColour;

                        _button1.StateCommon.Content.ShortText.Color1 = (Color)yesNoButtonTextColour;

                        _button1.StateCommon.Content.ShortText.Color2 = (Color)yesNoButtonTextColour;

                        _button2.StateCommon.Content.ShortText.Color1 = (Color)yesNoButtonTextColour;

                        _button2.StateCommon.Content.ShortText.Color2 = (Color)yesNoButtonTextColour;
                    }
                    else
                    {
                        _button1.StateCommon.Back.Color1 = Color.Empty;

                        _button1.StateCommon.Back.Color2 = Color.Empty;

                        _button1.StateCommon.Content.ShortText.Color1 = Color.Empty;

                        _button1.StateCommon.Content.ShortText.Color2 = Color.Empty;

                        _button2.StateCommon.Back.Color1 = Color.Empty;

                        _button2.StateCommon.Back.Color2 = Color.Empty;

                        _button2.StateCommon.Content.ShortText.Color1 = Color.Empty;

                        _button2.StateCommon.Content.ShortText.Color2 = Color.Empty;
                    }
                    break;
                case ExtendedMessageBoxButtons.ABORTRETRYIGNORE:
                    if (yesButtonColour != null || yesButtonColour == Color.Empty && noButtonColour != null || noButtonColour == Color.Empty)
                    {

                    }
                    else
                    {

                    }
                    break;
                case ExtendedMessageBoxButtons.YESNOCANCEL:
                    if (yesButtonColour != null || yesButtonColour == Color.Empty && noButtonColour != null || noButtonColour == Color.Empty)
                    {

                    }
                    else
                    {

                    }
                    break;
                case ExtendedMessageBoxButtons.YESNO:
                    if (yesButtonColour != null || yesButtonColour == Color.Empty && noButtonColour != null || noButtonColour == Color.Empty)
                    {
                        _button1.StateCommon.Back.Color1 = (Color)noButtonColour;

                        _button1.StateCommon.Back.Color2 = (Color)noButtonColour;

                        _button2.StateCommon.Back.Color1 = (Color)yesButtonColour;

                        _button2.StateCommon.Back.Color2 = (Color)yesButtonColour;

                        _button1.StateCommon.Content.ShortText.Color1 = (Color)yesNoButtonTextColour;

                        _button1.StateCommon.Content.ShortText.Color2 = (Color)yesNoButtonTextColour;

                        _button2.StateCommon.Content.ShortText.Color1 = (Color)yesNoButtonTextColour;

                        _button2.StateCommon.Content.ShortText.Color2 = (Color)yesNoButtonTextColour;
                    }
                    else
                    {
                        _button1.StateCommon.Back.Color1 = Color.Empty;

                        _button1.StateCommon.Back.Color2 = Color.Empty;

                        _button1.StateCommon.Content.ShortText.Color1 = Color.Empty;

                        _button1.StateCommon.Content.ShortText.Color2 = Color.Empty;

                        _button2.StateCommon.Back.Color1 = Color.Empty;

                        _button2.StateCommon.Back.Color2 = Color.Empty;

                        _button2.StateCommon.Content.ShortText.Color1 = Color.Empty;

                        _button2.StateCommon.Content.ShortText.Color2 = Color.Empty;
                    }
                    break;
                case ExtendedMessageBoxButtons.RETRYCANCEL:
                    if (yesButtonColour != null || yesButtonColour == Color.Empty && noButtonColour != null || noButtonColour == Color.Empty)
                    {
                        _button1.StateCommon.Back.Color1 = (Color)noButtonColour;

                        _button1.StateCommon.Back.Color2 = (Color)noButtonColour;

                        _button2.StateCommon.Back.Color1 = (Color)yesButtonColour;

                        _button2.StateCommon.Back.Color2 = (Color)yesButtonColour;

                        _button1.StateCommon.Content.ShortText.Color1 = (Color)yesNoButtonTextColour;

                        _button1.StateCommon.Content.ShortText.Color2 = (Color)yesNoButtonTextColour;

                        _button2.StateCommon.Content.ShortText.Color1 = (Color)yesNoButtonTextColour;

                        _button2.StateCommon.Content.ShortText.Color2 = (Color)yesNoButtonTextColour;
                    }
                    else
                    {
                        _button1.StateCommon.Back.Color1 = Color.Empty;

                        _button1.StateCommon.Back.Color2 = Color.Empty;

                        _button1.StateCommon.Content.ShortText.Color1 = Color.Empty;

                        _button1.StateCommon.Content.ShortText.Color2 = Color.Empty;

                        _button2.StateCommon.Back.Color1 = Color.Empty;

                        _button2.StateCommon.Back.Color2 = Color.Empty;

                        _button2.StateCommon.Content.ShortText.Color1 = Color.Empty;

                        _button2.StateCommon.Content.ShortText.Color2 = Color.Empty;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Optional CheckBox
        private void checkbox_CheckChanged(object sender, EventArgs e) => SetOptionalCheckBoxValue(_optionalCheckBox.Checked);

        private void checkBox_CheckStateChanged(object sender, EventArgs e) => SetOptionalCheckBoxCheckState(_optionalCheckBox.CheckState);

        /// <summary>Shows the optional CheckBox UI.</summary>
        /// <param name="showOptionalCheckBox">if set to <c>true</c> [show optional CheckBox].</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <param name="isOptionalCheckBoxChecked">if set to <c>true</c> [is optional CheckBox checked].</param>
        /// <param name="optionalCheckBoxCheckState">State of the optional CheckBox check.</param>
        /// <param name="optionalCheckBoxAnchor">The optional CheckBox anchor.</param>
        /// <param name="optionalCheckBoxLocation">The optional CheckBox location.</param>
        private void ShowOptionalCheckBoxUI(bool? showOptionalCheckBox, string optionalCheckBoxText,
                                            bool? isOptionalCheckBoxChecked, CheckState? optionalCheckBoxCheckState,
                                            AnchorStyles? optionalCheckBoxAnchor, Point? optionalCheckBoxLocation)
        {
            _optionalCheckBox.Visible = showOptionalCheckBox ?? false;

            _optionalCheckBox.Text = optionalCheckBoxText;

            _optionalCheckBox.Checked = isOptionalCheckBoxChecked ?? false;

            _optionalCheckBox.CheckState = optionalCheckBoxCheckState ?? CheckState.Unchecked;

            _optionalCheckBox.Anchor = optionalCheckBoxAnchor ?? AnchorStyles.Left;

            _optionalCheckBoxLocation = optionalCheckBoxLocation ?? new Point(12, 0);

            _optionalCheckBox.StateCommon.ShortText.Font = _messageboxTypeface;
        }

        private void checkBox_TextChanged(object sender, EventArgs e)
        {
            if (_optionalCheckBox.Text.Length >= 15)
            {

                _optionalCheckBox.StateCommon.ShortText.Trim = PaletteTextTrim.EllipsisWord;
            }
        }
        #endregion

        #region Setters and Getters
        /// <summary>Sets the optional CheckBox value.</summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void SetOptionalCheckBoxValue(bool value) => _isOptionalCheckBoxChecked = value;

        /// <summary>Gets the optional CheckBox value.</summary>
        /// <returns>The value of the optional check box.</returns>
        public bool GetOptionalCheckBoxValue() => _isOptionalCheckBoxChecked;

        /// <summary>Gets the state of the optional CheckBox.</summary>
        /// <returns></returns>
        public static bool GetOptionalCheckBoxState()
        {
            KryptonMessageBoxExtendedForm box = new();

            return box.GetOptionalCheckBoxValue();
        }

        /// <summary>Sets the state of the optional CheckBox check.</summary>
        /// <param name="state">The state.</param>
        public void SetOptionalCheckBoxCheckState(CheckState state) => _optionalCheckBox.CheckState = state;

        /// <summary>Gets the state of the optional CheckBox check.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public CheckState GetOptionalCheckBoxCheckState() => _optionalCheckBox.CheckState;
        #endregion

        #region Copy Button
        /// <summary>Shows the copy button.</summary>
        /// <param name="showCopyButton">if set to <c>true</c> [show copy button].</param>
        /// <param name="copyButtonText">The copy button text.</param>
        private void ShowCopyButton(bool? showCopyButton, string copyButtonText)
        {
            // _copyButton.Visible = showCopyButton;

            // _copyButton.Text = copyButtonText;
        }

        private void copyButton_KeyDown(object sender, KeyEventArgs e) => Clipboard.SetText(_messageText.Text);
        #endregion

        #region Custom Button Text
        /// <summary>Sets the custom button text.</summary>
        /// <param name="customButtonOptions">The custom button options.</param>
        /// <param name="buttonOneText">The button one text.</param>
        /// <param name="buttonOneResult">The button one result.</param>
        /// <param name="buttonTwoText">The button two text.</param>
        /// <param name="buttonTwoResult">The button two result.</param>
        /// <param name="buttonThreeText">The button three text.</param>
        /// <param name="buttonThreeResult">The button three result.</param>
        private void SetCustomButtonText(ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                         string buttonOneText, DialogResult buttonOneResult,
                                         string buttonTwoText, DialogResult? buttonTwoResult,
                                         string buttonThreeText, DialogResult? buttonThreeResult)
        {
            // As the physical layout of the buttons on the message box is: 
            // '_button1', '_button2' and '_button3', text that is for the
            // first button needs to be displayed on either '_button2' or
            // '_button3 depending on the options, unless you choose a
            // three button layout
            switch (customButtonOptions)
            {
                case ExtendedMessageBoxCustomButtonOptions.NONE:
                    _button3.Text = KryptonManager.Strings.OK;

                    _button3.DialogResult = DialogResult.OK;

                    _button3.StateCommon.Content.ShortText.Font = _messageboxTypeface;

                    _button1.Visible = _button2.Visible = false;
                    break;
                case ExtendedMessageBoxCustomButtonOptions.ONEBUTTON:
                    _button3.Text = buttonOneText;

                    _button3.DialogResult = buttonOneResult;

                    _button3.StateCommon.Content.ShortText.Font = _messageboxTypeface;

                    _button1.Visible = _button2.Visible = false;
                    break;
                case ExtendedMessageBoxCustomButtonOptions.TWOBUTTONS:
                    _button2.Text = buttonOneText;

                    _button2.DialogResult = buttonOneResult;

                    _button2.StateCommon.Content.ShortText.Font = _messageboxTypeface;

                    _button3.Text = buttonTwoText;

                    _button3.DialogResult = buttonTwoResult ?? DialogResult.None;

                    _button3.StateCommon.Content.ShortText.Font = _messageboxTypeface;

                    _button1.Visible = false;
                    break;
                case ExtendedMessageBoxCustomButtonOptions.THREEBUTTONS:
                    _button1.Text = buttonOneText;

                    _button1.DialogResult = buttonOneResult;

                    _button1.StateCommon.Content.ShortText.Font = _messageboxTypeface;

                    _button2.Text = buttonTwoText;

                    _button2.DialogResult = buttonTwoResult ?? DialogResult.None;

                    _button2.StateCommon.Content.ShortText.Font = _messageboxTypeface;

                    _button3.Text = buttonThreeText;

                    _button3.DialogResult = buttonThreeResult ?? DialogResult.None;

                    _button3.StateCommon.Content.ShortText.Font = _messageboxTypeface;
                    break;
            }
        }

        #endregion
    }

    #region Classes
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
