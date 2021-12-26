
namespace DeveloperUtilities
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
            this.kbtnNotImplementedYet = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // kbtnNotImplementedYet
            // 
            this.kbtnNotImplementedYet.Location = new System.Drawing.Point(12, 12);
            this.kbtnNotImplementedYet.Name = "kbtnNotImplementedYet";
            this.kbtnNotImplementedYet.Size = new System.Drawing.Size(90, 25);
            this.kbtnNotImplementedYet.TabIndex = 0;
            this.kbtnNotImplementedYet.Values.Text = "Show Not Implemented Yet";
            this.kbtnNotImplementedYet.Click += new System.EventHandler(this.kbtnNotImplementedYet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kbtnNotImplementedYet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonButton kbtnNotImplementedYet;
    }
}

