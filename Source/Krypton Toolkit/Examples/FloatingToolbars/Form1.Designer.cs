
namespace FloatingToolbars
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnFloatableMenuStrip = new Krypton.Toolkit.KryptonButton();
            this.kbtnFloatableToolStrip = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnFloatableToolStrip);
            this.kryptonPanel1.Controls.Add(this.kbtnFloatableMenuStrip);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(272, 78);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnFloatableMenuStrip
            // 
            this.kbtnFloatableMenuStrip.Location = new System.Drawing.Point(12, 12);
            this.kbtnFloatableMenuStrip.Name = "kbtnFloatableMenuStrip";
            this.kbtnFloatableMenuStrip.Size = new System.Drawing.Size(248, 25);
            this.kbtnFloatableMenuStrip.TabIndex = 0;
            this.kbtnFloatableMenuStrip.Values.Text = "Floatable MenuStrip";
            this.kbtnFloatableMenuStrip.Click += new System.EventHandler(this.kbtnFloatableMenuStrip_Click);
            // 
            // kbtnFloatableToolStrip
            // 
            this.kbtnFloatableToolStrip.Location = new System.Drawing.Point(12, 43);
            this.kbtnFloatableToolStrip.Name = "kbtnFloatableToolStrip";
            this.kbtnFloatableToolStrip.Size = new System.Drawing.Size(248, 25);
            this.kbtnFloatableToolStrip.TabIndex = 1;
            this.kbtnFloatableToolStrip.Values.Text = "Floatable ToolStrip";
            this.kbtnFloatableToolStrip.Click += new System.EventHandler(this.kbtnFloatableToolStrip_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 78);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Floating Toolbars";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnFloatableToolStrip;
        private Krypton.Toolkit.KryptonButton kbtnFloatableMenuStrip;
    }
}

