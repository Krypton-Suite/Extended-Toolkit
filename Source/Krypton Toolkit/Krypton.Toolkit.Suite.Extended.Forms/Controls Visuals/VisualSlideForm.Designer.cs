namespace Krypton.Toolkit.Suite.Extended.Forms
{
    public partial class VisualSlideForm
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
            this.components = new System.ComponentModel.Container();
            this.tmrSlide = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrSlide
            // 
            this.tmrSlide.Interval = 10;
            this.tmrSlide.Tick += new System.EventHandler(this.tmrSlide_Tick);
            // 
            // VisualSlideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 284);
            this.ControlBox = false;
            this.Name = "VisualSlideForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrSlide;
    }
}