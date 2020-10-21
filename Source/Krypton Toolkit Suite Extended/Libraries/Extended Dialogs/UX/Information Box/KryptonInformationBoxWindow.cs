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
        /// Help file associated to the help button
        /// </summary>
        private readonly string helpFile = string.Empty;

        /// <summary>
        /// Help topic associated to the help button
        /// </summary>
        private readonly string helpTopic = string.Empty;

        /// <summary>
        /// Contains the graphics used to measure the strings
        /// </summary>
        private readonly Graphics measureGraphics;

        /// <summary>
        /// Contains a reference to the active form
        /// </summary>
        private readonly KryptonForm activeForm;

        /// <summary>
        /// Result corresponding the clicked button
        /// </summary>
        private InformationBoxResult result = InformationBoxResult.None;

        /// <summary>
        /// Main icon of the form
        /// </summary>
        private InformationBoxIcon icon = InformationBoxIcon.None;

        /// <summary>
        /// Custom icon
        /// </summary>
        private Icon customIcon;

        /// <summary>
        /// Buttons displayed on the form
        /// </summary>
        private InformationBoxButtons buttons = InformationBoxButtons.OK;

        /// <summary>
        /// Default button
        /// </summary>
        private InformationBoxDefaultButton defaultButton = InformationBoxDefaultButton.Button1;

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
        #endregion

        #region Constructors
        internal KryptonInformationBoxWindow(string text)
        {
            InitializeComponent();

            measureGraphics = CreateGraphics();

            kwlMessageText.Text = text;
        }

        internal KryptonInformationBoxWindow(string text, params object[] parameters) : this(text)
        {
            activeForm = (KryptonForm)ActiveForm;

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
                LoadCurrentScope();
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
                        Text = (string)parameter;
                        klblTitle.Text = (string)parameter;
                    }
                    else if (stringCount == 1)
                    {
                        helpFile = (string)parameter;
                    }
                    else if (stringCount == 2)
                    {
                        helpTopic = (string)parameter;
                    }

                    stringCount++;
                }
                else if (parameter is InformationBoxButtons)
                {
                    // Buttons
                    buttons = (InformationBoxButtons)parameter;
                }
                else if (parameter is InformationBoxIcon)
                {
                    // Internal icon
                    icon = (InformationBoxIcon)parameter;
                }
                else if (parameter is Icon)
                {
                    // User defined icon
                    iconType = InformationBoxIconType.UserDefined;
                    customIcon = new Icon((Icon)parameter, 48, 48);
                }
                else if (parameter is InformationBoxDefaultButton)
                {
                    // Default button
                    defaultButton = (InformationBoxDefaultButton)parameter;
                }
                else if (parameter is string[])
                {
                    // Custom buttons
                    string[] labels = (string[])parameter;
                    if (labels.Length > 0)
                    {
                        buttonUser1Text = labels[0];
                    }

                    if (labels.Length > 1)
                    {
                        buttonUser2Text = labels[1];
                    }
                }
                else if (parameter is InformationBoxButtonsLayout)
                {
                    // Buttons layout
                    buttonsLayout = (InformationBoxButtonsLayout)parameter;
                }
                else if (parameter is InformationBoxAutoSizeMode)
                {
                    // Autosize mode
                    autoSizeMode = (InformationBoxAutoSizeMode)parameter;
                }
                else if (parameter is InformationBoxPosition)
                {
                    // Position
                    position = (InformationBoxPosition)parameter;
                }
                else if (parameter is bool)
                {
                    // Help button
                    showHelpButton = (bool)parameter;
                }
                else if (parameter is HelpNavigator)
                {
                    // Help navigator
                    helpNavigator = (HelpNavigator)parameter;
                }
                else if (parameter is InformationBoxCheckBox)
                {
                    // Do not show this dialog again ?
                    checkBox = (InformationBoxCheckBox)parameter;
                }
                else if (parameter is InformationBoxStyle)
                {
                    // Visual style
                    style = (InformationBoxStyle)parameter;
                }
                else if (parameter is AutoCloseParameters)
                {
                    // Auto-close parameters
                    autoClose = (AutoCloseParameters)parameter;
                }
                else if (parameter is DesignParameters)
                {
                    // Design parameters
                    design = (DesignParameters)parameter;
                }
                else if (parameter is InformationBoxTitleIconStyle)
                {
                    // Title style
                    titleStyle = (InformationBoxTitleIconStyle)parameter;
                }
                else if (parameter is InformationBoxTitleIcon)
                {
                    // Title icon
                    titleIcon = ((InformationBoxTitleIcon)parameter).Icon;
                }
                else if (parameter is MessageBoxButtons? && parameter != null)
                {
                    // MessageBox buttons
                    buttons = MessageBoxEnumConverter.Parse((MessageBoxButtons)parameter);
                }
                else if (parameter is MessageBoxIcon? && parameter != null)
                {
                    // MessageBox icon
                    icon = MessageBoxEnumConverter.Parse((MessageBoxIcon)parameter);
                }
                else if (parameter is MessageBoxDefaultButton? && parameter != null)
                {
                    // MessageBox default button
                    defaultButton = MessageBoxEnumConverter.Parse((MessageBoxDefaultButton)parameter);
                }
                else if (parameter is InformationBoxBehavior)
                {
                    // InformationBox behaviour
                    behavior = (InformationBoxBehavior)parameter;
                }
                else if (parameter is AsyncResultCallback)
                {
                    // Callback for the result
                    callback = (AsyncResultCallback)parameter;
                }
                else if (parameter is InformationBoxOpacity)
                {
                    // Opacity
                    opacity = (InformationBoxOpacity)parameter;
                }
                else if (parameter is Form)
                {
                    // Form parent
                    Parent = (Form)Parent;
                }
                else if (parameter is InformationBoxOrder)
                {
                    // z-order
                    order = (InformationBoxOrder)parameter;
                }
                else if (parameter is Form)
                {
                    // Form parent
                    Parent = (Form)Parent;
                }
                else if (parameter is InformationBoxOrder)
                {
                    // z-order
                    order = (InformationBoxOrder)parameter;
                }
            }
        }
        #endregion

        #region Show
        /// <summary>
        /// Shows this InformationBox.
        /// </summary>
        /// <returns>The result corresponding to the button clicked</returns>
        internal new InformationBoxResult Show()
        {
            SetCheckBox();
            SetButtons();
            SetText();
            SetIcon();
            SetLayout();
            SetFocus();
            SetPosition();
            SetWindowStyle();
            SetAutoClose();
            SetOpacity();
            PlaySound();
            SetOrder();

            if (behavior == InformationBoxBehavior.Modal)
            {
                ShowDialog();
            }
            else
            {
                base.Show();
            }

            return result;
        }

        /// <summary>
        /// Shows this InformationBox.
        /// </summary>
        /// <param name="state">The state of the checkbox.</param>
        /// <returns>The result corresponding to the button clicked</returns>
        internal InformationBoxResult Show(out CheckState state)
        {
            result = Show();
            state = kcbDoNotShow.CheckState;
            return result;
        }
        #endregion

        #region Sound
        /// <summary>
        /// Plays the sound associated with the icon type.
        /// </summary>
        private void PlaySound()
        {
            SystemSound sound;

            if (iconType == InformationBoxIconType.UserDefined)
            {
                sound = SystemSounds.Beep;
            }
            else
            {
                switch (IconHelper.GetCategory(icon))
                {
                    case InformationBoxMessageCategory.Asterisk:
                        sound = SystemSounds.Asterisk;
                        break;
                    case InformationBoxMessageCategory.Exclamation:
                        sound = SystemSounds.Exclamation;
                        break;
                    case InformationBoxMessageCategory.Hand:
                        sound = SystemSounds.Hand;
                        break;
                    case InformationBoxMessageCategory.Question:
                        sound = SystemSounds.Question;
                        break;
                    default:
                        sound = SystemSounds.Beep;
                        break;
                }
            }

            if (null != sound)
            {
                sound.Play();
            }
        }
        #endregion

        #region Box Initialisation
        // <summary>
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
                icon = parameters.Icon.Value;
            }

            if (parameters.CustomIcon != null)
            {
                iconType = InformationBoxIconType.UserDefined;
                customIcon = parameters.CustomIcon;
            }

            if (parameters.Buttons.HasValue)
            {
                buttons = parameters.Buttons.Value;
            }

            if (parameters.DefaultButton.HasValue)
            {
                defaultButton = parameters.DefaultButton.Value;
            }

            if (parameters.Layout.HasValue)
            {
                buttonsLayout = parameters.Layout.Value;
            }

            if (parameters.AutoSizeMode.HasValue)
            {
                autoSizeMode = parameters.AutoSizeMode.Value;
            }

            if (parameters.Position.HasValue)
            {
                position = parameters.Position.Value;
            }

            if (parameters.CheckBox.HasValue)
            {
                checkBox = parameters.CheckBox.Value;
            }

            if (parameters.Style.HasValue)
            {
                style = parameters.Style.Value;
            }

            if (parameters.AutoClose != null)
            {
                autoClose = parameters.AutoClose;
            }

            if (parameters.Design != null)
            {
                design = parameters.Design;
            }

            if (parameters.TitleIconStyle.HasValue)
            {
                titleStyle = parameters.TitleIconStyle.Value;
            }

            if (parameters.TitleIcon != null)
            {
                titleIcon = parameters.TitleIcon;
            }

            if (parameters.Behavior.HasValue)
            {
                behavior = parameters.Behavior.Value;
            }

            if (parameters.Opacity.HasValue)
            {
                opacity = parameters.Opacity.Value;
            }

            if (parameters.Help.HasValue)
            {
                showHelpButton = parameters.Help.Value;
            }

            if (parameters.HelpNavigator.HasValue)
            {
                helpNavigator = parameters.HelpNavigator.Value;
            }

            if (parameters.Order.HasValue)
            {
                order = parameters.Order.Value;
            }
        }

        #region Auto close

        /// <summary>
        /// Sets the auto close parameters.
        /// </summary>
        private void SetAutoClose()
        {
            if (null == autoClose)
            {
                return;
            }

            tmrAutoClose.Interval = 1000;
            tmrAutoClose.Tick += TmrAutoClose_Tick;
            tmrAutoClose.Start();
        }

        #endregion Auto close

        #region Opacity

        /// <summary>
        /// Sets the opacity.
        /// </summary>
        private void SetOpacity()
        {
            switch (opacity)
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
            if (style == InformationBoxStyle.Modern)
            {
                Color barsBackColor = Color.Black;
                Color formBackColor = Color.Silver;

                if (null != design)
                {
                    barsBackColor = design.BarsBackColor;
                    formBackColor = design.FormBackColor;
                }

                FormBorderStyle = FormBorderStyle.None;
                klblTitle.Visible = true;

                foreach (KryptonButton button in kpnlButtons.Controls)
                {
                    button.BackColor = barsBackColor;
                }
            }
            else if (style == InformationBoxStyle.Standard)
            {
                Color barsBackColor = SystemColors.Control;
                Color formBackColor = SystemColors.Control;

                if (null != design)
                {
                    barsBackColor = design.BarsBackColor;
                    formBackColor = design.FormBackColor;
                }

                FormBorderStyle = FormBorderStyle.FixedDialog;
                klblTitle.Visible = false;
                kpnlMain.Top -= klblTitle.Height;
                //kpnlButtons.SideBorder = SideBorder.None;
            }
        }

        #endregion Style

        #region CheckBox

        /// <summary>
        /// Sets the check box.
        /// </summary>
        private void SetCheckBox()
        {
            kcbDoNotShow.Text = Properties.Resources.DoNotShowText;

            kcbDoNotShow.Visible = ((checkBox & InformationBoxCheckBox.Show) == InformationBoxCheckBox.Show);
            kcbDoNotShow.Checked = ((checkBox & InformationBoxCheckBox.Checked) == InformationBoxCheckBox.Checked);
            //kcbDoNotShow.TextAlign = ((checkBox & InformationBoxCheckBox.RightAligned) == InformationBoxCheckBox.RightAligned)
            //                             ? ContentAlignment.BottomRight
            //                             : ContentAlignment.BottomLeft;
            //kcbDoNotShow.CheckAlign = ((checkBox & InformationBoxCheckBox.RightAligned) == InformationBoxCheckBox.RightAligned)
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
            if (position == InformationBoxPosition.CenterOnScreen)
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
            if (defaultButton == InformationBoxDefaultButton.Button1 && kpnlButtons.Controls.Count > 0)
            {
                kpnlButtons.Controls[0].Select();
            }

            if (defaultButton == InformationBoxDefaultButton.Button2 && kpnlButtons.Controls.Count > 1)
            {
                kpnlButtons.Controls[1].Select();
            }

            if (defaultButton == InformationBoxDefaultButton.Button3 && kpnlButtons.Controls.Count > 2)
            {
                kpnlButtons.Controls[2].Select();
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
            int captionWidth = Convert.ToInt32(measureGraphics.MeasureString(Text, SystemFonts.CaptionFont).Width) + 30;
            if (titleStyle != InformationBoxTitleIconStyle.None)
            {
                captionWidth += BORDER_PADDING * 2;
            }

            // "Do not show this dialog again" width
            int checkBoxWidth = ((checkBox & InformationBoxCheckBox.Show) == InformationBoxCheckBox.Show)
                                    ? (int)measureGraphics.MeasureString(kcbDoNotShow.Text, kcbDoNotShow.StateCommon.ShortText.Font).Width + BORDER_PADDING * 4
                                    : 0;

            // Width of the text and icon.
            int iconAndTextWidth = 0;

            // Minimum width to display all needed buttons.
            int buttonsMinWidth = (kpnlButtons.Controls.Count + 4) * BORDER_PADDING;
            foreach (Control ctrl in kpnlButtons.Controls)
            {
                buttonsMinWidth += ctrl.Width;
            }

            // Icon width
            if (icon != InformationBoxIcon.None || iconType == InformationBoxIconType.UserDefined)
            {
                iconAndTextWidth += ICON_PANEL_WIDTH;
            }

            // Text width
            iconAndTextWidth += kwlMessageText.Width + BORDER_PADDING * 2;

            // Gets the maximum size
            totalWidth = Math.Max(Math.Max(Math.Max(buttonsMinWidth, iconAndTextWidth), captionWidth), checkBoxWidth);

            #endregion Width

            #region Height

            if ((checkBox & InformationBoxCheckBox.Show) != InformationBoxCheckBox.Show)
            {
                kcbDoNotShow.Visible = false;
                kpnlBase.Height -= kcbDoNotShow.Height;
            }

            int iconHeight = 0;
            if (icon != InformationBoxIcon.None || iconType == InformationBoxIconType.UserDefined)
            {
                iconHeight = pbxIcon.Height;
            }

            int textHeight = kwlMessageText.Height;

            totalHeight = Math.Max(iconHeight, textHeight) + BORDER_PADDING * 2 + kpnlBase.Height;

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
                kwlMessageText.Top = BORDER_PADDING;
                verticalScroll = true;
            }

            kpnlContent.Size = new Size(Math.Min(Screen.PrimaryScreen.WorkingArea.Width - 20, totalWidth), totalHeight - kpnlBase.Height);

            if (style == InformationBoxStyle.Modern)
            {
                totalHeight += klblTitle.Height;
            }

            #endregion Height

            // Sets the size;
            ClientSize = new Size(Math.Min(Screen.PrimaryScreen.WorkingArea.Width - 20, totalWidth), totalHeight);

            #region Position

            // Set new position for all components
            // Icon
            pbxIcon.Left = BORDER_PADDING;
            pbxIcon.Top = BORDER_PADDING;

            // Text
            kpnlScrollText.Width = ClientSize.Width - ((icon != InformationBoxIcon.None || iconType == InformationBoxIconType.UserDefined)
                                       ? ICON_PANEL_WIDTH + BORDER_PADDING + 5
                                       : BORDER_PADDING);
            if (!verticalScroll)
            {
                kwlMessageText.Top = Convert.ToInt32((kpnlText.Height - kwlMessageText.Height) / 2);
            }

            // Buttons
            SetButtonsLayout();

            #endregion Position
        }

        /// <summary>
        /// Sets the buttons layout.
        /// </summary>
        private void SetButtonsLayout()
        {
            // Do not count the checkbox
            int buttonsCount = kpnlButtons.Controls.Count;
            int index = 0;
            int initialPosition = 0;
            int spaceBetween = 0;
            switch (buttonsLayout)
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
                        initialPosition += Convert.ToInt32((Width - buttonsCount * kpnlButtons.Controls[0].Width) / (buttonsCount + 1));
                    }
                    else
                    {
                        initialPosition = Convert.ToInt32((Width - (buttonsCount * (kpnlButtons.Controls[0].Width + BORDER_PADDING))) / 2);
                    }

                    break;
                case InformationBoxButtonsLayout.GroupRight:
                    spaceBetween = BORDER_PADDING;
                    initialPosition = ClientSize.Width - (buttonsCount * (kpnlButtons.Controls[0].Width + BORDER_PADDING));
                    break;
                case InformationBoxButtonsLayout.Separate:
                    spaceBetween = Convert.ToInt32((ClientSize.Width - buttonsCount * kpnlButtons.Controls[0].Width) / (buttonsCount + 1));
                    initialPosition = spaceBetween;
                    break;
                default:
                    break;
            }

            foreach (Control ctrl in kpnlButtons.Controls)
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
            if (iconType == InformationBoxIconType.Internal)
            {
                if (icon == InformationBoxIcon.None)
                {
                    kpnlIcon.Visible = false;
                    pbxIcon.Image = null;
                }
                else
                {
                    kpnlIcon.Visible = true;
                    pbxIcon.Image = IconHelper.FromEnum(icon).ToBitmap();
                }
            }
            else
            {
                pbxIcon.Image = customIcon.ToBitmap();
                kpnlIcon.Visible = true;
            }

            kpnlIcon.Width = ICON_PANEL_WIDTH;

            if (titleStyle == InformationBoxTitleIconStyle.None)
            {
                ShowIcon = false;
                Icon = Properties.Resources.blank;
            }
            else if (titleStyle == InformationBoxTitleIconStyle.SameAsBox)
            {
                if (iconType == InformationBoxIconType.Internal)
                {
                    Icon = IconHelper.FromEnum(icon);
                }
                else
                {
                    Icon = customIcon;
                }
            }
            else if (titleStyle == InformationBoxTitleIconStyle.Custom)
            {
                Icon = titleIcon;
            }
        }

        #endregion Icon

        #region Z-Order

        /// <summary>
        /// Sets the order.
        /// </summary>
        private void SetOrder()
        {
            if (order == InformationBoxOrder.TopMost)
            {
                TopMost = true;
            }
        }

        #endregion Z-Order

        #region Text

        /// <summary>
        /// Sets the text.
        /// </summary>
        private void SetText()
        {
            kwlMessageText.Text = kwlMessageText.Text.Replace("\n\r", "\n");
            kwlMessageText.Text = kwlMessageText.Text.Replace("\n", Environment.NewLine);

            Screen currentScreen = Screen.FromControl(this);
            int screenWidth = currentScreen.WorkingArea.Width;

            if (autoSizeMode == InformationBoxAutoSizeMode.None)
            {
                kwlMessageText.Size = measureGraphics.MeasureString(kwlMessageText.Text, kwlMessageText.Font, screenWidth / 2).ToSize();
            }
            else
            {
                internalText = new StringBuilder(kwlMessageText.Text);

                if (autoSizeMode == InformationBoxAutoSizeMode.MinimumHeight)
                {
                    // Remove line breaks.
                    internalText = internalText.Replace(Environment.NewLine, " ");
                    Regex splitter = new Regex(@"(?<sentence>.+?(\. |$))", RegexOptions.Compiled);
                    MatchCollection sentences = splitter.Matches(internalText.ToString());
                    StringBuilder formattedText = new StringBuilder();
                    int currentWidth = 0;

                    foreach (Match sentence in sentences)
                    {
                        int sentenceLength = (int)measureGraphics.MeasureString(sentence.Value, kwlMessageText.Font).Width;
                        if (currentWidth != 0 && (sentenceLength + currentWidth) > (screenWidth - 50))
                        {
                            formattedText.Append(Environment.NewLine);
                            currentWidth = 0;
                        }

                        currentWidth += sentenceLength;
                        formattedText.Append(sentence.Value);
                    }

                    internalText = formattedText;
                }
                else if (autoSizeMode == InformationBoxAutoSizeMode.MinimumWidth)
                {
                    internalText.Replace(". ", "." + Environment.NewLine);
                    internalText.Replace("? ", "?" + Environment.NewLine);
                    internalText.Replace("! ", "!" + Environment.NewLine);
                    internalText.Replace(": ", ":" + Environment.NewLine);
                    internalText.Replace(") ", ")" + Environment.NewLine);
                    internalText.Replace(", ", "," + Environment.NewLine);
                }

                kwlMessageText.Text = internalText.ToString();

                kwlMessageText.Size = measureGraphics.MeasureString(kwlMessageText.Text, kwlMessageText.Font).ToSize();
            }

            kwlMessageText.Width += BORDER_PADDING;
        }

        #endregion Text

        #region Buttons

        /// <summary>
        /// Sets the buttons, order of addition is respected.
        /// </summary>
        private void SetButtons()
        {
            // Abort button
            if (buttons == InformationBoxButtons.AbortRetryIgnore)
            {
                AddButton("Abort", Properties.Resources.AbortText);
            }

            // Ok
            if (buttons == InformationBoxButtons.OK ||
                buttons == InformationBoxButtons.OKCancel ||
                buttons == InformationBoxButtons.OKCancelUser1)
            {
                AddButton("OK", Properties.Resources.OkText);
            }

            // Yes
            if (buttons == InformationBoxButtons.YesNo ||
                buttons == InformationBoxButtons.YesNoCancel ||
                buttons == InformationBoxButtons.YesNoUser1)
            {
                AddButton("Yes", Properties.Resources.YesText);
            }

            // Retry
            if (buttons == InformationBoxButtons.AbortRetryIgnore ||
                buttons == InformationBoxButtons.RetryCancel)
            {
                AddButton("Retry", Properties.Resources.RetryText);
            }

            // No
            if (buttons == InformationBoxButtons.YesNo ||
                buttons == InformationBoxButtons.YesNoCancel ||
                buttons == InformationBoxButtons.YesNoUser1)
            {
                AddButton("No", Properties.Resources.NoText);
            }

            // Cancel
            if (buttons == InformationBoxButtons.OKCancel ||
                buttons == InformationBoxButtons.OKCancelUser1 ||
                buttons == InformationBoxButtons.RetryCancel ||
                buttons == InformationBoxButtons.YesNoCancel)
            {
                AddButton("Cancel", Properties.Resources.CancelText);
            }

            // Ignore
            if (buttons == InformationBoxButtons.AbortRetryIgnore)
            {
                AddButton("Ignore", Properties.Resources.IgnoreText);
            }

            // User1
            if (buttons == InformationBoxButtons.OKCancelUser1 ||
                buttons == InformationBoxButtons.User1User2 ||
                buttons == InformationBoxButtons.YesNoUser1 ||
                buttons == InformationBoxButtons.User1)
            {
                AddButton("User1", buttonUser1Text);
            }

            // User2
            if (buttons == InformationBoxButtons.User1User2)
            {
                AddButton("User2", buttonUser2Text);
            }

            // Help button is displayed when asked or when a help file name exists
            if (showHelpButton || !String.IsNullOrEmpty(helpFile))
            {
                AddButton("Help", Properties.Resources.HelpText);
            }

            SetButtonsSize();
        }

        /// <summary>
        /// Sets the buttons size.
        /// </summary>
        private void SetButtonsSize()
        {
            // All button will have the same size
            int maxSize = 0;

            // Measures the width of each button
            foreach (Control ctrl in kpnlButtons.Controls)
            {
                maxSize = Math.Max(Convert.ToInt32(measureGraphics.MeasureString(ctrl.Text, ctrl.Font).Width + 40), maxSize);
            }

            foreach (Control ctrl in kpnlButtons.Controls)
            {
                if (style == InformationBoxStyle.Standard)
                {
                    ctrl.Size = new Size(maxSize, 23);
                    ctrl.Top = 5;
                }
                else if (style == InformationBoxStyle.Modern)
                {
                    ctrl.Size = new Size(maxSize, kpnlButtons.Height);
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

            if (style == InformationBoxStyle.Modern)
            {
                buttonToAdd = new KryptonButton();
                //(buttonToAdd as KryptonButton).PersistantMode = false;
                (buttonToAdd as KryptonButton).Click += Button_Click;
            }
            else
            {
                buttonToAdd = new KryptonButton();
                (buttonToAdd as KryptonButton).Click += Button_Click;
            }

            buttonToAdd.Name = name;
            buttonToAdd.Text = text;
            kpnlButtons.Controls.Add(buttonToAdd);
        }

        #endregion Buttons

        #endregion

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
                    result = InformationBoxResult.Abort;
                    break;
                case "OK":
                    result = InformationBoxResult.OK;
                    break;
                case "Yes":
                    result = InformationBoxResult.Yes;
                    break;
                case "Retry":
                    result = InformationBoxResult.Retry;
                    break;
                case "No":
                    result = InformationBoxResult.No;
                    break;
                case "Cancel":
                    result = InformationBoxResult.Cancel;
                    break;
                case "Ignore":
                    result = InformationBoxResult.Ignore;
                    break;
                case "User1":
                    result = InformationBoxResult.User1;
                    break;
                case "User2":
                    result = InformationBoxResult.User2;
                    break;
                default:
                    result = InformationBoxResult.None;
                    break;
            }

            if (senderControl.Name.Equals("Help"))
            {
                OpenHelp();
            }
            else
            {
                DialogResult = DialogResult.OK;
                if (behavior == InformationBoxBehavior.Modeless)
                {
                    Close();
                }
            }
        }
        #endregion

        #region Help
        /// <summary>
        /// Opens the help.
        /// </summary>
        private void OpenHelp()
        {
            // If there is an active form
            if (null != activeForm)
            {
                MethodInfo met = activeForm.GetType().GetMethod("OnHelpRequested", BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
                if (null != met)
                {
                    // Call for help on the active form.
                    met.Invoke(activeForm, new object[] { new HelpEventArgs(MousePosition) });
                }
            }

            // If a help file is specified
            if (!String.IsNullOrEmpty(helpFile))
            {
                // If no topic is specified
                if (String.IsNullOrEmpty(helpTopic))
                {
                    Help.ShowHelp(activeForm, helpFile, helpNavigator);
                }
                else
                {
                    Help.ShowHelp(activeForm, helpFile, helpTopic);
                }
            }
        }
        #endregion

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
                ControlPaint.DrawBorder(e.Graphics, kpnlContent.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
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
            if (elapsedTime == autoClose.Seconds)
            {
                tmrAutoClose.Stop();

                switch (autoClose.Mode)
                {
                    case AutoCloseDefinedParameters.Button:
                        if (autoClose.DefaultButton == InformationBoxDefaultButton.Button1 && kpnlButtons.Controls.Count > 0)
                        {
                            HandleButton(kpnlButtons.Controls[0]);
                        }
                        else if (autoClose.DefaultButton == InformationBoxDefaultButton.Button2 && kpnlButtons.Controls.Count > 1)
                        {
                            HandleButton(kpnlButtons.Controls[1]);
                        }
                        else if (autoClose.DefaultButton == InformationBoxDefaultButton.Button3 && kpnlButtons.Controls.Count > 2)
                        {
                            HandleButton(kpnlButtons.Controls[2]);
                        }

                        return;
                    case AutoCloseDefinedParameters.TimeOnly:
                        if (defaultButton == InformationBoxDefaultButton.Button1 && kpnlButtons.Controls.Count > 0)
                        {
                            HandleButton(kpnlButtons.Controls[0]);
                        }
                        else if (defaultButton == InformationBoxDefaultButton.Button2 && kpnlButtons.Controls.Count > 1)
                        {
                            HandleButton(kpnlButtons.Controls[1]);
                        }
                        else if (defaultButton == InformationBoxDefaultButton.Button3 && kpnlButtons.Controls.Count > 2)
                        {
                            HandleButton(kpnlButtons.Controls[2]);
                        }

                        return;
                    case AutoCloseDefinedParameters.Result:
                        result = autoClose.Result;
                        DialogResult = DialogResult.OK;
                        return;
                    default:
                        break;
                }
            }
            else
            {
                Control buttonToUpdate = null;
                if (autoClose.Mode == AutoCloseDefinedParameters.Button)
                {
                    if (autoClose.DefaultButton == InformationBoxDefaultButton.Button1 && kpnlButtons.Controls.Count > 0)
                    {
                        buttonToUpdate = kpnlButtons.Controls[0];
                    }
                    else if (autoClose.DefaultButton == InformationBoxDefaultButton.Button2 && kpnlButtons.Controls.Count > 1)
                    {
                        buttonToUpdate = kpnlButtons.Controls[1];
                    }
                    else if (autoClose.DefaultButton == InformationBoxDefaultButton.Button3 && kpnlButtons.Controls.Count > 2)
                    {
                        buttonToUpdate = kpnlButtons.Controls[2];
                    }
                }
                else
                {
                    if (defaultButton == InformationBoxDefaultButton.Button1 && kpnlButtons.Controls.Count > 0)
                    {
                        buttonToUpdate = kpnlButtons.Controls[0];
                    }
                    else if (defaultButton == InformationBoxDefaultButton.Button2 && kpnlButtons.Controls.Count > 1)
                    {
                        buttonToUpdate = kpnlButtons.Controls[1];
                    }
                    else if (defaultButton == InformationBoxDefaultButton.Button3 && kpnlButtons.Controls.Count > 2)
                    {
                        buttonToUpdate = kpnlButtons.Controls[2];
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
                            button.Text = String.Format(CultureInfo.InvariantCulture, "{0} ({1})", button.Text.Substring(0, button.Text.LastIndexOf(" (", StringComparison.OrdinalIgnoreCase)), autoClose.Seconds - elapsedTime);
                        }
                        else
                        {
                            button.Text = String.Format(CultureInfo.InvariantCulture, "{0} ({1})", button.Text, autoClose.Seconds - elapsedTime);
                        }
                    }
                    else if (buttonToUpdate is KryptonButton)
                    {
                        KryptonButton button = (KryptonButton)buttonToUpdate;
                        if (extractLabel.IsMatch(button.Text))
                        {
                            button.Text = String.Format(CultureInfo.InvariantCulture, "{0} ({1})", button.Text.Substring(0, button.Text.LastIndexOf(" (", StringComparison.OrdinalIgnoreCase)), autoClose.Seconds - elapsedTime);
                        }
                        else
                        {
                            button.Text = String.Format(CultureInfo.InvariantCulture, "{0} ({1})", button.Text, autoClose.Seconds - elapsedTime);
                        }
                    }
                }
            }

            elapsedTime++;
        }

        #endregion Event handling

    }
}