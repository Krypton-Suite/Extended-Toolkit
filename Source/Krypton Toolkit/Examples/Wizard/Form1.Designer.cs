
namespace Wizard
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
            this.kawExample = new Krypton.Toolkit.Suite.Extended.Wizard.KryptonAdvancedWizard();
            this.kryptonAdvancedWizardPage1 = new Krypton.Toolkit.Suite.Extended.Wizard.KryptonAdvancedWizardPage();
            this.kryptonAdvancedWizardPage2 = new Krypton.Toolkit.Suite.Extended.Wizard.KryptonAdvancedWizardPage();
            this.kryptonAdvancedWizardPage3 = new Krypton.Toolkit.Suite.Extended.Wizard.KryptonAdvancedWizardPage();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kradDefaultLayout = new Krypton.Toolkit.KryptonRadioButton();
            this.kradOffice97Layout = new Krypton.Toolkit.KryptonRadioButton();
            this.kchkHelpButton = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkCancelButton = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkFinishButton = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonRichTextBox1 = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.circularPictureBox1 = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            this.kawExample.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonAdvancedWizardPage1)).BeginInit();
            this.kryptonAdvancedWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonAdvancedWizardPage2)).BeginInit();
            this.kryptonAdvancedWizardPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonAdvancedWizardPage3)).BeginInit();
            this.kryptonAdvancedWizardPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kawExample
            // 
            this.kawExample.BackButtonEnabled = false;
            this.kawExample.BackButtonText = "< &Back";
            this.kawExample.ButtonLayout = Krypton.Toolkit.Suite.Extended.Wizard.ButtonLayoutKind.DEFAULT;
            this.kawExample.ButtonsVisible = true;
            this.kawExample.CancelButton = true;
            this.kawExample.CancelButtonText = "&Cancel";
            this.kawExample.Controls.Add(this.kryptonAdvancedWizardPage1);
            this.kawExample.Controls.Add(this.kryptonAdvancedWizardPage2);
            this.kawExample.Controls.Add(this.kryptonAdvancedWizardPage3);
            this.kawExample.CurrentPageIsFinishPage = false;
            this.kawExample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kawExample.FinishButton = true;
            this.kawExample.FinishButtonEnabled = true;
            this.kawExample.FinishButtonText = "Fi&nish";
            this.kawExample.HelpButton = true;
            this.kawExample.HelpButtonText = "H&elp";
            this.kawExample.Location = new System.Drawing.Point(0, 0);
            this.kawExample.Name = "kawExample";
            this.kawExample.NextButtonEnabled = true;
            this.kawExample.NextButtonText = "N&ext >";
            this.kawExample.ProcessKeys = false;
            this.kawExample.Size = new System.Drawing.Size(630, 545);
            this.kawExample.TabIndex = 0;
            this.kawExample.TouchScreen = false;
            this.kawExample.WizardPages.Add(this.kryptonAdvancedWizardPage1);
            this.kawExample.WizardPages.Add(this.kryptonAdvancedWizardPage2);
            this.kawExample.WizardPages.Add(this.kryptonAdvancedWizardPage3);
            this.kawExample.Cancel += new System.EventHandler(this.kawExample_Cancel);
            this.kawExample.Finish += new System.EventHandler(this.kawExample_Finish);
            this.kawExample.Help += new System.EventHandler(this.kawExample_Help);
            // 
            // kryptonAdvancedWizardPage1
            // 
            this.kryptonAdvancedWizardPage1.Controls.Add(this.kchkFinishButton);
            this.kryptonAdvancedWizardPage1.Controls.Add(this.kchkCancelButton);
            this.kryptonAdvancedWizardPage1.Controls.Add(this.kchkHelpButton);
            this.kryptonAdvancedWizardPage1.Controls.Add(this.kradOffice97Layout);
            this.kryptonAdvancedWizardPage1.Controls.Add(this.kradDefaultLayout);
            this.kryptonAdvancedWizardPage1.Controls.Add(this.kryptonLabel1);
            this.kryptonAdvancedWizardPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonAdvancedWizardPage1.Header = true;
            this.kryptonAdvancedWizardPage1.HeaderBackgroundColor = System.Drawing.Color.Transparent;
            this.kryptonAdvancedWizardPage1.HeaderColourOne = System.Drawing.Color.White;
            this.kryptonAdvancedWizardPage1.HeaderColourTwo = System.Drawing.Color.White;
            this.kryptonAdvancedWizardPage1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonAdvancedWizardPage1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("kryptonAdvancedWizardPage1.HeaderImage")));
            this.kryptonAdvancedWizardPage1.HeaderImageVisible = true;
            this.kryptonAdvancedWizardPage1.HeaderTitle = "Welcome to the Krypton Wizard";
            this.kryptonAdvancedWizardPage1.Location = new System.Drawing.Point(0, 0);
            this.kryptonAdvancedWizardPage1.Name = "kryptonAdvancedWizardPage1";
            this.kryptonAdvancedWizardPage1.PreviousPage = 0;
            this.kryptonAdvancedWizardPage1.Size = new System.Drawing.Size(630, 495);
            this.kryptonAdvancedWizardPage1.SubTitle = "An example wizard - Page 1 of 3";
            this.kryptonAdvancedWizardPage1.SubTitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonAdvancedWizardPage1.TabIndex = 1;
            // 
            // kryptonAdvancedWizardPage2
            // 
            this.kryptonAdvancedWizardPage2.Controls.Add(this.kryptonRichTextBox1);
            this.kryptonAdvancedWizardPage2.Controls.Add(this.kryptonLabel2);
            this.kryptonAdvancedWizardPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonAdvancedWizardPage2.Header = true;
            this.kryptonAdvancedWizardPage2.HeaderBackgroundColor = System.Drawing.Color.Transparent;
            this.kryptonAdvancedWizardPage2.HeaderColourOne = System.Drawing.Color.White;
            this.kryptonAdvancedWizardPage2.HeaderColourTwo = System.Drawing.Color.White;
            this.kryptonAdvancedWizardPage2.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonAdvancedWizardPage2.HeaderImage = ((System.Drawing.Image)(resources.GetObject("kryptonAdvancedWizardPage2.HeaderImage")));
            this.kryptonAdvancedWizardPage2.HeaderImageVisible = true;
            this.kryptonAdvancedWizardPage2.HeaderTitle = "Welcome to the Krypton Wizard";
            this.kryptonAdvancedWizardPage2.Location = new System.Drawing.Point(0, 0);
            this.kryptonAdvancedWizardPage2.Name = "kryptonAdvancedWizardPage2";
            this.kryptonAdvancedWizardPage2.PreviousPage = 0;
            this.kryptonAdvancedWizardPage2.Size = new System.Drawing.Size(630, 495);
            this.kryptonAdvancedWizardPage2.SubTitle = "An example wizard - Page 2 of 3";
            this.kryptonAdvancedWizardPage2.SubTitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonAdvancedWizardPage2.TabIndex = 2;
            // 
            // kryptonAdvancedWizardPage3
            // 
            this.kryptonAdvancedWizardPage3.Controls.Add(this.circularPictureBox1);
            this.kryptonAdvancedWizardPage3.Controls.Add(this.kryptonLabel3);
            this.kryptonAdvancedWizardPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonAdvancedWizardPage3.Header = true;
            this.kryptonAdvancedWizardPage3.HeaderBackgroundColor = System.Drawing.Color.Transparent;
            this.kryptonAdvancedWizardPage3.HeaderColourOne = System.Drawing.Color.White;
            this.kryptonAdvancedWizardPage3.HeaderColourTwo = System.Drawing.Color.White;
            this.kryptonAdvancedWizardPage3.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonAdvancedWizardPage3.HeaderImage = ((System.Drawing.Image)(resources.GetObject("kryptonAdvancedWizardPage3.HeaderImage")));
            this.kryptonAdvancedWizardPage3.HeaderImageVisible = true;
            this.kryptonAdvancedWizardPage3.HeaderTitle = "Welcome to the Krypton Wizard";
            this.kryptonAdvancedWizardPage3.Location = new System.Drawing.Point(0, 0);
            this.kryptonAdvancedWizardPage3.Name = "kryptonAdvancedWizardPage3";
            this.kryptonAdvancedWizardPage3.PreviousPage = 1;
            this.kryptonAdvancedWizardPage3.Size = new System.Drawing.Size(630, 495);
            this.kryptonAdvancedWizardPage3.SubTitle = "An example wizard - Page 3 of 3";
            this.kryptonAdvancedWizardPage3.SubTitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonAdvancedWizardPage3.TabIndex = 3;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 91);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(126, 23);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Wizard Layout:";
            // 
            // kradDefaultLayout
            // 
            this.kradDefaultLayout.Checked = true;
            this.kradDefaultLayout.Location = new System.Drawing.Point(136, 138);
            this.kradDefaultLayout.Name = "kradDefaultLayout";
            this.kradDefaultLayout.Size = new System.Drawing.Size(123, 21);
            this.kradDefaultLayout.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kradDefaultLayout.TabIndex = 2;
            this.kradDefaultLayout.Values.Text = "&Default Layout";
            this.kradDefaultLayout.CheckedChanged += new System.EventHandler(this.kradDefaultLayout_CheckedChanged);
            // 
            // kradOffice97Layout
            // 
            this.kradOffice97Layout.Location = new System.Drawing.Point(135, 165);
            this.kradOffice97Layout.Name = "kradOffice97Layout";
            this.kradOffice97Layout.Size = new System.Drawing.Size(136, 21);
            this.kradOffice97Layout.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kradOffice97Layout.TabIndex = 3;
            this.kradOffice97Layout.Values.Text = "Office &97 Layout";
            this.kradOffice97Layout.CheckedChanged += new System.EventHandler(this.kradOffice97Layout_CheckedChanged);
            // 
            // kchkHelpButton
            // 
            this.kchkHelpButton.Checked = true;
            this.kchkHelpButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kchkHelpButton.Location = new System.Drawing.Point(193, 206);
            this.kchkHelpButton.Name = "kchkHelpButton";
            this.kchkHelpButton.Size = new System.Drawing.Size(105, 21);
            this.kchkHelpButton.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkHelpButton.TabIndex = 4;
            this.kchkHelpButton.Values.Text = "&Help Button";
            this.kchkHelpButton.CheckedChanged += new System.EventHandler(this.kchkHelpButton_CheckedChanged);
            // 
            // kchkCancelButton
            // 
            this.kchkCancelButton.Checked = true;
            this.kchkCancelButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kchkCancelButton.Location = new System.Drawing.Point(193, 233);
            this.kchkCancelButton.Name = "kchkCancelButton";
            this.kchkCancelButton.Size = new System.Drawing.Size(121, 21);
            this.kchkCancelButton.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkCancelButton.TabIndex = 5;
            this.kchkCancelButton.Values.Text = "Ca&ncel Button";
            this.kchkCancelButton.CheckedChanged += new System.EventHandler(this.kchkCancelButton_CheckedChanged);
            // 
            // kchkFinishButton
            // 
            this.kchkFinishButton.Checked = true;
            this.kchkFinishButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kchkFinishButton.Location = new System.Drawing.Point(193, 260);
            this.kchkFinishButton.Name = "kchkFinishButton";
            this.kchkFinishButton.Size = new System.Drawing.Size(115, 21);
            this.kchkFinishButton.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkFinishButton.TabIndex = 6;
            this.kchkFinishButton.Values.Text = "Fin&ish Button";
            this.kchkFinishButton.CheckedChanged += new System.EventHandler(this.kchkFinishButton_CheckedChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 91);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(164, 23);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "License Agreement:";
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(12, 120);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.ReadOnly = true;
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(606, 359);
            this.kryptonRichTextBox1.TabIndex = 3;
            this.kryptonRichTextBox1.Text = "Sample Text";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(250, 91);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(131, 23);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Task Complete!";
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.circularPictureBox1.Image = global::Wizard.Properties.Resources.Ok_128_x_128;
            this.circularPictureBox1.Location = new System.Drawing.Point(251, 183);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(128, 128);
            this.circularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.circularPictureBox1.TabIndex = 5;
            this.circularPictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 545);
            this.Controls.Add(this.kawExample);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.kawExample.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonAdvancedWizardPage1)).EndInit();
            this.kryptonAdvancedWizardPage1.ResumeLayout(false);
            this.kryptonAdvancedWizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonAdvancedWizardPage2)).EndInit();
            this.kryptonAdvancedWizardPage2.ResumeLayout(false);
            this.kryptonAdvancedWizardPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonAdvancedWizardPage3)).EndInit();
            this.kryptonAdvancedWizardPage3.ResumeLayout(false);
            this.kryptonAdvancedWizardPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Wizard.KryptonAdvancedWizard kawExample;
        private Krypton.Toolkit.Suite.Extended.Wizard.KryptonAdvancedWizardPage kryptonAdvancedWizardPage3;
        private Krypton.Toolkit.Suite.Extended.Wizard.KryptonAdvancedWizardPage kryptonAdvancedWizardPage2;
        private Krypton.Toolkit.Suite.Extended.Wizard.KryptonAdvancedWizardPage kryptonAdvancedWizardPage1;
        private Krypton.Toolkit.KryptonCheckBox kchkFinishButton;
        private Krypton.Toolkit.KryptonCheckBox kchkCancelButton;
        private Krypton.Toolkit.KryptonCheckBox kchkHelpButton;
        private Krypton.Toolkit.KryptonRadioButton kradOffice97Layout;
        private Krypton.Toolkit.KryptonRadioButton kradDefaultLayout;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox circularPictureBox1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonRichTextBox kryptonRichTextBox1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
    }
}

