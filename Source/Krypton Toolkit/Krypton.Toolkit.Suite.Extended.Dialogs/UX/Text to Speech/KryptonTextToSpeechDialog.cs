#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

// Only used here
using SpeechSynthesizer = System.Speech.Synthesis.SpeechSynthesizer;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonTextToSpeechDialog : CommonExtendedKryptonForm
    {
        #region Design Code
        private KryptonButton kbtnSpeak;
        private KryptonButton kbtnCancel;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonGroupBox kgbAdjustments;
        private KryptonTrackBar ktrkRate;
        private KryptonLabel kryptonLabel1;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonComboBox kcmbInstalledVoices;
        private KryptonWrapLabel kwlVolume;
        private KryptonTrackBar ktrkVolume;
        private KryptonLabel kryptonLabel2;
        private KryptonWrapLabel kwlRate;
        private KryptonButton kbtnPreview;
        private KryptonGroupBox kgbInput;
        private KryptonRichTextBox krtbInput;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new();
            this.kbtnPreview = new();
            this.kbtnSpeak = new();
            this.kbtnCancel = new();
            this.kryptonBorderEdge1 = new();
            this.kryptonPanel2 = new();
            this.kgbInput = new();
            this.krtbInput = new();
            this.kgbAdjustments = new();
            this.kwlVolume = new();
            this.ktrkVolume = new();
            this.kryptonLabel2 = new();
            this.kwlRate = new();
            this.ktrkRate = new();
            this.kryptonLabel1 = new();
            this.kryptonGroupBox1 = new();
            this.kcmbInstalledVoices = new();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbInput.Panel)).BeginInit();
            this.kgbInput.Panel.SuspendLayout();
            this.kgbInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbAdjustments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbAdjustments.Panel)).BeginInit();
            this.kgbAdjustments.Panel.SuspendLayout();
            this.kgbAdjustments.SuspendLayout();
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
            this.kryptonPanel1.Location = new(0, 552);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new(458, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnPreview
            // 
            this.kbtnPreview.Location = new(12, 13);
            this.kbtnPreview.Name = "kbtnPreview";
            this.kbtnPreview.Size = new(90, 25);
            this.kbtnPreview.TabIndex = 2;
            this.kbtnPreview.Values.Text = "Pr&eview";
            this.kbtnPreview.Click += new(this.kbtnPreview_Click);
            // 
            // kbtnSpeak
            // 
            this.kbtnSpeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSpeak.Enabled = false;
            this.kbtnSpeak.Location = new(260, 13);
            this.kbtnSpeak.Name = "kbtnSpeak";
            this.kbtnSpeak.Size = new(90, 25);
            this.kbtnSpeak.TabIndex = 2;
            this.kbtnSpeak.Values.Text = "Spea&k";
            this.kbtnSpeak.Click += new(this.kbtnSpeak_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new(356, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new(this.kbtnCancel_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new(458, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kgbInput);
            this.kryptonPanel2.Controls.Add(this.kgbAdjustments);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new(458, 552);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kgbInput
            // 
            this.kgbInput.Enabled = false;
            this.kgbInput.Location = new(13, 378);
            this.kgbInput.Name = "kgbInput";
            // 
            // kgbInput.Panel
            // 
            this.kgbInput.Panel.Controls.Add(this.krtbInput);
            this.kgbInput.Size = new(433, 150);
            this.kgbInput.TabIndex = 2;
            this.kgbInput.Values.Heading = "Input";
            // 
            // krtbInput
            // 
            this.krtbInput.Location = new(12, 15);
            this.krtbInput.Name = "krtbInput";
            this.krtbInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.krtbInput.Size = new(405, 96);
            this.krtbInput.TabIndex = 0;
            this.krtbInput.Text = "";
            this.krtbInput.TextChanged += new(this.krtbInput_TextChanged);
            // 
            // kgbAdjustments
            // 
            this.kgbAdjustments.Enabled = false;
            this.kgbAdjustments.Location = new(13, 122);
            this.kgbAdjustments.Name = "kgbAdjustments";
            // 
            // kgbAdjustments.Panel
            // 
            this.kgbAdjustments.Panel.Controls.Add(this.kwlVolume);
            this.kgbAdjustments.Panel.Controls.Add(this.ktrkVolume);
            this.kgbAdjustments.Panel.Controls.Add(this.kryptonLabel2);
            this.kgbAdjustments.Panel.Controls.Add(this.kwlRate);
            this.kgbAdjustments.Panel.Controls.Add(this.ktrkRate);
            this.kgbAdjustments.Panel.Controls.Add(this.kryptonLabel1);
            this.kgbAdjustments.Size = new(433, 250);
            this.kgbAdjustments.TabIndex = 1;
            this.kgbAdjustments.Values.Heading = "Adjustments";
            // 
            // kwlVolume
            // 
            this.kwlVolume.AutoSize = false;
            this.kwlVolume.Font = new("Segoe UI", 9F);
            this.kwlVolume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlVolume.Location = new(12, 184);
            this.kwlVolume.Name = "kwlVolume";
            this.kwlVolume.Size = new(405, 23);
            this.kwlVolume.Text = "{0}";
            this.kwlVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ktrkVolume
            // 
            this.ktrkVolume.DrawBackground = true;
            this.ktrkVolume.Location = new(12, 139);
            this.ktrkVolume.Maximum = 100;
            this.ktrkVolume.Name = "ktrkVolume";
            this.ktrkVolume.Size = new(405, 33);
            this.ktrkVolume.TabIndex = 5;
            this.ktrkVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ktrkVolume.ValueChanged += new(this.ktrkVolume_ValueChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new(12, 112);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new(59, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Volume:";
            // 
            // kwlRate
            // 
            this.kwlRate.AutoSize = false;
            this.kwlRate.Font = new("Segoe UI", 9F);
            this.kwlRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlRate.Location = new(12, 86);
            this.kwlRate.Name = "kwlRate";
            this.kwlRate.Size = new(405, 23);
            this.kwlRate.Text = "{0}";
            this.kwlRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ktrkRate
            // 
            this.ktrkRate.DrawBackground = true;
            this.ktrkRate.Location = new(12, 41);
            this.ktrkRate.Maximum = 100;
            this.ktrkRate.Name = "ktrkRate";
            this.ktrkRate.Size = new(405, 33);
            this.ktrkRate.TabIndex = 1;
            this.ktrkRate.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ktrkRate.ValueChanged += new(this.ktrkRate_ValueChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new(12, 14);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new(40, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Rate:";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGroupBox1.Location = new(13, 13);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kcmbInstalledVoices);
            this.kryptonGroupBox1.Size = new(433, 102);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Installed Voices";
            // 
            // kcmbInstalledVoices
            // 
            this.kcmbInstalledVoices.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbInstalledVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbInstalledVoices.DropDownWidth = 405;
            this.kcmbInstalledVoices.IntegralHeight = false;
            this.kcmbInstalledVoices.Location = new(12, 25);
            this.kcmbInstalledVoices.Name = "kcmbInstalledVoices";
            this.kcmbInstalledVoices.Size = new(405, 21);
            this.kcmbInstalledVoices.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbInstalledVoices.TabIndex = 0;
            this.kcmbInstalledVoices.SelectedIndexChanged += new(this.kcmbInstalledVoices_SelectedIndexChanged);
            this.kcmbInstalledVoices.TextChanged += new(this.kcmbInstalledVoices_TextChanged);
            // 
            // KryptonTextToSpeechDialog
            // 
            this.ClientSize = new(458, 602);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonTextToSpeechDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Text to Speech";
            this.Load += new(this.KryptonTextToSpeechDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbInput.Panel)).EndInit();
            this.kgbInput.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbInput)).EndInit();
            this.kgbInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbAdjustments.Panel)).EndInit();
            this.kgbAdjustments.Panel.ResumeLayout(false);
            this.kgbAdjustments.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbAdjustments)).EndInit();
            this.kgbAdjustments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbInstalledVoices)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private int _speechRate = 0, _speechVolume = 50;
        #endregion

        #region Constructor
        public KryptonTextToSpeechDialog()
        {
            InitializeComponent();

            PropagateInstalledVoicesList();
        }
        #endregion

        #region Properties
        public int SpeechRate { get => _speechRate; set => _speechRate = value; }

        public int SpeechVolume { get => _speechVolume; set => _speechVolume = value; }
        #endregion

        #region Methods
        private void PropagateInstalledVoicesList()
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                foreach (var voice in synth.GetInstalledVoices())
                {
                    kcmbInstalledVoices.Items.Add(voice.VoiceInfo.Name);
                }
            }

            kcmbInstalledVoices.SelectedIndex = 0;
        }

        private void Speak(string textToSpeak, string voice, int rate, int volume)
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer() { Volume = volume, Rate = rate })
            {
                synth.SelectVoice(voice);

                kgbAdjustments.Enabled = false;

                synth.Speak(textToSpeak);

                kgbAdjustments.Enabled = true;
            }
        }
        #endregion

        #region Event Handlers
        private void kbtnPreview_Click(object sender, EventArgs e)
        {
            Speak($"Hello World! This is {kcmbInstalledVoices.Text} speaking. Testing 1... 2... 3 ...", kcmbInstalledVoices.Text, _speechRate, _speechVolume);
        }

        private void kcmbInstalledVoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(kcmbInstalledVoices.Text))
            {
                kbtnPreview.Enabled = true;
            }
            else
            {
                kbtnPreview.Enabled = false;
            }
        }

        private void ktrkRate_ValueChanged(object sender, EventArgs e)
        {
            _speechRate = ktrkRate.Value;

            kwlRate.Text = _speechRate.ToString(CultureInfo.InvariantCulture);
        }

        private void ktrkVolume_ValueChanged(object sender, EventArgs e)
        {
            _speechVolume = ktrkVolume.Value;

            kwlVolume.Text = _speechVolume.ToString(CultureInfo.InvariantCulture);
        }

        private void krtbInput_TextChanged(object sender, EventArgs e)
        {
            kbtnSpeak.Enabled = string.IsNullOrWhiteSpace(krtbInput.Text);
        }

        private void kbtnSpeak_Click(object sender, EventArgs e)
        {
            Speak(krtbInput.Text, kcmbInstalledVoices.Text, _speechRate, _speechVolume);
        }

        private void KryptonTextToSpeechDialog_Load(object sender, EventArgs e)
        {
            ktrkRate.Value = _speechRate;

            kwlRate.Text = _speechRate.ToString();

            ktrkVolume.Value = _speechVolume;

            kwlVolume.Text = _speechVolume.ToString();
        }

        private void kcmbInstalledVoices_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(kcmbInstalledVoices.Text))
            {
                kbtnPreview.Enabled = true;
            }
            else
            {
                kbtnPreview.Enabled = false;
            }
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        #endregion
    }
}