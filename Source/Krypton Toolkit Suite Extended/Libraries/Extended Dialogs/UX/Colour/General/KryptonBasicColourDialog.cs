using System;
using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Extended.Dialogs
{
    [DefaultEvent("SelectedColourChanged"), DefaultProperty("Colour")]
    public class KryptonBasicColourDialog : KryptonForm
    {
        #region Designer Code
        private Colour.Controls.KryptonAlphaValueLabel kryptonAlphaValueLabel1;
        private KryptonOKDialogButton kbtnOk;
        private KryptonCancelDialogButton kbtnCancel;
        private KryptonPanel kryptonPanel1;
        private Colour.Controls.KryptonGreenValueLabel klblGreenValue;
        private Colour.Controls.KryptonBlueValueLabel klblBlueValue;
        private Colour.Controls.KryptonRedValueLabel klblRedValue;
        private Base.CircularPictureBox cpbxColourPreview;
        private Colour.Controls.ColourWheelControl cwColourPicker;
        private System.Windows.Forms.Panel panel1;
        private Colour.Controls.ColourHexadecimalTextBox txtHexColour;
        private KryptonPanel kpnlButtons;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonBasicColourDialog));
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.txtHexColour = new Krypton.Toolkit.Extended.Colour.Controls.ColourHexadecimalTextBox();
            this.kryptonAlphaValueLabel1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.kbtnOk = new Krypton.Toolkit.Extended.Dialogs.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.klblGreenValue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblBlueValue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblRedValue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueLabel();
            this.cpbxColourPreview = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.cwColourPicker = new Krypton.Toolkit.Extended.Colour.Controls.ColourWheelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxColourPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.txtHexColour);
            this.kpnlButtons.Controls.Add(this.kryptonAlphaValueLabel1);
            this.kpnlButtons.Controls.Add(this.kbtnOk);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 200);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(506, 44);
            this.kpnlButtons.TabIndex = 0;
            // 
            // txtHexColour
            // 
            this.txtHexColour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHexColour.Colour = System.Drawing.Color.Empty;
            this.txtHexColour.Hint = "000000";
            this.txtHexColour.Location = new System.Drawing.Point(172, 9);
            this.txtHexColour.MaxLength = 6;
            this.txtHexColour.Name = "txtHexColour";
            this.txtHexColour.Size = new System.Drawing.Size(100, 23);
            this.txtHexColour.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.txtHexColour.TabIndex = 3;
            this.txtHexColour.TextChanged += new System.EventHandler(this.txtHexColour_TextChanged);
            // 
            // kryptonAlphaValueLabel1
            // 
            this.kryptonAlphaValueLabel1.AlphaValue = 255;
            this.kryptonAlphaValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonAlphaValueLabel1.Location = new System.Drawing.Point(12, 9);
            this.kryptonAlphaValueLabel1.Name = "kryptonAlphaValueLabel1";
            this.kryptonAlphaValueLabel1.Size = new System.Drawing.Size(154, 21);
            this.kryptonAlphaValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel1.TabIndex = 3;
            this.kryptonAlphaValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel1.Values.Text = "Hexadecimal Value:";
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Image = null;
            this.kbtnOk.Location = new System.Drawing.Point(308, 7);
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
            this.kbtnOk.TabIndex = 2;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Image = null;
            this.kbtnCancel.Location = new System.Drawing.Point(404, 7);
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
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.klblGreenValue);
            this.kryptonPanel1.Controls.Add(this.klblBlueValue);
            this.kryptonPanel1.Controls.Add(this.klblRedValue);
            this.kryptonPanel1.Controls.Add(this.cpbxColourPreview);
            this.kryptonPanel1.Controls.Add(this.cwColourPicker);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(506, 200);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // klblGreenValue
            // 
            this.klblGreenValue.Location = new System.Drawing.Point(209, 127);
            this.klblGreenValue.Name = "klblGreenValue";
            this.klblGreenValue.RedValue = 255;
            this.klblGreenValue.Size = new System.Drawing.Size(91, 21);
            this.klblGreenValue.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.klblGreenValue.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.klblGreenValue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblGreenValue.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.klblGreenValue.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.klblGreenValue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreenValue.TabIndex = 4;
            this.klblGreenValue.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblGreenValue.Values.Text = "Green: 255";
            // 
            // klblBlueValue
            // 
            this.klblBlueValue.Location = new System.Drawing.Point(212, 88);
            this.klblBlueValue.Name = "klblBlueValue";
            this.klblBlueValue.RedValue = 255;
            this.klblBlueValue.Size = new System.Drawing.Size(79, 21);
            this.klblBlueValue.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBlueValue.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.klblBlueValue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlueValue.TabIndex = 3;
            this.klblBlueValue.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBlueValue.Values.Text = "Blue: 255";
            // 
            // klblRedValue
            // 
            this.klblRedValue.Location = new System.Drawing.Point(212, 49);
            this.klblRedValue.Name = "klblRedValue";
            this.klblRedValue.RedValue = 255;
            this.klblRedValue.Size = new System.Drawing.Size(76, 21);
            this.klblRedValue.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRedValue.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.klblRedValue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRedValue.TabIndex = 2;
            this.klblRedValue.TextSize = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRedValue.Values.Text = "Red: 255";
            // 
            // cpbxColourPreview
            // 
            this.cpbxColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.cpbxColourPreview.Location = new System.Drawing.Point(331, 12);
            this.cpbxColourPreview.Name = "cpbxColourPreview";
            this.cpbxColourPreview.Size = new System.Drawing.Size(163, 163);
            this.cpbxColourPreview.TabIndex = 1;
            this.cpbxColourPreview.TabStop = false;
            this.cpbxColourPreview.ToolTipValues = null;
            // 
            // cwColourPicker
            // 
            this.cwColourPicker.BackColor = System.Drawing.Color.Transparent;
            this.cwColourPicker.Location = new System.Drawing.Point(12, 12);
            this.cwColourPicker.Name = "cwColourPicker";
            this.cwColourPicker.Size = new System.Drawing.Size(163, 163);
            this.cwColourPicker.TabIndex = 0;
            this.cwColourPicker.ColourChanged += new System.EventHandler(this.cwColourPicker_ColourChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 197);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 3);
            this.panel1.TabIndex = 2;
            // 
            // KryptonBasicColourDialog
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(506, 244);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonBasicColourDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Colour Dialog";
            this.Load += new System.EventHandler(this.KryptonBasicColourDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxColourPreview)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constants
        private static readonly object _eventSelectedColourChanged = new object();
        #endregion

        #region Events
        [Category("Property Changed")]
        public event EventHandler SelectedColourChanged { add => Events.AddHandler(_eventSelectedColourChanged, value); remove => Events.RemoveHandler(_eventSelectedColourChanged, value); }
        #endregion

        #region Variables
        private Color _colour;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set { _colour = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonBasicColourDialog()
        {
            Invalidate();

            Colour = Color.Empty;
        }
        #endregion

        #region Virtuals
        protected virtual void OnSelectedColourChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)Events[_eventSelectedColourChanged];

            handler?.Invoke(this, e);
        }
        #endregion

        private void KryptonBasicColourDialog_Load(object sender, EventArgs e)
        {

        }

        private void cwColourPicker_ColourChanged(object sender, EventArgs e)
        {

        }

        private void txtHexColour_TextChanged(object sender, EventArgs e)
        {

        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {

        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}