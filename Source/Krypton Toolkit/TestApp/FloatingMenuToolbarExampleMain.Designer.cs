﻿namespace TestApp
{
    partial class FloatingMenuToolbarExampleMain
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
            this.kbtnFloatingAdvanced = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButton2);
            this.kryptonPanel1.Controls.Add(this.kbtnFloatingAdvanced);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(306, 83);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnFloatingAdvanced
            // 
            this.kbtnFloatingAdvanced.CornerRoundingRadius = -1F;
            this.kbtnFloatingAdvanced.Location = new System.Drawing.Point(13, 13);
            this.kbtnFloatingAdvanced.Name = "kbtnFloatingAdvanced";
            this.kbtnFloatingAdvanced.Size = new System.Drawing.Size(281, 25);
            this.kbtnFloatingAdvanced.TabIndex = 0;
            this.kbtnFloatingAdvanced.Values.Text = "Floating Menu && Toolbar (Advanced)";
            this.kbtnFloatingAdvanced.Click += new System.EventHandler(this.kbtnFloatingAdvanced_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.CornerRoundingRadius = -1F;
            this.kryptonButton2.Location = new System.Drawing.Point(18, 44);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(281, 25);
            this.kryptonButton2.TabIndex = 1;
            this.kryptonButton2.Values.Text = "Floating Menu && Toolbar";
            // 
            // FloatingMenuToolbarExampleMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 83);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FloatingMenuToolbarExampleMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FloatingMenuToolbarExample";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnFloatingAdvanced;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
    }
}