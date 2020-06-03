using Cyotek.Windows.Forms;
using Krypton.Toolkit.Suite.Extended.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    [DefaultEvent("PreviewColourChanged"), DefaultProperty("Colour")]
    public class KryptonColourPickerDialog : KryptonForm
    {
        #region Designer Code
        private IContainer components = null;
        private KryptonPanel kryptonPanel1;
        private Colour.Controls.ColourWheelControl cwColour;
        private KryptonCancelDialogButton kbtnCancel;
        private Colour.Controls.ColourEditorManager cem;
        private Colour.Controls.ColourEditorUserControl ceColours;
        private Colour.Controls.ScreenColourPickerControl scp;
        private Cyotek.Windows.Forms.ColorGrid cgColours;
        private CircularPictureBox cpbColourPreview;
        private KryptonButton kbtnSavePalette;
        private KryptonButton kbtnLoadPalette;
        private KryptonOKDialogButton kbtnOk;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonColourPickerDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnSavePalette = new Krypton.Toolkit.KryptonButton();
            this.kbtnLoadPalette = new Krypton.Toolkit.KryptonButton();
            this.cgColours = new Cyotek.Windows.Forms.ColorGrid();
            this.cpbColourPreview = new CircularPictureBox();
            this.scp = new Krypton.Toolkit.Suite.Extended.Colour.Controls.ScreenColourPickerControl();
            this.ceColours = new Krypton.Toolkit.Suite.Extended.Colour.Controls.ColourEditorUserControl();
            this.cwColour = new Krypton.Toolkit.Suite.Extended.Colour.Controls.ColourWheelControl();
            this.kbtnCancel = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonCancelDialogButton();
            this.kbtnOk = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonOKDialogButton();
            this.cem = new Krypton.Toolkit.Suite.Extended.Colour.Controls.ColourEditorManager();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnSavePalette);
            this.kryptonPanel1.Controls.Add(this.kbtnLoadPalette);
            this.kryptonPanel1.Controls.Add(this.cgColours);
            this.kryptonPanel1.Controls.Add(this.cpbColourPreview);
            this.kryptonPanel1.Controls.Add(this.scp);
            this.kryptonPanel1.Controls.Add(this.ceColours);
            this.kryptonPanel1.Controls.Add(this.cwColour);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(574, 544);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnSavePalette
            // 
            this.kbtnSavePalette.AutoSize = true;
            this.kbtnSavePalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSavePalette.Location = new System.Drawing.Point(40, 345);
            this.kbtnSavePalette.Name = "kbtnSavePalette";
            this.kbtnSavePalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnSavePalette.TabIndex = 4;
            this.kbtnSavePalette.ToolTipValues.Description = "Save current custom palette for futre use.";
            this.kbtnSavePalette.Values.Image = global::Krypton.Toolkit.Suite.Extended.Dialogs.Properties.Resources.palette_save;
            this.kbtnSavePalette.Values.Text = "";
            this.kbtnSavePalette.Click += new System.EventHandler(this.kbtnSavePalette_Click);
            // 
            // kbtnLoadPalette
            // 
            this.kbtnLoadPalette.AutoSize = true;
            this.kbtnLoadPalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLoadPalette.Location = new System.Drawing.Point(12, 345);
            this.kbtnLoadPalette.Name = "kbtnLoadPalette";
            this.kbtnLoadPalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnLoadPalette.TabIndex = 1;
            this.kbtnLoadPalette.ToolTipValues.Description = "Load a custom palette.";
            this.kbtnLoadPalette.ToolTipValues.Heading = "Load Custom Palette";
            this.kbtnLoadPalette.ToolTipValues.Image = global::Krypton.Toolkit.Suite.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtnLoadPalette.Values.Image = global::Krypton.Toolkit.Suite.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtnLoadPalette.Values.Text = "";
            this.kbtnLoadPalette.Click += new System.EventHandler(this.kbtnLoadPalette_Click);
            // 
            // cgColours
            // 
            this.cgColours.BackColor = System.Drawing.Color.Transparent;
            this.cgColours.Location = new System.Drawing.Point(12, 373);
            this.cgColours.Name = "cgColours";
            this.cgColours.Size = new System.Drawing.Size(247, 165);
            this.cgColours.TabIndex = 3;
            this.cgColours.EditingColor += new System.EventHandler<Cyotek.Windows.Forms.EditColorCancelEventArgs>(this.cgColours_EditingColor);
            // 
            // cpbColourPreview
            // 
            this.cpbColourPreview.BackColor = System.Drawing.SystemColors.Control;
            this.cpbColourPreview.Location = new System.Drawing.Point(443, 252);
            this.cpbColourPreview.Name = "cpbColourPreview";
            this.cpbColourPreview.Size = new System.Drawing.Size(119, 119);
            this.cpbColourPreview.TabIndex = 2;
            this.cpbColourPreview.TabStop = false;
            this.cpbColourPreview.ToolTipValues = null;
            this.cpbColourPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.cpbColourPreview_Paint);
            // 
            // scp
            // 
            this.scp.Colour = System.Drawing.Color.Empty;
            this.scp.Image = global::Krypton.Toolkit.Suite.Extended.Dialogs.Properties.Resources.eyedropper;
            this.scp.Location = new System.Drawing.Point(443, 87);
            this.scp.Name = "scp";
            this.scp.Size = new System.Drawing.Size(119, 103);
            this.scp.ColourChanged += new System.EventHandler(this.scp_ColourChanged);
            // 
            // ceColours
            // 
            this.ceColours.AutoSize = true;
            this.ceColours.BackColor = System.Drawing.Color.Transparent;
            this.ceColours.Location = new System.Drawing.Point(162, 12);
            this.ceColours.Name = "ceColours";
            this.ceColours.Size = new System.Drawing.Size(274, 364);
            this.ceColours.TabIndex = 1;
            // 
            // cwColour
            // 
            this.cwColour.BackColor = System.Drawing.Color.Transparent;
            this.cwColour.Location = new System.Drawing.Point(12, 12);
            this.cwColour.Name = "cwColour";
            this.cwColour.Size = new System.Drawing.Size(144, 144);
            this.cwColour.TabIndex = 1;
            this.cwColour.ColourChanged += new System.EventHandler(this.cwColour_ColourChanged);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Image = null;
            this.kbtnCancel.Location = new System.Drawing.Point(472, 43);
            this.kbtnCancel.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Image = null;
            this.kbtnOk.Location = new System.Drawing.Point(472, 12);
            this.kbtnOk.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.TabIndex = 0;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // cem
            // 
            this.cem.Color = System.Drawing.Color.Empty;
            this.cem.ColourEditor = this.ceColours;
            this.cem.ColourGrid = this.cgColours;
            this.cem.ColourWheel = this.cwColour;
            this.cem.ScreenColourPicker = this.scp;
            this.cem.ColourChanged += new System.EventHandler(this.cem_ColourChanged);
            // 
            // KryptonColourPickerDialog
            // 
            this.ClientSize = new System.Drawing.Size(574, 544);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonColourPickerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Colour Picker";
            this.Load += new System.EventHandler(this.KryptonColourPickerDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constants
        private static readonly object _eventPreviewColourChanged = new object();
        #endregion

        #region Fields
        private Brush _textureBrush;
        #endregion

        #region Events
        [Category("Property Changed")]
        public event EventHandler PreviewColourChanged
        {
            add { Events.AddHandler(_eventPreviewColourChanged, value); }
            remove { Events.RemoveHandler(_eventPreviewColourChanged, value); }
        }
        #endregion

        #region Properties
        public Color Colour { get => cem.Colour; set => cem.Colour = value; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowAlphaChannel { get; set; }
        #endregion

        #region Constructors
        public KryptonColourPickerDialog()
        {
            InitializeComponent();

            ShowAlphaChannel = true;

            Font = SystemFonts.DialogFont;
        }
        #endregion

        #region Overrides
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                if (_textureBrush != null)
                {
                    _textureBrush.Dispose();

                    _textureBrush = null;
                }
            }

            base.Dispose(disposing);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ceColours.ShowAlphaChannel = ShowAlphaChannel;

            if (!ShowAlphaChannel)
            {
                for (int i = 0; i < cgColours.Colors.Count; i++)
                {
                    Color colour;

                    colour = cgColours.Colors[i];

                    if (colour.A != 255)
                    {
                        cgColours.Colors[i] = Color.FromArgb(255, colour);
                    }
                }
            }
        }
        #endregion

        #region Virtual
        protected virtual void OnPreviewColourChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)Events[_eventPreviewColourChanged];

            handler?.Invoke(this, e);
        }
        #endregion

        private void KryptonColourPickerDialog_Load(object sender, EventArgs e)
        {

        }

        private void cwColour_ColourChanged(object sender, EventArgs e)
        {

        }

        private void kbtnLoadPalette_Click(object sender, EventArgs e)
        {
            using (FileDialog fd = new OpenFileDialog { Filter = PaletteSerializer.DefaultOpenFilter, DefaultExt = "pal", Title = "Open a custom palette file:" })
            {
                if (fd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        IPaletteSerializer serializer;

                        serializer = PaletteSerializer.GetSerializer(fd.FileName);

                        if (serializer != null)
                        {
                            ColorCollection colours;

                            if (!serializer.CanRead) throw new InvalidOperationException("Serializer does not support reading palettes.");

                            using (FileStream fs = File.OpenRead(fd.FileName))
                            {
                                colours = serializer.Deserialize(fs);
                            }

                            if (colours != null)
                            {
                                while (colours.Count > 96)
                                {
                                    colours.RemoveAt(colours.Count - 1);
                                }

                                while (colours.Count < 96)
                                {
                                    colours.Add(Color.White);
                                }

                                cgColours.Colors = colours;
                            }
                        }
                        else
                        {
                            KryptonMessageBoxExtended.Show("Sorry, unable to open palette, the file format is not supported or is not recognized.", "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception exc)
                    {
                        KryptonMessageBoxExtended.Show($@"Sorry, unable to open palette. { exc.GetBaseException().Message }", "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cem_ColourChanged(object sender, EventArgs e)
        {
            cpbColourPreview.Invalidate();

            OnPreviewColourChanged(e);
        }

        private void kbtnSavePalette_Click(object sender, EventArgs e)
        {
            using (FileDialog fd = new SaveFileDialog { Filter = PaletteSerializer.DefaultSaveFilter, DefaultExt = "pal", Title = "Save custom palette as:" })
            {
                if (fd.ShowDialog(this) == DialogResult.OK)
                {
                    IPaletteSerializer serializer;

                    serializer = PaletteSerializer.AllSerializers.Where(s => s.CanWrite).ElementAt(fd.FilterIndex - 1);

                    if (serializer != null)
                    {
                        if (!serializer.CanWrite) throw new InvalidOperationException("Serializer does not support writing palettes.");
                    }

                    try
                    {
                        using (FileStream fs = File.OpenWrite(fd.FileName))
                        {
                            serializer.Serialize(fs, cgColours.Colors);
                        }
                    }
                    catch (Exception exc)
                    {
                        KryptonMessageBoxExtended.Show($@"Sorry, unable to save palette. { exc.GetBaseException().Message }", "Save Palette", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    KryptonMessageBoxExtended.Show("Sorry, unable to save palette, the file format is not supported or is not recognised.", "Save Palette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void scp_ColourChanged(object sender, EventArgs e)
        {
            Colour = scp.Colour;

            OnPreviewColourChanged(e);
        }

        private void cgColours_EditingColor(object sender, EditColorCancelEventArgs e)
        {
            e.Cancel = true;

            // TODO: Use Krypton
            using (ColorDialog cd = new ColorDialog { FullOpen = true, Color = e.Color })
            {
                if (cd.ShowDialog(this) == DialogResult.OK) cgColours.Colors[e.ColorIndex] = cd.Color;
            }
        }

        private void cpbColourPreview_Paint(object sender, PaintEventArgs e)
        {
            Rectangle region;

            region = cpbColourPreview.ClientRectangle;

            if (Colour.A != 255)
            {
                if (_textureBrush == null)
                {
                    using (Bitmap bg = new Bitmap(GetType().Assembly.GetManifestResourceStream(string.Concat(GetType().Namespace, ".Resources.cellbackground.png"))))
                    {
                        _textureBrush = new TextureBrush(bg, WrapMode.Tile);
                    }
                }

                e.Graphics.FillRectangle(_textureBrush, region);
            }

            using (Brush brush = new SolidBrush(this.Colour))
            {
                e.Graphics.FillRectangle(brush, region);
            }

            e.Graphics.DrawRectangle(SystemPens.ControlText, region.Left, region.Top, region.Width - 1, region.Height - 1);
        }
    }
}