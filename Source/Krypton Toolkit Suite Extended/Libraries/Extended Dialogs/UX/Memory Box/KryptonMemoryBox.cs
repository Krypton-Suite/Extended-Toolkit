using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonMemoryBox : KryptonForm
    {
        private KryptonLabel klblBody;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private KryptonYesDialogButton kryptonYesDialogButton1;
        private KryptonNODialogButton kryptonNODialogButton1;
        private KryptonCancelDialogButton kryptonCancelDialogButton1;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonMemoryBox));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonYesDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonYesDialogButton();
            this.kryptonNODialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonNODialogButton();
            this.kryptonCancelDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.klblBody = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.klblBody);
            this.kryptonPanel1.Controls.Add(this.pictureBoxIcon);
            this.kryptonPanel1.Controls.Add(this.kryptonYesDialogButton1);
            this.kryptonPanel1.Controls.Add(this.kryptonNODialogButton1);
            this.kryptonPanel1.Controls.Add(this.kryptonCancelDialogButton1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(470, 280);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonYesDialogButton1
            // 
            this.kryptonYesDialogButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonYesDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.kryptonYesDialogButton1.Image = null;
            this.kryptonYesDialogButton1.Location = new System.Drawing.Point(12, 243);
            this.kryptonYesDialogButton1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.Name = "kryptonYesDialogButton1";
            this.kryptonYesDialogButton1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonYesDialogButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonYesDialogButton1.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonYesDialogButton1.TabIndex = 1;
            this.kryptonYesDialogButton1.Values.Text = "&Yes";
            // 
            // kryptonNODialogButton1
            // 
            this.kryptonNODialogButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonNODialogButton1.DialogResult = System.Windows.Forms.DialogResult.No;
            this.kryptonNODialogButton1.Image = null;
            this.kryptonNODialogButton1.Location = new System.Drawing.Point(154, 243);
            this.kryptonNODialogButton1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.Name = "kryptonNODialogButton1";
            this.kryptonNODialogButton1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonNODialogButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonNODialogButton1.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonNODialogButton1.TabIndex = 2;
            this.kryptonNODialogButton1.Values.Text = "&No";
            // 
            // kryptonCancelDialogButton1
            // 
            this.kryptonCancelDialogButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonCancelDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonCancelDialogButton1.Image = null;
            this.kryptonCancelDialogButton1.Location = new System.Drawing.Point(368, 243);
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
            this.kryptonCancelDialogButton1.TabIndex = 3;
            this.kryptonCancelDialogButton1.Values.Text = "C&ancel";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIcon.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxIcon.TabIndex = 4;
            this.pictureBoxIcon.TabStop = false;
            // 
            // klblBody
            // 
            this.klblBody.Location = new System.Drawing.Point(118, 12);
            this.klblBody.Name = "klblBody";
            this.klblBody.Size = new System.Drawing.Size(316, 211);
            this.klblBody.TabIndex = 1;
            this.klblBody.Values.Text = resources.GetString("kryptonLabel1.Values.Text");
            // 
            // KryptonMemoryBox
            // 
            this.ClientSize = new System.Drawing.Size(470, 280);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonMemoryBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }
    }
}