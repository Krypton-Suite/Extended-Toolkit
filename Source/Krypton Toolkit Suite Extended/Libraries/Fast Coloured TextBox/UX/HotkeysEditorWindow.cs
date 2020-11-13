using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class HotkeysEditorWindow : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonButton kbtnRestoreDefault;
        private KryptonButton kbtnRemove;
        private KryptonButton kbtnAdd;
        private KryptonPanel kryptonPanel2;
        private KryptonDataGridView kdgvHotkeys;
        private KryptonDataGridViewComboBoxColumn cbModifiers;
        private KryptonDataGridViewComboBoxColumn cbKey;
        private KryptonDataGridViewComboBoxColumn cbAction;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kbtnAdd = new Krypton.Toolkit.KryptonButton();
            this.kbtnRestoreDefault = new Krypton.Toolkit.KryptonButton();
            this.kbtnRemove = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kdgvHotkeys = new Krypton.Toolkit.KryptonDataGridView();
            this.cbModifiers = new Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.cbKey = new Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.cbAction = new Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvHotkeys)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnRestoreDefault);
            this.kryptonPanel1.Controls.Add(this.kbtnRemove);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnAdd);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 309);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(549, 47);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(351, 10);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(447, 10);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 306);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 3);
            this.panel1.TabIndex = 3;
            // 
            // kbtnAdd
            // 
            this.kbtnAdd.Location = new System.Drawing.Point(12, 10);
            this.kbtnAdd.Name = "kbtnAdd";
            this.kbtnAdd.Size = new System.Drawing.Size(90, 25);
            this.kbtnAdd.TabIndex = 4;
            this.kbtnAdd.Values.Text = "Ad&d";
            this.kbtnAdd.Click += new System.EventHandler(this.kbtnAdd_Click);
            // 
            // kbtnRestoreDefault
            // 
            this.kbtnRestoreDefault.Location = new System.Drawing.Point(204, 10);
            this.kbtnRestoreDefault.Name = "kbtnRestoreDefault";
            this.kbtnRestoreDefault.Size = new System.Drawing.Size(113, 25);
            this.kbtnRestoreDefault.TabIndex = 5;
            this.kbtnRestoreDefault.Values.Text = "Restore &Default";
            this.kbtnRestoreDefault.Click += new System.EventHandler(this.kbtnRestoreDefault_Click);
            // 
            // kbtnRemove
            // 
            this.kbtnRemove.Location = new System.Drawing.Point(108, 10);
            this.kbtnRemove.Name = "kbtnRemove";
            this.kbtnRemove.Size = new System.Drawing.Size(90, 25);
            this.kbtnRemove.TabIndex = 6;
            this.kbtnRemove.Values.Text = "R&emove";
            this.kbtnRemove.Click += new System.EventHandler(this.kbtnRemove_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kdgvHotkeys);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(549, 306);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(107, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Hotkeys mapping";
            // 
            // kdgvHotkeys
            // 
            this.kdgvHotkeys.AllowUserToAddRows = false;
            this.kdgvHotkeys.AllowUserToDeleteRows = false;
            this.kdgvHotkeys.AllowUserToResizeColumns = false;
            this.kdgvHotkeys.AllowUserToResizeRows = false;
            this.kdgvHotkeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kdgvHotkeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbModifiers,
            this.cbKey,
            this.cbAction});
            this.kdgvHotkeys.Location = new System.Drawing.Point(12, 38);
            this.kdgvHotkeys.Name = "kdgvHotkeys";
            this.kdgvHotkeys.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.kdgvHotkeys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kdgvHotkeys.Size = new System.Drawing.Size(525, 262);
            this.kdgvHotkeys.TabIndex = 5;
            this.kdgvHotkeys.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.kdgvHotkeys_RowsAdded);
            // 
            // cbModifiers
            // 
            this.cbModifiers.DataPropertyName = "Modifiers";
            this.cbModifiers.DataSource = null;
            this.cbModifiers.DropDownWidth = 121;
            this.cbModifiers.HeaderText = "Modifiers";
            this.cbModifiers.Name = "cbModifiers";
            this.cbModifiers.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbModifiers.Width = 100;
            // 
            // cbKey
            // 
            this.cbKey.DataPropertyName = "Key";
            this.cbKey.DataSource = null;
            this.cbKey.DropDownWidth = 121;
            this.cbKey.HeaderText = "Key";
            this.cbKey.Name = "cbKey";
            this.cbKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbKey.Width = 120;
            // 
            // cbAction
            // 
            this.cbAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cbAction.DataPropertyName = "Action";
            this.cbAction.DataSource = null;
            this.cbAction.DropDownWidth = 121;
            this.cbAction.HeaderText = "Action";
            this.cbAction.Name = "cbAction";
            this.cbAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbAction.Width = 264;
            // 
            // HotkeysEditorWindow
            // 
            this.ClientSize = new System.Drawing.Size(549, 356);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotkeysEditorWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotkeys Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HotkeysEditorWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvHotkeys)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private BindingList<HotkeyWrapper> _wrappers = new BindingList<HotkeyWrapper>();
        #endregion

        #region Constructor
        public HotkeysEditorWindow(HotkeysMapping keyValues)
        {
            InitializeComponent();

            BuildWrappers(keyValues);

            kdgvHotkeys.DataSource = _wrappers;
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

            _wrappers.Clear();
            foreach (var k in keys)
                _wrappers.Add(new HotkeyWrapper(k, hotkeys[k]));
        }

        /// <summary>
        /// Returns edited hotkey map
        /// </summary>
        /// <returns></returns>
        public HotkeysMapping GetHotkeys()
        {
            var result = new HotkeysMapping();
            foreach (var w in _wrappers)
                result[w.ToKeyData()] = w.Action;

            return result;
        }

        private string GetUnAssignedActions()
        {
            StringBuilder sb = new StringBuilder();
            var dic = new Dictionary<FCTBAction, FCTBAction>();

            foreach (var w in _wrappers)
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
            _wrappers.Add(new HotkeyWrapper(Keys.None, FCTBAction.None));
        }

        private void kbtnRemove_Click(object sender, EventArgs e)
        {
            for (int i = kdgvHotkeys.RowCount - 1; i >= 0; i--)
            {
                if (kdgvHotkeys.Rows[i].Selected)
                {
                    kdgvHotkeys.Rows.RemoveAt(i);
                }
            }
        }

        private void kbtnRestoreDefault_Click(object sender, EventArgs e)
        {
            HotkeysMapping hotkeys = new HotkeysMapping();

            hotkeys.InitDefault();

            BuildWrappers(hotkeys);
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {

        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void kdgvHotkeys_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var cell = (kdgvHotkeys[0, e.RowIndex] as KryptonDataGridViewComboBoxCell);

            if (cell.Items.Count == 0)
            {
                foreach (var item in new string[] { "", "Ctrl", "Ctrl + Shift", "Ctrl + Alt", "Shift", "Shift + Alt", "Alt", "Ctrl + Shift + Alt" })
                {
                    cell.Items.Add(item);
                }
            }

            cell = (kdgvHotkeys[1, e.RowIndex] as KryptonDataGridViewComboBoxCell);

            if (cell.Items.Count == 0)
            {
                foreach (var item in Enum.GetValues(typeof(Keys)))
                {
                    cell.Items.Add(item);
                }
            }

            cell = (kdgvHotkeys[2, e.RowCount] as KryptonDataGridViewComboBoxCell);

            if (cell.Items.Count == 0)
            {
                foreach (var item in Enum.GetValues(typeof(FCTBAction)))
                {
                    cell.Items.Add(item);
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
                    if (KryptonMessageBox.Show("Some actions are not assigned!\r\nActions: " + actions + "\r\nPress Yes to save and exit, press No to continue editing", "Some actions is not assigned", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                        e.Cancel = true;
                }
            }
        }
    }
}