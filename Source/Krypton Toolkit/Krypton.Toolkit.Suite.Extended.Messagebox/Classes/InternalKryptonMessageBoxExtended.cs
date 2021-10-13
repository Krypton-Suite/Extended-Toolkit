#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    /// <summary>
    /// Displays a message box that can contain text, buttons, and symbols that inform and instruct the user.
    /// Allows optional Font to be specified, if not then new Font(@"Microsoft Sans Serif", 8.25F) will be used
    /// </summary>
    #region Old Code
    /*
	[ToolboxItem(false), ToolboxBitmap(typeof(InternalKryptonMessageBoxExtended), "ToolboxBitmaps.KryptonMessageBox.bmp"),
	 DesignerCategory("code"), DesignTimeVisible(false)]
	internal class InternalKryptonMessageBoxExtended : KryptonForm
	{
		#region System
		private void InitializeComponent()
		{
			_panelMessage = new KryptonPanel();
			_panelMessageText = new KryptonPanel();
			_messageText = new KryptonWrapLabel();
			_panelMessageIcon = new KryptonPanel();
			_messageIcon = new PictureBox();
			_panelButtons = new KryptonPanel();
			_panelCheckBox = new KryptonPanel();
			_panelFooter = new KryptonPanel();
			_borderEdge = new KryptonBorderEdge();
			_button3 = new MessageButton();
			_button1 = new MessageButton();
			_button2 = new MessageButton();
			_copyButton = new MessageButton();
			_optionalCheckBox = new KryptonCheckBox();
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
			_panelButtons.Controls.Add(_panelCheckBox);
			_panelButtons.Controls.Add(_copyButton);
			_panelButtons.Dock = DockStyle.Top;
			_panelButtons.Location = new Point(0, 52);
			_panelButtons.Margin = new Padding(0);
			_panelButtons.Name = "_panelButtons";
			_panelButtons.PanelBackStyle = PaletteBackStyle.PanelAlternate;
			_panelButtons.Size = new Size(156, 26);
			_panelButtons.TabIndex = 0;
			//
			// _panelCheckBox
			//
			_panelCheckBox.AutoSize = true;
			_panelCheckBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			_panelCheckBox.Controls.Add(_optionalCheckBox);
			_panelCheckBox.Dock = DockStyle.Left;
			_panelCheckBox.Location = new Point(0, 52);
			_panelCheckBox.Margin = new Padding(0);
			_panelCheckBox.Name = "_panelCheckBox";
			_panelCheckBox.PanelBackStyle = PaletteBackStyle.PanelAlternate;
			_panelCheckBox.Size = new Size(156, 26);
			_panelCheckBox.TabIndex = 6;
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
			// _copyButton
			//
			_copyButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
			_copyButton.AutoSize = true;
			_copyButton.IgnoreAltF4 = false;
			_copyButton.Location = new Point(12, 0);
			_copyButton.Margin = new Padding(0);
			_copyButton.MinimumSize = new Size(50, 26);
			_copyButton.Name = "_copyButton";
			_copyButton.Size = new Size(50, 26);
			_copyButton.TabIndex = 5;
			_copyButton.Values.Text = @"B4";
			_copyButton.KeyDown += copyButton_KeyDown;
			//
			// _optionalCheckBox
			//
			_optionalCheckBox.Anchor = AnchorStyles.Left;
			_optionalCheckBox.AutoSize = true;
			_optionalCheckBox.Location = new Point(12, 0);
			_optionalCheckBox.Margin = new Padding(0);
			_optionalCheckBox.StateCommon.LongText.MultiLine = InheritBool.True;
			_optionalCheckBox.StateCommon.ShortText.MultiLine = InheritBool.True;
			_optionalCheckBox.Size = new Size(50, 20);
			_optionalCheckBox.Name = "_optionalCheckBox";
			_optionalCheckBox.TabIndex = 4;
			_optionalCheckBox.Text = @"CB1";
			_optionalCheckBox.CheckedChanged += checkbox_CheckChanged;
			_optionalCheckBox.CheckStateChanged += checkBox_CheckStateChanged;
			_optionalCheckBox.TextChanged += checkBox_TextChanged;
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
			Name = "KryptonMessageBoxExtended";
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
		private readonly string _text, _optionalCheckBoxText, _copyButtonText, _buttonOneText, _buttonTwoText, _buttonThreeText;
		private readonly string _caption;
		private readonly ExtendedMessageBoxButtons _buttons;
		private readonly ExtendedMessageBoxCustomButtonOptions _customButtonOptions;
		private readonly ExtendedKryptonMessageBoxIcon _icon;
		private readonly MessageBoxDefaultButton _defaultButton;
		private AnchorStyles _optionalCheckBoxAnchor;
		private MessageBoxOptions _options; // TODO: What is this used for ?
		private bool _fade, _showOptionalCheckBox, _showCopyButton, _hasTimedOut, _showToolTips;
		private CheckState _optionalCheckBoxCheckState;
		private DialogResult _buttonOneResult, _buttonTwoResult, _buttonThreeResult;
		private Double _fadeIn, _fadeOut;
		public static bool _isOptionalCheckBoxChecked;
		private KryptonPanel _panelMessage;
		private KryptonPanel _panelMessageText;
		private KryptonWrapLabel _messageText;
		private KryptonPanel _panelMessageIcon;
		private int _fadeSleepTimer, _timeOut, _cornerRadius, _blurRadius;
		private PictureBox _messageIcon;
		private KryptonPanel _panelButtons;
		private KryptonPanel _panelCheckBox;
		private KryptonPanel _panelFooter;
		private MessageButton _button1;
		private MessageButton _button2;
		private MessageButton _button3;
		private MessageButton _copyButton;
		private KryptonCheckBox _optionalCheckBox;
		private KryptonBorderEdge _borderEdge;
		private HelpInfo _HelpInfo;// TODO: What is this used for ?
		private Font _messageboxTypeface;
		private Image _customMessageBoxIcon;
		private Point _optionalCheckBoxLocation;
		private bool _useBlur;
		private bool? _useYesNoCancelButtonColour;
		private KryptonForm _parentWindow;
		private Color? _contentMessageColour, _buttonOneTextColour, _buttonTwoTextColour,
					   _buttonThreeTextColour, _yesButtonColour, _noButtonColour, _textColour,
					   _yesNoButtonTextColour;
		#endregion

		#region Static Fields
		private const int GAP = 10;
		private static readonly int _osMajorVersion;
		#endregion

		#region Internal Classes
		internal class HelpInfo
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
			/// Initialize a new instance of the HelpInfo class.
			/// </summary>
			public HelpInfo()
			{
			}

			/// <summary>
			/// Initialize a new instance of the HelpInfo class.
			/// </summary>
			/// <param name="helpFilePath">Value for HelpFilePath.</param>
			public HelpInfo(string helpFilePath)
			{
				HelpFilePath = helpFilePath;
			}

			/// <summary>
			/// Initialize a new instance of the HelpInfo class.
			/// </summary>
			/// <param name="helpFilePath">Value for HelpFilePath.</param>
			/// <param name="keyword">Value for Keyword</param>
			public HelpInfo(string helpFilePath, string keyword)
			{
				HelpFilePath = helpFilePath;
				Keyword = keyword;
			}

			/// <summary>
			/// Initialize a new instance of the HelpInfo class.
			/// </summary>
			/// <param name="helpFilePath">Value for HelpFilePath.</param>
			/// <param name="navigator">Value for Navigator</param>
			public HelpInfo(string helpFilePath, HelpNavigator navigator)
			{
				HelpFilePath = helpFilePath;
				Navigator = navigator;
			}

			/// <summary>
			/// Initialize a new instance of the HelpInfo class.
			/// </summary>
			/// <param name="helpFilePath">Value for HelpFilePath.</param>
			/// <param name="navigator">Value for Navigator</param>
			/// <param name="param">Value for Param</param>
			public HelpInfo(string helpFilePath, HelpNavigator navigator, object param)
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
		static InternalKryptonMessageBoxExtended() => _osMajorVersion = Environment.OSVersion.Version.Major;

		/// <summary>
		/// Initializes a new instance of the <see cref="InternalKryptonMessageBoxExtended" /> class.
		/// A dummy constructor to retrieve the optional check box value.
		/// </summary>
		public InternalKryptonMessageBoxExtended() { }

		/// <summary>Initializes a new instance of the <see cref="InternalKryptonMessageBoxExtended" /> class.</summary>
		/// <param name="showOwner">The show owner.</param>
		/// <param name="text">The text.</param>
		/// <param name="caption">The caption.</param>
		/// <param name="buttons">The buttons.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">The icon.</param>
		/// <param name="defaultButton">The default button.</param>
		/// <param name="options">The options.</param>
		/// <param name="HelpInfo">The help information.</param>
		/// <param name="showCtrlCopy">The show control copy.</param>
		/// <param name="messageboxTypeface">The message box typeface.</param>
		/// <param name="showOptionalCheckBox">if set to <c>true</c> [show optional CheckBox].</param>
		/// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
		/// <param name="isOptionalCheckBoxChecked">if set to <c>true</c> [is optional CheckBox checked].</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The optional CheckBox anchor.</param>
		/// <param name="optionalCheckBoxLocation">The optional CheckBox location.</param>
		/// <param name="customMessageBoxIcon">The custom message box icon.</param>
		/// <param name="showCopyButton">if set to <c>true</c> [show copy button].</param>
		/// <param name="copyButtonText">The copy button text.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
		/// <param name="useYesNoCancelButtonColour">Allows the user to change the Yes, No and Cancel button colour.</param>
		/// <param name="blurRadius">The radius of the blur effect. By default, this is set to 0.</param>
		/// <param name="contentMessageColour">The message text colour. By default, this is set to 'Color.Empty'.</param>
		/// <param name="buttonOneTextColour">The first button text colour. By default, this is set to 'Color.Empty'.</param>
		/// <param name="buttonTwoTextColour">The seccond button text colour. By default, this is set to 'Color.Empty'.</param>
		/// <param name="buttonThreeTextColour">The third button text colour. By default, this is set to 'Color.Empty'.</param>
		/// <param name="yesButtonColour">The Yes button background colour. By default, this is set to 'Color.Empty'.</param>
		/// <param name="noButtonColour">The Abort/Cancel/No button background colour. By default, this is set to 'Color.Empty'.</param>
		/// <param name="textColour">The overall text colour. By default, this is set to 'Color.Empty'.</param>
		/// <param name="yesNoButtonTextColour">The Abort/Cancel/No/Yes button background colour. By default, this is set to 'Color.Empty'.</param>
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		private InternalKryptonMessageBoxExtended(IWin32Window showOwner, string text, string caption,
												  ExtendedMessageBoxButtons buttons,
												  ExtendedMessageBoxCustomButtonOptions? customButtonOptions,
												  ExtendedKryptonMessageBoxIcon icon,
												  MessageBoxDefaultButton defaultButton,
												  MessageBoxOptions options, HelpInfo HelpInfo,
												  bool? showCtrlCopy, Font messageboxTypeface,
												  bool showOptionalCheckBox, string optionalCheckBoxText,
												  bool isOptionalCheckBoxChecked, CheckState? optionalCheckBoxCheckState,
												  AnchorStyles? optionalCheckBoxAnchor, Point? optionalCheckBoxLocation,
												  Image customMessageBoxIcon, bool showCopyButton, string copyButtonText,
												  bool? fade, int? fadeSleepTimer, string buttonOneCustomText,
												  string buttonTwoCustomText, string buttonThreeCustomText,
												  DialogResult? buttonOneCustomDialogResult, DialogResult? buttonTwoCustomDialogResult,
												  DialogResult? buttonThreeCustomDialogResult, int? cornerRadius,
												  bool? showToolTips, bool? useBlur, bool? useYesNoCancelButtonColour,
												  int? blurRadius, Color? contentMessageColour, Color? buttonOneTextColour,
												  Color? buttonTwoTextColour, Color? buttonThreeTextColour,
												  Color? yesButtonColour, Color? noButtonColour, Color? textColour,
												  Color? yesNoButtonTextColour, KryptonForm parentWindow = null)
		{
			#region Store Values
			_text = text;

			_caption = caption;

			_buttons = buttons;

			_customButtonOptions = customButtonOptions ?? ExtendedMessageBoxCustomButtonOptions.ONEBUTTON;

			_icon = icon;

			_defaultButton = defaultButton;

			_options = options;

			_HelpInfo = HelpInfo;

			_messageboxTypeface = messageboxTypeface ?? new Font(@"Microsoft Sans Serif", 8.25F);

			_showOptionalCheckBox = showOptionalCheckBox;

			_optionalCheckBoxText = optionalCheckBoxText;

			_isOptionalCheckBoxChecked = isOptionalCheckBoxChecked;

			_optionalCheckBoxCheckState = optionalCheckBoxCheckState ?? CheckState.Unchecked;

			_customMessageBoxIcon = customMessageBoxIcon;

			_optionalCheckBoxAnchor = optionalCheckBoxAnchor ?? AnchorStyles.Left;

			_optionalCheckBoxLocation = optionalCheckBoxLocation ?? new Point(12, 0);

			_showCopyButton = showCopyButton;

			_copyButtonText = copyButtonText;

			_fade = fade ?? false;

			_fadeSleepTimer = fadeSleepTimer ?? 50;

			_buttonOneText = buttonOneCustomText ?? "";

			_buttonTwoText = buttonTwoCustomText ?? "";

			_buttonThreeText = buttonThreeCustomText ?? "";

			_buttonOneResult = buttonOneCustomDialogResult ?? DialogResult.None;

			_buttonTwoResult = buttonTwoCustomDialogResult ?? DialogResult.None;

			_buttonThreeResult = buttonThreeCustomDialogResult ?? DialogResult.None;

			_showToolTips = showToolTips ?? false;

			_cornerRadius = cornerRadius ?? GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE;

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

			_parentWindow = parentWindow;
			#endregion

			// Create the form contents
			InitializeComponent();

			// Update contents to match requirements
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
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(string text, bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null, Point? optionalCheckBoxLocation = null,
										bool showCopyButton = false, string copyButtonText = null, bool? fade = false,
										int? fadeSleepTimer = 50, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE,
										bool? showToolTips = null, bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(null, text, string.Empty, ExtendedMessageBoxButtons.OK, null, ExtendedKryptonMessageBoxIcon.NONE,
								MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface, showOptionalCheckBox,
								optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor,
								optionalCheckBoxLocation, null, showCopyButton, copyButtonText, fade, fadeSleepTimer,
								null, null, null, null,
								null, null, cornerRadius, showToolTips, useBlur,
								useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour,
								buttonTwoTextColour, buttonThreeTextColour, yesButtonColour,
								noButtonColour, textColour, yesNoButtonTextColour,
								parentWindow);
		}

		/// <summary>
		/// Displays a message box in front of the specified object and with the specified text.
		/// </summary>
		/// <param name="owner">Owner of the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(IWin32Window owner, string text, bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, bool showCopyButton = false,
										string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
										float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(owner, text, string.Empty, ExtendedMessageBoxButtons.OK, null,
								ExtendedKryptonMessageBoxIcon.NONE, MessageBoxDefaultButton.Button1, 0, null,
								showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
								optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, null,
								showCopyButton, copyButtonText, fade, fadeSleepTimer, null, null, null, null,
								null, null, cornerRadius, showToolTips, useBlur,
								useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour,
								parentWindow);
		}

		/// <summary>
		/// Displays a message box with specified text and caption.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(string text, string caption, bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, bool showCopyButton = false,
										string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
										float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(null, text, caption, ExtendedMessageBoxButtons.OK, null,
								ExtendedKryptonMessageBoxIcon.NONE, MessageBoxDefaultButton.Button1, 0, null,
								showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
								optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, null,
								showCopyButton, copyButtonText, fade, fadeSleepTimer, null, null, null, null,
								null, null, cornerRadius, showToolTips, useBlur,
								useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour,
								buttonTwoTextColour, buttonThreeTextColour, yesButtonColour, noButtonColour, textColour,
								yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box in front of the specified object and with the specified text and caption.
		/// </summary>
		/// <param name="owner">Owner of the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(IWin32Window owner,
										string text, string caption, bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, bool showCopyButton = false,
										string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
										float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(owner, text, caption, ExtendedMessageBoxButtons.OK, null, ExtendedKryptonMessageBoxIcon.NONE,
								MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface,
								showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
								optionalCheckBoxAnchor, optionalCheckBoxLocation, null, showCopyButton, copyButtonText,
								fade, fadeSleepTimer, null, null, null, null,
								null, null, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour,
								blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour,
								parentWindow);
		}

		/// <summary>
		/// Displays a message box with specified text, caption, and buttons.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, bool showCopyButton = false,
										string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(null, text, caption, buttons, customButtonOptions, ExtendedKryptonMessageBoxIcon.NONE, MessageBoxDefaultButton.Button1,
						 0, null, showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText,
								isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation,
				null, showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText,
								buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
								buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box in front of the specified object and with the specified text, caption, and buttons.
		/// </summary>
		/// <param name="owner">Owner of the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(IWin32Window owner,
										string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, bool showCopyButton = false,
										string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(owner, text, caption, buttons, customButtonOptions, ExtendedKryptonMessageBoxIcon.NONE,
								MessageBoxDefaultButton.Button1, 0, null, showCtrlCopy, messageboxTypeface,
								showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
								optionalCheckBoxAnchor, optionalCheckBoxLocation, null, showCopyButton, copyButtonText,
								fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
								buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
								cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with specified text, caption, buttons, and icon.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(string text, string caption,
										ExtendedMessageBoxButtons buttons,
										ExtendedMessageBoxCustomButtonOptions customButtonOptions, ExtendedKryptonMessageBoxIcon icon,
										bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
										bool showCopyButton = false, string copyButtonText = null,
										bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(null, text, caption, buttons, customButtonOptions, icon, MessageBoxDefaultButton.Button1, 0,
								null, showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText,
								isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation,
								customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText,
								buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
								buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box in front of the specified object and with the specified text, caption, buttons, and icon.
		/// </summary>
		/// <param name="owner">Owner of the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(IWin32Window owner,
										string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon, bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
										bool showCopyButton = false, string copyButtonText = null,
										bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, MessageBoxDefaultButton.Button1, 0,
								null, showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText,
								isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation,
								customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText,
								buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
								buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, and default button.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon, MessageBoxDefaultButton defaultButton, bool? showCtrlCopy = null,
										Font messageboxTypeface = null, bool showOptionalCheckBox = false,
										string optionalCheckBoxText = null, bool isOptionalCheckBoxChecked = false,
										CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null, Point? optionalCheckBoxLocation = null,
										Image customMessageBoxIcon = null, bool showCopyButton = false,
										string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, 0, null,
								showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
								optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon,
								showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText,
								buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
								buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box in front of the specified object and with the specified text, caption, buttons, icon, and default button.
		/// </summary>
		/// <param name="owner">Owner of the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(IWin32Window owner,
										string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, bool? showCtrlCopy = null,
										Font messageboxTypeface = null, bool showOptionalCheckBox = false,
										string optionalCheckBoxText = null, bool isOptionalCheckBoxChecked = false,
										CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null, Point? optionalCheckBoxLocation = null,
										Image customMessageBoxIcon = null, bool showCopyButton = false,
										string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, 0, null,
								showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
								optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon,
								showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText,
								buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
								buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, default button, and options.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
										bool showCopyButton = false, string copyButtonText = null,
										bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options, null,
								showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
								optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon,
								showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText,
								buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
								buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box in front of the specified object and with the specified text, caption, buttons, icon, default button, and options.
		/// </summary>
		/// <param name="owner">Owner of the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(IWin32Window owner,
										string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
										bool showCopyButton = false, string copyButtonText = null,
										bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options, null,
								showCtrlCopy, messageboxTypeface, showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
								optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon,
								showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText,
								buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
								buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="displayHelpButton">Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										bool displayHelpButton, bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
										bool showCopyButton = false, string copyButtonText = null,
										bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE,
										bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
								displayHelpButton ? new HelpInfo() : null, showCtrlCopy, messageboxTypeface, showOptionalCheckBox,
								optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor,
								optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer,
								buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult,
								buttonTwoCustomDialogResult, buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur,
								useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										string helpFilePath, bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
										bool showCopyButton = false, string copyButtonText = null,
										bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
								new HelpInfo(helpFilePath), showCtrlCopy, messageboxTypeface, showOptionalCheckBox,
								optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor,
								optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer,
								buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult,
								buttonTwoCustomDialogResult, buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur,
								useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file.
		/// </summary>
		/// <param name="owner">Owner of the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(IWin32Window owner,
										string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										string helpFilePath, bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
										bool showCopyButton = false, string copyButtonText = null,
										bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
				   new HelpInfo(helpFilePath), showCtrlCopy, messageboxTypeface, showOptionalCheckBox,
								optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor,
								optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer,
								buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult,
								buttonTwoCustomDialogResult, buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur,
								useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and HelpNavigator.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
		/// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										string helpFilePath, HelpNavigator navigator, bool? showCtrlCopy = null,
										Font messageboxTypeface = null, bool showOptionalCheckBox = false,
										string optionalCheckBoxText = null, bool isOptionalCheckBoxChecked = false,
										CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null, Point? optionalCheckBoxLocation = null,
										Image customMessageBoxIcon = null, bool showCopyButton = false,
										string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
								new HelpInfo(helpFilePath, navigator), showCtrlCopy, messageboxTypeface,
								showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
								optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText,
								fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
								buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
								cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and Help keyword.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
		/// <param name="keyword">The Help keyword to display when the user clicks the Help button.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										string helpFilePath, string keyword, bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
										bool showCopyButton = false, string copyButtonText = null,
										bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
								new HelpInfo(helpFilePath, keyword), showCtrlCopy, messageboxTypeface, showOptionalCheckBox,
								optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor,
								optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer,
								buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText, buttonOneCustomDialogResult,
								buttonTwoCustomDialogResult, buttonThreeCustomDialogResult, cornerRadius, showToolTips, useBlur,
								useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and HelpNavigator.
		/// </summary>
		/// <param name="owner">Owner of the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
		/// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(IWin32Window owner,
										string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										string helpFilePath, HelpNavigator navigator, bool? showCtrlCopy = null,
										Font messageboxTypeface = null, bool showOptionalCheckBox = false,
										string optionalCheckBoxText = null, bool isOptionalCheckBoxChecked = false,
										CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null, Point? optionalCheckBoxLocation = null,
										Image customMessageBoxIcon = null, bool showCopyButton = false,
										string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
								new HelpInfo(helpFilePath, navigator), showCtrlCopy, messageboxTypeface,
								showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
								optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText,
								fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
								buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
								cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file and Help keyword.
		/// </summary>
		/// <param name="owner">Owner of the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
		/// <param name="keyword">The Help keyword to display when the user clicks the Help button.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(IWin32Window owner,
										string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										string helpFilePath, string keyword, bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
										bool showCopyButton = false, string copyButtonText = null,
										bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
								new HelpInfo(helpFilePath, keyword), showCtrlCopy, messageboxTypeface,
								showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
								optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText,
								fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
								buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
								cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file, HelpNavigator, and Help topic.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
		/// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
		/// <param name="param">The numeric ID of the Help topic to display when the user clicks the Help button.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">The message box typeface. (Can be null)</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										string helpFilePath, HelpNavigator navigator, object param,
										bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
										AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
										bool showCopyButton = false, string copyButtonText = null,
										bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(null, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
								new HelpInfo(helpFilePath, navigator, param), showCtrlCopy, messageboxTypeface,
								showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
								optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText,
								fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
								buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
								cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file, HelpNavigator, and Help topic.
		/// </summary>
		/// <param name="owner">Owner of the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="helpFilePath">The path and name of the Help file to display when the user clicks the Help button.</param>
		/// <param name="navigator">One of the System.Windows.Forms.HelpNavigator values.</param>
		/// <param name="param">The numeric ID of the Help topic to display when the user clicks the Help button.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageboxTypeface">Defines the message box font.</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		public static DialogResult Show(IWin32Window owner,
										string text, string caption,
										ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										ExtendedKryptonMessageBoxIcon icon,
										MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										string helpFilePath, HelpNavigator navigator, object param,
										bool? showCtrlCopy = null, Font messageboxTypeface = null,
										bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
										bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null, AnchorStyles? optionalCheckBoxAnchor = null,
										Point? optionalCheckBoxLocation = null, Image customMessageBoxIcon = null,
										bool showCopyButton = false, string copyButtonText = null,
										bool? fade = false, int? fadeSleepTimer = 50,
										string buttonOneCustomText = null, string buttonTwoCustomText = null,
										string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										DialogResult? buttonTwoCustomDialogResult = null,
										DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options,
				   new HelpInfo(helpFilePath, navigator, param), showCtrlCopy, messageboxTypeface,
								showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState,
								optionalCheckBoxAnchor, optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton, copyButtonText,
								fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText, buttonThreeCustomText,
								buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
								cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius,
								contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}

		/// <summary>
		/// Displays a message box with the specified text, caption, buttons, icon, default button, options, and Help button, using the specified Help file, HelpNavigator, and Help topic.
		/// </summary>
		/// <param name="owner">Owner of the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">One of the System.Windows.Forms.ExtendedMessageBoxButton values that specifies which buttons to display in the message box.</param>
		/// <param name="customButtonOptions">Custom button options.</param>
		/// <param name="icon">One of the System.Windows.Forms.ExtendedMessageBoxIcon values that specifies which icon to display in the message box.</param>
		/// <param name="defaultButton">One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies the default button for the message box.</param>
		/// <param name="options">One of the System.Windows.Forms.MessageBoxOptions values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="HelpInfo">The path and name of the Help file to display when the user clicks the Help button.</param>
		/// <param name="showCtrlCopy">Show extraText in title. If null(default) then only when Warning or Error icon is used.</param>
		/// <param name="messageBoxTypeface">Defines the message box font.</param>
		/// <param name="showOptionalCheckBox">Shows an optional check box in the footer of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <param name="optionalCheckBoxText">The text shown on the optional check box.</param>
		/// <param name="isOptionalCheckBoxChecked">Is the optional check box already checked.</param>
		/// <param name="optionalCheckBoxCheckState">The check state of the optional check box.</param>
		/// <param name="optionalCheckBoxAnchor">The <see cref="AnchorStyles"/> of the optional check box. (Always keep it to the left.)</param>
		/// <param name="optionalCheckBoxLocation">The location of the optional check box.</param>
		/// <param name="customMessageBoxIcon">Set a custom message box icon. (Must be at least a 32 x 32 PNG image.)</param>
		/// <param name="showCopyButton">Shows an optional copy button, to copy the message box content text to the Windows clipboard.</param>
		/// <param name="copyButtonText">The text shown on the copy button.</param>
		/// <param name="fade">Allows the message box to fade in and out.</param>
		/// <param name="fadeSleepTimer">The speed of the fading effect.</param>
		/// <param name="buttonOneCustomText">The custom text on the first button.</param>
		/// <param name="buttonTwoCustomText">The custom text on the second button.</param>
		/// <param name="buttonThreeCustomText">The custom text on the third button.</param>
		/// <param name="buttonOneCustomDialogResult">The action for the first button to take.</param>
		/// <param name="buttonTwoCustomDialogResult">The action for the second button to take.</param>
		/// <param name="buttonThreeCustomDialogResult">The action for the third button to take.</param>
		/// <param name="cornerRadius">The corner radius of the <see cref="InternalKryptonMessageBoxExtended"/>. By default, this is set to GlobalValues.DEFAULT_CORNER_ROUNDING_VALUE.</param>
		/// <param name="showToolTips">Displays tool-tips on the controls.</param>
		/// <param name="useBlur">Use the blur functionality on the parent window.</param>
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
		/// <param name="parentWindow">The parent window of the <see cref="InternalKryptonMessageBoxExtended"/>.</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		internal static DialogResult Show(IWin32Window owner,
										  string text, string caption,
										  ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
										  ExtendedKryptonMessageBoxIcon icon,
										  MessageBoxDefaultButton defaultButton, MessageBoxOptions options,
										  HelpInfo HelpInfo, bool showCtrlCopy, Font messageBoxTypeface,
										  bool showOptionalCheckBox, string optionalCheckBoxText, bool isOptionalCheckBoxChecked,
										  CheckState? optionalCheckBoxCheckState,
										  AnchorStyles optionalCheckBoxAnchor, Point optionalCheckBoxLocation,
										  Image customMessageBoxIcon, bool showCopyButton = false,
										  string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
										  string buttonOneCustomText = null, string buttonTwoCustomText = null,
										  string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
										  DialogResult? buttonTwoCustomDialogResult = null,
										  DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE, bool? showToolTips = null,
										  bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
										  int? blurRadius = 0, Color? contentMessageColour = null, Color? buttonOneTextColour = null,
										  Color? buttonTwoTextColour = null, Color? buttonThreeTextColour = null,
										  Color? yesButtonColour = null, Color? noButtonColour = null, Color? textColour = null,
										  Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
		{
			return InternalShow(owner, text, caption, buttons, customButtonOptions, icon, defaultButton, options, HelpInfo, showCtrlCopy, messageBoxTypeface, showOptionalCheckBox,
								optionalCheckBoxText, isOptionalCheckBoxChecked, optionalCheckBoxCheckState, optionalCheckBoxAnchor, optionalCheckBoxLocation,
								customMessageBoxIcon, showCopyButton, copyButtonText, fade, fadeSleepTimer, buttonOneCustomText, buttonTwoCustomText,
								buttonThreeCustomText, buttonOneCustomDialogResult, buttonTwoCustomDialogResult, buttonThreeCustomDialogResult,
								cornerRadius, showToolTips, useBlur, useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour, buttonTwoTextColour,
								buttonThreeTextColour, yesButtonColour, noButtonColour, textColour, yesNoButtonTextColour, parentWindow);
		}
		#endregion

		#region Implementation
		/// <summary> Shows the messagebox.</summary>
		/// <param name="owner">The owner.</param>
		/// <param name="text">The text.</param>
		/// <param name="caption">The caption.</param>
		/// <param name="buttons">The buttons.</param>
		/// <param name="customButtonOptions">The custom button options.</param>
		/// <param name="icon">The icon.</param>
		/// <param name="defaultButton">The default button.</param>
		/// <param name="options">The options.</param>
		/// <param name="HelpInfo">The help information.</param>
		/// <param name="showCtrlCopy">The show control copy.</param>
		/// <param name="messageboxTypeface">The messagebox typeface.</param>
		/// <param name="showOptionalCheckBox">if set to <c>true</c> [show optional CheckBox].</param>
		/// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
		/// <param name="isOptionalCheckBoxChecked">if set to <c>true</c> [is optional CheckBox checked].</param>
		/// <param name="optionalCheckBoxCheckState">State of the optional CheckBox check.</param>
		/// <param name="optionalCheckBoxAnchor">The optional CheckBox anchor.</param>
		/// <param name="optionalCheckBoxLocation">The optional CheckBox location.</param>
		/// <param name="customMessageBoxIcon">The custom message box icon.</param>
		/// <param name="showCopyButton">if set to <c>true</c> [show copy button].</param>
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
		/// <returns>
		///   <br />
		/// </returns>
		/// <exception cref="System.InvalidOperationException">Cannot show modal dialog when non-interactive</exception>
		/// <exception cref="System.ArgumentException">Cannot show message box from a service with an owner specified - options
		/// or
		/// Cannot show message box from a service with help specified - options</exception>
		private static DialogResult InternalShow(IWin32Window owner,
												 string text, string caption,
												 ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions? customButtonOptions,
												 ExtendedKryptonMessageBoxIcon icon,
												 MessageBoxDefaultButton defaultButton,
												 MessageBoxOptions options,
												 HelpInfo HelpInfo, bool? showCtrlCopy, Font messageboxTypeface = null,
												 bool showOptionalCheckBox = false, string optionalCheckBoxText = null,
												 bool isOptionalCheckBoxChecked = false, CheckState? optionalCheckBoxCheckState = null,
												 AnchorStyles? optionalCheckBoxAnchor = null, Point? optionalCheckBoxLocation = null,
												 Image customMessageBoxIcon = null, bool showCopyButton = false,
												 string copyButtonText = null, bool? fade = false, int? fadeSleepTimer = 50,
												 string buttonOneCustomText = null, string buttonTwoCustomText = null,
												 string buttonThreeCustomText = null, DialogResult? buttonOneCustomDialogResult = null,
												 DialogResult? buttonTwoCustomDialogResult = null,
												 DialogResult? buttonThreeCustomDialogResult = null, float? cornerRadius = GlobalStaticValues.PRIMARY_CORNER_ROUNDING_VALUE,
												 bool? showToolTips = null, bool? useBlur = null, bool? useYesNoCancelButtonColour = null,
												 int? blurRadius = 0, Color? contentMessageColour = null,
												 Color? buttonOneTextColour = null, Color? buttonTwoTextColour = null,
												 Color? buttonThreeTextColour = null, Color? yesButtonColour = null,
												 Color? noButtonColour = null, Color? textColour = null,
												 Color? yesNoButtonTextColour = null, KryptonForm parentWindow = null)
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
			if ((HelpInfo != null) && ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0))
			{
				throw new ArgumentException(@"Cannot show message box from a service with help specified", nameof(options));
			}

			// If help information provided or we are not a service/default desktop application then grab an owner for showing the message box
			IWin32Window showOwner = null;
			if ((HelpInfo != null) || ((options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0))
			{
				// If do not have an owner passed in then get the active window and use that instead
				showOwner = owner ?? FromHandle(PlatformInvoke.GetActiveWindow());
			}

			// Show message box window as a modal dialog and then dispose of it afterwards
			using (InternalKryptonMessageBoxExtended ekmb = new(showOwner, text, caption, buttons, customButtonOptions, icon, defaultButton,
																				  options, HelpInfo, showCtrlCopy, messageboxTypeface,
																				  showOptionalCheckBox, optionalCheckBoxText, isOptionalCheckBoxChecked,
																				  optionalCheckBoxCheckState, optionalCheckBoxAnchor,
																				  optionalCheckBoxLocation, customMessageBoxIcon, showCopyButton,
																				  copyButtonText, fade, fadeSleepTimer, buttonOneCustomText,
																				  buttonTwoCustomText, buttonThreeCustomText,
																				  buttonOneCustomDialogResult, buttonTwoCustomDialogResult,
																				  buttonThreeCustomDialogResult, cornerRadius, showToolTips,
																				  useBlur, useYesNoCancelButtonColour, blurRadius, contentMessageColour, buttonOneTextColour,
																				  buttonTwoTextColour, buttonThreeTextColour, yesButtonColour,
																				  noButtonColour, textColour, yesNoButtonTextColour, parentWindow))
			{
				ekmb.StartPosition = showOwner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;

				return ekmb.ShowDialog(showOwner);
			}
		}

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
					_panelMessageIcon.Visible = false;
					_panelMessageText.Left -= _messageIcon.Right;

					// Windows XP and before will Beep, Vista and above do not!
					if (_osMajorVersion < 6)
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
		private void ShowOptionalCheckBoxUI(bool showOptionalCheckBox, string optionalCheckBoxText,
											bool isOptionalCheckBoxChecked, CheckState? optionalCheckBoxCheckState,
											AnchorStyles? optionalCheckBoxAnchor, Point? optionalCheckBoxLocation)
		{
			_optionalCheckBox.Visible = showOptionalCheckBox;

			_optionalCheckBox.Text = optionalCheckBoxText;

			_optionalCheckBox.Checked = isOptionalCheckBoxChecked;

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
			InternalKryptonMessageBoxExtended box = new();

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
		private void ShowCopyButton(bool showCopyButton, string copyButtonText)
		{
			_copyButton.Visible = showCopyButton;

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
	*/
    #endregion

    internal class InternalKryptonMessageBoxExtended
    {

    }
}