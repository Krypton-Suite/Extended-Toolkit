using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Colour.Controls
{
    public class ScreenColourPickerDialog : KryptonForm
    {
        #region Design Code
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private ScreenColourPickerControl scpColour;
        private ColourWheelControl cwColour;
        private Suite.Extended.Base.KryptonKnobControl kknbRed;
        private Suite.Extended.Base.KryptonKnobControl kknbGreen;
        private Suite.Extended.Base.KryptonKnobControl kknbBlue;
        private Suite.Extended.Base.CircularPictureBox cpbSelectedColour;
        private ColourEditorManager cem;
        private KryptonNumericUpDown knumBlue;
        private KryptonNumericUpDown knumGreen;
        private KryptonNumericUpDown knumRed;
        private KryptonLabel klblHexValue;
        private Suite.Extended.Base.KryptonOKDialogButton kbtnOk;
        private Suite.Extended.Base.KryptonCancelDialogButton kbtnCancel;
        private KryptonPanel kryptonPanel1;

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
            this.klblHexValue = new Krypton.Toolkit.KryptonLabel();
            this.scpColour = new Krypton.Toolkit.Suite.Extended.Colour.Controls.ScreenColourPickerControl();
            this.cwColour = new Krypton.Toolkit.Suite.Extended.Colour.Controls.ColourWheelControl();
            this.kknbRed = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.kknbGreen = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.kknbBlue = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.cpbSelectedColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cem = new Krypton.Toolkit.Suite.Extended.Colour.Controls.ColourEditorManager();
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
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 367);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(586, 43);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(388, 6);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 3;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(484, 6);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 3;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 365);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 2);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.knumBlue);
            this.kryptonPanel2.Controls.Add(this.knumGreen);
            this.kryptonPanel2.Controls.Add(this.knumRed);
            this.kryptonPanel2.Controls.Add(this.klblHexValue);
            this.kryptonPanel2.Controls.Add(this.scpColour);
            this.kryptonPanel2.Controls.Add(this.cwColour);
            this.kryptonPanel2.Controls.Add(this.kknbRed);
            this.kryptonPanel2.Controls.Add(this.kknbGreen);
            this.kryptonPanel2.Controls.Add(this.kknbBlue);
            this.kryptonPanel2.Controls.Add(this.cpbSelectedColour);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(586, 365);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // knumBlue
            // 
            this.knumBlue.Location = new System.Drawing.Point(289, 109);
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
            this.knumBlue.TabIndex = 9;
            this.knumBlue.ValueChanged += new System.EventHandler(this.knumBlue_ValueChanged);
            // 
            // knumGreen
            // 
            this.knumGreen.Location = new System.Drawing.Point(153, 109);
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
            this.knumGreen.TabIndex = 8;
            this.knumGreen.ValueChanged += new System.EventHandler(this.knumGreen_ValueChanged);
            // 
            // knumRed
            // 
            this.knumRed.Location = new System.Drawing.Point(12, 109);
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
            this.knumRed.TabIndex = 7;
            this.knumRed.ValueChanged += new System.EventHandler(this.knumRed_ValueChanged);
            // 
            // klblHexValue
            // 
            this.klblHexValue.Location = new System.Drawing.Point(254, 246);
            this.klblHexValue.Name = "klblHexValue";
            this.klblHexValue.Size = new System.Drawing.Size(78, 23);
            this.klblHexValue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHexValue.TabIndex = 6;
            this.klblHexValue.Values.Text = "#000000";
            // 
            // scpColour
            // 
            this.scpColour.Colour = System.Drawing.Color.Empty;
            this.scpColour.Image = global::Krypton.Toolkit.Suite.Extended.Colour.Controls.Properties.Resources.eyedropper;
            this.scpColour.Location = new System.Drawing.Point(12, 173);
            this.scpColour.Name = "scpColour";
            this.scpColour.Size = new System.Drawing.Size(166, 158);
            this.scpColour.ColourChanged += new System.EventHandler(this.scpColour_ColourChanged);
            // 
            // cwColour
            // 
            this.cwColour.BackColor = System.Drawing.Color.Transparent;
            this.cwColour.Location = new System.Drawing.Point(421, 185);
            this.cwColour.Name = "cwColour";
            this.cwColour.Size = new System.Drawing.Size(150, 146);
            this.cwColour.TabIndex = 3;
            this.cwColour.ColourChanged += new System.EventHandler(this.cwColour_ColourChanged);
            // 
            // kknbRed
            // 
            this.kknbRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kknbRed.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kknbRed.KnobIndicatorBorderColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.kknbRed.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kknbRed.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kknbRed.LargeChange = 20;
            this.kknbRed.Location = new System.Drawing.Point(12, 12);
            this.kknbRed.Maximum = 100;
            this.kknbRed.Minimum = 0;
            this.kknbRed.Name = "kknbRed";
            this.kknbRed.ShowLargeScale = true;
            this.kknbRed.ShowSmallScale = false;
            this.kknbRed.Size = new System.Drawing.Size(91, 91);
            this.kknbRed.SizeLargeScaleMarker = 6;
            this.kknbRed.SizeSmallScaleMarker = 3;
            this.kknbRed.SmallChange = 5;
            this.kknbRed.TabIndex = 3;
            this.kknbRed.Value = 0;
            this.kknbRed.ValueChanged += new Krypton.Toolkit.Suite.Extended.Base.ValueChangedEventHandler(this.kknbRed_ValueChanged);
            // 
            // kknbGreen
            // 
            this.kknbGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kknbGreen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kknbGreen.KnobIndicatorBorderColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.kknbGreen.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kknbGreen.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kknbGreen.LargeChange = 20;
            this.kknbGreen.Location = new System.Drawing.Point(153, 12);
            this.kknbGreen.Maximum = 100;
            this.kknbGreen.Minimum = 0;
            this.kknbGreen.Name = "kknbGreen";
            this.kknbGreen.ShowLargeScale = true;
            this.kknbGreen.ShowSmallScale = false;
            this.kknbGreen.Size = new System.Drawing.Size(91, 91);
            this.kknbGreen.SizeLargeScaleMarker = 6;
            this.kknbGreen.SizeSmallScaleMarker = 3;
            this.kknbGreen.SmallChange = 5;
            this.kknbGreen.TabIndex = 4;
            this.kknbGreen.Value = 0;
            this.kknbGreen.ValueChanged += new Krypton.Toolkit.Suite.Extended.Base.ValueChangedEventHandler(this.kknbGreen_ValueChanged);
            // 
            // kknbBlue
            // 
            this.kknbBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kknbBlue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kknbBlue.KnobIndicatorBorderColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.kknbBlue.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kknbBlue.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kknbBlue.LargeChange = 20;
            this.kknbBlue.Location = new System.Drawing.Point(289, 12);
            this.kknbBlue.Maximum = 255;
            this.kknbBlue.Minimum = 0;
            this.kknbBlue.Name = "kknbBlue";
            this.kknbBlue.ShowLargeScale = true;
            this.kknbBlue.ShowSmallScale = false;
            this.kknbBlue.Size = new System.Drawing.Size(91, 91);
            this.kknbBlue.SizeLargeScaleMarker = 6;
            this.kknbBlue.SizeSmallScaleMarker = 3;
            this.kknbBlue.SmallChange = 5;
            this.kknbBlue.TabIndex = 5;
            this.kknbBlue.Value = 0;
            this.kknbBlue.ValueChanged += new Krypton.Toolkit.Suite.Extended.Base.ValueChangedEventHandler(this.kknbBlue_ValueChanged);
            // 
            // cpbSelectedColour
            // 
            this.cpbSelectedColour.BackColor = System.Drawing.SystemColors.Control;
            this.cpbSelectedColour.Location = new System.Drawing.Point(421, 12);
            this.cpbSelectedColour.Name = "cpbSelectedColour";
            this.cpbSelectedColour.Size = new System.Drawing.Size(150, 150);
            this.cpbSelectedColour.TabIndex = 3;
            this.cpbSelectedColour.TabStop = false;
            this.cpbSelectedColour.ToolTipValues = null;
            // 
            // cem
            // 
            this.cem.Color = System.Drawing.Color.Empty;
            this.cem.ColourWheel = this.cwColour;
            this.cem.ScreenColourPicker = this.scpColour;
            // 
            // ScreenColourPickerWindow
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(586, 410);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenColourPickerWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Screen Colour Picker";
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
        private Color _knobForeColour, _knobBackColour, _knobBorderColour, _knobColour, _knobTrackingColour, _colour;

        private IPalette _palette;
        #endregion

        #region Properties
        public Color KnobForeColour { get => _knobForeColour; set { _knobForeColour = value; Invalidate(); } }

        public Color KnobBackColour { get => _knobBackColour; set { _knobBackColour = value; Invalidate(); } }

        public Color KnobBorderColour { get => _knobBorderColour; set { _knobBorderColour = value; Invalidate(); } }

        public Color KnobColour { get => _knobColour; set { _knobColour = value; Invalidate(); } }

        public Color KnobTrackingColour { get => _knobTrackingColour; set { _knobTrackingColour = value; Invalidate(); } }

        public Color Colour { get => _colour; set { _colour = value; ColourChangedEventArgs e = new ColourChangedEventArgs(value); OnSelectedColourChanged(value, e); Invalidate(); } }
        #endregion

        public delegate void SelectedColourChangedEventHandler(object sender, ColourChangedEventArgs e);

        public event SelectedColourChangedEventHandler SelectedColourChanged;

        protected virtual void OnSelectedColourChanged(object sender, ColourChangedEventArgs e) => SelectedColourChanged?.Invoke(sender, e);

        #region Enumerations
        private enum ColourChannelLabel
        {
            BLUELABEL,
            GREENLABEL,
            REDLABEL
        }
        #endregion

        #region Constructor
        public ScreenColourPickerDialog()
        {
            InitializeComponent();

            InitialiseWindow();
        }
        #endregion

        #region Methods
        private void InitialiseWindow()
        {
            knumRed.Value = kknbRed.Value;

            knumGreen.Value = kknbGreen.Value;

            knumBlue.Value = kknbBlue.Value;

            klblHexValue.Text = string.Empty;

            cpbSelectedColour.BackColor = Color.Transparent;
        }

        private string GetHexColourValue(Color colour) => ColorTranslator.ToHtml(colour);

        private void UpdateColourValues(Color colour, bool useKnobs = true)
        {
            if (useKnobs)
            {
                kknbBlue.Value = colour.B;

                kknbGreen.Value = colour.G;

                kknbRed.Value = colour.R;
            }
            else
            {
                UpdateLabelValues(colour.R, colour.G, colour.B);
            }
        }

        private void UpdateLabelValues(byte r, byte g, byte b)
        {
            knumBlue.Value = b;

            knumGreen.Value = g;

            knumRed.Value = r;
        }

        private void ConstructSpecifiedColour(byte red, byte green, byte blue) => cpbSelectedColour.BackColor = Color.FromArgb(red, green, blue);

        private void ConstructSpecifiedColour(int red, int green, int blue) => cpbSelectedColour.BackColor = Color.FromArgb(red, green, blue);

        private void TranslateColourToHex(Color colour) => klblHexValue.Text = ColorTranslator.ToHtml(colour);
        #endregion

        private void scpColour_ColourChanged(object sender, EventArgs e)
        {
            cpbSelectedColour.BackColor = scpColour.Colour;
        }

        private void kknbRed_ValueChanged(object Sender)
        {
            ConstructSpecifiedColour(kknbRed.Value, kknbGreen.Value, kknbBlue.Value);

            TranslateColourToHex(cpbSelectedColour.BackColor);
        }

        private void kknbGreen_ValueChanged(object Sender)
        {
            ConstructSpecifiedColour(kknbRed.Value, kknbGreen.Value, kknbBlue.Value);

            TranslateColourToHex(cpbSelectedColour.BackColor);
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            ColourChangedEventArgs args = new ColourChangedEventArgs(cpbSelectedColour.BackColor);

            OnSelectedColourChanged(sender, args);

            DialogResult = DialogResult.OK;

            Hide();
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Hide();
        }

        private void kknbBlue_ValueChanged(object Sender)
        {
            ConstructSpecifiedColour(kknbRed.Value, kknbGreen.Value, kknbBlue.Value);

            TranslateColourToHex(cpbSelectedColour.BackColor);
        }

        private void knumRed_ValueChanged(object sender, EventArgs e)
        {
            ConstructSpecifiedColour(kknbRed.Value, kknbGreen.Value, kknbBlue.Value);

            TranslateColourToHex(cpbSelectedColour.BackColor);
        }

        private void knumGreen_ValueChanged(object sender, EventArgs e)
        {
            ConstructSpecifiedColour(kknbRed.Value, kknbGreen.Value, kknbBlue.Value);

            TranslateColourToHex(cpbSelectedColour.BackColor);
        }

        private void knumBlue_ValueChanged(object sender, EventArgs e)
        {
            ConstructSpecifiedColour(kknbRed.Value, kknbGreen.Value, kknbBlue.Value);

            TranslateColourToHex(cpbSelectedColour.BackColor);
        }

        private void cwColour_ColourChanged(object sender, EventArgs e)
        {
            ConstructSpecifiedColour(kknbRed.Value, kknbGreen.Value, kknbBlue.Value);

            TranslateColourToHex(cpbSelectedColour.BackColor);
        }
    }
}