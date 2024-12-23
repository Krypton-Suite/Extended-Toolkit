﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonSplashDialog : CommonExtendedKryptonForm
    {
        #region Design Code
        private System.Windows.Forms.ProgressBar pbLoading;
        private System.Windows.Forms.PictureBox pbAppIcon;
        private KryptonWrapLabel kwlApplicationName;
        private KryptonLabel klblClose;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.pbLoading = new();
            this.kryptonPanel1 = new();
            this.klblClose = new();
            this.pbAppIcon = new();
            this.kwlApplicationName = new();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbAppIcon).BeginInit();
            this.SuspendLayout();
            // 
            // pbLoading
            // 
            this.pbLoading.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbLoading.Location = new(0, 417);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new(797, 5);
            this.pbLoading.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.klblClose);
            this.kryptonPanel1.Controls.Add(this.pbAppIcon);
            this.kryptonPanel1.Controls.Add(this.kwlApplicationName);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new(797, 417);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // klblClose
            // 
            this.klblClose.Location = new(769, 12);
            this.klblClose.Name = "klblClose";
            this.klblClose.Size = new(20, 19);
            this.klblClose.StateCommon.ShortText.Font = new("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.klblClose.TabIndex = 6;
            this.klblClose.Values.Text = "X";
            this.klblClose.Click += new(this.klblClose_Click);
            this.klblClose.MouseEnter += new(this.klblClose_MouseEnter);
            this.klblClose.MouseLeave += new(this.klblClose_MouseLeave);
            // 
            // pbAppIcon
            // 
            this.pbAppIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbAppIcon.Location = new(274, 32);
            this.pbAppIcon.Name = "pbAppIcon";
            this.pbAppIcon.Size = new(256, 256);
            this.pbAppIcon.TabIndex = 1;
            this.pbAppIcon.TabStop = false;
            // 
            // kwlApplicationName
            // 
            this.kwlApplicationName.AutoSize = false;
            this.kwlApplicationName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kwlApplicationName.Font = new("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.kwlApplicationName.ForeColor = System.Drawing.Color.FromArgb((int)(byte)30, (int)(byte)57, (int)(byte)91);
            this.kwlApplicationName.Location = new(0, 302);
            this.kwlApplicationName.Name = "kwlApplicationName";
            this.kwlApplicationName.Size = new(797, 115);
            this.kwlApplicationName.StateCommon.Font = new("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.kwlApplicationName.Text = "<##APPLICATION-NAME##>";
            this.kwlApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KryptonSplashDialog
            // 
            this.ClientSize = new(797, 422);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.pbLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "KryptonSplashDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbAppIcon).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Properties
        public bool ShowProgressBar { get; set; } = false;

        public string ApplicationName { get; set; } = null;

        public int LoadingBarMaximum { get; set; } = 100;

        public int LoadingBarMinimum { get; set; } = 0;

        public int LoadingBarIncrement { get; set; } = 1;

        public Image ApplicationIcon { get; set; } = null;
        #endregion

        #region Constructors
        public KryptonSplashDialog()
        {
            InitializeComponent();

            UpdateUI(ShowProgressBar, ApplicationName, ApplicationIcon);

            if (ShowProgressBar)
            {
                UpdateProgressBar(LoadingBarMaximum, LoadingBarIncrement);
            }
        }

        public KryptonSplashDialog(bool showProgressBar, string applicationName, Image applicationIcon)
        {
            InitializeComponent();

            UpdateUI(showProgressBar, applicationName, applicationIcon);

            if (showProgressBar)
            {
                UpdateProgressBar(LoadingBarMaximum, LoadingBarIncrement);
            }
        }
        #endregion

        #region Methods
        private void UpdateUI(bool showProgressBar, string applicationName, Image applicationIcon)
        {
            pbLoading.Visible = showProgressBar;

            kwlApplicationName.Text = applicationName;

            pbAppIcon.Image = applicationIcon;
        }

        public void UpdateProgressBar(int maximum = 100, int increment = 1)
        {
            if (ShowProgressBar)
            {
                pbLoading.Maximum = maximum;

                while (pbLoading.Value >= maximum)
                {
                    pbLoading.Increment(increment);
                }
            }
        }
        #endregion

        private void klblClose_MouseEnter(object sender, EventArgs e)
        {
            klblClose.StateCommon.ShortText.Color1 = Color.Red;

            klblClose.StateCommon.ShortText.Color2 = Color.Red;
        }

        private void klblClose_MouseLeave(object sender, EventArgs e)
        {
            klblClose.StateCommon.ShortText.Color1 = Color.Empty;

            klblClose.StateCommon.ShortText.Color2 = Color.Empty;
        }

        private void klblClose_Click(object sender, EventArgs e) => Application.Exit();
    }
}