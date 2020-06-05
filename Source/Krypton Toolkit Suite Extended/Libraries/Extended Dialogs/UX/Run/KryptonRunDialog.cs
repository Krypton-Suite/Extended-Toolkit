using Krypton.Toolkit.Extended.Core;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonRunDialog : KryptonForm
    {
        #region Design Code
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended kryptonLabelExtended1;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klblMessage;
        private System.Windows.Forms.PictureBox pbxIcon;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnRun;
        private Base.KryptonUACElevatedButton kuacRun;
        private KryptonCancelDialogButton kcdbCancel;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnBrowse;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtneLocate;
        private Suite.Extended.Standard.Controls.KryptonTextBoxExtended ktxteUserInput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Suite.Extended.Standard.Controls.KryptonComboBoxExtended kcmbeUserInput;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonRunDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnRun = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kuacRun = new Krypton.Toolkit.Extended.Base.KryptonUACElevatedButton();
            this.kcdbCancel = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.kbtnBrowse = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtneLocate = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.ktxteUserInput = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonTextBoxExtended();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kcmbeUserInput = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonComboBoxExtended();
            this.kryptonLabelExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.klblMessage = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbeUserInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnRun);
            this.kryptonPanel1.Controls.Add(this.kuacRun);
            this.kryptonPanel1.Controls.Add(this.kcdbCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnBrowse);
            this.kryptonPanel1.Controls.Add(this.kbtneLocate);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 238);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(647, 45);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnRun
            // 
            this.kbtnRun.Image = null;
            this.kbtnRun.Location = new System.Drawing.Point(352, 8);
            this.kbtnRun.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRun.Name = "kbtnRun";
            this.kbtnRun.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRun.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnRun.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRun.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnRun.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnRun.Size = new System.Drawing.Size(90, 25);
            this.kbtnRun.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRun.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnRun.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRun.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnRun.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRun.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnRun.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRun.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnRun.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRun.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnRun.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnRun.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnRun.TabIndex = 5;
            this.kbtnRun.Values.Text = "&Run";
            this.kbtnRun.Click += new System.EventHandler(this.kbtnRun_Click);
            // 
            // kuacRun
            // 
            this.kuacRun.Location = new System.Drawing.Point(352, 8);
            this.kuacRun.Name = "kuacRun";
            this.kuacRun.ProcessToElevate = null;
            this.kuacRun.ShowUACShield = true;
            this.kuacRun.Size = new System.Drawing.Size(91, 25);
            this.kuacRun.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kuacRun.TabIndex = 4;
            this.kuacRun.Values.Text = "&Run";
            this.kuacRun.ExecuteProcessAsAdministrator += new Krypton.Toolkit.Extended.Base.KryptonUACElevatedButton.ExecuteProcessAsAdministratorEventHandler(this.kuacRun_ExecuteProcessAsAdministrator);
            this.kuacRun.Click += new System.EventHandler(this.kuacRun_Click);
            // 
            // kcdbCancel
            // 
            this.kcdbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kcdbCancel.Location = new System.Drawing.Point(449, 8);
            this.kcdbCancel.Name = "kcdbCancel";
            this.kcdbCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcdbCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcdbCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcdbCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcdbCancel.Size = new System.Drawing.Size(90, 25);
            this.kcdbCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcdbCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcdbCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcdbCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcdbCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcdbCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcdbCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcdbCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcdbCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcdbCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcdbCancel.TabIndex = 2;
            this.kcdbCancel.Values.Text = "C&ancel";
            this.kcdbCancel.Click += new System.EventHandler(this.kcdbCancel_Click);
            // 
            // kbtnBrowse
            // 
            this.kbtnBrowse.Image = null;
            this.kbtnBrowse.Location = new System.Drawing.Point(545, 8);
            this.kbtnBrowse.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowse.Name = "kbtnBrowse";
            this.kbtnBrowse.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowse.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnBrowse.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowse.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnBrowse.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnBrowse.Size = new System.Drawing.Size(90, 25);
            this.kbtnBrowse.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowse.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnBrowse.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowse.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnBrowse.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowse.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnBrowse.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowse.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnBrowse.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowse.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtnBrowse.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnBrowse.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnBrowse.TabIndex = 1;
            this.kbtnBrowse.Values.Text = "&Browse";
            this.kbtnBrowse.Click += new System.EventHandler(this.kbtnBrowse_Click);
            // 
            // kbtneLocate
            // 
            this.kbtneLocate.Image = null;
            this.kbtneLocate.Location = new System.Drawing.Point(12, 8);
            this.kbtneLocate.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtneLocate.Name = "kbtneLocate";
            this.kbtneLocate.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtneLocate.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtneLocate.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtneLocate.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtneLocate.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtneLocate.Size = new System.Drawing.Size(90, 25);
            this.kbtneLocate.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtneLocate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtneLocate.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtneLocate.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtneLocate.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtneLocate.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtneLocate.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtneLocate.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtneLocate.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtneLocate.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kbtneLocate.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLocate.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLocate.TabIndex = 0;
            this.kbtneLocate.Values.Text = "L&ocate";
            this.kbtneLocate.Click += new System.EventHandler(this.kbtneLocate_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 235);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxteUserInput);
            this.kryptonPanel2.Controls.Add(this.pictureBox1);
            this.kryptonPanel2.Controls.Add(this.kcmbeUserInput);
            this.kryptonPanel2.Controls.Add(this.kryptonLabelExtended1);
            this.kryptonPanel2.Controls.Add(this.klblMessage);
            this.kryptonPanel2.Controls.Add(this.pbxIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(647, 235);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // ktxteUserInput
            // 
            this.ktxteUserInput.Location = new System.Drawing.Point(82, 191);
            this.ktxteUserInput.Name = "ktxteUserInput";
            this.ktxteUserInput.Size = new System.Drawing.Size(515, 24);
            this.ktxteUserInput.StateActive.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxteUserInput.StateActive.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxteUserInput.StateActiveBackGroundColour = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateActiveBorderColourOne = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateActiveBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateActiveTextColour = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxteUserInput.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxteUserInput.StateCommonBackGroundColour = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateCommonTextColour = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateDisabled.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxteUserInput.StateDisabled.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxteUserInput.StateDisabledBackGroundColour = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateDisabledTextColour = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxteUserInput.StateNormal.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxteUserInput.StateNormalBackgroundColour = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxteUserInput.StateNormalTextColour = System.Drawing.Color.Empty;
            this.ktxteUserInput.TabIndex = 8;
            this.ktxteUserInput.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxteUserInput.TextChanged += new System.EventHandler(this.ktxteUserInput_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(603, 187);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // kcmbeUserInput
            // 
            this.kcmbeUserInput.ComboBoxContentTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.ComboBoxItemContentLongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.ComboBoxItemContentShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.DropDownWidth = 515;
            this.kcmbeUserInput.Image = null;
            this.kcmbeUserInput.IntegralHeight = false;
            this.kcmbeUserInput.Location = new System.Drawing.Point(82, 193);
            this.kcmbeUserInput.Name = "kcmbeUserInput";
            this.kcmbeUserInput.Size = new System.Drawing.Size(515, 22);
            this.kcmbeUserInput.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeUserInput.StateActiveComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateActiveComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateActiveComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateActiveComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbeUserInput.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateCommonComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommonComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommonComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommonComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommonComboBoxDropBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommonComboBoxDropBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommonComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommonComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommonComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommonComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommonComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateCommonComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeUserInput.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateDisabledComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateDisabledComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateDisabledComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateDisabledComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateDisabledComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateDisabledComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateDisabledComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateDisabledComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateDisabledComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateDisabledComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeUserInput.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateNormalComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateNormalComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateNormalComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateNormalComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateNormalComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateNormalComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateNormalComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateNormalComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateNormalComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateNormalComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeUserInput.StateTrackingComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateTrackingComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateTrackingComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateTrackingComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateTrackingComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeUserInput.StateTrackingComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeUserInput.TabIndex = 4;
            this.kcmbeUserInput.TextUpdate += new System.EventHandler(this.kcmbeUserInput_TextUpdate);
            this.kcmbeUserInput.TextChanged += new System.EventHandler(this.kcmbeUserInput_TextChanged);
            // 
            // kryptonLabelExtended1
            // 
            this.kryptonLabelExtended1.Image = null;
            this.kryptonLabelExtended1.Location = new System.Drawing.Point(12, 193);
            this.kryptonLabelExtended1.LongTextTypeface = null;
            this.kryptonLabelExtended1.Name = "kryptonLabelExtended1";
            this.kryptonLabelExtended1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.Size = new System.Drawing.Size(52, 23);
            this.kryptonLabelExtended1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.TabIndex = 6;
            this.kryptonLabelExtended1.Values.Text = "Path:";
            // 
            // klblMessage
            // 
            this.klblMessage.AutoSize = false;
            this.klblMessage.Image = null;
            this.klblMessage.Location = new System.Drawing.Point(82, 12);
            this.klblMessage.LongTextTypeface = null;
            this.klblMessage.Name = "klblMessage";
            this.klblMessage.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMessage.Size = new System.Drawing.Size(553, 159);
            this.klblMessage.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMessage.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblMessage.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblMessage.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMessage.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblMessage.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblMessage.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMessage.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblMessage.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblMessage.TabIndex = 5;
            this.klblMessage.Values.Text = "Type the name of a application, file, directory or internet\r\nresource, and Window" +
    "s will open it for you.";
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.Run_48_x_48;
            this.pbxIcon.Location = new System.Drawing.Point(12, 60);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxIcon.TabIndex = 4;
            this.pbxIcon.TabStop = false;
            // 
            // KryptonRunDialog
            // 
            this.ClientSize = new System.Drawing.Size(647, 283);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonRunDialog";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbeUserInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Enumerations
        public enum Type
        {
            COMBOBOX,
            TEXTBOX
        }

        public enum IconVisibility
        {
            HIDDEN,
            VISIBLE
        }
        #endregion

        #region Variables
        private Type _type;

        private IconVisibility _iconVisibility;
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="KryptonRunDialog"/> class.</summary>
        /// <param name="type">The input type.</param>
        /// <param name="iconVisibility">The icon visibility.</param>
        public KryptonRunDialog(Type type = Type.TEXTBOX, IconVisibility iconVisibility = IconVisibility.VISIBLE)
        {
            InitializeComponent();

            SetInputType(type);

            SetIconVisibility(iconVisibility);

            AdaptUI(type, iconVisibility);
        }
        #endregion

        #region Methods
        /// <summary>Determines whether [has file extension] [the specified path].</summary>
        /// <param name="path">The file path.</param>
        /// <returns><c>true</c> if [has file extension] [the specified path]; otherwise, <c>false</c>.</returns>
        private bool HasFileExtension(string path)
        {
            if (Path.HasExtension(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Determines whether [is text box string empty].</summary>
        /// <returns><c>true</c> if [is text box string empty]; otherwise, <c>false</c>.</returns>
        private bool IsTextBoxStringEmpty() => string.IsNullOrEmpty(ktxteUserInput.Text);

        /// <summary>Determines whether [is ComboBox string empty].</summary>
        /// <returns><c>true</c> if [is ComboBox string empty]; otherwise, <c>false</c>.</returns>
        private bool IsComboBoxStringEmpty() => string.IsNullOrEmpty(kcmbeUserInput.Text);

        /// <summary>Runs the process.</summary>
        /// <param name="path">The file path.</param>
        private void RunProcess(string path)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(path);

                Process.Start(psi);

                Close();
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc);
            }
        }

        /// <summary>Gets the application icon.</summary>
        /// <param name="path">The file path.</param>
        /// <returns>The application icon.</returns>
        private Image GetApplicationIcon(string path) => Icon.ExtractAssociatedIcon(path).ToBitmap();

        /// <summary>Launches the process.</summary>
        /// <param name="path">The file path.</param>
        private void LaunchProcess(string path) => Process.Start("explorer.exe", path);

        /// <summary>Enables the run button.</summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void EnableRunButton(bool value) => kbtnRun.Enabled = value;

        /// <summary>Enables the locate button.</summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void EnableLocateButton(bool value) => kbtneLocate.Enabled = value;

        /// <summary>Adapts the UI.</summary>
        /// <param name="type">The input type.</param>
        /// <param name="iconVisibility">The icon visibility.</param>
        public void AdaptUI(Type type, IconVisibility iconVisibility)
        {
            switch (iconVisibility)
            {
                case IconVisibility.HIDDEN:
                    pbxIcon.Visible = false;

                    switch (type)
                    {
                        case Type.COMBOBOX:
                            kcmbeUserInput.Visible = true;

                            kcmbeUserInput.Size = new Size(614, 25);

                            ktxteUserInput.Visible = false;
                            break;
                        case Type.TEXTBOX:
                            kcmbeUserInput.Visible = false;

                            ktxteUserInput.Visible = true;

                            ktxteUserInput.Size = new Size(614, 25);
                            break;
                    }
                    break;
                case IconVisibility.VISIBLE:
                    pbxIcon.Visible = true;

                    switch (type)
                    {
                        case Type.COMBOBOX:
                            kcmbeUserInput.Visible = true;

                            kcmbeUserInput.Size = new Size(576, 25);

                            ktxteUserInput.Visible = false;
                            break;
                        case Type.TEXTBOX:
                            kcmbeUserInput.Visible = false;

                            ktxteUserInput.Visible = true;

                            ktxteUserInput.Size = new Size(576, 25);
                            break;
                    }
                    break;

            }
        }
        #endregion

        #region Setters/Getters
        /// <summary>
        /// Sets the InputType.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetInputType(Type value) => _type = value;

        /// <summary>
        /// Gets the InputType.
        /// </summary>
        /// <returns>The value of _type.</returns>
        public Type GetInputType() => _type;

        /// <summary>
        /// Sets the IconVisibility.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetIconVisibility(IconVisibility value) => _iconVisibility = value;

        /// <summary>
        /// Gets the IconVisibility.
        /// </summary>
        /// <returns>The value of _iconVisibility.</returns>
        public IconVisibility GetIconVisibility() => _iconVisibility;
        #endregion

        private void kbtnBrowse_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            cofd.Title = "Browse for a Process:";

            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (GetInputType() == Type.COMBOBOX)
                {
                    kcmbeUserInput.Text = Path.GetFullPath(cofd.FileName);
                }
                else if (GetInputType() == Type.TEXTBOX)
                {
                    ktxteUserInput.Text = Path.GetFullPath(cofd.FileName);
                }
            }
        }

        private void kcdbCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void kbtnRun_Click(object sender, EventArgs e)
        {
            if (GetInputType() == Type.COMBOBOX)
            {
                RunProcess(kcmbeUserInput.Text);
            }
            else if (GetInputType() == Type.TEXTBOX)
            {
                RunProcess(ktxteUserInput.Text);
            }
        }

        private void kuacRun_Click(object sender, EventArgs e)
        {
            if (GetInputType() == Type.COMBOBOX)
            {
                RunProcess(kcmbeUserInput.Text);
            }
            else if (GetInputType() == Type.TEXTBOX)
            {
                RunProcess(ktxteUserInput.Text);
            }
        }

        private void kbtneLocate_Click(object sender, EventArgs e)
        {
            if (GetInputType() == Type.COMBOBOX)
            {
                LaunchProcess(kcmbeUserInput.Text);
            }
            else if (GetInputType() == Type.TEXTBOX)
            {
                LaunchProcess(ktxteUserInput.Text);
            }
        }

        private void kuacRun_ExecuteProcessAsAdministrator(object sender, Base.ExecuteProcessAsAdministratorEventArgs e)
        {
            if (GetInputType() == Type.COMBOBOX)
            {
                e.ElevateProcessWithAdministrativeRights(kcmbeUserInput.Text);
            }
            else if (GetInputType() == Type.TEXTBOX)
            {
                e.ElevateProcessWithAdministrativeRights(ktxteUserInput.Text);
            }
        }

        private void ktxteUserInput_TextChanged(object sender, EventArgs e)
        {
            if (HasFileExtension(ktxteUserInput.Text))
            {
                EnableLocateButton(IsTextBoxStringEmpty());

                EnableRunButton(IsTextBoxStringEmpty());
            }

            if (GetIconVisibility() == IconVisibility.VISIBLE && IsTextBoxStringEmpty()) GetApplicationIcon(ktxteUserInput.Text);
        }

        private void kcmbeUserInput_TextChanged(object sender, EventArgs e)
        {
            if (HasFileExtension(kcmbeUserInput.Text))
            {
                EnableLocateButton(IsComboBoxStringEmpty());

                EnableRunButton(IsComboBoxStringEmpty());
            }

            if (GetIconVisibility() == IconVisibility.VISIBLE && IsComboBoxStringEmpty()) GetApplicationIcon(kcmbeUserInput.Text);
        }

        private void kcmbeUserInput_TextUpdate(object sender, EventArgs e)
        {
            if (HasFileExtension(kcmbeUserInput.Text))
            {
                EnableLocateButton(IsComboBoxStringEmpty());

                EnableRunButton(IsComboBoxStringEmpty());
            }

            if (GetIconVisibility() == IconVisibility.VISIBLE && IsComboBoxStringEmpty()) GetApplicationIcon(kcmbeUserInput.Text);
        }
    }
}