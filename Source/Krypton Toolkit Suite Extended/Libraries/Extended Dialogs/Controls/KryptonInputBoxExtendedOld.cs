using Krypton.Toolkit.Suite.Extended.Dialogs.Resources;
using Krypton.Toolkit.Suite.Extended.Language.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonInputBoxExtendedControl : UserControl
    {
        #region Designer Code
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnOk;
        private Krypton.Toolkit.KryptonButton kbtnCancel;
        private Krypton.Toolkit.KryptonButton kbtnAbort;
        private Krypton.Toolkit.KryptonButton kbtnYes;
        private Panel panel1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonTextBox ktxtUserResponse;
        private Krypton.Toolkit.KryptonComboBox kcmbUserChoice;
        private Krypton.Toolkit.KryptonLabel klblMessage;
        private PictureBox pbxIcon;
        private Krypton.Toolkit.KryptonButton kbtnNo;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnAbort = new Krypton.Toolkit.KryptonButton();
            this.kbtnYes = new Krypton.Toolkit.KryptonButton();
            this.kbtnNo = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.ktxtUserResponse = new Krypton.Toolkit.KryptonTextBox();
            this.kcmbUserChoice = new Krypton.Toolkit.KryptonComboBox();
            this.klblMessage = new Krypton.Toolkit.KryptonLabel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbUserChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnAbort);
            this.kryptonPanel1.Controls.Add(this.kbtnYes);
            this.kryptonPanel1.Controls.Add(this.kbtnNo);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 212);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(578, 51);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.Location = new System.Drawing.Point(380, 8);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 31);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 4;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.Location = new System.Drawing.Point(476, 8);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 31);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.TabIndex = 3;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kbtnAbort
            // 
            this.kbtnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnAbort.Location = new System.Drawing.Point(476, 8);
            this.kbtnAbort.Name = "kbtnAbort";
            this.kbtnAbort.Size = new System.Drawing.Size(90, 31);
            this.kbtnAbort.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnAbort.TabIndex = 2;
            this.kbtnAbort.Values.Text = "&Abort";
            this.kbtnAbort.Click += new System.EventHandler(this.kbtnAbort_Click);
            // 
            // kbtnYes
            // 
            this.kbtnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnYes.Location = new System.Drawing.Point(380, 8);
            this.kbtnYes.Name = "kbtnYes";
            this.kbtnYes.Size = new System.Drawing.Size(90, 31);
            this.kbtnYes.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnYes.TabIndex = 1;
            this.kbtnYes.Values.Text = "&Yes";
            this.kbtnYes.Click += new System.EventHandler(this.kbtnYes_Click);
            // 
            // kbtnNo
            // 
            this.kbtnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnNo.Location = new System.Drawing.Point(476, 8);
            this.kbtnNo.Name = "kbtnNo";
            this.kbtnNo.Size = new System.Drawing.Size(90, 31);
            this.kbtnNo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnNo.TabIndex = 0;
            this.kbtnNo.Values.Text = "&No";
            this.kbtnNo.Click += new System.EventHandler(this.kbtnNo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 3);
            this.panel1.TabIndex = 9;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtUserResponse);
            this.kryptonPanel2.Controls.Add(this.kcmbUserChoice);
            this.kryptonPanel2.Controls.Add(this.klblMessage);
            this.kryptonPanel2.Controls.Add(this.pbxIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(578, 209);
            this.kryptonPanel2.TabIndex = 10;
            // 
            // ktxtUserResponse
            // 
            this.ktxtUserResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktxtUserResponse.Location = new System.Drawing.Point(180, 150);
            this.ktxtUserResponse.Name = "ktxtUserResponse";
            this.ktxtUserResponse.Size = new System.Drawing.Size(269, 25);
            this.ktxtUserResponse.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtUserResponse.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtUserResponse.TabIndex = 12;
            this.ktxtUserResponse.ToolTipValues.Description = "Type your response here...";
            this.ktxtUserResponse.ToolTipValues.EnableToolTips = true;
            this.ktxtUserResponse.ToolTipValues.Heading = "User Response";
            // 
            // kcmbUserChoice
            // 
            this.kcmbUserChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kcmbUserChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbUserChoice.DropDownWidth = 269;
            this.kcmbUserChoice.IntegralHeight = false;
            this.kcmbUserChoice.Location = new System.Drawing.Point(180, 150);
            this.kcmbUserChoice.Name = "kcmbUserChoice";
            this.kcmbUserChoice.Size = new System.Drawing.Size(269, 23);
            this.kcmbUserChoice.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbUserChoice.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbUserChoice.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbUserChoice.TabIndex = 11;
            // 
            // klblMessage
            // 
            this.klblMessage.AutoSize = false;
            this.klblMessage.Location = new System.Drawing.Point(82, 12);
            this.klblMessage.Name = "klblMessage";
            this.klblMessage.Size = new System.Drawing.Size(482, 132);
            this.klblMessage.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMessage.TabIndex = 10;
            this.klblMessage.Values.Text = "{0}";
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxIcon.TabIndex = 4;
            this.pbxIcon.TabStop = false;
            // 
            // KryptonInputBoxExtended
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonInputBoxExtended";
            this.Size = new System.Drawing.Size(578, 263);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbUserChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private static DialogResult _userResponse;

        private static string[] _buttonTextArray = new string[4];

        private Image[] _inputBoxDefaultImages = new Image[8];

        private Image _customIcon;

        private InputBoxIconImageSize _iconImageSize;

        private InputBoxIcon _icon;

        private Language _language;

        private InputBoxButtons _buttons;

        private InputBoxType _type;

        private string[] _itemList;

        private Font _controlTypeface, _messageTypeface;

        private string _abortText, _okText, _yesText, _noText, _cancelText, _hintText, _messageText;

        private InputBoxMessageTextAlignment _messageTextAlignment;

        private PaletteRelativeAlign _userInputTextAlignment;

        private PaletteRelativeAlign _userSelectionTextAlignment;

        private InputBoxMessageRightToLeft _rightToLeft;

        private Size _contentPanelSize, _buttonPanelSize, _buttonSize;

        private Point _buttonOneLocation, _buttonTwoLocation, _buttonThreeLocation;

        private KryptonForm _owner;
        #endregion

        #region Properties
        /// <summary>Gets or sets the user response.</summary>
        /// <value>The user response.</value>
        public static DialogResult UserResponse { get => _userResponse; set => _userResponse = value; }

        /// <summary>Gets the input box default images.</summary>
        /// <value>The input box default images.</value>
        public Image[] InputBoxDefaultImages { get => _inputBoxDefaultImages; private set { _inputBoxDefaultImages = value; Invalidate(); } }

        public Image CustomIcon { get => _customIcon; set { _customIcon = value; Invalidate(); } }

        public InputBoxButtons InputBoxButtons { get => _buttons; set { _buttons = value; Invalidate(); } }

        public InputBoxIcon InputBoxIcon { get => _icon; set { _icon = value; Invalidate(); } }

        public InputBoxIconImageSize InputBoxIconImageSize { get => _iconImageSize; set { _iconImageSize = value; Invalidate(); } }

        public InputBoxMessageRightToLeft InputBoxMessageRightToLeft { get => _rightToLeft; set { _rightToLeft = value; Invalidate(); } }

        public InputBoxMessageTextAlignment MessageTextAlignment { get => _messageTextAlignment; set { _messageTextAlignment = value; Invalidate(); } }

        public InputBoxType InputBoxType { get => _type; set { _type = value; Invalidate(); } }

        public PaletteRelativeAlign UserInputTextAlignment { get => _userInputTextAlignment; set { _userInputTextAlignment = value; Invalidate(); } }

        public PaletteRelativeAlign UserSelectionTextAlignment { get => _userSelectionTextAlignment; set { _userSelectionTextAlignment = value; Invalidate(); } }

        public Language Language { get => _language; set { _language = value; Invalidate(); } }

        public string[] ItemList { get => _itemList; set { _itemList = value; Invalidate(); } }

        public Font ControlTypeface { get => _controlTypeface; set { _controlTypeface = value; Invalidate(); } }

        public Font MessageTypeface { get => _messageTypeface; set { _messageTypeface = value; Invalidate(); } }

        public string AbortText { get => _abortText; set { _abortText = value; Invalidate(); } }

        public string CancelText { get => _cancelText; set { _cancelText = value; Invalidate(); } }

        public string OkText { get => _okText; set { _okText = value; Invalidate(); } }

        public string YesText { get => _yesText; set { _yesText = value; Invalidate(); } }

        public string NoText { get => _noText; set { _noText = value; Invalidate(); } }

        public string HintText { get => _hintText; set { _hintText = value; Invalidate(); } }

        public string MessageText { get => _messageText; set { _messageText = value; Invalidate(); } }

        public Size ContentPanelSize { get => _contentPanelSize; set { _contentPanelSize = value; Invalidate(); } }

        public Size ButtonPanelSize { get => _buttonPanelSize; set { _buttonPanelSize = value; Invalidate(); } }

        public Size ButtonSize { get => _buttonSize; set { _buttonSize = value; Invalidate(); } }

        public Point ButtonOneLocation { get => _buttonOneLocation; set { _buttonOneLocation = value; Invalidate(); } }

        public Point ButtonTwoLocation { get => _buttonTwoLocation; set { _buttonTwoLocation = value; Invalidate(); } }

        public Point ButtonThreeLocation { get => _buttonThreeLocation; set { _buttonThreeLocation = value; Invalidate(); } }

        //public KryptonForm Owner { get => _owner; set => _owner = value; }
        #endregion

        #region Constructors
        public KryptonInputBoxExtendedControl()
        {
            InitializeComponent();

            Language = Language.ENGLISH;
        }
        #endregion

        #region Setters/Getters
        /// <summary>
        /// Sets the UserResponse.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetUserDialogResponse(DialogResult value) => UserResponse = value;

        /// <summary>
        /// Gets the UserResponse.
        /// </summary>
        /// <returns>The value of UserResponse.</returns>
        public DialogResult GetUserDialogResponse() => UserResponse;

        /// <summary>
        /// Sets the InputBoxDefaultImages.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetInputBoxDefaultImages(Image[] value) => InputBoxDefaultImages = value;

        /// <summary>
        /// Gets the InputBoxDefaultImages.
        /// </summary>
        /// <returns>The value of InputBoxDefaultImages.</returns>
        public Image[] GetInputBoxDefaultImages() => InputBoxDefaultImages;
        #endregion

        private void kbtnAbort_Click(object sender, EventArgs e) => SetUserDialogParentResponse(DialogResult.Abort);

        private void kbtnCancel_Click(object sender, EventArgs e) => SetUserDialogParentResponse(DialogResult.Cancel);

        private void kbtnOk_Click(object sender, EventArgs e) => SetUserDialogParentResponse(DialogResult.OK);

        private void kbtnYes_Click(object sender, EventArgs e) => SetUserDialogParentResponse(DialogResult.Yes);

        private void kbtnNo_Click(object sender, EventArgs e) => SetUserDialogParentResponse(DialogResult.No);

        #region Methods
        private void SetUserDialogParentResponse(DialogResult result) => ((KryptonForm)TopLevelControl).DialogResult = result;

        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void SetMessage(string message) => klblMessage.Text = message;

        /// <summary>Sets the message typeface.</summary>
        /// <param name="typeface">The typeface.</param>
        private void SetMessageTypeface(Font typeface) => klblMessage.StateCommon.ShortText.Font = typeface;

        /// <summary>
        /// Sets the hint.
        /// </summary>
        /// <param name="hintText">The hint text.</param>
        private void SetHint(string hintText) => ktxtUserResponse.Hint = hintText;

        /// <summary>Sets the control typeface.</summary>
        /// <param name="typeface">The typeface.</param>
        private void SetControlTypeface(Font typeface)
        {
            kbtnCancel.StateCommon.Content.ShortText.Font = typeface;

            kbtnNo.StateCommon.Content.ShortText.Font = typeface;

            kbtnOk.StateCommon.Content.ShortText.Font = typeface;

            kbtnYes.StateCommon.Content.ShortText.Font = typeface;
        }

        /// <summary>Sets the language.</summary>
        /// <param name="language">The language.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        private void SetLanguage(Language language, string okText = "", string yesText = "", string noText = "", string cancelText = "", string abortText = "")
        {
            switch (language)
            {
                case Language.CZECH:
                    _buttonTextArray = "OK,Ano,Ne,Storno".Split(',');
                    break;
                case Language.FRANÇAIS:
                    _buttonTextArray = "OK,Oui,Non,Annuler".Split(',');
                    break;
                case Language.DEUTSCH:
                    _buttonTextArray = "OK,Ja,Nein,Abbrechen".Split(',');
                    break;
                case Language.SLOVAKIAN:
                    _buttonTextArray = "OK,Áno,Nie,Zrušiť".Split(',');
                    break;
                case Language.ESPAÑOL:
                    _buttonTextArray = "OK,Sí,No,Cancelar".Split(',');
                    break;
                case Language.CUSTOM:
                    _buttonTextArray = SetCustomText(okText, yesText, noText, cancelText, abortText);
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
        private static string[] SetCustomText(string okText, string yesText, string noText, string cancelText, string abortText)
        {
            string[] tempArray = new string[4];

            tempArray = $"{ okText },{ yesText },{ noText },{ cancelText },{ abortText }".Split(',');

            return tempArray;
        }

        /// <summary>Sets the icon.</summary>
        /// <param name="icon">The icon.</param>
        /// <param name="customImage">The custom image.</param>
        private void SetIcon(InputBoxIcon icon, Image customImage = null)
        {
            if (GetInputBoxDefaultImages().Length > 0)
            {
                switch (icon)
                {
                    case InputBoxIcon.CUSTOM:
                        NormalIconLayout();

                        if (customImage != null)
                        {
                            pbxIcon.Image = customImage;
                        }
                        break;
                    case InputBoxIcon.OK:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxDefaultImages[3];
                        break;
                    case InputBoxIcon.ERROR:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxDefaultImages[0];
                        break;
                    case InputBoxIcon.EXCLAMATION:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxDefaultImages[6];
                        break;
                    case InputBoxIcon.INFORMATION:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxDefaultImages[2];
                        break;
                    case InputBoxIcon.QUESTION:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxDefaultImages[4];
                        break;
                    case InputBoxIcon.NONE:
                        SetNoIconLayout();
                        break;
                    case InputBoxIcon.STOP:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxDefaultImages[5];
                        break;
                    case InputBoxIcon.HAND:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxDefaultImages[1];
                        break;
                }
            }
            else
            {
                switch (icon)
                {
                    case InputBoxIcon.CUSTOM:
                        NormalIconLayout();

                        if (customImage != null)
                        {
                            pbxIcon.Image = customImage;
                        }
                        break;
                    case InputBoxIcon.OK:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxResources.Input_Box_Ok_64_x_64;
                        break;
                    case InputBoxIcon.ERROR:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxResources.Input_Box_Critical_64_x_64;
                        break;
                    case InputBoxIcon.EXCLAMATION:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxResources.Input_Box_Warning_64_x_58;
                        break;
                    case InputBoxIcon.INFORMATION:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxResources.Input_Box_Information_64_x_64;
                        break;
                    case InputBoxIcon.QUESTION:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxResources.Input_Box_Question_64_x_64;
                        break;
                    case InputBoxIcon.NONE:
                        SetNoIconLayout();
                        break;
                    case InputBoxIcon.STOP:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxResources.Input_Box_Stop_64_x_64;
                        break;
                    case InputBoxIcon.HAND:
                        NormalIconLayout();

                        pbxIcon.Image = InputBoxResources.Input_Box_Hand_64_x_64;
                        break;
                }
            }
        }

        /// <summary>Sets the no icon layout.</summary>
        private void SetNoIconLayout()
        {
            pbxIcon.Visible = false;

            klblMessage.Size = new Size(552, 132);

            ktxtUserResponse.Location = new Point(146, 150);

            kcmbUserChoice.Location = new Point(146, 150);
        }

        /// <summary>Normals the icon layout.</summary>
        private void NormalIconLayout()
        {
            pbxIcon.Visible = true;

            klblMessage.Size = new Size(482, 132);

            ktxtUserResponse.Location = new Point(180, 150);

            kcmbUserChoice.Location = new Point(180, 150);
        }

        /// <summary>Gets the height of the image.</summary>
        /// <param name="image">The image.</param>
        /// <returns></returns>
        private int GetImageHeight(Image image) => image.Height;

        /// <summary>Gets the width of the image.</summary>
        /// <param name="image">The image.</param>
        /// <returns></returns>
        private int GetImageWidth(Image image) => image.Width;

        /// <summary>
        /// Adapts the buttons.
        /// </summary>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        private KryptonButton[] AdaptButtons(InputBoxButtons buttons)
        {
            KryptonButton[] buttonArray = new KryptonButton[3];

            #region Set Button Text
            kbtnOk.Text = _buttonTextArray[0];

            kbtnYes.Text = _buttonTextArray[1];

            kbtnNo.Text = _buttonTextArray[2];

            kbtnCancel.Text = _buttonTextArray[3];
            #endregion

            switch (buttons)
            {
                case InputBoxButtons.OK:
                    kbtnOk.Location = new Point(474, 8);

                    buttonArray[0] = kbtnOk;
                    break;
                case InputBoxButtons.OKCANCEL:
                    kbtnOk.Location = new Point(378, 8);

                    buttonArray[0] = kbtnOk;

                    kbtnCancel.Location = new Point(474, 8);

                    buttonArray[1] = kbtnCancel;
                    break;
                case InputBoxButtons.YESNO:
                    kbtnYes.Location = new Point(378, 8);

                    buttonArray[0] = kbtnYes;

                    kbtnNo.Location = new Point(474, 8);

                    buttonArray[1] = kbtnNo;
                    break;
                case InputBoxButtons.YESNOCANCEL:
                    kbtnYes.Location = new Point(282, 8);

                    buttonArray[0] = kbtnYes;

                    kbtnNo.Location = new Point(378, 8);

                    buttonArray[1] = kbtnNo;

                    kbtnCancel.Location = new Point(474, 8);

                    buttonArray[2] = kbtnCancel;
                    break;
            }

            foreach (KryptonButton button in buttonArray)
            {
                if (button != null)
                {
                    button.Size = new Size(90, 31);

                    //button.Click += Button_Click;
                }
            }

            return buttonArray;
        }

        /// <summary>Adapts the UI.</summary>
        /// <param name="type">The type.</param>
        /// <param name="items">The items.</param>
        private void AdaptUI(InputBoxType type, string[] items)
        {
            if (items != null)
            {
                foreach (string item in items)
                {
                    kcmbUserChoice.Items.Add(item);
                }

                kcmbUserChoice.SelectedIndex = 0;
            }

            switch (type)
            {
                case InputBoxType.COMBOBOX:
                    ktxtUserResponse.Visible = false;

                    kcmbUserChoice.Visible = true;
                    break;
                case InputBoxType.TEXTBOX:
                    ktxtUserResponse.Visible = true;

                    kcmbUserChoice.Visible = false;
                    break;
            }
        }

        /// <summary>Changes the button visibility.</summary>
        /// <param name="buttons">The buttons.</param>
        private void ChangeButtonVisibility(InputBoxButtons buttons)
        {
            switch (buttons)
            {
                case InputBoxButtons.OK:
                    break;
                case InputBoxButtons.OKCANCEL:
                    break;
                case InputBoxButtons.YESNO:
                    break;
                case InputBoxButtons.YESNOCANCEL:
                    break;
                default:
                    break;
            }
        }

        /// <summary>Changes the input box message text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void ChangeInputBoxMessageTextAlignment(InputBoxMessageTextAlignment alignment)
        {
            switch (alignment)
            {
                case InputBoxMessageTextAlignment.LEFT:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case InputBoxMessageTextAlignment.CENTRE:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case InputBoxMessageTextAlignment.RIGHT:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case InputBoxMessageTextAlignment.INHERIT:
                    klblMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    klblMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
            }
        }

        /// <summary>Changes the input box user input text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void ChangeInputBoxUserInputTextAlignment(PaletteRelativeAlign alignment) => ktxtUserResponse.StateCommon.Content.TextH = alignment;

        /// <summary>Changes the input box user selection text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void ChangeInputBoxUserSelectionTextAlignment(PaletteRelativeAlign alignment) => kcmbUserChoice.StateCommon.ComboBox.Content.TextH = alignment;

        /// <summary>Relocates the buttons.</summary>
        /// <param name="buttons">The buttons.</param>
        /// <param name="buttonOneLocation">The first button location.</param>
        /// <param name="buttonTwoLocation">The second button location.</param>
        /// <param name="buttonThreeLocation">The third button location.</param>
        private void RelocateButtons(InputBoxButtons buttons, Point buttonOneLocation, Point buttonTwoLocation, Point buttonThreeLocation)
        {
            switch (buttons)
            {
                case InputBoxButtons.OK:
                    kbtnOk.Location = buttonThreeLocation;
                    break;
                case InputBoxButtons.OKCANCEL:
                    kbtnOk.Location = buttonTwoLocation;

                    kbtnCancel.Location = buttonThreeLocation;
                    break;
                case InputBoxButtons.YESNO:
                    kbtnYes.Location = buttonTwoLocation;

                    kbtnNo.Location = buttonThreeLocation;
                    break;
                case InputBoxButtons.YESNOCANCEL:
                    kbtnYes.Location = buttonOneLocation;

                    kbtnNo.Location = buttonTwoLocation;

                    kbtnCancel.Location = buttonThreeLocation;
                    break;
            }
        }

        /// <summary>Relocates the buttons.</summary>
        /// <param name="buttonOne">The first one.</param>
        /// <param name="buttonTwo">The second two.</param>
        /// <param name="buttonThree">The third three.</param>
        /// <param name="buttonOneLocation">The first button location.</param>
        /// <param name="buttonTwoLocation">The second button location.</param>
        /// <param name="buttonThreeLocation">The third button location.</param>
        private void RelocateButtons(KryptonButton buttonOne, KryptonButton buttonTwo, KryptonButton buttonThree, Point buttonOneLocation, Point buttonTwoLocation, Point buttonThreeLocation)
        {
            buttonOne.Location = buttonOneLocation;

            buttonTwo.Location = buttonTwoLocation;

            buttonThree.Location = buttonThreeLocation;
        }

        /// <summary>Changes the input box message right to left layout.</summary>
        /// <param name="rightToLeft">The right to left.</param>
        private void ChangeInputBoxMessageRightToLeftLayout(InputBoxMessageRightToLeft rightToLeft)
        {
            SwapLayout(rightToLeft);

            switch (rightToLeft)
            {
                case InputBoxMessageRightToLeft.NO:
                    klblMessage.RightToLeft = RightToLeft.No;

                    ktxtUserResponse.RightToLeft = RightToLeft.No;

                    kcmbUserChoice.RightToLeft = RightToLeft.No;

                    kbtnAbort.RightToLeft = RightToLeft.No;

                    kbtnCancel.RightToLeft = RightToLeft.No;

                    kbtnNo.RightToLeft = RightToLeft.No;

                    kbtnOk.RightToLeft = RightToLeft.No;

                    kbtnYes.RightToLeft = RightToLeft.No;
                    break;
                case InputBoxMessageRightToLeft.YES:
                    klblMessage.RightToLeft = RightToLeft.Yes;

                    ktxtUserResponse.RightToLeft = RightToLeft.Yes;

                    kcmbUserChoice.RightToLeft = RightToLeft.Yes;

                    kbtnAbort.RightToLeft = RightToLeft.Yes;

                    kbtnCancel.RightToLeft = RightToLeft.Yes;

                    kbtnNo.RightToLeft = RightToLeft.Yes;

                    kbtnOk.RightToLeft = RightToLeft.Yes;

                    kbtnYes.RightToLeft = RightToLeft.Yes;
                    break;
                case InputBoxMessageRightToLeft.INHERIT:
                    klblMessage.RightToLeft = RightToLeft.Inherit;

                    ktxtUserResponse.RightToLeft = RightToLeft.Inherit;

                    kcmbUserChoice.RightToLeft = RightToLeft.Inherit;

                    kbtnAbort.RightToLeft = RightToLeft.Inherit;

                    kbtnCancel.RightToLeft = RightToLeft.Inherit;

                    kbtnNo.RightToLeft = RightToLeft.Inherit;

                    kbtnOk.RightToLeft = RightToLeft.Inherit;

                    kbtnYes.RightToLeft = RightToLeft.Inherit;
                    break;
            }
        }

        /// <summary>Swaps the layout.</summary>
        /// <param name="rightToLeft">The right to left.</param>
        private void SwapLayout(InputBoxMessageRightToLeft rightToLeft)
        {
            switch (rightToLeft)
            {
                case InputBoxMessageRightToLeft.NO:
                    RelocateControls(new Point(12, 12), new Point(82, 12), new Point(180, 150), new Point(180, 150), new Point(474, 8), new Point(474, 8), new Point(378, 8), new Point(378, 8), new Point(474, 8));
                    break;
                case InputBoxMessageRightToLeft.YES:
                    RelocateControls(new Point(500, 12), new Point(12, 12), new Point(126, 150), new Point(126, 150), new Point(12, 8), new Point(12, 8), new Point(108, 8), new Point(108, 8), new Point(108, 8));
                    break;
                case InputBoxMessageRightToLeft.INHERIT:
                    break;
            }
        }

        /// <summary>Relocates the controls.</summary>
        /// <param name="pictureBoxLocation">The picture box location.</param>
        /// <param name="messageLabelLocation">The message label location.</param>
        /// <param name="userInputLocation">The user input location.</param>
        /// <param name="userSelectionBoxLocation">The user selection box location.</param>
        /// <param name="abortButtonLocation">The abort button location.</param>
        /// <param name="cancelButtonLocation">The cancel button location.</param>
        /// <param name="okButtonLocation">The ok button location.</param>
        /// <param name="yesButtonLocation">The yes button location.</param>
        /// <param name="noButtonLocation">The no button location.</param>
        private void RelocateControls(Point pictureBoxLocation, Point messageLabelLocation, Point userInputLocation, Point userSelectionBoxLocation, Point abortButtonLocation, Point cancelButtonLocation, Point okButtonLocation, Point yesButtonLocation, Point noButtonLocation)
        {
            pbxIcon.Location = pictureBoxLocation;

            klblMessage.Location = messageLabelLocation;

            ktxtUserResponse.Location = userInputLocation;

            kcmbUserChoice.Location = userSelectionBoxLocation;

            kbtnAbort.Location = abortButtonLocation;

            kbtnCancel.Location = cancelButtonLocation;

            kbtnNo.Location = noButtonLocation;

            kbtnOk.Location = okButtonLocation;

            kbtnYes.Location = yesButtonLocation;
        }

        /// <summary>Gets the user response.</summary>
        /// <returns></returns>
        public string GetUserResponse() => ktxtUserResponse.Text;

        /// <summary>Gets the user selection.</summary>
        /// <returns></returns>
        public string GetUserSelection() => kcmbUserChoice.Text;

        /// <summary>Populates the image array.</summary>
        /// <param name="images">The images.</param>
        /// <returns></returns>
        private Image[] PopulateImageArray(Image[] images)
        {
            images[0] = InputBoxResources.Input_Box_Critical_64_x_64;

            images[1] = InputBoxResources.Input_Box_Hand_64_x_64;

            images[2] = InputBoxResources.Input_Box_Information_64_x_64;

            images[3] = InputBoxResources.Input_Box_Ok_64_x_64;

            images[4] = InputBoxResources.Input_Box_Question_64_x_64;

            images[5] = InputBoxResources.Input_Box_Stop_64_x_64;

            images[6] = InputBoxResources.Input_Box_Warning_64_x_58;

            return images;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            SetMessage(MessageText);

            SetMessageTypeface(MessageTypeface);

            SetHint(HintText);

            SetControlTypeface(ControlTypeface);

            SetLanguage(Language, OkText, YesText, NoText, CancelText, AbortText);

            if (CustomIcon != null)
            {
                InputBoxIcon = InputBoxIcon.CUSTOM;

                SetIcon(InputBoxIcon, CustomIcon);
            }
            else
            {
                SetIcon(InputBoxIcon);
            }

            AdaptButtons(InputBoxButtons);

            AdaptUI(InputBoxType, ItemList);

            ChangeInputBoxMessageRightToLeftLayout(InputBoxMessageRightToLeft);

            ChangeInputBoxMessageTextAlignment(MessageTextAlignment);

            ChangeInputBoxUserInputTextAlignment(UserInputTextAlignment);

            PopulateImageArray(InputBoxDefaultImages);

            base.OnPaint(e);
        }
        #endregion
    }
}