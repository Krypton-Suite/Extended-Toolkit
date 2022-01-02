namespace ErrorReporting
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.klblDefault = new Krypton.Toolkit.KryptonLinkLabel();
            this.klbSendEMail = new Krypton.Toolkit.KryptonLinkLabel();
            this.klblSilentReport = new Krypton.Toolkit.KryptonLinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.klblSilentReport);
            this.kryptonPanel1.Controls.Add(this.klbSendEMail);
            this.kryptonPanel1.Controls.Add(this.klblDefault);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(304, 117);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // klblDefault
            // 
            this.klblDefault.Location = new System.Drawing.Point(12, 12);
            this.klblDefault.Name = "klblDefault";
            this.klblDefault.Size = new System.Drawing.Size(128, 23);
            this.klblDefault.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.klblDefault.TabIndex = 0;
            this.klblDefault.Values.Text = "Show - Defaults";
            this.klblDefault.LinkClicked += new System.EventHandler(this.klblDefault_LinkClicked);
            // 
            // klbSendEMail
            // 
            this.klbSendEMail.Location = new System.Drawing.Point(12, 41);
            this.klbSendEMail.Name = "klbSendEMail";
            this.klbSendEMail.Size = new System.Drawing.Size(209, 23);
            this.klbSendEMail.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.klbSendEMail.TabIndex = 1;
            this.klbSendEMail.Values.Text = "Show - Configured to Send";
            this.klbSendEMail.LinkClicked += new System.EventHandler(this.klbSendEMail_LinkClicked);
            // 
            // klblSilentReport
            // 
            this.klblSilentReport.Location = new System.Drawing.Point(12, 70);
            this.klblSilentReport.Name = "klblSilentReport";
            this.klblSilentReport.Size = new System.Drawing.Size(229, 23);
            this.klblSilentReport.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.klblSilentReport.TabIndex = 2;
            this.klblSilentReport.Values.Text = "Send Report (no dialog show)";
            this.klblSilentReport.LinkClicked += new System.EventHandler(this.klblSilentReport_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 117);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonLinkLabel klblSilentReport;
        private Krypton.Toolkit.KryptonLinkLabel klbSendEMail;
        private Krypton.Toolkit.KryptonLinkLabel klblDefault;
    }
}