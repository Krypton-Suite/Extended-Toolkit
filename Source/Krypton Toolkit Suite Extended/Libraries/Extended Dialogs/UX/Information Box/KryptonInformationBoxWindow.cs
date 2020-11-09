using System;
using System.Drawing;
using System.Globalization;
using System.Media;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>Displays a message box that can contain text, buttons, and symbols that inform and instruct the user.</summary>
    internal class KryptonInformationBoxWindow : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kpnlMain;
        private System.Windows.Forms.Timer tmrAutoClose;
        private System.ComponentModel.IContainer components;
        private KryptonPanel kpnlContent;
        private KryptonPanel kpnlBase;
        private KryptonCheckBox kcbDoNotShow;
        private KryptonPanel kryptonPanel3;
        private KryptonPanel kpnlIcon;
        private System.Windows.Forms.PictureBox pbxIcon;
        private KryptonPanel kpnlText;
        private KryptonWrapLabel kwlMessageText;
        private KryptonPanel kpnlButtons;
        private KryptonPanel kpnlScrollText;
        private KryptonLabel klblTitle;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kpnlMain = new Krypton.Toolkit.KryptonPanel();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.kpnlText = new Krypton.Toolkit.KryptonPanel();
            this.kpnlScrollText = new Krypton.Toolkit.KryptonPanel();
            this.kwlMessageText = new Krypton.Toolkit.KryptonWrapLabel();
            this.kpnlIcon = new Krypton.Toolkit.KryptonPanel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.kpnlBase = new Krypton.Toolkit.KryptonPanel();
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel3 = new Krypton.Toolkit.KryptonPanel();
            this.kcbDoNotShow = new Krypton.Toolkit.KryptonCheckBox();
            this.klblTitle = new Krypton.Toolkit.KryptonLabel();
            this.tmrAutoClose = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).BeginInit();
            this.kpnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlText)).BeginInit();
            this.kpnlText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlScrollText)).BeginInit();
            this.kpnlScrollText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlIcon)).BeginInit();
            this.kpnlIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBase)).BeginInit();
            this.kpnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlMain
            // 
            this.kpnlMain.Controls.Add(this.kpnlContent);
            this.kpnlMain.Controls.Add(this.kpnlBase);
            this.kpnlMain.Controls.Add(this.klblTitle);
            this.kpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlMain.Location = new System.Drawing.Point(0, 0);
            this.kpnlMain.Name = "kpnlMain";
            this.kpnlMain.Size = new System.Drawing.Size(351, 198);
            this.kpnlMain.TabIndex = 0;
            // 
            // kpnlContent
            // 
            this.kpnlContent.Controls.Add(this.kpnlText);
            this.kpnlContent.Controls.Add(this.kpnlIcon);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(0, 31);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(351, 105);
            this.kpnlContent.TabIndex = 2;
            // 
            // kpnlText
            // 
            this.kpnlText.Controls.Add(this.kpnlScrollText);
            this.kpnlText.Dock = System.Windows.Forms.DockStyle.Right;
            this.kpnlText.Location = new System.Drawing.Point(81, 0);
            this.kpnlText.Name = "kpnlText";
            this.kpnlText.Size = new System.Drawing.Size(270, 105);
            this.kpnlText.TabIndex = 1;
            // 
            // kpnlScrollText
            // 
            this.kpnlScrollText.AutoScroll = true;
            this.kpnlScrollText.Controls.Add(this.kwlMessageText);
            this.kpnlScrollText.Dock = System.Windows.Forms.DockStyle.Right;
            this.kpnlScrollText.Location = new System.Drawing.Point(3, 0);
            this.kpnlScrollText.Name = "kpnlScrollText";
            this.kpnlScrollText.Size = new System.Drawing.Size(267, 105);
            this.kpnlScrollText.TabIndex = 1;
            // 
            // kwlMessageText
            // 
            this.kwlMessageText.AutoSize = false;
            this.kwlMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlMessageText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlMessageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlMessageText.Location = new System.Drawing.Point(0, 0);
            this.kwlMessageText.Name = "kwlMessageText";
            this.kwlMessageText.Size = new System.Drawing.Size(267, 105);
            this.kwlMessageText.Text = "kryptonWrapLabel1";
            this.kwlMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpnlIcon
            // 
            this.kpnlIcon.Controls.Add(this.pbxIcon);
            this.kpnlIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.kpnlIcon.Location = new System.Drawing.Point(0, 0);
            this.kpnlIcon.Name = "kpnlIcon";
            this.kpnlIcon.Size = new System.Drawing.Size(75, 105);
            this.kpnlIcon.TabIndex = 0;
            // 
            // pbxIcon
            // 
            this.pbxIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Location = new System.Drawing.Point(12, 26);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(48, 48);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxIcon.TabIndex = 0;
            this.pbxIcon.TabStop = false;
            // 
            // kpnlBase
            // 
            this.kpnlBase.Controls.Add(this.kpnlButtons);
            this.kpnlBase.Controls.Add(this.kryptonPanel3);
            this.kpnlBase.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlBase.Location = new System.Drawing.Point(0, 136);
            this.kpnlBase.Name = "kpnlBase";
            this.kpnlBase.Size = new System.Drawing.Size(351, 62);
            this.kpnlBase.TabIndex = 1;
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 20);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(351, 42);
            this.kpnlButtons.TabIndex = 1;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.kcbDoNotShow);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(351, 20);
            this.kryptonPanel3.TabIndex = 0;
            // 
            // kcbDoNotShow
            // 
            this.kcbDoNotShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcbDoNotShow.Location = new System.Drawing.Point(0, 0);
            this.kcbDoNotShow.Name = "kcbDoNotShow";
            this.kcbDoNotShow.Size = new System.Drawing.Size(351, 20);
            this.kcbDoNotShow.TabIndex = 1;
            this.kcbDoNotShow.Values.Text = "&Do not show";
            // 
            // klblTitle
            // 
            this.klblTitle.AutoSize = false;
            this.klblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.klblTitle.Location = new System.Drawing.Point(0, 0);
            this.klblTitle.Name = "klblTitle";
            this.klblTitle.Size = new System.Drawing.Size(351, 31);
            this.klblTitle.TabIndex = 0;
            this.klblTitle.Values.Text = "kryptonLabel1";
            // 
            // KryptonInformationBoxWindow
            // 
            this.ClientSize = new System.Drawing.Size(351, 198);
            this.Controls.Add(this.kpnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonInformationBoxWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).EndInit();
            this.kpnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlText)).EndInit();
            this.kpnlText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlScrollText)).EndInit();
            this.kpnlScrollText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlIcon)).EndInit();
            this.kpnlIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBase)).EndInit();
            this.kpnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.kryptonPanel3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constants
        /// <summary>The icon panel width</summary>
        private const int ICON_PANEL_WIDTH = 68;

        /// <summary>The border padding</summary>
        private const int BORDER_PADDING = 10;
        #endregion

        #region Attributes

        /// <summary>
        /// Contains the callback used to inform the caller of a modeless box
        /// </summary>
        private readonly AsyncResultCallback callback;

        /// <summary>
        /// Text for the first user button
        /// </summary>
        private readonly string buttonUser1Text = "User1";

        /// <summary>
        /// Text for the second user button
        /// </summary>
        private readonly string buttonUser2Text = "User2";

        /// <summary>
        /// Text for the third user button
        /// </summary>
        private readonly string buttonUser3Text = "User3";

        /// <summary>
        /// Help file associated to the help button
        /// </summary>
        private readonly string helpFile;

        /// <summary>
        /// Help topic associated to the help button
        /// </summary>
        private readonly string helpTopic;

        /// <summary>
        /// Contains the graphics used to measure the strings
        /// </summary>
        private readonly Graphics measureGraphics;

        /// <summary>
        /// Contains a reference to the active form
        /// </summary>
        private readonly Form activeForm;

        /// <summary>
        /// Result corresponding the clicked button
        /// </summary>
        private InformationBoxResult result = InformationBoxResult.None;

        /// <summary>
        /// Main icon of the form
        /// </summary>
        private InformationBoxIcon icon;

        /// <summary>
        /// Custom icon
        /// </summary>
        private Icon customIcon;

        /// <summary>
        /// Buttons displayed on the form
        /// </summary>
        private InformationBoxButtons buttons;

        /// <summary>
        /// Default button
        /// </summary>
        private InformationBoxDefaultButton defaultButton;

        /// <summary>
        /// Buttons layout
        /// </summary>
        private InformationBoxButtonsLayout buttonsLayout = InformationBoxButtonsLayout.GroupMiddle;

        /// <summary>
        /// Contains the autosize mode
        /// </summary>
        private InformationBoxAutoSizeMode autoSizeMode = InformationBoxAutoSizeMode.None;

        /// <summary>
        /// Contains the box initial position
        /// </summary>
        private InformationBoxPosition position = InformationBoxPosition.CenterOnParent;

        /// <summary>
        /// Contains a value defining whether displaying the checkbox or not
        /// </summary>
        private InformationBoxCheckBox checkBox = 0;

        /// <summary>
        /// Contains the style of the box
        /// </summary>
        private InformationBoxStyle style = InformationBoxStyle.Standard;

        /// <summary>
        /// Contains the autoclose parameters
        /// </summary>
        private AutoCloseParameters autoClose;

        /// <summary>
        /// Contains the design parameters
        /// </summary>
        private DesignParameters design;

        /// <summary>
        /// Contains the style of the title
        /// </summary>
        private InformationBoxTitleIconStyle titleStyle = InformationBoxTitleIconStyle.None;

        /// <summary>
        /// Contains the title icon
        /// </summary>
        private Icon titleIcon;

        /// <summary>
        /// Contains if the box is modal or not
        /// </summary>
        private InformationBoxBehavior behavior = InformationBoxBehavior.Modal;

        /// <summary>
        /// Contains the opacity of the form
        /// </summary>
        private InformationBoxOpacity opacity = InformationBoxOpacity.NoFade;

        /// <summary>
        /// Contains the icon type
        /// </summary>
        private InformationBoxIconType iconType = InformationBoxIconType.Internal;

        /// <summary>
        /// Contains the text
        /// </summary>
        private StringBuilder internalText;

        /// <summary>
        /// Contains if the help button should be displayed
        /// </summary>
        private bool showHelpButton;

        /// <summary>
        /// Help navigator associated to the help button
        /// </summary>
        private HelpNavigator helpNavigator = HelpNavigator.TableOfContents;

        /// <summary>
        /// Contains whether a mouse button is down
        /// </summary>
        private bool mouseDown;

        /// <summary>
        /// Last stored pointer position
        /// </summary>
        private Point lastPointerPosition;

        /// <summary>
        /// Elapsed time for the autoclose
        /// </summary>
        private int elapsedTime;

        /// <summary>
        /// Z-Order of the form
        /// </summary>
        private InformationBoxOrder order = InformationBoxOrder.Default;

        /// <summary>
        /// Sound to play on opening
        /// </summary>
        private InformationBoxSound sound;

        #endregion Attributes

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonInformationBoxWindow"/> class using the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <param name="helpFile">The help file.</param>
        /// <param name="helpTopic">The help topic.</param>
        /// <param name="initialization">The initialization.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="customIcon">The custom icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="customButtons">The custom buttons.</param>
        /// <param name="buttonsLayout">The buttons layout.</param>
        /// <param name="autoSizeMode">The auto size mode.</param>
        /// <param name="position">The position.</param>
        /// <param name="showHelpButton">if set to <c>true</c> shows help button.</param>
        /// <param name="helpNavigator">The help navigator.</param>
        /// <param name="showDoNotShowAgainCheckBox">if set to <c>true</c> shows the do not show again check box.</param>
        /// <param name="style">The style.</param>
        /// <param name="autoClose">The auto close configuration.</param>
        /// <param name="design">The design.</param>
        /// <param name="titleStyle">The title style.</param>
        /// <param name="titleIcon">The title icon.</param>
        /// <param name="legacyButtons">The legacy buttons.</param>
        /// <param name="legacyIcon">The legacy icon.</param>
        /// <param name="legacyDefaultButton">The legacy default button.</param>
        /// <param name="behavior">The behavior.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="opacity">The opacity.</param>
        /// <param name="parent">The parent form.</param>
        /// <param name="order">The z-order</param>
        /// <param name="sound">The sound</param>
        internal KryptonInformationBoxWindow(string text,
                                    string title = "",
                                    string helpFile = "",
                                    string helpTopic = "",
                                    InformationBoxInitialization initialization = InformationBoxInitialization.FromScopeAndParameters,
                                    InformationBoxButtons buttons = InformationBoxButtons.OK,
                                    InformationBoxIcon icon = InformationBoxIcon.None,
                                    Icon customIcon = null,
                                    InformationBoxDefaultButton defaultButton = InformationBoxDefaultButton.Button1,
                                    string[] customButtons = null,
                                    InformationBoxButtonsLayout buttonsLayout = InformationBoxButtonsLayout.GroupMiddle,
                                    InformationBoxAutoSizeMode autoSizeMode = InformationBoxAutoSizeMode.None,
                                    InformationBoxPosition position = InformationBoxPosition.CenterOnParent,
                                    bool showHelpButton = false,
                                    HelpNavigator helpNavigator = HelpNavigator.TableOfContents,
                                    InformationBoxCheckBox showDoNotShowAgainCheckBox = 0,
                                    InformationBoxStyle style = InformationBoxStyle.Standard,
                                    AutoCloseParameters autoClose = null,
                                    DesignParameters design = null,
                                    InformationBoxTitleIconStyle titleStyle = InformationBoxTitleIconStyle.None,
                                    InformationBoxTitleIcon titleIcon = null,
                                    MessageBoxButtons? legacyButtons = null,
                                    MessageBoxIcon? legacyIcon = null,
                                    MessageBoxDefaultButton? legacyDefaultButton = null,
                                    InformationBoxBehavior behavior = InformationBoxBehavior.Modal,
                                    AsyncResultCallback callback = null,
                                    InformationBoxOpacity opacity = InformationBoxOpacity.NoFade,
                                    KryptonForm parent = null,
                                    InformationBoxOrder order = InformationBoxOrder.Default,
                                    InformationBoxSound sound = InformationBoxSound.Default)
        {
            this.InitializeComponent();
            this.measureGraphics = CreateGraphics();

            // Apply default font for message boxes
            this.Font = SystemFonts.MessageBoxFont;
            this.kwlMessageText.Font = SystemFonts.MessageBoxFont;
            this.klblTitle.StateCommon.ShortText.Font = SystemFonts.CaptionFont;

            this.kwlMessageText.Text = text;

            if (InformationBoxInitialization.FromParametersOnly == initialization)
            {
                this.LoadCurrentScope();
            }

            this.Text = title;
            this.klblTitle.Text = title;
            this.helpFile = helpFile;
            this.helpTopic = helpTopic;
            this.buttons = buttons;
            this.icon = icon;
            if (customIcon != null)
            {
                this.iconType = InformationBoxIconType.UserDefined;
                this.customIcon = new Icon(customIcon, 48, 48);
            }
            this.defaultButton = defaultButton;
            if (customButtons != null)
            {
                if (customButtons.Length > 0)
                {
                    this.buttonUser1Text = customButtons[0];
                }

                if (customButtons.Length > 1)
                {
                    this.buttonUser2Text = customButtons[1];
                }

                if (customButtons.Length > 2)
                {
                    this.buttonUser3Text = customButtons[2];
                }
            }
            this.buttonsLayout = buttonsLayout;
            this.autoSizeMode = autoSizeMode;
            this.position = position;
            this.showHelpButton = showHelpButton;
            this.helpNavigator = helpNavigator;
            this.checkBox = showDoNotShowAgainCheckBox;
            this.style = style;
            this.autoClose = autoClose;
            this.design = design;
            this.titleStyle = titleStyle;
            if (titleIcon != null)
            {
                this.titleIcon = titleIcon.Icon;
            }
            if (!(legacyButtons is null))
            {
                this.buttons = MessageBoxEnumConverter.Parse(legacyButtons.Value);
            }
            if (!(legacyIcon is null))
            {
                this.icon = MessageBoxEnumConverter.Parse(legacyIcon.Value);
            }
            if (!(legacyDefaultButton is null))
            {
                this.defaultButton = MessageBoxEnumConverter.Parse(legacyDefaultButton.Value);
            }
            this.behavior = behavior;
            this.callback = callback;
            this.opacity = opacity;
            this.Parent = parent;
            this.order = order;
            this.sound = sound;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonInformationBoxWindow"/> class.
        /// </summary>
        /// <param name="text">The text of the box.</param>
        /// <param name="parameters">The parameters.</param>
        internal KryptonInformationBoxWindow(string text, params object[] parameters)
            : this(text)
        {
            this.activeForm = ActiveForm;

            // Looks for a parameter of the type InformationBoxInitialization.
            // If found and equal to InformationBoxInitialization.FromParametersOnly,
            // skips the scope parameters.
            bool loadScope = true;
            foreach (object param in parameters)
            {
                if (param is InformationBoxInitialization)
                {
                    InformationBoxInitialization value = (InformationBoxInitialization)param;
                    if (InformationBoxInitialization.FromParametersOnly == value)
                    {
                        loadScope = false;
                    }
                }
            }

            if (loadScope)
            {
                this.LoadCurrentScope();
            }

            int stringCount = 0;

            foreach (object parameter in parameters)
            {
                if (null == parameter)
                {
                    continue;
                }

                // Simple string -> caption
                // Or Help file if the string contains a file name
                if (parameter is string)
                {
                    if (stringCount == 0)
                    {
                        this.Text = (string)parameter;
                        this.klblTitle.Text = (string)parameter;
                    }
                    else if (stringCount == 1)
                    {
                        this.helpFile = (string)parameter;
                    }
                    else if (stringCount == 2)
                    {
                        this.helpTopic = (string)parameter;
                    }

                    stringCount++;
                }
                else if (parameter is InformationBoxButtons)
                {
                    // Buttons
                    this.buttons = (InformationBoxButtons)parameter;
                }
                else if (parameter is InformationBoxIcon)
                {
                    // Internal icon
                    this.icon = (InformationBoxIcon)parameter;
                }
                else if (parameter is Icon)
                {
                    // User defined icon
                    this.iconType = InformationBoxIconType.UserDefined;
                    this.customIcon = new Icon((Icon)parameter, 48, 48);
                }
                else if (parameter is InformationBoxDefaultButton)
                {
                    // Default button
                    this.defaultButton = (InformationBoxDefaultButton)parameter;
                }
                else if (parameter is string[])
                {
                    // Custom buttons
                    string[] labels = (string[])parameter;
                    if (labels.Length > 0)
                    {
                        this.buttonUser1Text = labels[0];
                    }

                    if (labels.Length > 1)
                    {
                        this.buttonUser2Text = labels[1];
                    }

                    if (labels.Length > 2)
                    {
                        this.buttonUser3Text = labels[2];
                    }
                }
                else if (parameter is InformationBoxButtonsLayout)
                {
                    // Buttons layout
                    this.buttonsLayout = (InformationBoxButtonsLayout)parameter;
                }
                else if (parameter is InformationBoxAutoSizeMode)
                {
                    // Autosize mode
                    this.autoSizeMode = (InformationBoxAutoSizeMode)parameter;
                }
                else if (parameter is InformationBoxPosition)
                {
                    // Position
                    this.position = (InformationBoxPosition)parameter;
                }
                else if (parameter is bool)
                {
                    // Help button
                    this.showHelpButton = (bool)parameter;
                }
                else if (parameter is HelpNavigator)
                {
                    // Help navigator
                    this.helpNavigator = (HelpNavigator)parameter;
                }
                else if (parameter is InformationBoxCheckBox)
                {
                    // Do not show this dialog again ?
                    this.checkBox = (InformationBoxCheckBox)parameter;
                }
                else if (parameter is InformationBoxStyle)
                {
                    // Visual style
                    this.style = (InformationBoxStyle)parameter;
                }
                else if (parameter is AutoCloseParameters)
                {
                    // Auto-close parameters
                    this.autoClose = (AutoCloseParameters)parameter;
                }
                else if (parameter is DesignParameters)
                {
                    // Design parameters
                    this.design = (DesignParameters)parameter;
                }
                else if (parameter is InformationBoxTitleIconStyle)
                {
                    // Title style
                    this.titleStyle = (InformationBoxTitleIconStyle)parameter;
                }
                else if (parameter is InformationBoxTitleIcon)
                {
                    // Title icon
                    this.titleIcon = ((InformationBoxTitleIcon)parameter).Icon;
                }
                else if (parameter is MessageBoxButtons?)
                {
                    // MessageBox buttons
                    this.buttons = MessageBoxEnumConverter.Parse((MessageBoxButtons)parameter);
                }
                else if (parameter is MessageBoxIcon?)
                {
                    // MessageBox icon
                    this.icon = MessageBoxEnumConverter.Parse((MessageBoxIcon)parameter);
                }
                else if (parameter is MessageBoxDefaultButton?)
                {
                    // MessageBox default button
                    this.defaultButton = MessageBoxEnumConverter.Parse((MessageBoxDefaultButton)parameter);
                }
                else if (parameter is InformationBoxBehavior)
                {
                    // InformationBox behaviour
                    this.behavior = (InformationBoxBehavior)parameter;
                }
                else if (parameter is AsyncResultCallback)
                {
                    // Callback for the result
                    this.callback = (AsyncResultCallback)parameter;
                }
                else if (parameter is InformationBoxOpacity)
                {
                    // Opacity
                    this.opacity = (InformationBoxOpacity)parameter;
                }
                else if (parameter is Form)
                {
                    // Form parent
                    this.Parent = (Form)Parent;
                }
                else if (parameter is InformationBoxOrder)
                {
                    // z-order
                    this.order = (InformationBoxOrder)parameter;
                }
                else if (parameter is InformationBoxSound)
                {
                    // Sound
                    this.sound = (InformationBoxSound)parameter;
                }
            }
        }

        #endregion Constructors

        #region Show

        /// <summary>
        /// Shows this InformationBox.
        /// </summary>
        /// <returns>The result corresponding to the button clicked</returns>
        internal new InformationBoxResult Show()
        {
            this.SetCheckBox();
            this.SetButtons();
            this.SetText();
            this.SetIcon();
            this.SetLayout();
            this.SetFocus();
            this.SetPosition();
            this.SetWindowStyle();
            this.SetAutoClose();
            this.SetOpacity();
            this.PlaySound();
            this.SetOrder();

            if (this.behavior == InformationBoxBehavior.Modal)
            {
                ShowDialog();
            }
            else
            {
                base.Show();
            }

            return this.result;
        }

        /// <summary>
        /// Shows this InformationBox.
        /// </summary>
        /// <param name="state">The state of the checkbox.</param>
        /// <returns>The result corresponding to the button clicked</returns>
        internal InformationBoxResult Show(out CheckState state)
        {
            this.result = this.Show();
            state = this.kcbDoNotShow.CheckState;
            return this.result;
        }

        #endregion Show

        #region Sound

        /// <summary>
        /// Plays the sound associated with the icon type.
        /// </summary>
        private void PlaySound()
        {
            if (sound == InformationBoxSound.None)
            {
                return;
            }

            SystemSound soundToPlay;

            if (this.iconType == InformationBoxIconType.UserDefined)
            {
                soundToPlay = SystemSounds.Beep;
            }
            else
            {
                switch (IconHelper.GetCategory(this.icon))
                {
                    case InformationBoxMessageCategory.Asterisk:
                        soundToPlay = SystemSounds.Asterisk;
                        break;
                    case InformationBoxMessageCategory.Exclamation:
                        soundToPlay = SystemSounds.Exclamation;
                        break;
                    case InformationBoxMessageCategory.Hand:
                        soundToPlay = SystemSounds.Hand;
                        break;
                    case InformationBoxMessageCategory.Question:
                        soundToPlay = SystemSounds.Question;
                        break;
                    default:
                        soundToPlay = SystemSounds.Beep;
                        break;
                }
            }

            if (null != soundToPlay)
            {
                soundToPlay.Play();
            }
        }

        #endregion Sound

        #region Box initialization

        /// <summary>
        /// Loads the current scope.
        /// </summary>
        private void LoadCurrentScope()
        {
            if (InformationBoxScope.Current == null)
            {
                return;
            }

            InformationBoxScopeParameters parameters = InformationBoxScope.Current.Parameters;

            if (parameters.Icon.HasValue)
            {
                this.icon = parameters.Icon.Value;
            }

            if (parameters.CustomIcon != null)
            {
                this.iconType = InformationBoxIconType.UserDefined;
                this.customIcon = parameters.CustomIcon;
            }

            if (parameters.Buttons.HasValue)
            {
                this.buttons = parameters.Buttons.Value;
            }

            if (parameters.DefaultButton.HasValue)
            {
                this.defaultButton = parameters.DefaultButton.Value;
            }

            if (parameters.Layout.HasValue)
            {
                this.buttonsLayout = parameters.Layout.Value;
            }

            if (parameters.AutoSizeMode.HasValue)
            {
                this.autoSizeMode = parameters.AutoSizeMode.Value;
            }

            if (parameters.Position.HasValue)
            {
                this.position = parameters.Position.Value;
            }

            if (parameters.CheckBox.HasValue)
            {
                this.checkBox = parameters.CheckBox.Value;
            }

            if (parameters.Style.HasValue)
            {
                this.style = parameters.Style.Value;
            }

            if (parameters.AutoClose != null)
            {
                this.autoClose = parameters.AutoClose;
            }

            if (parameters.Design != null)
            {
                this.design = parameters.Design;
            }

            if (parameters.TitleIconStyle.HasValue)
            {
                this.titleStyle = parameters.TitleIconStyle.Value;
            }

            if (parameters.TitleIcon != null)
            {
                this.titleIcon = parameters.TitleIcon;
            }

            if (parameters.Behavior.HasValue)
            {
                this.behavior = parameters.Behavior.Value;
            }

            if (parameters.Opacity.HasValue)
            {
                this.opacity = parameters.Opacity.Value;
            }

            if (parameters.Help.HasValue)
            {
                this.showHelpButton = parameters.Help.Value;
            }

            if (parameters.HelpNavigator.HasValue)
            {
                this.helpNavigator = parameters.HelpNavigator.Value;
            }

            if (parameters.Order.HasValue)
            {
                this.order = parameters.Order.Value;
            }

            if (parameters.Sound.HasValue)
            {
                this.sound = parameters.Sound.Value;
            }
        }

        #region Auto close

        /// <summary>
        /// Sets the auto close parameters.
        /// </summary>
        private void SetAutoClose()
        {
            if (null == this.autoClose)
            {
                return;
            }

            this.tmrAutoClose.Interval = 1000;
            this.tmrAutoClose.Tick += this.TmrAutoClose_Tick;
            this.tmrAutoClose.Start();
        }

        #endregion Auto close

        #region Opacity

        /// <summary>
        /// Sets the opacity.
        /// </summary>
        private void SetOpacity()
        {
            switch (this.opacity)
            {
                case InformationBoxOpacity.Faded10:
                    Opacity = 0.1;
                    break;
                case InformationBoxOpacity.Faded20:
                    Opacity = 0.2;
                    break;
                case InformationBoxOpacity.Faded30:
                    Opacity = 0.3;
                    break;
                case InformationBoxOpacity.Faded40:
                    Opacity = 0.4;
                    break;
                case InformationBoxOpacity.Faded50:
                    Opacity = 0.5;
                    break;
                case InformationBoxOpacity.Faded60:
                    Opacity = 0.6;
                    break;
                case InformationBoxOpacity.Faded70:
                    Opacity = 0.7;
                    break;
                case InformationBoxOpacity.Faded80:
                    Opacity = 0.8;
                    break;
                case InformationBoxOpacity.Faded90:
                    Opacity = 0.9;
                    break;
                case InformationBoxOpacity.NoFade:
                    Opacity = 1.0;
                    break;
                default:
                    break;
            }
        }

        #endregion Opacity

        #region Style

        /// <summary>
        /// Sets the window style.
        /// </summary>
        private void SetWindowStyle()
        {
            if (this.style == InformationBoxStyle.Modern)
            {
                Color barsBackColor = Color.Black;
                Color formBackColor = Color.Silver;

                if (null != this.design)
                {
                    barsBackColor = this.design.BarsBackColor;
                    formBackColor = this.design.FormBackColor;
                }

                //this.pnlForm.BackColor = formBackColor;
                this.kwlMessageText.BackColor = formBackColor;

                this.kpnlButtons.BackColor = barsBackColor;
                this.klblTitle.BackColor = barsBackColor;

                FormBorderStyle = FormBorderStyle.None;
                this.klblTitle.Visible = true;

                foreach (KryptonButton button in this.kpnlButtons.Controls)
                {
                    button.BackColor = barsBackColor;
                }
            }
            else if (this.style == InformationBoxStyle.Standard)
            {
                Color barsBackColor = SystemColors.Control;
                Color formBackColor = SystemColors.Control;

                if (null != this.design)
                {
                    barsBackColor = this.design.BarsBackColor;
                    formBackColor = this.design.FormBackColor;
                }

                //this.kpnlButtons.BackColor = barsBackColor;
                //this.k.BackColor = formBackColor;
                //this.kwlMessageText.BackColor = formBackColor;

                FormBorderStyle = FormBorderStyle.FixedDialog;
                this.klblTitle.Visible = false;
                this.kpnlMain.Top -= this.klblTitle.Height;
                //this.kpnlButtons.SideBorder = SideBorder.None;
            }
        }

        #endregion Style

        #region CheckBox

        /// <summary>
        /// Sets the check box.
        /// </summary>
        private void SetCheckBox()
        {
            this.kcbDoNotShow.Text = Properties.Resources.DoNotShowText;

            this.kcbDoNotShow.Visible = ((this.checkBox & InformationBoxCheckBox.Show) == InformationBoxCheckBox.Show);
            this.kcbDoNotShow.Checked = ((this.checkBox & InformationBoxCheckBox.Checked) == InformationBoxCheckBox.Checked);
            //this.kcbDoNotShow.TextAlign = ((this.checkBox & InformationBoxCheckBox.RightAligned) == InformationBoxCheckBox.RightAligned)
            //                             ? ContentAlignment.BottomRight
            //                             : ContentAlignment.BottomLeft;
            //this.kcbDoNotShow.CheckAlign = ((this.checkBox & InformationBoxCheckBox.RightAligned) == InformationBoxCheckBox.RightAligned)
            //                              ? ContentAlignment.MiddleRight
            //                              : ContentAlignment.MiddleLeft;
        }

        #endregion CheckBox

        #region Position

        /// <summary>
        /// Sets the position.
        /// </summary>
        private void SetPosition()
        {
            if (this.position == InformationBoxPosition.CenterOnScreen)
            {
                StartPosition = FormStartPosition.CenterScreen;
                CenterToScreen();
            }
            else
            {
                StartPosition = FormStartPosition.CenterParent;
                CenterToParent();
            }
        }

        #endregion Position

        #region Focus

        /// <summary>
        /// Sets the focus.
        /// </summary>
        private void SetFocus()
        {
            if (this.defaultButton == InformationBoxDefaultButton.Button1 && this.kpnlButtons.Controls.Count > 0)
            {
                this.kpnlButtons.Controls[0].Select();
            }

            if (this.defaultButton == InformationBoxDefaultButton.Button2 && this.kpnlButtons.Controls.Count > 1)
            {
                this.kpnlButtons.Controls[1].Select();
            }

            if (this.defaultButton == InformationBoxDefaultButton.Button3 && this.kpnlButtons.Controls.Count > 2)
            {
                this.kpnlButtons.Controls[2].Select();
            }
        }

        #endregion Focus

        #region Layout

        /// <summary>
        /// Sets the layout.
        /// </summary>
        private void SetLayout()
        {
            int totalHeight;
            int totalWidth;

            #region Width

            // Caption width including button
            int captionWidth = Convert.ToInt32(this.measureGraphics.MeasureString(Text, SystemFonts.CaptionFont).Width) + 30;
            if (this.titleStyle != InformationBoxTitleIconStyle.None)
            {
                captionWidth += BORDER_PADDING * 2;
            }

            // "Do not show this dialog again" width
            int checkBoxWidth = ((this.checkBox & InformationBoxCheckBox.Show) == InformationBoxCheckBox.Show)
                                    ? (int)this.measureGraphics.MeasureString(this.kcbDoNotShow.Text, this.kcbDoNotShow.Font).Width + BORDER_PADDING * 4
                                    : 0;

            // Width of the text and icon.
            int iconAndTextWidth = 0;

            // Minimum width to display all needed buttons.
            int buttonsMinWidth = (this.kpnlButtons.Controls.Count + 4) * BORDER_PADDING;
            foreach (Control ctrl in this.kpnlButtons.Controls)
            {
                buttonsMinWidth += ctrl.Width;
            }

            // Icon width
            if (this.icon != InformationBoxIcon.None || this.iconType == InformationBoxIconType.UserDefined)
            {
                iconAndTextWidth += ICON_PANEL_WIDTH;
            }

            // Text width
            iconAndTextWidth += this.kwlMessageText.Width + BORDER_PADDING * 2;

            // Gets the maximum size
            totalWidth = Math.Max(Math.Max(Math.Max(buttonsMinWidth, iconAndTextWidth), captionWidth), checkBoxWidth);

            #endregion Width

            #region Height

            if ((this.checkBox & InformationBoxCheckBox.Show) != InformationBoxCheckBox.Show)
            {
                this.kcbDoNotShow.Visible = false;
                this.kpnlBase.Height -= this.kcbDoNotShow.Height;
            }

            int iconHeight = 0;
            if (this.icon != InformationBoxIcon.None || this.iconType == InformationBoxIconType.UserDefined)
            {
                iconHeight = this.pbxIcon.Height;
            }

            int textHeight = this.kwlMessageText.Height;

            totalHeight = Math.Max(iconHeight, textHeight) + BORDER_PADDING * 2 + this.kpnlBase.Height;

            // Add a small space to avoid vertical scrollbar.
            if (iconAndTextWidth > Screen.PrimaryScreen.WorkingArea.Width - 100)
            {
                totalHeight += 20;
            }

            bool verticalScroll = false;
            if (totalHeight > Screen.PrimaryScreen.WorkingArea.Height - 50)
            {
                totalHeight = Screen.PrimaryScreen.WorkingArea.Height - 50;
                totalWidth += 20;
                this.kwlMessageText.Top = BORDER_PADDING;
                verticalScroll = true;
            }

            this.kpnlMain.Size = new Size(Math.Min(Screen.PrimaryScreen.WorkingArea.Width - 20, totalWidth), totalHeight - this.kpnlBase.Height);

            if (this.style == InformationBoxStyle.Modern)
            {
                totalHeight += this.klblTitle.Height;
            }

            #endregion Height

            // Sets the size
            ClientSize = new Size(Math.Min(Screen.PrimaryScreen.WorkingArea.Width - 20, totalWidth), totalHeight);

            #region Position

            // Set new position for all components
            // Icon
            this.pbxIcon.Left = BORDER_PADDING;
            this.pbxIcon.Top = BORDER_PADDING;

            // Text
            this.kpnlScrollText.Width = ClientSize.Width - ((this.icon != InformationBoxIcon.None || this.iconType == InformationBoxIconType.UserDefined)
                                       ? ICON_PANEL_WIDTH + BORDER_PADDING + 5
                                       : BORDER_PADDING);
            if (!verticalScroll)
            {
                this.kwlMessageText.Top = Convert.ToInt32((this.kpnlText.Height - this.kwlMessageText.Height) / 2);
            }

            // Buttons
            this.SetButtonsLayout();

            #endregion Position
        }

        /// <summary>
        /// Sets the buttons layout.
        /// </summary>
        private void SetButtonsLayout()
        {
            // Do not count the checkbox
            int buttonsCount = this.kpnlButtons.Controls.Count;
            int index = 0;
            int initialPosition = 0;
            int spaceBetween = 0;
            switch (this.buttonsLayout)
            {
                case InformationBoxButtonsLayout.GroupLeft:
                    initialPosition = BORDER_PADDING;
                    spaceBetween = BORDER_PADDING;
                    break;
                case InformationBoxButtonsLayout.GroupMiddle:
                    spaceBetween = BORDER_PADDING;

                    // If there is only one button then we must center it
                    if (buttonsCount == 1)
                    {
                        initialPosition += Convert.ToInt32((Width - buttonsCount * this.kpnlButtons.Controls[0].Width) / (buttonsCount + 1));
                    }
                    else
                    {
                        initialPosition = Convert.ToInt32((Width - (buttonsCount * (this.kpnlButtons.Controls[0].Width + BORDER_PADDING))) / 2);
                    }

                    break;
                case InformationBoxButtonsLayout.GroupRight:
                    spaceBetween = BORDER_PADDING;
                    initialPosition = ClientSize.Width - (buttonsCount * (this.kpnlButtons.Controls[0].Width + BORDER_PADDING));
                    break;
                case InformationBoxButtonsLayout.Separate:
                    spaceBetween = Convert.ToInt32((ClientSize.Width - buttonsCount * this.kpnlButtons.Controls[0].Width) / (buttonsCount + 1));
                    initialPosition = spaceBetween;
                    break;
                default:
                    break;
            }

            foreach (Control ctrl in this.kpnlButtons.Controls)
            {
                ctrl.Left = initialPosition + spaceBetween * (index) + ctrl.Width * index;
                ++index;
            }
        }

        #endregion Layout

        #region Icon

        /// <summary>
        /// Sets the icon.
        /// </summary>
        private void SetIcon()
        {
            if (this.iconType == InformationBoxIconType.Internal)
            {
                if (this.icon == InformationBoxIcon.None)
                {
                    this.kpnlIcon.Visible = false;
                    this.pbxIcon.Image = null;
                }
                else
                {
                    this.kpnlIcon.Visible = true;
                    this.pbxIcon.Image = IconHelper.FromEnum(this.icon).ToBitmap();
                }
            }
            else
            {
                this.pbxIcon.Image = this.customIcon.ToBitmap();
                this.kpnlIcon.Visible = true;
            }

            this.kpnlIcon.Width = ICON_PANEL_WIDTH;

            if (this.titleStyle == InformationBoxTitleIconStyle.None)
            {
                ShowIcon = false;
                Icon = Properties.Resources.blank;
            }
            else if (this.titleStyle == InformationBoxTitleIconStyle.SameAsBox)
            {
                if (this.iconType == InformationBoxIconType.Internal)
                {
                    Icon = IconHelper.FromEnum(this.icon);
                }
                else
                {
                    Icon = this.customIcon;
                }
            }
            else if (this.titleStyle == InformationBoxTitleIconStyle.Custom)
            {
                Icon = this.titleIcon;
            }
        }

        #endregion Icon

        #region Z-Order

        /// <summary>
        /// Sets the order.
        /// </summary>
        private void SetOrder()
        {
            if (this.order == InformationBoxOrder.TopMost)
            {
                this.TopMost = true;
            }
        }

        #endregion Z-Order

        #region Text

        /// <summary>
        /// Sets the text.
        /// </summary>
        private void SetText()
        {
            this.kwlMessageText.Text = this.kwlMessageText.Text.Replace("\n\r", "\n");
            this.kwlMessageText.Text = this.kwlMessageText.Text.Replace("\n", Environment.NewLine);

            Screen currentScreen = Screen.FromControl(this);
            int screenWidth = currentScreen.WorkingArea.Width;

            if (this.autoSizeMode == InformationBoxAutoSizeMode.None)
            {
                //this.kwlMessageText.WordWrap = true;
                this.kwlMessageText.Size = this.measureGraphics.MeasureString(this.kwlMessageText.Text, this.kwlMessageText.Font, screenWidth / 2).ToSize();
            }
            else
            {
                this.internalText = new StringBuilder(this.kwlMessageText.Text);

                if (this.autoSizeMode == InformationBoxAutoSizeMode.MinimumHeight)
                {
                    // Remove line breaks.
                    this.internalText = this.internalText.Replace(Environment.NewLine, " ");
                    Regex splitter = new Regex(@"(?<sentence>.+?(\. |$))", RegexOptions.Compiled);
                    MatchCollection sentences = splitter.Matches(this.internalText.ToString());
                    StringBuilder formattedText = new StringBuilder();
                    int currentWidth = 0;

                    foreach (Match sentence in sentences)
                    {
                        int sentenceLength = (int)this.measureGraphics.MeasureString(sentence.Value, kwlMessageText.Font).Width;
                        if (currentWidth != 0 && (sentenceLength + currentWidth) > (screenWidth - 50))
                        {
                            formattedText.Append(Environment.NewLine);
                            currentWidth = 0;
                        }

                        currentWidth += sentenceLength;
                        formattedText.Append(sentence.Value);
                    }

                    this.internalText = formattedText;
                }
                else if (this.autoSizeMode == InformationBoxAutoSizeMode.MinimumWidth)
                {
                    this.internalText.Replace(". ", "." + Environment.NewLine);
                    this.internalText.Replace("? ", "?" + Environment.NewLine);
                    this.internalText.Replace("! ", "!" + Environment.NewLine);
                    this.internalText.Replace(": ", ":" + Environment.NewLine);
                    this.internalText.Replace(") ", ")" + Environment.NewLine);
                    this.internalText.Replace(", ", "," + Environment.NewLine);
                }

                this.kwlMessageText.Text = this.internalText.ToString();

                this.kwlMessageText.Size = this.measureGraphics.MeasureString(this.kwlMessageText.Text, this.kwlMessageText.Font).ToSize();
            }

            this.kwlMessageText.Width += BORDER_PADDING;
        }

        #endregion Text

        #region Buttons

        /// <summary>
        /// Sets the buttons, order of addition is respected.
        /// </summary>
        private void SetButtons()
        {
            // Abort button
            if (this.buttons == InformationBoxButtons.AbortRetryIgnore)
            {
                this.AddButton("Abort", Properties.Resources.AbortText);
            }

            // Ok
            if (this.buttons == InformationBoxButtons.OK ||
                this.buttons == InformationBoxButtons.OKCancel ||
                this.buttons == InformationBoxButtons.OKCancelUser1)
            {
                this.AddButton("OK", Properties.Resources.OkText);
            }

            // Yes
            if (this.buttons == InformationBoxButtons.YesNo ||
                this.buttons == InformationBoxButtons.YesNoCancel ||
                this.buttons == InformationBoxButtons.YesNoUser1)
            {
                this.AddButton("Yes", Properties.Resources.YesText);
            }

            // Retry
            if (this.buttons == InformationBoxButtons.AbortRetryIgnore ||
                this.buttons == InformationBoxButtons.RetryCancel)
            {
                this.AddButton("Retry", Properties.Resources.RetryText);
            }

            // No
            if (this.buttons == InformationBoxButtons.YesNo ||
                this.buttons == InformationBoxButtons.YesNoCancel ||
                this.buttons == InformationBoxButtons.YesNoUser1)
            {
                this.AddButton("No", Properties.Resources.NoText);
            }

            // Cancel
            if (this.buttons == InformationBoxButtons.OKCancel ||
                this.buttons == InformationBoxButtons.OKCancelUser1 ||
                this.buttons == InformationBoxButtons.RetryCancel ||
                this.buttons == InformationBoxButtons.YesNoCancel)
            {
                this.AddButton("Cancel", Properties.Resources.CancelText);
            }

            // Ignore
            if (this.buttons == InformationBoxButtons.AbortRetryIgnore)
            {
                this.AddButton("Ignore", Properties.Resources.IgnoreText);
            }

            // User1
            if (this.buttons == InformationBoxButtons.OKCancelUser1 ||
                this.buttons == InformationBoxButtons.User1User2User3 ||
                this.buttons == InformationBoxButtons.User1User2 ||
                this.buttons == InformationBoxButtons.YesNoUser1 ||
                this.buttons == InformationBoxButtons.User1)
            {
                this.AddButton("User1", this.buttonUser1Text);
            }

            // User2
            if (this.buttons == InformationBoxButtons.User1User2 ||
                this.buttons == InformationBoxButtons.User1User2User3)
            {
                this.AddButton("User2", this.buttonUser2Text);
            }

            // User3
            if (this.buttons == InformationBoxButtons.User1User2User3)
            {
                this.AddButton("User3", this.buttonUser3Text);
            }

            // Help button is displayed when asked or when a help file name exists
            if (this.showHelpButton || !String.IsNullOrEmpty(this.helpFile))
            {
                this.AddButton("Help", Properties.Resources.HelpText);
            }

            this.SetButtonsSize();
        }

        /// <summary>
        /// Sets the buttons size.
        /// </summary>
        private void SetButtonsSize()
        {
            // All button will have the same size
            int maxSize = 0;

            // Measures the width of each button
            foreach (Control ctrl in this.kpnlButtons.Controls)
            {
                maxSize = Math.Max(Convert.ToInt32(this.measureGraphics.MeasureString(ctrl.Text, ctrl.Font).Width + 40), maxSize);
            }

            foreach (Control ctrl in this.kpnlButtons.Controls)
            {
                if (this.style == InformationBoxStyle.Standard)
                {
                    ctrl.Size = new Size(maxSize, 23);
                    ctrl.Top = 5;
                }
                else if (this.style == InformationBoxStyle.Modern)
                {
                    ctrl.Size = new Size(maxSize, this.kpnlButtons.Height);
                    ctrl.Top = 0;
                }
            }
        }

        /// <summary>
        /// Adds the button.
        /// </summary>
        /// <param name="name">The name of the button.</param>
        /// <param name="text">The text of the button.</param>
        private void AddButton(string name, string text)
        {
            Control buttonToAdd;

            if (this.style == InformationBoxStyle.Modern)
            {
                buttonToAdd = new KryptonButton();
                //(buttonToAdd as KryptonButton).PersistantMode = false;
                (buttonToAdd as KryptonButton).Click += this.Button_Click;
            }
            else
            {
                buttonToAdd = new KryptonButton();
                (buttonToAdd as KryptonButton).Click += this.Button_Click;
            }

            buttonToAdd.Font = SystemFonts.MessageBoxFont;
            buttonToAdd.Name = name;
            buttonToAdd.Text = text;
            this.kpnlButtons.Controls.Add(buttonToAdd);
        }

        #endregion Buttons

        #endregion Box initialization

        #region Button click

        /// <summary>
        /// Handles the buttons.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void HandleButton(Control sender)
        {
            Control senderControl = sender;
            switch (senderControl.Name)
            {
                case "Abort":
                    this.result = InformationBoxResult.Abort;
                    break;
                case "OK":
                    this.result = InformationBoxResult.OK;
                    break;
                case "Yes":
                    this.result = InformationBoxResult.Yes;
                    break;
                case "Retry":
                    this.result = InformationBoxResult.Retry;
                    break;
                case "No":
                    this.result = InformationBoxResult.No;
                    break;
                case "Cancel":
                    this.result = InformationBoxResult.Cancel;
                    break;
                case "Ignore":
                    this.result = InformationBoxResult.Ignore;
                    break;
                case "User1":
                    this.result = InformationBoxResult.User1;
                    break;
                case "User2":
                    this.result = InformationBoxResult.User2;
                    break;
                case "User3":
                    this.result = InformationBoxResult.User3;
                    break;
                default:
                    this.result = InformationBoxResult.None;
                    break;
            }

            if (senderControl.Name.Equals("Help"))
            {
                this.OpenHelp();
            }
            else
            {
                DialogResult = DialogResult.OK;
                if (this.behavior == InformationBoxBehavior.Modeless)
                {
                    Close();
                }
            }
        }

        #endregion Button click

        #region Help

        /// <summary>
        /// Opens the help.
        /// </summary>
        private void OpenHelp()
        {
            // If there is an active form
            if (null != this.activeForm)
            {
                MethodInfo met = this.activeForm.GetType().GetMethod("OnHelpRequested", BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
                if (null != met)
                {
                    // Call for help on the active form.
                    met.Invoke(this.activeForm, new object[] { new HelpEventArgs(MousePosition) });
                }
            }

            // If a help file is specified
            if (!String.IsNullOrEmpty(this.helpFile))
            {
                // If no topic is specified
                if (String.IsNullOrEmpty(this.helpTopic))
                {
                    Help.ShowHelp(this.activeForm, this.helpFile, this.helpNavigator);
                }
                else
                {
                    Help.ShowHelp(this.activeForm, this.helpFile, this.helpTopic);
                }
            }
        }

        #endregion Help

        #region Event handling

        /// <summary>
        /// Handles the Click event of the buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                this.HandleButton((Control)sender);
            }
        }

        /// <summary>
        /// Handles the FormClosed event of the InformationBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosedEventArgs"/> instance containing the event data.</param>
        private void InformationBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.result == InformationBoxResult.None)
            {
                this.result = InformationBoxResult.Cancel;
            }

            if (this.behavior == InformationBoxBehavior.Modeless && null != this.callback)
            {
                Invoke(this.callback, this.result);
            }
        }

        /// <summary>
        /// Handles the Paint event of the pnlForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void PnlForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.style == InformationBoxStyle.Modern)
            {
                ControlPaint.DrawBorder(e.Graphics, this.kpnlContent.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the lblTitle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void LblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.lastPointerPosition = e.Location;
                this.mouseDown = true;
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the lblTitle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void LblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.mouseDown)
            {
                return;
            }

            Point location = DesktopLocation;

            location.Offset(new Point(e.Location.X - this.lastPointerPosition.X, e.Location.Y - this.lastPointerPosition.Y));

            DesktopLocation = location;
        }

        /// <summary>
        /// Handles the MouseUp event of the lblTitle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void LblTitle_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseDown = false;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the InformationBoxForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void InformationBoxForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        /// <summary>
        /// Handles the Tick event of the tmrAutoClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TmrAutoClose_Tick(object sender, EventArgs e)
        {
            if (this.elapsedTime == this.autoClose.Seconds)
            {
                this.tmrAutoClose.Stop();

                switch (this.autoClose.Mode)
                {
                    case AutoCloseDefinedParameters.Button:
                        if (this.autoClose.DefaultButton == InformationBoxDefaultButton.Button1 && this.kpnlButtons.Controls.Count > 0)
                        {
                            this.HandleButton(this.kpnlButtons.Controls[0]);
                        }
                        else if (this.autoClose.DefaultButton == InformationBoxDefaultButton.Button2 && this.kpnlButtons.Controls.Count > 1)
                        {
                            this.HandleButton(this.kpnlButtons.Controls[1]);
                        }
                        else if (this.autoClose.DefaultButton == InformationBoxDefaultButton.Button3 && this.kpnlButtons.Controls.Count > 2)
                        {
                            this.HandleButton(this.kpnlButtons.Controls[2]);
                        }

                        return;
                    case AutoCloseDefinedParameters.TimeOnly:
                        if (this.defaultButton == InformationBoxDefaultButton.Button1 && this.kpnlButtons.Controls.Count > 0)
                        {
                            this.HandleButton(this.kpnlButtons.Controls[0]);
                        }
                        else if (this.defaultButton == InformationBoxDefaultButton.Button2 && this.kpnlButtons.Controls.Count > 1)
                        {
                            this.HandleButton(this.kpnlButtons.Controls[1]);
                        }
                        else if (this.defaultButton == InformationBoxDefaultButton.Button3 && this.kpnlButtons.Controls.Count > 2)
                        {
                            this.HandleButton(this.kpnlButtons.Controls[2]);
                        }

                        return;
                    case AutoCloseDefinedParameters.Result:
                        this.result = this.autoClose.Result;
                        DialogResult = DialogResult.OK;
                        return;
                    default:
                        break;
                }
            }
            else
            {
                Control buttonToUpdate = null;
                if (this.autoClose.Mode == AutoCloseDefinedParameters.Button)
                {
                    if (this.autoClose.DefaultButton == InformationBoxDefaultButton.Button1 && this.kpnlButtons.Controls.Count > 0)
                    {
                        buttonToUpdate = this.kpnlButtons.Controls[0];
                    }
                    else if (this.autoClose.DefaultButton == InformationBoxDefaultButton.Button2 && this.kpnlButtons.Controls.Count > 1)
                    {
                        buttonToUpdate = this.kpnlButtons.Controls[1];
                    }
                    else if (this.autoClose.DefaultButton == InformationBoxDefaultButton.Button3 && this.kpnlButtons.Controls.Count > 2)
                    {
                        buttonToUpdate = this.kpnlButtons.Controls[2];
                    }
                }
                else
                {
                    if (this.defaultButton == InformationBoxDefaultButton.Button1 && this.kpnlButtons.Controls.Count > 0)
                    {
                        buttonToUpdate = this.kpnlButtons.Controls[0];
                    }
                    else if (this.defaultButton == InformationBoxDefaultButton.Button2 && this.kpnlButtons.Controls.Count > 1)
                    {
                        buttonToUpdate = this.kpnlButtons.Controls[1];
                    }
                    else if (this.defaultButton == InformationBoxDefaultButton.Button3 && this.kpnlButtons.Controls.Count > 2)
                    {
                        buttonToUpdate = this.kpnlButtons.Controls[2];
                    }
                }

                if (null != buttonToUpdate)
                {
                    Regex extractLabel = new Regex(@".*?\(\d+\)");

                    if (buttonToUpdate is KryptonButton)
                    {
                        KryptonButton button = (KryptonButton)buttonToUpdate;
                        if (extractLabel.IsMatch(button.Text))
                        {
                            button.Text = String.Format(CultureInfo.InvariantCulture, "{0} ({1})", button.Text.Substring(0, button.Text.LastIndexOf(" (", StringComparison.OrdinalIgnoreCase)), this.autoClose.Seconds - this.elapsedTime);
                        }
                        else
                        {
                            button.Text = String.Format(CultureInfo.InvariantCulture, "{0} ({1})", button.Text, this.autoClose.Seconds - this.elapsedTime);
                        }
                    }
                    else if (buttonToUpdate is KryptonButton)
                    {
                        KryptonButton button = (KryptonButton)buttonToUpdate;
                        if (extractLabel.IsMatch(button.Text))
                        {
                            button.Text = String.Format(CultureInfo.InvariantCulture, "{0} ({1})", button.Text.Substring(0, button.Text.LastIndexOf(" (", StringComparison.OrdinalIgnoreCase)), this.autoClose.Seconds - this.elapsedTime);
                        }
                        else
                        {
                            button.Text = String.Format(CultureInfo.InvariantCulture, "{0} ({1})", button.Text, this.autoClose.Seconds - this.elapsedTime);
                        }
                    }
                }
            }

            this.elapsedTime++;
        }

        #endregion Event handling
    }
}