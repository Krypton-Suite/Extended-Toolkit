using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonARGBColourSliderHorizontal : UserControl
    {
        private Panel panel1;
        private Panel panel2;
        private KryptonBlueValueNumericBox knudBlue;
        private KryptonBlueTrackBar ktrkBlue;
        private KryptonGreenTrackBar ktrkGreen;
        private KryptonGreenValueNumericBox knudGreen;
        private KryptonRedTrackBar ktrkRed;
        private KryptonRedValueNumericBox knudRed;
        private KryptonAlphaTrackBar ktrkAlpha;
        private KryptonAlphaValueNumericBox knudAlpha;
        private KryptonBlueValueLabel klblBlue;
        private KryptonGreenValueLabel klblGreen;
        private KryptonRedValueLabel klblRed;
        private Base.KryptonKnobControl kkcAlpha;
        private Base.KryptonKnobControl kkcRed;
        private Base.KryptonKnobControl kkcGreen;
        private Base.KryptonKnobControl kkcBlue;
        private KryptonAlphaValueLabel klblAlpha;
        #region Design Code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.knudBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueNumericBox();
            this.ktrkBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueTrackBar();
            this.ktrkGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenTrackBar();
            this.knudGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueNumericBox();
            this.ktrkRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedTrackBar();
            this.knudRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueNumericBox();
            this.ktrkAlpha = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaTrackBar();
            this.knudAlpha = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaValueNumericBox();
            this.klblBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueLabel();
            this.klblAlpha = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.kkcAlpha = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.kkcRed = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.kkcGreen = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.kkcBlue = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.kkcBlue);
            this.panel1.Controls.Add(this.kkcGreen);
            this.panel1.Controls.Add(this.kkcRed);
            this.panel1.Controls.Add(this.kkcAlpha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(489, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 251);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.knudBlue);
            this.panel2.Controls.Add(this.ktrkBlue);
            this.panel2.Controls.Add(this.ktrkGreen);
            this.panel2.Controls.Add(this.knudGreen);
            this.panel2.Controls.Add(this.ktrkRed);
            this.panel2.Controls.Add(this.knudRed);
            this.panel2.Controls.Add(this.ktrkAlpha);
            this.panel2.Controls.Add(this.knudAlpha);
            this.panel2.Controls.Add(this.klblBlue);
            this.panel2.Controls.Add(this.klblGreen);
            this.panel2.Controls.Add(this.klblRed);
            this.panel2.Controls.Add(this.klblAlpha);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(489, 251);
            this.panel2.TabIndex = 1;
            // 
            // knudBlue
            // 
            this.knudBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudBlue.Location = new System.Drawing.Point(411, 204);
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
            this.knudBlue.TabIndex = 23;
            this.knudBlue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudBlue.UseAccessibleUI = false;
            // 
            // ktrkBlue
            // 
            this.ktrkBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkBlue.DrawBackground = true;
            this.ktrkBlue.Location = new System.Drawing.Point(152, 204);
            this.ktrkBlue.Maximum = 255;
            this.ktrkBlue.Name = "ktrkBlue";
            this.ktrkBlue.Size = new System.Drawing.Size(253, 21);
            this.ktrkBlue.StateCommon.Tick.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktrkBlue.TabIndex = 22;
            this.ktrkBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkBlue.UseAccessibleUI = false;
            // 
            // ktrkGreen
            // 
            this.ktrkGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkGreen.DrawBackground = true;
            this.ktrkGreen.Location = new System.Drawing.Point(152, 145);
            this.ktrkGreen.Maximum = 255;
            this.ktrkGreen.Name = "ktrkGreen";
            this.ktrkGreen.Size = new System.Drawing.Size(253, 21);
            this.ktrkGreen.StateCommon.Tick.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktrkGreen.TabIndex = 21;
            this.ktrkGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkGreen.UseAccessibleUI = false;
            // 
            // knudGreen
            // 
            this.knudGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudGreen.Location = new System.Drawing.Point(411, 145);
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
            this.knudGreen.TabIndex = 20;
            this.knudGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudGreen.UseAccessibleUI = false;
            // 
            // ktrkRed
            // 
            this.ktrkRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkRed.DrawBackground = true;
            this.ktrkRed.Location = new System.Drawing.Point(152, 81);
            this.ktrkRed.Maximum = 255;
            this.ktrkRed.Name = "ktrkRed";
            this.ktrkRed.Size = new System.Drawing.Size(253, 21);
            this.ktrkRed.StateCommon.Tick.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktrkRed.TabIndex = 19;
            this.ktrkRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkRed.UseAccessibleUI = false;
            // 
            // knudRed
            // 
            this.knudRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudRed.Location = new System.Drawing.Point(411, 81);
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
            this.knudRed.TabIndex = 18;
            this.knudRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudRed.UseAccessibleUI = false;
            // 
            // ktrkAlpha
            // 
            this.ktrkAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkAlpha.DrawBackground = true;
            this.ktrkAlpha.Location = new System.Drawing.Point(152, 17);
            this.ktrkAlpha.Maximum = 255;
            this.ktrkAlpha.Name = "ktrkAlpha";
            this.ktrkAlpha.Size = new System.Drawing.Size(253, 21);
            this.ktrkAlpha.TabIndex = 17;
            this.ktrkAlpha.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // knudAlpha
            // 
            this.knudAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudAlpha.Location = new System.Drawing.Point(411, 15);
            this.knudAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudAlpha.Name = "knudAlpha";
            this.knudAlpha.Size = new System.Drawing.Size(67, 23);
            this.knudAlpha.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudAlpha.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudAlpha.TabIndex = 16;
            this.knudAlpha.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            // 
            // klblBlue
            // 
            this.klblBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblBlue.BlueValue = 0;
            this.klblBlue.ExtraText = "Blue Value";
            this.klblBlue.Location = new System.Drawing.Point(13, 204);
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
            this.klblBlue.TabIndex = 15;
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
            this.klblGreen.Location = new System.Drawing.Point(13, 145);
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
            this.klblGreen.TabIndex = 14;
            this.klblGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.UseAccessibleUI = false;
            this.klblGreen.Values.Text = "Green Value: 0";
            // 
            // klblRed
            // 
            this.klblRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblRed.ExtraText = "Red Value";
            this.klblRed.Location = new System.Drawing.Point(13, 81);
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
            this.klblRed.TabIndex = 13;
            this.klblRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.UseAccessibleUI = false;
            this.klblRed.Values.Text = "Red Value: 0";
            // 
            // klblAlpha
            // 
            this.klblAlpha.AlphaValue = 0;
            this.klblAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblAlpha.ExtraText = "Alpha Value";
            this.klblAlpha.Location = new System.Drawing.Point(13, 15);
            this.klblAlpha.Name = "klblAlpha";
            this.klblAlpha.ShowColon = false;
            this.klblAlpha.ShowCurrentColourValue = true;
            this.klblAlpha.Size = new System.Drawing.Size(115, 21);
            this.klblAlpha.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.TabIndex = 12;
            this.klblAlpha.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.Values.Text = "Alpha Value: 0";
            // 
            // kkcAlpha
            // 
            this.kkcAlpha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcAlpha.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcAlpha.KnobIndicatorBorderColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.kkcAlpha.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcAlpha.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcAlpha.LargeChange = 20;
            this.kkcAlpha.Location = new System.Drawing.Point(3, 3);
            this.kkcAlpha.Maximum = 255;
            this.kkcAlpha.Minimum = 0;
            this.kkcAlpha.Name = "kkcAlpha";
            this.kkcAlpha.ShowLargeScale = true;
            this.kkcAlpha.ShowSmallScale = false;
            this.kkcAlpha.Size = new System.Drawing.Size(57, 56);
            this.kkcAlpha.SizeLargeScaleMarker = 6;
            this.kkcAlpha.SizeSmallScaleMarker = 3;
            this.kkcAlpha.SmallChange = 5;
            this.kkcAlpha.TabIndex = 176;
            this.kkcAlpha.Value = 0;
            // 
            // kkcRed
            // 
            this.kkcRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcRed.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcRed.KnobIndicatorBorderColour = System.Drawing.Color.Red;
            this.kkcRed.KnobIndicatorColourBegin = System.Drawing.Color.Red;
            this.kkcRed.KnobIndicatorColourEnd = System.Drawing.Color.Red;
            this.kkcRed.LargeChange = 20;
            this.kkcRed.Location = new System.Drawing.Point(3, 65);
            this.kkcRed.Maximum = 255;
            this.kkcRed.Minimum = 0;
            this.kkcRed.Name = "kkcRed";
            this.kkcRed.ShowLargeScale = true;
            this.kkcRed.ShowSmallScale = false;
            this.kkcRed.Size = new System.Drawing.Size(57, 56);
            this.kkcRed.SizeLargeScaleMarker = 6;
            this.kkcRed.SizeSmallScaleMarker = 3;
            this.kkcRed.SmallChange = 5;
            this.kkcRed.TabIndex = 179;
            this.kkcRed.Value = 0;
            // 
            // kkcGreen
            // 
            this.kkcGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcGreen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcGreen.KnobIndicatorBorderColour = System.Drawing.Color.Green;
            this.kkcGreen.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcGreen.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcGreen.LargeChange = 20;
            this.kkcGreen.Location = new System.Drawing.Point(3, 127);
            this.kkcGreen.Maximum = 255;
            this.kkcGreen.Minimum = 0;
            this.kkcGreen.Name = "kkcGreen";
            this.kkcGreen.ShowLargeScale = true;
            this.kkcGreen.ShowSmallScale = false;
            this.kkcGreen.Size = new System.Drawing.Size(57, 56);
            this.kkcGreen.SizeLargeScaleMarker = 6;
            this.kkcGreen.SizeSmallScaleMarker = 3;
            this.kkcGreen.SmallChange = 5;
            this.kkcGreen.TabIndex = 180;
            this.kkcGreen.Value = 0;
            // 
            // kkcBlue
            // 
            this.kkcBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcBlue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcBlue.KnobIndicatorBorderColour = System.Drawing.Color.Blue;
            this.kkcBlue.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcBlue.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcBlue.LargeChange = 20;
            this.kkcBlue.Location = new System.Drawing.Point(3, 189);
            this.kkcBlue.Maximum = 255;
            this.kkcBlue.Minimum = 0;
            this.kkcBlue.Name = "kkcBlue";
            this.kkcBlue.ShowLargeScale = true;
            this.kkcBlue.ShowSmallScale = false;
            this.kkcBlue.Size = new System.Drawing.Size(57, 56);
            this.kkcBlue.SizeLargeScaleMarker = 6;
            this.kkcBlue.SizeSmallScaleMarker = 3;
            this.kkcBlue.SmallChange = 5;
            this.kkcBlue.TabIndex = 181;
            this.kkcBlue.Value = 0;
            // 
            // KryptonARGBColourSliderHorizontal
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "KryptonARGBColourSliderHorizontal";
            this.Size = new System.Drawing.Size(553, 251);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}