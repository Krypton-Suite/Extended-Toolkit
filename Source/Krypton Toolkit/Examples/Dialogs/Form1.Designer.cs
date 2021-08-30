
namespace Dialogs
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
            this.kbtnAboutBox = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kabm = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonAboutBoxManager();
            this.kbtnException = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kbtnAboutBox
            // 
            this.kbtnAboutBox.Location = new System.Drawing.Point(12, 12);
            this.kbtnAboutBox.Name = "kbtnAboutBox";
            this.kbtnAboutBox.Size = new System.Drawing.Size(116, 25);
            this.kbtnAboutBox.TabIndex = 0;
            this.kbtnAboutBox.Values.Text = "&Show About Box";
            this.kbtnAboutBox.Click += new System.EventHandler(this.kbtnAboutBox_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnException);
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Controls.Add(this.kbtnAboutBox);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(275, 114);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(12, 43);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(138, 25);
            this.kryptonButton1.TabIndex = 2;
            this.kryptonButton1.Values.Text = "Show Text to Speech";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kabm
            // 
            this.kabm.AboutText = "About";
            this.kabm.Application = null;
            this.kabm.ApplicationDescription = "Krypton.Toolkit.Suite.Extended.Dialogs";
            this.kabm.ApplicationIcon = null;
            this.kabm.ApplicationText = "Application";
            this.kabm.Assembly = null;
            this.kabm.CopyrightText = "Copyright (c)";
            this.kabm.FrameworkVersionText = "Framework Version";
            this.kabm.ShowDescription = true;
            this.kabm.ShowFrameworkVersion = true;
            this.kabm.ShowSystemInformation = false;
            this.kabm.ShowSystemInformationText = "&Show System Information";
            this.kabm.VersionText = "Version";
            // 
            // kbtnException
            // 
            this.kbtnException.Location = new System.Drawing.Point(12, 74);
            this.kbtnException.Name = "kbtnException";
            this.kbtnException.Size = new System.Drawing.Size(138, 25);
            this.kbtnException.TabIndex = 2;
            this.kbtnException.Values.Text = "Test Exception Capture";
            this.kbtnException.Click += new System.EventHandler(this.kbtnException_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 114);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Dialogs.KryptonAboutBoxManager kabm;
        private Krypton.Toolkit.KryptonButton kbtnAboutBox;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton kbtnException;
    }
}

