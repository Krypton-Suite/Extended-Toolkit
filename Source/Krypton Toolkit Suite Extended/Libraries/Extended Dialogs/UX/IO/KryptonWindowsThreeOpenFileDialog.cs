using System;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonWindowsThreeOpenFileDialog : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnOk;
        private KryptonComboBox kryptonComboBox2;
        private KryptonComboBox kcmbFileType;
        private KryptonLabel kryptonLabel5;
        private KryptonLabel kryptonLabel4;
        private KryptonLabel kryptonLabel3;
        private KryptonLabel kryptonLabel2;
        private KryptonTextBox ktxtFileName;
        private KryptonListBox kryptonListBox2;
        private KryptonListBox kryptonListBox1;
        private KryptonLabel kryptonLabel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kryptonComboBox2 = new Krypton.Toolkit.KryptonComboBox();
            this.kcmbFileType = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtFileName = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonListBox2 = new Krypton.Toolkit.KryptonListBox();
            this.kryptonListBox1 = new Krypton.Toolkit.KryptonListBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFileType)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kryptonComboBox2);
            this.kryptonPanel1.Controls.Add(this.kcmbFileType);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.ktxtFileName);
            this.kryptonPanel1.Controls.Add(this.kryptonListBox2);
            this.kryptonPanel1.Controls.Add(this.kryptonListBox1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(449, 292);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(347, 43);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 10;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.Location = new System.Drawing.Point(347, 12);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kryptonComboBox2
            // 
            this.kryptonComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kryptonComboBox2.DropDownWidth = 162;
            this.kryptonComboBox2.IntegralHeight = false;
            this.kryptonComboBox2.Location = new System.Drawing.Point(180, 254);
            this.kryptonComboBox2.Name = "kryptonComboBox2";
            this.kryptonComboBox2.Size = new System.Drawing.Size(162, 21);
            this.kryptonComboBox2.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBox2.TabIndex = 9;
            this.kryptonComboBox2.Text = "kryptonComboBox2";
            // 
            // kcmbFileType
            // 
            this.kcmbFileType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbFileType.DropDownWidth = 162;
            this.kcmbFileType.IntegralHeight = false;
            this.kcmbFileType.Location = new System.Drawing.Point(12, 255);
            this.kcmbFileType.Name = "kcmbFileType";
            this.kcmbFileType.Size = new System.Drawing.Size(162, 21);
            this.kcmbFileType.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbFileType.TabIndex = 8;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(12, 228);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(103, 20);
            this.kryptonLabel5.TabIndex = 7;
            this.kryptonLabel5.Values.Text = "List Files of &Type:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(180, 228);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(47, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Dri&ves:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(180, 41);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(25, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "{0}";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(180, 12);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "&Directories:";
            // 
            // ktxtFileName
            // 
            this.ktxtFileName.Hint = "File name...";
            this.ktxtFileName.Location = new System.Drawing.Point(12, 38);
            this.ktxtFileName.Name = "ktxtFileName";
            this.ktxtFileName.Size = new System.Drawing.Size(162, 23);
            this.ktxtFileName.TabIndex = 3;
            // 
            // kryptonListBox2
            // 
            this.kryptonListBox2.Location = new System.Drawing.Point(180, 67);
            this.kryptonListBox2.Name = "kryptonListBox2";
            this.kryptonListBox2.Size = new System.Drawing.Size(162, 155);
            this.kryptonListBox2.TabIndex = 2;
            // 
            // kryptonListBox1
            // 
            this.kryptonListBox1.Location = new System.Drawing.Point(12, 67);
            this.kryptonListBox1.Name = "kryptonListBox1";
            this.kryptonListBox1.Size = new System.Drawing.Size(162, 155);
            this.kryptonListBox1.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(68, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "File &Name:";
            // 
            // KryptonWindowsThreeOpenFileDialog
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(449, 292);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonWindowsThreeOpenFileDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFileType)).EndInit();
            this.ResumeLayout(false);

        }

        public KryptonWindowsThreeOpenFileDialog()
        {
            InitializeComponent();
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {

        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}