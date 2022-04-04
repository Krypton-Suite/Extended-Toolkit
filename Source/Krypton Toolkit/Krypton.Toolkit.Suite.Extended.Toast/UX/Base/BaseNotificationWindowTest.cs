namespace Krypton.Toolkit.Suite.Extended.Toast
{
    internal class BaseNotificationWindowTest : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private KryptonPanel kryptonPanel2;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private PictureBox pbxToastImage;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel2;
        private KryptonWrapLabel kwlTitle;
        private KryptonRichTextBox krtbContent;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseNotificationWindowTest));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.pbxToastImage = new System.Windows.Forms.PictureBox();
            this.kryptonTableLayoutPanel2 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.kwlTitle = new Krypton.Toolkit.KryptonWrapLabel();
            this.krtbContent = new Krypton.Toolkit.KryptonRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxToastImage)).BeginInit();
            this.kryptonTableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 243);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(609, 50);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(609, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonTableLayoutPanel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(609, 243);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 2;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.Controls.Add(this.pbxToastImage, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonTableLayoutPanel2, 1, 0);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 1;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(609, 243);
            this.kryptonTableLayoutPanel1.TabIndex = 0;
            // 
            // pbxToastImage
            // 
            this.pbxToastImage.BackColor = System.Drawing.Color.Transparent;
            this.pbxToastImage.Location = new System.Drawing.Point(3, 3);
            this.pbxToastImage.Name = "pbxToastImage";
            this.pbxToastImage.Size = new System.Drawing.Size(128, 128);
            this.pbxToastImage.TabIndex = 0;
            this.pbxToastImage.TabStop = false;
            // 
            // kryptonTableLayoutPanel2
            // 
            this.kryptonTableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel2.BackgroundImage")));
            this.kryptonTableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel2.ColumnCount = 1;
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel2.Controls.Add(this.kwlTitle, 0, 0);
            this.kryptonTableLayoutPanel2.Controls.Add(this.krtbContent, 0, 1);
            this.kryptonTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel2.Location = new System.Drawing.Point(137, 3);
            this.kryptonTableLayoutPanel2.Name = "kryptonTableLayoutPanel2";
            this.kryptonTableLayoutPanel2.RowCount = 2;
            this.kryptonTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel2.Size = new System.Drawing.Size(469, 237);
            this.kryptonTableLayoutPanel2.TabIndex = 1;
            // 
            // kwlTitle
            // 
            this.kwlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlTitle.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlTitle.Location = new System.Drawing.Point(3, 0);
            this.kwlTitle.Name = "kwlTitle";
            this.kwlTitle.Size = new System.Drawing.Size(463, 135);
            this.kwlTitle.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlTitle.Text = "kryptonWrapLabel1";
            this.kwlTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // krtbContent
            // 
            this.krtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbContent.Location = new System.Drawing.Point(3, 138);
            this.krtbContent.Name = "krtbContent";
            this.krtbContent.ReadOnly = true;
            this.krtbContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.krtbContent.Size = new System.Drawing.Size(463, 96);
            this.krtbContent.TabIndex = 1;
            this.krtbContent.Text = "";
            // 
            // BaseNotificationWindowTest
            // 
            this.ClientSize = new System.Drawing.Size(609, 293);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseNotificationWindowTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxToastImage)).EndInit();
            this.kryptonTableLayoutPanel2.ResumeLayout(false);
            this.kryptonTableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}