namespace Examples
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
            this.kryptonHeaderGroup1 = new Krypton.Toolkit.KryptonHeaderGroup();
            this.buttonSpecHeaderGroup1 = new Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.buttonSpecHeaderGroup2 = new Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.buttonSpecHeaderGroup3 = new Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.kryptonOutlookGridGroupBox2 = new Krypton.Toolkit.Suite.Extended.Outlook.Grid.KryptonOutlookGridGroupBox();
            this.kogExample = new Krypton.Toolkit.Suite.Extended.Outlook.Grid.KryptonOutlookGrid();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kogExample)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonHeaderGroup1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.buttonSpecHeaderGroup1,
            this.buttonSpecHeaderGroup2,
            this.buttonSpecHeaderGroup3});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonOutlookGridGroupBox2);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kogExample);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(800, 450);
            this.kryptonHeaderGroup1.TabIndex = 3;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Options";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // buttonSpecHeaderGroup1
            // 
            this.buttonSpecHeaderGroup1.Text = "Load config";
            this.buttonSpecHeaderGroup1.UniqueName = "57942eb9436944db83b334a0bf2f2362";
            this.buttonSpecHeaderGroup1.Click += new System.EventHandler(this.buttonSpecHeaderGroup1_Click);
            // 
            // buttonSpecHeaderGroup2
            // 
            this.buttonSpecHeaderGroup2.Text = "Save config";
            this.buttonSpecHeaderGroup2.UniqueName = "d7f140c9902041c8ba2ab10fda344b9b";
            this.buttonSpecHeaderGroup2.Click += new System.EventHandler(this.buttonSpecHeaderGroup2_Click);
            // 
            // buttonSpecHeaderGroup3
            // 
            this.buttonSpecHeaderGroup3.Text = "Toggle all nodes";
            this.buttonSpecHeaderGroup3.UniqueName = "b3b0035890fc444783d157625034a3cb";
            this.buttonSpecHeaderGroup3.Click += new System.EventHandler(this.buttonSpecHeaderGroup3_Click);
            // 
            // kryptonOutlookGridGroupBox2
            // 
            this.kryptonOutlookGridGroupBox2.AllowDrop = true;
            this.kryptonOutlookGridGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonOutlookGridGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.kryptonOutlookGridGroupBox2.Name = "kryptonOutlookGridGroupBox2";
            this.kryptonOutlookGridGroupBox2.Size = new System.Drawing.Size(798, 46);
            this.kryptonOutlookGridGroupBox2.TabIndex = 0;
            // 
            // kogExample
            // 
            this.kogExample.AllowDrop = true;
            this.kogExample.AllowUserToAddRows = false;
            this.kogExample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kogExample.FillMode = Krypton.Toolkit.Suite.Extended.Outlook.Grid.FillMode.GroupsOnly;
            this.kogExample.GroupCollection = outlookGridGroupCollection1;
            this.kogExample.Location = new System.Drawing.Point(0, 0);
            this.kogExample.Name = "kogExample";
            this.kogExample.PreviousSelectedGroupRow = -1;
            this.kogExample.ShowLines = false;
            this.kogExample.Size = new System.Drawing.Size(798, 418);
            this.kogExample.TabIndex = 2;
            this.kogExample.GroupImageClick += new System.EventHandler<Krypton.Toolkit.Suite.Extended.Outlook.Grid.OutlookGridGroupImageEventArgs>(this.kogExample_GroupImageClick);
            this.kogExample.Resize += new System.EventHandler(this.kogExample_Resize);
            // 
            // OutlookGridExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "OutlookGridExample";
            this.Text = "OutlookGridExample";
            this.Load += new System.EventHandler(this.OutlookGridExample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kogExample)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Outlook.Grid.KryptonOutlookGrid kogExample;
        private Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private Krypton.Toolkit.Suite.Extended.Outlook.Grid.KryptonOutlookGridGroupBox kryptonOutlookGridGroupBox2;
        private Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
        private Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup2;
        private Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup3;
    }
}