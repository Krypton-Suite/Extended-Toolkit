using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonColourButtonCustomColourDialog : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private Suite.Extended.Base.KryptonOKDialogButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private Suite.Extended.Base.CircularPictureBox cpbSelectedColour;
        private KryptonNumericUpDown knumHue;
        private KryptonNumericUpDown knumBrightness;
        private KryptonNumericUpDown knumBlue;
        private KryptonNumericUpDown knumGreen;
        private KryptonNumericUpDown knumRed;
        private KryptonLabel kryptonLabel4;
        private KryptonLabel kryptonLabel3;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private KryptonLabel klblHexValue;
        private KryptonLabel kryptonLabel5;
        private KryptonNumericUpDown knumSaturation;
        private KryptonLabel kryptonLabel6;
        private KryptonNumericUpDown knumAlpha;
        private ColourWheelControl cwColours;
        private KryptonButton kbtnSavePalette;
        private KryptonLabel kryptonLabel7;
        private Cyotek.Windows.Forms.ColorGrid cgColours;
        private KryptonButton kryptonButton1;
        private KryptonTextBox ktxtHexValue;
        private ColourEditorManager cem;
        private Suite.Extended.Base.KryptonCancelDialogButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.Suite.Extended.Base.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Suite.Extended.Base.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.knumBlue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumGreen = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumRed = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumBrightness = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumHue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.klblHexValue = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.knumSaturation = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.knumAlpha = new Krypton.Toolkit.KryptonNumericUpDown();
            this.cwColours = new Krypton.Toolkit.Extended.Colour.Controls.ColourWheelControl();
            this.cgColours = new Cyotek.Windows.Forms.ColorGrid();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnSavePalette = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.cpbSelectedColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.ktxtHexValue = new Krypton.Toolkit.KryptonTextBox();
            this.cem = new Krypton.Toolkit.Extended.Colour.Controls.ColourEditorManager();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSelectedColour)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 418);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(595, 43);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(397, 6);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 3;
            this.kbtnOk.Values.Text = "&OK";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(493, 6);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 3;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 416);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 2);
            this.panel1.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtHexValue);
            this.kryptonPanel2.Controls.Add(this.kryptonButton1);
            this.kryptonPanel2.Controls.Add(this.kbtnSavePalette);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel7);
            this.kryptonPanel2.Controls.Add(this.cgColours);
            this.kryptonPanel2.Controls.Add(this.cwColours);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel2.Controls.Add(this.knumAlpha);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.knumSaturation);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.klblHexValue);
            this.kryptonPanel2.Controls.Add(this.knumHue);
            this.kryptonPanel2.Controls.Add(this.knumBrightness);
            this.kryptonPanel2.Controls.Add(this.knumBlue);
            this.kryptonPanel2.Controls.Add(this.knumGreen);
            this.kryptonPanel2.Controls.Add(this.knumRed);
            this.kryptonPanel2.Controls.Add(this.cpbSelectedColour);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(595, 416);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // knumBlue
            // 
            this.knumBlue.Location = new System.Drawing.Point(330, 76);
            this.knumBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBlue.Name = "knumBlue";
            this.knumBlue.Size = new System.Drawing.Size(91, 25);
            this.knumBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBlue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumBlue.TabIndex = 12;
            // 
            // knumGreen
            // 
            this.knumGreen.Location = new System.Drawing.Point(330, 45);
            this.knumGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumGreen.Name = "knumGreen";
            this.knumGreen.Size = new System.Drawing.Size(91, 25);
            this.knumGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knumGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumGreen.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumGreen.TabIndex = 11;
            // 
            // knumRed
            // 
            this.knumRed.Location = new System.Drawing.Point(330, 12);
            this.knumRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumRed.Name = "knumRed";
            this.knumRed.Size = new System.Drawing.Size(91, 25);
            this.knumRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumRed.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumRed.TabIndex = 10;
            // 
            // knumBrightness
            // 
            this.knumBrightness.Location = new System.Drawing.Point(116, 12);
            this.knumBrightness.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBrightness.Name = "knumBrightness";
            this.knumBrightness.Size = new System.Drawing.Size(91, 25);
            this.knumBrightness.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumBrightness.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumBrightness.TabIndex = 13;
            // 
            // knumHue
            // 
            this.knumHue.Location = new System.Drawing.Point(116, 43);
            this.knumHue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumHue.Name = "knumHue";
            this.knumHue.Size = new System.Drawing.Size(91, 25);
            this.knumHue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumHue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumHue.TabIndex = 14;
            // 
            // klblHexValue
            // 
            this.klblHexValue.Location = new System.Drawing.Point(12, 12);
            this.klblHexValue.Name = "klblHexValue";
            this.klblHexValue.Size = new System.Drawing.Size(98, 23);
            this.klblHexValue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHexValue.TabIndex = 15;
            this.klblHexValue.Values.Text = "Brightness:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 45);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(48, 23);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 16;
            this.kryptonLabel1.Values.Text = "Hue:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(226, 12);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(48, 23);
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel2.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 17;
            this.kryptonLabel2.Values.Text = "Red:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(226, 45);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(64, 23);
            this.kryptonLabel3.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kryptonLabel3.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 18;
            this.kryptonLabel3.Values.Text = "Green:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(226, 76);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(51, 23);
            this.kryptonLabel4.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonLabel4.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 19;
            this.kryptonLabel4.Values.Text = "Blue:";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(12, 76);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(95, 23);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 21;
            this.kryptonLabel5.Values.Text = "Saturation:";
            // 
            // knumSaturation
            // 
            this.knumSaturation.Location = new System.Drawing.Point(116, 74);
            this.knumSaturation.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumSaturation.Name = "knumSaturation";
            this.knumSaturation.Size = new System.Drawing.Size(91, 25);
            this.knumSaturation.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumSaturation.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumSaturation.TabIndex = 20;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(12, 107);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(61, 23);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 23;
            this.kryptonLabel6.Values.Text = "Alpha:";
            // 
            // knumAlpha
            // 
            this.knumAlpha.Location = new System.Drawing.Point(116, 105);
            this.knumAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumAlpha.Name = "knumAlpha";
            this.knumAlpha.Size = new System.Drawing.Size(91, 25);
            this.knumAlpha.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumAlpha.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumAlpha.TabIndex = 22;
            // 
            // cwColours
            // 
            this.cwColours.BackColor = System.Drawing.Color.Transparent;
            this.cwColours.Location = new System.Drawing.Point(418, 179);
            this.cwColours.Name = "cwColours";
            this.cwColours.Size = new System.Drawing.Size(165, 165);
            this.cwColours.TabIndex = 24;
            // 
            // cgColours
            // 
            this.cgColours.BackColor = System.Drawing.Color.Transparent;
            this.cgColours.Location = new System.Drawing.Point(12, 179);
            this.cgColours.Name = "cgColours";
            this.cgColours.Size = new System.Drawing.Size(247, 165);
            this.cgColours.TabIndex = 25;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(226, 107);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(95, 23);
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.TabIndex = 26;
            this.kryptonLabel7.Values.Text = "Hex Value:";
            // 
            // kbtnSavePalette
            // 
            this.kbtnSavePalette.AutoSize = true;
            this.kbtnSavePalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSavePalette.Location = new System.Drawing.Point(12, 148);
            this.kbtnSavePalette.Name = "kbtnSavePalette";
            this.kbtnSavePalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnSavePalette.TabIndex = 27;
            this.kbtnSavePalette.Values.Image = global::Krypton.Toolkit.Extended.Colour.Controls.Properties.Resources.palette_save;
            this.kbtnSavePalette.Values.Text = "";
            this.kbtnSavePalette.Click += new System.EventHandler(this.kbtnSavePalette_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.AutoSize = true;
            this.kryptonButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton1.Location = new System.Drawing.Point(40, 148);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(22, 22);
            this.kryptonButton1.TabIndex = 28;
            this.kryptonButton1.Values.Image = global::Krypton.Toolkit.Extended.Colour.Controls.Properties.Resources.palette_load;
            this.kryptonButton1.Values.Text = "";
            // 
            // cpbSelectedColour
            // 
            this.cpbSelectedColour.BackColor = System.Drawing.SystemColors.Control;
            this.cpbSelectedColour.Location = new System.Drawing.Point(511, 12);
            this.cpbSelectedColour.Name = "cpbSelectedColour";
            this.cpbSelectedColour.Size = new System.Drawing.Size(72, 72);
            this.cpbSelectedColour.TabIndex = 4;
            this.cpbSelectedColour.TabStop = false;
            this.cpbSelectedColour.ToolTipValues = null;
            // 
            // ktxtHexValue
            // 
            this.ktxtHexValue.Hint = "#000000";
            this.ktxtHexValue.Location = new System.Drawing.Point(330, 107);
            this.ktxtHexValue.MaxLength = 7;
            this.ktxtHexValue.Name = "ktxtHexValue";
            this.ktxtHexValue.Size = new System.Drawing.Size(100, 26);
            this.ktxtHexValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtHexValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.ktxtHexValue.TabIndex = 29;
            this.ktxtHexValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cem
            // 
            this.cem.Color = System.Drawing.Color.Empty;
            this.cem.ColourGrid = this.cgColours;
            this.cem.ColourWheel = this.cwColours;
            // 
            // KryptonColourButtonCustomColourDialog
            // 
            this.ClientSize = new System.Drawing.Size(595, 461);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonColourButtonCustomColourDialog";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSelectedColour)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _colour, _hsbValue;

        private Timer _tmrARGB, _tmrHSB, _tmrFillColourValues;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set => _colour = value; }

        public Color HSBValue { get => _hsbValue; set => _hsbValue = value; }
        #endregion

        #region Constructors
        public KryptonColourButtonCustomColourDialog()
        {
            InitializeComponent();

            cwColours.Colour = Color.White;

            _tmrFillColourValues = new Timer();

            _tmrFillColourValues.Enabled = true;

            _tmrFillColourValues.Interval = 250;

            _tmrFillColourValues.Tick += FillColourValues_Tick;
        }

        public KryptonColourButtonCustomColourDialog(Color colour)
        {
            InitializeComponent();

            cwColours.Colour = colour;

            _tmrFillColourValues = new Timer();

            _tmrFillColourValues.Enabled = true;

            _tmrFillColourValues.Interval = 250;

            _tmrFillColourValues.Tick += FillColourValues_Tick;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Populates the R, G and B boxes.
        /// </summary>
        private void FillRGB()
        {
            if (Colour != Color.Empty)
            {
                knumRed.Value = Colour.R;

                knumGreen.Value = Colour.G;

                knumBlue.Value = Colour.B;
            }
        }

        /// <summary>
        /// Fills the HSB.
        /// </summary>
        /// <param name="hSBValue">The HSB value.</param>
        private void FillHSB(Color hSBValue)
        {
            knumAlpha.Value = hSBValue.A;

            knumHue.Value = (decimal)hSBValue.GetHue();

            knumSaturation.Value = (decimal)hSBValue.GetSaturation();

            knumBrightness.Value = (decimal)hSBValue.GetBrightness();
        }

        /// <summary>
        /// Creates the HSB colour.
        /// </summary>
        /// <param name="hue">The hue.</param>
        /// <param name="saturation">The saturation.</param>
        /// <param name="brightness">The brightness.</param>
        /// <returns></returns>
        private Color CreateHSBColour(decimal hue, decimal saturation, decimal brightness)
        {
            int alpha = Convert.ToInt32(knumAlpha.Value);

            float h = Convert.ToSingle(hue), s = Convert.ToSingle(saturation), b = Convert.ToSingle(brightness);

            return ColourExtensions.FromAHSB(alpha, h, s, b);
        }

        private void UpdateColourValues()
        {
            FillHSB(HSBValue);

            FillRGB();
        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the Colour.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetColour(Color value) => Colour = value;

        /// <summary>
        /// Gets the Colour.
        /// </summary>
        /// <returns>The value of Colour.</returns>
        public Color GetColour() => Colour;

        /// <summary>
        /// Sets the HSBValue.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetHSBValue(Color value) => HSBValue = value;

        /// <summary>
        /// Gets the HSBValue.
        /// </summary>
        /// <returns>The value of HSBValue.</returns>
        public Color GetHSBValue() => HSBValue;
        #endregion

        private void kbtnSavePalette_Click(object sender, EventArgs e)
        {

        }

        private void FillColourValues_Tick(object sender, EventArgs e)
        {
            FillHSB(HSBValue);

            FillRGB();

            _tmrFillColourValues.Stop();
        }
    }
}