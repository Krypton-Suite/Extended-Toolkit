#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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
    partial class ThemeTools
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
            this.kbtnThemeSelector = new Krypton.Toolkit.KryptonButton();
            this.kbtnExternalThemeSelector = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnThemeSelector);
            this.kryptonPanel1.Controls.Add(this.kbtnExternalThemeSelector);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(275, 77);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnThemeSelector
            // 
            this.kbtnThemeSelector.Location = new System.Drawing.Point(13, 43);
            this.kbtnThemeSelector.Name = "kbtnThemeSelector";
            this.kbtnThemeSelector.Size = new System.Drawing.Size(250, 25);
            this.kbtnThemeSelector.TabIndex = 2;
            this.kbtnThemeSelector.Values.Text = "Theme Selector";
            this.kbtnThemeSelector.Click += new System.EventHandler(this.kbtnThemeSelector_Click);
            // 
            // kbtnExternalThemeSelector
            // 
            this.kbtnExternalThemeSelector.Location = new System.Drawing.Point(13, 12);
            this.kbtnExternalThemeSelector.Name = "kbtnExternalThemeSelector";
            this.kbtnExternalThemeSelector.Size = new System.Drawing.Size(250, 25);
            this.kbtnExternalThemeSelector.TabIndex = 1;
            this.kbtnExternalThemeSelector.Values.Text = "External Theme Selector";
            this.kbtnExternalThemeSelector.Click += new System.EventHandler(this.kbtnExternalThemeSelector_Click);
            // 
            // ThemeTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 77);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ThemeTools";
            this.Text = "ThemeTools";
            this.Load += new System.EventHandler(this.ThemeTools_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnThemeSelector;
        private KryptonButton kbtnExternalThemeSelector;
    }
}