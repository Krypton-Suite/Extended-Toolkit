
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonUACButtonVersion21 = new Krypton.Toolkit.Suite.Extended.Buttons.KryptonUACButtonVersion2();
            this.kuacbtnV1 = new Krypton.Toolkit.Suite.Extended.Buttons.KryptonUACButtonVersion1();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kryptonUACButtonVersion21
            // 
            this.kryptonUACButtonVersion21.CustomShieldSize = new System.Drawing.Size(48, 48);
            this.kryptonUACButtonVersion21.ExtraArguments = null;
            this.kryptonUACButtonVersion21.Location = new System.Drawing.Point(393, 210);
            this.kryptonUACButtonVersion21.Name = "kryptonUACButtonVersion21";
            this.kryptonUACButtonVersion21.PathToElevatedObject = null;
            this.kryptonUACButtonVersion21.Size = new System.Drawing.Size(322, 130);
            this.kryptonUACButtonVersion21.TabIndex = 1;
            this.kryptonUACButtonVersion21.UACShieldSize = Krypton.Toolkit.Suite.Extended.Buttons.UACShieldSize.CUSTOM;
            this.kryptonUACButtonVersion21.UseAsUACElevatedButton = true;
            this.kryptonUACButtonVersion21.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonUACButtonVersion21.Values.Image")));
            this.kryptonUACButtonVersion21.Values.Text = "kryptonUACButtonVersion21";
            // 
            // kuacbtnV1
            // 
            this.kuacbtnV1.AssemblyToElevate = null;
            this.kuacbtnV1.Location = new System.Drawing.Point(393, 129);
            this.kuacbtnV1.Name = "kuacbtnV1";
            this.kuacbtnV1.ProcessName = "C:\\Windows\\notepad.exe";
            this.kuacbtnV1.Size = new System.Drawing.Size(243, 51);
            this.kuacbtnV1.TabIndex = 0;
            this.kuacbtnV1.Values.Image = ((System.Drawing.Image)(resources.GetObject("kuacbtnV1.Values.Image")));
            this.kuacbtnV1.Values.Text = "Open &Notepad";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonUACButtonVersion21);
            this.Controls.Add(this.kuacbtnV1);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Buttons.KryptonUACButtonVersion1 kuacbtnV1;
        private Krypton.Toolkit.Suite.Extended.Buttons.KryptonUACButtonVersion2 kryptonUACButtonVersion21;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}

