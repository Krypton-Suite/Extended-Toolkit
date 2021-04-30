using Krypton.Toolkit.Suite.Extended.Controls;
using Krypton.Toolkit.Suite.Extended.Dialogs.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonInputBoxExtended : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnFirstButton;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonButton kbtnThirdButton;
        private KryptonButton kbtnSecondButton;
        private KryptonTextBox ktxtInput;
        private KryptonComboBox kcmbInput;
        private KryptonWrapLabel kwlMessage;
        private System.Windows.Forms.PictureBox pbxImage;
        private KryptonMaskedTextBox kmtxtInput;
        private KryptonBorderedLabel kblMessage;
        private KryptonLabel klblMessage;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnFirstButton = new Krypton.Toolkit.KryptonButton();
            this.kbtnSecondButton = new Krypton.Toolkit.KryptonButton();
            this.kbtnThirdButton = new Krypton.Toolkit.KryptonButton();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.kwlMessage = new Krypton.Toolkit.KryptonWrapLabel();
            this.kcmbInput = new Krypton.Toolkit.KryptonComboBox();
            this.ktxtInput = new Krypton.Toolkit.KryptonTextBox();
            this.kmtxtInput = new Krypton.Toolkit.KryptonMaskedTextBox();
            this.klblMessage = new Krypton.Toolkit.KryptonLabel();
            this.kblMessage = new Krypton.Toolkit.Suite.Extended.Controls.KryptonBorderedLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbInput)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnFirstButton);
            this.kryptonPanel1.Controls.Add(this.kbtnThirdButton);
            this.kryptonPanel1.Controls.Add(this.kbtnSecondButton);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 189);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(551, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(551, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kblMessage);
            this.kryptonPanel2.Controls.Add(this.klblMessage);
            this.kryptonPanel2.Controls.Add(this.kmtxtInput);
            this.kryptonPanel2.Controls.Add(this.ktxtInput);
            this.kryptonPanel2.Controls.Add(this.kcmbInput);
            this.kryptonPanel2.Controls.Add(this.kwlMessage);
            this.kryptonPanel2.Controls.Add(this.pbxImage);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(551, 189);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnFirstButton
            // 
            this.kbtnFirstButton.Location = new System.Drawing.Point(170, 13);
            this.kbtnFirstButton.Name = "kbtnFirstButton";
            this.kbtnFirstButton.Size = new System.Drawing.Size(119, 25);
            this.kbtnFirstButton.TabIndex = 1;
            this.kbtnFirstButton.Values.Text = "kryptonButton1";
            // 
            // kbtnSecondButton
            // 
            this.kbtnSecondButton.Location = new System.Drawing.Point(295, 13);
            this.kbtnSecondButton.Name = "kbtnSecondButton";
            this.kbtnSecondButton.Size = new System.Drawing.Size(119, 25);
            this.kbtnSecondButton.TabIndex = 2;
            this.kbtnSecondButton.Values.Text = "kryptonButton2";
            // 
            // kbtnThirdButton
            // 
            this.kbtnThirdButton.Location = new System.Drawing.Point(420, 13);
            this.kbtnThirdButton.Name = "kbtnThirdButton";
            this.kbtnThirdButton.Size = new System.Drawing.Size(119, 25);
            this.kbtnThirdButton.TabIndex = 3;
            this.kbtnThirdButton.Values.Text = "kryptonButton3";
            // 
            // pbxImage
            // 
            this.pbxImage.BackColor = System.Drawing.Color.Transparent;
            this.pbxImage.Location = new System.Drawing.Point(12, 12);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(128, 128);
            this.pbxImage.TabIndex = 0;
            this.pbxImage.TabStop = false;
            // 
            // kwlMessage
            // 
            this.kwlMessage.AutoEllipsis = true;
            this.kwlMessage.AutoSize = false;
            this.kwlMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlMessage.Location = new System.Drawing.Point(146, 12);
            this.kwlMessage.Name = "kwlMessage";
            this.kwlMessage.Size = new System.Drawing.Size(393, 128);
            this.kwlMessage.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlMessage.Text = "kryptonWrapLabel1";
            this.kwlMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kcmbInput
            // 
            this.kcmbInput.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.kcmbInput.DropDownWidth = 393;
            this.kcmbInput.IntegralHeight = false;
            this.kcmbInput.Location = new System.Drawing.Point(146, 144);
            this.kcmbInput.Name = "kcmbInput";
            this.kcmbInput.Size = new System.Drawing.Size(393, 21);
            this.kcmbInput.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbInput.TabIndex = 2;
            this.kcmbInput.KeyDown += kcmbInput_KeyDown;
            // 
            // ktxtInput
            // 
            this.ktxtInput.Location = new System.Drawing.Point(146, 144);
            this.ktxtInput.Name = "ktxtInput";
            this.ktxtInput.Size = new System.Drawing.Size(393, 23);
            this.ktxtInput.TabIndex = 2;
            this.ktxtInput.KeyDown += ktxtInput_KeyDown;
            // 
            // kmtxtInput
            // 
            this.kmtxtInput.Location = new System.Drawing.Point(146, 144);
            this.kmtxtInput.Name = "kmtxtInput";
            this.kmtxtInput.Size = new System.Drawing.Size(393, 23);
            this.kmtxtInput.TabIndex = 2;
            this.kmtxtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kmtxtInput_KeyDown);
            // 
            // klblMessage
            // 
            this.klblMessage.AutoSize = false;
            this.klblMessage.Location = new System.Drawing.Point(146, 12);
            this.klblMessage.Name = "klblMessage";
            this.klblMessage.Size = new System.Drawing.Size(393, 128);
            this.klblMessage.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMessage.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.EllipsisWord;
            this.klblMessage.TabIndex = 2;
            this.klblMessage.Values.Text = "kryptonLabel1";
            // 
            // kblMessage
            // 
            this.kblMessage.AutoSize = false;
            this.kblMessage.BackColor = System.Drawing.Color.Transparent;
            this.kblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblMessage.Location = new System.Drawing.Point(146, 12);
            this.kblMessage.Name = "kblMessage";
            this.kblMessage.Size = new System.Drawing.Size(393, 128);
            this.kblMessage.TabIndex = 2;
            this.kblMessage.Values.Text = "kryptonBorderedLabel1";
            // 
            // KryptonInputBoxExtended
            // 
            this.ClientSize = new System.Drawing.Size(551, 239);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbInput)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private static DialogResult _userResponse;

        private static string[] _buttonTextArray = new string[4];

        private Image[] _iconImageArray = new Image[7];

        private Image _customImage;
        #endregion

        #region Properties
        public static DialogResult UserResponse { get => _userResponse; set => _userResponse = value; }

        public Image[] IconImages { get => _iconImageArray; private set => _iconImageArray = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended" /> class.</summary>
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
        public KryptonInputBoxExtended(string message, string title = "", InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "")
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
        public KryptonInputBoxExtended(string message, string title = "", InputBoxIconType icon = InputBoxIconType.NONE, Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "")
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
        public KryptonInputBoxExtended(string message, string title = "", InputBoxIconType icon = InputBoxIconType.INFORMATION, Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxButtons buttons = InputBoxButtons.OK, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "")
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
        public KryptonInputBoxExtended(string message, string title = "", InputBoxIconType icon = InputBoxIconType.INFORMATION, Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxButtons buttons = InputBoxButtons.OK, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation)
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
        public KryptonInputBoxExtended(string message, string title = "", InputBoxIconType icon = InputBoxIconType.INFORMATION, Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxButtons buttons = InputBoxButtons.OK, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", InputBoxWrappedMessageTextAlignment textAlignment = InputBoxWrappedMessageTextAlignment.MIDDLELEFT)
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
        public KryptonInputBoxExtended(Point iconLocation, string message, string title = "", InputBoxIconType icon = InputBoxIconType.INFORMATION, Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxButtons buttons = InputBoxButtons.OK, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation, InputBoxTextAlignment textAlignment = InputBoxTextAlignment.LEFT)
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
        }

        // TODO: Complete this
        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended" /> class.</summary>
        /// <param name="inputBoxIconLocation">The input box icon location.</param>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="imageSize">Size of the image.</param>
        /// <param name="inputBoxLanguage">The input box language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="inputType">Type of the input.</param>
        /// <param name="displayType">The display type.</param>
        /// <param name="itemList">The item list.</param>
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
        /// <param name="messageTextAlignment">The message text alignment.</param>
        /// <param name="wrappedMessageTextAlignment">The wrapped message text alignment.</param>
        public KryptonInputBoxExtended(Point inputBoxIconLocation, string message, string title, InputBoxIconType iconType, Image customImage, InputBoxIconImageSize imageSize, InputBoxLanguage inputBoxLanguage, InputBoxButtons buttons, InputBoxInputType inputType, InputBoxMessageDisplayType displayType, string[] itemList, bool showInTaskBar, Font controlTypeface, Font messageTypeface, string okText, string yesText, string noText, string cancelText, string hintText, FormStartPosition startPosition, InputBoxTextAlignment textAlignment, InputBoxNormalMessageTextAlignment messageTextAlignment, InputBoxWrappedMessageTextAlignment wrappedMessageTextAlignment)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(iconType, customImage);

            SetCustomImageSize(imageSize, customImage);

            SetLanguage(inputBoxLanguage, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, inputBoxLanguage);

            ChangeButtonVisibility(buttons);

            AdaptUI(inputType, itemList);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetDisplayType(displayType);

            SetHint(hintText);

            RelocateIcon(inputBoxIconLocation);

            SetTextAlignment(textAlignment);

            SetMessageTextAlignment(messageTextAlignment);

            SetWrappedMessageTextAlignment(wrappedMessageTextAlignment);

            SetStartPosition(startPosition);
        }
        #endregion

        private void KryptonInputBoxExtended_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.None)
            {
                _userResponse = DialogResult;
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void ktxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void kmtxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void kcmbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;

                Close();
            }
        }

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
        private void SetHint(string hintText) => ktxtInput.Hint = hintText;

        /// <summary>Sets the control typeface.</summary>
        /// <param name="typeface">The typeface.</param>
        private void SetControlTypeface(Font typeface)
        {
            kbtnThirdButton.StateCommon.Content.ShortText.Font = typeface;

            kbtnFirstButton.StateCommon.Content.ShortText.Font = typeface;

            kbtnSecondButton.StateCommon.Content.ShortText.Font = typeface;
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
                case "kbtnChoiceOne":
                    UserResponse = DialogResult.Yes;
                    break;
                case "kbtnChoiceTwo":
                    UserResponse = DialogResult.No;
                    break;
                case "kbtnChoiceThree":
                    UserResponse = DialogResult.Cancel;
                    break;
                default:
                    UserResponse = DialogResult.OK;
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

                    SetIconImage(Resources.Input_Box_Ok_128_x_128);
                    break;
                case InputBoxIconType.ERROR:
                    AdaptUI(true);

                    SetIconImage(Resources.Input_Box_Critical_128_x_128);
                    break;
                case InputBoxIconType.EXCLAMATION:
                    AdaptUI(true);

                    SetIconImage(Resources.Input_Box_Warning_128_x_115);
                    break;
                case InputBoxIconType.INFORMATION:
                    AdaptUI(true);

                    SetIconImage(Resources.Input_Box_Information_128_x_128);
                    break;
                case InputBoxIconType.QUESTION:
                    AdaptUI(true);

                    SetIconImage(Resources.Input_Box_Question_128_x_128); ;
                    break;
                case InputBoxIconType.NONE:
                    AdaptUI(false);
                    break;
                case InputBoxIconType.STOP:
                    AdaptUI(true);

                    SetIconImage(Resources.Input_Box_Stop_128_x_128);
                    break;
                case InputBoxIconType.HAND:
                    AdaptUI(true);

                    SetIconImage(Resources.Input_Box_Hand_128_x_128);
                    break;
            }
        }

        /// <summary>Sets the icon image.</summary>
        /// <param name="image">The image.</param>
        private void SetIconImage(Image image) => pbxImage.Image = image;

        /// <summary>Adapts the buttons.</summary>
        /// <param name="buttons">The buttons.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        // TODO: Re-look at this
        private KryptonButton[] AdaptButtons(InputBoxButtons buttons, InputBoxLanguage language)
        {
            KryptonButton[] buttonArray = new KryptonButton[3];

            #region Set Button Text
            kbtnFirstButton.Text = _buttonTextArray[0];

            kbtnSecondButton.Text = _buttonTextArray[1];

            kbtnThirdButton.Text = _buttonTextArray[2];
            #endregion

            switch (buttons)
            {
                case InputBoxButtons.OK:
                    kbtnFirstButton.Location = new Point(483, 9);

                    buttonArray[0] = kbtnFirstButton;
                    break;
                case InputBoxButtons.OKCANCEL:
                    kbtnFirstButton.Location = new Point(388, 9);

                    buttonArray[0] = kbtnFirstButton;

                    kbtnThirdButton.Location = new Point(483, 9);

                    buttonArray[1] = kbtnThirdButton;
                    break;
                case InputBoxButtons.YESNO:
                    kbtnSecondButton.Location = new Point(388, 9);

                    buttonArray[0] = kbtnSecondButton;

                    kbtnThirdButton.Location = new Point(483, 9);

                    buttonArray[1] = kbtnThirdButton;
                    break;
                case InputBoxButtons.YESNOCANCEL:
                    kbtnFirstButton.Location = new Point(293, 9);

                    buttonArray[0] = kbtnFirstButton;

                    kbtnSecondButton.Location = new Point(388, 9);

                    buttonArray[1] = kbtnSecondButton;

                    kbtnThirdButton.Location = new Point(483, 9);

                    buttonArray[2] = kbtnThirdButton;
                    break;
                default:
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
                pbxImage.Visible = true;

                ResizeControls(new Size(489, 175), new Point(213, 192), new Point(213, 192));
            }
            else
            {
                pbxImage.Visible = false;

                ResizeControls(new Size(560, 175), new Point(180, 192), new Point(180, 192));
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

                    klblMessage.Visible = false;

                    kwlMessage.Visible = false;
                    break;
                case InputBoxMessageDisplayType.LABEL:
                    kblMessage.Visible = false;

                    klblMessage.Visible = true;

                    kwlMessage.Visible = false;
                    break;
                case InputBoxMessageDisplayType.WRAPPEDLABEL:
                    kblMessage.Visible = false;

                    klblMessage.Visible = false;

                    kwlMessage.Visible = true;
                    break;
            }
        }

        /// <summary>Resizes the controls.</summary>
        /// <param name="messageLabelSize">Size of the message label.</param>
        /// <param name="userSelectionLocation">The user selection location.</param>
        /// <param name="userInputLocation">The user input location.</param>
        private void ResizeControls(Size messageLabelSize, Point userSelectionLocation, Point userInputLocation)
        {
            kwlMessage.Size = messageLabelSize;

            kcmbInput.Location = userSelectionLocation;

            ktxtInput.Location = userInputLocation;

            kmtxtInput.Location = userInputLocation;
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
        private void RelocateIcon(Point newPoint) => pbxImage.Location = newPoint;

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
                    kbtnFirstButton.Visible = true;

                    kbtnThirdButton.Visible = false;

                    kbtnThirdButton.DialogResult = DialogResult.OK;

                    kbtnSecondButton.Visible = false;
                    break;
                case InputBoxButtons.OKCANCEL:
                    kbtnFirstButton.Visible = true;

                    kbtnThirdButton.Visible = true;

                    kbtnThirdButton.DialogResult = DialogResult.Cancel;

                    kbtnSecondButton.Visible = false;

                    kbtnSecondButton.DialogResult = DialogResult.OK;
                    break;
                case InputBoxButtons.YESNO:
                    kbtnFirstButton.Visible = false;

                    kbtnThirdButton.Visible = false;

                    kbtnThirdButton.DialogResult = DialogResult.No;

                    kbtnSecondButton.Visible = true;

                    kbtnSecondButton.DialogResult = DialogResult.Yes;
                    break;
                case InputBoxButtons.YESNOCANCEL:
                    kbtnFirstButton.Visible = true;

                    kbtnFirstButton.DialogResult = DialogResult.Yes;

                    kbtnThirdButton.Visible = true;

                    kbtnThirdButton.DialogResult = DialogResult.Cancel;

                    kbtnSecondButton.Visible = true;

                    kbtnSecondButton.DialogResult = DialogResult.No;
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

        /// <summary>Sets the message text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void SetWrappedMessageTextAlignment(InputBoxWrappedMessageTextAlignment alignment)
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
            imageArray[0] = Resources.Input_Box_Critical_128_x_128;

            imageArray[1] = Resources.Input_Box_Hand_128_x_128;

            imageArray[2] = Resources.Input_Box_Information_128_x_128;

            imageArray[3] = Resources.Input_Box_Ok_128_x_128;

            imageArray[4] = Resources.Input_Box_Question_128_x_128;

            imageArray[5] = Resources.Input_Box_Stop_128_x_128;

            imageArray[6] = Resources.Input_Box_Warning_128_x_115;
        }

        private Image[] ReturnIconImageArray() => IconImages;

        private void SetMessageTextAlignment(InputBoxWrappedMessageTextAlignment textAlignment)
        {
            switch (textAlignment)
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

        private void SetMessageTextAlignment(InputBoxNormalMessageTextAlignment messageTextAlignment)
        {
            switch (messageTextAlignment)
            {
                case InputBoxNormalMessageTextAlignment.INHERIT:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case InputBoxNormalMessageTextAlignment.NEARNEAR:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case InputBoxNormalMessageTextAlignment.NEARCENTRE:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case InputBoxNormalMessageTextAlignment.NEARFAR:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case InputBoxNormalMessageTextAlignment.CENTRENEAR:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case InputBoxNormalMessageTextAlignment.CENTRECENTRE:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case InputBoxNormalMessageTextAlignment.CENTREFAR:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case InputBoxNormalMessageTextAlignment.FARNEAR:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case InputBoxNormalMessageTextAlignment.FARCENTRE:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case InputBoxNormalMessageTextAlignment.FARFAR:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case InputBoxNormalMessageTextAlignment.INHERITNEAR:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case InputBoxNormalMessageTextAlignment.INHERITCENTRE:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case InputBoxNormalMessageTextAlignment.INHERITFAR:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case InputBoxNormalMessageTextAlignment.NEARINHERIT:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case InputBoxNormalMessageTextAlignment.CENTREINHERIT:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case InputBoxNormalMessageTextAlignment.FARINHERIT:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                default:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
            }
        }

        private void SetDisplayType(InputBoxMessageDisplayType displayType)
        {
            switch (displayType)
            {
                case InputBoxMessageDisplayType.LABEL:
                    kblMessage.Visible = false;

                    klblMessage.Visible = true;

                    kwlMessage.Visible = false;
                    break;
                case InputBoxMessageDisplayType.BORDEREDLABEL:
                    kblMessage.Visible = true;

                    klblMessage.Visible = false;

                    kwlMessage.Visible = false;
                    break;
                case InputBoxMessageDisplayType.WRAPPEDLABEL:
                    kblMessage.Visible = false;

                    klblMessage.Visible = false;

                    kwlMessage.Visible = true;
                    break;
                default:
                    kblMessage.Visible = false;

                    klblMessage.Visible = true;

                    kwlMessage.Visible = false;
                    break;
            }
        }

        // TODO: Resize other components, depending on pbxImage size
        private void SetCustomImageSize(InputBoxIconImageSize imageSize, Image customImage = null)
        {
            switch (imageSize)
            {
                case InputBoxIconImageSize.CUSTOM:
                    if (customImage != null)
                    {
                        pbxImage.Size = customImage.Size;
                    }
                    else
                    {
                        throw new ArgumentNullException();

                        pbxImage.Size = new Size(32, 32);
                    }
                    break;
                case InputBoxIconImageSize.THIRTYTWO:
                    pbxImage.Size = new Size(32, 32);
                    break;
                case InputBoxIconImageSize.FOURTYEIGHT:
                    pbxImage.Size = new Size(48, 48);
                    break;
                case InputBoxIconImageSize.SIXTYFOUR:
                    pbxImage.Size = new Size(64, 64);
                    break;
                case InputBoxIconImageSize.ONEHUNDREDANDTWENTYEIGHT:
                    pbxImage.Size = new Size(128, 128);
                    break;
                default:
                    pbxImage.Size = new Size(32, 32);
                    break;
            }
        }
        #endregion

        #region Show

        #region Internal Show
        private static string InternalShow(string message, string title = "", InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "")
        {
            using (KryptonInputBoxExtended ib = new KryptonInputBoxExtended(message, title, language, type, listItems, showInTaskBar, controlTypeface, messageTypeface, okText, yesText, noText, cancelText, hintText))
            {
                return ib.ShowDialog() == DialogResult.OK ? ib.GetUserResponse() : string.Empty;
            }
        }

        private static string InternalShow(string message, string title = "", InputBoxIconType icon = InputBoxIconType.INFORMATION, Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxButtons buttons = InputBoxButtons.OK, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation, InputBoxTextAlignment textAlignment = InputBoxTextAlignment.LEFT, Point iconLocation = new Point())
        {
            using (KryptonInputBoxExtended inputBoxExtended = new KryptonInputBoxExtended(iconLocation, message, title, icon, image, language, buttons, type, listItems, showInTaskBar, controlTypeface, messageTypeface, okText, yesText, noText, cancelText, hintText, startPosition, textAlignment))
            {
                inputBoxExtended.StartPosition = startPosition;

                return inputBoxExtended.ShowDialog() == DialogResult.OK ? inputBoxExtended.GetUserResponse() : string.Empty;
            }
        }

        private static string InternalShow(IWin32Window owner, string message, string title = "", InputBoxIconType icon = InputBoxIconType.INFORMATION, Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxButtons buttons = InputBoxButtons.OK, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation, InputBoxTextAlignment textAlignment = InputBoxTextAlignment.LEFT, Point iconLocation = new Point())
        {
            IWin32Window showOwner = owner ?? FromHandle(PlatformInvoke.GetActiveWindow());

            string result;

            using (KryptonInputBoxExtended inputBoxExtended = new KryptonInputBoxExtended(iconLocation, message, title, icon, image, language, buttons, type, listItems, showInTaskBar, controlTypeface, messageTypeface, okText, yesText, noText, cancelText, hintText, startPosition, textAlignment))
            {
                inputBoxExtended.StartPosition = startPosition;

                switch (type)
                {
                    case InputBoxInputType.COMBOBOX:
                        result = inputBoxExtended.ShowDialog(showOwner) == DialogResult.OK ? inputBoxExtended.GetUserChoice() : string.Empty;
                        break;
                    case InputBoxInputType.TEXTBOX:
                        result = inputBoxExtended.ShowDialog(showOwner) == DialogResult.OK ? inputBoxExtended.GetUserResponse() : string.Empty;
                        break;
                    case InputBoxInputType.MASKEDTEXTBOX:
                        result = inputBoxExtended.ShowDialog(showOwner) == DialogResult.OK ? inputBoxExtended.GetUserResponse() : string.Empty;
                        break;
                    case InputBoxInputType.NONE:
                        result = inputBoxExtended.ShowDialog(showOwner) == DialogResult.OK ? "" : string.Empty;
                        break;
                    default:
                        result = inputBoxExtended.ShowDialog(showOwner) == DialogResult.OK ? inputBoxExtended.GetUserResponse() : string.Empty;
                        result = inputBoxExtended.ShowDialog(showOwner) == DialogResult.OK ? inputBoxExtended.GetUserResponse() : string.Empty;
                        break;
                }

                return inputBoxExtended.ShowDialog(showOwner) == DialogResult.OK ? inputBoxExtended.GetUserResponse() : string.Empty;
            }
        }
        #endregion

        public static string Show(string message, string title = "", InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "") => InternalShow(message, title, language, type, listItems, showInTaskBar, controlTypeface, messageTypeface, okText, yesText, noText, cancelText, hintText);

        public static string Show(string message, string title = "", InputBoxIconType icon = InputBoxIconType.INFORMATION, Image image = null, InputBoxLanguage language = InputBoxLanguage.ENGLISH, InputBoxButtons buttons = InputBoxButtons.OK, InputBoxInputType type = InputBoxInputType.NONE, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation, InputBoxTextAlignment textAlignment = InputBoxTextAlignment.LEFT, Point iconLocation = new Point()) => InternalShow(message, title, icon, image, language, buttons, type, listItems, showInTaskBar, controlTypeface, messageTypeface, okText, yesText, noText, cancelText, hintText, startPosition, textAlignment, iconLocation);
        #endregion
    }
}