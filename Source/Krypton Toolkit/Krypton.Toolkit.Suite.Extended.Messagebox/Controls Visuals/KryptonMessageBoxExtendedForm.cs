using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public KryptonMessageBoxExtendedForm()
        {
            InitializeComponent();
        }

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
