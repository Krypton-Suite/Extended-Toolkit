#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Base;
using Microsoft.VisualBasic;
using System;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    public class OutlookBarNavigationPaneOptions : KryptonForm
    {
        #region Designer Code
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnReset;
        private KryptonButton kbtnMoveDown;
        private KryptonButton kbtnMoveUp;
        private KryptonCheckedListBox kclbItems;
        private KryptonLabel kryptonLabelExtended1;
        private System.Windows.Forms.CheckedListBox clbItems;
        private KryptonOKDialogButton kbtnOk;
        private KryptonCancelDialogButton kbtnCancel;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.Suite.Extended.Base.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Suite.Extended.Base.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.clbItems = new System.Windows.Forms.CheckedListBox();
            this.kbtnReset = new Krypton.Toolkit.KryptonButton();
            this.kbtnMoveDown = new Krypton.Toolkit.KryptonButton();
            this.kbtnMoveUp = new Krypton.Toolkit.KryptonButton();
            this.kclbItems = new Krypton.Toolkit.KryptonCheckedListBox();
            this.kryptonLabelExtended1 = new Krypton.Toolkit.KryptonLabel();
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
            this.kbtnReset.Location = new System.Drawing.Point(378, 230);
            this.kbtnReset.Name = "kbtnReset";
            this.kbtnReset.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.Size = new System.Drawing.Size(90, 25);
            this.kbtnReset.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReset.TabIndex = 8;
            this.kbtnReset.Values.Text = "&Reset";
            this.kbtnReset.Click += new System.EventHandler(this.kbtnReset_Click);
            // 
            // kbtnMoveDown
            // 
            this.kbtnMoveDown.Enabled = false;
            this.kbtnMoveDown.Location = new System.Drawing.Point(378, 70);
            this.kbtnMoveDown.Name = "kbtnMoveDown";
            this.kbtnMoveDown.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.Size = new System.Drawing.Size(90, 25);
            this.kbtnMoveDown.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveDown.TabIndex = 7;
            this.kbtnMoveDown.Values.Text = "Move &Down";
            this.kbtnMoveDown.Click += new System.EventHandler(this.kbtnMoveDown_Click);
            // 
            // kbtnMoveUp
            // 
            this.kbtnMoveUp.Enabled = false;
            this.kbtnMoveUp.Location = new System.Drawing.Point(378, 39);
            this.kbtnMoveUp.Name = "kbtnMoveUp";
            this.kbtnMoveUp.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.Size = new System.Drawing.Size(90, 25);
            this.kbtnMoveUp.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnMoveUp.TabIndex = 6;
            this.kbtnMoveUp.Values.Text = "Move &Up";
            this.kbtnMoveUp.Click += new System.EventHandler(this.kbtnMoveUp_Click);
            // 
            // kclbItems
            // 
            this.kclbItems.Location = new System.Drawing.Point(12, 39);
            this.kclbItems.Name = "kclbItems";
            this.kclbItems.OverrideFocus.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.OverrideFocus.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.OverrideFocus.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.OverrideFocus.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.OverrideFocus.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.OverrideFocus.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.Size = new System.Drawing.Size(359, 216);
            this.kclbItems.StateCheckedNormal.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedNormal.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateCheckedNormal.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedNormal.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateCheckedPressed.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressed.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressed.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateCheckedPressed.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressed.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedPressed.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateCheckedTracking.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTracking.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateCheckedTracking.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTracking.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCheckedTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateCommon.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommon.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateCommon.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommon.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateDisabled.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabled.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateDisabled.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabled.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateNormal.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormal.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateNormal.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormal.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StatePressed.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressed.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressed.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StatePressed.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressed.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StatePressed.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.StateTracking.Item.Content.LongText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTracking.Item.Content.LongText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kclbItems.StateTracking.Item.Content.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTracking.Item.Content.ShortText.Color2 = System.Drawing.SystemColors.ControlText;
            this.kclbItems.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.TabIndex = 5;
            this.kclbItems.Visible = false;
            this.kclbItems.SelectedIndexChanged += new System.EventHandler(this.kclbItems_SelectedIndexChanged);
            // 
            // kryptonLabelExtended1
            // 
            this.kryptonLabelExtended1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabelExtended1.Name = "kryptonLabelExtended1";
            this.kryptonLabelExtended1.Size = new System.Drawing.Size(209, 21);
            this.kryptonLabelExtended1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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