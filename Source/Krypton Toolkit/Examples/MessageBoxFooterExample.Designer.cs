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
    partial class MessageBoxFooterExample
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
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.btnErrorWithFooter = new Krypton.Toolkit.KryptonButton();
            this.btnWarningWithExpandedFooter = new Krypton.Toolkit.KryptonButton();
            this.btnInfoWithTechnicalDetails = new Krypton.Toolkit.KryptonButton();
            this.btnQuestionWithHelp = new Krypton.Toolkit.KryptonButton();
            this.btnExceptionDetails = new Krypton.Toolkit.KryptonButton();
            this.btnValidationErrors = new Krypton.Toolkit.KryptonButton();
            this.btnSystemInfo = new Krypton.Toolkit.KryptonButton();
            this.btnNoFooter = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 600);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 50);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnErrorWithFooter);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnWarningWithExpandedFooter);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnInfoWithTechnicalDetails);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnQuestionWithHelp);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnExceptionDetails);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnValidationErrors);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnSystemInfo);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnNoFooter);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(776, 538);
            this.kryptonGroupBox1.TabIndex = 1;
            this.kryptonGroupBox1.Values.Heading = "Expandable Footer Examples";
            // 
            // btnErrorWithFooter
            // 
            this.btnErrorWithFooter.Location = new System.Drawing.Point(15, 15);
            this.btnErrorWithFooter.Name = "btnErrorWithFooter";
            this.btnErrorWithFooter.Size = new System.Drawing.Size(360, 50);
            this.btnErrorWithFooter.TabIndex = 0;
            this.btnErrorWithFooter.Values.Text = "1. Error with Collapsed Footer (Stack Trace)";
            this.btnErrorWithFooter.Click += new System.EventHandler(this.btnErrorWithFooter_Click);
            // 
            // btnWarningWithExpandedFooter
            // 
            this.btnWarningWithExpandedFooter.Location = new System.Drawing.Point(400, 15);
            this.btnWarningWithExpandedFooter.Name = "btnWarningWithExpandedFooter";
            this.btnWarningWithExpandedFooter.Size = new System.Drawing.Size(360, 50);
            this.btnWarningWithExpandedFooter.TabIndex = 1;
            this.btnWarningWithExpandedFooter.Values.Text = "2. Warning with Expanded Footer";
            this.btnWarningWithExpandedFooter.Click += new System.EventHandler(this.btnWarningWithExpandedFooter_Click);
            // 
            // btnInfoWithTechnicalDetails
            // 
            this.btnInfoWithTechnicalDetails.Location = new System.Drawing.Point(15, 80);
            this.btnInfoWithTechnicalDetails.Name = "btnInfoWithTechnicalDetails";
            this.btnInfoWithTechnicalDetails.Size = new System.Drawing.Size(360, 50);
            this.btnInfoWithTechnicalDetails.TabIndex = 2;
            this.btnInfoWithTechnicalDetails.Values.Text = "3. Information with Technical Details";
            this.btnInfoWithTechnicalDetails.Click += new System.EventHandler(this.btnInfoWithTechnicalDetails_Click);
            // 
            // btnQuestionWithHelp
            // 
            this.btnQuestionWithHelp.Location = new System.Drawing.Point(400, 80);
            this.btnQuestionWithHelp.Name = "btnQuestionWithHelp";
            this.btnQuestionWithHelp.Size = new System.Drawing.Size(360, 50);
            this.btnQuestionWithHelp.TabIndex = 3;
            this.btnQuestionWithHelp.Values.Text = "4. Question with Help Text";
            this.btnQuestionWithHelp.Click += new System.EventHandler(this.btnQuestionWithHelp_Click);
            // 
            // btnExceptionDetails
            // 
            this.btnExceptionDetails.Location = new System.Drawing.Point(15, 145);
            this.btnExceptionDetails.Name = "btnExceptionDetails";
            this.btnExceptionDetails.Size = new System.Drawing.Size(360, 50);
            this.btnExceptionDetails.TabIndex = 4;
            this.btnExceptionDetails.Values.Text = "5. Exception Details";
            this.btnExceptionDetails.Click += new System.EventHandler(this.btnExceptionDetails_Click);
            // 
            // btnValidationErrors
            // 
            this.btnValidationErrors.Location = new System.Drawing.Point(400, 145);
            this.btnValidationErrors.Name = "btnValidationErrors";
            this.btnValidationErrors.Size = new System.Drawing.Size(360, 50);
            this.btnValidationErrors.TabIndex = 5;
            this.btnValidationErrors.Values.Text = "6. Validation Errors (Expanded)";
            this.btnValidationErrors.Click += new System.EventHandler(this.btnValidationErrors_Click);
            // 
            // btnSystemInfo
            // 
            this.btnSystemInfo.Location = new System.Drawing.Point(15, 210);
            this.btnSystemInfo.Name = "btnSystemInfo";
            this.btnSystemInfo.Size = new System.Drawing.Size(360, 50);
            this.btnSystemInfo.TabIndex = 6;
            this.btnSystemInfo.Values.Text = "7. System Information";
            this.btnSystemInfo.Click += new System.EventHandler(this.btnSystemInfo_Click);
            // 
            // btnNoFooter
            // 
            this.btnNoFooter.Location = new System.Drawing.Point(400, 210);
            this.btnNoFooter.Name = "btnNoFooter";
            this.btnNoFooter.Size = new System.Drawing.Size(360, 50);
            this.btnNoFooter.TabIndex = 7;
            this.btnNoFooter.Values.Text = "8. Standard Message (No Footer)";
            this.btnNoFooter.Click += new System.EventHandler(this.btnNoFooter_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(776, 32);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel1.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "ExtendedKryptonMessageBox - Expandable Footer Feature Examples";
            // 
            // MessageBoxFooterExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "MessageBoxFooterExample";
            this.Text = "MessageBox Footer Examples";
            this.Load += new System.EventHandler(this.MessageBoxFooterExample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonButton btnErrorWithFooter;
        private Krypton.Toolkit.KryptonButton btnWarningWithExpandedFooter;
        private Krypton.Toolkit.KryptonButton btnInfoWithTechnicalDetails;
        private Krypton.Toolkit.KryptonButton btnQuestionWithHelp;
        private Krypton.Toolkit.KryptonButton btnExceptionDetails;
        private Krypton.Toolkit.KryptonButton btnValidationErrors;
        private Krypton.Toolkit.KryptonButton btnSystemInfo;
        private Krypton.Toolkit.KryptonButton btnNoFooter;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
