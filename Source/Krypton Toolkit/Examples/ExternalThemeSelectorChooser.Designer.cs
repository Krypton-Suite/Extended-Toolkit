namespace Examples
{
    partial class ExternalThemeSelectorChooser
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
            this.kbtnXMLThemes = new Krypton.Toolkit.KryptonButton();
            this.kbtnBinaryThemes = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnXMLThemes);
            this.kryptonPanel1.Controls.Add(this.kbtnBinaryThemes);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(275, 79);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kbtnXMLThemes
            // 
            this.kbtnXMLThemes.CornerRoundingRadius = -1F;
            this.kbtnXMLThemes.Location = new System.Drawing.Point(13, 44);
            this.kbtnXMLThemes.Name = "kbtnXMLThemes";
            this.kbtnXMLThemes.Size = new System.Drawing.Size(250, 25);
            this.kbtnXMLThemes.TabIndex = 1;
            this.kbtnXMLThemes.Values.Text = "XML Themes";
            this.kbtnXMLThemes.Click += new System.EventHandler(this.kbtnXMLThemes_Click);
            // 
            // kbtnBinaryThemes
            // 
            this.kbtnBinaryThemes.CornerRoundingRadius = -1F;
            this.kbtnBinaryThemes.Location = new System.Drawing.Point(13, 13);
            this.kbtnBinaryThemes.Name = "kbtnBinaryThemes";
            this.kbtnBinaryThemes.Size = new System.Drawing.Size(250, 25);
            this.kbtnBinaryThemes.TabIndex = 0;
            this.kbtnBinaryThemes.Values.Text = "Binary Themes";
            this.kbtnBinaryThemes.Click += new System.EventHandler(this.kbtnBinaryThemes_Click);
            // 
            // ExternalThemeSelectorChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 79);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ExternalThemeSelectorChooser";
            this.Text = "ExternalThemeSelectorChooser";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnXMLThemes;
        private KryptonButton kbtnBinaryThemes;
    }
}