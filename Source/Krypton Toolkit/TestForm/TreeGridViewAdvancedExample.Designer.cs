#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */

#endregion
namespace TestForm
{
    partial class TreeGridViewAdvancedExample
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeGridViewAdvancedExample));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCollapseAll = new Krypton.Toolkit.KryptonButton();
            this.kbtnExpandAll = new Krypton.Toolkit.KryptonButton();
            this.kbtnDataSource = new Krypton.Toolkit.KryptonButton();
            this.kryptonThemeComboBox1 = new Krypton.Toolkit.KryptonThemeComboBox();
            this.kryptonTreeGridView1 = new Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView();
            this.nameColumn = new Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridColumn();
            this.ageColumn = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.birthdateColumn = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.jobColumn = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonThemeComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonTreeGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnCollapseAll);
            this.kryptonPanel1.Controls.Add(this.kbtnExpandAll);
            this.kryptonPanel1.Controls.Add(this.kbtnDataSource);
            this.kryptonPanel1.Controls.Add(this.kryptonThemeComboBox1);
            this.kryptonPanel1.Controls.Add(this.kryptonTreeGridView1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnCollapseAll
            // 
            this.kbtnCollapseAll.Location = new System.Drawing.Point(576, 109);
            this.kbtnCollapseAll.Name = "kbtnCollapseAll";
            this.kbtnCollapseAll.Size = new System.Drawing.Size(212, 31);
            this.kbtnCollapseAll.TabIndex = 4;
            this.kbtnCollapseAll.Values.Text = "Collapse All";
            this.kbtnCollapseAll.Click += new System.EventHandler(this.kbtnCollapseAll_Click);
            // 
            // kbtnExpandAll
            // 
            this.kbtnExpandAll.Location = new System.Drawing.Point(576, 75);
            this.kbtnExpandAll.Name = "kbtnExpandAll";
            this.kbtnExpandAll.Size = new System.Drawing.Size(212, 31);
            this.kbtnExpandAll.TabIndex = 3;
            this.kbtnExpandAll.Values.Text = "Expand All";
            this.kbtnExpandAll.Click += new System.EventHandler(this.kbtnExpandAll_Click);
            // 
            // kbtnDataSource
            // 
            this.kbtnDataSource.Location = new System.Drawing.Point(576, 41);
            this.kbtnDataSource.Name = "kbtnDataSource";
            this.kbtnDataSource.Size = new System.Drawing.Size(212, 31);
            this.kbtnDataSource.TabIndex = 2;
            this.kbtnDataSource.Values.Text = "Open DataSourceExample";
            this.kbtnDataSource.Click += new System.EventHandler(this.kbtnDataSource_Click);
            // 
            // kryptonThemeComboBox1
            // 
            this.kryptonThemeComboBox1.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.kryptonThemeComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kryptonThemeComboBox1.DropDownWidth = 212;
            this.kryptonThemeComboBox1.IntegralHeight = false;
            this.kryptonThemeComboBox1.Location = new System.Drawing.Point(576, 13);
            this.kryptonThemeComboBox1.Name = "kryptonThemeComboBox1";
            this.kryptonThemeComboBox1.Size = new System.Drawing.Size(212, 21);
            this.kryptonThemeComboBox1.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonThemeComboBox1.TabIndex = 1;
            // 
            // kryptonTreeGridView1
            // 
            this.kryptonTreeGridView1.AllowUserToAddRows = false;
            this.kryptonTreeGridView1.AllowUserToDeleteRows = false;
            this.kryptonTreeGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonTreeGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kryptonTreeGridView1.ColumnHeadersHeight = 36;
            this.kryptonTreeGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.ageColumn,
            this.birthdateColumn,
            this.jobColumn});
            this.kryptonTreeGridView1.DataSource = null;
            this.kryptonTreeGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.kryptonTreeGridView1.ImageList = null;
            this.kryptonTreeGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTreeGridView1.Name = "kryptonTreeGridView1";
            this.kryptonTreeGridView1.RowHeadersWidth = 51;
            this.kryptonTreeGridView1.Size = new System.Drawing.Size(557, 450);
            this.kryptonTreeGridView1.TabIndex = 0;
            // 
            // nameColumn
            // 
            this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameColumn.HeaderText = "name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ageColumn
            // 
            this.ageColumn.HeaderText = "age";
            this.ageColumn.Name = "ageColumn";
            this.ageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ageColumn.Width = 45;
            // 
            // birthdateColumn
            // 
            this.birthdateColumn.HeaderText = "birthdate";
            this.birthdateColumn.Name = "birthdateColumn";
            this.birthdateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.birthdateColumn.Width = 90;
            // 
            // jobColumn
            // 
            this.jobColumn.HeaderText = "job";
            this.jobColumn.Name = "jobColumn";
            this.jobColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.jobColumn.Width = 90;
            // 
            // TreeGridViewAdvancedExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TreeGridViewAdvancedExample";
            this.Text = "TreeGridView Advanced Example (Issue #533)";
            this.Load += new System.EventHandler(this.TreeGridViewAdvancedExample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonThemeComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonTreeGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView kryptonTreeGridView1;
        private KryptonButton kbtnDataSource;
        private KryptonButton kbtnExpandAll;
        private KryptonButton kbtnCollapseAll;
        private KryptonThemeComboBox kryptonThemeComboBox1;
        private Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridColumn nameColumn;
        private KryptonDataGridViewTextBoxColumn ageColumn;
        private KryptonDataGridViewTextBoxColumn birthdateColumn;
        private KryptonDataGridViewTextBoxColumn jobColumn;
    }
}
