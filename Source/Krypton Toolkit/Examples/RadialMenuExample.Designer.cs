namespace Examples
{
    partial class RadialMenuExample
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
            this.kryptonRadialMenu1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonRadialMenu();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonRadialMenu1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(820, 390);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kryptonRadialMenu1
            // 
            this.kryptonRadialMenu1.BackColor = System.Drawing.Color.Transparent;
            this.kryptonRadialMenu1.ForeColor = System.Drawing.Color.Fuchsia;
            this.kryptonRadialMenu1.Location = new System.Drawing.Point(263, 39);
            this.kryptonRadialMenu1.Name = "kryptonRadialMenu1";
            this.kryptonRadialMenu1.Size = new System.Drawing.Size(381, 327);
            this.kryptonRadialMenu1.TabIndex = 0;
            this.kryptonRadialMenu1.MenuItemClicked += new System.EventHandler<string>(this.kryptonRadialMenu1_MenuItemClicked);
            this.kryptonRadialMenu1.SubMenuItemClicked += new System.EventHandler<string>(this.kryptonRadialMenu1_SubMenuItemClicked);
            // 
            // RadialMenuExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 390);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "RadialMenuExample";
            this.Text = "RadialMenuExample";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Controls.KryptonRadialMenu kryptonRadialMenu1;
        private KryptonPanel kryptonPanel1;
    }
}