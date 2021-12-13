#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using ContentAlignment = System.Drawing.ContentAlignment;

namespace Krypton.Toolkit.Suite.Extended.InputBox
{
    public class KryptonInputBoxExtended : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonTextBox ktxtInput;
        private KryptonMaskedTextBox kmtxtInput;
        private KryptonComboBox kcmbInput;
        private KryptonWrapLabel kwlMessage;
        private KryptonButton kbtnButtonOne;
        private KryptonButton kbtnButtonThree;
        private KryptonButton kbtnButtonTwo;
        private KryptonButton kbtnButtonFour;
        private InternalKryptonBorderedLabel kblMessage;
        private KryptonLabel klblMessage;
        private PictureBox pbxInputBoxIcon;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnButtonOne = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonTwo = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonThree = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonFour = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.klblMessage = new Krypton.Toolkit.KryptonLabel();
            this.kblMessage = new Krypton.Toolkit.Suite.Extended.InputBox.InternalKryptonBorderedLabel();
            this.ktxtInput = new Krypton.Toolkit.KryptonTextBox();
            this.kmtxtInput = new Krypton.Toolkit.KryptonMaskedTextBox();
            this.kcmbInput = new Krypton.Toolkit.KryptonComboBox();
            this.kwlMessage = new Krypton.Toolkit.KryptonWrapLabel();
            this.pbxInputBoxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInputBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnButtonOne);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonTwo);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonThree);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonFour);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 179);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(584, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnButtonOne
            // 
            this.kbtnButtonOne.Location = new System.Drawing.Point(437, 13);
            this.kbtnButtonOne.Name = "kbtnButtonOne";
            this.kbtnButtonOne.Size = new System.Drawing.Size(134, 25);
            this.kbtnButtonOne.TabIndex = 1;
            this.kbtnButtonOne.Values.Text = "{0}";
            this.kbtnButtonOne.Click += new System.EventHandler(this.kbtnButtonOne_Click);
            // 
            // kbtnButtonTwo
            // 
            this.kbtnButtonTwo.Location = new System.Drawing.Point(297, 13);
            this.kbtnButtonTwo.Name = "kbtnButtonTwo";
            this.kbtnButtonTwo.Size = new System.Drawing.Size(134, 25);
            this.kbtnButtonTwo.TabIndex = 2;
            this.kbtnButtonTwo.Values.Text = "{1}";
            this.kbtnButtonTwo.Click += new System.EventHandler(this.kbtnButtonTwo_Click);
            // 
            // kbtnButtonThree
            // 
            this.kbtnButtonThree.Location = new System.Drawing.Point(157, 13);
            this.kbtnButtonThree.Name = "kbtnButtonThree";
            this.kbtnButtonThree.Size = new System.Drawing.Size(134, 25);
            this.kbtnButtonThree.TabIndex = 3;
            this.kbtnButtonThree.Values.Text = "{2}";
            this.kbtnButtonThree.Click += new System.EventHandler(this.kbtnButtonThree_Click);
            // 
            // kbtnButtonFour
            // 
            this.kbtnButtonFour.Location = new System.Drawing.Point(437, 13);
            this.kbtnButtonFour.Name = "kbtnButtonFour";
            this.kbtnButtonFour.Size = new System.Drawing.Size(134, 25);
            this.kbtnButtonFour.TabIndex = 5;
            this.kbtnButtonFour.Values.Text = "{3}";
            this.kbtnButtonFour.Click += new System.EventHandler(this.kbtnButtonFour_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(584, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.klblMessage);
            this.kryptonPanel2.Controls.Add(this.kblMessage);
            this.kryptonPanel2.Controls.Add(this.ktxtInput);
            this.kryptonPanel2.Controls.Add(this.kmtxtInput);
            this.kryptonPanel2.Controls.Add(this.kcmbInput);
            this.kryptonPanel2.Controls.Add(this.kwlMessage);
            this.kryptonPanel2.Controls.Add(this.pbxInputBoxIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(584, 179);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // klblMessage
            // 
            this.klblMessage.AutoSize = false;
            this.klblMessage.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblMessage.Location = new System.Drawing.Point(147, 12);
            this.klblMessage.Name = "klblMessage";
            this.klblMessage.Size = new System.Drawing.Size(424, 126);
            this.klblMessage.TabIndex = 2;
            this.klblMessage.Values.Text = "kryptonLabel1";
            // 
            // kblMessage
            // 
            this.kblMessage.AutoSize = false;
            this.kblMessage.BackColor = System.Drawing.Color.Transparent;
            this.kblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblMessage.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kblMessage.Location = new System.Drawing.Point(147, 13);
            this.kblMessage.Name = "kblMessage";
            this.kblMessage.Size = new System.Drawing.Size(425, 125);
            this.kblMessage.TabIndex = 6;
            this.kblMessage.Values.Text = "internalKryptonBorderedLabel1";
            this.kblMessage.Visible = false;
            // 
            // ktxtInput
            // 
            this.ktxtInput.Location = new System.Drawing.Point(147, 144);
            this.ktxtInput.Name = "ktxtInput";
            this.ktxtInput.Size = new System.Drawing.Size(425, 23);
            this.ktxtInput.TabIndex = 4;
            this.ktxtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ktxtInput_KeyDown);
            // 
            // kmtxtInput
            // 
            this.kmtxtInput.Location = new System.Drawing.Point(147, 144);
            this.kmtxtInput.Name = "kmtxtInput";
            this.kmtxtInput.Size = new System.Drawing.Size(425, 23);
            this.kmtxtInput.TabIndex = 3;
            this.kmtxtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kmtxtInput_KeyDown);
            // 
            // kcmbInput
            // 
            this.kcmbInput.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbInput.DropDownWidth = 425;
            this.kcmbInput.IntegralHeight = false;
            this.kcmbInput.Location = new System.Drawing.Point(147, 144);
            this.kcmbInput.Name = "kcmbInput";
            this.kcmbInput.Size = new System.Drawing.Size(425, 21);
            this.kcmbInput.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbInput.TabIndex = 2;
            this.kcmbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kcmbInput_KeyDown);
            // 
            // kwlMessage
            // 
            this.kwlMessage.AutoSize = false;
            this.kwlMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.kwlMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlMessage.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kwlMessage.Location = new System.Drawing.Point(147, 13);
            this.kwlMessage.Name = "kwlMessage";
            this.kwlMessage.Size = new System.Drawing.Size(425, 127);
            this.kwlMessage.Text = "kryptonWrapLabel1";
            this.kwlMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxInputBoxIcon
            // 
            this.pbxInputBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxInputBoxIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxInputBoxIcon.Name = "pbxInputBoxIcon";
            this.pbxInputBoxIcon.Size = new System.Drawing.Size(128, 128);
            this.pbxInputBoxIcon.TabIndex = 0;
            this.pbxInputBoxIcon.TabStop = false;
            // 
            // KryptonInputBoxExtended
            // 
            this.ClientSize = new System.Drawing.Size(584, 229);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonInputBoxExtended";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KryptonInputBoxExtended_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInputBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables

        private static DialogResult _response;

        private static string[] _buttonTextArray = new string[4];

        private Image[] _iconImageArray = new Image[7];

        private Image _customImage;

        private DialogResult _buttonOneResult, _buttonTwoResult, _buttonThreeResult, _buttonFourResult;

        #endregion

        #region Properties
        public static DialogResult Response { get => _response; set => _response = value; }

        public Image[] IconImages { get => _iconImageArray; private set => _iconImageArray = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }

        [DefaultValue(typeof(DialogResult), "DialogResult.None"), Description("")]
        public DialogResult ButtonOneResult { get => _buttonOneResult; set => _buttonOneResult = value; }

        [DefaultValue(typeof(DialogResult), "DialogResult.None"), Description("")]
        public DialogResult ButtonTwoResult { get => _buttonTwoResult; set => _buttonTwoResult = value; }

        [DefaultValue(typeof(DialogResult), "DialogResult.None"), Description("")]
        public DialogResult ButtonThreeResult { get => _buttonThreeResult; set => _buttonThreeResult = value; }

        [DefaultValue(typeof(DialogResult), "DialogResult.None"), Description("")]
        public DialogResult ButtonFourResult { get => _buttonFourResult; set => _buttonFourResult = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="language">The language.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        public KryptonInputBoxExtended(string message, string title = "", InputBoxLanguage language = InputBoxLanguage.ENGLISH, 
            InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, 
            Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes",
            string noText = "N&o", string cancelText = "&Cancel", string hintText = "")
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(InputBoxIconType.NONE);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(InputBoxButtons.OK, language);

            ChangeButtonVisibility(InputBoxButtons.OK);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetDialogResult(DialogResult.OK, DialogResult.None, DialogResult.None, DialogResult.None);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        public KryptonInputBoxExtended(string message, string title = "", InputBoxIconType icon = InputBoxIconType.NONE, 
            Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, 
            InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, 
            bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, 
            string okText = "&Ok", string yesText = "&Yes", string noText = "N&o",
            string cancelText = "&Cancel", string hintText = "")
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(InputBoxButtons.OK, language);

            ChangeButtonVisibility(InputBoxButtons.OK);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetDialogResult(DialogResult.None, DialogResult.None, DialogResult.None, DialogResult.OK);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        public KryptonInputBoxExtended(string message, string title = "", InputBoxIconType icon = InputBoxIconType.INFORMATION,
            Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxButtons buttons = InputBoxButtons.OK, 
            InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, 
            Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", 
            string noText = "N&o", string cancelText = "&Cancel", string hintText = "",
            DialogResult buttonOneResult = DialogResult.None, DialogResult buttonTwoResult = DialogResult.None,
            DialogResult buttonThreeResult = DialogResult.None, DialogResult buttonFourResult = DialogResult.None)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetDialogResult(buttonOneResult, buttonTwoResult, buttonThreeResult, buttonFourResult);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        /// <param name="startPosition">The start position.</param>
        public KryptonInputBoxExtended(string message, string title = "", InputBoxIconType icon = InputBoxIconType.INFORMATION, 
            Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, 
            InputBoxButtons buttons = InputBoxButtons.OK, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, 
            bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok",
            string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "",
            FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation,
            DialogResult buttonOneResult = DialogResult.None, DialogResult buttonTwoResult = DialogResult.None,
            DialogResult buttonThreeResult = DialogResult.None, DialogResult buttonFourResult = DialogResult.None)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetStartPosition(startPosition);

            SetDialogResult(buttonOneResult, buttonTwoResult, buttonThreeResult, buttonFourResult);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        /// <param name="textAlignment">The text alignment.</param>
        public KryptonInputBoxExtended(string message, string title = "", InputBoxIconType icon = InputBoxIconType.INFORMATION, 
            Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxButtons buttons = InputBoxButtons.OK, 
            InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, 
            Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", 
            string noText = "N&o", string cancelText = "&Cancel", string hintText = "", 
            InputBoxWrappedMessageTextAlignment textAlignment = InputBoxWrappedMessageTextAlignment.MIDDLELEFT,
            DialogResult buttonOneResult = DialogResult.None, DialogResult buttonTwoResult = DialogResult.None,
            DialogResult buttonThreeResult = DialogResult.None, DialogResult buttonFourResult = DialogResult.None)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetMessageTextAlignment(textAlignment);

            SetDialogResult(buttonOneResult, buttonTwoResult, buttonThreeResult, buttonFourResult);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="iconLocation">The icon location.</param>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        /// <param name="startPosition">The start position.</param>
        /// <param name="textAlignment">The text alignment.</param>
        public KryptonInputBoxExtended(Point iconLocation, string message, string title = "", 
            InputBoxIconType icon = InputBoxIconType.INFORMATION, Image image = null, 
            InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxButtons buttons = InputBoxButtons.OK, 
            InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false,
            Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", 
            string noText = "N&o", string cancelText = "&Cancel", string hintText = "", 
            FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation, 
            InputBoxTextAlignment textAlignment = InputBoxTextAlignment.LEFT,
            DialogResult buttonOneResult = DialogResult.None, DialogResult buttonTwoResult = DialogResult.None,
            DialogResult buttonThreeResult = DialogResult.None, DialogResult buttonFourResult = DialogResult.None)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            RelocateIcon(iconLocation);

            SetTextAlignment(textAlignment);

            SetStartPosition(startPosition);

            SetDialogResult(buttonOneResult, buttonTwoResult, buttonThreeResult, buttonFourResult);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void SetMessage(string message) => kwlMessage.Text = message;

        /// <summary>Sets the title.</summary>
        /// <param name="title">The title.</param>
        private void SetTitle(string title) => Text = title;

        /// <summary>Sets the message typeface.</summary>
        /// <param name="typeface">The typeface.</param>
        private void SetMessageTypeface(Font typeface) => kwlMessage.StateCommon.Font = typeface;

        /// <summary>Sets the show in taskbar.</summary>
        /// <param name="showInTaskbar">if set to <c>true</c> [show in taskbar].</param>
        private void SetShowInTaskbar(bool showInTaskbar) => ShowInTaskbar = showInTaskbar;

        /// <summary>
        /// Sets the hint.
        /// </summary>
        /// <param name="hintText">The hint text.</param>
        private void SetHint(string hintText) => ktxtInput.CueHint.CueHintText = hintText;

        /// <summary>Sets the control typeface.</summary>
        /// <param name="typeface">The typeface.</param>
        private void SetControlTypeface(Font typeface)
        {
            kbtnButtonThree.StateCommon.Content.ShortText.Font = typeface;

            kbtnButtonFour.StateCommon.Content.ShortText.Font = typeface;

            kbtnButtonOne.StateCommon.Content.ShortText.Font = typeface;

            kbtnButtonTwo.StateCommon.Content.ShortText.Font = typeface;
        }

        /// <summary>
        /// Sets the language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        private void SetLanguage(InputBoxLanguage language, string okText = "", string yesText = "", string noText = "", string cancelText = "")
        {
            switch (language)
            {
                case InputBoxLanguage.CZECH:
                    _buttonTextArray = "OK,Ano,Ne,Storno".Split(',');
                    break;
                case InputBoxLanguage.FRENCH:
                    _buttonTextArray = "OK,Oui,Non,Annuler".Split(',');
                    break;
                case InputBoxLanguage.GERMAN:
                    _buttonTextArray = "OK,Ja,Nein,Stornieren".Split(',');
                    break;
                case InputBoxLanguage.SLOVAKIAN:
                    _buttonTextArray = "OK,Áno,Nie,Zrušiť".Split(',');
                    break;
                case InputBoxLanguage.SPANISH:
                    _buttonTextArray = "OK,Sí,No,Cancelar".Split(',');
                    break;
                case InputBoxLanguage.CUSTOM:
                    _buttonTextArray = SetCustomText(okText, yesText, noText, cancelText);
                    break;
                default:
                    _buttonTextArray = "OK,Yes,No,Cancel".Split(',');
                    break;
            }
        }

        /// <summary>
        /// Sets the custom text.
        /// </summary>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <returns></returns>
        private static string[] SetCustomText(string okText, string yesText, string noText, string cancelText)
        {
            string[] tempArray = new string[4];

            tempArray = $"{ okText },{ yesText },{ noText },{ cancelText }".Split(',');

            return tempArray;
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, EventArgs e)
        {
            KryptonButton button = (KryptonButton)sender;

            switch (button.Name)
            {
                case "kbtnButtonOne":
                    SetResponse(DialogResult.Yes);
                    break;
                case "kbtnButtonTwo":
                    SetResponse(DialogResult.No);
                    break;
                case "kbtnButtonThree":
                    SetResponse(DialogResult.Cancel);
                    break;
                case "kbtnButtonFour":
                    SetResponse(DialogResult.OK);
                    break;
                default:
                    SetResponse(DialogResult.None);
                    break;
            }
        }

        /// <summary>Sets the type of the icon.</summary>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <exception cref="ArgumentNullException"></exception>
        private void SetIconType(InputBoxIconType icon, Image image = null)
        {
            switch (icon)
            {
                case InputBoxIconType.CUSTOM:
                    if (image != null)
                    {
                        AdaptUI(true);

                        SetIconImage(image);
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                    break;
                case InputBoxIconType.OK:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Ok);
                    break;
                case InputBoxIconType.ERROR:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Critical);
                    break;
                case InputBoxIconType.EXCLAMATION:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Warning);
                    break;
                case InputBoxIconType.INFORMATION:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Information);
                    break;
                case InputBoxIconType.QUESTION:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Question);
                    break;
                case InputBoxIconType.NONE:
                    AdaptUI(false);
                    break;
                case InputBoxIconType.STOP:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Stop);
                    break;
                case InputBoxIconType.HAND:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Hand);
                    break;
            }
        }

        /// <summary>Sets the icon image.</summary>
        /// <param name="image">The image.</param>
        private void SetIconImage(Image image) => pbxInputBoxIcon.Image = image;

        /// <summary>Adapts the buttons.</summary>
        /// <param name="buttons">The buttons.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        private KryptonButton[] AdaptButtons(InputBoxButtons buttons, InputBoxLanguage language)
        {
            KryptonButton[] buttonArray = new KryptonButton[3];

            #region Set Button Text
            kbtnButtonOne.Text = _buttonTextArray[0];

            kbtnButtonTwo.Text = _buttonTextArray[1];

            kbtnButtonFour.Text = _buttonTextArray[2];

            kbtnButtonThree.Text = _buttonTextArray[3];
            #endregion

            // TODO: Review locations

            switch (buttons)
            {
                case InputBoxButtons.OK:
                    kbtnButtonOne.Location = new Point(483, 9);

                    buttonArray[0] = kbtnButtonOne;
                    break;
                case InputBoxButtons.OKCANCEL:
                    kbtnButtonOne.Location = new Point(388, 9);

                    buttonArray[0] = kbtnButtonOne;

                    kbtnButtonThree.Location = new Point(483, 9);

                    buttonArray[1] = kbtnButtonThree;
                    break;
                case InputBoxButtons.YESNO:
                    kbtnButtonTwo.Location = new Point(388, 9);

                    buttonArray[0] = kbtnButtonTwo;

                    kbtnButtonFour.Location = new Point(483, 9);

                    buttonArray[1] = kbtnButtonFour;
                    break;
                case InputBoxButtons.YESNOCANCEL:
                    kbtnButtonTwo.Location = new Point(293, 9);

                    buttonArray[0] = kbtnButtonTwo;

                    kbtnButtonFour.Location = new Point(388, 9);

                    buttonArray[1] = kbtnButtonFour;

                    kbtnButtonThree.Location = new Point(483, 9);

                    buttonArray[2] = kbtnButtonThree;
                    break;
            }

            foreach (KryptonButton button in buttonArray)
            {
                if (button != null)
                {
                    button.Size = new Size(89, 28);

                    button.Click += Button_Click;
                }
            }

            return buttonArray;
        }

        /// <summary>Adapts the UI.</summary>
        /// <param name="showIconBox">if set to <c>true</c> [show icon box].</param>
        private void AdaptUI(bool showIconBox)
        {
            if (showIconBox)
            {
                pbxInputBoxIcon.Visible = true;

                ResizeControls(new Size(425, 125), new Size(425, 23), new Size(425, 23));
            }
            else
            {
                pbxInputBoxIcon.Visible = false;

                ResizeControls(new Size(559, 126), new Size(560, 23), new Size(560, 23));
            }
        }

        /// <summary>Adapts the UI.</summary>
        /// <param name="type">The type.</param>
        /// <param name="itemList">The item list.</param>
        private void AdaptUI(InputBoxInputType type, string[] itemList)
        {
            if (itemList != null)
            {
                foreach (string item in itemList)
                {
                    kcmbInput.Items.Add(item);
                }

                kcmbInput.SelectedIndex = 0;
            }

            switch (type)
            {
                case InputBoxInputType.COMBOBOX:
                    ktxtInput.Visible = false;

                    kmtxtInput.Visible = false;

                    kcmbInput.Visible = true;
                    break;
                case InputBoxInputType.TEXTBOX:
                    ktxtInput.Visible = true;

                    kmtxtInput.Visible = false;

                    kcmbInput.Visible = false;
                    break;
                case InputBoxInputType.MASKEDTEXTBOX:
                    ktxtInput.Visible = false;

                    kmtxtInput.Visible = true;

                    kcmbInput.Visible = false;
                    break;
            }
        }

        /// <summary>Adapts the display type of the message.</summary>
        /// <param name="displayType">The display type.</param>
        private void AdaptMessageDisplayType(InputBoxMessageDisplayType displayType)
        {
            switch (displayType)
            {
                case InputBoxMessageDisplayType.BORDEREDLABEL:
                    kblMessage.Visible = true;

                    kwlMessage.Visible = false;
                    break;
                case InputBoxMessageDisplayType.LABEL:
                    kblMessage.Visible = false;

                    kwlMessage.Visible = true;

                    kwlMessage.Visible = false;
                    break;
                case InputBoxMessageDisplayType.WRAPPEDLABEL:
                    kblMessage.Visible = false;

                    kwlMessage.Visible = false;

                    kwlMessage.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Resizes the controls.
        /// </summary>
        /// <param name="messageLabelSize">Size of the message label.</param>
        /// <param name="userSelectionSize">Size of the user selection.</param>
        /// <param name="userInputSize">Size of the user input.</param>
        /// <returns></returns>
        private void ResizeControls(Size messageLabelSize, Size userSelectionSize, Size userInputSize)
        {
            kblMessage.Size = messageLabelSize;

            klblMessage.Size = messageLabelSize;

            kwlMessage.Size = messageLabelSize;

            kcmbInput.Size = userSelectionSize;

            kmtxtInput.Size = userInputSize;

            ktxtInput.Size = userInputSize;
        }

        /// <summary>
        /// Sets the text alignment.
        /// </summary>
        /// <param name="textAlignment">The text alignment.</param>
        private void SetTextAlignment(InputBoxTextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case InputBoxTextAlignment.LEFT:
                    ktxtInput.TextAlign = HorizontalAlignment.Left;
                    break;
                case InputBoxTextAlignment.CENTRE:
                    ktxtInput.TextAlign = HorizontalAlignment.Center;
                    break;
                case InputBoxTextAlignment.RIGHT:
                    ktxtInput.TextAlign = HorizontalAlignment.Right;
                    break;
            }
        }

        /// <summary>
        /// Gets the user response.
        /// </summary>
        /// <returns></returns>
        public string GetUserResponse() => ktxtInput.Text;

        /// <summary>
        /// Gets the user choice.
        /// </summary>
        /// <returns></returns>
        public string GetUserChoice() => kcmbInput.Text;

        /// <summary>Relocates the icon.</summary>
        /// <param name="newPoint">The new point.</param>
        private void RelocateIcon(Point newPoint) => pbxInputBoxIcon.Location = newPoint;

        private void SetStartPosition(FormStartPosition startPosition) => StartPosition = startPosition;

        /// <summary>
        /// Changes the button visibility.
        /// </summary>
        /// <param name="buttons">The buttons.</param>
        private void ChangeButtonVisibility(InputBoxButtons buttons)
        {
            switch (buttons)
            {
                case InputBoxButtons.OK:
                    kbtnButtonOne.Visible = true;

                    kbtnButtonThree.Visible = false;

                    kbtnButtonFour.Visible = false;

                    kbtnButtonTwo.Visible = false;
                    break;
                case InputBoxButtons.OKCANCEL:
                    kbtnButtonOne.Visible = true;

                    kbtnButtonThree.Visible = true;

                    kbtnButtonFour.Visible = false;

                    kbtnButtonTwo.Visible = false;
                    break;
                case InputBoxButtons.YESNO:
                    kbtnButtonOne.Visible = false;

                    kbtnButtonThree.Visible = false;

                    kbtnButtonFour.Visible = true;

                    kbtnButtonTwo.Visible = true;
                    break;
                case InputBoxButtons.YESNOCANCEL:
                    kbtnButtonOne.Visible = false;

                    kbtnButtonThree.Visible = true;

                    kbtnButtonFour.Visible = true;

                    kbtnButtonTwo.Visible = true;
                    break;
            }
        }

        /// <summary>Sets the mask.</summary>
        /// <param name="maskText">The mask text.</param>
        private void SetMask(string maskText) => kmtxtInput.Mask = maskText;

        /// <summary>Sets the masked textbox text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void SetMaskedTextboxTextAlignment(InputBoxTextAlignment alignment)
        {
            switch (alignment)
            {
                case InputBoxTextAlignment.LEFT:
                    kmtxtInput.TextAlign = HorizontalAlignment.Left;
                    break;
                case InputBoxTextAlignment.CENTRE:
                    kmtxtInput.TextAlign = HorizontalAlignment.Center;
                    break;
                case InputBoxTextAlignment.RIGHT:
                    kmtxtInput.TextAlign = HorizontalAlignment.Right;
                    break;
            }
        }

        /*
        /// <summary>Sets the message text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void SetMessageTextAlignment(MessageTextAlignment alignment)
        {
            switch (alignment)
            {
                case MessageTextAlignment.INHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case MessageTextAlignment.NEARNEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.NEARCENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.NEARFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.CENTRENEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.CENTRECENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.CENTREFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.FARNEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.FARCENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.FARFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.INHERITNEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.INHERITCENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.INHERITFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.NEARINHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case MessageTextAlignment.CENTREINHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case MessageTextAlignment.FARINHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
            }
        }
        */

        /// <summary>Sets the message text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void SetMessageTextAlignment(InputBoxWrappedMessageTextAlignment alignment)
        {
            switch (alignment)
            {
                case InputBoxWrappedMessageTextAlignment.TOPLEFT:
                    kwlMessage.TextAlign = ContentAlignment.TopLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.TOPCENTRE:
                    kwlMessage.TextAlign = ContentAlignment.TopCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.TOPRIGHT:
                    kwlMessage.TextAlign = ContentAlignment.TopRight;
                    break;
                case InputBoxWrappedMessageTextAlignment.MIDDLELEFT:
                    kwlMessage.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.MIDDLECENTRE:
                    kwlMessage.TextAlign = ContentAlignment.MiddleCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.MIDDLERIGHT:
                    kwlMessage.TextAlign = ContentAlignment.MiddleRight;
                    break;
                case InputBoxWrappedMessageTextAlignment.BOTTOMLEFT:
                    kwlMessage.TextAlign = ContentAlignment.BottomLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.BOTTOMCENTRE:
                    kwlMessage.TextAlign = ContentAlignment.BottomCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.BOTTOMRIGHT:
                    kwlMessage.TextAlign = ContentAlignment.BottomRight;
                    break;
                default:
                    kwlMessage.TextAlign = ContentAlignment.MiddleLeft;
                    break;
            }
        }

        private void PropagateIconImageArray(Image[] imageArray)
        {
            imageArray[0] = Properties.Resources.Critical;

            imageArray[1] = Properties.Resources.Hand;

            imageArray[2] = Properties.Resources.Information;

            imageArray[3] = Properties.Resources.Ok;

            imageArray[4] = Properties.Resources.Question;

            imageArray[5] = Properties.Resources.Stop;

            imageArray[6] = Properties.Resources.Warning;
        }

        private Image[] ReturnIconImageArray() => IconImages;

        private void SetResponse(DialogResult response) => Response = response;

        /// <summary>Sets the dialog result.</summary>
        /// <param name="buttonOneResult">The button one result.</param>
        /// <param name="buttonTwoResult">The button two result.</param>
        /// <param name="buttonThreeResult">The button three result.</param>
        /// <param name="buttonFourResult">The button four result.</param>
        private void SetDialogResult(DialogResult buttonOneResult, DialogResult buttonTwoResult, DialogResult buttonThreeResult, DialogResult buttonFourResult)
        {
            kbtnButtonOne.DialogResult = buttonOneResult;

            kbtnButtonTwo.DialogResult = buttonTwoResult;

            kbtnButtonThree.DialogResult = buttonThreeResult;

            kbtnButtonFour.DialogResult = buttonFourResult;
        }

        /// <summary>Sets the button focus.</summary>
        /// <param name="buttons">The buttons.</param>
        private void SetButtonFocus(InputBoxButtonFocus buttons)
        {
            switch (buttons)
            {
                case InputBoxButtonFocus.BUTTONONE:
                    kbtnButtonOne.Focus();
                    break;
                case InputBoxButtonFocus.BUTTONTWO:
                    kbtnButtonTwo.Focus();
                    break;
                case InputBoxButtonFocus.BUTTONTHREE:
                    kbtnButtonThree.Focus();
                    break;
                case InputBoxButtonFocus.BUTTONFOUR:
                    kbtnButtonFour.Focus();
                    break;
            }
        }

        /// <summary>Sets the input type focus.</summary>
        /// <param name="inputType">Type of the input.</param>
        private void SetInputTypeFocus(InputBoxInputType inputType)
        {
            switch (inputType)
            {
                case InputBoxInputType.COMBOBOX:
                    kcmbInput.Focus();
                    break;
                case InputBoxInputType.MASKEDTEXTBOX:
                    kmtxtInput.Focus();
                    break;
                case InputBoxInputType.TEXTBOX:
                    ktxtInput.Focus();
                    break;
                case InputBoxInputType.NONE:
                    kwlMessage.Focus();
                    break;
            }
        }

        private void ResultKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;

                Close();
            }
        }
        #endregion

        #region Event Handlers
        private void KryptonInputBoxExtended_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Response != DialogResult.None)
            {
                Response = DialogResult;
            }
            else
            {
                DialogResult = Response;
            }
        }

        private void ktxtInput_KeyDown(object sender, KeyEventArgs e) => ResultKeyDown(e);

        private void kbtnButtonOne_Click(object sender, EventArgs e) => kbtnButtonOne.DialogResult = _buttonOneResult;

        private void kbtnButtonTwo_Click(object sender, EventArgs e) => kbtnButtonTwo.DialogResult = _buttonTwoResult;

        private void kbtnButtonThree_Click(object sender, EventArgs e) => kbtnButtonThree.DialogResult = _buttonThreeResult;

        private void kbtnButtonFour_Click(object sender, EventArgs e) => kbtnButtonFour.DialogResult = _buttonFourResult;

        private void kmtxtInput_KeyDown(object sender, KeyEventArgs e) => ResultKeyDown(e);

        private void kcmbInput_KeyDown(object sender, KeyEventArgs e) => ResultKeyDown(e);
        #endregion
    }
}