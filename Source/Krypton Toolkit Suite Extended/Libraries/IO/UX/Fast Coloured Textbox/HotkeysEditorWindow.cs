using Krypton.Toolkit.Extended.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.IO
{
    public class HotkeysEditorWindow : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnRestoreDefault;
        private KryptonButton kbtnRemove;
        private KryptonButton kbtnAdd;
        private Dialogs.KryptonOKDialogButton kbtnOk;
        private Dialogs.KryptonCancelDialogButton kbtnCancel;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonDataGridView kdgv;
        private DataGridView dgv;
        private DataGridViewComboBoxColumn colModifiers;
        private DataGridViewComboBoxColumn colKey;
        private DataGridViewComboBoxColumn colAction;
        private KryptonDataGridViewComboBoxColumn cbModifiers;
        private KryptonDataGridViewComboBoxColumn cbKey;
        private KryptonDataGridViewComboBoxColumn kcolAction;
        private KryptonGrid kgv;
        private KryptonDataGridViewComboBoxColumn kcolModifiers;
        private KryptonDataGridViewComboBoxColumn kcolKey;
        private KryptonDataGridViewComboBoxColumn kcolmnAction;
        private KryptonLabel kryptonLabel1;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnRestoreDefault = new Krypton.Toolkit.KryptonButton();
            this.kbtnRemove = new Krypton.Toolkit.KryptonButton();
            this.kbtnAdd = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Dialogs.KryptonOKDialogButton();
            this.kbtnCancel = new Dialogs.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kdgv = new Krypton.Toolkit.KryptonDataGridView();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cbModifiers = new Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.cbKey = new Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.kcolAction = new Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.colModifiers = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.kgv = new Krypton.Toolkit.Extended.Base.KryptonGrid();
            this.kcolModifiers = new Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.kcolKey = new Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.kcolmnAction = new Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgv)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnRestoreDefault);
            this.kryptonPanel1.Controls.Add(this.kbtnRemove);
            this.kryptonPanel1.Controls.Add(this.kbtnAdd);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 416);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(691, 47);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnRestoreDefault
            // 
            this.kbtnRestoreDefault.Location = new System.Drawing.Point(204, 10);
            this.kbtnRestoreDefault.Name = "kbtnRestoreDefault";
            this.kbtnRestoreDefault.Size = new System.Drawing.Size(115, 25);
            this.kbtnRestoreDefault.TabIndex = 5;
            this.kbtnRestoreDefault.Values.Text = "Restore &Default";
            this.kbtnRestoreDefault.Click += new System.EventHandler(this.kbtnRestoreDefault_Click);
            // 
            // kbtnRemove
            // 
            this.kbtnRemove.Location = new System.Drawing.Point(108, 10);
            this.kbtnRemove.Name = "kbtnRemove";
            this.kbtnRemove.Size = new System.Drawing.Size(90, 25);
            this.kbtnRemove.TabIndex = 4;
            this.kbtnRemove.Values.Text = "R&emove";
            this.kbtnRemove.Click += new System.EventHandler(this.kbtnRemove_Click);
            // 
            // kbtnAdd
            // 
            this.kbtnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnAdd.Location = new System.Drawing.Point(12, 10);
            this.kbtnAdd.Name = "kbtnAdd";
            this.kbtnAdd.Size = new System.Drawing.Size(90, 25);
            this.kbtnAdd.TabIndex = 3;
            this.kbtnAdd.Values.Text = "&Add";
            this.kbtnAdd.Click += new System.EventHandler(this.kbtnAdd_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Image = null;
            this.kbtnOk.Location = new System.Drawing.Point(493, 10);
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
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&OK";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Image = null;
            this.kbtnCancel.Location = new System.Drawing.Point(589, 10);
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
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.dgv);
            this.kryptonPanel2.Controls.Add(this.kgv);
            this.kryptonPanel2.Controls.Add(this.kdgv);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(691, 413);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kdgv
            // 
            this.kdgv.AllowUserToAddRows = false;
            this.kdgv.AllowUserToDeleteRows = false;
            this.kdgv.AllowUserToResizeColumns = false;
            this.kdgv.AllowUserToResizeRows = false;
            this.kdgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kdgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbModifiers,
            this.cbKey,
            this.kcolAction});
            this.kdgv.Location = new System.Drawing.Point(12, 39);
            this.kdgv.Name = "kdgv";
            this.kdgv.RowHeadersVisible = false;
            this.kdgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.kdgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kdgv.Size = new System.Drawing.Size(667, 368);
            this.kdgv.TabIndex = 4;
            this.kdgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.kdgv_RowsAdded);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(135, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Hotkeys Mapping";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModifiers,
            this.colKey,
            this.colAction});
            this.dgv.Location = new System.Drawing.Point(12, 39);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(667, 368);
            this.dgv.TabIndex = 3;
            this.dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_RowsAdded);
            // 
            // cbModifiers
            // 
            this.cbModifiers.DataSource = null;
            this.cbModifiers.DropDownWidth = 121;
            this.cbModifiers.HeaderText = "Modifiers";
            this.cbModifiers.Name = "cbModifiers";
            this.cbModifiers.Width = 100;
            // 
            // cbKey
            // 
            this.cbKey.DataSource = null;
            this.cbKey.DropDownWidth = 121;
            this.cbKey.HeaderText = "Key";
            this.cbKey.Name = "cbKey";
            this.cbKey.Width = 100;
            // 
            // kcolAction
            // 
            this.kcolAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kcolAction.DataSource = null;
            this.kcolAction.DropDownWidth = 121;
            this.kcolAction.HeaderText = "Action";
            this.kcolAction.Name = "kcolAction";
            this.kcolAction.Width = 466;
            // 
            // colModifiers
            // 
            this.colModifiers.HeaderText = "Modifiers";
            this.colModifiers.Name = "colModifiers";
            this.colModifiers.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colKey
            // 
            this.colKey.HeaderText = "Key";
            this.colKey.Name = "colKey";
            this.colKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colAction
            // 
            this.colAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAction.HeaderText = "Action";
            this.colAction.Name = "colAction";
            // 
            // kgv
            // 
            this.kgv.AllowUserToAddRows = false;
            this.kgv.AllowUserToDeleteRows = false;
            this.kgv.AllowUserToResizeColumns = false;
            this.kgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.kgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.kgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(196)))), ((int)(((byte)(216)))));
            this.kgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kcolModifiers,
            this.kcolKey,
            this.kcolmnAction});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.kgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.kgv.Location = new System.Drawing.Point(12, 39);
            this.kgv.Name = "kgv";
            this.kgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.kgv.RowHeadersVisible = false;
            this.kgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.kgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.kgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Navy;
            this.kgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kgv.Size = new System.Drawing.Size(667, 368);
            this.kgv.TabIndex = 3;
            this.kgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.kgv_RowsAdded);
            // 
            // kcolModifiers
            // 
            this.kcolModifiers.DataSource = null;
            this.kcolModifiers.DropDownWidth = 121;
            this.kcolModifiers.HeaderText = "Modifiers";
            this.kcolModifiers.Name = "kcolModifiers";
            this.kcolModifiers.Width = 100;
            // 
            // kcolKey
            // 
            this.kcolKey.DataSource = null;
            this.kcolKey.DropDownWidth = 121;
            this.kcolKey.HeaderText = "Key";
            this.kcolKey.Name = "kcolKey";
            this.kcolKey.Width = 100;
            // 
            // kcolmnAction
            // 
            this.kcolmnAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kcolmnAction.DataSource = null;
            this.kcolmnAction.DropDownWidth = 121;
            this.kcolmnAction.HeaderText = "Action";
            this.kcolmnAction.Name = "kcolmnAction";
            this.kcolmnAction.Width = 464;
            // 
            // HotkeysEditorWindow
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(691, 463);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotkeysEditorWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Hotkey Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HotkeysEditorWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgv)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private BindingList<HotkeyWrapper> _wrapper = new BindingList<HotkeyWrapper>();
        #endregion

        #region Constructor
        public HotkeysEditorWindow(HotkeysMapping valuePairs)
        {
            InitializeComponent();

            BuildWrappers(valuePairs);

            dgv.DataSource = _wrapper;
        }
        #endregion

        #region Methods
        int CompereKeys(Keys key1, Keys key2)
        {
            var res = ((int)key1 & 0xff).CompareTo((int)key2 & 0xff);
            if (res == 0)
                res = key1.CompareTo(key2);

            return res;
        }

        private void BuildWrappers(HotkeysMapping hotkeys)
        {
            var keys = new List<Keys>(hotkeys.Keys);
            keys.Sort(CompereKeys);

            _wrapper.Clear();
            foreach (var k in keys)
            {
                _wrapper.Add(new HotkeyWrapper(k, hotkeys[k]));
            }
        }

        /// <summary>
        /// Returns edited hotkey map
        /// </summary>
        /// <returns></returns>
        public HotkeysMapping GetHotkeys()
        {
            var result = new HotkeysMapping();
            foreach (var w in _wrapper)
                result[w.ToKeyData()] = w.Action;

            return result;
        }

        private string GetUnAssignedActions()
        {
            StringBuilder sb = new StringBuilder();
            var dic = new Dictionary<FCTBAction, FCTBAction>();

            foreach (var w in _wrapper)
                dic[w.Action] = w.Action;

            foreach (var item in Enum.GetValues(typeof(FCTBAction)))
                if ((FCTBAction)item != FCTBAction.None)
                    if (!((FCTBAction)item).ToString().StartsWith("CustomAction"))
                    {
                        if (!dic.ContainsKey((FCTBAction)item))
                            sb.Append(item + ", ");
                    }

            return sb.ToString().TrimEnd(' ', ',');
        }
        #endregion

        private void kbtnAdd_Click(object sender, EventArgs e)
        {
            _wrapper.Add(new HotkeyWrapper(Keys.None, FCTBAction.None));
        }

        private void kdgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //var cell = (kdgv[0, e.RowIndex] as KryptonDataGridViewComboBoxCell);
            //if (cell.Items.Count == 0)
            //    foreach (var item in new string[] { "", "Ctrl", "Ctrl + Shift", "Ctrl + Alt", "Shift", "Shift + Alt", "Alt", "Ctrl + Shift + Alt" })
            //        cell.Items.Add(item);

            //cell = (kdgv[1, e.RowIndex] as KryptonDataGridViewComboBoxCell);
            //if (cell.Items.Count == 0)
            //    foreach (var item in Enum.GetValues(typeof(Keys)))
            //        cell.Items.Add(item);

            //cell = (kdgv[2, e.RowIndex] as KryptonDataGridViewComboBoxCell);
            //if (cell.Items.Count == 0)
            //    foreach (var item in Enum.GetValues(typeof(FCTBAction)))
            //        cell.Items.Add(item);
        }

        private void kbtnRestoreDefault_Click(object sender, EventArgs e)
        {
            HotkeysMapping h = new HotkeysMapping();

            h.InitDefault();

            BuildWrappers(h);
        }

        private void kbtnRemove_Click(object sender, EventArgs e)
        {
            for (int i = dgv.RowCount - 1; i >= 0; i--)
            {
                if (dgv.Rows[i].Selected)
                {
                    dgv.Rows.RemoveAt(i);
                }
            }
        }

        private void HotkeysEditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                var actions = GetUnAssignedActions();
                if (!string.IsNullOrEmpty(actions))
                {
                    if (KryptonMessageBoxExtended.Show("Some actions are not assigned!\r\nActions: " + actions + "\r\nPress Yes to save and exit, press No to continue editing", "Some actions is not assigned", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                        e.Cancel = true;
                }
            }
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var cell = (dgv[0, e.RowIndex] as DataGridViewComboBoxCell);
            if (cell.Items.Count == 0)
                foreach (var item in new string[] { "", "Ctrl", "Ctrl + Shift", "Ctrl + Alt", "Shift", "Shift + Alt", "Alt", "Ctrl + Shift + Alt" })
                    cell.Items.Add(item);

            cell = (dgv[1, e.RowIndex] as DataGridViewComboBoxCell);
            if (cell.Items.Count == 0)
                foreach (var item in Enum.GetValues(typeof(Keys)))
                    cell.Items.Add(item);

            cell = (dgv[2, e.RowIndex] as DataGridViewComboBoxCell);
            if (cell.Items.Count == 0)
                foreach (var item in Enum.GetValues(typeof(FCTBAction)))
                    cell.Items.Add(item);
        }

        private void kgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //var cell = (kdgv[0, e.RowIndex] as KryptonDataGridViewComboBoxCell);
            //if (cell.Items.Count == 0)
            //    foreach (var item in new string[] { "", "Ctrl", "Ctrl + Shift", "Ctrl + Alt", "Shift", "Shift + Alt", "Alt", "Ctrl + Shift + Alt" })
            //        cell.Items.Add(item);

            //cell = (kdgv[1, e.RowIndex] as KryptonDataGridViewComboBoxCell);
            //if (cell.Items.Count == 0)
            //    foreach (var item in Enum.GetValues(typeof(Keys)))
            //        cell.Items.Add(item);

            //cell = (kdgv[2, e.RowIndex] as KryptonDataGridViewComboBoxCell);
            //if (cell.Items.Count == 0)
            //    foreach (var item in Enum.GetValues(typeof(FCTBAction)))
            //        cell.Items.Add(item);
        }
    }
}