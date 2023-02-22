#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.SharpUpdate
{
    internal class SharpUpdateInfoForm : KryptonForm
    {
        #region Design Code
        private KryptonButton kbtnBack;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonTextBox ktxtDescription;
        private KryptonLabel klblDescription;
        private KryptonLabel klblVersions;
        private PictureBox pictureBox1;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnBack = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.ktxtDescription = new Krypton.Toolkit.KryptonTextBox();
            this.klblDescription = new Krypton.Toolkit.KryptonLabel();
            this.klblVersions = new Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnBack);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 239);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(284, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnBack
            // 
            this.kbtnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnBack.Location = new System.Drawing.Point(97, 13);
            this.kbtnBack.Name = "kbtnBack";
            this.kbtnBack.Size = new System.Drawing.Size(90, 25);
            this.kbtnBack.TabIndex = 1;
            this.kbtnBack.Values.Text = "B&ack";
            this.kbtnBack.Click += this.kbtnBack_Click;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(284, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtDescription);
            this.kryptonPanel2.Controls.Add(this.klblDescription);
            this.kryptonPanel2.Controls.Add(this.klblVersions);
            this.kryptonPanel2.Controls.Add(this.pictureBox1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(284, 239);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // ktxtDescription
            // 
            this.ktxtDescription.Location = new System.Drawing.Point(12, 124);
            this.ktxtDescription.Multiline = true;
            this.ktxtDescription.Name = "ktxtDescription";
            this.ktxtDescription.ReadOnly = true;
            this.ktxtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ktxtDescription.Size = new System.Drawing.Size(260, 95);
            this.ktxtDescription.TabIndex = 12;
            this.ktxtDescription.KeyDown += this.ktxtDescription_KeyDown;
            // 
            // klblDescription
            // 
            this.klblDescription.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblDescription.Location = new System.Drawing.Point(12, 98);
            this.klblDescription.Name = "klblDescription";
            this.klblDescription.Size = new System.Drawing.Size(80, 20);
            this.klblDescription.TabIndex = 11;
            this.klblDescription.Values.Text = "Description:";
            // 
            // klblVersions
            // 
            this.klblVersions.AutoSize = false;
            this.klblVersions.Location = new System.Drawing.Point(98, 22);
            this.klblVersions.Name = "klblVersions";
            this.klblVersions.Size = new System.Drawing.Size(174, 61);
            this.klblVersions.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblVersions.TabIndex = 10;
            this.klblVersions.Values.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // SharpUpdateInfoForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 289);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpUpdateInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Constructor
        internal SharpUpdateInfoForm(SharpUpdateLocalAppInfo applicationInfo, SharpUpdateXml updateInfo)
        {
            InitializeComponent();

            try
            {
                if (applicationInfo.ApplicationIcon != null) Icon = applicationInfo.ApplicationIcon;

                // ReSharper disable VirtualMemberCallInConstructor
                Text = Properties.Resources.SharpUpdateInfoForm_Title;
                // ReSharper restore VirtualMemberCallInConstructor

                klblVersions.Text = string.Format(Properties.Resources.SharpUpdateInfoForm_Version, applicationInfo.ApplicationAssembly.GetName().Version, updateInfo.Version);

                klblDescription.Text = Properties.Resources.SharpUpdateInfoForm_lblDescription;

                ktxtDescription.Text = updateInfo.Description;

                kbtnBack.Text = Properties.Resources.SharpUpdateInfoForm_btnBack;
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }
        #endregion

        private void ktxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Control && e.KeyCode == Keys.C))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void kbtnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}