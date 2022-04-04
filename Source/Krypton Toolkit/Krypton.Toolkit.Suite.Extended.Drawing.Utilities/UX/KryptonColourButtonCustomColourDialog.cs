#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class KryptonColourButtonCustomColourDialog : CommonExtendedKryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kryptonOKDialogButton1;
        private KryptonPanel kryptonPanel2;
        private Controls.CircularPictureBox circularPictureBox1;
        private KryptonNumericUpDown kryptonNumericUpDown6;
        private KryptonNumericUpDown kryptonNumericUpDown5;
        private KryptonNumericUpDown kryptonNumericUpDown4;
        private KryptonNumericUpDown kryptonNumericUpDown3;
        private KryptonNumericUpDown kryptonNumericUpDown2;
        private KryptonNumericUpDown kryptonNumericUpDown1;
        private KryptonLabel kryptonLabel6;
        private KryptonLabel kryptonLabel5;
        private KryptonLabel kryptonLabel4;
        private KryptonLabel kryptonLabel3;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private ColourWheelControl colourWheelControl1;
        private KryptonTextBox kryptonTextBox1;
        private KryptonLabel kryptonLabel7;
        private KryptonButton kryptonButton1;
        private KryptonButton kryptonButton3;
        private KryptonButton kryptonButton2;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonButton kryptonCancelDialogButton1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonOKDialogButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonCancelDialogButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.colourWheelControl1 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.ColourWheelControl();
            this.circularPictureBox1 = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            this.kryptonNumericUpDown6 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown5 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown4 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown3 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown2 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown1 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Controls.Add(this.kryptonOKDialogButton1);
            this.kryptonPanel1.Controls.Add(this.kryptonCancelDialogButton1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 318);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(471, 48);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonOKDialogButton1
            // 
            this.kryptonOKDialogButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonOKDialogButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonOKDialogButton1.Location = new System.Drawing.Point(273, 11);
            this.kryptonOKDialogButton1.Name = "kryptonOKDialogButton1";
            this.kryptonOKDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonOKDialogButton1.TabIndex = 1;
            this.kryptonOKDialogButton1.Values.Text = "&OK";
            // 
            // kryptonCancelDialogButton1
            // 
            this.kryptonCancelDialogButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonCancelDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonCancelDialogButton1.Location = new System.Drawing.Point(369, 11);
            this.kryptonCancelDialogButton1.Name = "kryptonCancelDialogButton1";
            this.kryptonCancelDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonCancelDialogButton1.TabIndex = 0;
            this.kryptonCancelDialogButton1.Values.Text = "C&ancel";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonButton3);
            this.kryptonPanel2.Controls.Add(this.kryptonButton2);
            this.kryptonPanel2.Controls.Add(this.kryptonButton1);
            this.kryptonPanel2.Controls.Add(this.kryptonTextBox1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel7);
            this.kryptonPanel2.Controls.Add(this.colourWheelControl1);
            this.kryptonPanel2.Controls.Add(this.circularPictureBox1);
            this.kryptonPanel2.Controls.Add(this.kryptonNumericUpDown6);
            this.kryptonPanel2.Controls.Add(this.kryptonNumericUpDown5);
            this.kryptonPanel2.Controls.Add(this.kryptonNumericUpDown4);
            this.kryptonPanel2.Controls.Add(this.kryptonNumericUpDown3);
            this.kryptonPanel2.Controls.Add(this.kryptonNumericUpDown2);
            this.kryptonPanel2.Controls.Add(this.kryptonNumericUpDown1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(471, 318);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.AutoSize = true;
            this.kryptonButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton3.Location = new System.Drawing.Point(42, 221);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(22, 22);
            this.kryptonButton3.TabIndex = 21;
            this.kryptonButton3.Values.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_save;
            this.kryptonButton3.Values.Text = "";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.AutoSize = true;
            this.kryptonButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton2.Location = new System.Drawing.Point(14, 221);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(22, 22);
            this.kryptonButton2.TabIndex = 20;
            this.kryptonButton2.Values.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_load;
            this.kryptonButton2.Values.Text = "";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(14, 252);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(152, 25);
            this.kryptonButton1.TabIndex = 19;
            this.kryptonButton1.Values.Text = "&More Colours...";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.CueHint.CueHintText = "#000000";
            this.kryptonTextBox1.Location = new System.Drawing.Point(12, 171);
            this.kryptonTextBox1.MaxLength = 7;
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(154, 24);
            this.kryptonTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonTextBox1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonTextBox1.TabIndex = 18;
            this.kryptonTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(12, 144);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(154, 21);
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.TabIndex = 17;
            this.kryptonLabel7.Values.Text = "Hexadecimal Value:";
            // 
            // colourWheelControl1
            // 
            this.colourWheelControl1.BackColor = System.Drawing.Color.Transparent;
            this.colourWheelControl1.Location = new System.Drawing.Point(208, 121);
            this.colourWheelControl1.Name = "colourWheelControl1";
            this.colourWheelControl1.Size = new System.Drawing.Size(251, 185);
            this.colourWheelControl1.TabIndex = 16;
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.circularPictureBox1.Location = new System.Drawing.Point(361, 12);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(101, 101);
            this.circularPictureBox1.TabIndex = 15;
            this.circularPictureBox1.TabStop = false;
            // 
            // kryptonNumericUpDown6
            // 
            this.kryptonNumericUpDown6.Location = new System.Drawing.Point(275, 92);
            this.kryptonNumericUpDown6.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown6.Name = "kryptonNumericUpDown6";
            this.kryptonNumericUpDown6.Size = new System.Drawing.Size(79, 23);
            this.kryptonNumericUpDown6.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.kryptonNumericUpDown6.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonNumericUpDown6.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonNumericUpDown6.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonNumericUpDown6.TabIndex = 14;
            // 
            // kryptonNumericUpDown5
            // 
            this.kryptonNumericUpDown5.Location = new System.Drawing.Point(275, 52);
            this.kryptonNumericUpDown5.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown5.Name = "kryptonNumericUpDown5";
            this.kryptonNumericUpDown5.Size = new System.Drawing.Size(79, 23);
            this.kryptonNumericUpDown5.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.kryptonNumericUpDown5.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonNumericUpDown5.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonNumericUpDown5.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonNumericUpDown5.TabIndex = 13;
            // 
            // kryptonNumericUpDown4
            // 
            this.kryptonNumericUpDown4.Location = new System.Drawing.Point(275, 12);
            this.kryptonNumericUpDown4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown4.Name = "kryptonNumericUpDown4";
            this.kryptonNumericUpDown4.Size = new System.Drawing.Size(79, 23);
            this.kryptonNumericUpDown4.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonNumericUpDown4.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonNumericUpDown4.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonNumericUpDown4.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonNumericUpDown4.TabIndex = 12;
            // 
            // kryptonNumericUpDown3
            // 
            this.kryptonNumericUpDown3.Location = new System.Drawing.Point(110, 92);
            this.kryptonNumericUpDown3.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.kryptonNumericUpDown3.Name = "kryptonNumericUpDown3";
            this.kryptonNumericUpDown3.Size = new System.Drawing.Size(79, 23);
            this.kryptonNumericUpDown3.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonNumericUpDown3.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonNumericUpDown3.TabIndex = 11;
            // 
            // kryptonNumericUpDown2
            // 
            this.kryptonNumericUpDown2.Location = new System.Drawing.Point(110, 12);
            this.kryptonNumericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown2.Name = "kryptonNumericUpDown2";
            this.kryptonNumericUpDown2.Size = new System.Drawing.Size(79, 23);
            this.kryptonNumericUpDown2.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonNumericUpDown2.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonNumericUpDown2.TabIndex = 10;
            // 
            // kryptonNumericUpDown1
            // 
            this.kryptonNumericUpDown1.Location = new System.Drawing.Point(110, 52);
            this.kryptonNumericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown1.Name = "kryptonNumericUpDown1";
            this.kryptonNumericUpDown1.Size = new System.Drawing.Size(79, 23);
            this.kryptonNumericUpDown1.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonNumericUpDown1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonNumericUpDown1.TabIndex = 9;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(208, 92);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(48, 21);
            this.kryptonLabel6.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonLabel6.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 8;
            this.kryptonLabel6.Values.Text = "Blue:";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(208, 52);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(61, 21);
            this.kryptonLabel5.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kryptonLabel5.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 7;
            this.kryptonLabel5.Values.Text = "Green:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(208, 12);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(45, 21);
            this.kryptonLabel4.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel4.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Red:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 92);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(45, 21);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Hue:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 52);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(92, 21);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Brightness:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(57, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Alpha:";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(471, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // KryptonColourButtonCustomColourDialog
            // 
            this.ClientSize = new System.Drawing.Size(471, 366);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "KryptonColourButtonCustomColourDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select Colour";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _colour, _hsbValue;

        private System.Windows.Forms.Timer _tmrARGB, _tmrHSB, _tmrFillColourValues;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set => _colour = value; }

        public Color HSBValue { get => _hsbValue; set => _hsbValue = value; }
        #endregion

        #region Constructors
        public KryptonColourButtonCustomColourDialog()
        {
            InitializeComponent();

            //cwColours.Colour = Color.White;

            _tmrFillColourValues = new System.Windows.Forms.Timer();

            _tmrFillColourValues.Enabled = true;

            _tmrFillColourValues.Interval = 250;

            //_tmrFillColourValues.Tick += FillColourValues_Tick;
        }

        public KryptonColourButtonCustomColourDialog(Color colour)
        {
            InitializeComponent();

            //cwColours.Colour = colour;

            _tmrFillColourValues = new System.Windows.Forms.Timer();

            _tmrFillColourValues.Enabled = true;

            _tmrFillColourValues.Interval = 250;

            //_tmrFillColourValues.Tick += FillColourValues_Tick;
        }
        #endregion
    }
}