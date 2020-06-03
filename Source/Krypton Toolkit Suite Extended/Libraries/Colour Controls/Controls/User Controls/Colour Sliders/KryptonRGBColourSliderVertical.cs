using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Colour.Controls
{
    public delegate void ColourChangedHandler(object sender, ColourChangedEventArgs e);

    [DefaultEvent("ColourChanged")]
    public class KryptonRGBColourSliderVertical : UserControl
    {
        #region Design Code
        private KryptonBlueValueNumericBox knudBlue;
        private KryptonRedValueNumericBox knudRed;
        private KryptonGreenValueNumericBox knudGreen;
        private KryptonGreenTrackBar ktrkGreen;
        private KryptonBlueTrackBar ktrkBlue;
        private KryptonRedTrackBar ktrkRed;
        private KryptonBlueValueLabel klblBlue;
        private KryptonGreenValueLabel klblGreen;
        private KryptonRedValueLabel klblRed;

        private void InitializeComponent()
        {
            this.knudBlue = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonBlueValueNumericBox();
            this.knudRed = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonRedValueNumericBox();
            this.knudGreen = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonGreenValueNumericBox();
            this.ktrkGreen = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonGreenTrackBar();
            this.ktrkBlue = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonBlueTrackBar();
            this.ktrkRed = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonRedTrackBar();
            this.klblBlue = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblGreen = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblRed = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonRedValueLabel();
            this.SuspendLayout();
            // 
            // knudBlue
            // 
            this.knudBlue.Location = new System.Drawing.Point(167, 398);
            this.knudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlue.Name = "knudBlue";
            this.knudBlue.Size = new System.Drawing.Size(77, 23);
            this.knudBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBlue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBlue.TabIndex = 20;
            this.knudBlue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBlue.UseAccessibleUI = false;
            this.knudBlue.ValueChanged += new System.EventHandler(this.knudBlue_ValueChanged);
            // 
            // knudRed
            // 
            this.knudRed.Location = new System.Drawing.Point(3, 398);
            this.knudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRed.Name = "knudRed";
            this.knudRed.Size = new System.Drawing.Size(67, 23);
            this.knudRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudRed.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudRed.TabIndex = 19;
            this.knudRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudRed.UseAccessibleUI = false;
            this.knudRed.ValueChanged += new System.EventHandler(this.knudRed_ValueChanged);
            // 
            // knudGreen
            // 
            this.knudGreen.Location = new System.Drawing.Point(85, 398);
            this.knudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreen.Name = "knudGreen";
            this.knudGreen.Size = new System.Drawing.Size(67, 23);
            this.knudGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudGreen.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudGreen.TabIndex = 18;
            this.knudGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudGreen.UseAccessibleUI = false;
            this.knudGreen.ValueChanged += new System.EventHandler(this.knudGreen_ValueChanged);
            // 
            // ktrkGreen
            // 
            this.ktrkGreen.DrawBackground = true;
            this.ktrkGreen.Location = new System.Drawing.Point(102, 43);
            this.ktrkGreen.Maximum = 255;
            this.ktrkGreen.Name = "ktrkGreen";
            this.ktrkGreen.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktrkGreen.Size = new System.Drawing.Size(21, 349);
            this.ktrkGreen.StateCommon.Tick.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktrkGreen.TabIndex = 17;
            this.ktrkGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkGreen.UseAccessibleUI = false;
            this.ktrkGreen.ValueChanged += new System.EventHandler(this.ktrkGreen_ValueChanged);
            // 
            // ktrkBlue
            // 
            this.ktrkBlue.DrawBackground = true;
            this.ktrkBlue.Location = new System.Drawing.Point(191, 42);
            this.ktrkBlue.Maximum = 255;
            this.ktrkBlue.Name = "ktrkBlue";
            this.ktrkBlue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktrkBlue.Size = new System.Drawing.Size(21, 350);
            this.ktrkBlue.StateCommon.Tick.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktrkBlue.TabIndex = 16;
            this.ktrkBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkBlue.UseAccessibleUI = false;
            this.ktrkBlue.ValueChanged += new System.EventHandler(this.ktrkBlue_ValueChanged);
            // 
            // ktrkRed
            // 
            this.ktrkRed.DrawBackground = true;
            this.ktrkRed.Location = new System.Drawing.Point(20, 42);
            this.ktrkRed.Maximum = 255;
            this.ktrkRed.Name = "ktrkRed";
            this.ktrkRed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktrkRed.Size = new System.Drawing.Size(21, 350);
            this.ktrkRed.StateCommon.Tick.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktrkRed.TabIndex = 15;
            this.ktrkRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkRed.UseAccessibleUI = false;
            this.ktrkRed.ValueChanged += new System.EventHandler(this.ktrkRed_ValueChanged);
            // 
            // klblBlue
            // 
            this.klblBlue.BlueValue = 0;
            this.klblBlue.ExtraText = "Blue";
            this.klblBlue.Location = new System.Drawing.Point(179, 15);
            this.klblBlue.Name = "klblBlue";
            this.klblBlue.ShowColon = true;
            this.klblBlue.ShowCurrentColourValue = false;
            this.klblBlue.Size = new System.Drawing.Size(44, 21);
            this.klblBlue.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.klblBlue.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.klblBlue.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlue.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.klblBlue.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.klblBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlue.TabIndex = 14;
            this.klblBlue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlue.UseAccessibleUI = false;
            this.klblBlue.Values.Text = "Blue";
            // 
            // klblGreen
            // 
            this.klblGreen.ExtraText = "Green";
            this.klblGreen.GreenValue = 0;
            this.klblGreen.Location = new System.Drawing.Point(87, 15);
            this.klblGreen.Name = "klblGreen";
            this.klblGreen.ShowColon = true;
            this.klblGreen.ShowCurrentColourValue = false;
            this.klblGreen.Size = new System.Drawing.Size(56, 21);
            this.klblGreen.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.TabIndex = 13;
            this.klblGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.UseAccessibleUI = false;
            this.klblGreen.Values.Text = "Green";
            // 
            // klblRed
            // 
            this.klblRed.ExtraText = "Red";
            this.klblRed.Location = new System.Drawing.Point(10, 15);
            this.klblRed.Name = "klblRed";
            this.klblRed.RedValue = 255;
            this.klblRed.ShowColon = true;
            this.klblRed.ShowCurrentColourValue = false;
            this.klblRed.Size = new System.Drawing.Size(41, 21);
            this.klblRed.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.TabIndex = 12;
            this.klblRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.UseAccessibleUI = false;
            this.klblRed.Values.Text = "Red";
            // 
            // KryptonRGBColourSliderVertical
            // 
            this.Controls.Add(this.knudBlue);
            this.Controls.Add(this.knudRed);
            this.Controls.Add(this.knudGreen);
            this.Controls.Add(this.ktrkGreen);
            this.Controls.Add(this.ktrkBlue);
            this.Controls.Add(this.ktrkRed);
            this.Controls.Add(this.klblBlue);
            this.Controls.Add(this.klblGreen);
            this.Controls.Add(this.klblRed);
            this.Name = "KryptonRGBColourSliderVertical";
            this.Size = new System.Drawing.Size(250, 437);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Events
        public event ColourChangedHandler ColourChanged;
        #endregion

        #region Variables
        private byte _r, _g, _b;

        private byte[] _byteArray;

        private Color _colour;
        #endregion

        #region Properties
        private byte Red { get => _r; set => _r = value; }

        private byte Green { get => _g; set => _g = value; }

        private byte Blue { get => _b; set => _b = value; }

        [Description("")]
        public Color Colour { get => _colour; set => _colour = value; }
        #endregion

        #region Constructor
        public KryptonRGBColourSliderVertical()
        {
            InitializeComponent();
        }
        #endregion

        #region Virtual
        protected virtual void OnColourChanged(object sender, ColourChangedEventArgs e)
        {
            if (ColourChanged != null) ColourChanged(sender, e);
        }
        #endregion

        #region Methods
        private void UpdateColour(byte red, byte green, byte blue)
        {
            Color temp = Color.FromArgb(red, green, blue);

            ColourChangedEventArgs e;

            e = new ColourChangedEventArgs(temp);

            OnColourChanged(this, e);

            Colour = temp;
        }

        private byte[] ReturnColourArray(byte r, byte g, byte b)
        {
            _byteArray = new byte[3] { r, g, b };

            return _byteArray;
        }

        private void FillColour(byte[] array)
        {
            if (array.Length > 0)
            {
                Color temp = Color.FromArgb(array[0], array[1], array[2]);

                ColourChangedEventArgs e;

                e = new ColourChangedEventArgs(temp);

                OnColourChanged(this, e);

                Colour = temp;
            }
        }
        #endregion

        private void ktrkRed_ValueChanged(object sender, EventArgs e)
        {
            Red = (byte)ktrkRed.Value;

            Green = (byte)ktrkGreen.Value;

            Blue = (byte)ktrkBlue.Value;

            FillColour(ReturnColourArray(Red, Green, Blue));
        }

        private void ktrkGreen_ValueChanged(object sender, EventArgs e)
        {
            Red = (byte)ktrkRed.Value;

            Green = (byte)ktrkGreen.Value;

            Blue = (byte)ktrkBlue.Value;

            FillColour(ReturnColourArray(Red, Green, Blue));
        }

        private void ktrkBlue_ValueChanged(object sender, EventArgs e)
        {
            Red = (byte)ktrkRed.Value;

            Green = (byte)ktrkGreen.Value;

            Blue = (byte)ktrkBlue.Value;

            FillColour(ReturnColourArray(Red, Green, Blue));
        }

        private void knudRed_ValueChanged(object sender, EventArgs e)
        {
            Red = (byte)knudRed.Value;

            Green = (byte)knudGreen.Value;

            Blue = (byte)knudBlue.Value;

            FillColour(ReturnColourArray(Red, Green, Blue));
        }

        private void knudGreen_ValueChanged(object sender, EventArgs e)
        {
            Red = (byte)knudRed.Value;

            Green = (byte)knudGreen.Value;

            Blue = (byte)knudBlue.Value;

            FillColour(ReturnColourArray(Red, Green, Blue));
        }

        private void knudBlue_ValueChanged(object sender, EventArgs e)
        {
            Red = (byte)knudRed.Value;

            Green = (byte)knudGreen.Value;

            Blue = (byte)knudBlue.Value;

            FillColour(ReturnColourArray(Red, Green, Blue));
        }
    }
}