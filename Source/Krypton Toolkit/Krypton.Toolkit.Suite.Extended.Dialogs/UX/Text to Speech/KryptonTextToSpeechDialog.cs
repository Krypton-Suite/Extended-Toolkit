namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonTextToSpeechDialog : CommonExtendedKryptonForm
    {
        private KryptonButton kbtnSpeak;
        private KryptonButton kbtnCancel;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonGroupBox kryptonGroupBox2;
        private KryptonTrackBar ktrkRate;
        private KryptonLabel kryptonLabel1;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonComboBox kcmbInstalledVoices;
        private KryptonWrapLabel kwlVolume;
        private KryptonTrackBar ktrkVolume;
        private KryptonLabel kryptonLabel2;
        private KryptonWrapLabel kwlRate;
        private KryptonButton kbtnPreview;
        private KryptonGroupBox kryptonGroupBox3;
        private KryptonRichTextBox krtbInput;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnPreview = new Krypton.Toolkit.KryptonButton();
            this.kbtnSpeak = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox3 = new Krypton.Toolkit.KryptonGroupBox();
            this.krtbInput = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.kwlVolume = new Krypton.Toolkit.KryptonWrapLabel();
            this.ktrkVolume = new Krypton.Toolkit.KryptonTrackBar();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kwlRate = new Krypton.Toolkit.KryptonWrapLabel();
            this.ktrkRate = new Krypton.Toolkit.KryptonTrackBar();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kcmbInstalledVoices = new Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbInstalledVoices)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnPreview);
            this.kryptonPanel1.Controls.Add(this.kbtnSpeak);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 552);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(458, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnPreview
            // 
            this.kbtnPreview.Enabled = false;
            this.kbtnPreview.Location = new System.Drawing.Point(12, 13);
            this.kbtnPreview.Name = "kbtnPreview";
            this.kbtnPreview.Size = new System.Drawing.Size(90, 25);
            this.kbtnPreview.TabIndex = 2;
            this.kbtnPreview.Values.Text = "Pr&eview";
            // 
            // kbtnSpeak
            // 
            this.kbtnSpeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSpeak.Enabled = false;
            this.kbtnSpeak.Location = new System.Drawing.Point(260, 13);
            this.kbtnSpeak.Name = "kbtnSpeak";
            this.kbtnSpeak.Size = new System.Drawing.Size(90, 25);
            this.kbtnSpeak.TabIndex = 2;
            this.kbtnSpeak.Values.Text = "Spea&k";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(356, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(458, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox3);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(458, 552);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.Location = new System.Drawing.Point(13, 378);
            this.kryptonGroupBox3.Name = "kryptonGroupBox3";
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.krtbInput);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(433, 150);
            this.kryptonGroupBox3.TabIndex = 2;
            this.kryptonGroupBox3.Values.Heading = "Input";
            // 
            // krtbInput
            // 
            this.krtbInput.Location = new System.Drawing.Point(12, 15);
            this.krtbInput.Name = "krtbInput";
            this.krtbInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.krtbInput.Size = new System.Drawing.Size(405, 96);
            this.krtbInput.TabIndex = 0;
            this.krtbInput.Text = "";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(13, 122);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.kwlVolume);
            this.kryptonGroupBox2.Panel.Controls.Add(this.ktrkVolume);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kwlRate);
            this.kryptonGroupBox2.Panel.Controls.Add(this.ktrkRate);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(433, 250);
            this.kryptonGroupBox2.TabIndex = 1;
            this.kryptonGroupBox2.Values.Heading = "Adjustments";
            // 
            // kwlVolume
            // 
            this.kwlVolume.AutoSize = false;
            this.kwlVolume.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlVolume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlVolume.Location = new System.Drawing.Point(12, 184);
            this.kwlVolume.Name = "kwlVolume";
            this.kwlVolume.Size = new System.Drawing.Size(405, 23);
            this.kwlVolume.Text = "{0}";
            this.kwlVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ktrkVolume
            // 
            this.ktrkVolume.DrawBackground = true;
            this.ktrkVolume.Location = new System.Drawing.Point(12, 139);
            this.ktrkVolume.Maximum = 100;
            this.ktrkVolume.Name = "ktrkVolume";
            this.ktrkVolume.Size = new System.Drawing.Size(405, 33);
            this.ktrkVolume.TabIndex = 5;
            this.ktrkVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 112);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Volume:";
            // 
            // kwlRate
            // 
            this.kwlRate.AutoSize = false;
            this.kwlRate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlRate.Location = new System.Drawing.Point(12, 86);
            this.kwlRate.Name = "kwlRate";
            this.kwlRate.Size = new System.Drawing.Size(405, 23);
            this.kwlRate.Text = "{0}";
            this.kwlRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ktrkRate
            // 
            this.ktrkRate.DrawBackground = true;
            this.ktrkRate.Location = new System.Drawing.Point(12, 41);
            this.ktrkRate.Maximum = 100;
            this.ktrkRate.Name = "ktrkRate";
            this.ktrkRate.Size = new System.Drawing.Size(405, 33);
            this.ktrkRate.TabIndex = 1;
            this.ktrkRate.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 14);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(40, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Rate:";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGroupBox1.Location = new System.Drawing.Point(13, 13);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kcmbInstalledVoices);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(433, 102);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Installed Voices";
            // 
            // kcmbInstalledVoices
            // 
            this.kcmbInstalledVoices.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbInstalledVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbInstalledVoices.DropDownWidth = 405;
            this.kcmbInstalledVoices.IntegralHeight = false;
            this.kcmbInstalledVoices.Location = new System.Drawing.Point(12, 25);
            this.kcmbInstalledVoices.Name = "kcmbInstalledVoices";
            this.kcmbInstalledVoices.Size = new System.Drawing.Size(405, 21);
            this.kcmbInstalledVoices.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbInstalledVoices.TabIndex = 0;
            // 
            // KryptonTextToSpeechDialog
            // 
            this.ClientSize = new System.Drawing.Size(458, 602);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonTextToSpeechDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Text to Speech";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).EndInit();
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbInstalledVoices)).EndInit();
            this.ResumeLayout(false);

        }
    }
}