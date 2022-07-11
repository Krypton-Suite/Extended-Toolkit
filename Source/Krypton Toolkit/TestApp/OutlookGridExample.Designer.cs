namespace TestApp
{
    partial class OutlookGridExample
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
            Krypton.Toolkit.Suite.Extended.Outlook.Grid.OutlookGridGroupCollection outlookGridGroupCollection1 = new Krypton.Toolkit.Suite.Extended.Outlook.Grid.OutlookGridGroupCollection();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kogExample = new Krypton.Toolkit.Suite.Extended.Outlook.Grid.KryptonOutlookGrid();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kogExample)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kogExample);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kogExample
            // 
            this.kogExample.FillMode = Krypton.Toolkit.Suite.Extended.Outlook.Grid.FillMode.GroupsOnly;
            this.kogExample.GroupCollection = outlookGridGroupCollection1;
            this.kogExample.Location = new System.Drawing.Point(197, 226);
            this.kogExample.Name = "kogExample";
            this.kogExample.PreviousSelectedGroupRow = -1;
            this.kogExample.ShowLines = false;
            this.kogExample.Size = new System.Drawing.Size(240, 150);
            this.kogExample.TabIndex = 2;
            // 
            // OutlookGridExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "OutlookGridExample";
            this.Text = "OutlookGridExample";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kogExample)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Outlook.Grid.KryptonOutlookGrid kogExample;
    }
}