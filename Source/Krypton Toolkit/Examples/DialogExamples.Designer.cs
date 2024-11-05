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
    partial class DialogExamples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogExamples));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnTextToSpeech = new Krypton.Toolkit.KryptonButton();
            this.kbtnSplash = new Krypton.Toolkit.KryptonButton();
            this.kbtnRun = new Krypton.Toolkit.KryptonButton();
            this.kbtnCheckSum = new Krypton.Toolkit.KryptonButton();
            this.kbtnException = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnTextToSpeech);
            this.kryptonPanel1.Controls.Add(this.kbtnSplash);
            this.kryptonPanel1.Controls.Add(this.kbtnRun);
            this.kryptonPanel1.Controls.Add(this.kbtnCheckSum);
            this.kryptonPanel1.Controls.Add(this.kbtnException);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(363, 77);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnTextToSpeech
            // 
            this.kbtnTextToSpeech.Location = new System.Drawing.Point(125, 38);
            this.kbtnTextToSpeech.Name = "kbtnTextToSpeech";
            this.kbtnTextToSpeech.Size = new System.Drawing.Size(109, 22);
            this.kbtnTextToSpeech.TabIndex = 8;
            this.kbtnTextToSpeech.Values.Text = "Text to Speech";
            this.kbtnTextToSpeech.Click += new System.EventHandler(this.kbtnTextToSpeech_Click);
            // 
            // kbtnSplash
            // 
            this.kbtnSplash.Location = new System.Drawing.Point(10, 38);
            this.kbtnSplash.Name = "kbtnSplash";
            this.kbtnSplash.Size = new System.Drawing.Size(109, 22);
            this.kbtnSplash.TabIndex = 7;
            this.kbtnSplash.Values.Text = "Splash";
            this.kbtnSplash.Click += new System.EventHandler(this.kbtnSplash_Click);
            // 
            // kbtnRun
            // 
            this.kbtnRun.Location = new System.Drawing.Point(240, 10);
            this.kbtnRun.Name = "kbtnRun";
            this.kbtnRun.Size = new System.Drawing.Size(109, 22);
            this.kbtnRun.TabIndex = 6;
            this.kbtnRun.Values.Text = "Run";
            this.kbtnRun.Click += new System.EventHandler(this.kbtnRun_Click);
            // 
            // kbtnCheckSum
            // 
            this.kbtnCheckSum.Location = new System.Drawing.Point(125, 10);
            this.kbtnCheckSum.Name = "kbtnCheckSum";
            this.kbtnCheckSum.Size = new System.Drawing.Size(109, 22);
            this.kbtnCheckSum.TabIndex = 4;
            this.kbtnCheckSum.Values.Text = "Properties";
            this.kbtnCheckSum.Click += new System.EventHandler(this.kbtnCheckSum_Click);
            // 
            // kbtnException
            // 
            this.kbtnException.Location = new System.Drawing.Point(10, 10);
            this.kbtnException.Name = "kbtnException";
            this.kbtnException.Size = new System.Drawing.Size(109, 22);
            this.kbtnException.TabIndex = 3;
            this.kbtnException.Values.Text = "Exception";
            this.kbtnException.Click += new System.EventHandler(this.kbtnException_Click);
            // 
            // DialogExamples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 77);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogExamples";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dialog Examples";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnTextToSpeech;
        private KryptonButton kbtnSplash;
        private KryptonButton kbtnRun;
        private KryptonButton kbtnCheckSum;
        private KryptonButton kbtnException;
    }
}