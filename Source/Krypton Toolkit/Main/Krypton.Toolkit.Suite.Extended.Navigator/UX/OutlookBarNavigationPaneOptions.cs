#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

using Microsoft.VisualBasic;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    public partial class OutlookBarNavigationPaneOptions : KryptonForm
    {
        #region Designer Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.CheckedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnMoveUp = new Krypton.Toolkit.KryptonButton();
            this.kbtnMoveDown = new Krypton.Toolkit.KryptonButton();
            this.kbtnReset = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kclbItems = new Krypton.Toolkit.KryptonCheckedListBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Cancel.Location = new System.Drawing.Point(307, 193);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_OK.Location = new System.Drawing.Point(226, 193);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Visible = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Enabled = false;
            this.btn_Reset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Reset.Location = new System.Drawing.Point(307, 142);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset.TabIndex = 11;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Visible = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Down
            // 
            this.btn_Down.Enabled = false;
            this.btn_Down.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Down.Location = new System.Drawing.Point(307, 100);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(75, 23);
            this.btn_Down.TabIndex = 10;
            this.btn_Down.Text = "Move Down";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Visible = false;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Enabled = false;
            this.btn_Up.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Up.Location = new System.Drawing.Point(307, 71);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(75, 23);
            this.btn_Up.TabIndex = 9;
            this.btn_Up.Text = "Move Up";
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Visible = false;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // CheckedListBox1
            // 
            this.CheckedListBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckedListBox1.FormattingEnabled = true;
            this.CheckedListBox1.Location = new System.Drawing.Point(7, 52);
            this.CheckedListBox1.Name = "CheckedListBox1";
            this.CheckedListBox1.ScrollAlwaysVisible = true;
            this.CheckedListBox1.Size = new System.Drawing.Size(275, 164);
            this.CheckedListBox1.TabIndex = 8;
            this.CheckedListBox1.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox1_SelectedIndexChanged);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.CheckedListBox1);
            this.kryptonPanel1.Controls.Add(this.btn_Cancel);
            this.kryptonPanel1.Controls.Add(this.btn_OK);
            this.kryptonPanel1.Controls.Add(this.kclbItems);
            this.kryptonPanel1.Controls.Add(this.btn_Reset);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.btn_Down);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.btn_Up);
            this.kryptonPanel1.Controls.Add(this.kbtnReset);
            this.kryptonPanel1.Controls.Add(this.kbtnMoveDown);
            this.kryptonPanel1.Controls.Add(this.kbtnMoveUp);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(411, 272);
            this.kryptonPanel1.TabIndex = 14;
            // 
            // kbtnMoveUp
            // 
            this.kbtnMoveUp.Location = new System.Drawing.Point(288, 51);
            this.kbtnMoveUp.Name = "kbtnMoveUp";
            this.kbtnMoveUp.Size = new System.Drawing.Size(111, 34);
            this.kbtnMoveUp.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnMoveUp.TabIndex = 1;
            this.kbtnMoveUp.Values.Text = "Move &Up";
            this.kbtnMoveUp.Click += new System.EventHandler(this.kbtnMoveUp_Click);
            // 
            // kbtnMoveDown
            // 
            this.kbtnMoveDown.Location = new System.Drawing.Point(288, 91);
            this.kbtnMoveDown.Name = "kbtnMoveDown";
            this.kbtnMoveDown.Size = new System.Drawing.Size(111, 34);
            this.kbtnMoveDown.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnMoveDown.TabIndex = 2;
            this.kbtnMoveDown.Values.Text = "Move &Down";
            this.kbtnMoveDown.Click += new System.EventHandler(this.kbtnMoveDown_Click);
            // 
            // kbtnReset
            // 
            this.kbtnReset.Location = new System.Drawing.Point(288, 162);
            this.kbtnReset.Name = "kbtnReset";
            this.kbtnReset.Size = new System.Drawing.Size(111, 34);
            this.kbtnReset.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnReset.TabIndex = 3;
            this.kbtnReset.Values.Text = "&Reset";
            this.kbtnReset.Click += new System.EventHandler(this.kbtnReset_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(288, 226);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(111, 34);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.TabIndex = 4;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(171, 226);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(111, 34);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 5;
            this.kbtnOk.Values.Text = "O&k";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kclbItems
            // 
            this.kclbItems.Location = new System.Drawing.Point(7, 51);
            this.kclbItems.Name = "kclbItems";
            this.kclbItems.ScrollAlwaysVisible = true;
            this.kclbItems.Size = new System.Drawing.Size(275, 165);
            this.kclbItems.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kclbItems.TabIndex = 6;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(7, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(275, 30);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 14;
            this.kryptonLabel1.Values.Text = "Display buttons in this order";
            // 
            // OutlookBarNavigationPaneOptions
            // 
            this.AcceptButton = this.kbtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(411, 272);
            this.Controls.Add(this.kryptonPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutlookBarNavigationPaneOptions";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navigation Pane Options";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btn_Cancel;
        internal System.Windows.Forms.Button btn_OK;
        internal System.Windows.Forms.Button btn_Reset;
        internal System.Windows.Forms.Button btn_Down;
        internal System.Windows.Forms.Button btn_Up;
        internal System.Windows.Forms.CheckedListBox CheckedListBox1;
        #endregion

        private OutlookBarButtonCollection Items;
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnReset;
        private KryptonButton kbtnMoveDown;
        private KryptonButton kbtnMoveUp;
        private KryptonCheckedListBox kclbItems;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private KryptonLabel kryptonLabel1;
        private Collection OriginalItems = new Collection();

        public OutlookBarNavigationPaneOptions(OutlookBarButtonCollection items)
        {
            InitializeComponent();
            this.Items = items;
            foreach (OutlookBarButton b in this.Items)
            {
                this.OriginalItems.Add(b, null, null, null);
            }

            this.FillList();
            this.CheckedListBox1.SelectedIndex = 0;
        }

        private void FillList()
        {
            this.CheckedListBox1.Items.Clear();
            foreach (OutlookBarButton b in this.Items)
            {
                if (b.Allowed) this.CheckedListBox1.Items.Add(b, b.Visible);
            }
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            int newIndex = this.CheckedListBox1.SelectedIndex - 1;
            this.Items.Insert(newIndex, (OutlookBarButton)this.CheckedListBox1.SelectedItem);
            this.Items.RemoveAt(newIndex + 2);
            this.FillList();
            this.CheckedListBox1.SelectedIndex = newIndex;

        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            OutlookBarButton b = (OutlookBarButton)this.CheckedListBox1.SelectedItem;
            int newIndex = this.CheckedListBox1.SelectedIndex + 2;
            this.Items.Insert(newIndex, (OutlookBarButton)this.CheckedListBox1.SelectedItem);
            this.Items.Remove(b);
            this.FillList();
            this.CheckedListBox1.SelectedIndex = newIndex - 1;
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            btn_Cancel_Click(sender, e);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Items.Clear();
            foreach (OutlookBarButton b in this.OriginalItems)
            {
                this.Items.Add(b);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            foreach (OutlookBarButton b in this.Items)
            {
                b.Visible = false;
            }
            for (int i = 0; i <= this.CheckedListBox1.CheckedItems.Count - 1; i++)
            {
                ((OutlookBarButton)this.CheckedListBox1.CheckedItems[i]).Visible = true;
            }
            this.Close();
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CheckedListBox1.SelectedIndex == 0)
            {
                this.btn_Up.Enabled = false;
            }
            else
            {
                this.btn_Up.Enabled = true;
            }
            if (this.CheckedListBox1.SelectedIndex == this.CheckedListBox1.Items.Count - 1)
            {
                this.btn_Down.Enabled = false;
            }
            else
            {
                this.btn_Down.Enabled = true;
            }
            if (this.CheckedListBox1.Items.Count == 1)
            {
                this.btn_Down.Enabled = false;
                this.btn_Up.Enabled = false;
            }
        }

        private void kbtnMoveUp_Click(object sender, EventArgs e)
        {
            int newIndex = this.CheckedListBox1.SelectedIndex - 1;
            this.Items.Insert(newIndex, (OutlookBarButton)this.CheckedListBox1.SelectedItem);
            this.Items.RemoveAt(newIndex + 2);
            this.FillList();
            this.CheckedListBox1.SelectedIndex = newIndex;
        }

        private void kbtnMoveDown_Click(object sender, EventArgs e)
        {
            OutlookBarButton b = (OutlookBarButton)this.CheckedListBox1.SelectedItem;
            int newIndex = this.CheckedListBox1.SelectedIndex + 2;
            this.Items.Insert(newIndex, (OutlookBarButton)this.CheckedListBox1.SelectedItem);
            this.Items.Remove(b);
            this.FillList();
            this.CheckedListBox1.SelectedIndex = newIndex - 1;
        }

        private void kbtnReset_Click(object sender, EventArgs e)
        {
            kbtnReset_Click(sender, e);
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            foreach (OutlookBarButton b in this.Items)
            {
                b.Visible = false;
            }
            for (int i = 0; i <= this.CheckedListBox1.CheckedItems.Count - 1; i++)
            {
                ((OutlookBarButton)this.CheckedListBox1.CheckedItems[i]).Visible = true;
            }
            this.Close();
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            this.Items.Clear();
            foreach (OutlookBarButton b in this.OriginalItems)
            {
                this.Items.Add(b);

            }
        }
    }
}