#region MIT License

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
namespace Examples
{
    partial class KryptonProgressBarExtendedExamples
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonProgressBarExtended1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtended();
            this.kryptonProgressBar1 = new Krypton.Toolkit.KryptonProgressBar();
            this.kryptonProgressBarExtendedVersion11 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtendedVersion1();
            this.ktbValue = new Krypton.Toolkit.KryptonTrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.ktbValue);
            this.kryptonPanel1.Controls.Add(this.kryptonProgressBarExtendedVersion11);
            this.kryptonPanel1.Controls.Add(this.kryptonProgressBarExtended1);
            this.kryptonPanel1.Controls.Add(this.kryptonProgressBar1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(409, 166);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonProgressBarExtended1
            // 
            this.kryptonProgressBarExtended1.ForeColor = System.Drawing.Color.Empty;
            this.kryptonProgressBarExtended1.Location = new System.Drawing.Point(12, 85);
            this.kryptonProgressBarExtended1.Name = "kryptonProgressBarExtended1";
            this.kryptonProgressBarExtended1.Size = new System.Drawing.Size(383, 26);
            this.kryptonProgressBarExtended1.TabIndex = 1;
            this.kryptonProgressBarExtended1.Text = "0%";
            // 
            // kryptonProgressBar1
            // 
            this.kryptonProgressBar1.Location = new System.Drawing.Point(12, 52);
            this.kryptonProgressBar1.Name = "kryptonProgressBar1";
            this.kryptonProgressBar1.Size = new System.Drawing.Size(383, 26);
            this.kryptonProgressBar1.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.kryptonProgressBar1.StateDisabled.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.kryptonProgressBar1.StateNormal.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.kryptonProgressBar1.TabIndex = 0;
            this.kryptonProgressBar1.Text = "kryptonProgressBar1";
            this.kryptonProgressBar1.Values.Text = "kryptonProgressBar1";
            // 
            // kryptonProgressBarExtendedVersion11
            // 
            this.kryptonProgressBarExtendedVersion11.BackColor = System.Drawing.Color.Transparent;
            this.kryptonProgressBarExtendedVersion11.Location = new System.Drawing.Point(12, 118);
            this.kryptonProgressBarExtendedVersion11.Name = "kryptonProgressBarExtendedVersion11";
            this.kryptonProgressBarExtendedVersion11.Size = new System.Drawing.Size(383, 32);
            this.kryptonProgressBarExtendedVersion11.TabIndex = 2;
            // 
            // ktbValue
            // 
            this.ktbValue.Location = new System.Drawing.Point(13, 13);
            this.ktbValue.Maximum = 100;
            this.ktbValue.Name = "ktbValue";
            this.ktbValue.Size = new System.Drawing.Size(382, 33);
            this.ktbValue.TabIndex = 3;
            this.ktbValue.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ktbValue.ValueChanged += new System.EventHandler(this.ktbValue_ValueChanged);
            // 
            // KryptonProgressBarExtendedExamples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 166);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonProgressBarExtendedExamples";
            this.Text = "KryptonProgressBarExtendedExamples";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonProgressBar kryptonProgressBar1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtended kryptonProgressBarExtended1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtendedVersion1 kryptonProgressBarExtendedVersion11;
        private KryptonTrackBar ktbValue;
    }
}