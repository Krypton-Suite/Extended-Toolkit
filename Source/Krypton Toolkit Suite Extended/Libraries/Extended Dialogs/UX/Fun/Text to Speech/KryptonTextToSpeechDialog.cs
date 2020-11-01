using Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis;
using System;
using System.Globalization;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonTextToSpeechDialog : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonGroupBox kryptonGroupBox3;
        private KryptonGroupBox kgrpAdjustments;
        private KryptonLabel klblVolume;
        private KryptonLabel klblRate;
        private KryptonTrackBar ktrkVolume;
        private KryptonTrackBar ktrkRate;
        private KryptonLabel kryptonLabel5;
        private KryptonLabel kryptonLabel2;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonButton kbtnSpeak;
        private KryptonLabel kryptonLabel1;
        private KryptonRichTextBox krtbInput;
        private KryptonButton kbtnPreview;
        private KryptonComboBox kcmbInstalledVoices;
        private KryptonButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox3 = new Krypton.Toolkit.KryptonGroupBox();
            this.kbtnPreview = new Krypton.Toolkit.KryptonButton();
            this.kcmbInstalledVoices = new Krypton.Toolkit.KryptonComboBox();
            this.kgrpAdjustments = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.klblVolume = new Krypton.Toolkit.KryptonLabel();
            this.klblRate = new Krypton.Toolkit.KryptonLabel();
            this.ktrkVolume = new Krypton.Toolkit.KryptonTrackBar();
            this.ktrkRate = new Krypton.Toolkit.KryptonTrackBar();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kbtnSpeak = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.krtbInput = new Krypton.Toolkit.KryptonRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbInstalledVoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgrpAdjustments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgrpAdjustments.Panel)).BeginInit();
            this.kgrpAdjustments.Panel.SuspendLayout();
            this.kgrpAdjustments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 544);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(513, 50);
            this.kryptonPanel1.TabIndex = 3;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(211, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 542);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 2);
            this.panel1.TabIndex = 4;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox3);
            this.kryptonPanel2.Controls.Add(this.kgrpAdjustments);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(513, 542);
            this.kryptonPanel2.TabIndex = 5;
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.Location = new System.Drawing.Point(12, 455);
            this.kryptonGroupBox3.Name = "kryptonGroupBox3";
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.kbtnPreview);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcmbInstalledVoices);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(489, 81);
            this.kryptonGroupBox3.TabIndex = 6;
            this.kryptonGroupBox3.Values.Heading = "Installed Voices";
            // 
            // kbtnPreview
            // 
            this.kbtnPreview.Enabled = false;
            this.kbtnPreview.Location = new System.Drawing.Point(380, 14);
            this.kbtnPreview.Name = "kbtnPreview";
            this.kbtnPreview.Size = new System.Drawing.Size(90, 25);
            this.kbtnPreview.TabIndex = 6;
            this.kbtnPreview.Values.Text = "&Preview";
            this.kbtnPreview.Click += new System.EventHandler(this.kbtnPreview_Click);
            // 
            // kcmbInstalledVoices
            // 
            this.kcmbInstalledVoices.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbInstalledVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbInstalledVoices.DropDownWidth = 360;
            this.kcmbInstalledVoices.IntegralHeight = false;
            this.kcmbInstalledVoices.Location = new System.Drawing.Point(14, 16);
            this.kcmbInstalledVoices.Name = "kcmbInstalledVoices";
            this.kcmbInstalledVoices.Size = new System.Drawing.Size(360, 21);
            this.kcmbInstalledVoices.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbInstalledVoices.TabIndex = 13;
            this.kcmbInstalledVoices.SelectedIndexChanged += new System.EventHandler(this.kcmbInstalledVoices_SelectedIndexChanged);
            this.kcmbInstalledVoices.TextChanged += new System.EventHandler(this.kcmbInstalledVoices_TextChanged);
            // 
            // kgrpAdjustments
            // 
            this.kgrpAdjustments.Location = new System.Drawing.Point(12, 258);
            this.kgrpAdjustments.Name = "kgrpAdjustments";
            // 
            // kgrpAdjustments.Panel
            // 
            this.kgrpAdjustments.Panel.Controls.Add(this.kryptonLabel5);
            this.kgrpAdjustments.Panel.Controls.Add(this.klblVolume);
            this.kgrpAdjustments.Panel.Controls.Add(this.klblRate);
            this.kgrpAdjustments.Panel.Controls.Add(this.ktrkVolume);
            this.kgrpAdjustments.Panel.Controls.Add(this.ktrkRate);
            this.kgrpAdjustments.Panel.Controls.Add(this.kryptonLabel2);
            this.kgrpAdjustments.Size = new System.Drawing.Size(489, 191);
            this.kgrpAdjustments.TabIndex = 6;
            this.kgrpAdjustments.Values.Heading = "Adjustments";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(14, 82);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel5.TabIndex = 11;
            this.kryptonLabel5.Values.Text = "Volume";
            // 
            // klblVolume
            // 
            this.klblVolume.AutoSize = false;
            this.klblVolume.Location = new System.Drawing.Point(14, 141);
            this.klblVolume.Name = "klblVolume";
            this.klblVolume.Size = new System.Drawing.Size(456, 20);
            this.klblVolume.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblVolume.TabIndex = 12;
            this.klblVolume.Values.Text = "{0}";
            // 
            // klblRate
            // 
            this.klblRate.AutoSize = false;
            this.klblRate.Location = new System.Drawing.Point(14, 71);
            this.klblRate.Name = "klblRate";
            this.klblRate.Size = new System.Drawing.Size(456, 20);
            this.klblRate.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblRate.TabIndex = 9;
            this.klblRate.Values.Text = "{0}";
            // 
            // ktrkVolume
            // 
            this.ktrkVolume.DrawBackground = true;
            this.ktrkVolume.Location = new System.Drawing.Point(14, 108);
            this.ktrkVolume.Maximum = 100;
            this.ktrkVolume.Name = "ktrkVolume";
            this.ktrkVolume.Size = new System.Drawing.Size(456, 27);
            this.ktrkVolume.TabIndex = 10;
            this.ktrkVolume.Value = 50;
            this.ktrkVolume.ValueChanged += new System.EventHandler(this.ktrkVolume_ValueChanged);
            // 
            // ktrkRate
            // 
            this.ktrkRate.DrawBackground = true;
            this.ktrkRate.Location = new System.Drawing.Point(14, 38);
            this.ktrkRate.Maximum = 100;
            this.ktrkRate.Name = "ktrkRate";
            this.ktrkRate.Size = new System.Drawing.Size(456, 27);
            this.ktrkRate.TabIndex = 6;
            this.ktrkRate.Value = 50;
            this.ktrkRate.ValueChanged += new System.EventHandler(this.ktrkRate_ValueChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(14, 12);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(35, 20);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "Rate";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnSpeak);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.krtbInput);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(489, 240);
            this.kryptonGroupBox1.TabIndex = 6;
            this.kryptonGroupBox1.Values.Heading = "Input";
            // 
            // kbtnSpeak
            // 
            this.kbtnSpeak.Enabled = false;
            this.kbtnSpeak.Location = new System.Drawing.Point(197, 187);
            this.kbtnSpeak.Name = "kbtnSpeak";
            this.kbtnSpeak.Size = new System.Drawing.Size(90, 25);
            this.kbtnSpeak.TabIndex = 6;
            this.kbtnSpeak.Values.Text = "&Speak";
            this.kbtnSpeak.Click += new System.EventHandler(this.kbtnSpeak_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 161);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(408, 20);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Please enter some text in the field above, then click \'speak\' to listen back.";
            // 
            // krtbInput
            // 
            this.krtbInput.Location = new System.Drawing.Point(3, 3);
            this.krtbInput.Name = "krtbInput";
            this.krtbInput.Size = new System.Drawing.Size(479, 152);
            this.krtbInput.TabIndex = 0;
            this.krtbInput.Text = "";
            this.krtbInput.TextChanged += new System.EventHandler(this.krtbInput_TextChanged);
            // 
            // KryptonTextToSpeechDialog
            // 
            this.ClientSize = new System.Drawing.Size(513, 594);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).EndInit();
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbInstalledVoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgrpAdjustments.Panel)).EndInit();
            this.kgrpAdjustments.Panel.ResumeLayout(false);
            this.kgrpAdjustments.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgrpAdjustments)).EndInit();
            this.kgrpAdjustments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
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

        private void kbtnSpeak_Click(object sender, EventArgs e)
        {
            Speak(krtbInput.Text, kcmbInstalledVoices.Text, _speechRate, _speechVolume);
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void ktrkRate_ValueChanged(object sender, EventArgs e)
        {
            _speechRate = ktrkRate.Value;

            klblRate.Text = _speechRate.ToString(CultureInfo.InvariantCulture);
        }

        private void ktrkVolume_ValueChanged(object sender, EventArgs e)
        {
            _speechVolume = ktrkVolume.Value;

            klblVolume.Text = _speechVolume.ToString(CultureInfo.InvariantCulture);
        }

        private void kbtnPreview_Click(object sender, EventArgs e)
        {
            Speak($"Hello World! This is { kcmbInstalledVoices.Text } speaking. Testing 1... 2... 3 ...", kcmbInstalledVoices.Text, _speechRate, _speechVolume);
        }

        private void kcmbInstalledVoices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kcmbInstalledVoices_TextChanged(object sender, EventArgs e)
        {

        }

        private void krtbInput_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(krtbInput.Text))
            {
                krtbInput.Enabled = true;
            }
            else
            {
                krtbInput.Enabled = false;
            }
        }

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
            using (SpeechSynthesizer synth = new SpeechSynthesizer { Volume = volume, Rate = rate })
            {
                synth.SelectVoice(voice);

                kgrpAdjustments.Enabled = false;

                synth.Speak(textToSpeak);

                kgrpAdjustments.Enabled = true;
            }

            //#if NETCOREAPP
            //            SpeakNETCore(textToSpeak);
            //#endif
        }

        /// <summary>
        /// https://www.c-sharpcorner.com/blogs/using-systemspeech-with-net-core-30
        /// </summary>
        /// <param name="textToSpeech"></param>
        /// <param name="wait"></param>
        private static void SpeakNETCore(string textToSpeech, bool wait = false)
        {
            // Command to execute PS  
            Execute($@"Add-Type -AssemblyName System.speech;  
            $speak = New-Object System.Speech.Synthesis.SpeechSynthesizer;                           
            $speak.Speak(""{textToSpeech}"");"); // Embedd text  

            void Execute(string command)
            {
                // create a temp file with .ps1 extension  
                var cFile = System.IO.Path.GetTempPath() + Guid.NewGuid() + ".ps1";

                //Write the .ps1  
                using var tw = new System.IO.StreamWriter(cFile, false, Encoding.UTF8);
                tw.Write(command);

                // Setup the PS  
                var start =
                    new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "C:\\windows\\system32\\windowspowershell\\v1.0\\powershell.exe",  // CHUPA MICROSOFT 02-10-2019 23:45                    
                        LoadUserProfile = false,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        Arguments = $"-executionpolicy bypass -File {cFile}",
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                    };

                //Init the Process  
                var p = System.Diagnostics.Process.Start(start);
                // The wait may not work! :(  
                if (wait) p.WaitForExit();
            }
        }

    }
}