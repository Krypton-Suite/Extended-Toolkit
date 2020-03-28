using Krypton.Toolkit.Extended.Wizard.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Krypton.Toolkit.Extended.Wizard
{
    /// <summary>Styles that can be applied to the body of a <see cref="WizardControl"/> when on XP or earlier or when a Basic theme is applied.</summary>
    public enum WizardClassicStyle
    {
        /// <summary>Windows Vista style theme with large fonts and white background.</summary>
        AeroStyle,

        AeroKryptonStyle,

        /// <summary>Windows XP style theme with control color background.</summary>
        BasicStyle,

        /// <summary>Use <see cref="BasicStyle"/> on Windows XP and <see cref="AeroStyle"/> for later versions.</summary>
        Automatic,

        KryptonStyle
    }

    /// <summary>Control providing an "Aero Wizard" style interface.</summary>
    [Designer(typeof(WizardControlDesigner))]
    [ToolboxItem(true), ToolboxBitmap(typeof(WizardControl), "Resources\\WizardControl.bmp")]
    [Description("Creates an Aero Wizard interface.")]
    [DefaultProperty("Pages"), DefaultEvent("SelectedPageChanged")]
    public partial class WizardControl :
#if DEBUG
        UserControl
#else
		Control
#endif
        , ISupportInitialize
    {
        #region Designer Code
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.titleImageList = new System.Windows.Forms.ImageList(this.components);
            this.commandAreaBorder = new System.Windows.Forms.Panel();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.contentArea = new ThemedTableLayoutPanel();
            this.pageContainer = new WizardPageContainer();
            this.backButton = new ThemedImageButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.header = new ThemedTableLayoutPanel();
            this.headerLabel = new System.Windows.Forms.Label();
            this.commandArea = new ThemedTableLayoutPanel();
            this.commandAreaButtonFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.titleBar = new ThemedTableLayoutPanel();
            this.title = new ThemedLabel();
            this.titleImage = new ThemedLabel();
            this.bodyPanel.SuspendLayout();
            this.contentArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageContainer)).BeginInit();
            this.header.SuspendLayout();
            this.commandArea.SuspendLayout();
            this.commandAreaButtonFlowLayout.SuspendLayout();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleImageList
            // 
            this.titleImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.titleImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.titleImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // commandAreaBorder
            // 
            this.commandAreaBorder.BackColor = System.Drawing.SystemColors.ControlLight;
            this.commandAreaBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandAreaBorder.Location = new System.Drawing.Point(0, 368);
            this.commandAreaBorder.Margin = new System.Windows.Forms.Padding(0);
            this.commandAreaBorder.Name = "commandAreaBorder";
            this.commandAreaBorder.Size = new System.Drawing.Size(609, 1);
            this.commandAreaBorder.TabIndex = 2;
            // 
            // bodyPanel
            // 
            this.bodyPanel.Controls.Add(this.contentArea);
            this.bodyPanel.Controls.Add(this.header);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(0, 32);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(609, 336);
            this.bodyPanel.TabIndex = 1;
            // 
            // contentArea
            // 
            this.contentArea.BackColor = System.Drawing.SystemColors.Window;
            this.contentArea.ColumnCount = 3;
            this.contentArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.contentArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.contentArea.Controls.Add(this.pageContainer, 1, 0);
            this.contentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentArea.Location = new System.Drawing.Point(0, 59);
            this.contentArea.Name = "contentArea";
            this.contentArea.RowCount = 2;
            this.contentArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.contentArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.contentArea.Size = new System.Drawing.Size(609, 277);
            this.contentArea.TabIndex = 1;
            this.contentArea.Paint += new System.Windows.Forms.PaintEventHandler(this.contentArea_Paint);
            // 
            // pageContainer
            // 
            this.pageContainer.BackButton = this.backButton;
            this.pageContainer.BackButtonText = "";
            this.pageContainer.CancelButton = this.cancelButton;
            this.pageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageContainer.Location = new System.Drawing.Point(38, 0);
            this.pageContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pageContainer.Name = "pageContainer";
            this.pageContainer.NextButton = this.nextButton;
            this.pageContainer.Size = new System.Drawing.Size(552, 258);
            this.pageContainer.TabIndex = 0;
            this.pageContainer.ButtonStateChanged += new System.EventHandler(this.pageContainer_ButtonStateChanged);
            this.pageContainer.Cancelling += new System.ComponentModel.CancelEventHandler(this.pageContainer_Cancelling);
            this.pageContainer.Finished += new System.EventHandler(this.pageContainer_Finished);
            this.pageContainer.SelectedPageChanged += new System.EventHandler(this.pageContainer_SelectedPageChanged);
            // 
            // backButton
            // 
            this.backButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.backButton.Enabled = false;
            this.backButton.Image = null;
            this.backButton.Location = new System.Drawing.Point(0, 0);
            this.backButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(30, 30);
            this.backButton.StyleClass = "NAVIGATION";
            this.backButton.TabIndex = 0;
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.AutoSize = true;
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.Location = new System.Drawing.Point(520, 0);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.cancelButton.MinimumSize = new System.Drawing.Size(70, 15);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(70, 25);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Tag = WizardCommandButtonState.Disabled;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.AutoSize = true;
            this.nextButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nextButton.Location = new System.Drawing.Point(443, 0);
            this.nextButton.Margin = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.nextButton.MinimumSize = new System.Drawing.Size(70, 15);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(70, 23);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "&Next";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.BackColor = System.Drawing.SystemColors.Window;
            this.header.ColumnCount = 1;
            this.header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.header.Controls.Add(this.headerLabel, 0, 0);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.RowCount = 1;
            this.header.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.header.Size = new System.Drawing.Size(609, 59);
            this.header.TabIndex = 0;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(112)))), ((int)(((byte)(171)))));
            this.headerLabel.Location = new System.Drawing.Point(38, 19);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(38, 19, 0, 19);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(77, 21);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Page Title";
            // 
            // commandArea
            // 
            this.commandArea.AutoSize = true;
            this.commandArea.BackColor = System.Drawing.SystemColors.Control;
            this.commandArea.ColumnCount = 2;
            this.commandArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.commandArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.commandArea.Controls.Add(this.commandAreaButtonFlowLayout, 0, 1);
            this.commandArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandArea.Location = new System.Drawing.Point(0, 369);
            this.commandArea.Name = "commandArea";
            this.commandArea.RowCount = 3;
            this.commandArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.commandArea.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.commandArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.commandArea.Size = new System.Drawing.Size(609, 45);
            this.commandArea.TabIndex = 3;
            // 
            // commandAreaButtonFlowLayout
            // 
            this.commandAreaButtonFlowLayout.AutoSize = true;
            this.commandAreaButtonFlowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.commandAreaButtonFlowLayout.BackColor = System.Drawing.Color.Transparent;
            this.commandAreaButtonFlowLayout.Controls.Add(this.cancelButton);
            this.commandAreaButtonFlowLayout.Controls.Add(this.nextButton);
            this.commandAreaButtonFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandAreaButtonFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.commandAreaButtonFlowLayout.Location = new System.Drawing.Point(0, 10);
            this.commandAreaButtonFlowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.commandAreaButtonFlowLayout.MinimumSize = new System.Drawing.Size(0, 23);
            this.commandAreaButtonFlowLayout.Name = "commandAreaButtonFlowLayout";
            this.commandAreaButtonFlowLayout.Size = new System.Drawing.Size(590, 25);
            this.commandAreaButtonFlowLayout.TabIndex = 2;
            this.commandAreaButtonFlowLayout.WrapContents = false;
            // 
            // titleBar
            // 
            this.titleBar.AutoSize = true;
            this.titleBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.titleBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.titleBar.ColumnCount = 3;
            this.titleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.titleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.titleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.titleBar.Controls.Add(this.title, 2, 0);
            this.titleBar.Controls.Add(this.titleImage, 1, 0);
            this.titleBar.Controls.Add(this.backButton, 0, 0);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.RowCount = 1;
            this.titleBar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.titleBar.Size = new System.Drawing.Size(609, 32);
            this.titleBar.SupportGlass = true;
            this.titleBar.TabIndex = 0;
            this.titleBar.WatchFocus = true;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            this.titleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.title.AutoSize = true;
            this.title.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.title.Location = new System.Drawing.Point(55, 6);
            this.title.Margin = new System.Windows.Forms.Padding(0);
            this.title.Name = "title";
            this.title.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.title.Size = new System.Drawing.Size(79, 19);
            this.title.TabIndex = 2;
            this.title.Text = "Wizard Title";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleImage
            // 
            this.titleImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.titleImage.AutoSize = true;
            this.titleImage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.titleImage.ImageList = this.titleImageList;
            this.titleImage.Location = new System.Drawing.Point(32, 8);
            this.titleImage.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.titleImage.MinimumSize = new System.Drawing.Size(16, 16);
            this.titleImage.Name = "titleImage";
            this.titleImage.Size = new System.Drawing.Size(16, 16);
            this.titleImage.TabIndex = 1;
            // 
            // WizardControl
            // 
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.commandAreaBorder);
            this.Controls.Add(this.commandArea);
            this.Controls.Add(this.titleBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WizardControl";
            this.Size = new System.Drawing.Size(609, 414);
            this.bodyPanel.ResumeLayout(false);
            this.bodyPanel.PerformLayout();
            this.contentArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageContainer)).EndInit();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.commandArea.ResumeLayout(false);
            this.commandArea.PerformLayout();
            this.commandAreaButtonFlowLayout.ResumeLayout(false);
            this.commandAreaButtonFlowLayout.PerformLayout();
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private ThemedTableLayoutPanel titleBar;
        private ThemedTableLayoutPanel header;
        internal System.Windows.Forms.Label headerLabel;
        private ThemedTableLayoutPanel commandArea;
        private System.Windows.Forms.Button cancelButton;
        internal System.Windows.Forms.Button nextButton;
        private ThemedLabel title;
        private ThemedLabel titleImage;
        internal ThemedImageButton backButton;
        private System.Windows.Forms.Panel commandAreaBorder;
        private System.Windows.Forms.ImageList titleImageList;
        private System.Windows.Forms.Panel bodyPanel;
        private ThemedTableLayoutPanel contentArea;
        internal WizardPageContainer pageContainer;
        private System.Windows.Forms.FlowLayoutPanel commandAreaButtonFlowLayout;
        #endregion

        private static readonly bool isMin6 = Environment.OSVersion.Version.Major >= 6;

        private WizardClassicStyle classicStyle = WizardClassicStyle.AeroStyle;
        private Point formMoveLastMousePos;
        private bool formMoveTracking;
        private Form parentForm;
        private bool themePropsSet;
        private Icon titleImageIcon;
        private bool titleImageIconSet;

        internal int contentCol = 1;

        /// <summary>Initializes a new instance of the <see cref="WizardControl"/> class.</summary>
        public WizardControl()
        {
            InitializeComponent();

            OnRightToLeftChanged(EventArgs.Empty);

            // Get localized defaults for button text
            ResetBackButtonToolTipText();
            ResetTitle();
            ResetTitleIcon();

            // Connect to page add and remove events to track property changes
            Pages.ItemAdded += Pages_ItemAdded;
            Pages.ItemDeleted += Pages_ItemDeleted;
        }

        /// <summary>Occurs when the user clicks the Cancel button and allows for programmatic cancellation.</summary>
        [Category("Behavior"), Description("Occurs when the user clicks the Cancel button and allows for programmatic cancellation.")]
        public event CancelEventHandler Cancelling;

        /// <summary>
        /// Occurs when the user clicks the Next/Finish button and the page is set to <see cref="WizardPage.IsFinishPage"/> or this is the last page in the
        /// <see cref="Pages"/> collection.
        /// </summary>
        [Category("Behavior"), Description("Occurs when the user clicks the Next/Finish button on last page.")]
        public event EventHandler Finished;

        /// <summary>Occurs when the <see cref="WizardControl.SelectedPage"/> property has changed.</summary>
        [Category("Property Changed"), Description("Occurs when the SelectedPage property has changed.")]
        public event EventHandler SelectedPageChanged;

        /// <summary>Gets or sets the state of the back button.</summary>
        /// <value>The state of the back button.</value>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WizardCommandButtonState BackButtonState => pageContainer.BackButtonState;

        /// <summary>Gets or sets the back button tool tip text.</summary>
        /// <value>The back button tool tip text.</value>
        [Category("Wizard"), Localizable(true), Description("The back button tool tip text")]
        public string BackButtonToolTipText
        {
            get => backButton.ToolTipText;
            set { backButton.ToolTipText = value; Invalidate(); }
        }

        /// <summary>Gets the state of the cancel button.</summary>
        /// <value>The state of the cancel button.</value>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WizardCommandButtonState CancelButtonState => pageContainer.CancelButtonState;

        /// <summary>Gets or sets the cancel button text.</summary>
        /// <value>The cancel button text.</value>
        [Category("Wizard"), Localizable(true), Description("The cancel button text")]
        public string CancelButtonText
        {
            get => pageContainer.CancelButtonText;
            set { pageContainer.CancelButtonText = value; Refresh(); }
        }

        /// <summary>Gets or sets the value of the Cancel button's <see cref="Control.CausesValidation"/> property.</summary>
        /// <value>The value of the Cancel button's <see cref="Control.CausesValidation"/> property.</value>
        [Category("Focus"), DefaultValue(true), Description("The cancel button causes validation.")]
        public bool CancelCausesValidation
        {
            get => cancelButton.CausesValidation;
            set => cancelButton.CausesValidation = value;
        }

        /// <summary>Gets or sets the style applied to the body of a <see cref="WizardControl"/> when on XP or earlier or when a Basic theme is applied.</summary>
        /// <value>A <see cref="WizardClassicStyle"/> value which determines the style.</value>
        [Category("Wizard"), DefaultValue(typeof(WizardClassicStyle), "AeroStyle"), Description("The style used in Windows Classic mode or on Windows XP")]
        public WizardClassicStyle ClassicStyle
        {
            get => classicStyle;
            set { classicStyle = value; ConfigureStyles(); Invalidate(); }
        }

        /// <summary>Gets or sets the finish button text.</summary>
        /// <value>The finish button text.</value>
        [Category("Wizard"), Localizable(true), Description("The finish button text")]
        public string FinishButtonText
        {
            get => pageContainer.FinishButtonText;
            set { pageContainer.FinishButtonText = value; Refresh(); }
        }

        /// <summary>Gets or sets the page header text.</summary>
        /// <value>The page header text.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HeaderText
        {
            get => headerLabel.Text;
            set { headerLabel.Text = value; Refresh(); }
        }

        /// <summary>Gets or sets the shield icon on the next button.</summary>
        /// <value><c>true</c> if Next button should display a shield; otherwise, <c>false</c>.</value>
        /// <exception cref="PlatformNotSupportedException">Setting a UAF shield on a button only works on Vista and later versions of Windows.</exception>
        [DefaultValue(false), Category("Wizard"), Description("Show a shield icon on the next button")]
        public bool NextButtonShieldEnabled
        {
            get => pageContainer.NextButtonShieldEnabled;
            set => pageContainer.NextButtonShieldEnabled = value;
        }

        /// <summary>Gets the state of the next button.</summary>
        /// <value>The state of the next button.</value>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WizardCommandButtonState NextButtonState => pageContainer.NextButtonState;

        /// <summary>Gets or sets the next button text.</summary>
        /// <value>The next button text.</value>
        [Category("Wizard"), Localizable(true), Description("The next button text.")]
        public string NextButtonText
        {
            get => pageContainer.NextButtonText;
            set { pageContainer.NextButtonText = value; Refresh(); }
        }

        /// <summary>Gets the collection of wizard pages in this wizard control.</summary>
        /// <value>The <see cref="WizardPageCollection"/> that contains the <see cref="WizardPage"/> objects in this <see cref="WizardControl"/>.</value>
        [Category("Wizard"), Description("Collection of wizard pages.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public WizardPageCollection Pages => pageContainer.Pages;

        /// <summary>Gets how far the wizard has progressed, as a percentage.</summary>
        /// <value>A value between 0 and 100.</value>
        [Browsable(false), Description("The percentage of the current page against all pages at run-time.")]
        public short PercentComplete => pageContainer.PercentComplete;

        /// <summary>Gets the currently selected wizard page.</summary>
        /// <value>The selected wizard page. <c>null</c> if no page is active.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual WizardPage SelectedPage
        {
            get => pageContainer.SelectedPage;
            internal set { pageContainer.SelectedPage = value; if (value != null) HeaderText = value.Text; }
        }

        /// <summary>Gets or sets a value indicating whether to show progress in form's taskbar icon.</summary>
        /// <remarks>This will only work on Windows 7 or later and the parent form must be showing its icon in the taskbar. No exception is thrown on failure.</remarks>
        /// <value><c>true</c> to show progress in taskbar icon; otherwise, <c>false</c>.</value>
        [Category("Wizard"), DefaultValue(false), Description("Indicates whether to show progress in form's taskbar icon")]
        public bool ShowProgressInTaskbarIcon
        {
            get => pageContainer.ShowProgressInTaskbarIcon;
            set => pageContainer.ShowProgressInTaskbarIcon = value;
        }

        /// <summary>Gets or sets a value indicating whether to suppress changing the parent form's icon to match the wizard's <see cref="TitleIcon"/>.</summary>
        /// <value><c>true</c> to not change the parent form's icon to match this wizard's icon; otherwise, <c>false</c>.</value>
        [Category("Wizard"), DefaultValue(false), Description("Indicates whether to suppress changing the parent form's icon to match the wizard's")]
        public bool SuppressParentFormIconSync { get; set; }

        /// <summary>Gets or sets a value indicating whether to suppress changing the parent form's caption to match the wizard's <see cref="Title"/>.</summary>
        /// <value><c>true</c> to not change the parent form's caption (Text) to match this wizard's title; otherwise, <c>false</c>.</value>
        [Category("Wizard"), DefaultValue(false), Description("Indicates whether to suppress changing the parent form's caption to match the wizard's")]
        public bool SuppressParentFormCaptionSync { get; set; }

        /// <summary>Gets or sets the title for the wizard.</summary>
        /// <value>The title text.</value>
        [Category("Wizard"), Localizable(true), Description("Title for the wizard")]
        public string Title
        {
            get => title.Text;
            set { title.Text = value; Invalidate(); }
        }

        /// <summary>Gets or sets the optionally displayed icon next to the wizard title.</summary>
        /// <value>The title icon.</value>
        [Category("Wizard"), Localizable(true), Description("Icon next to the wizard title")]
        public Icon TitleIcon
        {
            get => titleImageIcon;
            set
            {
                titleImageIcon = value;
                titleImageList.Images.Clear();
                if (titleImageIcon != null)
                {
                    // Resolve for different DPI settings and ensure that if icon is not a standard size, such as 20x20, that the larger one (24x24) is downsized
                    // and not the smaller up-sized. (thanks demidov)
                    titleImage.Size = titleImageList.ImageSize = SystemInformation.SmallIconSize;
                    titleImageList.Images.Add(new Icon(value, SystemInformation.SmallIconSize + new Size(1, 1)));
                    titleImage.ImageIndex = 0;
                }
                titleImageIconSet = true;
                Invalidate();
            }
        }

        internal int SelectedPageIndex => pageContainer.SelectedPageIndex;

        private bool UseAeroStyle => classicStyle == WizardClassicStyle.AeroStyle || (classicStyle == WizardClassicStyle.Automatic && DesktopWindowManager.CompositionSupported && Application.RenderWithVisualStyles);

        /// <summary>Adds a new control to the command bar.</summary>
        /// <remarks>
        /// This will cause your wizard to deviate from the Windows UI guidelines. All controls will display right to left in the order added and will cause the
        /// command bar to remain visible as long as the control is visible. The developer must fully manage the state of this added control.
        /// </remarks>
        /// <param name="ctrl">The control to add.</param>
        public void AddCommandControl(Control ctrl)
        {
            commandAreaButtonFlowLayout.Controls.Add(ctrl);
        }

        /// <summary>Signals the object that initialization is starting.</summary>
        public void BeginInit()
        {
            pageContainer.BeginInit();
        }

        /// <summary>Signals the object that initialization is complete.</summary>
        public void EndInit()
        {
            pageContainer.EndInit();
        }

        /// <summary>Advances to the specified page.</summary>
        /// <param name="nextPage">The wizard page to go to next.</param>
        /// <param name="skipCommit">if set to <c>true</c> skip <see cref="WizardPage.Commit"/> event.</param>
        /// <exception cref="ArgumentException">When specifying a value for nextPage, it must already be in the Pages collection.</exception>
        public virtual void NextPage(WizardPage nextPage = null, bool skipCommit = false)
        {
            pageContainer.NextPage(nextPage, skipCommit);
        }

        /// <summary>Overrides the theme fonts provided by the system.</summary>
        /// <remarks>
        /// This is NOT recommended as it will cause the wizard to not match those provided by the system. This should be called only after the handle has been
        /// created or it will be overridden with the system theme values.
        /// </remarks>
        /// <param name="titleFont">The title font.</param>
        /// <param name="headerFont">The header font.</param>
        /// <param name="buttonFont">The command buttons font.</param>
        public virtual void OverrideThemeFonts(Font titleFont, Font headerFont, Font buttonFont)
        {
            title.Font = titleFont;
            headerLabel.Font = headerFont;
            foreach (Control ctrl in commandAreaButtonFlowLayout.Controls)
            {
                ctrl.Font = buttonFont;
            }
        }

        /// <summary>Returns to the previous page.</summary>
        public virtual void PreviousPage()
        {
            pageContainer.PreviousPage();
        }

        /// <summary>Restarts the wizard pages from the first page.</summary>
        public void RestartPages()
        {
            pageContainer.RestartPages();
        }

        /// <summary>Gets the unthemed back button image.</summary>
        /// <returns><see cref="Bitmap"/> with the four state images stacked on top of each other.</returns>
        protected virtual Bitmap GetUnthemedBackButtonImage() => Environment.OSVersion.Version >= new Version(6, 2) ? Resources.BackBtnStrip2 : Resources.BackBtnStrip;

        /// <summary>Raises the <see cref="WizardControl.Cancelling"/> event.</summary>
        /// <param name="arg">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        protected virtual void OnCancelling(CancelEventArgs arg)
        {
            Cancelling?.Invoke(this, arg);

            if (arg.Cancel && !this.IsDesignMode()) CloseForm(DialogResult.Cancel);
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.ControlAdded"/> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs"/> that contains the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (!(e.Control is WizardPage page)) return;
            Controls.Remove(page);
            Pages.Add(page);
        }

        /// <summary>Raises the <see cref="WizardControl.Finished"/> event.</summary>
        protected virtual void OnFinished()
        {
            Finished?.Invoke(this, EventArgs.Empty);

            if (!this.IsDesignMode())
                CloseForm(DialogResult.OK);
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"/> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            pageContainer.Focus();
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated"/> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnHandleCreated");
            base.OnHandleCreated(e);
            SetLayout();
            AddSystemEvents();
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.HandleDestroyed"/> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            RemoveSystemEvents();
            base.OnHandleDestroyed(e);
        }

        private void AddSystemEvents()
        {
            if (this.IsDesignMode()) return;
            if (DesktopWindowManager.CompositionSupported)
            {
                DesktopWindowManager.ColourisationColourChanged += DisplyColourOrCompositionChanged;
                DesktopWindowManager.CompositionChanged += DisplyColourOrCompositionChanged;
            }
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += DisplyColourOrCompositionChanged;
            SystemColorsChanged += DisplyColourOrCompositionChanged;
        }

        private void RemoveSystemEvents()
        {
            if (this.IsDesignMode()) return;
            if (DesktopWindowManager.CompositionSupported)
            {
                DesktopWindowManager.CompositionChanged -= DisplyColourOrCompositionChanged;
                DesktopWindowManager.ColourisationColourChanged -= DisplyColourOrCompositionChanged;
            }
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged -= DisplyColourOrCompositionChanged;
            SystemColorsChanged -= DisplyColourOrCompositionChanged;
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.ParentChanged"/> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (parentForm != null)
                parentForm.Load -= parentForm_Load;
            parentForm = Parent as Form; // FindForm();
            Dock = DockStyle.Fill;
            if (parentForm != null)
                parentForm.Load += parentForm_Load;
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.RightToLeftChanged"/> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            var r2l = this.GetRightToLeftProperty() == RightToLeft.Yes;
            var btnStrip = GetUnthemedBackButtonImage();
            if (r2l) btnStrip.RotateFlip(RotateFlipType.RotateNoneFlipX);
            backButton.SetImageListImageStrip(btnStrip, Orientation.Vertical);
            backButton.StylePart = r2l ? 2 : 1;
        }

        /// <summary>Raises the <see cref="WizardControl.SelectedPageChanged"/> event.</summary>
        protected void OnSelectedPageChanged()
        {
            SelectedPageChanged?.Invoke(this, EventArgs.Empty);
        }

        private void CloseForm(DialogResult dlgResult)
        {
            var form = FindForm();
            if (form == null) return;
            if (form.Modal)
                form.DialogResult = dlgResult;
            else
                form.Close();
        }

        private void ConfigureStyles()
        {
            if (Application.RenderWithVisualStyles)
            {
                titleBar.SetTheme(VisualStyleElementEx.AeroWizard.TitleBar.Active);
                header.SetTheme(VisualStyleElementEx.AeroWizard.HeaderArea.Normal);
                contentArea.SetTheme(VisualStyleElementEx.AeroWizard.ContentArea.Normal);
                commandArea.SetTheme(VisualStyleElementEx.AeroWizard.CommandArea.Normal);
            }
            else
            {
                titleBar.ClearTheme();
                header.ClearTheme();
                contentArea.ClearTheme();
                commandArea.ClearTheme();
                titleBar.BackColor = SystemColors.Control;
            }

            if (UseAeroStyle)
            {
                bodyPanel.BorderStyle = BorderStyle.None;
                header.BackColor = contentArea.BackColor = SystemColors.Window;
                if (themePropsSet) return;
                headerLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                headerLabel.ForeColor = Color.FromArgb(19, 112, 171);
                title.Font = Font;
            }
            else
            {
                bodyPanel.BorderStyle = BorderStyle.FixedSingle;
                header.BackColor = contentArea.BackColor = SystemColors.Control;
                headerLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                headerLabel.ForeColor = SystemColors.ControlText;
                title.Font = new Font(Font, FontStyle.Bold);
            }
        }

        private void ConfigureWindowFrame()
        {
            System.Diagnostics.Debug.WriteLine($"ConfigureWindowFrame: compEnab={DesktopWindowManager.IsCompositionEnabled()},parentForm={(parentForm == null ? "null" : parentForm.Name)}");
            ConfigureStyles();
            if (DesktopWindowManager.IsCompositionEnabled())
            {
                titleBar.BackColor = Color.Black;
                try
                {
                    //if (!parentForm.GetWindowAttribute<bool>(DesktopWindowManager.GetWindowAttr.NonClientRenderingEnabled))
                    //	parentForm.SetWindowAttribute(DesktopWindowManager.SetWindowAttr.NonClientRenderingPolicy, DesktopWindowManager.NonClientRenderingPolicy.Enabled);
                    //parentForm.ExtendFrameIntoClientArea(new Padding(0));
                    //NativeMethods.SetWindowPos(this.Handle, IntPtr.Zero, this.Location.X, this.Location.Y, this.Width, this.Height, NativeMethods.SetWindowPosFlags.FrameChanged);
                    parentForm?.ExtendFrameIntoClientArea(new Padding(0) { Top = titleBar.Visible ? titleBar.Height : 0 });
                }
                catch
                {
                    titleBar.BackColor = commandArea.BackColor;
                }
            }
            else
            {
                titleBar.BackColor = commandArea.BackColor;
            }

            if (parentForm == null) return;
            if (!SuppressParentFormCaptionSync)
                parentForm.Text = Title;
            if (!SuppressParentFormIconSync && titleImageIcon != null)
            {
                parentForm.Icon = TitleIcon;
                parentForm.ShowIcon = true;
            }
            parentForm.CancelButton = cancelButton;
            parentForm.AcceptButton = nextButton;
            parentForm.AutoScaleMode = AutoScaleMode.Font;
            parentForm.SetWindowThemeAttribute(NativeMethods.WindowThemeNonClientAttributes.NoDrawCaption | NativeMethods.WindowThemeNonClientAttributes.NoDrawIcon | NativeMethods.WindowThemeNonClientAttributes.NoSysMenu);
            parentForm.Invalidate();
        }

        private void contentArea_Paint(object sender, PaintEventArgs pe)
        {
            if (!this.IsDesignMode() || Pages.Count != 0) return;
            var noPagesText = Properties.Resources.WizardNoPagesNotice;
            var r = GetContentAreaRectangle(false);

            r.Inflate(-2, -2);
            //pe.Graphics.DrawRectangle(SystemPens.GrayText, r);
            ControlPaint.DrawFocusRectangle(pe.Graphics, r);

            var textSize = pe.Graphics.MeasureString(noPagesText, Font);
            r.Inflate((r.Width - (int)textSize.Width) / -2, (r.Height - (int)textSize.Height) / -2);
            pe.Graphics.DrawString(noPagesText, Font, SystemBrushes.GrayText, r);
        }

        private void DisplyColourOrCompositionChanged(object sender, EventArgs e)
        {
            SetLayout();
            ConfigureWindowFrame();
            parentForm?.Refresh();
        }

        /// <summary>Gets the content area rectangle.</summary>
        /// <param name="parentRelative">if set to <c>true</c> rectangle is relative to parent.</param>
        /// <returns>Coordinates of content area.</returns>
        private Rectangle GetContentAreaRectangle(bool parentRelative)
        {
            var cw = contentArea.GetColumnWidths();
            var ch = contentArea.GetRowHeights();
            var r = new Rectangle(cw[contentCol - 1], 0, cw[contentCol], ch[0]);
            if (parentRelative)
                r.Offset(contentArea.Location);
            return r;
        }

        private void pageContainer_ButtonStateChanged(object sender, EventArgs e)
        {
            var vis = false;
            foreach (Control c in commandAreaButtonFlowLayout.Controls)
            {
                if (c.Visible || (c is ButtonBase && pageContainer.GetCmdButtonState(c as ButtonBase) != WizardCommandButtonState.Hidden))
                    vis = true;
            }
            commandArea.Visible = vis;
        }

        private void pageContainer_Cancelling(object sender, CancelEventArgs e)
        {
            OnCancelling(e);
        }

        private void pageContainer_Finished(object sender, EventArgs e)
        {
            OnFinished();
        }

        private void pageContainer_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageContainer.SelectedPage != null)
                HeaderText = pageContainer.SelectedPage.Text;
            OnSelectedPageChanged();
        }

        private void Pages_ItemAdded(object sender, System.Collections.Generic.EventedList<WizardPage>.ListChangedEventArgs<WizardPage> e)
        {
            e.Item.TextChanged += Page_TextChanged;
        }

        private void Pages_ItemDeleted(object sender, System.Collections.Generic.EventedList<WizardPage>.ListChangedEventArgs<WizardPage> e)
        {
            e.Item.TextChanged -= Page_TextChanged;
        }

        private void Page_TextChanged(object sender, EventArgs e)
        {
            HeaderText = ((WizardPage)sender).Text;
        }

        private void parentForm_Load(object sender, EventArgs e)
        {
            ConfigureWindowFrame();
        }

        private void ResetBackButtonToolTipText()
        {
            BackButtonToolTipText = Properties.Resources.WizardBackButtonToolTip;
        }

        private void ResetBackButtonText()
        {
            pageContainer.ResetBackButtonText();
        }

        private void ResetCancelButtonText()
        {
            pageContainer.ResetCancelButtonText();
        }

        private void ResetFinishButtonText()
        {
            pageContainer.ResetFinishButtonText();
        }

        private void ResetNextButtonText()
        {
            pageContainer.ResetNextButtonText();
        }

        private void ResetTitle()
        {
            Title = Properties.Resources.WizardTitle;
        }

        private void ResetTitleIcon()
        {
            TitleIcon = Properties.Resources.WizardHat;
            titleImageIconSet = false;
        }

        private void SetLayout()
        {
            if (isMin6 && Application.RenderWithVisualStyles)
            {
                using (var g = CreateGraphics())
                {
                    // Back button
                    var theme = new VisualStyleRenderer(VisualStyleElementEx.Navigation.BackButton.Normal);
                    var bbSize = theme.GetPartSize(g, ThemeSizeType.Draw);

                    // Title
                    theme.SetParameters(VisualStyleElementEx.AeroWizard.TitleBar.Active);
                    title.Font = theme.GetFont2(g);
                    titleBar.Height = Math.Max(theme.GetMargins2(g).Top, bbSize.Height + 2);
                    titleBar.ColumnStyles[0].Width = bbSize.Width + 4F;
                    titleBar.ColumnStyles[1].Width = titleImageIcon != null ? titleImageList.ImageSize.Width + 4F : 0;
                    backButton.Size = bbSize;

                    // Header
                    theme.SetParameters(VisualStyleElementEx.AeroWizard.HeaderArea.Normal);
                    headerLabel.Font = theme.GetFont2(g);
                    headerLabel.Margin = theme.GetMargins2(g);
                    headerLabel.ForeColor = theme.GetColor(ColorProperty.TextColor);

                    // Content
                    theme.SetParameters(VisualStyleElementEx.AeroWizard.ContentArea.Normal);
                    BackColor = theme.GetColor(ColorProperty.FillColor);
                    contentArea.Font = theme.GetFont2(g);
                    var cp = theme.GetMargins2(g);
                    contentArea.ColumnStyles[0].Width = cp.Left;
                    contentArea.RowStyles[1].Height = cp.Bottom;

                    // Command
                    theme.SetParameters(VisualStyleElementEx.AeroWizard.CommandArea.Normal);
                    cp = theme.GetMargins2(g);
                    commandArea.RowStyles[0].Height = cp.Top;
                    commandArea.RowStyles[2].Height = cp.Bottom;
                    commandArea.ColumnStyles[1].Width = contentArea.ColumnStyles[contentCol + 1].Width = cp.Right;
                    commandAreaBorder.Height = 0;
                    theme.SetParameters(VisualStyleElementEx.AeroWizard.Button.Normal);
                    var btnHeight = theme.GetInteger(IntegerProperty.Height);
                    commandAreaButtonFlowLayout.MinimumSize = new Size(0, btnHeight);
                    var btnFont = theme.GetFont2(g);
                    foreach (Control ctrl in commandAreaButtonFlowLayout.Controls)
                    {
                        ctrl.Font = btnFont;
                        ctrl.Height = btnHeight;
                        //ctrl.MaximumSize = new Size(0, btnHeight);
                    }

                    themePropsSet = true;
                }
            }
            else
            {
                commandAreaBorder.Height = 1;
                backButton.Size = new Size(GetUnthemedBackButtonImage().Width, GetUnthemedBackButtonImage().Height / 4);
                BackColor = UseAeroStyle ? SystemColors.Window : SystemColors.Control;
            }
        }

        private bool ShouldSerializeBackButtonToolTipText() => BackButtonToolTipText != Properties.Resources.WizardBackButtonToolTip;

        private bool ShouldSerializeBackButtonText() => pageContainer.ShouldSerializeBackButtonText();

        private bool ShouldSerializeCancelButtonText() => pageContainer.ShouldSerializeCancelButtonText();

        private bool ShouldSerializeFinishButtonText() => pageContainer.ShouldSerializeFinishButtonText();

        private bool ShouldSerializeNextButtonText() => pageContainer.ShouldSerializeNextButtonText();

        private bool ShouldSerializeTitle() => Title != Properties.Resources.WizardTitle;

        private bool ShouldSerializeTitleIcon() => titleImageIconSet;

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var c = titleBar.GetChildAtPoint(e.Location);
                if (c != backButton)
                {
                    formMoveTracking = true;
                    formMoveLastMousePos = PointToScreen(e.Location);
                }
            }

            OnMouseDown(e);
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (formMoveTracking)
            {
                var screen = PointToScreen(e.Location);

                var diff = new Point(screen.X - formMoveLastMousePos.X, screen.Y - formMoveLastMousePos.Y);

                var loc = parentForm.Location;
                loc.Offset(diff);
                parentForm.Location = loc;

                formMoveLastMousePos = screen;
            }

            OnMouseMove(e);
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                formMoveTracking = false;

            OnMouseUp(e);
        }
    }
}