using System;

namespace Krypton.Toolkit.Extended.Palette.Controls
{
    public class InternalBasicPaletteCreatorOptions : KryptonForm
    {
        #region Design Code
        private KryptonButton kbtnOk;
        private KryptonButton kbtnApply;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnFlushColourSettings;
        private KryptonCheckBox kchkDebugConsole;
        private KryptonCheckBox kchkUpdateColours;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kchkUpdateColours = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkDebugConsole = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnFlushColourSettings = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnApply);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 292);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(509, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnApply
            // 
            this.kbtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnApply.Enabled = false;
            this.kbtnApply.Location = new System.Drawing.Point(407, 13);
            this.kbtnApply.Name = "kbtnApply";
            this.kbtnApply.Size = new System.Drawing.Size(90, 25);
            this.kbtnApply.TabIndex = 0;
            this.kbtnApply.Values.Text = "A&pply";
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(311, 13);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 3);
            this.panel1.TabIndex = 3;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnFlushColourSettings);
            this.kryptonPanel2.Controls.Add(this.kchkDebugConsole);
            this.kryptonPanel2.Controls.Add(this.kchkUpdateColours);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(509, 289);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // kchkUpdateColours
            // 
            this.kchkUpdateColours.Location = new System.Drawing.Point(13, 13);
            this.kchkUpdateColours.Name = "kchkUpdateColours";
            this.kchkUpdateColours.Size = new System.Drawing.Size(189, 20);
            this.kchkUpdateColours.TabIndex = 0;
            this.kchkUpdateColours.Values.Text = "Automatcically &update colours";
            // 
            // kchkDebugConsole
            // 
            this.kchkDebugConsole.Location = new System.Drawing.Point(13, 40);
            this.kchkDebugConsole.Name = "kchkDebugConsole";
            this.kchkDebugConsole.Size = new System.Drawing.Size(177, 20);
            this.kchkDebugConsole.TabIndex = 1;
            this.kchkDebugConsole.Values.Text = "&Show debug console button";
            // 
            // kbtnFlushColourSettings
            // 
            this.kbtnFlushColourSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnFlushColourSettings.Enabled = false;
            this.kbtnFlushColourSettings.Location = new System.Drawing.Point(347, 258);
            this.kbtnFlushColourSettings.Name = "kbtnFlushColourSettings";
            this.kbtnFlushColourSettings.Size = new System.Drawing.Size(149, 25);
            this.kbtnFlushColourSettings.TabIndex = 2;
            this.kbtnFlushColourSettings.Values.Text = "&Flush Colour Settings";
            this.kbtnFlushColourSettings.Click += new System.EventHandler(this.kbtnFlushColourSettings_Click);
            // 
            // InternalBasicPaletteCreatorOptions
            // 
            this.AcceptButton = this.kbtnOk;
            this.ClientSize = new System.Drawing.Size(509, 342);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InternalBasicPaletteCreatorOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Palette Colour Creator Options";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private AllMergedPaletteColourSettingsManager colourSettings = new AllMergedPaletteColourSettingsManager();
        #endregion

        #region Constructors
        public InternalBasicPaletteCreatorOptions()
        {
            InitializeComponent();
        }
        #endregion

        private void kbtnFlushColourSettings_Click(object sender, EventArgs e) => colourSettings.ResetToDefaults();
    }
}