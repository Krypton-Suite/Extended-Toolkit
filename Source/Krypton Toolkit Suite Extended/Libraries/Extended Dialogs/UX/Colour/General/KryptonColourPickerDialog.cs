using System;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonColourPickerDialog : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private Colour.Controls.ColourWheelControl cwColour;
        private KryptonCancelDialogButton kryptonCancelDialogButton1;
        private Colour.Controls.ColourEditorManager cem;
        private Colour.Controls.ColourEditorUserControl ceColours;
        private Colour.Controls.ScreenColourPickerControl scp;
        private Cyotek.Windows.Forms.ColorGrid cgColours;
        private Core.CircularPictureBox circularPictureBox1;
        private KryptonButton kryptonButton2;
        private KryptonButton kbtnLoadPalette;
        private KryptonOKDialogButton kryptonOKDialogButton1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonColourPickerDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kbtnLoadPalette = new Krypton.Toolkit.KryptonButton();
            this.cgColours = new Cyotek.Windows.Forms.ColorGrid();
            this.circularPictureBox1 = new Krypton.Toolkit.Extended.Core.CircularPictureBox();
            this.scp = new Krypton.Toolkit.Extended.Colour.Controls.ScreenColourPickerControl();
            this.ceColours = new Krypton.Toolkit.Extended.Colour.Controls.ColourEditorUserControl();
            this.cwColour = new Krypton.Toolkit.Extended.Colour.Controls.ColourWheelControl();
            this.kryptonCancelDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.kryptonOKDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonOKDialogButton();
            this.cem = new Krypton.Toolkit.Extended.Colour.Controls.ColourEditorManager();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButton2);
            this.kryptonPanel1.Controls.Add(this.kbtnLoadPalette);
            this.kryptonPanel1.Controls.Add(this.cgColours);
            this.kryptonPanel1.Controls.Add(this.circularPictureBox1);
            this.kryptonPanel1.Controls.Add(this.scp);
            this.kryptonPanel1.Controls.Add(this.ceColours);
            this.kryptonPanel1.Controls.Add(this.cwColour);
            this.kryptonPanel1.Controls.Add(this.kryptonCancelDialogButton1);
            this.kryptonPanel1.Controls.Add(this.kryptonOKDialogButton1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(574, 544);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.AutoSize = true;
            this.kryptonButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton2.Location = new System.Drawing.Point(40, 345);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(22, 22);
            this.kryptonButton2.TabIndex = 4;
            this.kryptonButton2.Values.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_save;
            this.kryptonButton2.Values.Text = "";
            // 
            // kbtnLoadPalette
            // 
            this.kbtnLoadPalette.AutoSize = true;
            this.kbtnLoadPalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLoadPalette.Location = new System.Drawing.Point(12, 345);
            this.kbtnLoadPalette.Name = "kbtnLoadPalette";
            this.kbtnLoadPalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnLoadPalette.TabIndex = 1;
            this.kbtnLoadPalette.Values.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtnLoadPalette.Values.Text = "";
            // 
            // cgColours
            // 
            this.cgColours.BackColor = System.Drawing.Color.Transparent;
            this.cgColours.Location = new System.Drawing.Point(12, 373);
            this.cgColours.Name = "cgColours";
            this.cgColours.Size = new System.Drawing.Size(247, 165);
            this.cgColours.TabIndex = 3;
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.circularPictureBox1.Location = new System.Drawing.Point(443, 252);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(119, 119);
            this.circularPictureBox1.TabIndex = 2;
            this.circularPictureBox1.TabStop = false;
            this.circularPictureBox1.ToolTipValues = null;
            // 
            // scp
            // 
            this.scp.Colour = System.Drawing.Color.Empty;
            this.scp.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.eyedropper;
            this.scp.Location = new System.Drawing.Point(443, 87);
            this.scp.Name = "scp";
            this.scp.Size = new System.Drawing.Size(119, 103);
            // 
            // ceColours
            // 
            this.ceColours.AutoSize = true;
            this.ceColours.BackColor = System.Drawing.Color.Transparent;
            this.ceColours.Location = new System.Drawing.Point(162, 12);
            this.ceColours.Name = "ceColours";
            this.ceColours.Size = new System.Drawing.Size(274, 359);
            this.ceColours.TabIndex = 1;
            // 
            // cwColour
            // 
            this.cwColour.BackColor = System.Drawing.Color.Transparent;
            this.cwColour.Location = new System.Drawing.Point(12, 12);
            this.cwColour.Name = "cwColour";
            this.cwColour.Size = new System.Drawing.Size(144, 144);
            this.cwColour.TabIndex = 1;
            // 
            // kryptonCancelDialogButton1
            // 
            this.kryptonCancelDialogButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonCancelDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonCancelDialogButton1.Image = null;
            this.kryptonCancelDialogButton1.Location = new System.Drawing.Point(472, 43);
            this.kryptonCancelDialogButton1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.Name = "kryptonCancelDialogButton1";
            this.kryptonCancelDialogButton1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonCancelDialogButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.TabIndex = 1;
            this.kryptonCancelDialogButton1.Values.Text = "C&ancel";
            // 
            // kryptonOKDialogButton1
            // 
            this.kryptonOKDialogButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonOKDialogButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonOKDialogButton1.Image = null;
            this.kryptonOKDialogButton1.Location = new System.Drawing.Point(472, 12);
            this.kryptonOKDialogButton1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.Name = "kryptonOKDialogButton1";
            this.kryptonOKDialogButton1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonOKDialogButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.TabIndex = 0;
            this.kryptonOKDialogButton1.Values.Text = "&OK";
            // 
            // cem
            // 
            this.cem.Color = System.Drawing.Color.Empty;
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
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void KryptonColourPickerDialog_Load(object sender, EventArgs e)
        {

        }
    }
}