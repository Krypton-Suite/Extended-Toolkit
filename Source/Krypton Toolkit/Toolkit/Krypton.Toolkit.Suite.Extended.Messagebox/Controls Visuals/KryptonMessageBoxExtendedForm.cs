using Krypton.Toolkit.Suite.Extended.Tools;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
	internal partial class KryptonMessageBoxExtendedForm : KryptonForm
	{
		#region Design Code
		private KryptonWrapLabel _messageText;
		private PictureBox _messageIcon;
		private KryptonPanel _panelButtons;
		private KryptonPanel _panelCheckBox;
		private ExtendedMessageButton _button1;
		private ExtendedMessageButton _button2;
		private ExtendedMessageButton _button3;
		private ExtendedMessageButton _button4;
		private ExtendedMessageButton _copyButton;
		private KryptonCheckBox _optionalCheckBox;
		private KryptonBorderEdge _borderEdge;
		private KryptonPanel kryptonPanel1;
		private TableLayoutPanel tableLayoutPanel1;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._messageText = new Krypton.Toolkit.KryptonWrapLabel();
			this._messageIcon = new System.Windows.Forms.PictureBox();
			this._panelButtons = new Krypton.Toolkit.KryptonPanel();
			this._panelCheckBox = new Krypton.Toolkit.KryptonPanel();
			this._borderEdge = new Krypton.Toolkit.KryptonBorderEdge();
			this._button4 = new Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedMessageButton();
			this._button3 = new Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedMessageButton();
			this._button1 = new Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedMessageButton();
			this._button2 = new Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedMessageButton();
			this._copyButton = new Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedMessageButton();
			this._optionalCheckBox = new Krypton.Toolkit.KryptonCheckBox();
			this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this._messageIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._panelButtons)).BeginInit();
			this._panelButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			//
			// _panelCheckBox
			//
			this._panelCheckBox.AutoSize = true;
			this._panelCheckBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this._panelCheckBox.Controls.Add(_optionalCheckBox);
			this._panelCheckBox.Dock = DockStyle.Left;
			this._panelCheckBox.Location = new Point(0, 52);
			this._panelCheckBox.Margin = new Padding(0);
			this._panelCheckBox.Name = "_panelCheckBox";
			this._panelCheckBox.PanelBackStyle = PaletteBackStyle.PanelAlternate;
			this._panelCheckBox.Size = new Size(156, 26);
			this._panelCheckBox.TabIndex = 6;
			// 
			// _messageText
			// 
			this._messageText.AutoSize = false;
			this._messageText.Dock = System.Windows.Forms.DockStyle.Fill;
			this._messageText.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._messageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
			this._messageText.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
			this._messageText.Location = new System.Drawing.Point(0, 0);
			this._messageText.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this._messageText.Name = "_messageText";
			this._messageText.Size = new System.Drawing.Size(180, 51);
			this._messageText.Text = "Message Text";
			this._messageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _messageIcon
			// 
			this._messageIcon.BackColor = System.Drawing.Color.Transparent;
			this._messageIcon.Dock = System.Windows.Forms.DockStyle.Fill;
			this._messageIcon.Location = new System.Drawing.Point(190, 5);
			this._messageIcon.Margin = new System.Windows.Forms.Padding(10, 5, 5, 5);
			this._messageIcon.Name = "_messageIcon";
			this._messageIcon.Size = new System.Drawing.Size(44, 41);
			this._messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this._messageIcon.TabIndex = 0;
			this._messageIcon.TabStop = false;
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
			this._panelButtons.Location = new System.Drawing.Point(0, 51);
			this._panelButtons.Margin = new System.Windows.Forms.Padding(0);
			this._panelButtons.Name = "_panelButtons";
			this._panelButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
			this._panelButtons.Size = new System.Drawing.Size(244, 26);
			this._panelButtons.TabIndex = 0;
			// 
			// _borderEdge
			// 
			this._borderEdge.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
			this._borderEdge.Dock = System.Windows.Forms.DockStyle.Top;
			this._borderEdge.Location = new System.Drawing.Point(0, 0);
			this._borderEdge.Name = "_borderEdge";
			this._borderEdge.Size = new System.Drawing.Size(244, 1);
			this._borderEdge.Text = "kryptonBorderEdge1";
			// 
			// _button4
			// 
			this._button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._button4.AutoSize = true;
			this._button4.Enabled = false;
			this._button4.IgnoreAltF4 = false;
			this._button4.Location = new System.Drawing.Point(244, 0);
			this._button4.Margin = new System.Windows.Forms.Padding(0);
			this._button4.MinimumSize = new System.Drawing.Size(50, 26);
			this._button4.Name = "_button4";
			this._button4.Size = new System.Drawing.Size(50, 28);
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
			this._button3.Location = new System.Drawing.Point(194, 0);
			this._button3.Margin = new System.Windows.Forms.Padding(0);
			this._button3.MinimumSize = new System.Drawing.Size(50, 26);
			this._button3.Name = "_button3";
			this._button3.Size = new System.Drawing.Size(50, 28);
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
			this._button1.Location = new System.Drawing.Point(94, 0);
			this._button1.Margin = new System.Windows.Forms.Padding(0);
			this._button1.MinimumSize = new System.Drawing.Size(50, 26);
			this._button1.Name = "_button1";
			this._button1.Size = new System.Drawing.Size(50, 28);
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
			this._button2.Location = new System.Drawing.Point(144, 0);
			this._button2.Margin = new System.Windows.Forms.Padding(0);
			this._button2.MinimumSize = new System.Drawing.Size(50, 26);
			this._button2.Name = "_button2";
			this._button2.Size = new System.Drawing.Size(50, 28);
			this._button2.TabIndex = 1;
			this._button2.Values.Text = "B2";
			this._button2.Visible = false;
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(244, 77);
			this.kryptonPanel1.TabIndex = 1;
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
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 77);
			this.tableLayoutPanel1.TabIndex = 0;
			//
			// _optionalCheckBox
			//
			this._optionalCheckBox.Anchor = AnchorStyles.Left;
			this._optionalCheckBox.AutoSize = true;
			this._optionalCheckBox.Location = new Point(12, 0);
			this._optionalCheckBox.Margin = new Padding(0);
			this._optionalCheckBox.StateCommon.LongText.MultiLine = InheritBool.True;
			this._optionalCheckBox.StateCommon.ShortText.MultiLine = InheritBool.True;
			this._optionalCheckBox.Size = new Size(50, 20);
			this._optionalCheckBox.Name = "_optionalCheckBox";
			this._optionalCheckBox.TabIndex = 4;
			this._optionalCheckBox.Text = @"CB1";
			this._optionalCheckBox.CheckedChanged += checkbox_CheckChanged;
			this._optionalCheckBox.CheckStateChanged += checkBox_CheckStateChanged;
			this._optionalCheckBox.TextChanged += checkBox_TextChanged;
			// 
			// KryptonMessageBoxForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(244, 77);
			this.Controls.Add(this.kryptonPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "KryptonMessageBoxForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this._messageIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._panelButtons)).EndInit();
			this._panelButtons.ResumeLayout(false);
			this._panelButtons.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
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

		private void UpdateText()
		{
			Text = (MissingFrameWorkAPIs.IsNullOrWhiteSpace(_caption) ? string.Empty : _caption.Split(Environment.NewLine.ToCharArray())[0]);
			_messageText.StateCommon.Font = _messageboxTypeface;

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

			_messageText.Text = _text;
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

		// TODO: Complete method
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
		public bool GetOptionalCheckBoxState() => _optionalCheckBox.Checked;

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
			_copyButton.Visible = showCopyButton ?? false;

			_copyButton.Text = copyButtonText;
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

		#region Fade
		private void InternalKryptonMessageBoxExtended_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_fade)
			{
				for (_fadeOut = 90; _fadeOut >= 10; _fadeOut += 10)
				{
					Opacity = _fadeOut / 100;

					Refresh();
				}

				Thread.Sleep(_fadeSleepTimer);
			}
		}

		private void InternalKryptonMessageBoxExtended_Load(object sender, EventArgs e)
		{
			if (_fade)
			{
				for (_fadeIn = 0.0; _fadeIn <= 1.1; _fadeIn += 0.1)
				{
					Opacity = _fadeIn;

					Refresh();
				}

				Thread.Sleep(_fadeSleepTimer);
			}
		}

		#endregion

		#region Tool Tips
		/// <summary>Toggles the control tool tips.</summary>
		/// <param name="showToolTips">if set to <c>true</c> [show tool tips].</param>
		private void ToggleControlToolTips(bool showToolTips)
		{
			_button1.ToolTipValues.EnableToolTips = showToolTips;

			_button2.ToolTipValues.EnableToolTips = showToolTips;

			_button3.ToolTipValues.EnableToolTips = showToolTips;
		}

		/// <summary>Setups the control tool tips.</summary>
		/// <param name="buttonOneToolTipHeader">The button one tool tip header.</param>
		/// <param name="buttonOneToolTipContent">Content of the button one tool tip.</param>
		/// <param name="buttonTwoToolTipHeader">The button two tool tip header.</param>
		/// <param name="buttonTwoToolTipContent">Content of the button two tool tip.</param>
		/// <param name="buttonThreeToolTipHeader">The button three tool tip header.</param>
		/// <param name="buttonThreeToolTipContent">Content of the button three tool tip.</param>
		private void SetupControlToolTips(string buttonOneToolTipHeader, string buttonOneToolTipContent,
										  string buttonTwoToolTipHeader, string buttonTwoToolTipContent,
										  string buttonThreeToolTipHeader,
										  string buttonThreeToolTipContent)
		{
			_button1.ToolTipValues.Heading = buttonOneToolTipHeader;

			_button1.ToolTipValues.Description = buttonOneToolTipContent;

			_button2.ToolTipValues.Heading = buttonTwoToolTipHeader;

			_button2.ToolTipValues.Description = buttonTwoToolTipContent;

			_button3.ToolTipValues.Heading = buttonThreeToolTipHeader;

			_button3.ToolTipValues.Description = buttonThreeToolTipContent;
		}
		#endregion
	}
}