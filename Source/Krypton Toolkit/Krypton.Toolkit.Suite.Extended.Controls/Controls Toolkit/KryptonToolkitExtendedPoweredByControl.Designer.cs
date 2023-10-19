namespace Krypton.Toolkit.Suite.Extended.Controls
{
    partial class KryptonToolkitExtendedPoweredByControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kgbContent = new Krypton.Toolkit.KryptonGroupBox();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.kpbxLogo = new Krypton.Toolkit.KryptonPictureBox();
            this.klwlblDescription = new Krypton.Toolkit.KryptonLinkWrapLabel();
            this.kwlblCurrentTheme = new Krypton.Toolkit.KryptonWrapLabel();
            this.ktcmbTheme = new Krypton.Toolkit.KryptonThemeComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent.Panel)).BeginInit();
            this.kgbContent.Panel.SuspendLayout();
            this.kgbContent.SuspendLayout();
            this.tlpContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpbxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ktcmbTheme)).BeginInit();
            this.SuspendLayout();
            // 
            // kgbContent
            // 
            this.kgbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kgbContent.Location = new System.Drawing.Point(0, 0);
            this.kgbContent.Name = "kgbContent";
            // 
            // kgbContent.Panel
            // 
            this.kgbContent.Panel.Controls.Add(this.tlpContent);
            this.kgbContent.Size = new System.Drawing.Size(659, 175);
            this.kgbContent.TabIndex = 0;
            this.kgbContent.Values.Heading = "Powered by Krypton";
            // 
            // tlpContent
            // 
            this.tlpContent.BackColor = System.Drawing.Color.Transparent;
            this.tlpContent.ColumnCount = 2;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Controls.Add(this.kpbxLogo, 0, 0);
            this.tlpContent.Controls.Add(this.klwlblDescription, 1, 0);
            this.tlpContent.Controls.Add(this.kwlblCurrentTheme, 1, 1);
            this.tlpContent.Controls.Add(this.ktcmbTheme, 1, 2);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(0, 0);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 3;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContent.Size = new System.Drawing.Size(655, 151);
            this.tlpContent.TabIndex = 0;
            // 
            // kpbxLogo
            // 
            this.kpbxLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpbxLogo.Location = new System.Drawing.Point(8, 4);
            this.kpbxLogo.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.kpbxLogo.Name = "kpbxLogo";
            this.kpbxLogo.Size = new System.Drawing.Size(48, 91);
            this.kpbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.kpbxLogo.TabIndex = 0;
            this.kpbxLogo.TabStop = false;
            // 
            // klwlblDescription
            // 
            this.klwlblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klwlblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.klwlblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.klwlblDescription.LabelStyle = Krypton.Toolkit.LabelStyle.AlternateControl;
            this.klwlblDescription.LinkArea = new System.Windows.Forms.LinkArea(124, 134);
            this.klwlblDescription.Location = new System.Drawing.Point(64, 4);
            this.klwlblDescription.Margin = new System.Windows.Forms.Padding(4);
            this.klwlblDescription.Name = "klwlblDescription";
            this.klwlblDescription.Size = new System.Drawing.Size(587, 91);
            this.klwlblDescription.Text = "Some of the components used in this application are part of the Krypton Extended " +
    "Toolkit.\r\n\r\nLicense: MIT\r\n\r\nTo learn more, click here.";
            this.klwlblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.klwlblDescription.UseCompatibleTextRendering = true;
            this.klwlblDescription.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.klwlblDescription_LinkClicked);
            // 
            // kwlblCurrentTheme
            // 
            this.kwlblCurrentTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlblCurrentTheme.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.kwlblCurrentTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlblCurrentTheme.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kwlblCurrentTheme.Location = new System.Drawing.Point(64, 103);
            this.kwlblCurrentTheme.Margin = new System.Windows.Forms.Padding(4);
            this.kwlblCurrentTheme.Name = "kwlblCurrentTheme";
            this.kwlblCurrentTheme.Size = new System.Drawing.Size(587, 15);
            this.kwlblCurrentTheme.Text = "Current Theme:";
            // 
            // ktcmbTheme
            // 
            this.ktcmbTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktcmbTheme.DropDownWidth = 589;
            this.ktcmbTheme.IntegralHeight = false;
            this.ktcmbTheme.Location = new System.Drawing.Point(64, 126);
            this.ktcmbTheme.Margin = new System.Windows.Forms.Padding(4);
            this.ktcmbTheme.Name = "ktcmbTheme";
            this.ktcmbTheme.Size = new System.Drawing.Size(587, 21);
            this.ktcmbTheme.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.ktcmbTheme.TabIndex = 3;
            // 
            // KryptonToolkitExtendedPoweredByControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kgbContent);
            this.Name = "KryptonToolkitExtendedPoweredByControl";
            this.Size = new System.Drawing.Size(659, 175);
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent.Panel)).EndInit();
            this.kgbContent.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent)).EndInit();
            this.kgbContent.ResumeLayout(false);
            this.tlpContent.ResumeLayout(false);
            this.tlpContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpbxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ktcmbTheme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonGroupBox kgbContent;
        private TableLayoutPanel tlpContent;
        private KryptonPictureBox kpbxLogo;
        private KryptonLinkWrapLabel klwlblDescription;
        private KryptonWrapLabel kwlblCurrentTheme;
        private KryptonThemeComboBox ktcmbTheme;
    }
}
