using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonRGBColourSliderHorizontal : UserControl
    {
        private KryptonBlueValueNumericBox knudBlue;
        private KryptonBlueTrackBar ktrkBlue;
        private KryptonGreenTrackBar ktrkGreen;
        private KryptonGreenValueNumericBox knudGreen;
        private KryptonRedTrackBar ktrkRed;
        private KryptonRedValueNumericBox knudRed;
        private KryptonBlueValueLabel klblBlue;
        private KryptonGreenValueLabel klblGreen;
        private KryptonRedValueLabel klblRed;

        private void InitializeComponent()
        {
            this.knudBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueNumericBox();
            this.ktrkBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueTrackBar();
            this.ktrkGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenTrackBar();
            this.knudGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueNumericBox();
            this.ktrkRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedTrackBar();
            this.knudRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueNumericBox();
            this.klblBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueLabel();
            this.SuspendLayout();
            // 
            // knudBlue
            // 
            this.knudBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudBlue.Location = new System.Drawing.Point(407, 102);
            this.knudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlue.Name = "knudBlue";
            this.knudBlue.Size = new System.Drawing.Size(67, 23);
            this.knudBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBlue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBlue.TabIndex = 20;
            this.knudBlue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudBlue.UseAccessibleUI = false;
            // 
            // ktrkBlue
            // 
            this.ktrkBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkBlue.DrawBackground = true;
            this.ktrkBlue.Location = new System.Drawing.Point(148, 104);
            this.ktrkBlue.Maximum = 255;
            this.ktrkBlue.Name = "ktrkBlue";
            this.ktrkBlue.Size = new System.Drawing.Size(253, 21);
            this.ktrkBlue.StateCommon.Tick.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktrkBlue.TabIndex = 19;
            this.ktrkBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkBlue.UseAccessibleUI = false;
            // 
            // ktrkGreen
            // 
            this.ktrkGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkGreen.DrawBackground = true;
            this.ktrkGreen.Location = new System.Drawing.Point(148, 60);
            this.ktrkGreen.Maximum = 255;
            this.ktrkGreen.Name = "ktrkGreen";
            this.ktrkGreen.Size = new System.Drawing.Size(253, 21);
            this.ktrkGreen.StateCommon.Tick.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktrkGreen.TabIndex = 18;
            this.ktrkGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkGreen.UseAccessibleUI = false;
            // 
            // knudGreen
            // 
            this.knudGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudGreen.Location = new System.Drawing.Point(407, 58);
            this.knudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreen.Name = "knudGreen";
            this.knudGreen.Size = new System.Drawing.Size(67, 23);
            this.knudGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudGreen.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudGreen.TabIndex = 17;
            this.knudGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudGreen.UseAccessibleUI = false;
            // 
            // ktrkRed
            // 
            this.ktrkRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkRed.DrawBackground = true;
            this.ktrkRed.Location = new System.Drawing.Point(148, 16);
            this.ktrkRed.Maximum = 255;
            this.ktrkRed.Name = "ktrkRed";
            this.ktrkRed.Size = new System.Drawing.Size(253, 21);
            this.ktrkRed.StateCommon.Tick.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktrkRed.TabIndex = 16;
            this.ktrkRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkRed.UseAccessibleUI = false;
            // 
            // knudRed
            // 
            this.knudRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudRed.Location = new System.Drawing.Point(407, 14);
            this.knudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRed.Name = "knudRed";
            this.knudRed.Size = new System.Drawing.Size(67, 23);
            this.knudRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudRed.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudRed.TabIndex = 15;
            this.knudRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudRed.UseAccessibleUI = false;
            // 
            // klblBlue
            // 
            this.klblBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblBlue.BlueValue = 0;
            this.klblBlue.ExtraText = "Blue Value";
            this.klblBlue.Location = new System.Drawing.Point(9, 104);
            this.klblBlue.Name = "klblBlue";
            this.klblBlue.ShowColon = false;
            this.klblBlue.ShowCurrentColourValue = true;
            this.klblBlue.Size = new System.Drawing.Size(107, 21);
            this.klblBlue.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.klblBlue.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.klblBlue.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlue.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.klblBlue.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.klblBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlue.TabIndex = 14;
            this.klblBlue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlue.UseAccessibleUI = false;
            this.klblBlue.Values.Text = "Blue Value: 0";
            // 
            // klblGreen
            // 
            this.klblGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblGreen.ExtraText = "Green Value";
            this.klblGreen.GreenValue = 0;
            this.klblGreen.Location = new System.Drawing.Point(9, 60);
            this.klblGreen.Name = "klblGreen";
            this.klblGreen.ShowColon = false;
            this.klblGreen.ShowCurrentColourValue = true;
            this.klblGreen.Size = new System.Drawing.Size(119, 21);
            this.klblGreen.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.klblGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.TabIndex = 13;
            this.klblGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.UseAccessibleUI = false;
            this.klblGreen.Values.Text = "Green Value: 0";
            // 
            // klblRed
            // 
            this.klblRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblRed.ExtraText = "Red Value";
            this.klblRed.Location = new System.Drawing.Point(9, 16);
            this.klblRed.Name = "klblRed";
            this.klblRed.RedValue = 0;
            this.klblRed.ShowColon = false;
            this.klblRed.ShowCurrentColourValue = true;
            this.klblRed.Size = new System.Drawing.Size(104, 21);
            this.klblRed.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.klblRed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.TabIndex = 12;
            this.klblRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.UseAccessibleUI = false;
            this.klblRed.Values.Text = "Red Value: 0";
            // 
            // KryptonRGBColourSliderHorizontal
            // 
            this.Controls.Add(this.knudBlue);
            this.Controls.Add(this.ktrkBlue);
            this.Controls.Add(this.ktrkGreen);
            this.Controls.Add(this.knudGreen);
            this.Controls.Add(this.ktrkRed);
            this.Controls.Add(this.knudRed);
            this.Controls.Add(this.klblBlue);
            this.Controls.Add(this.klblGreen);
            this.Controls.Add(this.klblRed);
            this.Name = "KryptonRGBColourSliderHorizontal";
            this.Size = new System.Drawing.Size(483, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}