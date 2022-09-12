namespace TestApp
{
    partial class WizardExample
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
            this.kryptonAdvancedWizard1 = new Krypton.Toolkit.Suite.Extended.Wizard.KryptonAdvancedWizard();
            this.SuspendLayout();
            // 
            // kryptonAdvancedWizard1
            // 
            this.kryptonAdvancedWizard1.BackButtonEnabled = true;
            this.kryptonAdvancedWizard1.BackButtonText = "< &Back";
            this.kryptonAdvancedWizard1.ButtonLayout = Krypton.Toolkit.Suite.Extended.Wizard.ButtonLayoutKind.DEFAULT;
            this.kryptonAdvancedWizard1.ButtonsVisible = true;
            this.kryptonAdvancedWizard1.CancelButton = true;
            this.kryptonAdvancedWizard1.CancelButtonText = "&Cancel";
            this.kryptonAdvancedWizard1.CurrentPageIsFinishPage = false;
            this.kryptonAdvancedWizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonAdvancedWizard1.FinishButton = true;
            this.kryptonAdvancedWizard1.FinishButtonEnabled = true;
            this.kryptonAdvancedWizard1.FinishButtonText = "Fi&nish";
            this.kryptonAdvancedWizard1.HelpButton = true;
            this.kryptonAdvancedWizard1.HelpButtonText = "H&elp";
            this.kryptonAdvancedWizard1.Location = new System.Drawing.Point(0, 0);
            this.kryptonAdvancedWizard1.Name = "kryptonAdvancedWizard1";
            this.kryptonAdvancedWizard1.NextButtonEnabled = false;
            this.kryptonAdvancedWizard1.NextButtonText = "N&ext >";
            this.kryptonAdvancedWizard1.ProcessKeys = false;
            this.kryptonAdvancedWizard1.Size = new System.Drawing.Size(783, 576);
            this.kryptonAdvancedWizard1.TabIndex = 0;
            this.kryptonAdvancedWizard1.TouchScreen = false;
            // 
            // WizardExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 576);
            this.Controls.Add(this.kryptonAdvancedWizard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardExample";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Wizard.KryptonAdvancedWizard kryptonAdvancedWizard1;
    }
}