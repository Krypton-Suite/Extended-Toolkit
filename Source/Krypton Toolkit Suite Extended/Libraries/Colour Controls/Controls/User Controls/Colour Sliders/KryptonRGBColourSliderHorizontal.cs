using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Colour.Controls
{
    [DefaultEvent("ColourChanged"), DefaultProperty("Colour")]
    public class KryptonRGBColourSliderHorizontal : UserControl
    {
        #region Design Code
        private Panel panel1;
        private Panel panel2;
        private Base.KryptonKnobControl kkcGreen;
        private Panel panel7;
        private Panel panel6;
        private Base.KryptonKnobControl kkcBlue;
        private KryptonGreenTrackBar ktrkGreen;
        private KryptonGreenValueNumericBox knudGreen;
        private KryptonGreenValueLabel klblGreen;
        private KryptonRedTrackBar ktrkRed;
        private KryptonRedValueNumericBox knudRed;
        private KryptonRedValueLabel klblRed;
        private KryptonBlueTrackBar ktrkBlue;
        private KryptonBlueValueLabel klblBlue;
        private Panel panel8;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private KryptonBlueValueNumericBox kryptonBlueValueNumericBox1;
        private Base.KryptonKnobControl kkcRed;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonRGBColourSliderHorizontal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.kkcGreen = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.kkcRed = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.kkcBlue = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ktrkGreen = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonGreenTrackBar();
            this.knudGreen = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonGreenValueNumericBox();
            this.klblGreen = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.ktrkRed = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonRedTrackBar();
            this.knudRed = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonRedValueNumericBox();
            this.klblRed = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonRedValueLabel();
            this.ktrkBlue = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonBlueTrackBar();
            this.klblBlue = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.kryptonBlueValueNumericBox1 = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonBlueValueNumericBox();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(341, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(62, 189);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.kkcGreen);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 58);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(62, 73);
            this.panel8.TabIndex = 7;
            // 
            // kkcGreen
            // 
            this.kkcGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kkcGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcGreen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcGreen.KnobIndicatorBorderColour = System.Drawing.Color.Green;
            this.kkcGreen.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcGreen.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcGreen.LargeChange = 20;
            this.kkcGreen.Location = new System.Drawing.Point(4, 6);
            this.kkcGreen.Maximum = 255;
            this.kkcGreen.Minimum = 0;
            this.kkcGreen.Name = "kkcGreen";
            this.kkcGreen.ShowLargeScale = true;
            this.kkcGreen.ShowSmallScale = false;
            this.kkcGreen.Size = new System.Drawing.Size(55, 55);
            this.kkcGreen.SizeLargeScaleMarker = 6;
            this.kkcGreen.SizeSmallScaleMarker = 3;
            this.kkcGreen.SmallChange = 5;
            this.kkcGreen.TabIndex = 4;
            this.kkcGreen.Value = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.kkcRed);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(62, 58);
            this.panel7.TabIndex = 6;
            // 
            // kkcRed
            // 
            this.kkcRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kkcRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcRed.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcRed.KnobIndicatorBorderColour = System.Drawing.Color.Red;
            this.kkcRed.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcRed.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcRed.LargeChange = 20;
            this.kkcRed.Location = new System.Drawing.Point(0, 0);
            this.kkcRed.Maximum = 255;
            this.kkcRed.Minimum = 0;
            this.kkcRed.Name = "kkcRed";
            this.kkcRed.ShowLargeScale = true;
            this.kkcRed.ShowSmallScale = false;
            this.kkcRed.Size = new System.Drawing.Size(62, 58);
            this.kkcRed.SizeLargeScaleMarker = 6;
            this.kkcRed.SizeSmallScaleMarker = 3;
            this.kkcRed.SmallChange = 5;
            this.kkcRed.TabIndex = 3;
            this.kkcRed.Value = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.kkcBlue);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 131);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(62, 58);
            this.panel6.TabIndex = 5;
            // 
            // kkcBlue
            // 
            this.kkcBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kkcBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkcBlue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkcBlue.KnobIndicatorBorderColour = System.Drawing.Color.Blue;
            this.kkcBlue.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcBlue.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkcBlue.LargeChange = 20;
            this.kkcBlue.Location = new System.Drawing.Point(0, 0);
            this.kkcBlue.Maximum = 255;
            this.kkcBlue.Minimum = 0;
            this.kkcBlue.Name = "kkcBlue";
            this.kkcBlue.ShowLargeScale = true;
            this.kkcBlue.ShowSmallScale = false;
            this.kkcBlue.Size = new System.Drawing.Size(62, 58);
            this.kkcBlue.SizeLargeScaleMarker = 6;
            this.kkcBlue.SizeSmallScaleMarker = 3;
            this.kkcBlue.SmallChange = 5;
            this.kkcBlue.TabIndex = 5;
            this.kkcBlue.Value = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 189);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ktrkRed);
            this.panel4.Controls.Add(this.knudRed);
            this.panel4.Controls.Add(this.klblRed);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(341, 58);
            this.panel4.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ktrkGreen);
            this.panel5.Controls.Add(this.knudGreen);
            this.panel5.Controls.Add(this.klblGreen);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 58);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(341, 73);
            this.panel5.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.kryptonBlueValueNumericBox1);
            this.panel3.Controls.Add(this.ktrkBlue);
            this.panel3.Controls.Add(this.klblBlue);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(341, 58);
            this.panel3.TabIndex = 28;
            // 
            // ktrkGreen
            // 
            this.ktrkGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkGreen.DrawBackground = true;
            this.ktrkGreen.Location = new System.Drawing.Point(144, 25);
            this.ktrkGreen.Maximum = 255;
            this.ktrkGreen.Name = "ktrkGreen";
            this.ktrkGreen.Size = new System.Drawing.Size(120, 21);
            this.ktrkGreen.StateCommon.Tick.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktrkGreen.TabIndex = 30;
            this.ktrkGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkGreen.UseAccessibleUI = false;
            // 
            // knudGreen
            // 
            this.knudGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.knudGreen.Location = new System.Drawing.Point(270, 25);
            this.knudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreen.Name = "knudGreen";
            this.knudGreen.Size = new System.Drawing.Size(65, 23);
            this.knudGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudGreen.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudGreen.TabIndex = 29;
            this.knudGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudGreen.UseAccessibleUI = false;
            // 
            // klblGreen
            // 
            this.klblGreen.ExtraText = "Green Value";
            this.klblGreen.GreenValue = 0;
            this.klblGreen.Location = new System.Drawing.Point(5, 25);
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
            this.klblGreen.TabIndex = 28;
            this.klblGreen.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.UseAccessibleUI = false;
            this.klblGreen.Values.Text = "Green Value: 0";
            // 
            // ktrkRed
            // 
            this.ktrkRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkRed.DrawBackground = true;
            this.ktrkRed.Location = new System.Drawing.Point(142, 20);
            this.ktrkRed.Maximum = 255;
            this.ktrkRed.Name = "ktrkRed";
            this.ktrkRed.Size = new System.Drawing.Size(120, 21);
            this.ktrkRed.StateCommon.Tick.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktrkRed.TabIndex = 28;
            this.ktrkRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkRed.UseAccessibleUI = false;
            // 
            // knudRed
            // 
            this.knudRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudRed.Location = new System.Drawing.Point(270, 18);
            this.knudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRed.Name = "knudRed";
            this.knudRed.Size = new System.Drawing.Size(65, 23);
            this.knudRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudRed.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudRed.TabIndex = 27;
            this.knudRed.ToolTipValues.Description = "";
            this.knudRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudRed.UseAccessibleUI = false;
            // 
            // klblRed
            // 
            this.klblRed.ExtraText = "Red Value";
            this.klblRed.Location = new System.Drawing.Point(6, 20);
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
            this.klblRed.TabIndex = 26;
            this.klblRed.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.UseAccessibleUI = false;
            this.klblRed.Values.Text = "Red Value: 0";
            // 
            // ktrkBlue
            // 
            this.ktrkBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkBlue.DrawBackground = true;
            this.ktrkBlue.Location = new System.Drawing.Point(144, 20);
            this.ktrkBlue.Maximum = 255;
            this.ktrkBlue.Name = "ktrkBlue";
            this.ktrkBlue.Size = new System.Drawing.Size(120, 21);
            this.ktrkBlue.StateCommon.Tick.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktrkBlue.TabIndex = 31;
            this.ktrkBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkBlue.UseAccessibleUI = false;
            // 
            // klblBlue
            // 
            this.klblBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klblBlue.BlueValue = 0;
            this.klblBlue.ExtraText = "Blue Value";
            this.klblBlue.Location = new System.Drawing.Point(5, 20);
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
            this.klblBlue.TabIndex = 30;
            this.klblBlue.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlue.UseAccessibleUI = false;
            this.klblBlue.Values.Text = "Blue Value: 0";
            // 
            // kryptonBlueValueNumericBox1
            // 
            this.kryptonBlueValueNumericBox1.Location = new System.Drawing.Point(270, 20);
            this.kryptonBlueValueNumericBox1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonBlueValueNumericBox1.Name = "kryptonBlueValueNumericBox1";
            this.kryptonBlueValueNumericBox1.Size = new System.Drawing.Size(65, 22);
            this.kryptonBlueValueNumericBox1.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueNumericBox1.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonBlueValueNumericBox1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonBlueValueNumericBox1.TabIndex = 33;
            this.kryptonBlueValueNumericBox1.ToolTipValues.Description = "The blue value";
            this.kryptonBlueValueNumericBox1.ToolTipValues.EnableToolTips = true;
            this.kryptonBlueValueNumericBox1.ToolTipValues.Heading = "Blue Value";
            this.kryptonBlueValueNumericBox1.ToolTipValues.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.kryptonBlueValueNumericBox1.Typeface = null;
            this.kryptonBlueValueNumericBox1.UseAccessibleUI = false;
            // 
            // KryptonRGBColourSliderHorizontal
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "KryptonRGBColourSliderHorizontal";
            this.Size = new System.Drawing.Size(403, 189);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variable
        private Color _colour;
        #endregion

        #region Properties
        public Color Colour
        {
            get => _colour;

            set
            {
                _colour = value;

                ColourChangedEventArgs e = new ColourChangedEventArgs(value);

                OnColourChanged(this, e);
            }
        }
        #endregion

        #region Event
        public delegate void ColourChangedEventHandler(object sender, ColourChangedEventArgs e);

        public event ColourChangedEventHandler ColourChanged;

        protected virtual void OnColourChanged(object sender, ColourChangedEventArgs e) => ColourChanged?.Invoke(sender, e);
        #endregion

        #region Constructor
        public KryptonRGBColourSliderHorizontal()
        {
            InitializeComponent();
        }
        #endregion
    }
}