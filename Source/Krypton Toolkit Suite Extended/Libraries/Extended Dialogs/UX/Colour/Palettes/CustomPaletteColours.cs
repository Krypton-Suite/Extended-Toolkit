using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class CustomPaletteColours : KryptonForm
    {
        private KryptonPanel kpnlButtons;
        private KryptonOKDialogButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel1;
        private KryptonListBox kryptonListBox1;
        private Colour.Controls.KryptonBlueValueNumericBox knudBaseBlue;
        private Colour.Controls.KryptonRedValueLabel klblBaseRed;
        private Colour.Controls.KryptonBlueValueLabel klblBaseBlue;
        private Colour.Controls.KryptonGreenValueNumericBox knudBaseGreen;
        private Colour.Controls.KryptonRedValueNumericBox knudBaseRed;
        private Colour.Controls.KryptonGreenValueLabel klblBaseGreen;
        private System.Windows.Forms.PictureBox pbxColourPreview;
        private KryptonButton kryptonButton3;
        private KryptonButton kryptonButton2;
        private KryptonButton kryptonButton1;
        private Suite.Extended.Standard.Controls.KryptonComboBoxExtended kryptonComboBoxExtended2;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended kryptonLabelExtended2;
        private Suite.Extended.Standard.Controls.KryptonComboBoxExtended kryptonComboBoxExtended1;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended kryptonLabelExtended1;
        private Colour.Controls.ColourHexadecimalTextBox colourHexadecimalTextBox1;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended kryptonLabelExtended3;
        private KryptonButton kryptonButton5;
        private KryptonButton kryptonButton4;
        private KryptonCancelDialogButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.Extended.Dialogs.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.knudBaseBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueNumericBox();
            this.knudBaseGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueNumericBox();
            this.knudBaseRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueNumericBox();
            this.klblBaseBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblBaseGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblBaseRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueLabel();
            this.kryptonListBox1 = new Krypton.Toolkit.KryptonListBox();
            this.pbxColourPreview = new System.Windows.Forms.PictureBox();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabelExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.kryptonComboBoxExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonComboBoxExtended();
            this.kryptonComboBoxExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonComboBoxExtended();
            this.kryptonLabelExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.kryptonButton4 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton5 = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabelExtended3 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.colourHexadecimalTextBox1 = new Krypton.Toolkit.Extended.Colour.Controls.ColourHexadecimalTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxExtended1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxExtended2)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.colourHexadecimalTextBox1);
            this.kpnlButtons.Controls.Add(this.kryptonLabelExtended3);
            this.kpnlButtons.Controls.Add(this.kryptonButton5);
            this.kpnlButtons.Controls.Add(this.kryptonButton4);
            this.kpnlButtons.Controls.Add(this.kbtnOk);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 243);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(887, 44);
            this.kpnlButtons.TabIndex = 2;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Image = null;
            this.kbtnOk.Location = new System.Drawing.Point(689, 7);
            this.kbtnOk.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.TabIndex = 2;
            this.kbtnOk.Values.Text = "&OK";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Image = null;
            this.kbtnCancel.Location = new System.Drawing.Point(785, 7);
            this.kbtnCancel.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 3);
            this.panel1.TabIndex = 4;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonComboBoxExtended2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabelExtended2);
            this.kryptonPanel1.Controls.Add(this.kryptonComboBoxExtended1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabelExtended1);
            this.kryptonPanel1.Controls.Add(this.kryptonButton3);
            this.kryptonPanel1.Controls.Add(this.kryptonButton2);
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Controls.Add(this.pbxColourPreview);
            this.kryptonPanel1.Controls.Add(this.kryptonListBox1);
            this.kryptonPanel1.Controls.Add(this.knudBaseBlue);
            this.kryptonPanel1.Controls.Add(this.klblBaseRed);
            this.kryptonPanel1.Controls.Add(this.klblBaseBlue);
            this.kryptonPanel1.Controls.Add(this.knudBaseGreen);
            this.kryptonPanel1.Controls.Add(this.knudBaseRed);
            this.kryptonPanel1.Controls.Add(this.klblBaseGreen);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(887, 240);
            this.kryptonPanel1.TabIndex = 5;
            // 
            // knudBaseBlue
            // 
            this.knudBaseBlue.Location = new System.Drawing.Point(611, 206);
            this.knudBaseBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBaseBlue.Name = "knudBaseBlue";
            this.knudBaseBlue.Size = new System.Drawing.Size(74, 23);
            this.knudBaseBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudBaseBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBaseBlue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBaseBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBaseBlue.TabIndex = 23;
            // 
            // knudBaseGreen
            // 
            this.knudBaseGreen.Location = new System.Drawing.Point(332, 206);
            this.knudBaseGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBaseGreen.Name = "knudBaseGreen";
            this.knudBaseGreen.Size = new System.Drawing.Size(74, 23);
            this.knudBaseGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudBaseGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBaseGreen.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBaseGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBaseGreen.TabIndex = 22;
            // 
            // knudBaseRed
            // 
            this.knudBaseRed.Location = new System.Drawing.Point(63, 206);
            this.knudBaseRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBaseRed.Name = "knudBaseRed";
            this.knudBaseRed.Size = new System.Drawing.Size(74, 23);
            this.knudBaseRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudBaseRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBaseRed.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBaseRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBaseRed.TabIndex = 21;
            // 
            // klblBaseBlue
            // 
            this.klblBaseBlue.Location = new System.Drawing.Point(557, 206);
            this.klblBaseBlue.Name = "klblBaseBlue";
            this.klblBaseBlue.RedValue = 255;
            this.klblBaseBlue.Size = new System.Drawing.Size(48, 21);
            this.klblBaseBlue.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.klblBaseBlue.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.klblBaseBlue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseBlue.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.klblBaseBlue.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.klblBaseBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBaseBlue.TabIndex = 20;
            this.klblBaseBlue.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseBlue.Values.Text = "Blue:";
            // 
            // klblBaseGreen
            // 
            this.klblBaseGreen.Location = new System.Drawing.Point(265, 206);
            this.klblBaseGreen.Name = "klblBaseGreen";
            this.klblBaseGreen.RedValue = 255;
            this.klblBaseGreen.Size = new System.Drawing.Size(61, 21);
            this.klblBaseGreen.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.klblBaseGreen.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.klblBaseGreen.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseGreen.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.klblBaseGreen.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.klblBaseGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBaseGreen.TabIndex = 19;
            this.klblBaseGreen.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseGreen.Values.Text = "Green:";
            // 
            // klblBaseRed
            // 
            this.klblBaseRed.Location = new System.Drawing.Point(12, 206);
            this.klblBaseRed.Name = "klblBaseRed";
            this.klblBaseRed.RedValue = 255;
            this.klblBaseRed.Size = new System.Drawing.Size(45, 21);
            this.klblBaseRed.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.klblBaseRed.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.klblBaseRed.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseRed.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.klblBaseRed.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.klblBaseRed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBaseRed.TabIndex = 18;
            this.klblBaseRed.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseRed.Values.Text = "Red:";
            // 
            // kryptonListBox1
            // 
            this.kryptonListBox1.Location = new System.Drawing.Point(13, 13);
            this.kryptonListBox1.Name = "kryptonListBox1";
            this.kryptonListBox1.Size = new System.Drawing.Size(185, 171);
            this.kryptonListBox1.TabIndex = 24;
            // 
            // pbxColourPreview
            // 
            this.pbxColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.pbxColourPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxColourPreview.Location = new System.Drawing.Point(204, 13);
            this.pbxColourPreview.Name = "pbxColourPreview";
            this.pbxColourPreview.Size = new System.Drawing.Size(671, 112);
            this.pbxColourPreview.TabIndex = 156;
            this.pbxColourPreview.TabStop = false;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(143, 206);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(116, 25);
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 157;
            this.kryptonButton1.Values.Text = "Generate &Red";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(412, 206);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(139, 25);
            this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton2.TabIndex = 158;
            this.kryptonButton2.Values.Text = "Generate Gr&een";
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.Location = new System.Drawing.Point(691, 206);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(124, 25);
            this.kryptonButton3.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton3.TabIndex = 159;
            this.kryptonButton3.Values.Text = "Generate &Blue";
            // 
            // kryptonLabelExtended1
            // 
            this.kryptonLabelExtended1.Image = null;
            this.kryptonLabelExtended1.Location = new System.Drawing.Point(205, 146);
            this.kryptonLabelExtended1.LongTextTypeface = null;
            this.kryptonLabelExtended1.Name = "kryptonLabelExtended1";
            this.kryptonLabelExtended1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.Size = new System.Drawing.Size(141, 21);
            this.kryptonLabelExtended1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.TabIndex = 160;
            this.kryptonLabelExtended1.Values.Text = "Standard Colours:";
            // 
            // kryptonComboBoxExtended1
            // 
            this.kryptonComboBoxExtended1.ComboBoxContentTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.ComboBoxItemContentLongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.ComboBoxItemContentShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.DropDownWidth = 191;
            this.kryptonComboBoxExtended1.Image = null;
            this.kryptonComboBoxExtended1.IntegralHeight = false;
            this.kryptonComboBoxExtended1.Location = new System.Drawing.Point(352, 146);
            this.kryptonComboBoxExtended1.Name = "kryptonComboBoxExtended1";
            this.kryptonComboBoxExtended1.Size = new System.Drawing.Size(191, 22);
            this.kryptonComboBoxExtended1.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended1.StateActiveComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateActiveComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateActiveComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateActiveComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBoxExtended1.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateCommonComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxDropBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxDropBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended1.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateDisabledComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended1.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateNormalComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.TabIndex = 161;
            this.kryptonComboBoxExtended1.Text = "kryptonComboBoxExtended1";
            // 
            // kryptonComboBoxExtended2
            // 
            this.kryptonComboBoxExtended2.ComboBoxContentTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.ComboBoxItemContentLongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.ComboBoxItemContentShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.DropDownWidth = 191;
            this.kryptonComboBoxExtended2.Image = null;
            this.kryptonComboBoxExtended2.IntegralHeight = false;
            this.kryptonComboBoxExtended2.Location = new System.Drawing.Point(684, 146);
            this.kryptonComboBoxExtended2.Name = "kryptonComboBoxExtended2";
            this.kryptonComboBoxExtended2.Size = new System.Drawing.Size(191, 22);
            this.kryptonComboBoxExtended2.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended2.StateActiveComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateActiveComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateActiveComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateActiveComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBoxExtended2.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateCommonComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxDropBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxDropBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended2.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateDisabledComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended2.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateNormalComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.TabIndex = 163;
            this.kryptonComboBoxExtended2.Text = "kryptonComboBoxExtended2";
            // 
            // kryptonLabelExtended2
            // 
            this.kryptonLabelExtended2.Image = null;
            this.kryptonLabelExtended2.Location = new System.Drawing.Point(549, 146);
            this.kryptonLabelExtended2.LongTextTypeface = null;
            this.kryptonLabelExtended2.Name = "kryptonLabelExtended2";
            this.kryptonLabelExtended2.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended2.Size = new System.Drawing.Size(129, 21);
            this.kryptonLabelExtended2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended2.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended2.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended2.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.TabIndex = 162;
            this.kryptonLabelExtended2.Values.Text = "System Colours:";
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.AutoSize = true;
            this.kryptonButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton4.Location = new System.Drawing.Point(12, 8);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(161, 25);
            this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton4.TabIndex = 158;
            this.kryptonButton4.Values.Text = "Save &Selected Colour";
            // 
            // kryptonButton5
            // 
            this.kryptonButton5.AutoSize = true;
            this.kryptonButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton5.Location = new System.Drawing.Point(179, 8);
            this.kryptonButton5.Name = "kryptonButton5";
            this.kryptonButton5.Size = new System.Drawing.Size(163, 25);
            this.kryptonButton5.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton5.TabIndex = 159;
            this.kryptonButton5.Values.Text = "Utilise as Base &Colour";
            // 
            // kryptonLabelExtended3
            // 
            this.kryptonLabelExtended3.Image = null;
            this.kryptonLabelExtended3.Location = new System.Drawing.Point(348, 11);
            this.kryptonLabelExtended3.LongTextTypeface = null;
            this.kryptonLabelExtended3.Name = "kryptonLabelExtended3";
            this.kryptonLabelExtended3.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended3.Size = new System.Drawing.Size(161, 21);
            this.kryptonLabelExtended3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended3.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended3.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended3.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.TabIndex = 161;
            this.kryptonLabelExtended3.Values.Text = "Hexadecimal Colour:";
            // 
            // colourHexadecimalTextBox1
            // 
            this.colourHexadecimalTextBox1.Colour = System.Drawing.Color.Empty;
            this.colourHexadecimalTextBox1.Hint = "000000";
            this.colourHexadecimalTextBox1.Location = new System.Drawing.Point(516, 9);
            this.colourHexadecimalTextBox1.MaxLength = 6;
            this.colourHexadecimalTextBox1.Name = "colourHexadecimalTextBox1";
            this.colourHexadecimalTextBox1.Size = new System.Drawing.Size(100, 24);
            this.colourHexadecimalTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colourHexadecimalTextBox1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.colourHexadecimalTextBox1.TabIndex = 162;
            // 
            // CustomPaletteColours
            // 
            this.ClientSize = new System.Drawing.Size(887, 287);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kpnlButtons);
            this.Name = "CustomPaletteColours";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxExtended1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxExtended2)).EndInit();
            this.ResumeLayout(false);

        }
    }
}