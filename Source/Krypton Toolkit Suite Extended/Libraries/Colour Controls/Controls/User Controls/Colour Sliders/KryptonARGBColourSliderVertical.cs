using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    [DefaultEvent("ColourChanged")]
    public class KryptonARGBColourSliderVertical : UserControl
    {
        #region Designer Code
        private KryptonRedValueLabel klblRed;
        private KryptonGreenValueLabel klblGreen;
        private KryptonBlueValueLabel klblBlue;
        private KryptonAlphaTrackBar kryptonAlphaTrackBar1;
        private KryptonRedTrackBar kryptonRedTrackBar1;
        private KryptonBlueTrackBar kryptonBlueTrackBar1;
        private KryptonGreenTrackBar kryptonGreenTrackBar1;
        private KryptonGreenValueNumericBox kryptonGreenValueNumericBox1;
        private KryptonRedValueNumericBox kryptonRedValueNumericBox1;
        private KryptonBlueValueNumericBox kryptonBlueValueNumericBox1;
        private KryptonAlphaValueNumericBox kryptonAlphaValueNumericBox1;
        private KryptonAlphaValueLabel klblAlpha;

        private void InitializeComponent()
        {
            this.kryptonGreenTrackBar1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenTrackBar();
            this.kryptonBlueTrackBar1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueTrackBar();
            this.kryptonRedTrackBar1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedTrackBar();
            this.kryptonAlphaTrackBar1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaTrackBar();
            this.klblBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueLabel();
            this.klblAlpha = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.kryptonGreenValueNumericBox1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueNumericBox();
            this.kryptonRedValueNumericBox1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueNumericBox();
            this.kryptonBlueValueNumericBox1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueNumericBox();
            this.kryptonAlphaValueNumericBox1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaValueNumericBox();
            this.SuspendLayout();
            // 
            // kryptonGreenTrackBar1
            // 
            this.kryptonGreenTrackBar1.DrawBackground = true;
            this.kryptonGreenTrackBar1.Location = new System.Drawing.Point(196, 44);
            this.kryptonGreenTrackBar1.Maximum = 255;
            this.kryptonGreenTrackBar1.Name = "kryptonGreenTrackBar1";
            this.kryptonGreenTrackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.kryptonGreenTrackBar1.Size = new System.Drawing.Size(21, 349);
            this.kryptonGreenTrackBar1.StateCommon.Tick.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenTrackBar1.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenTrackBar1.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenTrackBar1.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.kryptonGreenTrackBar1.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.kryptonGreenTrackBar1.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.kryptonGreenTrackBar1.TabIndex = 7;
            this.kryptonGreenTrackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kryptonGreenTrackBar1.UseAccessibleUI = false;
            // 
            // kryptonBlueTrackBar1
            // 
            this.kryptonBlueTrackBar1.DrawBackground = true;
            this.kryptonBlueTrackBar1.Location = new System.Drawing.Point(285, 43);
            this.kryptonBlueTrackBar1.Maximum = 255;
            this.kryptonBlueTrackBar1.Name = "kryptonBlueTrackBar1";
            this.kryptonBlueTrackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.kryptonBlueTrackBar1.Size = new System.Drawing.Size(21, 350);
            this.kryptonBlueTrackBar1.StateCommon.Tick.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueTrackBar1.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueTrackBar1.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueTrackBar1.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.kryptonBlueTrackBar1.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.kryptonBlueTrackBar1.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.kryptonBlueTrackBar1.TabIndex = 6;
            this.kryptonBlueTrackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kryptonBlueTrackBar1.UseAccessibleUI = false;
            // 
            // kryptonRedTrackBar1
            // 
            this.kryptonRedTrackBar1.DrawBackground = true;
            this.kryptonRedTrackBar1.Location = new System.Drawing.Point(114, 43);
            this.kryptonRedTrackBar1.Maximum = 255;
            this.kryptonRedTrackBar1.Name = "kryptonRedTrackBar1";
            this.kryptonRedTrackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.kryptonRedTrackBar1.Size = new System.Drawing.Size(21, 350);
            this.kryptonRedTrackBar1.StateCommon.Tick.Color1 = System.Drawing.Color.Red;
            this.kryptonRedTrackBar1.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.kryptonRedTrackBar1.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.kryptonRedTrackBar1.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.kryptonRedTrackBar1.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.kryptonRedTrackBar1.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.kryptonRedTrackBar1.TabIndex = 5;
            this.kryptonRedTrackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kryptonRedTrackBar1.UseAccessibleUI = false;
            // 
            // kryptonAlphaTrackBar1
            // 
            this.kryptonAlphaTrackBar1.DrawBackground = true;
            this.kryptonAlphaTrackBar1.Location = new System.Drawing.Point(33, 43);
            this.kryptonAlphaTrackBar1.Maximum = 255;
            this.kryptonAlphaTrackBar1.Name = "kryptonAlphaTrackBar1";
            this.kryptonAlphaTrackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.kryptonAlphaTrackBar1.Size = new System.Drawing.Size(21, 350);
            this.kryptonAlphaTrackBar1.TabIndex = 4;
            this.kryptonAlphaTrackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // klblBlue
            // 
            this.klblBlue.BlueValue = 0;
            this.klblBlue.ExtraText = "Blue";
            this.klblBlue.Location = new System.Drawing.Point(273, 16);
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
            this.klblBlue.TabIndex = 3;
            this.klblBlue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlue.UseAccessibleUI = false;
            this.klblBlue.Values.Text = "Blue";
            // 
            // klblGreen
            // 
            this.klblGreen.ExtraText = "Green";
            this.klblGreen.GreenValue = 0;
            this.klblGreen.Location = new System.Drawing.Point(181, 16);
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
            this.klblGreen.TabIndex = 2;
            this.klblGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.UseAccessibleUI = false;
            this.klblGreen.Values.Text = "Green";
            // 
            // klblRed
            // 
            this.klblRed.ExtraText = "Red";
            this.klblRed.Location = new System.Drawing.Point(104, 16);
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
            this.klblRed.TabIndex = 1;
            this.klblRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.UseAccessibleUI = false;
            this.klblRed.Values.Text = "Red";
            // 
            // klblAlpha
            // 
            this.klblAlpha.AlphaValue = 255;
            this.klblAlpha.ExtraText = "Alpha";
            this.klblAlpha.Location = new System.Drawing.Point(15, 16);
            this.klblAlpha.Name = "klblAlpha";
            this.klblAlpha.ShowColon = true;
            this.klblAlpha.ShowCurrentColourValue = false;
            this.klblAlpha.Size = new System.Drawing.Size(53, 21);
            this.klblAlpha.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.TabIndex = 0;
            this.klblAlpha.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.Values.Text = "Alpha";
            // 
            // kryptonGreenValueNumericBox1
            // 
            this.kryptonGreenValueNumericBox1.Location = new System.Drawing.Point(179, 399);
            this.kryptonGreenValueNumericBox1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonGreenValueNumericBox1.Name = "kryptonGreenValueNumericBox1";
            this.kryptonGreenValueNumericBox1.Size = new System.Drawing.Size(67, 23);
            this.kryptonGreenValueNumericBox1.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueNumericBox1.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonGreenValueNumericBox1.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueNumericBox1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonGreenValueNumericBox1.TabIndex = 9;
            this.kryptonGreenValueNumericBox1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueNumericBox1.UseAccessibleUI = false;
            // 
            // kryptonRedValueNumericBox1
            // 
            this.kryptonRedValueNumericBox1.Location = new System.Drawing.Point(97, 399);
            this.kryptonRedValueNumericBox1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonRedValueNumericBox1.Name = "kryptonRedValueNumericBox1";
            this.kryptonRedValueNumericBox1.Size = new System.Drawing.Size(67, 23);
            this.kryptonRedValueNumericBox1.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueNumericBox1.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonRedValueNumericBox1.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRedValueNumericBox1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonRedValueNumericBox1.TabIndex = 10;
            this.kryptonRedValueNumericBox1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRedValueNumericBox1.UseAccessibleUI = false;
            // 
            // kryptonBlueValueNumericBox1
            // 
            this.kryptonBlueValueNumericBox1.Location = new System.Drawing.Point(261, 399);
            this.kryptonBlueValueNumericBox1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonBlueValueNumericBox1.Name = "kryptonBlueValueNumericBox1";
            this.kryptonBlueValueNumericBox1.Size = new System.Drawing.Size(77, 23);
            this.kryptonBlueValueNumericBox1.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueNumericBox1.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonBlueValueNumericBox1.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonBlueValueNumericBox1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonBlueValueNumericBox1.TabIndex = 11;
            this.kryptonBlueValueNumericBox1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonBlueValueNumericBox1.UseAccessibleUI = false;
            // 
            // kryptonAlphaValueNumericBox1
            // 
            this.kryptonAlphaValueNumericBox1.Location = new System.Drawing.Point(15, 399);
            this.kryptonAlphaValueNumericBox1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonAlphaValueNumericBox1.Name = "kryptonAlphaValueNumericBox1";
            this.kryptonAlphaValueNumericBox1.Size = new System.Drawing.Size(67, 23);
            this.kryptonAlphaValueNumericBox1.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonAlphaValueNumericBox1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonAlphaValueNumericBox1.TabIndex = 12;
            this.kryptonAlphaValueNumericBox1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // KryptonARGBColourSliderVertical
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonAlphaValueNumericBox1);
            this.Controls.Add(this.kryptonBlueValueNumericBox1);
            this.Controls.Add(this.kryptonRedValueNumericBox1);
            this.Controls.Add(this.kryptonGreenValueNumericBox1);
            this.Controls.Add(this.kryptonGreenTrackBar1);
            this.Controls.Add(this.kryptonBlueTrackBar1);
            this.Controls.Add(this.kryptonRedTrackBar1);
            this.Controls.Add(this.kryptonAlphaTrackBar1);
            this.Controls.Add(this.klblBlue);
            this.Controls.Add(this.klblGreen);
            this.Controls.Add(this.klblRed);
            this.Controls.Add(this.klblAlpha);
            this.Name = "KryptonARGBColourSliderVertical";
            this.Size = new System.Drawing.Size(341, 437);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Event
        public delegate void ColourChangedEventHandler(object sender, ColourChangedEventArgs e);

        public event ColourChangedEventHandler ColourChanged;

        protected virtual void OnColourChanged(object sender, ColourChangedEventArgs e) => ColourChanged?.Invoke(sender, e);
        #endregion

        #region Variables
        private Color _colour;
        #endregion

        #region Property
        public Color Colour
        {
            get => _colour;

            set
            {
                _colour = value;

                if (!Colour.IsEmpty)
                {
                    ColourChangedEventArgs e = new ColourChangedEventArgs(value);

                    OnColourChanged(this, e);
                }
            }
        }
        #endregion

        #region Constructors
        public KryptonARGBColourSliderVertical()
        {
            InitializeComponent();
        }
        #endregion
    }
}