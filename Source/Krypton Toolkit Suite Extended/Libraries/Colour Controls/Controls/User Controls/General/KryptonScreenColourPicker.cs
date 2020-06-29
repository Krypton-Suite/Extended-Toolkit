using Krypton.Toolkit.Extended.Base;
using Krypton.Toolkit.Suite.Extended.Standard.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    /*
    public class KryptonScreenColourPicker : UserControl
    {
        #region Designer Code
        private Suite.Extended.Standard.Controls.KryptonPanelExtended kryptonPanelExtended1;
        private KryptonButtonExtended kbtnOk;
        private Panel panel1;
        private KryptonSplitContainer kryptonSplitContainer1;
        private CircularPictureBox cpbSelectedColour;
        private KryptonLabelExtended klblHexValue;
        private Cyotek.Windows.Forms.ScreenColorPicker scpColour;
        private KryptonPanel kryptonPanel1;
        private KryptonBlueValueLabel klblBlueValue;
        private KryptonBlueValueLabel kryptonBlueValueLabel1;
        private KryptonGreenValueLabel klblGreenValue;
        private KryptonKnobControl kknbBlue;
        private KryptonKnobControl kknbGreen;
        private KryptonGreenValueLabel kryptonGreenValueLabel1;
        private KryptonKnobControl kknbRed;
        private KryptonRedValueLabel klblRedValue;
        private KryptonRedValueLabel kryptonRedValueLabel1;
        private KryptonButtonExtended kbtnCancel;

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonSplitContainer1 = new Krypton.Toolkit.KryptonSplitContainer();
            this.klblHexValue = new KryptonLabelExtended();
            this.scpColour = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.cpbSelectedColour = new CircularPictureBox();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.klblBlueValue = new KryptonBlueValueLabel();
            this.kryptonBlueValueLabel1 = new KryptonBlueValueLabel();
            this.kknbBlue = new KryptonKnobControl();
            this.kknbGreen = new KryptonKnobControl();
            this.kknbRed = new KryptonKnobControl();
            this.klblRedValue = new KryptonRedValueLabel();
            this.kryptonRedValueLabel1 = new KryptonRedValueLabel();
            this.kryptonPanelExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonPanelExtended();
            this.kbtnOk = new KryptonButtonExtended();
            this.kbtnCancel = new KryptonButtonExtended();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSelectedColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended1)).BeginInit();
            this.kryptonPanelExtended1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 452);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 3);
            this.panel1.TabIndex = 2;
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
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(479, 452);
            this.kryptonSplitContainer1.SplitterDistance = 173;
            this.kryptonSplitContainer1.TabIndex = 3;
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
            this.scpColour.Location = new System.Drawing.Point(18, 154);
            this.scpColour.Name = "scpColour";
            this.scpColour.Size = new System.Drawing.Size(115, 112);
            this.scpColour.Text = "screenColorPicker1";
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
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.klblBlueValue);
            this.kryptonPanel1.Controls.Add(this.kryptonBlueValueLabel1);
            this.kryptonPanel1.Controls.Add(this.klblGreenValue);
            this.kryptonPanel1.Controls.Add(this.kknbBlue);
            this.kryptonPanel1.Controls.Add(this.kknbGreen);
            this.kryptonPanel1.Controls.Add(this.kryptonGreenValueLabel1);
            this.kryptonPanel1.Controls.Add(this.kknbRed);
            this.kryptonPanel1.Controls.Add(this.klblRedValue);
            this.kryptonPanel1.Controls.Add(this.kryptonRedValueLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(301, 452);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // klblBlueValue
            // 
            this.klblBlueValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klblBlueValue.Location = new System.Drawing.Point(238, 366);
            this.klblBlueValue.Name = "klblBlueValue";
            this.klblBlueValue.BlueValue = 255;
            this.klblBlueValue.Size = new System.Drawing.Size(33, 26);
            this.klblBlueValue.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBlueValue.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBlueValue.TabIndex = 28;
            this.klblBlueValue.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBlueValue.Values.Text = "{0}";
            // 
            // kryptonBlueValueLabel1
            // 
            this.kryptonBlueValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonBlueValueLabel1.Location = new System.Drawing.Point(42, 366);
            this.kryptonBlueValueLabel1.Name = "kryptonBlueValueLabel1";
            this.kryptonBlueValueLabel1.BlueValue = 255;
            this.kryptonBlueValueLabel1.Size = new System.Drawing.Size(46, 26);
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.TabIndex = 27;
            this.kryptonBlueValueLabel1.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
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
            // 
            // klblRedValue
            // 
            this.klblRedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klblRedValue.Location = new System.Drawing.Point(238, 62);
            this.klblRedValue.Name = "klblRedValue";
            this.klblRedValue.RedValue = 255;
            this.klblRedValue.Size = new System.Drawing.Size(33, 26);
            this.klblRedValue.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblRedValue.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblRedValue.TabIndex = 24;
            this.klblRedValue.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblRedValue.Values.Text = "{0}";
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
            this.kryptonRedValueLabel1.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.Values.Text = "Red";
            // 
            // kryptonPanelExtended1
            // 
            this.kryptonPanelExtended1.Controls.Add(this.kbtnOk);
            this.kryptonPanelExtended1.Controls.Add(this.kbtnCancel);
            this.kryptonPanelExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanelExtended1.Image = null;
            this.kryptonPanelExtended1.Location = new System.Drawing.Point(0, 455);
            this.kryptonPanelExtended1.Name = "kryptonPanelExtended1";
            this.kryptonPanelExtended1.Size = new System.Drawing.Size(479, 50);
            this.kryptonPanelExtended1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.TabIndex = 1;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Image = null;
            this.kbtnOk.Location = new System.Drawing.Point(281, 13);
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
            this.kbtnCancel.Location = new System.Drawing.Point(377, 13);
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
            // KryptonScreenColourPicker
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanelExtended1);
            this.MinimumSize = new System.Drawing.Size(479, 505);
            this.Name = "KryptonScreenColourPicker";
            this.Size = new System.Drawing.Size(479, 505);
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended1)).EndInit();
            this.kryptonPanelExtended1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _selectedColour = Color.Empty;

        private Timer _tmrChangeColourByTrackbars = null, _tmrChangeColourByNumericUpDown = null, _tmrChangeColourByScreenColourPicker = null;

        private KryptonForm _owner;
        #endregion

        #region Properties
        public Color SelectedColour { get => _selectedColour; set { _selectedColour = value; Invalidate(); } }

        public KryptonForm Owner { get => _owner; set { _owner = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonScreenColourPicker()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;

            if (Owner != null)
            {
                Owner.AcceptButton = kbtnOk;

                Owner.CancelButton = kbtnCancel;
            }

            #region Timers

            #region Trackbars
            _tmrChangeColourByTrackbars = new Timer();

            _tmrChangeColourByTrackbars.Enabled = true;

            _tmrChangeColourByTrackbars.Interval = 500;

            _tmrChangeColourByTrackbars.Tick += ChangeColourByTrackbars_Tick;
            #endregion

            #region Numeric Up & Down
            _tmrChangeColourByNumericUpDown = new Timer();

            _tmrChangeColourByNumericUpDown.Interval = 500;

            _tmrChangeColourByNumericUpDown.Enabled = true;

            _tmrChangeColourByNumericUpDown.Tick += ChangeColourByNumericUpDown_Tick;
            #endregion

            #region Screen Colour Picker
            _tmrChangeColourByScreenColourPicker = new Timer();

            _tmrChangeColourByScreenColourPicker.Enabled = true;

            _tmrChangeColourByScreenColourPicker.Tick += ChangeColourByScreenColourPicker_Tick;
            #endregion

            #endregion
        }

        public KryptonScreenColourPicker(KryptonForm owner)
        {
            InitializeComponent();

            owner.CancelButton = kbtnCancel;

            owner.AcceptButton = kbtnOk;

            #region Timers

            #region Trackbars
            _tmrChangeColourByTrackbars = new Timer();

            _tmrChangeColourByTrackbars.Enabled = true;

            _tmrChangeColourByTrackbars.Interval = 500;

            _tmrChangeColourByTrackbars.Tick += ChangeColourByTrackbars_Tick;
            #endregion

            #region Numeric Up & Down
            _tmrChangeColourByNumericUpDown = new Timer();

            _tmrChangeColourByNumericUpDown.Interval = 500;

            _tmrChangeColourByNumericUpDown.Enabled = true;

            _tmrChangeColourByNumericUpDown.Tick += ChangeColourByNumericUpDown_Tick;
            #endregion

            #region Screen Colour Picker
            _tmrChangeColourByScreenColourPicker = new Timer();

            _tmrChangeColourByScreenColourPicker.Enabled = true;

            _tmrChangeColourByScreenColourPicker.Tick += ChangeColourByScreenColourPicker_Tick;
            #endregion

            #endregion
        }
        #endregion

        #region Methods
        /// <summary>Updates the selected colour.</summary>
        /// <param name="colour">The colour.</param>
        public void UpdateSelectedColour(Color colour)
        {
            int r = colour.R, g = colour.G, b = colour.B;

            cpbSelectedColour.BackColor = colour;

            SetSelectedColour(colour);
        }


        /// <summary>Updates the selected colour.</summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        public void UpdateSelectedColour(byte red, byte green, byte blue)
        {
            Color output = Color.FromArgb(red, green, blue);

            cpbSelectedColour.BackColor = output;

            SetSelectedColour(output);
        }

        private void UpdateHexadecimalLabel(bool toUpper = false)
        {
            if (toUpper)
            {
                klblHexValue.Text = ColorTranslator.ToHtml(SelectedColour).ToUpper();
            }
            else
            {
                klblHexValue.Text = ColorTranslator.ToHtml(SelectedColour);
            }
        }

        private string ResolveHexadecimalColourValue(Color colourValue) => ColorTranslator.ToHtml(colourValue);
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the SelectedColour.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetSelectedColour(Color value) => SelectedColour = value;

        /// <summary>
        /// Gets the SelectedColour.
        /// </summary>
        /// <returns>The value of SelectedColour.</returns>
        public Color GetSelectedColour() => SelectedColour;
        #endregion

        #region Event Handlers
        private void kbtnOk_Click(object sender, EventArgs e)
        {
            ((KryptonForm)TopLevelControl).DialogResult = DialogResult.OK;

            ((KryptonForm)TopLevelControl).Close();
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            ((KryptonForm)TopLevelControl).DialogResult = DialogResult.Cancel;

            ((KryptonForm)TopLevelControl).Close();
        }

        private void ChangeColourByScreenColourPicker_Tick(object sender, EventArgs e)
        {
            UpdateSelectedColour(scpColour.Color);

            _tmrChangeColourByScreenColourPicker.Stop();
        }

        private void ChangeColourByNumericUpDown_Tick(object sender, EventArgs e)
        {
            //UpdateSelectedColour((byte)knumRed.Value, (byte)knumGreen.Value, (byte)knumBlue.Value);

            _tmrChangeColourByNumericUpDown.Stop();
        }

        private void klblHex_MouseEnter(object sender, EventArgs e)
        {
            klblHexValue.ToolTipValues.Heading = "Current Hexadecimal Value";

            klblHexValue.ToolTipValues.Description = $"The hexadecimal value for the current colour is: { klblHexValue.Text }";
        }

        private void kknbBlue_ValueChanged(object Sender)
        {

        }

        private void ChangeColourByTrackbars_Tick(object sender, EventArgs e)
        {
            //UpdateSelectedColour((byte)ktrkRed.Value, (byte)ktrkGreen.Value, (byte)ktrkBlue.Value);

            _tmrChangeColourByTrackbars.Stop();
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateSelectedColour(SelectedColour);

            if (SelectedColour != null || SelectedColour != Color.Empty || SelectedColour != Color.Transparent)
            {
                UpdateHexadecimalLabel();
            }

            base.OnPaint(e);
        }
        #endregion
    }
    */
}