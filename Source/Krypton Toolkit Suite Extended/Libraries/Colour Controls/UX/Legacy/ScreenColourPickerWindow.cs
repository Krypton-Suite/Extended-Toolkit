using Krypton.Toolkit.Extended.Base;
using Krypton.Toolkit.Suite.Extended.Standard.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class ScreenColourPickerWindow : KryptonForm
    {
        #region Designer Code
        private Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonPanelExtended kryptonPanelExtended1;
        private KryptonButtonExtended kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonSplitContainer kryptonSplitContainer1;
        private KryptonLabelExtended klblHexValue;
        private Cyotek.Windows.Forms.ScreenColorPicker scpColour;
        private CircularPictureBox cpbSelectedColour;
        private KryptonPanel kryptonPanel1;
        private KryptonBlueValueLabel kryptonBlueValueLabel1;
        private KryptonKnobControl kknbBlue;
        private KryptonKnobControl kknbGreen;
        private KryptonGreenValueLabel kryptonGreenValueLabel1;
        private KryptonKnobControl kknbRed;
        private KryptonRedValueLabel kryptonRedValueLabel1;
        private KryptonBlueValueNumericBox knumBlue;
        private KryptonGreenValueNumericBox knumGreen;
        private KryptonRedValueNumericBox knumRed;
        private KryptonButtonExtended kbtnCancel;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenColourPickerWindow));
            this.kryptonPanelExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonPanelExtended();
            this.kbtnOk = new KryptonButtonExtended();
            this.kbtnCancel = new KryptonButtonExtended();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonSplitContainer1 = new Krypton.Toolkit.KryptonSplitContainer();
            this.klblHexValue = new KryptonLabelExtended();
            this.scpColour = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.cpbSelectedColour = new CircularPictureBox();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.knumBlue = new KryptonBlueValueNumericBox();
            this.knumGreen = new KryptonGreenValueNumericBox();
            this.knumRed = new KryptonRedValueNumericBox();
            this.kryptonBlueValueLabel1 = new KryptonBlueValueLabel();
            this.kknbBlue = new KryptonKnobControl();
            this.kknbGreen = new KryptonKnobControl();
            this.kryptonGreenValueLabel1 = new KryptonGreenValueLabel();
            this.kknbRed = new KryptonKnobControl();
            this.kryptonRedValueLabel1 = new KryptonRedValueLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended1)).BeginInit();
            this.kryptonPanelExtended1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSelectedColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanelExtended1
            // 
            this.kryptonPanelExtended1.Controls.Add(this.kbtnOk);
            this.kryptonPanelExtended1.Controls.Add(this.kbtnCancel);
            this.kryptonPanelExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanelExtended1.Image = null;
            this.kryptonPanelExtended1.Location = new System.Drawing.Point(0, 457);
            this.kryptonPanelExtended1.Name = "kryptonPanelExtended1";
            this.kryptonPanelExtended1.Size = new System.Drawing.Size(477, 50);
            this.kryptonPanelExtended1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.TabIndex = 2;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Image = null;
            this.kbtnOk.Location = new System.Drawing.Point(279, 13);
            this.kbtnOk.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.ShortTextTypeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&Ok";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Image = null;
            this.kbtnCancel.Location = new System.Drawing.Point(375, 13);
            this.kbtnCancel.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.ShortTextTypeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 3);
            this.panel1.TabIndex = 3;
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.klblHexValue);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.scpColour);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.cpbSelectedColour);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonPanel1);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(477, 454);
            this.kryptonSplitContainer1.SplitterDistance = 172;
            this.kryptonSplitContainer1.TabIndex = 4;
            // 
            // klblHexValue
            // 
            this.klblHexValue.Image = null;
            this.klblHexValue.Location = new System.Drawing.Point(18, 272);
            this.klblHexValue.LongTextTypeface = null;
            this.klblHexValue.Name = "klblHexValue";
            this.klblHexValue.ShortTextTypeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHexValue.Size = new System.Drawing.Size(78, 26);
            this.klblHexValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHexValue.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblHexValue.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblHexValue.StateDisabled.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHexValue.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblHexValue.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblHexValue.StateNormal.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHexValue.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblHexValue.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblHexValue.TabIndex = 1;
            this.klblHexValue.Values.Text = "#000000";
            // 
            // scpColour
            // 
            this.scpColour.Color = System.Drawing.Color.Empty;
            this.scpColour.Image = global::Krypton.Toolkit.Extended.Colour.Controls.Resources.LibraryResources.dropper;
            this.scpColour.Location = new System.Drawing.Point(18, 154);
            this.scpColour.Name = "scpColour";
            this.scpColour.ShowGrid = false;
            this.scpColour.ShowTextWithSnapshot = true;
            this.scpColour.Size = new System.Drawing.Size(115, 112);
            this.scpColour.ColorChanged += new System.EventHandler(this.scpColour_ColorChanged);
            // 
            // cpbSelectedColour
            // 
            this.cpbSelectedColour.BackColor = System.Drawing.SystemColors.Control;
            this.cpbSelectedColour.Location = new System.Drawing.Point(18, 14);
            this.cpbSelectedColour.Name = "cpbSelectedColour";
            this.cpbSelectedColour.Size = new System.Drawing.Size(115, 115);
            this.cpbSelectedColour.TabIndex = 0;
            this.cpbSelectedColour.TabStop = false;
            this.cpbSelectedColour.ToolTipValues = null;
            this.cpbSelectedColour.BackColorChanged += new System.EventHandler(this.cpbSelectedColour_BackColorChanged);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.knumBlue);
            this.kryptonPanel1.Controls.Add(this.knumGreen);
            this.kryptonPanel1.Controls.Add(this.knumRed);
            this.kryptonPanel1.Controls.Add(this.kryptonBlueValueLabel1);
            this.kryptonPanel1.Controls.Add(this.kknbBlue);
            this.kryptonPanel1.Controls.Add(this.kknbGreen);
            this.kryptonPanel1.Controls.Add(this.kryptonGreenValueLabel1);
            this.kryptonPanel1.Controls.Add(this.kknbRed);
            this.kryptonPanel1.Controls.Add(this.kryptonRedValueLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(300, 454);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // knumBlue
            // 
            this.knumBlue.Location = new System.Drawing.Point(224, 366);
            this.knumBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBlue.Name = "knumBlue";
            this.knumBlue.Size = new System.Drawing.Size(64, 26);
            this.knumBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBlue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumBlue.TabIndex = 31;
            this.knumBlue.ValueChanged += new System.EventHandler(this.knumBlue_ValueChanged);
            // 
            // knumGreen
            // 
            this.knumGreen.Location = new System.Drawing.Point(224, 211);
            this.knumGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumGreen.Name = "knumGreen";
            this.knumGreen.Size = new System.Drawing.Size(64, 26);
            this.knumGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knumGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumGreen.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumGreen.TabIndex = 30;
            this.knumGreen.ValueChanged += new System.EventHandler(this.knumGreen_ValueChanged);
            // 
            // knumRed
            // 
            this.knumRed.Location = new System.Drawing.Point(224, 62);
            this.knumRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumRed.Name = "knumRed";
            this.knumRed.Size = new System.Drawing.Size(64, 26);
            this.knumRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumRed.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumRed.TabIndex = 29;
            this.knumRed.ValueChanged += new System.EventHandler(this.knumRed_ValueChanged);
            // 
            // kryptonBlueValueLabel1
            // 
            this.kryptonBlueValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonBlueValueLabel1.Location = new System.Drawing.Point(42, 366);
            this.kryptonBlueValueLabel1.Name = "kryptonBlueValueLabel1";
            this.kryptonBlueValueLabel1.RedValue = 255;
            this.kryptonBlueValueLabel1.Size = new System.Drawing.Size(46, 26);
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.TabIndex = 27;
            this.kryptonBlueValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.Values.Text = "Blue";
            // 
            // kknbBlue
            // 
            this.kknbBlue.BackColor = System.Drawing.Color.Transparent;
            this.kknbBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kknbBlue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kknbBlue.LargeChange = 20;
            this.kknbBlue.Location = new System.Drawing.Point(103, 324);
            this.kknbBlue.Maximum = 255;
            this.kknbBlue.Minimum = 0;
            this.kknbBlue.Name = "kknbBlue";
            this.kknbBlue.ShowLargeScale = true;
            this.kknbBlue.ShowSmallScale = false;
            this.kknbBlue.Size = new System.Drawing.Size(110, 110);
            this.kknbBlue.SizeLargeScaleMarker = 6;
            this.kknbBlue.SizeSmallScaleMarker = 3;
            this.kknbBlue.SmallChange = 5;
            this.kknbBlue.TabIndex = 22;
            this.kknbBlue.Value = 0;
            this.kknbBlue.ValueChanged += new ValueChangedEventHandler(this.kknbBlue_ValueChanged);
            // 
            // kknbGreen
            // 
            this.kknbGreen.BackColor = System.Drawing.Color.Transparent;
            this.kknbGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kknbGreen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kknbGreen.LargeChange = 20;
            this.kknbGreen.Location = new System.Drawing.Point(103, 171);
            this.kknbGreen.Maximum = 255;
            this.kknbGreen.Minimum = 0;
            this.kknbGreen.Name = "kknbGreen";
            this.kknbGreen.ShowLargeScale = true;
            this.kknbGreen.ShowSmallScale = false;
            this.kknbGreen.Size = new System.Drawing.Size(110, 110);
            this.kknbGreen.SizeLargeScaleMarker = 6;
            this.kknbGreen.SizeSmallScaleMarker = 3;
            this.kknbGreen.SmallChange = 5;
            this.kknbGreen.TabIndex = 21;
            this.kknbGreen.Value = 0;
            this.kknbGreen.ValueChanged += new ValueChangedEventHandler(this.kknbGreen_ValueChanged);
            // 
            // kryptonGreenValueLabel1
            // 
            this.kryptonGreenValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGreenValueLabel1.Location = new System.Drawing.Point(30, 211);
            this.kryptonGreenValueLabel1.Name = "kryptonGreenValueLabel1";
            this.kryptonGreenValueLabel1.RedValue = 255;
            this.kryptonGreenValueLabel1.Size = new System.Drawing.Size(58, 26);
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.TabIndex = 25;
            this.kryptonGreenValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.Values.Text = "Green";
            // 
            // kknbRed
            // 
            this.kknbRed.BackColor = System.Drawing.Color.Transparent;
            this.kknbRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kknbRed.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kknbRed.LargeChange = 20;
            this.kknbRed.Location = new System.Drawing.Point(103, 18);
            this.kknbRed.Maximum = 255;
            this.kknbRed.Minimum = 0;
            this.kknbRed.Name = "kknbRed";
            this.kknbRed.ShowLargeScale = true;
            this.kknbRed.ShowSmallScale = false;
            this.kknbRed.Size = new System.Drawing.Size(110, 110);
            this.kknbRed.SizeLargeScaleMarker = 6;
            this.kknbRed.SizeSmallScaleMarker = 3;
            this.kknbRed.SmallChange = 5;
            this.kknbRed.TabIndex = 20;
            this.kknbRed.Value = 0;
            this.kknbRed.ValueChanged += new ValueChangedEventHandler(this.kknbRed_ValueChanged);
            // 
            // kryptonRedValueLabel1
            // 
            this.kryptonRedValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonRedValueLabel1.Location = new System.Drawing.Point(46, 62);
            this.kryptonRedValueLabel1.Name = "kryptonRedValueLabel1";
            this.kryptonRedValueLabel1.RedValue = 255;
            this.kryptonRedValueLabel1.Size = new System.Drawing.Size(42, 26);
            this.kryptonRedValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.TabIndex = 23;
            this.kryptonRedValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.Values.Text = "Red";
            // 
            // ScreenColourPickerWindow
            // 
            this.ClientSize = new System.Drawing.Size(477, 507);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanelExtended1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenColourPickerWindow";
            this.Text = "Screen Colour Picker";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended1)).EndInit();
            this.kryptonPanelExtended1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbSelectedColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _knobForeColour, _knobBackColour, _knobBorderColour, _knobColour, _knobTrackingColour, _colour;

        private IPalette _palette;
        #endregion

        #region Properties
        public Color KnobForeColour { get => _knobForeColour; set { _knobForeColour = value; Invalidate(); } }

        public Color KnobBackColour { get => _knobBackColour; set { _knobBackColour = value; Invalidate(); } }

        public Color KnobBorderColour { get => _knobBorderColour; set { _knobBorderColour = value; Invalidate(); } }

        public Color KnobColour { get => _knobColour; set { _knobColour = value; Invalidate(); } }

        public Color KnobTrackingColour { get => _knobTrackingColour; set { _knobTrackingColour = value; Invalidate(); } }

        public Color Colour { get => _colour; set { _colour = value; OnSelectedColourChanged(value); Invalidate(); } }
        #endregion

        public delegate void SelectedColourChangedEventHandler(object sender, EventArgs e);

        public event SelectedColourChangedEventHandler SelectedColourChanged;

        #region Enumerations
        private enum ColourChannelLabel
        {
            BLUELABEL,
            GREENLABEL,
            REDLABEL
        }
        #endregion

        #region Constructor
        public ScreenColourPickerWindow()
        {
            InitializeComponent();

            InitialiseWindow();
        }
        #endregion

        #region Methods
        private void AlterLabel(ColourChannelLabel colourChannel, int value)
        {
            switch (colourChannel)
            {
                case ColourChannelLabel.BLUELABEL:
                    knumBlue.Value = value;
                    break;
                case ColourChannelLabel.GREENLABEL:
                    knumGreen.Value = value;
                    break;
                case ColourChannelLabel.REDLABEL:
                    knumRed.Value = value;
                    break;
            }
        }

        private void InitialiseWindow()
        {
            knumRed.Value = kknbRed.Value;

            knumGreen.Value = kknbGreen.Value;

            knumBlue.Value = kknbBlue.Value;

            klblHexValue.Text = string.Empty;

            cpbSelectedColour.BackColor = Color.Transparent;
        }

        private string GetHexColourValue(Color colour) => ColorTranslator.ToHtml(colour);

        private void UpdateColourValues(Color colour, bool useKnobs = true)
        {
            if (useKnobs)
            {
                kknbBlue.Value = colour.B;

                kknbGreen.Value = colour.G;

                kknbRed.Value = colour.R;
            }
            else
            {
                UpdateLabelValues(colour.R, colour.G, colour.B);
            }
        }

        private void UpdateLabelValues(byte r, byte g, byte b)
        {
            knumBlue.Value = b;

            knumGreen.Value = g;

            knumRed.Value = r;
        }

        private void ConstructSpecifiedColour(byte red, byte green, byte blue) => cpbSelectedColour.BackColor = Color.FromArgb(red, green, blue);

        private void ConstructSpecifiedColour(int red, int green, int blue) => cpbSelectedColour.BackColor = Color.FromArgb(red, green, blue);
        #endregion

        private void scpColour_ColorChanged(object sender, EventArgs e)
        {
            cpbSelectedColour.BackColor = scpColour.Color;
        }

        private void kknbRed_ValueChanged(object Sender)
        {
            AlterLabel(ColourChannelLabel.REDLABEL, kknbRed.Value);

            ConstructSpecifiedColour(kknbRed.Value, kknbGreen.Value, kknbBlue.Value);
        }

        private void kknbGreen_ValueChanged(object Sender)
        {
            AlterLabel(ColourChannelLabel.GREENLABEL, kknbGreen.Value);

            ConstructSpecifiedColour(kknbRed.Value, kknbGreen.Value, kknbBlue.Value);
        }

        private void kknbBlue_ValueChanged(object Sender)
        {
            AlterLabel(ColourChannelLabel.BLUELABEL, kknbBlue.Value);

            ConstructSpecifiedColour(kknbRed.Value, kknbGreen.Value, kknbBlue.Value);
        }

        private void knumRed_ValueChanged(object sender, EventArgs e)
        {
            ConstructSpecifiedColour((byte)knumRed.Value, (byte)knumGreen.Value, (byte)knumBlue.Value);
        }

        private void knumGreen_ValueChanged(object sender, EventArgs e)
        {
            ConstructSpecifiedColour((byte)knumRed.Value, (byte)knumGreen.Value, (byte)knumBlue.Value);
        }

        private void knumBlue_ValueChanged(object sender, EventArgs e)
        {
            ConstructSpecifiedColour((byte)knumRed.Value, (byte)knumGreen.Value, (byte)knumBlue.Value);
        }

        private void cpbSelectedColour_BackColorChanged(object sender, EventArgs e)
        {
            klblHexValue.Text = GetHexColourValue(cpbSelectedColour.BackColor);

            UpdateColourValues(cpbSelectedColour.BackColor);

            Colour = cpbSelectedColour.BackColor;
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Hide();
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Hide();
        }

        #region Protected
        protected virtual void OnSelectedColourChanged(object sender)
        {
            if (SelectedColourChanged != null) SelectedColourChanged(sender, EventArgs.Empty);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }
        #endregion
    }
}