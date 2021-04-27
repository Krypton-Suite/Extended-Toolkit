
namespace Buttons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kryptonUACButtonVersion11 = new Krypton.Toolkit.Suite.Extended.Buttons.KryptonUACButtonVersion1();
            this.kryptonUACButtonVersion21 = new Krypton.Toolkit.Suite.Extended.Buttons.KryptonUACButtonVersion2();
            this.SuspendLayout();
            // 
            // kryptonUACButtonVersion11
            // 
            this.kryptonUACButtonVersion11.AssemblyToElevate = null;
            this.kryptonUACButtonVersion11.Location = new System.Drawing.Point(393, 129);
            this.kryptonUACButtonVersion11.Name = "kryptonUACButtonVersion11";
            this.kryptonUACButtonVersion11.ShowUACShield = true;
            this.kryptonUACButtonVersion11.Size = new System.Drawing.Size(243, 51);
            this.kryptonUACButtonVersion11.TabIndex = 0;
            this.kryptonUACButtonVersion11.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonUACButtonVersion11.Values.Image")));
            this.kryptonUACButtonVersion11.Values.Text = "kryptonUACButtonVersion11";
            // 
            // kryptonUACButtonVersion21
            // 
            this.kryptonUACButtonVersion21.ExtraArguments = null;
            this.kryptonUACButtonVersion21.Location = new System.Drawing.Point(393, 210);
            this.kryptonUACButtonVersion21.Name = "kryptonUACButtonVersion21";
            this.kryptonUACButtonVersion21.PathToElevatedObject = null;
            this.kryptonUACButtonVersion21.Size = new System.Drawing.Size(243, 56);
            this.kryptonUACButtonVersion21.TabIndex = 1;
            this.kryptonUACButtonVersion21.UseAsUACElevatedButton = true;
            this.kryptonUACButtonVersion21.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonUACButtonVersion21.Values.Image")));
            this.kryptonUACButtonVersion21.Values.Text = "kryptonUACButtonVersion21";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonUACButtonVersion21);
            this.Controls.Add(this.kryptonUACButtonVersion11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Buttons.KryptonUACButtonVersion1 kryptonUACButtonVersion11;
        private Krypton.Toolkit.Suite.Extended.Buttons.KryptonUACButtonVersion2 kryptonUACButtonVersion21;
    }
}

