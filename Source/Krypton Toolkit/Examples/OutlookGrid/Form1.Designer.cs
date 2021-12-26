
namespace OutlookGrid
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Krypton.Toolkit.Suite.Extended.Outlook.Grid.OutlookGridGroupCollection outlookGridGroupCollection1 = new Krypton.Toolkit.Suite.Extended.Outlook.Grid.OutlookGridGroupCollection();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kogTest = new Krypton.Toolkit.Suite.Extended.Outlook.Grid.KryptonOutlookGrid();
            this.kryptonHeaderGroup1 = new Krypton.Toolkit.KryptonHeaderGroup();
            this.bshgLoadConfig = new Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.bshgSaveConfig = new Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.bshgToggleNodes = new Krypton.Toolkit.ButtonSpecHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kogTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(686, 390);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kogTest
            // 
            this.kogTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kogTest.FillMode = Krypton.Toolkit.Suite.Extended.Outlook.Grid.FillMode.GroupsOnly;
            this.kogTest.GroupCollection = outlookGridGroupCollection1;
            this.kogTest.Location = new System.Drawing.Point(0, 0);
            this.kogTest.Name = "kogTest";
            this.kogTest.PreviousSelectedGroupRow = -1;
            this.kogTest.ShowLines = false;
            this.kogTest.Size = new System.Drawing.Size(684, 358);
            this.kogTest.TabIndex = 1;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.bshgLoadConfig,
            this.bshgSaveConfig,
            this.bshgToggleNodes});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderPositionPrimary = Krypton.Toolkit.VisualOrientation.Top;
            this.kryptonHeaderGroup1.HeaderPositionSecondary = Krypton.Toolkit.VisualOrientation.Bottom;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kogTest);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(686, 390);
            this.kryptonHeaderGroup1.TabIndex = 1;
            // 
            // bshgLoadConfig
            // 
            this.bshgLoadConfig.Text = "Load Config";
            this.bshgLoadConfig.UniqueName = "68fae3e2c65b43c48f48f1937fd3744c";
            // 
            // bshgSaveConfig
            // 
            this.bshgSaveConfig.Text = "Save Config";
            this.bshgSaveConfig.UniqueName = "fafebff626604609a8baac28c126d255";
            // 
            // bshgToggleNodes
            // 
            this.bshgToggleNodes.Text = "Toggle all Nodes";
            this.bshgToggleNodes.UniqueName = "ac5e3686737b496cbe2978107561b9e1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kogTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Outlook.Grid.KryptonOutlookGrid kogTest;
        private Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private Krypton.Toolkit.ButtonSpecHeaderGroup bshgLoadConfig;
        private Krypton.Toolkit.ButtonSpecHeaderGroup bshgSaveConfig;
        private Krypton.Toolkit.ButtonSpecHeaderGroup bshgToggleNodes;
    }
}

