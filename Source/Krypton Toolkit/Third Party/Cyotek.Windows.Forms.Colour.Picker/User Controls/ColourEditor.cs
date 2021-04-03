using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.Colour.Picker
{
    /// <summary>
    /// Represents a control that allows the editing of a color in a variety of ways.
    /// </summary>
    [DefaultProperty("Colour"), DefaultEvent("ColourChanged")]
    public class ColourEditor : UserControl, IColourEditor
    {
        #region Design Code
        private Krypton.Toolkit.KryptonLabel klblGreen;
        private Krypton.Toolkit.KryptonLabel klblRed;
        private Krypton.Toolkit.KryptonLabel klblRGB;
        private Krypton.Toolkit.KryptonLabel klblBlue;
        private Krypton.Toolkit.KryptonNumericUpDown knudBlue;
        private RgbaColourSlider rgbaBlue;
        private Krypton.Toolkit.KryptonNumericUpDown knudGreen;
        private RgbaColourSlider rgbaGreen;
        private Krypton.Toolkit.KryptonNumericUpDown knudRed;
        private RgbaColourSlider rgbaRed;
        private Krypton.Toolkit.KryptonLabel klblSaturation;
        private Krypton.Toolkit.KryptonLabel klblLuminosity;
        private Krypton.Toolkit.KryptonLabel klblAlpha;
        private Krypton.Toolkit.KryptonLabel klblHue;
        private Krypton.Toolkit.KryptonLabel klblHSL;
        private Krypton.Toolkit.KryptonComboBox kcmbHexValue;
        private Krypton.Toolkit.KryptonLabel klblHex;
        private HueColourSlider hcsHue;
        private SaturationColourSlider scsSaturation;
        private Krypton.Toolkit.KryptonNumericUpDown knudLuminosity;
        private Krypton.Toolkit.KryptonNumericUpDown knudSaturation;
        private Krypton.Toolkit.KryptonNumericUpDown knudHue;
        private LightnessColourSlider lcsLuminosity;
        private Krypton.Toolkit.KryptonNumericUpDown knudAlpha;
        private RgbaColourSlider rgbasAlpha;
        private Krypton.Toolkit.KryptonPanel kpBackground;

        private void InitializeComponent()
        {
            this.kpBackground = new Krypton.Toolkit.KryptonPanel();
            this.knudAlpha = new Krypton.Toolkit.KryptonNumericUpDown();
            this.rgbasAlpha = new Cyotek.Windows.Forms.Colour.Picker.RgbaColourSlider();
            this.knudLuminosity = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudSaturation = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudHue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.lcsLuminosity = new Cyotek.Windows.Forms.Colour.Picker.LightnessColourSlider();
            this.scsSaturation = new Cyotek.Windows.Forms.Colour.Picker.SaturationColourSlider();
            this.hcsHue = new Cyotek.Windows.Forms.Colour.Picker.HueColourSlider();
            this.klblSaturation = new Krypton.Toolkit.KryptonLabel();
            this.klblLuminosity = new Krypton.Toolkit.KryptonLabel();
            this.klblAlpha = new Krypton.Toolkit.KryptonLabel();
            this.klblHue = new Krypton.Toolkit.KryptonLabel();
            this.klblHSL = new Krypton.Toolkit.KryptonLabel();
            this.kcmbHexValue = new Krypton.Toolkit.KryptonComboBox();
            this.klblHex = new Krypton.Toolkit.KryptonLabel();
            this.knudBlue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.rgbaBlue = new Cyotek.Windows.Forms.Colour.Picker.RgbaColourSlider();
            this.knudGreen = new Krypton.Toolkit.KryptonNumericUpDown();
            this.rgbaGreen = new Cyotek.Windows.Forms.Colour.Picker.RgbaColourSlider();
            this.knudRed = new Krypton.Toolkit.KryptonNumericUpDown();
            this.rgbaRed = new Cyotek.Windows.Forms.Colour.Picker.RgbaColourSlider();
            this.klblBlue = new Krypton.Toolkit.KryptonLabel();
            this.klblGreen = new Krypton.Toolkit.KryptonLabel();
            this.klblRed = new Krypton.Toolkit.KryptonLabel();
            this.klblRGB = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kpBackground)).BeginInit();
            this.kpBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHexValue)).BeginInit();
            this.SuspendLayout();
            // 
            // kpBackground
            // 
            this.kpBackground.Controls.Add(this.knudAlpha);
            this.kpBackground.Controls.Add(this.rgbasAlpha);
            this.kpBackground.Controls.Add(this.knudLuminosity);
            this.kpBackground.Controls.Add(this.knudSaturation);
            this.kpBackground.Controls.Add(this.knudHue);
            this.kpBackground.Controls.Add(this.lcsLuminosity);
            this.kpBackground.Controls.Add(this.scsSaturation);
            this.kpBackground.Controls.Add(this.hcsHue);
            this.kpBackground.Controls.Add(this.klblSaturation);
            this.kpBackground.Controls.Add(this.klblLuminosity);
            this.kpBackground.Controls.Add(this.klblAlpha);
            this.kpBackground.Controls.Add(this.klblHue);
            this.kpBackground.Controls.Add(this.klblHSL);
            this.kpBackground.Controls.Add(this.kcmbHexValue);
            this.kpBackground.Controls.Add(this.klblHex);
            this.kpBackground.Controls.Add(this.knudBlue);
            this.kpBackground.Controls.Add(this.rgbaBlue);
            this.kpBackground.Controls.Add(this.knudGreen);
            this.kpBackground.Controls.Add(this.rgbaGreen);
            this.kpBackground.Controls.Add(this.knudRed);
            this.kpBackground.Controls.Add(this.rgbaRed);
            this.kpBackground.Controls.Add(this.klblBlue);
            this.kpBackground.Controls.Add(this.klblGreen);
            this.kpBackground.Controls.Add(this.klblRed);
            this.kpBackground.Controls.Add(this.klblRGB);
            this.kpBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpBackground.Location = new System.Drawing.Point(0, 0);
            this.kpBackground.Name = "kpBackground";
            this.kpBackground.Size = new System.Drawing.Size(211, 294);
            this.kpBackground.TabIndex = 0;
            // 
            // knudAlpha
            // 
            this.knudAlpha.Location = new System.Drawing.Point(132, 257);
            this.knudAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudAlpha.Name = "knudAlpha";
            this.knudAlpha.Size = new System.Drawing.Size(67, 22);
            this.knudAlpha.TabIndex = 25;
            this.knudAlpha.ValueChanged += ValueChangedHandler;
            // 
            // rgbasAlpha
            // 
            this.rgbasAlpha.BackColor = System.Drawing.Color.Transparent;
            this.rgbasAlpha.Channel = Cyotek.Windows.Forms.Colour.Picker.RgbaChannel.Alpha;
            this.rgbasAlpha.Location = new System.Drawing.Point(51, 259);
            this.rgbasAlpha.Name = "rgbasAlpha";
            this.rgbasAlpha.Size = new System.Drawing.Size(75, 23);
            this.rgbasAlpha.TabIndex = 24;
            this.rgbasAlpha.ValueChanged += ValueChangedHandler;
            // 
            // knudLuminosity
            // 
            this.knudLuminosity.Location = new System.Drawing.Point(132, 227);
            this.knudLuminosity.Name = "knudLuminosity";
            this.knudLuminosity.Size = new System.Drawing.Size(67, 22);
            this.knudLuminosity.TabIndex = 23;
            this.knudLuminosity.ValueChanged += ValueChangedHandler;
            // 
            // knudSaturation
            // 
            this.knudSaturation.Location = new System.Drawing.Point(132, 198);
            this.knudSaturation.Name = "knudSaturation";
            this.knudSaturation.Size = new System.Drawing.Size(67, 22);
            this.knudSaturation.TabIndex = 22;
            this.knudSaturation.ValueChanged += ValueChangedHandler;
            // 
            // knudHue
            // 
            this.knudHue.Location = new System.Drawing.Point(132, 169);
            this.knudHue.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.knudHue.Name = "knudHue";
            this.knudHue.Size = new System.Drawing.Size(67, 22);
            this.knudHue.TabIndex = 21;
            this.knudHue.ValueChanged += ValueChangedHandler;
            // 
            // lcsLuminosity
            // 
            this.lcsLuminosity.BackColor = System.Drawing.Color.Transparent;
            this.lcsLuminosity.Location = new System.Drawing.Point(30, 228);
            this.lcsLuminosity.Name = "lcsLuminosity";
            this.lcsLuminosity.Size = new System.Drawing.Size(96, 23);
            this.lcsLuminosity.TabIndex = 20;
            this.lcsLuminosity.ValueChanged += ValueChangedHandler;
            // 
            // scsSaturation
            // 
            this.scsSaturation.BackColor = System.Drawing.Color.Transparent;
            this.scsSaturation.Location = new System.Drawing.Point(33, 199);
            this.scsSaturation.Name = "scsSaturation";
            this.scsSaturation.Size = new System.Drawing.Size(96, 23);
            this.scsSaturation.TabIndex = 19;
            this.scsSaturation.ValueChanged += ValueChangedHandler;
            // 
            // hcsHue
            // 
            this.hcsHue.BackColor = System.Drawing.Color.Transparent;
            this.hcsHue.Location = new System.Drawing.Point(33, 170);
            this.hcsHue.Name = "hcsHue";
            this.hcsHue.Size = new System.Drawing.Size(96, 23);
            this.hcsHue.TabIndex = 18;
            this.hcsHue.ValueChanged += ValueChangedHandler;
            // 
            // klblSaturation
            // 
            this.klblSaturation.Location = new System.Drawing.Point(5, 200);
            this.klblSaturation.Name = "klblSaturation";
            this.klblSaturation.Size = new System.Drawing.Size(20, 20);
            this.klblSaturation.TabIndex = 17;
            this.klblSaturation.Values.Text = "S:";
            // 
            // klblLuminosity
            // 
            this.klblLuminosity.Location = new System.Drawing.Point(5, 229);
            this.klblLuminosity.Name = "klblLuminosity";
            this.klblLuminosity.Size = new System.Drawing.Size(19, 20);
            this.klblLuminosity.TabIndex = 16;
            this.klblLuminosity.Values.Text = "L:";
            // 
            // klblAlpha
            // 
            this.klblAlpha.Location = new System.Drawing.Point(0, 259);
            this.klblAlpha.Name = "klblAlpha";
            this.klblAlpha.Size = new System.Drawing.Size(45, 20);
            this.klblAlpha.TabIndex = 15;
            this.klblAlpha.Values.Text = "Alpha:";
            // 
            // klblHue
            // 
            this.klblHue.Location = new System.Drawing.Point(5, 170);
            this.klblHue.Name = "klblHue";
            this.klblHue.Size = new System.Drawing.Size(22, 20);
            this.klblHue.TabIndex = 14;
            this.klblHue.Values.Text = "H:";
            // 
            // klblHSL
            // 
            this.klblHSL.Location = new System.Drawing.Point(0, 144);
            this.klblHSL.Name = "klblHSL";
            this.klblHSL.Size = new System.Drawing.Size(34, 20);
            this.klblHSL.TabIndex = 13;
            this.klblHSL.Values.Text = "HSL:";
            // 
            // kcmbHexValue
            // 
            this.kcmbHexValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbHexValue.DropDownWidth = 67;
            this.kcmbHexValue.IntegralHeight = false;
            this.kcmbHexValue.Location = new System.Drawing.Point(132, 118);
            this.kcmbHexValue.Name = "kcmbHexValue";
            this.kcmbHexValue.Size = new System.Drawing.Size(67, 21);
            this.kcmbHexValue.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbHexValue.TabIndex = 12;
            this.kcmbHexValue.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.kcmbHexValue_DrawItem);
            this.kcmbHexValue.DropDown += new System.EventHandler(this.kcmbHexValue_DropDown);
            this.kcmbHexValue.TextChanged += ValueChangedHandler;
            this.kcmbHexValue.SelectedIndexChanged += new System.EventHandler(this.kcmbHexValue_SelectedIndexChanged);
            this.kcmbHexValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kcmbHexValue_KeyDown);
            // 
            // klblHex
            // 
            this.klblHex.Location = new System.Drawing.Point(5, 118);
            this.klblHex.Name = "klblHex";
            this.klblHex.Size = new System.Drawing.Size(34, 20);
            this.klblHex.TabIndex = 11;
            this.klblHex.Values.Text = "Hex:";
            // 
            // knudBlue
            // 
            this.knudBlue.Location = new System.Drawing.Point(132, 83);
            this.knudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlue.Name = "knudBlue";
            this.knudBlue.Size = new System.Drawing.Size(67, 22);
            this.knudBlue.TabIndex = 10;
            this.knudBlue.ValueChanged += ValueChangedHandler;
            // 
            // rgbaBlue
            // 
            this.rgbaBlue.BackColor = System.Drawing.Color.Transparent;
            this.rgbaBlue.Channel = Cyotek.Windows.Forms.Colour.Picker.RgbaChannel.Blue;
            this.rgbaBlue.Location = new System.Drawing.Point(30, 84);
            this.rgbaBlue.Name = "rgbaBlue";
            this.rgbaBlue.Size = new System.Drawing.Size(96, 23);
            this.rgbaBlue.TabIndex = 9;
            this.rgbaBlue.ValueChanged += ValueChangedHandler;
            // 
            // knudGreen
            // 
            this.knudGreen.Location = new System.Drawing.Point(132, 54);
            this.knudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreen.Name = "knudGreen";
            this.knudGreen.Size = new System.Drawing.Size(67, 22);
            this.knudGreen.TabIndex = 8;
            this.knudGreen.ValueChanged += ValueChangedHandler;
            // 
            // rgbaGreen
            // 
            this.rgbaGreen.BackColor = System.Drawing.Color.Transparent;
            this.rgbaGreen.Channel = Cyotek.Windows.Forms.Colour.Picker.RgbaChannel.Green;
            this.rgbaGreen.Location = new System.Drawing.Point(30, 55);
            this.rgbaGreen.Name = "rgbaGreen";
            this.rgbaGreen.Size = new System.Drawing.Size(96, 23);
            this.rgbaGreen.TabIndex = 7;
            this.rgbaGreen.ValueChanged += ValueChangedHandler;
            // 
            // knudRed
            // 
            this.knudRed.Location = new System.Drawing.Point(132, 25);
            this.knudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRed.Name = "knudRed";
            this.knudRed.Size = new System.Drawing.Size(67, 22);
            this.knudRed.TabIndex = 6;
            this.knudRed.ValueChanged += ValueChangedHandler;
            // 
            // rgbaRed
            // 
            this.rgbaRed.BackColor = System.Drawing.Color.Transparent;
            this.rgbaRed.Location = new System.Drawing.Point(30, 26);
            this.rgbaRed.Name = "rgbaRed";
            this.rgbaRed.Size = new System.Drawing.Size(96, 23);
            this.rgbaRed.TabIndex = 5;
            this.rgbaRed.ValueChanged += ValueChangedHandler;
            // 
            // klblBlue
            // 
            this.klblBlue.Location = new System.Drawing.Point(3, 84);
            this.klblBlue.Name = "klblBlue";
            this.klblBlue.Size = new System.Drawing.Size(20, 20);
            this.klblBlue.TabIndex = 4;
            this.klblBlue.Values.Text = "B:";
            // 
            // klblGreen
            // 
            this.klblGreen.Location = new System.Drawing.Point(3, 55);
            this.klblGreen.Name = "klblGreen";
            this.klblGreen.Size = new System.Drawing.Size(22, 20);
            this.klblGreen.TabIndex = 3;
            this.klblGreen.Values.Text = "G:";
            // 
            // klblRed
            // 
            this.klblRed.Location = new System.Drawing.Point(3, 26);
            this.klblRed.Name = "klblRed";
            this.klblRed.Size = new System.Drawing.Size(21, 20);
            this.klblRed.TabIndex = 2;
            this.klblRed.Values.Text = "R:";
            // 
            // klblRGB
            // 
            this.klblRGB.Location = new System.Drawing.Point(0, 0);
            this.klblRGB.Name = "klblRGB";
            this.klblRGB.Size = new System.Drawing.Size(33, 20);
            this.klblRGB.TabIndex = 1;
            this.klblRGB.Values.Text = "RGB";
            // 
            // ColourEditor
            // 
            this.Controls.Add(this.kpBackground);
            this.Name = "ColourEditor";
            this.Size = new System.Drawing.Size(211, 294);
            ((System.ComponentModel.ISupportInitialize)(this.kpBackground)).EndInit();
            this.kpBackground.ResumeLayout(false);
            this.kpBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHexValue)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constants

        private static readonly object _eventColourChanged = new object();

        private static readonly object _eventOrientationChanged = new object();

        private static readonly object _eventShowAlphaChannelChanged = new object();

        private static readonly object _eventShowColourSpaceLabelsChanged = new object();

        private const int _minimumBarWidth = 30;

        #endregion

        #region Fields

        private Color _colour;

        private HslColour _hslColour;

        private Orientation _orientation;

        private bool _showAlphaChannel;

        private bool _showColorSpaceLabels;

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler OrientationChanged
        {
            add { this.Events.AddHandler(_eventOrientationChanged, value); }
            remove { this.Events.RemoveHandler(_eventOrientationChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ShowAlphaChannelChanged
        {
            add { this.Events.AddHandler(_eventShowAlphaChannelChanged, value); }
            remove { this.Events.RemoveHandler(_eventShowAlphaChannelChanged, value); }
        }

        /// <summary>
        /// Occurs when the ShowColorSpaceLabels property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ShowColourSpaceLabelsChanged
        {
            add { this.Events.AddHandler(_eventShowColourSpaceLabelsChanged, value); }
            remove { this.Events.RemoveHandler(_eventShowColourSpaceLabelsChanged, value); }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the component color as a HSL structure.
        /// </summary>
        /// <value>The component color.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual HslColour HslColour
        {
            get { return _hslColour; }
            set
            {
                if (this.HslColour != value)
                {
                    _hslColour = value;

                    if (!this.LockUpdates)
                    {
                        this.LockUpdates = true;
                        this.Colour = value.ToRgbColor();
                        this.LockUpdates = false;
                        this.UpdateFields(false);
                    }
                    else
                    {
                        this.OnColourChanged(EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the orientation of the editor.
        /// </summary>
        /// <value>The orientation.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Orientation), "Vertical")]
        public virtual Orientation Orientation
        {
            get { return _orientation; }
            set
            {
                if (this.Orientation != value)
                {
                    _orientation = value;

                    this.OnOrientationChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool ShowAlphaChannel
        {
            get { return _showAlphaChannel; }
            set
            {
                if (_showAlphaChannel != value)
                {
                    _showAlphaChannel = value;

                    this.OnShowAlphaChannelChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowColorSpaceLabels
        {
            get { return _showColorSpaceLabels; }
            set
            {
                if (_showColorSpaceLabels != value)
                {
                    _showColorSpaceLabels = value;

                    this.OnShowColourSpaceLabelsChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether input changes should be processed.
        /// </summary>
        /// <value><c>true</c> if input changes should be processed; otherwise, <c>false</c>.</value>
        protected bool LockUpdates { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColourEditor"/> class.
        /// </summary>
        public ColourEditor()
        {
            InitializeComponent();

            _colour = Color.Black;
            _orientation = Orientation.Vertical;
            Size = new Size(211, 294);
            _showAlphaChannel = true;
            _showColorSpaceLabels = true;
        }

        #endregion

        #region Protected
        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourChanged(EventArgs e)
        {
            EventHandler handler;

            this.UpdateFields(false);

            handler = (EventHandler)this.Events[_eventColourChanged];

            handler?.Invoke(this, e);
        }

        protected override void OnDockChanged(EventArgs e)
        {
            base.OnDockChanged(e);

            ResizeComponents();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            SetDropDownWidth();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ResizeComponents();
        }

        /// <summary>
        /// Raises the <see cref="OrientationChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnOrientationChanged(EventArgs e)
        {
            EventHandler handler;

            ResizeComponents();

            handler = (EventHandler)this.Events[_eventOrientationChanged];

            handler?.Invoke(this, e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            ResizeComponents();
        }

        /// <summary>
        /// Raises the <see cref="ShowAlphaChannelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowAlphaChannelChanged(EventArgs e)
        {
            EventHandler handler;

            this.SetControlStates();
            ResizeComponents();

            handler = (EventHandler)this.Events[_eventShowAlphaChannelChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ShowColourSpaceLabelsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowColourSpaceLabelsChanged(EventArgs e)
        {
            EventHandler handler;

            this.SetControlStates();
            ResizeComponents();

            handler = (EventHandler)this.Events[_eventShowColourSpaceLabelsChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Resizes the editing components.
        /// </summary>
        protected virtual void ResizeComponents()
        {
            try
            {
                int group1HeaderLeft;
                int group1BarLeft;
                int group1EditLeft;
                int group2HeaderLeft;
                int group2BarLeft;
                int group2EditLeft;
                int barWidth;
                int editWidth;
                int top;
                int innerMargin;
                int columnWidth;
                int rowHeight;
                int labelOffset;
                int colourBarOffset;
                int editOffset;
                int barHorizontalOffset;

                top = this.Padding.Top;
                innerMargin = 3;
                editWidth = TextRenderer.MeasureText("0000W", this.Font).Width + 6; // magic 6 for interior spacing+borders
                rowHeight = Math.Max(Math.Max(klblRed.Height, rgbaRed.Height), knudRed.Height);
                labelOffset = (rowHeight - klblRed.Height) >> 1;
                colourBarOffset = (rowHeight - rgbaRed.Height) >> 1;
                editOffset = (rowHeight - knudRed.Height) >> 1;
                barHorizontalOffset = _showAlphaChannel ? klblAlpha.Width : klblHue.Width;

                switch (this.Orientation)
                {
                    case Orientation.Horizontal:
                        columnWidth = (this.ClientSize.Width - (this.Padding.Horizontal + innerMargin)) >> 1;
                        break;
                    default:
                        columnWidth = this.ClientSize.Width - this.Padding.Horizontal;
                        break;
                }

                group1HeaderLeft = this.Padding.Left;
                group1EditLeft = columnWidth - editWidth;
                group1BarLeft = group1HeaderLeft + barHorizontalOffset + innerMargin;

                if (this.Orientation == Orientation.Horizontal)
                {
                    group2HeaderLeft = this.Padding.Left + columnWidth + innerMargin;
                    group2EditLeft = this.ClientSize.Width - (this.Padding.Right + editWidth);
                    group2BarLeft = group2HeaderLeft + barHorizontalOffset + innerMargin;
                }
                else
                {
                    group2HeaderLeft = group1HeaderLeft;
                    group2EditLeft = group1EditLeft;
                    group2BarLeft = group1BarLeft;
                }

                barWidth = group1EditLeft - (group1BarLeft + innerMargin);

                this.SetBarStates(barWidth >= _minimumBarWidth);

                // RGB header
                if (_showColorSpaceLabels)
                {
                    klblRGB.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                    top += rowHeight + innerMargin;
                }

                // R row
                klblRed.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                rgbaRed.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudRed.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // G row
                klblGreen.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                rgbaGreen.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudGreen.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // B row
                klblBlue.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                rgbaBlue.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudBlue.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // Hex row
                klblHex.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                kcmbHexValue.SetBounds(klblHex.Right + innerMargin, top + colourBarOffset, barWidth + editOffset + editWidth - (klblHex.Right - group1BarLeft), 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // reset top
                if (this.Orientation == Orientation.Horizontal)
                {
                    top = this.Padding.Top;
                }

                // HSL header
                if (_showColorSpaceLabels)
                {
                    klblHSL.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                    top += rowHeight + innerMargin;
                }

                // H row
                klblHue.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                hcsHue.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudHue.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // S row
                klblSaturation.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                scsSaturation.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudSaturation.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // L row
                klblLuminosity.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                lcsLuminosity.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudLuminosity.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // A row
                klblAlpha.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                rgbasAlpha.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudAlpha.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch
            // ReSharper restore EmptyGeneralCatchClause
            {
                // ignore errors
            }
        }

        /// <summary>
        /// Updates the editing field values.
        /// </summary>
        /// <param name="userAction">if set to <c>true</c> the update is due to user interaction.</param>
        protected virtual void UpdateFields(bool userAction)
        {
            if (!this.LockUpdates)
            {
                try
                {
                    this.LockUpdates = true;

                    // RGB
                    if (!(userAction && knudRed.Focused))
                    {
                        knudRed.Value = this.Colour.R;
                    }
                    if (!(userAction && knudGreen.Focused))
                    {
                        knudGreen.Value = this.Colour.G;
                    }
                    if (!(userAction && knudBlue.Focused))
                    {
                        knudBlue.Value = this.Colour.B;
                    }
                    rgbaRed.Value = this.Colour.R;
                    rgbaRed.Colour = this.Colour;
                    rgbaGreen.Value = this.Colour.G;
                    rgbaGreen.Colour = this.Colour;
                    rgbaBlue.Value = this.Colour.B;
                    rgbaBlue.Colour = this.Colour;

                    // HTML
                    if (!(userAction && kcmbHexValue.Focused))
                    {
                        kcmbHexValue.Text = this.Colour.IsNamedColor ? this.Colour.Name : string.Format("{0:X2}{1:X2}{2:X2}", this.Colour.R, this.Colour.G, this.Colour.B);
                    }

                    // HSL
                    if (!(userAction && knudHue.Focused))
                    {
                        knudHue.Value = (int)this.HslColour.H;
                    }
                    if (!(userAction && knudSaturation.Focused))
                    {
                        knudSaturation.Value = (int)(this.HslColour.S * 100);
                    }
                    if (!(userAction && knudLuminosity.Focused))
                    {
                        knudLuminosity.Value = (int)(this.HslColour.L * 100);
                    }
                    hcsHue.Value = (int)this.HslColour.H;
                    scsSaturation.Colour = this.Colour;
                    scsSaturation.Value = (int)(this.HslColour.S * 100);
                    lcsLuminosity.Colour = this.Colour;
                    lcsLuminosity.Value = (int)(this.HslColour.L * 100);

                    // Alpha
                    if (!(userAction && knudAlpha.Focused))
                    {
                        knudAlpha.Value = this.Colour.A;
                    }
                    rgbasAlpha.Colour = this.Colour;
                    rgbasAlpha.Value = this.Colour.A;
                }
                finally
                {
                    this.LockUpdates = false;
                }
            }
        }

        private void AddColourProperties<T>()
        {
            Type type, colourType;

            type = typeof(T);
            colourType = typeof(Color);

            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                if (property.PropertyType == colourType)
                {
                    Color colour;

                    colour = (Color)property.GetValue(type, null);
                    if (!colour.IsEmpty)
                    {
                        kcmbHexValue.Items.Add(colour.Name);
                    }
                }
            }
        }

        private string AddSpaces(string text)
        {
            string result;

            //http://stackoverflow.com/a/272929/148962

            if (!string.IsNullOrEmpty(text))
            {
                StringBuilder newText;

                newText = new StringBuilder(text.Length * 2);
                newText.Append(text[0]);
                for (int i = 1; i < text.Length; i++)
                {
                    if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    {
                        newText.Append(' ');
                    }
                    newText.Append(text[i]);
                }

                result = newText.ToString();
            }
            else
            {
                result = null;
            }

            return result;
        }

        private void FillNamedColours()
        {
#if !NETCOREAPP3_0_OR_GREATER
            AddColourProperties<SystemColors>();
#else

#endif
            AddColourProperties<Color>();

            SetDropDownWidth();
        }

        private void SetBarStates(bool visible)
        {
            rgbaRed.Visible = visible;
            rgbaGreen.Visible = visible;
            rgbaBlue.Visible = visible;
            hcsHue.Visible = visible;
            scsSaturation.Visible = visible;
            lcsLuminosity.Visible = visible;
            rgbasAlpha.Visible = _showAlphaChannel && visible;
        }

        private void SetControlStates()
        {
            klblAlpha.Visible = _showAlphaChannel;
            rgbasAlpha.Visible = _showAlphaChannel;
            knudAlpha.Visible = _showAlphaChannel;

            klblRGB.Visible = _showColorSpaceLabels;
            klblHSL.Visible = _showColorSpaceLabels;
        }

        private void SetDropDownWidth()
        {
            if (kcmbHexValue.Items.Count != 0)
            {
                kcmbHexValue.DropDownWidth = kcmbHexValue.ItemHeight * 2 + kcmbHexValue.Items.Cast<string>().Max(s => TextRenderer.MeasureText(s, this.Font).Width);
            }
        }

        /// <summary>
        /// Change handler for editing components.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ValueChangedHandler(object sender, EventArgs e)
        {
            if (!this.LockUpdates)
            {
                bool useHsl;
                bool useRgb;
                bool useNamed;

                useHsl = false;
                useRgb = false;
                useNamed = false;

                this.LockUpdates = true;

                if (sender == kcmbHexValue)
                {
                    string text;
                    int namedIndex;

                    text = kcmbHexValue.Text;
                    if (text.StartsWith("#"))
                    {
                        text = text.Substring(1);
                    }

                    if (kcmbHexValue.Items.Count == 0)
                    {
                        this.FillNamedColours();
                    }

                    namedIndex = kcmbHexValue.FindStringExact(text);

                    if (namedIndex != -1 || text.Length == 6 || text.Length == 8)
                    {
                        try
                        {
                            Color colour;

                            colour = namedIndex != -1 ? Color.FromName(text) : ColorTranslator.FromHtml("#" + text);
                            knudAlpha.Value = colour.A;
                            knudRed.Value = colour.R;
                            knudBlue.Value = colour.B;
                            knudGreen.Value = colour.G;

                            useRgb = true;
                        }
                        // ReSharper disable EmptyGeneralCatchClause
                        catch
                        { }
                        // ReSharper restore EmptyGeneralCatchClause
                    }
                    else
                    {
                        useNamed = true;
                    }
                }
                else if (sender == rgbasAlpha || sender == rgbaRed || sender == rgbaGreen || sender == rgbaBlue)
                {
                    knudAlpha.Value = (int)rgbasAlpha.Value;
                    knudRed.Value = (int)rgbaRed.Value;
                    knudGreen.Value = (int)rgbaGreen.Value;
                    knudBlue.Value = (int)rgbaBlue.Value;

                    useRgb = true;
                }
                else if (sender == knudAlpha || sender == knudRed || sender == knudGreen || sender == knudBlue)
                {
                    useRgb = true;
                }
                else if (sender == hcsHue || sender == lcsLuminosity || sender == scsSaturation)
                {
                    knudHue.Value = (int)hcsHue.Value;
                    knudSaturation.Value = (int)scsSaturation.Value;
                    knudLuminosity.Value = (int)lcsLuminosity.Value;

                    useHsl = true;
                }
                else if (sender == knudHue || sender == knudSaturation || sender == knudLuminosity)
                {
                    useHsl = true;
                }

                if (useRgb || useNamed)
                {
                    Color colour;

                    colour = useNamed ? Color.FromName(kcmbHexValue.Text) : Color.FromArgb((int)knudAlpha.Value, (int)knudRed.Value, (int)knudGreen.Value, (int)knudBlue.Value);

                    this.Colour = colour;
                    this.HslColour = new HslColour(colour);
                }
                else if (useHsl)
                {
                    HslColour colour;

                    colour = new HslColour((int)knudAlpha.Value, (double)knudHue.Value, (double)knudSaturation.Value / 100, (double)knudLuminosity.Value / 100);
                    this.HslColour = colour;
                    this.Colour = colour.ToRgbColor();
                }

                this.LockUpdates = false;
                this.UpdateFields(true);
            }
        }
        #endregion

        #region IColourInterface
        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add { Events.AddHandler(_eventColourChanged, value); }
            remove { Events.RemoveHandler(_eventColourChanged, value); }
        }

        /// <summary>
        /// Gets or sets the component color.
        /// </summary>
        /// <value>The component color.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "0, 0, 0")]
        public virtual Color Colour
        {
            get { return _colour; }
            set
            {
                /*
                 * If the color isn't solid, and ShowAlphaChannel is false
                 * remove the alpha channel. Not sure if this is the best
                 * place to do it, but it is a blanket fix for now
                 */
                if (value.A != 255 && !_showAlphaChannel)
                {
                    value = Color.FromArgb(255, value);
                }

                if (_colour != value)
                {
                    _colour = value;

                    if (!this.LockUpdates)
                    {
                        this.LockUpdates = true;
                        this.HslColour = new HslColour(value);
                        this.LockUpdates = false;
                        this.UpdateFields(false);
                    }
                    else
                    {
                        this.OnColourChanged(EventArgs.Empty);
                    }
                }
            }
        }
        #endregion

        private void kcmbHexValue_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index != -1)
            {
                Rectangle colourBox;
                string name;
                Color colour;

                e.DrawBackground();

                name = (string)kcmbHexValue.Items[e.Index];
                colour = Color.FromName(name);
                colourBox = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1, e.Bounds.Height - 3, e.Bounds.Height - 3);

                using (Brush brush = new SolidBrush(colour))
                {
                    e.Graphics.FillRectangle(brush, colourBox);
                }
                e.Graphics.DrawRectangle(SystemPens.ControlText, colourBox);

                TextRenderer.DrawText(e.Graphics, this.AddSpaces(name), this.Font, new Point(colourBox.Right + 3, colourBox.Top), e.ForeColor);

                //if (color == Color.Transparent && (e.State & DrawItemState.Selected) != DrawItemState.Selected)
                //  e.Graphics.DrawLine(SystemPens.ControlText, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);

                e.DrawFocusRectangle();
            }
        }

        private void kcmbHexValue_DropDown(object sender, EventArgs e)
        {
            if (kcmbHexValue.Items.Count == 0)
            {
                FillNamedColours();
            }
        }

        private void kcmbHexValue_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.PageUp:
                case Keys.PageDown:
                    if (kcmbHexValue.Items.Count == 0)
                    {
                        FillNamedColours();
                    }
                    break;
            }
        }

        private void kcmbHexValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcmbHexValue.SelectedIndex != 0)
            {
                LockUpdates = true;

                Colour = Color.FromName((string)kcmbHexValue.SelectedItem);

                LockUpdates = false;
            }
        }
    }
}