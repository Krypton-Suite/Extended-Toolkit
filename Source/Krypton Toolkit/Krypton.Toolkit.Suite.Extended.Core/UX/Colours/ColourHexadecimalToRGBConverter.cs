#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class ColourHexadecimalToRGBConverter : KryptonForm
    {
        #region Designer Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtHexColourValue = new Krypton.Toolkit.KryptonTextBox();
            this.klblRGBOutput = new Krypton.Toolkit.KryptonLabel();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.kchkAutoUpdate = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnConvert = new Krypton.Toolkit.KryptonButton();
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            this.kPal = new Krypton.Toolkit.KryptonPalette(this.components);
            this.tmrUpdateValues = new System.Windows.Forms.Timer(this.components);
            this.ttInformation = new System.Windows.Forms.ToolTip(this.components);
            this.ep1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kchkAutoUpdate);
            this.kryptonPanel1.Controls.Add(this.klblRGBOutput);
            this.kryptonPanel1.Controls.Add(this.kbtnConvert);
            this.kryptonPanel1.Controls.Add(this.pnlPreview);
            this.kryptonPanel1.Controls.Add(this.ktxtHexColourValue);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(750, 202);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(43, 37);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(235, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Hexadecimal Colour Value: #";
            // 
            // ktxtHexColourValue
            // 
            this.ktxtHexColourValue.Location = new System.Drawing.Point(285, 36);
            this.ktxtHexColourValue.MaxLength = 6;
            this.ktxtHexColourValue.Name = "ktxtHexColourValue";
            this.ktxtHexColourValue.Size = new System.Drawing.Size(100, 29);
            this.ktxtHexColourValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtHexColourValue.TabIndex = 2;
            this.ktxtHexColourValue.Text = "000000";
            this.ktxtHexColourValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtHexColourValue.TextChanged += new System.EventHandler(this.ktxtHexColourValue_TextChanged);
            // 
            // klblRGBOutput
            // 
            this.klblRGBOutput.Location = new System.Drawing.Point(43, 104);
            this.klblRGBOutput.Name = "klblRGBOutput";
            this.klblRGBOutput.Size = new System.Drawing.Size(143, 37);
            this.klblRGBOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.klblRGBOutput.TabIndex = 8;
            this.klblRGBOutput.Values.Text = "RGB Value:";
            // 
            // pnlPreview
            // 
            this.pnlPreview.BackColor = System.Drawing.Color.Transparent;
            this.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPreview.Location = new System.Drawing.Point(634, 37);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(101, 89);
            this.pnlPreview.TabIndex = 9;
            this.pnlPreview.MouseEnter += new System.EventHandler(this.pnlPreview_MouseEnter);
            // 
            // kchkAutoUpdate
            // 
            this.kchkAutoUpdate.Checked = true;
            this.kchkAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kchkAutoUpdate.Location = new System.Drawing.Point(237, 157);
            this.kchkAutoUpdate.Name = "kchkAutoUpdate";
            this.kchkAutoUpdate.Size = new System.Drawing.Size(234, 26);
            this.kchkAutoUpdate.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkAutoUpdate.TabIndex = 6;
            this.kchkAutoUpdate.Values.Text = "Automatically Update &Values";
            this.kchkAutoUpdate.CheckedChanged += new System.EventHandler(this.kchkAutoUpdate_CheckedChanged);
            // 
            // kbtnConvert
            // 
            this.kbtnConvert.Location = new System.Drawing.Point(43, 157);
            this.kbtnConvert.Name = "kbtnConvert";
            this.kbtnConvert.Size = new System.Drawing.Size(188, 25);
            this.kbtnConvert.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnConvert.TabIndex = 7;
            this.kbtnConvert.Values.Text = "&Convert Hex to RGB";
            this.kbtnConvert.Click += new System.EventHandler(this.kbtnConvert_Click);
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPalette = this.kPal;
            this.kryptonManager1.GlobalPaletteMode = Krypton.Toolkit.PaletteModeManager.Custom;
            // 
            // tmrUpdateValues
            // 
            this.tmrUpdateValues.Interval = 150;
            this.tmrUpdateValues.Tick += new System.EventHandler(this.tmrUpdateValues_Tick);
            // 
            // ep1
            // 
            this.ep1.ContainerControl = this;
            // 
            // ColourHexadecimalToRGBConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 202);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourHexadecimalToRGBConverter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hexadecimal to RGB Converter";
            this.Load += new System.EventHandler(this.ColourHexadecimalToRGBConverter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTextBox ktxtHexColourValue;
        private Krypton.Toolkit.KryptonLabel klblRGBOutput;
        private System.Windows.Forms.Panel pnlPreview;
        private Krypton.Toolkit.KryptonCheckBox kchkAutoUpdate;
        private Krypton.Toolkit.KryptonButton kbtnConvert;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
        private Krypton.Toolkit.KryptonPalette kPal;
        private System.Windows.Forms.Timer tmrUpdateValues;
        private System.Windows.Forms.ToolTip ttInformation;
        private System.Windows.Forms.ErrorProvider ep1;
        #endregion

        #region Variables
        private string[] _disallowedCharacters = { "\\", "\"", "!", "`", "¬", "¦", "£", "$", "€", "%", "^", "&", "*", "(", ")", "_", "-", "+", "=",
                                           "[", "]", "{", "}", ":", ";", "@", "'", "~", "#", "|", "<", ">", ",", ".", "?", "/", "g", "h", "i",
                                           "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "G", "H",
                                           "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        private ConversionMethods _conversionMethods = new ConversionMethods();
        #endregion

        #region Properties
        public string[] DisallowedCharacters
        {
            get
            {
                return _disallowedCharacters;
            }
        }
        #endregion

        public ColourHexadecimalToRGBConverter()
        {
            InitializeComponent();
        }

        private void kbtnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rgb = ConversionMethods.ConvertHexadecimalToRGBTest(ktxtHexColourValue.Text);

                pnlPreview.BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
            }
            catch (Exception)
            {

            }

            //UpdateUI();
        }

        private void ktxtHexColourValue_TextChanged(object sender, EventArgs e)
        {
            string content = ktxtHexColourValue.Text;

            string[] contentArray = new string[6];

            //foreach (string character in content.Length)
            //{

            //}

            foreach (string disqualifiedCharacter in DisallowedCharacters)
            {
                if (content.Contains(disqualifiedCharacter))
                {
                    ep1.SetError((Control)ktxtHexColourValue, $"Cannot accept values: { DisallowedCharacters.ToString() }");
                }
            }
        }

        private void kchkAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            tmrUpdateValues.Enabled = kchkAutoUpdate.Checked;
        }

        private void tmrUpdateValues_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void pnlPreview_MouseEnter(object sender, EventArgs e)
        {

        }

        private void UpdateUI()
        {
            _conversionMethods.ConvertHexadecimalToRGB("#" + ktxtHexColourValue.Text);

            klblRGBOutput.Text = $"RGB Value: Red: { _conversionMethods.GetRed() }, Green: { _conversionMethods.GetGreen() }, Blue: { _conversionMethods.GetBlue() }";

            pnlPreview.BackColor = Color.FromArgb(_conversionMethods.GetRed(), _conversionMethods.GetGreen(), _conversionMethods.GetBlue());
        }

        private void ColourHexadecimalToRGBConverter_Load(object sender, EventArgs e)
        {
            tmrUpdateValues.Enabled = kchkAutoUpdate.Checked;
        }
    }
}