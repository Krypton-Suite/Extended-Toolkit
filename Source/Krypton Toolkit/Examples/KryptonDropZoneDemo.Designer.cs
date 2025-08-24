namespace Examples
{
    partial class KryptonDropZoneDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonDropZoneDemo));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonDropZone1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonDropZone();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDropZone1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonDropZone1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(802, 444);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonDropZone1
            // 
            this.kryptonDropZone1.AllowDrop = true;
            this.kryptonDropZone1.AllowedExtensions = ((System.Collections.Generic.List<string>)(resources.GetObject("kryptonDropZone1.AllowedExtensions")));
            this.kryptonDropZone1.Location = new System.Drawing.Point(264, 109);
            this.kryptonDropZone1.Name = "kryptonDropZone1";
            this.kryptonDropZone1.Padding = new System.Windows.Forms.Padding(20);
            this.kryptonDropZone1.ShowClearButton = false;
            this.kryptonDropZone1.ShowSizeProgressBar = false;
            this.kryptonDropZone1.Size = new System.Drawing.Size(100, 100);
            this.kryptonDropZone1.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonDropZone1.StateCommon.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonDropZone1.TabIndex = 0;
            // 
            // KryptonDropZoneDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 444);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonDropZoneDemo";
            this.Text = "KryptonDropZoneDemo";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDropZone1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonDropZone kryptonDropZone1;
    }
}