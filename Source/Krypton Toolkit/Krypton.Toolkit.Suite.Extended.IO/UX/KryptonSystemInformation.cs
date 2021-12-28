#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.IO
{
	public class KryptonSystemInformation : KryptonForm
	{
		#region Design Code
		private KryptonPanel kryptonPanel1;
		private KryptonBorderEdge kryptonBorderEdge1;
		private KryptonButton kbtnClose;
		private KryptonRichTextBox krtbSystemInformation;
		private KryptonButton kbtnCopy;
		private KryptonPanel kryptonPanel2;

		private void InitializeComponent()
		{
			this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
			this.kbtnCopy = new Krypton.Toolkit.KryptonButton();
			this.kbtnClose = new Krypton.Toolkit.KryptonButton();
			this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
			this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
			this.krtbSystemInformation = new Krypton.Toolkit.KryptonRichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
			this.kryptonPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.kbtnCopy);
			this.kryptonPanel1.Controls.Add(this.kbtnClose);
			this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 556);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
			this.kryptonPanel1.Size = new System.Drawing.Size(814, 50);
			this.kryptonPanel1.TabIndex = 0;
			// 
			// kbtnCopy
			// 
			this.kbtnCopy.Location = new System.Drawing.Point(12, 13);
			this.kbtnCopy.Name = "kbtnCopy";
			this.kbtnCopy.Size = new System.Drawing.Size(90, 25);
			this.kbtnCopy.TabIndex = 3;
			this.kbtnCopy.Values.Text = "&Copy";
			this.kbtnCopy.Click += new System.EventHandler(this.kbtnCopy_Click);
			// 
			// kbtnClose
			// 
			this.kbtnClose.Location = new System.Drawing.Point(712, 13);
			this.kbtnClose.Name = "kbtnClose";
			this.kbtnClose.Size = new System.Drawing.Size(90, 25);
			this.kbtnClose.TabIndex = 1;
			this.kbtnClose.Values.Text = "Cl&ose";
			this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
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
			this.kryptonPanel2.Controls.Add(this.krtbSystemInformation);
			this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel2.Name = "kryptonPanel2";
			this.kryptonPanel2.Size = new System.Drawing.Size(814, 556);
			this.kryptonPanel2.TabIndex = 1;
			// 
			// krtbSystemInformation
			// 
			this.krtbSystemInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.krtbSystemInformation.Location = new System.Drawing.Point(13, 13);
			this.krtbSystemInformation.Name = "krtbSystemInformation";
			this.krtbSystemInformation.ReadOnly = true;
			this.krtbSystemInformation.Size = new System.Drawing.Size(789, 527);
			this.krtbSystemInformation.TabIndex = 0;
			this.krtbSystemInformation.Text = "";
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
			this.Text = "System Information";
			this.Load += new System.EventHandler(this.KryptonSystemInformation_Load);
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
			this.kryptonPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Identity
		public KryptonSystemInformation()
		{
			InitializeComponent();
		}
		#endregion

		private void kbtnCopy_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(krtbSystemInformation.Text))
			{
				Clipboard.SetText(krtbSystemInformation.Text);
			}
		}

		private void kbtnClose_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void KryptonSystemInformation_Load(object sender, EventArgs e)
		{

		}
	}
}