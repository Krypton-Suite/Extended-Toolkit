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
        private Panel panel1;
        private Panel panel2;
        private KryptonBlueValueNumericBox knudBlue;
        private KryptonBlueTrackBar ktrkBlue;
        private KryptonGreenTrackBar ktrkGreen;
        private KryptonGreenValueNumericBox knudGreen;
        private KryptonRedTrackBar ktrkRed;
        private KryptonRedValueNumericBox knudRed;
        private KryptonBlueValueLabel klblBlue;
        private KryptonGreenValueLabel klblGreen;
        private Base.KryptonKnobControl kryptonKnobControl1;
        private Base.KryptonKnobControl kryptonKnobControl3;
        private Base.KryptonKnobControl kryptonKnobControl2;
        private KryptonRedValueLabel klblRed;

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
            this.klblBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueLabel();
            this.kryptonKnobControl1 = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.kryptonKnobControl2 = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.kryptonKnobControl3 = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.kryptonKnobControl3);
            this.panel1.Controls.Add(this.kryptonKnobControl2);
            this.panel1.Controls.Add(this.kryptonKnobControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(492, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(62, 189);
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
            this.panel2.Controls.Add(this.klblBlue);
            this.panel2.Controls.Add(this.klblGreen);
            this.panel2.Controls.Add(this.klblRed);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 189);
            this.panel2.TabIndex = 1;
            // 
            // knudBlue
            // 
            this.knudBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudBlue.Location = new System.Drawing.Point(419, 146);
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
            this.knudBlue.TabIndex = 29;
            this.knudBlue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudBlue.UseAccessibleUI = false;
            // 
            // ktrkBlue
            // 
            this.ktrkBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkBlue.DrawBackground = true;
            this.ktrkBlue.Location = new System.Drawing.Point(142, 149);
            this.ktrkBlue.Maximum = 255;
            this.ktrkBlue.Name = "ktrkBlue";
            this.ktrkBlue.Size = new System.Drawing.Size(271, 21);
            this.ktrkBlue.StateCommon.Tick.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktrkBlue.TabIndex = 28;
            this.ktrkBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkBlue.UseAccessibleUI = false;
            // 
            // ktrkGreen
            // 
            this.ktrkGreen.DrawBackground = true;
            this.ktrkGreen.Location = new System.Drawing.Point(142, 83);
            this.ktrkGreen.Maximum = 255;
            this.ktrkGreen.Name = "ktrkGreen";
            this.ktrkGreen.Size = new System.Drawing.Size(271, 21);
            this.ktrkGreen.StateCommon.Tick.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktrkGreen.TabIndex = 27;
            this.ktrkGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkGreen.UseAccessibleUI = false;
            // 
            // knudGreen
            // 
            this.knudGreen.Location = new System.Drawing.Point(419, 83);
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
            this.knudGreen.TabIndex = 26;
            this.knudGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudGreen.UseAccessibleUI = false;
            // 
            // ktrkRed
            // 
            this.ktrkRed.DrawBackground = true;
            this.ktrkRed.Location = new System.Drawing.Point(142, 22);
            this.ktrkRed.Maximum = 255;
            this.ktrkRed.Name = "ktrkRed";
            this.ktrkRed.Size = new System.Drawing.Size(271, 21);
            this.ktrkRed.StateCommon.Tick.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktrkRed.TabIndex = 25;
            this.ktrkRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkRed.UseAccessibleUI = false;
            // 
            // knudRed
            // 
            this.knudRed.Location = new System.Drawing.Point(419, 20);
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
            this.knudRed.TabIndex = 24;
            this.knudRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudRed.UseAccessibleUI = false;
            // 
            // klblBlue
            // 
            this.klblBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klblBlue.BlueValue = 0;
            this.klblBlue.ExtraText = "Blue Value";
            this.klblBlue.Location = new System.Drawing.Point(3, 149);
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
            this.klblBlue.TabIndex = 23;
            this.klblBlue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlue.UseAccessibleUI = false;
            this.klblBlue.Values.Text = "Blue Value: 0";
            // 
            // klblGreen
            // 
            this.klblGreen.ExtraText = "Green Value";
            this.klblGreen.GreenValue = 0;
            this.klblGreen.Location = new System.Drawing.Point(3, 83);
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
            this.klblGreen.TabIndex = 22;
            this.klblGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.UseAccessibleUI = false;
            this.klblGreen.Values.Text = "Green Value: 0";
            // 
            // klblRed
            // 
            this.klblRed.ExtraText = "Red Value";
            this.klblRed.Location = new System.Drawing.Point(6, 22);
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
            this.klblRed.TabIndex = 21;
            this.klblRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.UseAccessibleUI = false;
            this.klblRed.Values.Text = "Red Value: 0";
            // 
            // kryptonKnobControl1
            // 
            this.kryptonKnobControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonKnobControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonKnobControl1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kryptonKnobControl1.KnobIndicatorBorderColour = System.Drawing.Color.Blue;
            this.kryptonKnobControl1.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControl1.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControl1.LargeChange = 20;
            this.kryptonKnobControl1.Location = new System.Drawing.Point(4, 131);
            this.kryptonKnobControl1.Maximum = 255;
            this.kryptonKnobControl1.Minimum = 0;
            this.kryptonKnobControl1.Name = "kryptonKnobControl1";
            this.kryptonKnobControl1.ShowLargeScale = true;
            this.kryptonKnobControl1.ShowSmallScale = false;
            this.kryptonKnobControl1.Size = new System.Drawing.Size(55, 55);
            this.kryptonKnobControl1.SizeLargeScaleMarker = 6;
            this.kryptonKnobControl1.SizeSmallScaleMarker = 3;
            this.kryptonKnobControl1.SmallChange = 5;
            this.kryptonKnobControl1.TabIndex = 2;
            this.kryptonKnobControl1.Value = 0;
            // 
            // kryptonKnobControl2
            // 
            this.kryptonKnobControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonKnobControl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonKnobControl2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kryptonKnobControl2.KnobIndicatorBorderColour = System.Drawing.Color.Red;
            this.kryptonKnobControl2.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControl2.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControl2.LargeChange = 20;
            this.kryptonKnobControl2.Location = new System.Drawing.Point(4, 3);
            this.kryptonKnobControl2.Maximum = 255;
            this.kryptonKnobControl2.Minimum = 0;
            this.kryptonKnobControl2.Name = "kryptonKnobControl2";
            this.kryptonKnobControl2.ShowLargeScale = true;
            this.kryptonKnobControl2.ShowSmallScale = false;
            this.kryptonKnobControl2.Size = new System.Drawing.Size(55, 55);
            this.kryptonKnobControl2.SizeLargeScaleMarker = 6;
            this.kryptonKnobControl2.SizeSmallScaleMarker = 3;
            this.kryptonKnobControl2.SmallChange = 5;
            this.kryptonKnobControl2.TabIndex = 3;
            this.kryptonKnobControl2.Value = 0;
            // 
            // kryptonKnobControl3
            // 
            this.kryptonKnobControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonKnobControl3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonKnobControl3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kryptonKnobControl3.KnobIndicatorBorderColour = System.Drawing.Color.Green;
            this.kryptonKnobControl3.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControl3.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControl3.LargeChange = 20;
            this.kryptonKnobControl3.Location = new System.Drawing.Point(4, 67);
            this.kryptonKnobControl3.Maximum = 255;
            this.kryptonKnobControl3.Minimum = 0;
            this.kryptonKnobControl3.Name = "kryptonKnobControl3";
            this.kryptonKnobControl3.ShowLargeScale = true;
            this.kryptonKnobControl3.ShowSmallScale = false;
            this.kryptonKnobControl3.Size = new System.Drawing.Size(55, 55);
            this.kryptonKnobControl3.SizeLargeScaleMarker = 6;
            this.kryptonKnobControl3.SizeSmallScaleMarker = 3;
            this.kryptonKnobControl3.SmallChange = 5;
            this.kryptonKnobControl3.TabIndex = 4;
            this.kryptonKnobControl3.Value = 0;
            // 
            // KryptonRGBColourSliderHorizontal
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "KryptonRGBColourSliderHorizontal";
            this.Size = new System.Drawing.Size(554, 189);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #region Constructor
        public KryptonRGBColourSliderHorizontal()
        {
            InitializeComponent();
        }
        #endregion
    }
}