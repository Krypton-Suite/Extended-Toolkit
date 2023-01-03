namespace Examples
{
    partial class AdvancedDataGridView
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
            this.kryptonAdvancedDataGridViewSearchToolBar1 = new Krypton.Toolkit.Suite.Extended.AdvancedDataGridView.KryptonAdvancedDataGridViewSearchToolBar();
            this.kryptonAdvancedDataGridView2 = new Krypton.Toolkit.Suite.Extended.AdvancedDataGridView.KryptonAdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonAdvancedDataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonAdvancedDataGridViewSearchToolBar1
            // 
            this.kryptonAdvancedDataGridViewSearchToolBar1.AllowMerge = false;
            this.kryptonAdvancedDataGridViewSearchToolBar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonAdvancedDataGridViewSearchToolBar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.kryptonAdvancedDataGridViewSearchToolBar1.Location = new System.Drawing.Point(0, 0);
            this.kryptonAdvancedDataGridViewSearchToolBar1.MaximumSize = new System.Drawing.Size(0, 27);
            this.kryptonAdvancedDataGridViewSearchToolBar1.MinimumSize = new System.Drawing.Size(0, 27);
            this.kryptonAdvancedDataGridViewSearchToolBar1.Name = "kryptonAdvancedDataGridViewSearchToolBar1";
            this.kryptonAdvancedDataGridViewSearchToolBar1.Size = new System.Drawing.Size(800, 27);
            this.kryptonAdvancedDataGridViewSearchToolBar1.TabIndex = 1;
            this.kryptonAdvancedDataGridViewSearchToolBar1.Text = "kryptonAdvancedDataGridViewSearchToolBar1";
            // 
            // kryptonAdvancedDataGridView2
            // 
            this.kryptonAdvancedDataGridView2.FilterAndSortEnabled = true;
            this.kryptonAdvancedDataGridView2.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.kryptonAdvancedDataGridView2.Location = new System.Drawing.Point(138, 66);
            this.kryptonAdvancedDataGridView2.Name = "kryptonAdvancedDataGridView2";
            this.kryptonAdvancedDataGridView2.Size = new System.Drawing.Size(240, 150);
            this.kryptonAdvancedDataGridView2.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.kryptonAdvancedDataGridView2.TabIndex = 2;
            // 
            // AdvancedDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonAdvancedDataGridView2);
            this.Controls.Add(this.kryptonAdvancedDataGridViewSearchToolBar1);
            this.Name = "AdvancedDataGridView";
            this.Text = "AdvancedDataGridView";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonAdvancedDataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.AdvancedDataGridView.KryptonAdvancedDataGridViewSearchToolBar kryptonAdvancedDataGridViewSearchToolBar1;
        private Krypton.Toolkit.Suite.Extended.AdvancedDataGridView.KryptonAdvancedDataGridView kryptonAdvancedDataGridView2;
    }
}