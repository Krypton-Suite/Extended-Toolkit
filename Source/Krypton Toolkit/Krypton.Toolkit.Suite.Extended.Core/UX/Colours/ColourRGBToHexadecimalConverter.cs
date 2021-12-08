#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class ColourRGBToHexadecimalConverter : KryptonForm
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
            this.kryptonPanel1 = new Toolkit.KryptonPanel();
            this.kchkEnableAlphaChannel = new Toolkit.KryptonCheckBox();
            this.numAlpha = new Toolkit.KryptonNumericUpDown();
            this.klblAlpha = new Toolkit.KryptonLabel();
            this.numBlue = new Toolkit.KryptonNumericUpDown();
            this.numGreen = new Toolkit.KryptonNumericUpDown();
            this.kryptonLabel5 = new Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Toolkit.KryptonLabel();
            this.klblHexOutput = new Toolkit.KryptonLabel();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.kchkAutoUpdate = new Toolkit.KryptonCheckBox();
            this.numRed = new Toolkit.KryptonNumericUpDown();
            this.kbtnConvert = new Toolkit.KryptonButton();
            this.kryptonLabel1 = new Toolkit.KryptonLabel();
            this.kryptonManager1 = new Toolkit.KryptonManager(this.components);
            this.kPal = new Toolkit.KryptonPalette(this.components);
            this.tmrUpdateValues = new System.Windows.Forms.Timer(this.components);
            this.ttInformation = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kchkEnableAlphaChannel);
            this.kryptonPanel1.Controls.Add(this.numAlpha);
            this.kryptonPanel1.Controls.Add(this.klblAlpha);
            this.kryptonPanel1.Controls.Add(this.numBlue);
            this.kryptonPanel1.Controls.Add(this.numGreen);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.klblHexOutput);
            this.kryptonPanel1.Controls.Add(this.pnlPreview);
            this.kryptonPanel1.Controls.Add(this.kchkAutoUpdate);
            this.kryptonPanel1.Controls.Add(this.numRed);
            this.kryptonPanel1.Controls.Add(this.kbtnConvert);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(803, 202);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kchkEnableAlphaChannel
            // 
            this.kchkEnableAlphaChannel.Location = new System.Drawing.Point(477, 144);
            this.kchkEnableAlphaChannel.Name = "kchkEnableAlphaChannel";
            this.kchkEnableAlphaChannel.Size = new System.Drawing.Size(183, 26);
            this.kchkEnableAlphaChannel.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkEnableAlphaChannel.TabIndex = 6;
            this.kchkEnableAlphaChannel.Values.Text = "&Enable Alpha Channel";
            this.kchkEnableAlphaChannel.CheckedChanged += new System.EventHandler(this.kchkEnableAlphaChannel_CheckedChanged);
            // 
            // numAlpha
            // 
            this.numAlpha.DecimalPlaces = 1;
            this.numAlpha.Enabled = false;
            this.numAlpha.Location = new System.Drawing.Point(605, 35);
            this.numAlpha.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numAlpha.Name = "numAlpha";
            this.numAlpha.Size = new System.Drawing.Size(80, 28);
            this.numAlpha.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAlpha.TabIndex = 3;
            this.numAlpha.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // klblAlpha
            // 
            this.klblAlpha.Enabled = false;
            this.klblAlpha.Location = new System.Drawing.Point(537, 37);
            this.klblAlpha.Name = "klblAlpha";
            this.klblAlpha.Size = new System.Drawing.Size(62, 26);
            this.klblAlpha.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.TabIndex = 11;
            this.klblAlpha.Values.Text = "Alpha:";
            // 
            // numBlue
            // 
            this.numBlue.Location = new System.Drawing.Point(433, 35);
            this.numBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBlue.Name = "numBlue";
            this.numBlue.Size = new System.Drawing.Size(80, 28);
            this.numBlue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBlue.TabIndex = 2;
            // 
            // numGreen
            // 
            this.numGreen.Location = new System.Drawing.Point(268, 35);
            this.numGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numGreen.Name = "numGreen";
            this.numGreen.Size = new System.Drawing.Size(80, 28);
            this.numGreen.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGreen.TabIndex = 1;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(200, 37);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "Green:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(377, 37);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(50, 26);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 7;
            this.kryptonLabel4.Values.Text = "Blue:";
            // 
            // klblHexOutput
            // 
            this.klblHexOutput.Location = new System.Drawing.Point(43, 92);
            this.klblHexOutput.Name = "klblHexOutput";
            this.klblHexOutput.Size = new System.Drawing.Size(139, 37);
            this.klblHexOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.klblHexOutput.TabIndex = 5;
            this.klblHexOutput.Values.Text = "Hex Value:";
            // 
            // pnlPreview
            // 
            this.pnlPreview.BackColor = System.Drawing.Color.Transparent;
            this.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPreview.Location = new System.Drawing.Point(691, 35);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(101, 89);
            this.pnlPreview.TabIndex = 7;
            this.pnlPreview.MouseEnter += new System.EventHandler(this.pnlPreview_MouseEnter);
            // 
            // kchkAutoUpdate
            // 
            this.kchkAutoUpdate.Checked = true;
            this.kchkAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kchkAutoUpdate.Location = new System.Drawing.Point(237, 144);
            this.kchkAutoUpdate.Name = "kchkAutoUpdate";
            this.kchkAutoUpdate.Size = new System.Drawing.Size(234, 26);
            this.kchkAutoUpdate.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkAutoUpdate.TabIndex = 4;
            this.kchkAutoUpdate.Values.Text = "Automatically Update &Values";
            this.kchkAutoUpdate.CheckedChanged += new System.EventHandler(this.kchkAutoUpdate_CheckedChanged);
            // 
            // numRed
            // 
            this.numRed.Location = new System.Drawing.Point(95, 35);
            this.numRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numRed.Name = "numRed";
            this.numRed.Size = new System.Drawing.Size(80, 28);
            this.numRed.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRed.TabIndex = 0;
            // 
            // kbtnConvert
            // 
            this.kbtnConvert.Location = new System.Drawing.Point(43, 144);
            this.kbtnConvert.Name = "kbtnConvert";
            this.kbtnConvert.Size = new System.Drawing.Size(188, 25);
            this.kbtnConvert.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnConvert.TabIndex = 5;
            this.kbtnConvert.Values.Text = "&Convert RGB To Hex";
            this.kbtnConvert.Click += new System.EventHandler(this.kbtnConvert_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(43, 37);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(46, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Red:";
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPalette = this.kPal;
            this.kryptonManager1.GlobalPaletteMode = Toolkit.PaletteModeManager.Custom;
            // 
            // tmrUpdateValues
            // 
            this.tmrUpdateValues.Interval = 150;
            this.tmrUpdateValues.Tick += new System.EventHandler(this.tmrUpdateValues_Tick);
            // 
            // ColourRGBToHexadecimalConverter
            // 
            this.AcceptButton = this.kbtnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 202);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourRGBToHexadecimalConverter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RGB to Hexadecimal Converter";
            this.Load += new System.EventHandler(this.ColourRGBToHexadecimalConverter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Toolkit.KryptonPanel kryptonPanel1;
        private Toolkit.KryptonLabel kryptonLabel1;
        private Toolkit.KryptonNumericUpDown numBlue;
        private Toolkit.KryptonNumericUpDown numGreen;
        private Toolkit.KryptonLabel kryptonLabel5;
        private Toolkit.KryptonLabel kryptonLabel4;
        private Toolkit.KryptonLabel klblHexOutput;
        private System.Windows.Forms.Panel pnlPreview;
        private Toolkit.KryptonCheckBox kchkAutoUpdate;
        private Toolkit.KryptonNumericUpDown numRed;
        private Toolkit.KryptonButton kbtnConvert;
        private Toolkit.KryptonManager kryptonManager1;
        private Toolkit.KryptonPalette kPal;
        private System.Windows.Forms.Timer tmrUpdateValues;
        private Toolkit.KryptonNumericUpDown numAlpha;
        private Toolkit.KryptonLabel klblAlpha;
        private Toolkit.KryptonCheckBox kchkEnableAlphaChannel;
        private System.Windows.Forms.ToolTip ttInformation;
        #endregion

        #region Variables
        ConversionMethods conversionMethods = new ConversionMethods();

        private bool _enableAlphaChannel = false;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether [enable alpha channel].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable alpha channel]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableAlphaChannel { get { return _enableAlphaChannel; } set { _enableAlphaChannel = value; } }
        #endregion

        #region Setters & Getters        
        /// <summary>
        /// Sets the enable alpha channel.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void SetEnableAlphaChannel(bool value)
        {
            EnableAlphaChannel = value;
        }

        /// <summary>
        /// Gets the enable alpha channel.
        /// </summary>
        /// <returns></returns>
        public bool GetEnableAlphaChannel()
        {
            return EnableAlphaChannel;
        }
        #endregion

        public ColourRGBToHexadecimalConverter()
        {
            InitializeComponent();
        }

        private void kbtnConvert_Click(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void kchkAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            tmrUpdateValues.Enabled = kchkAutoUpdate.Checked;
        }

        private void tmrUpdateValues_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            klblHexOutput.Text = $"Hex Value: #{ conversionMethods.ConvertRGBToHexadecimal(conversionMethods.ConvertDecimalToInteger(numRed.Value), conversionMethods.ConvertDecimalToInteger(numGreen.Value), conversionMethods.ConvertDecimalToInteger(numBlue.Value)).ToUpper() }";

            pnlPreview.BackColor = Color.FromArgb(conversionMethods.ConvertDecimalToInteger(numRed.Value), conversionMethods.ConvertDecimalToInteger(numGreen.Value), conversionMethods.ConvertDecimalToInteger(numBlue.Value));

            klblAlpha.Enabled = GetEnableAlphaChannel();

            numAlpha.Enabled = GetEnableAlphaChannel();
        }

        private void pnlPreview_MouseEnter(object sender, EventArgs e)
        {
            string knownName = pnlPreview.BackColor.ToKnownColor().ToString();

            ttInformation.SetToolTip(pnlPreview, $"This colour is: { knownName }");
        }

        private void kchkEnableAlphaChannel_CheckedChanged(object sender, EventArgs e)
        {
            SetEnableAlphaChannel(kchkEnableAlphaChannel.Checked);
        }

        private void ColourRGBToHexadecimalConverter_Load(object sender, EventArgs e)
        {
            tmrUpdateValues.Enabled = kchkAutoUpdate.Checked;
        }
    }
}