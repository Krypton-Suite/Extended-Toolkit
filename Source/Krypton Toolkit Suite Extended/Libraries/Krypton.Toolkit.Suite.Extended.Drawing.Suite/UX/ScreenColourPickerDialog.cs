#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Base;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    [DefaultEvent("SelectedColourChanged"), DefaultProperty("Colour")]
    public class ScreenColourPickerDialog : KryptonForm
    {
        #region Design Code
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonLabel klblRed;
        private KryptonLabel klblGreen;
        private KryptonLabel klblBlue;
        private ColourWheelControl cwColour;
        private ScreenColourPickerControl scp;
        private KryptonNumericUpDown knudGreen;
        private KryptonNumericUpDown knudBlue;
        private KryptonNumericUpDown knudRed;
        private KryptonTextBox ktxtHexValue;
        private KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl kkcBlue;
        private Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl kkcGreen;
        private Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl kkcRed;
        private Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox cpbSelectedColour;
        private Krypton.Toolkit.Suite.Extended.Base.KryptonOKDialogButton kryptonOKDialogButton1;
        private Krypton.Toolkit.Suite.Extended.Base.KryptonCancelDialogButton kryptonCancelDialogButton1;
        private ColourEditorManager cem;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonOKDialogButton1 = new Krypton.Toolkit.Suite.Extended.Base.KryptonOKDialogButton();
            this.kryptonCancelDialogButton1 = new Krypton.Toolkit.Suite.Extended.Base.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.ktxtHexValue = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kkcBlue = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.kkcGreen = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.kkcRed = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.cpbSelectedColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.knudGreen = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudBlue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudRed = new Krypton.Toolkit.KryptonNumericUpDown();
            this.cwColour = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.ColourWheelControl();
            this.scp = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.ScreenColourPickerControl();
            this.klblGreen = new Krypton.Toolkit.KryptonLabel();
            this.klblBlue = new Krypton.Toolkit.KryptonLabel();
            this.klblRed = new Krypton.Toolkit.KryptonLabel();
            this.cem = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.ColourEditorManager();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSelectedColour)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonOKDialogButton1);
            this.kryptonPanel1.Controls.Add(this.kryptonCancelDialogButton1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 318);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(577, 39);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonOKDialogButton1
            // 
            this.kryptonOKDialogButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonOKDialogButton1.Location = new System.Drawing.Point(379, 6);
            this.kryptonOKDialogButton1.Name = "kryptonOKDialogButton1";
            this.kryptonOKDialogButton1.ParentWindow = this;
            this.kryptonOKDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonOKDialogButton1.TabIndex = 3;
            this.kryptonOKDialogButton1.Values.Text = "&OK";
            // 
            // kryptonCancelDialogButton1
            // 
            this.kryptonCancelDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonCancelDialogButton1.Location = new System.Drawing.Point(475, 6);
            this.kryptonCancelDialogButton1.Name = "kryptonCancelDialogButton1";
            this.kryptonCancelDialogButton1.ParentWindow = this;
            this.kryptonCancelDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonCancelDialogButton1.TabIndex = 3;
            this.kryptonCancelDialogButton1.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtHexValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kkcBlue);
            this.kryptonPanel2.Controls.Add(this.kkcGreen);
            this.kryptonPanel2.Controls.Add(this.kkcRed);
            this.kryptonPanel2.Controls.Add(this.cpbSelectedColour);
            this.kryptonPanel2.Controls.Add(this.knudGreen);
            this.kryptonPanel2.Controls.Add(this.knudBlue);
            this.kryptonPanel2.Controls.Add(this.knudRed);
            this.kryptonPanel2.Controls.Add(this.cwColour);
            this.kryptonPanel2.Controls.Add(this.scp);
            this.kryptonPanel2.Controls.Add(this.klblGreen);
            this.kryptonPanel2.Controls.Add(this.klblBlue);
            this.kryptonPanel2.Controls.Add(this.klblRed);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(577, 315);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // ktxtHexValue
            // 
            this.ktxtHexValue.Hint = "#000000";
            this.ktxtHexValue.Location = new System.Drawing.Point(240, 233);
            this.ktxtHexValue.MaxLength = 7;
            this.ktxtHexValue.Name = "ktxtHexValue";
            this.ktxtHexValue.Size = new System.Drawing.Size(100, 24);
            this.ktxtHexValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtHexValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtHexValue.TabIndex = 9;
            this.ktxtHexValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtHexValue.TextChanged += new System.EventHandler(this.ktxtHexValue_TextChanged);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(210, 206);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(154, 21);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Hexadecimal Value:";
            // 
            // kkcBlue
            // 
            this.kkcBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcBlue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcBlue.KnobIndicatorBorderColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.kkcBlue.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcBlue.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcBlue.LargeChange = 20;
            this.kkcBlue.Location = new System.Drawing.Point(325, 39);
            this.kkcBlue.Maximum = 255;
            this.kkcBlue.Minimum = 0;
            this.kkcBlue.Name = "kkcBlue";
            this.kkcBlue.ShowLargeScale = true;
            this.kkcBlue.ShowSmallScale = false;
            this.kkcBlue.Size = new System.Drawing.Size(91, 91);
            this.kkcBlue.SizeLargeScaleMarker = 6;
            this.kkcBlue.SizeSmallScaleMarker = 3;
            this.kkcBlue.SmallChange = 5;
            this.kkcBlue.TabIndex = 7;
            this.kkcBlue.Value = 0;
            this.kkcBlue.ValueChanged += new Krypton.Toolkit.Suite.Extended.Base.ValueChangedEventHandler(this.kkcBlue_ValueChanged);
            // 
            // kkcGreen
            // 
            this.kkcGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcGreen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcGreen.KnobIndicatorBorderColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.kkcGreen.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcGreen.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcGreen.LargeChange = 20;
            this.kkcGreen.Location = new System.Drawing.Point(165, 39);
            this.kkcGreen.Maximum = 255;
            this.kkcGreen.Minimum = 0;
            this.kkcGreen.Name = "kkcGreen";
            this.kkcGreen.ShowLargeScale = true;
            this.kkcGreen.ShowSmallScale = false;
            this.kkcGreen.Size = new System.Drawing.Size(91, 91);
            this.kkcGreen.SizeLargeScaleMarker = 6;
            this.kkcGreen.SizeSmallScaleMarker = 3;
            this.kkcGreen.SmallChange = 5;
            this.kkcGreen.TabIndex = 6;
            this.kkcGreen.Value = 0;
            this.kkcGreen.ValueChanged += new Krypton.Toolkit.Suite.Extended.Base.ValueChangedEventHandler(this.kkcGreen_ValueChanged);
            // 
            // kkcRed
            // 
            this.kkcRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcRed.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcRed.KnobIndicatorBorderColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.kkcRed.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcRed.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcRed.LargeChange = 20;
            this.kkcRed.Location = new System.Drawing.Point(12, 39);
            this.kkcRed.Maximum = 255;
            this.kkcRed.Minimum = 0;
            this.kkcRed.Name = "kkcRed";
            this.kkcRed.ShowLargeScale = true;
            this.kkcRed.ShowSmallScale = false;
            this.kkcRed.Size = new System.Drawing.Size(91, 91);
            this.kkcRed.SizeLargeScaleMarker = 6;
            this.kkcRed.SizeSmallScaleMarker = 3;
            this.kkcRed.SmallChange = 5;
            this.kkcRed.TabIndex = 3;
            this.kkcRed.Value = 0;
            this.kkcRed.ValueChanged += new Krypton.Toolkit.Suite.Extended.Base.ValueChangedEventHandler(this.kkcRed_ValueChanged);
            // 
            // cpbSelectedColour
            // 
            this.cpbSelectedColour.BackColor = System.Drawing.SystemColors.Control;
            this.cpbSelectedColour.Location = new System.Drawing.Point(435, 12);
            this.cpbSelectedColour.Name = "cpbSelectedColour";
            this.cpbSelectedColour.Size = new System.Drawing.Size(130, 130);
            this.cpbSelectedColour.TabIndex = 3;
            this.cpbSelectedColour.TabStop = false;
            // 
            // knudGreen
            // 
            this.knudGreen.Location = new System.Drawing.Point(165, 136);
            this.knudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreen.Name = "knudGreen";
            this.knudGreen.Size = new System.Drawing.Size(88, 23);
            this.knudGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudGreen.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudGreen.TabIndex = 5;
            this.knudGreen.ValueChanged += new System.EventHandler(this.knudGreen_ValueChanged);
            // 
            // knudBlue
            // 
            this.knudBlue.Location = new System.Drawing.Point(328, 136);
            this.knudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlue.Name = "knudBlue";
            this.knudBlue.Size = new System.Drawing.Size(88, 23);
            this.knudBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBlue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBlue.TabIndex = 4;
            this.knudBlue.ValueChanged += new System.EventHandler(this.knudBlue_ValueChanged);
            // 
            // knudRed
            // 
            this.knudRed.Location = new System.Drawing.Point(12, 136);
            this.knudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRed.Name = "knudRed";
            this.knudRed.Size = new System.Drawing.Size(91, 23);
            this.knudRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudRed.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudRed.TabIndex = 3;
            this.knudRed.ValueChanged += new System.EventHandler(this.knudRed_ValueChanged);
            // 
            // cwColour
            // 
            this.cwColour.BackColor = System.Drawing.Color.Transparent;
            this.cwColour.Location = new System.Drawing.Point(415, 148);
            this.cwColour.Name = "cwColour";
            this.cwColour.Size = new System.Drawing.Size(150, 150);
            this.cwColour.TabIndex = 3;
            // 
            // scp
            // 
            this.scp.Colour = System.Drawing.Color.Empty;
            this.scp.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Suite.Properties.Resources.eyedropper;
            this.scp.Location = new System.Drawing.Point(12, 185);
            this.scp.Name = "scp";
            this.scp.Size = new System.Drawing.Size(139, 113);
            // 
            // klblGreen
            // 
            this.klblGreen.Location = new System.Drawing.Point(165, 12);
            this.klblGreen.Name = "klblGreen";
            this.klblGreen.Size = new System.Drawing.Size(91, 21);
            this.klblGreen.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblGreen.TabIndex = 2;
            this.klblGreen.Values.Text = "Green: 255";
            // 
            // klblBlue
            // 
            this.klblBlue.Location = new System.Drawing.Point(328, 12);
            this.klblBlue.Name = "klblBlue";
            this.klblBlue.Size = new System.Drawing.Size(79, 21);
            this.klblBlue.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.klblBlue.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.klblBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBlue.TabIndex = 1;
            this.klblBlue.Values.Text = "Blue: 255";
            // 
            // klblRed
            // 
            this.klblRed.Location = new System.Drawing.Point(12, 12);
            this.klblRed.Name = "klblRed";
            this.klblRed.Size = new System.Drawing.Size(76, 21);
            this.klblRed.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRed.TabIndex = 0;
            this.klblRed.Values.Text = "Red: 255";
            // 
            // cem
            // 
            this.cem.Color = System.Drawing.Color.Empty;
            this.cem.ColourWheel = this.cwColour;
            this.cem.ScreenColourPicker = this.scp;
            this.cem.ColourChanged += new System.EventHandler(this.cem_ColourChanged);
            // 
            // ScreenColourPickerDialog
            // 
            this.ClientSize = new System.Drawing.Size(577, 357);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenColourPickerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select a Colour";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSelectedColour)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Enumerations
        private enum ColourChannelLabel
        {
            BLUELABEL,
            GREENLABEL,
            REDLABEL
        }
        #endregion

        #region Custom Events
        public delegate void SelectedColourChangedEventHandler(object sender, ColourChangedEventArgs e);

        public event SelectedColourChangedEventHandler SelectedColourChanged;

        protected virtual void OnSelectedColourChanged(object sender, ColourChangedEventArgs e) => SelectedColourChanged?.Invoke(sender, e);
        #endregion

        #region Values
        private byte _red, _green, _blue;

        private Color _colour;
        #endregion

        #region Properties
        [DefaultValue(0)]
        public byte RedValue { get => _red; set { _red = value; Invalidate(); } }

        [DefaultValue(0)]
        public byte GreenValue { get => _green; set { _green = value; Invalidate(); } }

        [DefaultValue(0)]
        public byte BlueValue { get => _blue; set { _blue = value; Invalidate(); } }

        [DefaultValue(null)]
        public Color Colour { get => _colour; set { _colour = value; Invalidate(); } }
        #endregion

        #region Constructor
        public ScreenColourPickerDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler
        private void cem_ColourChanged(object sender, EventArgs e)
        {
            UpdateColourValues(cem.Color);

            ColourChangedEventArgs args = new ColourChangedEventArgs(cem.Color);

            OnSelectedColourChanged(sender, args);
        }

        private void knudRed_ValueChanged(object sender, EventArgs e)
        {

        }

        private void knudGreen_ValueChanged(object sender, EventArgs e)
        {

        }

        private void kkcRed_ValueChanged(object sender, KnobValueChangedEventArgs e)
        {

        }

        private void kkcGreen_ValueChanged(object sender, KnobValueChangedEventArgs e)
        {

        }

        private void kkcBlue_ValueChanged(object sender, KnobValueChangedEventArgs e)
        {

        }

        private void knudBlue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ktxtHexValue_TextChanged(object sender, EventArgs e)
        {
            if (ktxtHexValue.Text.Length == 3 || ktxtHexValue.Text.Length <= 6)
            {
                UpdateColourValues(ColorTranslator.FromHtml(ktxtHexValue.Text));
            }
        }
        #endregion

        #region Methods
        private void UpdateColourValues(Color colour)
        {
            cpbSelectedColour.BackColor = colour;

            UpdateLabels(colour);

            kkcBlue.Value = colour.B;

            kkcGreen.Value = colour.G;

            kkcRed.Value = colour.R;

            cwColour.Colour = colour;

            knudBlue.Value = colour.B;

            knudGreen.Value = colour.G;

            knudRed.Value = colour.R;

            ktxtHexValue.Text = GetHexadecimalValue(colour);
        }

        private byte ReturnRedChannelValue(Color colour) => colour.R;

        private byte ReturnGreenChannelValue(Color colour) => colour.G;

        private byte ReturnBlueChannelValue(Color colour) => colour.B;

        private Color ConstructColour(byte red, byte green, byte blue) => Color.FromArgb(red, green, blue);

        private string GetHexadecimalValue(Color colour) => ColorTranslator.ToHtml(colour);

        private void UpdateLabels(Color colour)
        {
            klblRed.Text = $"Red: { colour.R }";

            klblGreen.Text = $"Green: { colour.G }";

            klblBlue.Text = $"Blue: { colour.B }";
        }
        #endregion
    }
}