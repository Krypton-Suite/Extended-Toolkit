using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonRGBColourSliderVertical : UserControl
    {
        private KryptonBlueValueNumericBox kryptonBlueValueNumericBox1;
        private KryptonRedValueNumericBox kryptonRedValueNumericBox1;
        private KryptonGreenValueNumericBox kryptonGreenValueNumericBox1;
        private KryptonGreenTrackBar kryptonGreenTrackBar1;
        private KryptonBlueTrackBar kryptonBlueTrackBar1;
        private KryptonRedTrackBar kryptonRedTrackBar1;
        private KryptonBlueValueLabel klblBlue;
        private KryptonGreenValueLabel klblGreen;
        private KryptonRedValueLabel klblRed;

        private void InitializeComponent()
        {
            this.kryptonBlueValueNumericBox1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueNumericBox();
            this.kryptonRedValueNumericBox1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueNumericBox();
            this.kryptonGreenValueNumericBox1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueNumericBox();
            this.kryptonGreenTrackBar1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenTrackBar();
            this.kryptonBlueTrackBar1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueTrackBar();
            this.kryptonRedTrackBar1 = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedTrackBar();
            this.klblBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueLabel();
            this.SuspendLayout();
            // 
            // kryptonBlueValueNumericBox1
            // 
            this.kryptonBlueValueNumericBox1.Location = new System.Drawing.Point(167, 398);
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
            this.kryptonBlueValueNumericBox1.TabIndex = 20;
            this.kryptonBlueValueNumericBox1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonBlueValueNumericBox1.UseAccessibleUI = false;
            // 
            // kryptonRedValueNumericBox1
            // 
            this.kryptonRedValueNumericBox1.Location = new System.Drawing.Point(3, 398);
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
            this.kryptonRedValueNumericBox1.TabIndex = 19;
            this.kryptonRedValueNumericBox1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRedValueNumericBox1.UseAccessibleUI = false;
            // 
            // kryptonGreenValueNumericBox1
            // 
            this.kryptonGreenValueNumericBox1.Location = new System.Drawing.Point(85, 398);
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
            this.kryptonGreenValueNumericBox1.TabIndex = 18;
            this.kryptonGreenValueNumericBox1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueNumericBox1.UseAccessibleUI = false;
            // 
            // kryptonGreenTrackBar1
            // 
            this.kryptonGreenTrackBar1.DrawBackground = true;
            this.kryptonGreenTrackBar1.Location = new System.Drawing.Point(102, 43);
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
            this.kryptonGreenTrackBar1.TabIndex = 17;
            this.kryptonGreenTrackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kryptonGreenTrackBar1.UseAccessibleUI = false;
            // 
            // kryptonBlueTrackBar1
            // 
            this.kryptonBlueTrackBar1.DrawBackground = true;
            this.kryptonBlueTrackBar1.Location = new System.Drawing.Point(191, 42);
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
            this.kryptonBlueTrackBar1.TabIndex = 16;
            this.kryptonBlueTrackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kryptonBlueTrackBar1.UseAccessibleUI = false;
            // 
            // kryptonRedTrackBar1
            // 
            this.kryptonRedTrackBar1.DrawBackground = true;
            this.kryptonRedTrackBar1.Location = new System.Drawing.Point(20, 42);
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
            this.kryptonRedTrackBar1.TabIndex = 15;
            this.kryptonRedTrackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kryptonRedTrackBar1.UseAccessibleUI = false;
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
            this.Controls.Add(this.kryptonBlueValueNumericBox1);
            this.Controls.Add(this.kryptonRedValueNumericBox1);
            this.Controls.Add(this.kryptonGreenValueNumericBox1);
            this.Controls.Add(this.kryptonGreenTrackBar1);
            this.Controls.Add(this.kryptonBlueTrackBar1);
            this.Controls.Add(this.kryptonRedTrackBar1);
            this.Controls.Add(this.klblBlue);
            this.Controls.Add(this.klblGreen);
            this.Controls.Add(this.klblRed);
            this.Name = "KryptonRGBColourSliderVertical";
            this.Size = new System.Drawing.Size(250, 437);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}