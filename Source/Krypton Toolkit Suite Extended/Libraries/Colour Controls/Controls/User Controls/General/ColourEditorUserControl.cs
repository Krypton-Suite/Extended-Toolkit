using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    [DefaultProperty("Color"), DefaultEvent("ColorChanged")]
    public class ColourEditorUserControl : UserControl, IColourEditor
    {
        #region Designer Code
        private IContainer components = null;

        private Krypton.Toolkit.KryptonLabel klblRGB;
        private Krypton.Toolkit.KryptonLabel klblRed;
        private Krypton.Toolkit.KryptonLabel klblGreen;
        private Krypton.Toolkit.KryptonLabel klblBlue;
        private Krypton.Toolkit.KryptonLabel klblHex;
        private Krypton.Toolkit.KryptonLabel klblAlpha;
        private Krypton.Toolkit.KryptonLabel klblLuminosity;
        private Krypton.Toolkit.KryptonLabel klblSaturation;
        private Krypton.Toolkit.KryptonLabel klblHue;
        private Krypton.Toolkit.KryptonLabel klblHSL;
        private Krypton.Toolkit.KryptonNumericUpDown knudRed;
        private Krypton.Toolkit.KryptonNumericUpDown knudSaturation;
        private Krypton.Toolkit.KryptonNumericUpDown knudLuminosity;
        private Krypton.Toolkit.KryptonNumericUpDown knudHue;
        private Krypton.Toolkit.KryptonNumericUpDown knudBlue;
        private Krypton.Toolkit.KryptonNumericUpDown knudGreen;
        private Krypton.Toolkit.KryptonComboBox kcmbHex;
        private Krypton.Toolkit.KryptonNumericUpDown knudAlpha;
        private RGBAColourSliderControl rColourBar;
        private RGBAColourSliderControl gColourBar;
        private RGBAColourSliderControl bColourBar;
        private HueColourSliderControl hColourBar;
        private LightnessColourSliderControl lColourBar;
        private SaturationColourSliderControl sColourBar;
        private RGBAColourSliderControl aColourBar;

        private void InitializeComponent()
        {
            this.klblRGB = new Krypton.Toolkit.KryptonLabel();
            this.klblRed = new Krypton.Toolkit.KryptonLabel();
            this.klblGreen = new Krypton.Toolkit.KryptonLabel();
            this.klblBlue = new Krypton.Toolkit.KryptonLabel();
            this.klblHex = new Krypton.Toolkit.KryptonLabel();
            this.klblAlpha = new Krypton.Toolkit.KryptonLabel();
            this.klblLuminosity = new Krypton.Toolkit.KryptonLabel();
            this.klblSaturation = new Krypton.Toolkit.KryptonLabel();
            this.klblHue = new Krypton.Toolkit.KryptonLabel();
            this.klblHSL = new Krypton.Toolkit.KryptonLabel();
            this.knudRed = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudSaturation = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudLuminosity = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudHue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudBlue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudGreen = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kcmbHex = new Krypton.Toolkit.KryptonComboBox();
            this.knudAlpha = new Krypton.Toolkit.KryptonNumericUpDown();
            this.rColourBar = new RGBAColourSliderControl();
            this.gColourBar = new RGBAColourSliderControl();
            this.bColourBar = new RGBAColourSliderControl();
            this.hColourBar = new HueColourSliderControl();
            this.sColourBar = new SaturationColourSliderControl();
            this.lColourBar = new LightnessColourSliderControl();
            this.aColourBar = new RGBAColourSliderControl();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHex)).BeginInit();
            this.SuspendLayout();
            // 
            // klblRGB
            // 
            this.klblRGB.Location = new System.Drawing.Point(0, 0);
            this.klblRGB.Name = "klblRGB";
            this.klblRGB.Size = new System.Drawing.Size(49, 26);
            this.klblRGB.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRGB.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRGB.TabIndex = 0;
            this.klblRGB.Values.Text = "RGB:";
            // 
            // klblRed
            // 
            this.klblRed.Location = new System.Drawing.Point(5, 26);
            this.klblRed.Name = "klblRed";
            this.klblRed.Size = new System.Drawing.Size(27, 26);
            this.klblRed.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRed.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRed.TabIndex = 1;
            this.klblRed.Values.Text = "R:";
            // 
            // klblGreen
            // 
            this.klblGreen.Location = new System.Drawing.Point(3, 56);
            this.klblGreen.Name = "klblGreen";
            this.klblGreen.Size = new System.Drawing.Size(28, 26);
            this.klblGreen.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblGreen.TabIndex = 2;
            this.klblGreen.Values.Text = "G:";
            // 
            // klblBlue
            // 
            this.klblBlue.Location = new System.Drawing.Point(5, 88);
            this.klblBlue.Name = "klblBlue";
            this.klblBlue.Size = new System.Drawing.Size(27, 26);
            this.klblBlue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBlue.TabIndex = 3;
            this.klblBlue.Values.Text = "B:";
            // 
            // klblHex
            // 
            this.klblHex.Location = new System.Drawing.Point(3, 123);
            this.klblHex.Name = "klblHex";
            this.klblHex.Size = new System.Drawing.Size(47, 26);
            this.klblHex.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHex.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHex.TabIndex = 4;
            this.klblHex.Values.Text = "Hex:";
            // 
            // klblAlpha
            // 
            this.klblAlpha.Location = new System.Drawing.Point(5, 289);
            this.klblAlpha.Name = "klblAlpha";
            this.klblAlpha.Size = new System.Drawing.Size(62, 26);
            this.klblAlpha.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.TabIndex = 9;
            this.klblAlpha.Values.Text = "Alpha:";
            // 
            // klblLuminosity
            // 
            this.klblLuminosity.Location = new System.Drawing.Point(3, 251);
            this.klblLuminosity.Name = "klblLuminosity";
            this.klblLuminosity.Size = new System.Drawing.Size(25, 26);
            this.klblLuminosity.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLuminosity.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLuminosity.TabIndex = 8;
            this.klblLuminosity.Values.Text = "L:";
            // 
            // klblSaturation
            // 
            this.klblSaturation.Location = new System.Drawing.Point(3, 217);
            this.klblSaturation.Name = "klblSaturation";
            this.klblSaturation.Size = new System.Drawing.Size(26, 26);
            this.klblSaturation.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblSaturation.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblSaturation.TabIndex = 7;
            this.klblSaturation.Values.Text = "S:";
            // 
            // klblHue
            // 
            this.klblHue.Location = new System.Drawing.Point(5, 183);
            this.klblHue.Name = "klblHue";
            this.klblHue.Size = new System.Drawing.Size(29, 26);
            this.klblHue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHue.TabIndex = 6;
            this.klblHue.Values.Text = "H:";
            // 
            // klblHSL
            // 
            this.klblHSL.Location = new System.Drawing.Point(0, 159);
            this.klblHSL.Name = "klblHSL";
            this.klblHSL.Size = new System.Drawing.Size(47, 26);
            this.klblHSL.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHSL.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHSL.TabIndex = 5;
            this.klblHSL.Values.Text = "HSL:";
            // 
            // knudRed
            // 
            this.knudRed.Location = new System.Drawing.Point(176, 20);
            this.knudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRed.Name = "knudRed";
            this.knudRed.Size = new System.Drawing.Size(58, 28);
            this.knudRed.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.knudRed.TabIndex = 10;
            // 
            // knudSaturation
            // 
            this.knudSaturation.Location = new System.Drawing.Point(176, 217);
            this.knudSaturation.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudSaturation.Name = "knudSaturation";
            this.knudSaturation.Size = new System.Drawing.Size(58, 28);
            this.knudSaturation.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudSaturation.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.knudSaturation.TabIndex = 11;
            // 
            // knudLuminosity
            // 
            this.knudLuminosity.Location = new System.Drawing.Point(176, 251);
            this.knudLuminosity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudLuminosity.Name = "knudLuminosity";
            this.knudLuminosity.Size = new System.Drawing.Size(58, 28);
            this.knudLuminosity.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudLuminosity.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.knudLuminosity.TabIndex = 12;
            // 
            // knudHue
            // 
            this.knudHue.Location = new System.Drawing.Point(176, 183);
            this.knudHue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudHue.Name = "knudHue";
            this.knudHue.Size = new System.Drawing.Size(58, 28);
            this.knudHue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudHue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.knudHue.TabIndex = 13;
            // 
            // knudBlue
            // 
            this.knudBlue.Location = new System.Drawing.Point(176, 88);
            this.knudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlue.Name = "knudBlue";
            this.knudBlue.Size = new System.Drawing.Size(58, 28);
            this.knudBlue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.knudBlue.TabIndex = 14;
            // 
            // knudGreen
            // 
            this.knudGreen.Location = new System.Drawing.Point(176, 54);
            this.knudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreen.Name = "knudGreen";
            this.knudGreen.Size = new System.Drawing.Size(58, 28);
            this.knudGreen.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.knudGreen.TabIndex = 15;
            // 
            // kcmbHex
            // 
            this.kcmbHex.DropDownWidth = 58;
            this.kcmbHex.IntegralHeight = false;
            this.kcmbHex.Location = new System.Drawing.Point(176, 122);
            this.kcmbHex.Name = "kcmbHex";
            this.kcmbHex.Size = new System.Drawing.Size(58, 27);
            this.kcmbHex.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbHex.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbHex.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbHex.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbHex.TabIndex = 16;
            this.kcmbHex.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.kcmbHex_DrawItem);
            // 
            // knudAlpha
            // 
            this.knudAlpha.Location = new System.Drawing.Point(176, 287);
            this.knudAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudAlpha.Name = "knudAlpha";
            this.knudAlpha.Size = new System.Drawing.Size(58, 28);
            this.knudAlpha.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudAlpha.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.knudAlpha.TabIndex = 17;
            // 
            // rColourBar
            // 
            this.rColourBar.Location = new System.Drawing.Point(38, 28);
            this.rColourBar.Name = "rColourBar";
            this.rColourBar.Size = new System.Drawing.Size(132, 20);
            this.rColourBar.TabIndex = 3;
            this.rColourBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // gColourBar
            // 
            this.gColourBar.Channel = RGBAChannel.Green;
            this.gColourBar.Location = new System.Drawing.Point(38, 59);
            this.gColourBar.Name = "gColourBar";
            this.gColourBar.Size = new System.Drawing.Size(132, 20);
            this.gColourBar.TabIndex = 6;
            this.gColourBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // bColourBar
            // 
            this.bColourBar.Channel = RGBAChannel.Blue;
            this.bColourBar.Location = new System.Drawing.Point(38, 92);
            this.bColourBar.Name = "bColourBar";
            this.bColourBar.Size = new System.Drawing.Size(132, 20);
            this.bColourBar.TabIndex = 9;
            this.bColourBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // hColourBar
            // 
            this.hColourBar.Location = new System.Drawing.Point(38, 187);
            this.hColourBar.Name = "hColourBar";
            this.hColourBar.Size = new System.Drawing.Size(132, 20);
            this.hColourBar.TabIndex = 15;
            this.hColourBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // sColourBar
            // 
            this.sColourBar.Location = new System.Drawing.Point(38, 220);
            this.sColourBar.Name = "sColourBar";
            this.sColourBar.Size = new System.Drawing.Size(132, 20);
            this.sColourBar.TabIndex = 18;
            this.sColourBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // lColourBar
            // 
            this.lColourBar.Location = new System.Drawing.Point(38, 251);
            this.lColourBar.Name = "lColourBar";
            this.lColourBar.Size = new System.Drawing.Size(132, 20);
            this.lColourBar.TabIndex = 21;
            this.lColourBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // aColourBar
            // 
            this.aColourBar.Channel = RGBAChannel.Alpha;
            this.aColourBar.Location = new System.Drawing.Point(73, 293);
            this.aColourBar.Name = "aColourBar";
            this.aColourBar.Size = new System.Drawing.Size(97, 20);
            this.aColourBar.TabIndex = 24;
            this.aColourBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // ColourEditor
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.knudAlpha);
            this.Controls.Add(this.kcmbHex);
            this.Controls.Add(this.knudGreen);
            this.Controls.Add(this.knudBlue);
            this.Controls.Add(this.knudHue);
            this.Controls.Add(this.knudLuminosity);
            this.Controls.Add(this.knudSaturation);
            this.Controls.Add(this.knudRed);
            this.Controls.Add(this.klblAlpha);
            this.Controls.Add(this.klblLuminosity);
            this.Controls.Add(this.klblSaturation);
            this.Controls.Add(this.klblHue);
            this.Controls.Add(this.klblHSL);
            this.Controls.Add(this.klblHex);
            this.Controls.Add(this.klblBlue);
            this.Controls.Add(this.klblGreen);
            this.Controls.Add(this.klblRed);
            this.Controls.Add(this.klblRGB);
            this.Controls.Add(this.rColourBar);
            this.Controls.Add(this.gColourBar);
            this.Controls.Add(this.bColourBar);
            this.Controls.Add(this.hColourBar);
            this.Controls.Add(this.sColourBar);
            this.Controls.Add(this.lColourBar);
            this.Controls.Add(this.aColourBar);
            this.Name = "ColourEditor";
            this.Size = new System.Drawing.Size(243, 323);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private HSLColour _hslColour;

        private Orientation _orientation;

        private bool _showAlphaChannel;

        private bool _showColourSpaceLabels;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColourEditorUserControl"/> class.
        /// </summary>
        public ColourEditorUserControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);

            _colour = Color.Black;
            _orientation = Orientation.Vertical;
            this.Size = new Size(200, 260);
            _showAlphaChannel = true;
            _showColourSpaceLabels = true;
        }
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
        /// Occurs when the ShowColourSpaceLabels property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ShowColourSpaceLabelsChanged
        {
            add { this.Events.AddHandler(_eventShowColourSpaceLabelsChanged, value); }
            remove { this.Events.RemoveHandler(_eventShowColourSpaceLabelsChanged, value); }
        }

        #endregion

        #region Properties

        //public Color Colour
        //{

        //}

        /// <summary>
        /// Gets or sets the component colour as a HSL structure.
        /// </summary>
        /// <value>The component colour.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual HSLColour HslColour
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
                        this.Colour = value.ToRgbColour();
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
        public bool ShowColourSpaceLabels
        {
            get { return _showColourSpaceLabels; }
            set
            {
                if (_showColourSpaceLabels != value)
                {
                    _showColourSpaceLabels = value;

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

        #region Methods

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

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.DockChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnDockChanged(EventArgs e)
        {
            base.OnDockChanged(e);

            this.ResizeComponents();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            this.SetDropDownWidth();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.ResizeComponents();
        }

        /// <summary>
        /// Raises the <see cref="OrientationChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnOrientationChanged(EventArgs e)
        {
            EventHandler handler;

            this.ResizeComponents();

            handler = (EventHandler)this.Events[_eventOrientationChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.PaddingChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);

            this.ResizeComponents();
        }

        /// <summary>
        /// Raises the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.ResizeComponents();
        }

        /// <summary>
        /// Raises the <see cref="ShowAlphaChannelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowAlphaChannelChanged(EventArgs e)
        {
            EventHandler handler;

            this.SetControlStates();
            this.ResizeComponents();

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
            this.ResizeComponents();

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
                rowHeight = Math.Max(Math.Max(klblRed.Height, rColourBar.Height), knudRed.Height);
                labelOffset = (rowHeight - klblRed.Height) >> 1;
                colourBarOffset = (rowHeight - rColourBar.Height) >> 1;
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
                if (_showColourSpaceLabels)
                {
                    klblRGB.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                    top += rowHeight + innerMargin;
                }

                // R row
                klblRed.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                rColourBar.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudRed.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // G row
                klblGreen.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                gColourBar.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudGreen.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // B row
                klblBlue.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                bColourBar.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudBlue.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // Hex row
                klblHex.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                kcmbHex.SetBounds(klblHex.Right + innerMargin, top + colourBarOffset, barWidth + editOffset + editWidth - (klblHex.Right - group1BarLeft), 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // reset top
                if (this.Orientation == Orientation.Horizontal)
                {
                    top = this.Padding.Top;
                }

                // HSL header
                if (_showColourSpaceLabels)
                {
                    klblHSL.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                    top += rowHeight + innerMargin;
                }

                // H row
                klblHue.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                hColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudHue.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // S row
                klblSaturation.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                sColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudSaturation.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // L row
                klblLuminosity.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                lColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudLuminosity.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // A row
                klblAlpha.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                aColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
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
                    rColourBar.Value = this.Colour.R;
                    rColourBar.Colour = this.Colour;
                    gColourBar.Value = this.Colour.G;
                    gColourBar.Colour = this.Colour;
                    bColourBar.Value = this.Colour.B;
                    bColourBar.Colour = this.Colour;

                    // HTML
                    if (!(userAction && kcmbHex.Focused))
                    {
                        kcmbHex.Text = this.Colour.IsNamedColor ? this.Colour.Name : string.Format("{0:X2}{1:X2}{2:X2}", this.Colour.R, this.Colour.G, this.Colour.B);
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
                    hColourBar.Value = (int)this.HslColour.H;
                    sColourBar.Colour = this.Colour;
                    sColourBar.Value = (int)(this.HslColour.S * 100);
                    lColourBar.Colour = this.Colour;
                    lColourBar.Value = (int)(this.HslColour.L * 100);

                    // Alpha
                    if (!(userAction && knudAlpha.Focused))
                    {
                        knudAlpha.Value = this.Colour.A;
                    }
                    aColourBar.Colour = this.Colour;
                    aColourBar.Value = this.Colour.A;
                }
                finally
                {
                    this.LockUpdates = false;
                }
            }
        }

#if !NETCOREAPP
        private void AddColourProperties<T>()
        {
            Type type;
            Type colourType;

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
                        kcmbHex.Items.Add(colour.Name);
                    }
                }
            }
        }
#endif

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

#if !NETCOREAPP
        private void FillNamedColours()
        {
            this.AddColourProperties<SystemColors>();
            this.AddColourProperties<Color>();
            this.SetDropDownWidth();
        }
#endif

        private void kcmbHex_DrawItem(object sender, DrawItemEventArgs e)
        {
            // TODO: Really, this should be another control - ColourComboBox or ColourListBox etc.

            if (e.Index != -1)
            {
                Rectangle colourBox;
                string name;
                Color colour;

                e.DrawBackground();

                name = (string)kcmbHex.Items[e.Index];
                colour = Color.FromName(name);
                colourBox = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1, e.Bounds.Height - 3, e.Bounds.Height - 3);

                using (Brush brush = new SolidBrush(colour))
                {
                    e.Graphics.FillRectangle(brush, colourBox);
                }
                e.Graphics.DrawRectangle(SystemPens.ControlText, colourBox);

                TextRenderer.DrawText(e.Graphics, this.AddSpaces(name), this.Font, new Point(colourBox.Right + 3, colourBox.Top), e.ForeColor);

                //if (colour == Colour.Transparent && (e.State & DrawItemState.Selected) != DrawItemState.Selected)
                //  e.Graphics.DrawLine(SystemPens.ControlText, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);

                e.DrawFocusRectangle();
            }
        }

        private void kcmbHex_DropDown(object sender, EventArgs e)
        {
#if !NETCOREAPP
            if (kcmbHex.Items.Count == 0)
            {
                this.FillNamedColours();
            }
#endif
        }

        private void kcmbHex_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.PageUp:
                case Keys.PageDown:
#if !NETCOREAPP
                    if (kcmbHex.Items.Count == 0)
                    {
                        this.FillNamedColours();
                    }
#endif
                    break;
            }
        }

        private void kcmbHex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcmbHex.SelectedIndex != -1)
            {
                this.LockUpdates = true;
                this.Colour = Color.FromName((string)kcmbHex.SelectedItem);
                this.LockUpdates = false;
            }
        }

        private void SetBarStates(bool visible)
        {
            rColourBar.Visible = visible;
            gColourBar.Visible = visible;
            bColourBar.Visible = visible;
            hColourBar.Visible = visible;
            sColourBar.Visible = visible;
            lColourBar.Visible = visible;
            aColourBar.Visible = _showAlphaChannel && visible;
        }

        private void SetControlStates()
        {
            klblAlpha.Visible = _showAlphaChannel;
            aColourBar.Visible = _showAlphaChannel;
            knudAlpha.Visible = _showAlphaChannel;

            klblRed.Visible = _showColourSpaceLabels;
            klblHSL.Visible = _showColourSpaceLabels;
        }

        private void SetDropDownWidth()
        {
            if (kcmbHex.Items.Count != 0)
            {
                kcmbHex.DropDownWidth = kcmbHex.ItemHeight * 2 + kcmbHex.Items.Cast<string>().Max(s => TextRenderer.MeasureText(s, this.Font).Width);
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

                if (sender == kcmbHex)
                {
                    string text;
                    int namedIndex;

                    text = kcmbHex.Text;
                    if (text.StartsWith("#"))
                    {
                        text = text.Substring(1);
                    }

#if !NETCOREAPP
                    if (kcmbHex.Items.Count == 0)
                    {
                        this.FillNamedColours();
                    }
#endif

                    namedIndex = kcmbHex.FindStringExact(text);

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
                else if (sender == aColourBar || sender == rColourBar || sender == gColourBar || sender == bColourBar)
                {
                    knudAlpha.Value = (int)aColourBar.Value;
                    knudRed.Value = (int)rColourBar.Value;
                    knudGreen.Value = (int)gColourBar.Value;
                    knudBlue.Value = (int)bColourBar.Value;

                    useRgb = true;
                }
                else if (sender == knudAlpha || sender == knudRed || sender == knudGreen || sender == knudBlue)
                {
                    useRgb = true;
                }
                else if (sender == hColourBar || sender == lColourBar || sender == sColourBar)
                {
                    knudHue.Value = (int)hColourBar.Value;
                    knudSaturation.Value = (int)sColourBar.Value;
                    knudLuminosity.Value = (int)lColourBar.Value;

                    useHsl = true;
                }
                else if (sender == knudHue || sender == knudSaturation || sender == knudLuminosity)
                {
                    useHsl = true;
                }

                if (useRgb || useNamed)
                {
                    Color colour;

                    colour = useNamed ? Color.FromName(kcmbHex.Text) : Color.FromArgb((int)knudAlpha.Value, (int)knudRed.Value, (int)knudGreen.Value, (int)knudBlue.Value);

                    this.Colour = colour;
                    this.HslColour = new HSLColour(colour);
                }
                else if (useHsl)
                {
                    HSLColour colour;

                    colour = new HSLColour((int)knudAlpha.Value, (double)knudHue.Value, (double)knudSaturation.Value / 100, (double)knudLuminosity.Value / 100);
                    this.HslColour = colour;
                    this.Colour = colour.ToRgbColour();
                }

                this.LockUpdates = false;
                this.UpdateFields(true);
            }
        }

        #endregion

        #region IColourEditor Implementation
        [Category("Appearance"), DefaultValue(typeof(Color), "0, 0, 0")]
        public Color Colour
        {
            get => _colour;

            set
            {
                if (value.A != 255 && !_showAlphaChannel)
                {
                    value = Color.FromArgb(255, value);
                }

                if (_colour != value)
                {
                    _colour = value;

                    if (!LockUpdates)
                    {
                        LockUpdates = true;

                        HslColour = new HSLColour(value);

                        LockUpdates = false;

                        UpdateFields(false);
                    }
                    else
                    {
                        OnColourChanged(EventArgs.Empty);
                    }
                }
            }
        }

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add => this.Events.AddHandler(_eventColourChanged, value);

            remove => Events.RemoveHandler(_eventColourChanged, value);
        }

        #endregion
    }
}