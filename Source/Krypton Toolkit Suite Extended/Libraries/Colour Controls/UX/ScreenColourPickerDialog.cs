using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class ScreenColourPickerDialog : KryptonForm
    {
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private Cyotek.Windows.Forms.ColorEditorManager cem;
        private Extended.Dialogs.KryptonOKDialogButton kryptonOKDialogButton1;
        private Extended.Dialogs.KryptonCancelDialogButton kryptonCancelDialogButton1;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.cem = new Cyotek.Windows.Forms.ColorEditorManager();
            this.kryptonCancelDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.kryptonOKDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonOKDialogButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonOKDialogButton1);
            this.kryptonPanel1.Controls.Add(this.kryptonCancelDialogButton1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 318);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(577, 39);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(577, 315);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kryptonCancelDialogButton1
            // 
            this.kryptonCancelDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonCancelDialogButton1.Image = null;
            this.kryptonCancelDialogButton1.Location = new System.Drawing.Point(475, 6);
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
            this.kryptonCancelDialogButton1.TabIndex = 0;
            this.kryptonCancelDialogButton1.Values.Text = "C&ancel";
            // 
            // kryptonOKDialogButton1
            // 
            this.kryptonOKDialogButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonOKDialogButton1.Image = null;
            this.kryptonOKDialogButton1.Location = new System.Drawing.Point(379, 6);
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
            this.kryptonOKDialogButton1.TabIndex = 1;
            this.kryptonOKDialogButton1.Values.Text = "&OK";
            // 
            // ScreenColourPickerDialog
            // 
            this.ClientSize = new System.Drawing.Size(577, 357);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenColourPickerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.ResumeLayout(false);

        }
    }
}