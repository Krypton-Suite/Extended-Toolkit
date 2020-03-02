using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonRGBColourSlider : UserControl
    {
        #region Designer Code
        private KryptonBlueTrackBar ktrkBlue;
        private KryptonGreenTrackBar ktrkGreen;
        private KryptonRedTrackBar ktrkRed;
        private KryptonBlueValueLabel kryptonBlueValueLabel1;
        private KryptonGreenValueLabel kryptonGreenValueLabel1;
        private KryptonBlueValueNumericBox knumBlue;
        private KryptonGreenValueNumericBox knumGreen;
        private KryptonRedValueNumericBox knumRed;
        private KryptonRedValueLabel kryptonRedValueLabel1;

        private void InitializeComponent()
        {
            this.ktrkBlue = new KryptonBlueTrackBar();
            this.ktrkGreen = new KryptonGreenTrackBar();
            this.ktrkRed = new KryptonRedTrackBar();
            this.kryptonBlueValueLabel1 = new KryptonBlueValueLabel();
            this.kryptonGreenValueLabel1 = new KryptonGreenValueLabel();
            this.kryptonRedValueLabel1 = new KryptonRedValueLabel();
            this.knumBlue = new KryptonBlueValueNumericBox();
            this.knumGreen = new KryptonGreenValueNumericBox();
            this.knumRed = new KryptonRedValueNumericBox();
            this.SuspendLayout();
            // 
            // ktrkBlue
            // 
            this.ktrkBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkBlue.DrawBackground = true;
            this.ktrkBlue.Location = new System.Drawing.Point(246, 47);
            this.ktrkBlue.Maximum = 255;
            this.ktrkBlue.Name = "ktrkBlue";
            this.ktrkBlue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktrkBlue.Size = new System.Drawing.Size(21, 344);
            this.ktrkBlue.StateCommon.Tick.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktrkBlue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktrkBlue.TabIndex = 17;
            this.ktrkBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkBlue.Value = 255;
            this.ktrkBlue.ValueChanged += new System.EventHandler(this.ktrkBlue_ValueChanged);
            // 
            // ktrkGreen
            // 
            this.ktrkGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkGreen.DrawBackground = true;
            this.ktrkGreen.Location = new System.Drawing.Point(137, 47);
            this.ktrkGreen.Maximum = 255;
            this.ktrkGreen.Name = "ktrkGreen";
            this.ktrkGreen.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktrkGreen.Size = new System.Drawing.Size(21, 344);
            this.ktrkGreen.StateCommon.Tick.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktrkGreen.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktrkGreen.TabIndex = 16;
            this.ktrkGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkGreen.Value = 255;
            this.ktrkGreen.ValueChanged += new System.EventHandler(this.ktrkGreen_ValueChanged);
            // 
            // ktrkRed
            // 
            this.ktrkRed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktrkRed.DrawBackground = true;
            this.ktrkRed.Location = new System.Drawing.Point(31, 47);
            this.ktrkRed.Maximum = 255;
            this.ktrkRed.Name = "ktrkRed";
            this.ktrkRed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktrkRed.Size = new System.Drawing.Size(21, 344);
            this.ktrkRed.StateCommon.Tick.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktrkRed.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktrkRed.TabIndex = 15;
            this.ktrkRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktrkRed.Value = 255;
            this.ktrkRed.ValueChanged += new System.EventHandler(this.ktrkRed_ValueChanged);
            // 
            // kryptonBlueValueLabel1
            // 
            this.kryptonBlueValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonBlueValueLabel1.Location = new System.Drawing.Point(232, 15);
            this.kryptonBlueValueLabel1.Name = "kryptonBlueValueLabel1";
            this.kryptonBlueValueLabel1.RedValue = 255;
            this.kryptonBlueValueLabel1.Size = new System.Drawing.Size(46, 26);
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.TabIndex = 14;
            this.kryptonBlueValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.Values.Text = "Blue";
            // 
            // kryptonGreenValueLabel1
            // 
            this.kryptonGreenValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGreenValueLabel1.Location = new System.Drawing.Point(119, 15);
            this.kryptonGreenValueLabel1.Name = "kryptonGreenValueLabel1";
            this.kryptonGreenValueLabel1.RedValue = 255;
            this.kryptonGreenValueLabel1.Size = new System.Drawing.Size(58, 26);
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.TabIndex = 13;
            this.kryptonGreenValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.Values.Text = "Green";
            // 
            // kryptonRedValueLabel1
            // 
            this.kryptonRedValueLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonRedValueLabel1.Location = new System.Drawing.Point(22, 15);
            this.kryptonRedValueLabel1.Name = "kryptonRedValueLabel1";
            this.kryptonRedValueLabel1.RedValue = 255;
            this.kryptonRedValueLabel1.Size = new System.Drawing.Size(42, 26);
            this.kryptonRedValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.TabIndex = 12;
            this.kryptonRedValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.Values.Text = "Red";
            // 
            // knumBlue
            // 
            this.knumBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knumBlue.Location = new System.Drawing.Point(223, 406);
            this.knumBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBlue.Name = "knumBlue";
            this.knumBlue.Size = new System.Drawing.Size(64, 26);
            this.knumBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBlue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumBlue.TabIndex = 20;
            this.knumBlue.ValueChanged += new System.EventHandler(this.knumBlue_ValueChanged);
            // 
            // knumGreen
            // 
            this.knumGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knumGreen.Location = new System.Drawing.Point(117, 406);
            this.knumGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumGreen.Name = "knumGreen";
            this.knumGreen.Size = new System.Drawing.Size(64, 26);
            this.knumGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knumGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumGreen.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumGreen.TabIndex = 19;
            this.knumGreen.ValueChanged += new System.EventHandler(this.knumGreen_ValueChanged);
            // 
            // knumRed
            // 
            this.knumRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knumRed.Location = new System.Drawing.Point(14, 406);
            this.knumRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumRed.Name = "knumRed";
            this.knumRed.Size = new System.Drawing.Size(64, 26);
            this.knumRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumRed.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumRed.TabIndex = 18;
            this.knumRed.ValueChanged += new System.EventHandler(this.knumRed_ValueChanged);
            // 
            // KryptonRGBColourSlider
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.knumBlue);
            this.Controls.Add(this.knumGreen);
            this.Controls.Add(this.knumRed);
            this.Controls.Add(this.ktrkBlue);
            this.Controls.Add(this.ktrkGreen);
            this.Controls.Add(this.ktrkRed);
            this.Controls.Add(this.kryptonBlueValueLabel1);
            this.Controls.Add(this.kryptonGreenValueLabel1);
            this.Controls.Add(this.kryptonRedValueLabel1);
            this.Name = "KryptonRGBColourSlider";
            this.Size = new System.Drawing.Size(301, 452);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Variables
        private Color _selectedColour, _previousColour;

        private int _redValue, _greenValue, _blueValue;
        #endregion

        #region Properties
        public Color SelectedColour { get => _selectedColour; set { _selectedColour = value; Invalidate(); } }

        internal Color PreviousColour { get => _previousColour; set { _previousColour = value; Invalidate(); } }

        public int RedValue { get => _redValue; set { _redValue = value; Invalidate(); } }

        public int GreenValue { get => _greenValue; set { _greenValue = value; Invalidate(); } }

        public int BlueValue { get => _blueValue; set { _blueValue = value; Invalidate(); } }
        #endregion

        #region Events
        public event EventHandler<SelectedColourEventArgs> SelectedColourChanged;
        #endregion

        #region Delegates
        //public delegate void SelectedColourChangedEventHandler(object sender, SelectedColourEventArgs e);
        #endregion

        #region Constructor
        public KryptonRGBColourSlider()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

            SelectedColour = Color.Empty;

            RedValue = 255;

            GreenValue = 255;

            BlueValue = 255;

            ktrkRed.Value = RedValue;

            ktrkGreen.Value = GreenValue;

            ktrkBlue.Value = BlueValue;
        }
        #endregion

        #region Event Handlers
        private void ktrkRed_ValueChanged(object sender, EventArgs e)
        {
            UpdateSelectedColour(ktrkRed.Value, ktrkGreen.Value, ktrkBlue.Value);

            knumRed.Value = ktrkRed.Value;
        }

        private void ktrkGreen_ValueChanged(object sender, EventArgs e)
        {
            UpdateSelectedColour(ktrkRed.Value, ktrkGreen.Value, ktrkBlue.Value);

            knumGreen.Value = ktrkGreen.Value;
        }

        private void ktrkBlue_ValueChanged(object sender, EventArgs e)
        {
            UpdateSelectedColour(ktrkRed.Value, ktrkGreen.Value, ktrkBlue.Value);

            knumBlue.Value = ktrkBlue.Value;
        }

        private void knumRed_ValueChanged(object sender, EventArgs e)
        {
            UpdateSelectedColour((int)knumRed.Value, (int)knumGreen.Value, (int)knumBlue.Value);

            ktrkRed.Value = Convert.ToInt32(knumRed.Value);
        }

        private void knumGreen_ValueChanged(object sender, EventArgs e)
        {
            UpdateSelectedColour((int)knumRed.Value, (int)knumGreen.Value, (int)knumBlue.Value);

            ktrkGreen.Value = Convert.ToInt32(knumGreen.Value);
        }

        private void knumBlue_ValueChanged(object sender, EventArgs e)
        {
            UpdateSelectedColour((int)knumRed.Value, (int)knumGreen.Value, (int)knumBlue.Value);

            ktrkBlue.Value = Convert.ToInt32(knumBlue.Value);
        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the SelectedColour.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetSelectedColour(Color value) => SelectedColour = value;

        /// <summary>
        /// Gets the SelectedColour.
        /// </summary>
        /// <returns>The value of SelectedColour.</returns>
        public Color GetSelectedColour() => SelectedColour;

        /// <summary>
        /// Sets the PreviousColour.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetPreviousColour(Color value) => PreviousColour = value;

        /// <summary>
        /// Gets the PreviousColour.
        /// </summary>
        /// <returns>The value of PreviousColour.</returns>
        public Color GetPreviousColour() => PreviousColour;
        #endregion

        #region Methods
        /// <summary>Updates the colour tracking values.</summary>
        /// <param name="colour">The colour.</param>
        public void UpdateColourTrackingValues(Color colour)
        {
            int red = colour.R, green = colour.G, blue = colour.B;

            ktrkRed.Value = red;

            ktrkGreen.Value = green;

            ktrkBlue.Value = blue;
        }

        /// <summary>Updates the selected colour.</summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        private Color UpdateSelectedColour(int red, int green, int blue) => SelectedColour = Color.FromArgb(red, green, blue);

        public void UpdateSelectedColour(Color colour)
        {
            SelectedColour = colour;

            OnSelectedColourChanged(colour);
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            SetSelectedColour(UpdateSelectedColour(ktrkRed.Value, ktrkGreen.Value, ktrkBlue.Value));

            base.OnPaint(e);
        }
        #endregion

        #region Protected
        protected virtual void OnSelectedColourChanged(Color colour)
        {
            if (SelectedColourChanged != null) SelectedColourChanged(this, new SelectedColourEventArgs() { SelectedColour = colour });
        }
        #endregion
    }
}