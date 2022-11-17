namespace TestApp
{
    partial class KryptonFormExtended1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonFormExtended1));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCloseButton = new Krypton.Toolkit.KryptonCheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnCloseButton);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnCloseButton
            // 
            this.kbtnCloseButton.CornerRoundingRadius = -1F;
            this.kbtnCloseButton.Location = new System.Drawing.Point(346, 214);
            this.kbtnCloseButton.Name = "kbtnCloseButton";
            this.kbtnCloseButton.Size = new System.Drawing.Size(172, 22);
            this.kbtnCloseButton.TabIndex = 1;
            this.kbtnCloseButton.Values.Text = "Disable Close Button";
            this.kbtnCloseButton.CheckedChanged += new System.EventHandler(this.kbtnCloseButton_CheckedChanged);
            // 
            // KryptonFormExtended1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.FadeSpeedChoice = Krypton.Toolkit.Suite.Extended.Forms.FadeSpeedChoice.Fast;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KryptonFormExtended1";
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 5F;
            this.Text = "KryptonFormExtended1";
            this.UseBlur = true;
            this.Load += new System.EventHandler(this.KryptonFormExtended1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonCheckButton kbtnCloseButton;
    }
}