namespace TestApp
{
    partial class FloatingMenuToolbarAdvancedExample
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
            this.menuStripPanelExtened1 = new Krypton.Toolkit.Suite.Extended.Floating.Toolbars.MenuStripPanelExtened();
            this.SuspendLayout();
            // 
            // menuStripPanelExtened1
            // 
            this.menuStripPanelExtened1.FloatableMenuStrip = null;
            this.menuStripPanelExtened1.Location = new System.Drawing.Point(189, 108);
            this.menuStripPanelExtened1.Name = "menuStripPanelExtened1";
            this.menuStripPanelExtened1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.menuStripPanelExtened1.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.menuStripPanelExtened1.Size = new System.Drawing.Size(75, 23);
            // 
            // FloatingMenuToolbarAdvancedExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 386);
            this.Controls.Add(this.menuStripPanelExtened1);
            this.Name = "FloatingMenuToolbarAdvancedExample";
            this.Text = "FloatingMenuToolbarAdvancedExample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Floating.Toolbars.MenuStripPanelExtened menuStripPanelExtened1;
    }
}