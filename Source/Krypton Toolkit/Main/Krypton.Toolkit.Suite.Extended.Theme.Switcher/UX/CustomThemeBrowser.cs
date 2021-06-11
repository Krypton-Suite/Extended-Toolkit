namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class CustomThemeBrowser : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnBrowse;
        private KryptonTextBox ktxtThemePath;
        private KryptonButton kbtnApply;
        private KryptonButton kbtnCancel;
        private KryptonLabel kryptonLabel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.ktxtThemePath = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnApply);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 106);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(532, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnApply
            // 
            this.kbtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnApply.Enabled = false;
            this.kbtnApply.Location = new System.Drawing.Point(334, 13);
            this.kbtnApply.Name = "kbtnApply";
            this.kbtnApply.Size = new System.Drawing.Size(90, 25);
            this.kbtnApply.TabIndex = 2;
            this.kbtnApply.Values.Text = "A&pply";
            this.kbtnApply.Click += new System.EventHandler(this.kbtnApply_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(430, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(532, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnBrowse);
            this.kryptonPanel2.Controls.Add(this.ktxtThemePath);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(532, 106);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnBrowse
            // 
            this.kbtnBrowse.Location = new System.Drawing.Point(487, 41);
            this.kbtnBrowse.Name = "kbtnBrowse";
            this.kbtnBrowse.Size = new System.Drawing.Size(33, 25);
            this.kbtnBrowse.TabIndex = 2;
            this.kbtnBrowse.Values.Text = "...";
            this.kbtnBrowse.Click += new System.EventHandler(this.kbtnBrowse_Click);
            // 
            // ktxtThemePath
            // 
            this.ktxtThemePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.ktxtThemePath.Hint = "Please enter a theme file path...";
            this.ktxtThemePath.Location = new System.Drawing.Point(126, 41);
            this.ktxtThemePath.Name = "ktxtThemePath";
            this.ktxtThemePath.Size = new System.Drawing.Size(355, 23);
            this.ktxtThemePath.TabIndex = 1;
            this.ktxtThemePath.TextChanged += new System.EventHandler(this.ktxtThemePath_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 41);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(107, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Theme File Path:";
            // 
            // CustomThemeBrowser
            // 
            this.AcceptButton = this.kbtnApply;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(532, 156);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomThemeBrowser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private KryptonPalette _palette = null;
        #endregion

        #region Constructor
        public CustomThemeBrowser()
        {
            InitializeComponent();
        }
        #endregion

        private void kbtnBrowse_Click(object sender, EventArgs e)
        {
            _palette = new KryptonPalette();

            _palette.Import();

            ktxtThemePath.Text = _palette.GetCustomisedKryptonPaletteFilePath();
        }

        private void ktxtThemePath_TextChanged(object sender, EventArgs e)
        {
            kbtnApply.Enabled = MissingFrameWorkAPIs.IsNullOrWhiteSpace(ktxtThemePath.Text);
        }

        private void kbtnApply_Click(object sender, EventArgs e)
        {
            Properties.Settings settings = new Properties.Settings();

            settings.SelectedTheme = PaletteModeManager.Custom;

            settings.CustomThemePath = ktxtThemePath.Text;

            settings.Save();
        }
    }
}