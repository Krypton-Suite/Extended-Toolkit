using Krypton.Toolkit.Extended.Global.Utilities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    [DefaultEvent("ColourChanged"), DefaultProperty("Colour")]
    public class KryptonARGBColourSliderVertical : UserControl
    {
        #region Designer Code
        private Base.KryptonKnobControl kkcAlpha;
        private Base.KryptonKnobControl kkcRed;
        private Base.KryptonKnobControl kkcGreen;
        private Base.KryptonKnobControl kkcBlue;
        private Panel pnlControls;
        private KryptonAlphaValueNumericBox knudAlphaValue;
        private KryptonBlueValueNumericBox knudBlueValue;
        private KryptonRedValueNumericBox knudRedValue;
        private KryptonGreenValueNumericBox knudGreenValue;
        private KryptonGreenTrackBar ktrkGreenValue;
        private KryptonBlueTrackBar ktrkBlueValue;
        private KryptonRedTrackBar ktrkRedValue;
        private KryptonAlphaTrackBar ktrkAlphaValue;
        private KryptonBlueValueLabel klblBlue;
        private KryptonGreenValueLabel klblGreen;
        private KryptonRedValueLabel klblRed;
        private KryptonAlphaValueLabel klblAlpha;
        private Panel pnlKnobs;

        private void InitializeComponent()
        {
            this.kkcBlue = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.kkcGreen = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.kkcRed = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.kkcAlpha = new Krypton.Toolkit.Extended.Base.KryptonKnobControl();
            this.pnlKnobs = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.knudAlphaValue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaValueNumericBox();
            this.knudBlueValue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueNumericBox();
            this.knudRedValue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueNumericBox();
            this.knudGreenValue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueNumericBox();
            this.ktrkGreenValue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenTrackBar();
            this.ktrkBlueValue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueTrackBar();
            this.ktrkRedValue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedTrackBar();
            this.ktrkAlphaValue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaTrackBar();
            this.klblBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueLabel();
            this.klblAlpha = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.pnlKnobs.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // kkcBlue
            // 
            this.kkcBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcBlue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcBlue.KnobIndicatorBorderColour = System.Drawing.Color.Blue;
            this.kkcBlue.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcBlue.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcBlue.LargeChange = 20;
            this.kkcBlue.Location = new System.Drawing.Point(265, 3);
            this.kkcBlue.Maximum = 255;
            this.kkcBlue.Minimum = 0;
            this.kkcBlue.Name = "kkcBlue";
            this.kkcBlue.ShowLargeScale = true;
            this.kkcBlue.ShowSmallScale = false;
            this.kkcBlue.Size = new System.Drawing.Size(57, 56);
            this.kkcBlue.SizeLargeScaleMarker = 6;
            this.kkcBlue.SizeSmallScaleMarker = 3;
            this.kkcBlue.SmallChange = 5;
            this.kkcBlue.TabIndex = 180;
            this.kkcBlue.Value = 0;
            this.kkcBlue.ValueChanged += new Krypton.Toolkit.Extended.Base.ValueChangedEventHandler(this.kkcBlue_ValueChanged);
            // 
            // kkcGreen
            // 
            this.kkcGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcGreen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcGreen.KnobIndicatorBorderColour = System.Drawing.Color.Green;
            this.kkcGreen.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcGreen.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcGreen.LargeChange = 20;
            this.kkcGreen.Location = new System.Drawing.Point(181, 3);
            this.kkcGreen.Maximum = 255;
            this.kkcGreen.Minimum = 0;
            this.kkcGreen.Name = "kkcGreen";
            this.kkcGreen.ShowLargeScale = true;
            this.kkcGreen.ShowSmallScale = false;
            this.kkcGreen.Size = new System.Drawing.Size(57, 56);
            this.kkcGreen.SizeLargeScaleMarker = 6;
            this.kkcGreen.SizeSmallScaleMarker = 3;
            this.kkcGreen.SmallChange = 5;
            this.kkcGreen.TabIndex = 179;
            this.kkcGreen.Value = 0;
            this.kkcGreen.ValueChanged += new Krypton.Toolkit.Extended.Base.ValueChangedEventHandler(this.kkcGreen_ValueChanged);
            // 
            // kkcRed
            // 
            this.kkcRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcRed.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcRed.KnobIndicatorBorderColour = System.Drawing.Color.Red;
            this.kkcRed.KnobIndicatorColourBegin = System.Drawing.Color.Red;
            this.kkcRed.KnobIndicatorColourEnd = System.Drawing.Color.Red;
            this.kkcRed.LargeChange = 20;
            this.kkcRed.Location = new System.Drawing.Point(104, 3);
            this.kkcRed.Maximum = 255;
            this.kkcRed.Minimum = 0;
            this.kkcRed.Name = "kkcRed";
            this.kkcRed.ShowLargeScale = true;
            this.kkcRed.ShowSmallScale = false;
            this.kkcRed.Size = new System.Drawing.Size(57, 56);
            this.kkcRed.SizeLargeScaleMarker = 6;
            this.kkcRed.SizeSmallScaleMarker = 3;
            this.kkcRed.SmallChange = 5;
            this.kkcRed.TabIndex = 178;
            this.kkcRed.Value = 0;
            this.kkcRed.ValueChanged += new Krypton.Toolkit.Extended.Base.ValueChangedEventHandler(this.kkcRed_ValueChanged);
            // 
            // kkcAlpha
            // 
            this.kkcAlpha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcAlpha.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcAlpha.KnobIndicatorBorderColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.kkcAlpha.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcAlpha.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcAlpha.LargeChange = 20;
            this.kkcAlpha.Location = new System.Drawing.Point(15, 3);
            this.kkcAlpha.Maximum = 255;
            this.kkcAlpha.Minimum = 0;
            this.kkcAlpha.Name = "kkcAlpha";
            this.kkcAlpha.ShowLargeScale = true;
            this.kkcAlpha.ShowSmallScale = false;
            this.kkcAlpha.Size = new System.Drawing.Size(57, 56);
            this.kkcAlpha.SizeLargeScaleMarker = 6;
            this.kkcAlpha.SizeSmallScaleMarker = 3;
            this.kkcAlpha.SmallChange = 5;
            this.kkcAlpha.TabIndex = 175;
            this.kkcAlpha.Value = 0;
            this.kkcAlpha.ValueChanged += new Krypton.Toolkit.Extended.Base.ValueChangedEventHandler(this.kkcAlpha_ValueChanged);
            // 
            // pnlKnobs
            // 
            this.pnlKnobs.Controls.Add(this.kkcAlpha);
            this.pnlKnobs.Controls.Add(this.kkcBlue);
            this.pnlKnobs.Controls.Add(this.kkcRed);
            this.pnlKnobs.Controls.Add(this.kkcGreen);
            this.pnlKnobs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlKnobs.Location = new System.Drawing.Point(0, 428);
            this.pnlKnobs.Name = "pnlKnobs";
            this.pnlKnobs.Size = new System.Drawing.Size(341, 63);
            this.pnlKnobs.TabIndex = 181;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.knudAlphaValue);
            this.pnlControls.Controls.Add(this.knudBlueValue);
            this.pnlControls.Controls.Add(this.knudRedValue);
            this.pnlControls.Controls.Add(this.knudGreenValue);
            this.pnlControls.Controls.Add(this.ktrkGreenValue);
            this.pnlControls.Controls.Add(this.ktrkBlueValue);
            this.pnlControls.Controls.Add(this.ktrkRedValue);
            this.pnlControls.Controls.Add(this.ktrkAlphaValue);
            this.pnlControls.Controls.Add(this.klblBlue);
            this.pnlControls.Controls.Add(this.klblGreen);
            this.pnlControls.Controls.Add(this.klblRed);
            this.pnlControls.Controls.Add(this.klblAlpha);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(341, 428);
            this.pnlControls.TabIndex = 182;
            // 
            // knudAlphaValue
            // 
            this.knudAlphaValue.Location = new System.Drawing.Point(14, 394);
            this.knudAlphaValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudAlphaValue.Name = "knudAlphaValue";
            this.knudAlphaValue.Size = new System.Drawing.Size(67, 23);
            this.knudAlphaValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudAlphaValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudAlphaValue.TabIndex = 24;
            this.knudAlphaValue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // knudBlueValue
            // 
            this.knudBlueValue.Location = new System.Drawing.Point(260, 394);
            this.knudBlueValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlueValue.Name = "knudBlueValue";
            this.knudBlueValue.Size = new System.Drawing.Size(67, 23);
            this.knudBlueValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudBlueValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBlueValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBlueValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBlueValue.TabIndex = 23;
            this.knudBlueValue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBlueValue.UseAccessibleUI = false;
            // 
            // knudRedValue
            // 
            this.knudRedValue.Location = new System.Drawing.Point(96, 394);
            this.knudRedValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRedValue.Name = "knudRedValue";
            this.knudRedValue.Size = new System.Drawing.Size(67, 23);
            this.knudRedValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudRedValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudRedValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudRedValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudRedValue.TabIndex = 22;
            this.knudRedValue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudRedValue.UseAccessibleUI = false;
            // 
            // knudGreenValue
            // 
            this.knudGreenValue.Location = new System.Drawing.Point(178, 394);
            this.knudGreenValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreenValue.Name = "knudGreenValue";
            this.knudGreenValue.Size = new System.Drawing.Size(67, 23);
            this.knudGreenValue.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudGreenValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudGreenValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudGreenValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudGreenValue.TabIndex = 21;
            this.knudGreenValue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudGreenValue.UseAccessibleUI = false;
            // 
            // ktrkGreenValue
            // 
            this.ktrkGreenValue.DrawBackground = true;
            this.ktrkGreenValue.Location = new System.Drawing.Point(195, 39);
            this.ktrkGreenValue.Maximum = 255;
            this.ktrkGreenValue.Name = "ktrkGreenValue";
            this.ktrkGreenValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktrkGreenValue.Size = new System.Drawing.Size(21, 349);
            this.ktrkGreenValue.StateCommon.Tick.Color1 = System.Drawing.Color.Green;
            this.ktrkGreenValue.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktrkGreenValue.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktrkGreenValue.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktrkGreenValue.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktrkGreenValue.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktrkGreenValue.TabIndex = 20;
            this.ktrkGreenValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkGreenValue.UseAccessibleUI = false;
            // 
            // ktrkBlueValue
            // 
            this.ktrkBlueValue.DrawBackground = true;
            this.ktrkBlueValue.Location = new System.Drawing.Point(284, 38);
            this.ktrkBlueValue.Maximum = 255;
            this.ktrkBlueValue.Name = "ktrkBlueValue";
            this.ktrkBlueValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktrkBlueValue.Size = new System.Drawing.Size(21, 350);
            this.ktrkBlueValue.StateCommon.Tick.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlueValue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlueValue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktrkBlueValue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktrkBlueValue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktrkBlueValue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktrkBlueValue.TabIndex = 19;
            this.ktrkBlueValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkBlueValue.UseAccessibleUI = false;
            // 
            // ktrkRedValue
            // 
            this.ktrkRedValue.DrawBackground = true;
            this.ktrkRedValue.Location = new System.Drawing.Point(113, 38);
            this.ktrkRedValue.Maximum = 255;
            this.ktrkRedValue.Name = "ktrkRedValue";
            this.ktrkRedValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktrkRedValue.Size = new System.Drawing.Size(21, 350);
            this.ktrkRedValue.StateCommon.Tick.Color1 = System.Drawing.Color.Red;
            this.ktrkRedValue.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktrkRedValue.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktrkRedValue.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktrkRedValue.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktrkRedValue.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktrkRedValue.TabIndex = 18;
            this.ktrkRedValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkRedValue.UseAccessibleUI = false;
            // 
            // ktrkAlphaValue
            // 
            this.ktrkAlphaValue.DrawBackground = true;
            this.ktrkAlphaValue.Location = new System.Drawing.Point(32, 38);
            this.ktrkAlphaValue.Maximum = 255;
            this.ktrkAlphaValue.Name = "ktrkAlphaValue";
            this.ktrkAlphaValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktrkAlphaValue.Size = new System.Drawing.Size(21, 350);
            this.ktrkAlphaValue.TabIndex = 17;
            this.ktrkAlphaValue.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // klblBlue
            // 
            this.klblBlue.BlueValue = 0;
            this.klblBlue.ExtraText = "Blue";
            this.klblBlue.Location = new System.Drawing.Point(272, 11);
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
            this.klblBlue.TabIndex = 16;
            this.klblBlue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlue.UseAccessibleUI = false;
            this.klblBlue.Values.Text = "Blue";
            // 
            // klblGreen
            // 
            this.klblGreen.ExtraText = "Green";
            this.klblGreen.GreenValue = 0;
            this.klblGreen.Location = new System.Drawing.Point(180, 11);
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
            this.klblGreen.TabIndex = 15;
            this.klblGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.UseAccessibleUI = false;
            this.klblGreen.Values.Text = "Green";
            // 
            // klblRed
            // 
            this.klblRed.ExtraText = "Red";
            this.klblRed.Location = new System.Drawing.Point(103, 11);
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
            this.klblRed.TabIndex = 14;
            this.klblRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.UseAccessibleUI = false;
            this.klblRed.Values.Text = "Red";
            // 
            // klblAlpha
            // 
            this.klblAlpha.AlphaValue = 255;
            this.klblAlpha.ExtraText = "Alpha";
            this.klblAlpha.Location = new System.Drawing.Point(14, 11);
            this.klblAlpha.Name = "klblAlpha";
            this.klblAlpha.ShowColon = true;
            this.klblAlpha.ShowCurrentColourValue = false;
            this.klblAlpha.Size = new System.Drawing.Size(53, 21);
            this.klblAlpha.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.TabIndex = 13;
            this.klblAlpha.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.Values.Text = "Alpha";
            // 
            // KryptonARGBColourSliderVertical
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlKnobs);
            this.Name = "KryptonARGBColourSliderVertical";
            this.Size = new System.Drawing.Size(341, 491);
            this.pnlKnobs.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Event
        /// <summary></summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ColourChangedEventArgs"/> instance containing the event data.</param>
        public delegate void ColourChangedEventHandler(object sender, ColourChangedEventArgs e);

        /// <summary>Occurs when [colour changed].</summary>
        public event ColourChangedEventHandler ColourChanged;

        /// <summary>Called when [colour changed].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ColourChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnColourChanged(object sender, ColourChangedEventArgs e) => ColourChanged?.Invoke(sender, e);

        /// <summary></summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ColourHexadecimalValuesEventArgs"/> instance containing the event data.</param>
        public delegate void ColourHexadecimalValuesChangedEventHandler(object sender, ColourHexadecimalValuesEventArgs e);

        /// <summary>Occurs when [colour hexadecimal values changed].</summary>
        public event ColourHexadecimalValuesChangedEventHandler ColourHexadecimalValuesChanged;

        /// <summary>Called when [colour hexadecimal values changed].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ColourHexadecimalValuesEventArgs"/> instance containing the event data.</param>
        public virtual void OnColourHexadecimalValuesChanged(object sender, ColourHexadecimalValuesEventArgs e) => ColourHexadecimalValuesChanged?.Invoke(sender, e);
        #endregion

        #region Variables
        private bool _useAccessibleUI, _useKnobs;

        private int _alphaChannelValue, _redChannelValue, _greenChannelValue, _blueChannelValue;

        private byte _trueAlphaChannelValue, _trueRedChannelValue, _trueGreenChannelValue, _trueBlueChannelValue;

        private Color _colour, _trueColour;

        private string _colourHexadecimalValue;

        private KryptonPalette _palette;
        #endregion

        #region Property
        [DefaultValue(false)]
        public bool UseAccessibleUI { get => _useAccessibleUI; set { _useAccessibleUI = value; Invalidate(); } }

        [DefaultValue(false)]
        public bool UseKnobs { get => _useKnobs; set { _useKnobs = value; Invalidate(); } }

        public byte TrueAlphaChannelValue { get => _trueAlphaChannelValue; private set => _trueAlphaChannelValue = value; }

        public byte TrueRedChannelValue { get => _trueRedChannelValue; private set => _trueRedChannelValue = value; }

        public byte TrueGreenChannelValue { get => _trueGreenChannelValue; private set => _trueGreenChannelValue = value; }

        public byte TrueBlueChannelValue { get => _trueBlueChannelValue; private set => _trueBlueChannelValue = value; }

        [DefaultValue(255)]
        public int AlphaChannelValue { get => _alphaChannelValue; set { _alphaChannelValue = value; Invalidate(); } }

        [DefaultValue(0)]
        public int RedChannelValue { get => _redChannelValue; set { _redChannelValue = value; Invalidate(); } }

        [DefaultValue(0)]
        public int GreenChannelValue { get => _greenChannelValue; set { _greenChannelValue = value; Invalidate(); } }

        [DefaultValue(0)]
        public int BlueChannelValue { get => _blueChannelValue; set { _blueChannelValue = value; Invalidate(); } }

        [DefaultValue(null)]
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

        public Color TrueColour { get => _trueColour; private set => _trueColour = value; }

        [DefaultValue("#000000")]
        public string ColourHexadecimalValue
        {
            get => _colourHexadecimalValue;

            set
            {
                _colourHexadecimalValue = value;

                ColourHexadecimalValuesEventArgs e = new ColourHexadecimalValuesEventArgs(value);

                OnColourHexadecimalValuesChanged(this, e);
            }
        }
        #endregion

        #region Constructors
        public KryptonARGBColourSliderVertical()
        {
            InitializeComponent();

            AlphaChannelValue = 255;
        }
        #endregion

        #region Methods
        private void MixColour(byte alphaChannelValue, byte redChannelValue, byte greenChannelValue, byte blueChannelValue) => Colour = Color.FromArgb(alphaChannelValue, redChannelValue, greenChannelValue, blueChannelValue);

        private void UpdateTrueValues(byte alphaChannelValue, byte redChannelValue, byte greenChannelValue, byte blueChannelValue)
        {
            TrueAlphaChannelValue = alphaChannelValue;

            TrueRedChannelValue = redChannelValue;

            TrueGreenChannelValue = greenChannelValue;

            TrueBlueChannelValue = blueChannelValue;

            TrueColour = Color.FromArgb(alphaChannelValue, redChannelValue, greenChannelValue, blueChannelValue);
        }

        private void TearDownColour(Color colour)
        {
            AlphaChannelValue = colour.A;

            RedChannelValue = colour.R;

            GreenChannelValue = colour.G;

            BlueChannelValue = colour.B;
        }

        private void AlterControlUI(bool useKnobs)
        {
            if (useKnobs)
            {
                //Size = new Size(341, 491);

                GlobalMethodsStatic.AnchorSelectedControl(klblAlpha, AnchorStyles.Top | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(ktrkAlphaValue, AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(knudAlphaValue, AnchorStyles.Bottom | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(kkcAlpha, AnchorStyles.Bottom | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(klblRed, AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

                GlobalMethodsStatic.AnchorSelectedControl(ktrkRedValue, AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);

                GlobalMethodsStatic.AnchorSelectedControl(knudRedValue, AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(kkcRed, AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(klblGreen, AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

                GlobalMethodsStatic.AnchorSelectedControl(ktrkGreenValue, AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);

                GlobalMethodsStatic.AnchorSelectedControl(knudGreenValue, AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(kkcGreen, AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(klblBlue, AnchorStyles.Right | AnchorStyles.Top);

                GlobalMethodsStatic.AnchorSelectedControl(ktrkBlueValue, AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);

                GlobalMethodsStatic.AnchorSelectedControl(knudBlueValue, AnchorStyles.Bottom | AnchorStyles.Right);

                GlobalMethodsStatic.AnchorSelectedControl(kkcBlue, AnchorStyles.Bottom | AnchorStyles.Right);

                pnlKnobs.Visible = true;
            }
            else
            {
                //Size = new Size(341, 437);

                GlobalMethodsStatic.AnchorSelectedControl(klblAlpha, AnchorStyles.Top | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(ktrkAlphaValue, AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(knudAlphaValue, AnchorStyles.Bottom | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(klblRed, AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

                GlobalMethodsStatic.AnchorSelectedControl(ktrkRedValue, AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);

                GlobalMethodsStatic.AnchorSelectedControl(knudRedValue, AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(klblGreen, AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

                GlobalMethodsStatic.AnchorSelectedControl(ktrkGreenValue, AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);

                GlobalMethodsStatic.AnchorSelectedControl(knudGreenValue, AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);

                GlobalMethodsStatic.AnchorSelectedControl(klblBlue, AnchorStyles.Right | AnchorStyles.Top);

                GlobalMethodsStatic.AnchorSelectedControl(ktrkBlueValue, AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);

                GlobalMethodsStatic.AnchorSelectedControl(knudBlueValue, AnchorStyles.Bottom | AnchorStyles.Right);

                pnlKnobs.Visible = false;
            }
        }

        private void ChangeUseAccessibleUI(bool value)
        {
            klblRed.UseAccessibleUI = value;

            ktrkRedValue.UseAccessibleUI = value;

            knudRedValue.UseAccessibleUI = value;

            klblGreen.UseAccessibleUI = value;

            ktrkGreenValue.UseAccessibleUI = value;

            knudGreenValue.UseAccessibleUI = value;

            klblBlue.UseAccessibleUI = value;

            ktrkBlueValue.UseAccessibleUI = value;

            knudBlueValue.UseAccessibleUI = value;

            // TODO: Knob dials
            if (value)
            {
                kkcRed.KnobIndicatorBorderColour = _palette.ColorTable.ToolStripGradientBegin;

                kkcGreen.KnobIndicatorBorderColour = _palette.ColorTable.ToolStripGradientBegin;

                kkcBlue.KnobIndicatorBorderColour = _palette.ColorTable.ToolStripGradientBegin;
            }
            else
            {
                kkcRed.KnobIndicatorBorderColour = Color.Red;

                kkcGreen.KnobIndicatorBorderColour = Color.Green;

                kkcBlue.KnobIndicatorBorderColour = Color.Blue;
            }
        }

        /// <summary>Updates the control values.</summary>
        /// <param name="alphaChannelValue">The alpha channel value.</param>
        /// <param name="redChannelValue">The red channel value.</param>
        /// <param name="greenChannelValue">The green channel value.</param>
        /// <param name="blueChannelValue">The blue channel value.</param>
        private void UpdateControlValues(int alphaChannelValue, int redChannelValue, int greenChannelValue, int blueChannelValue)
        {
            ktrkAlphaValue.Value = alphaChannelValue;

            knudAlphaValue.Value = alphaChannelValue;

            kkcAlpha.Value = alphaChannelValue;


            ktrkRedValue.Value = redChannelValue;

            knudRedValue.Value = redChannelValue;

            kkcRed.Value = redChannelValue;


            ktrkGreenValue.Value = greenChannelValue;

            knudGreenValue.Value = greenChannelValue;

            kkcGreen.Value = greenChannelValue;


            ktrkBlueValue.Value = blueChannelValue;

            knudBlueValue.Value = blueChannelValue;

            kkcBlue.Value = blueChannelValue;
        }
        #endregion

        #region Event Handlers
        private void ktrkAlphaValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ktrkRedValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ktrkGreenValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ktrkBlueValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void knudAlphaValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void knudRedValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void knudGreenValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void knudBlueValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void kkcAlpha_ValueChanged(object Sender)
        {

        }

        private void kkcRed_ValueChanged(object Sender)
        {

        }

        private void kkcGreen_ValueChanged(object Sender)
        {

        }

        private void kkcBlue_ValueChanged(object Sender)
        {

        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            //MixColour((byte)_alphaChannelValue, (byte)_redChannelValue, (byte)_greenChannelValue, (byte)_blueChannelValue);

            AlterControlUI(_useKnobs);

            //ChangeUseAccessibleUI(_useAccessibleUI);

            //if (_colour != Color.Empty) TearDownColour(_colour);

            UpdateControlValues(_alphaChannelValue, _redChannelValue, _greenChannelValue, _blueChannelValue);

            base.OnPaint(e);
        }
        #endregion
    }
}