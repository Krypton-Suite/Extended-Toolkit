namespace Krypton.Toolkit.Suite.Extended.IO
{
	public class KryptonSystemInformation : KryptonForm
	{
		private KryptonPanel kryptonPanel1;
		private KryptonBorderEdge kryptonBorderEdge1;
		private KryptonButton kbtnClose;
		private KryptonRichTextBox kryptonRichTextBox1;
		private KryptonPanel kryptonPanel2;

		private void InitializeComponent()
		{
			this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
			this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
			this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
			this.kryptonRichTextBox1 = new Krypton.Toolkit.KryptonRichTextBox();
			this.kbtnClose = new Krypton.Toolkit.KryptonButton();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
			this.kryptonPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.kbtnClose);
			this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 556);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
			this.kryptonPanel1.Size = new System.Drawing.Size(814, 50);
			this.kryptonPanel1.TabIndex = 0;
			// 
			// kryptonBorderEdge1
			// 
			this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
			this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
			this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
			this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
			this.kryptonBorderEdge1.Size = new System.Drawing.Size(814, 1);
			this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
			// 
			// kryptonPanel2
			// 
			this.kryptonPanel2.Controls.Add(this.kryptonRichTextBox1);
			this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel2.Name = "kryptonPanel2";
			this.kryptonPanel2.Size = new System.Drawing.Size(814, 556);
			this.kryptonPanel2.TabIndex = 1;
			// 
			// kryptonRichTextBox1
			// 
			this.kryptonRichTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonRichTextBox1.Location = new System.Drawing.Point(13, 13);
			this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
			this.kryptonRichTextBox1.ReadOnly = true;
			this.kryptonRichTextBox1.Size = new System.Drawing.Size(789, 527);
			this.kryptonRichTextBox1.TabIndex = 0;
			this.kryptonRichTextBox1.Text = "kryptonRichTextBox1";
			// 
			// kbtnClose
			// 
			this.kbtnClose.Location = new System.Drawing.Point(362, 13);
			this.kbtnClose.Name = "kbtnClose";
			this.kbtnClose.Size = new System.Drawing.Size(90, 25);
			this.kbtnClose.TabIndex = 1;
			this.kbtnClose.Values.Text = "Cl&ose";
			// 
			// KryptonSystemInformation
			// 
			this.ClientSize = new System.Drawing.Size(814, 606);
			this.Controls.Add(this.kryptonPanel2);
			this.Controls.Add(this.kryptonPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "KryptonSystemInformation";
			this.ShowInTaskbar = false;
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
			this.kryptonPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}