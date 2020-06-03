using Krypton.Toolkit.Extended.Base;
using Microsoft.VisualBasic;
using System;

namespace Krypton.Toolkit.Extended.Navigator
{
    public class OutlookBarNavigationPaneOptions : KryptonForm
    {
        #region Designer Code
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnReset;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnMoveDown;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnMoveUp;
        private Suite.Extended.Standard.Controls.KryptonCheckedListBoxExtended kclbItems;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended kryptonLabelExtended1;
        private System.Windows.Forms.CheckedListBox clbItems;
        private KryptonOKDialogButton kbtnOk;
        private KryptonCancelDialogButton kbtnCancel;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.Extended.Base.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Extended.Base.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.clbItems = new System.Windows.Forms.CheckedListBox();
            this.kbtnReset = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnMoveDown = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnMoveUp = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kclbItems = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonCheckedListBoxExtended();
            this.kryptonLabelExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 264);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(479, 46);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(281, 9);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 6;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(377, 9);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 5;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 3);
            this.panel1.TabIndex = 3;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.clbItems);
            this.kryptonPanel2.Controls.Add(this.kbtnReset);
            this.kryptonPanel2.Controls.Add(this.kbtnMoveDown);
            this.kryptonPanel2.Controls.Add(this.kbtnMoveUp);
            this.kryptonPanel2.Controls.Add(this.kclbItems);
            this.kryptonPanel2.Controls.Add(this.kryptonLabelExtended1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(479, 261);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // clbItems
            // 
            this.clbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbItems.FormattingEnabled = true;
            this.clbItems.Location = new System.Drawing.Point(12, 39);
            this.clbItems.Name = "clbItems";
            this.clbItems.Size = new System.Drawing.Size(360, 208);
            this.clbItems.TabIndex = 5;
            this.clbItems.SelectedIndexChanged += new System.EventHandler(this.clbItems_SelectedIndexChanged);
            // 
            // kbtnReset
            // 
            this.kbtnReset.Image = null;
            this.kbtnReset.Location = new System.Drawing.Point(378, 230);
            this.kbtnReset.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.Name = "kbtnReset";
            this.kbtnReset.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.Size = new System.Drawing.Size(90, 25);
            this.kbtnReset.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnReset.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnReset.TabIndex = 8;
            this.kbtnReset.Values.Text = "&Reset";
            this.kbtnReset.Click += new System.EventHandler(this.kbtnReset_Click);
            // 
            // kbtnMoveDown
            // 
            this.kbtnMoveDown.Enabled = false;
            this.kbtnMoveDown.Image = null;
            this.kbtnMoveDown.Location = new System.Drawing.Point(378, 70);
            this.kbtnMoveDown.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.Name = "kbtnMoveDown";
            this.kbtnMoveDown.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.Size = new System.Drawing.Size(90, 25);
            this.kbtnMoveDown.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveDown.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveDown.TabIndex = 7;
            this.kbtnMoveDown.Values.Text = "Move &Down";
            this.kbtnMoveDown.Click += new System.EventHandler(this.kbtnMoveDown_Click);
            // 
            // kbtnMoveUp
            // 
            this.kbtnMoveUp.Enabled = false;
            this.kbtnMoveUp.Image = null;
            this.kbtnMoveUp.Location = new System.Drawing.Point(378, 39);
            this.kbtnMoveUp.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.Name = "kbtnMoveUp";
            this.kbtnMoveUp.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.Size = new System.Drawing.Size(90, 25);
            this.kbtnMoveUp.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnMoveUp.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnMoveUp.TabIndex = 6;
            this.kbtnMoveUp.Values.Text = "Move &Up";
            this.kbtnMoveUp.Click += new System.EventHandler(this.kbtnMoveUp_Click);
            // 
            // kclbItems
            // 
            this.kclbItems.Image = null;
            this.kclbItems.Location = new System.Drawing.Point(12, 39);
            this.kclbItems.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.Name = "kclbItems";
            this.kclbItems.OverrideFocus.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.OverrideFocus.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.OverrideFocus.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.OverrideFocus.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.OverrideFocus.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.OverrideFocus.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.OverrideFocusItemBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.OverrideFocusItemBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.OverrideFocusLongTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.OverrideFocusLongTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.OverrideFocusShortTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.OverrideFocusShortTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.Size = new System.Drawing.Size(359, 216);
            this.kclbItems.StateActiveBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateActiveBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateActiveBorderColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateActiveBorderColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateCheckedNormal.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedNormal.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateCheckedNormal.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedNormal.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateCheckedNormalItemBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateCheckedNormalItemBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateCheckedNormalLongTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedNormalLongTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedNormalShortTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedNormalShortTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressed.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressed.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressed.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateCheckedPressed.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressed.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressed.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateCheckedPressedItemBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateCheckedPressedItemBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateCheckedPressedLongTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressedLongTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressedShortTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressedShortTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTracking.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTracking.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateCheckedTracking.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTracking.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateCheckedTrackingItemBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateCheckedTrackingItemBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateCheckedTrackingLongTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTrackingLongTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTrackingShortTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTrackingShortTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommon.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommon.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateCommon.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommon.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateCommonBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateCommonBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateCommonItemBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateCommonItemBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateCommonLongTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommonLongTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommonShortTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommonShortTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabled.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabled.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateDisabled.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabled.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateDisabledBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateDisabledBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateDisabledItemBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateDisabledItemBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateDisabledLongTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabledLongTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabledShortTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabledShortTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormal.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormal.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateNormal.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormal.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateNormalBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateNormalBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateNormalItemBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateNormalItemBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateNormalLongTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormalLongTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormalShortTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormalShortTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressed.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressed.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressed.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StatePressed.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressed.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressed.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StatePressedItemBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StatePressedItemBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StatePressedLongTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressedLongTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressedShortTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressedShortTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTracking.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTracking.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateTracking.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTracking.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateTrackingItemBackgroundColourOne = System.Drawing.Color.Empty;
            this.kclbItems.StateTrackingItemBackgroundColourTwo = System.Drawing.Color.Empty;
            this.kclbItems.StateTrackingLongTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTrackingLongTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTrackingShortTextColourOne = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTrackingShortTextColourTwo = System.Drawing.SystemColors.ControlText;
            this.kclbItems.TabIndex = 5;
            this.kclbItems.Visible = false;
            this.kclbItems.SelectedIndexChanged += new System.EventHandler(this.kclbItems_SelectedIndexChanged);
            // 
            // kryptonLabelExtended1
            // 
            this.kryptonLabelExtended1.Image = null;
            this.kryptonLabelExtended1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabelExtended1.LongTextTypeface = null;
            this.kryptonLabelExtended1.Name = "kryptonLabelExtended1";
            this.kryptonLabelExtended1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.Size = new System.Drawing.Size(209, 21);
            this.kryptonLabelExtended1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.TabIndex = 5;
            this.kryptonLabelExtended1.Values.Text = "Display buttons in this order";
            // 
            // OutlookBarNavigationPaneOptions
            // 
            this.ClientSize = new System.Drawing.Size(479, 310);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutlookBarNavigationPaneOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Navigation Pane Options";
            this.Load += new System.EventHandler(this.OutlookBarNavigationPaneOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private OutlookBarButtonCollection _items;

        private Collection _originalItems = new Collection();
        #endregion

        #region Constructor
        public OutlookBarNavigationPaneOptions(OutlookBarButtonCollection items)
        {
            InitializeComponent();

            _items = items;

            foreach (OutlookBarButton item in _items)
            {
                _originalItems.Add(item, null, null, null);
            }

            FillList();

            clbItems.SelectedIndex = 0;
        }
        #endregion

        private void FillList()
        {
            clbItems.Items.Clear();

            foreach (OutlookBarButton item in _items)
            {
                if (item.Allowed) clbItems.Items.Add(item, item.Visible);
            }
        }

        private void OutlookBarNavigationPaneOptions_Load(object sender, EventArgs e)
        {

        }

        private void kbtnMoveUp_Click(object sender, EventArgs e)
        {
            int newIndex = clbItems.SelectedIndex - 1;

            _items.Insert(newIndex, (OutlookBarButton)clbItems.SelectedItem);

            _items.RemoveAt(newIndex + 2);

            FillList();

            clbItems.SelectedIndex = newIndex;
        }

        private void kbtnMoveDown_Click(object sender, EventArgs e)
        {
            OutlookBarButton button = (OutlookBarButton)clbItems.SelectedItem;

            int newIndex = clbItems.SelectedIndex + 2;

            _items.Insert(newIndex, (OutlookBarButton)clbItems.SelectedItem);

            _items.Remove(button);

            FillList();

            clbItems.SelectedIndex = newIndex - 1;
        }

        private void kbtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            _items.Clear();

            foreach (OutlookBarButton item in _items)
            {
                _items.Add(item);
            }
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            foreach (OutlookBarButton item in _items)
            {
                item.Visible = false;
            }

            for (int i = 0; i <= clbItems.CheckedItems.Count - 1; i++)
            {
                ((OutlookBarButton)clbItems.CheckedItems[i]).Visible = true;
            }

            Close();
        }

        private void kclbItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbItems.SelectedIndex == 0)
            {
                kbtnMoveUp.Enabled = false;
            }
            else
            {
                kbtnMoveUp.Enabled = true;
            }

            if (clbItems.SelectedIndex == clbItems.Items.Count - 1)
            {
                kbtnMoveDown.Enabled = false;
            }
            else
            {
                kbtnMoveDown.Enabled = true;
            }

            if (clbItems.Items.Count == 1)
            {
                kbtnMoveDown.Enabled = false;

                kbtnMoveUp.Enabled = false;
            }
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}