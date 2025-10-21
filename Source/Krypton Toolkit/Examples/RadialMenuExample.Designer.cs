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
            this.kryptonRadialMenu1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonRadialMenu();
            this.SuspendLayout();
            // 
            // kryptonRadialMenu1
            // 
            this.kryptonRadialMenu1.Location = new System.Drawing.Point(111, 28);
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
            this.ClientSize = new System.Drawing.Size(806, 432);
            this.Controls.Add(this.kryptonRadialMenu1);
            this.Name = "RadialMenuExample";
            this.Text = "RadialMenuExample";
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Controls.KryptonRadialMenu kryptonRadialMenu1;
    }
}