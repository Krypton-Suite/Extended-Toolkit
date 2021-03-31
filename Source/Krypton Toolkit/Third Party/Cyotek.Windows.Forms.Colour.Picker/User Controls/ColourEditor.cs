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
    [DefaultProperty("Colour")]
    [DefaultEvent("ColourChanged")]
    public partial class ColourEditor : UserControl, IColourEditor
    {
        #region Design Code
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rgbHeaderLabel = new Krypton.Toolkit.KryptonLabel();
            this.rLabel = new Krypton.Toolkit.KryptonLabel();
            this.rNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.rColorBar = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.gLabel = new Krypton.Toolkit.KryptonLabel();
            this.gColorBar = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.gNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.bLabel = new Krypton.Toolkit.KryptonLabel();
            this.bColorBar = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.bNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.hexLabel = new Krypton.Toolkit.KryptonLabel();
            this.hexTextBox = new Krypton.Toolkit.KryptonComboBox();
            this.lNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.lColorBar = new Cyotek.Windows.Forms.LightnessColorSlider();
            this.lLabel = new Krypton.Toolkit.KryptonLabel();
            this.sNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.sColorBar = new Cyotek.Windows.Forms.SaturationColorSlider();
            this.sLabel = new Krypton.Toolkit.KryptonLabel();
            this.hColorBar = new Cyotek.Windows.Forms.HueColorSlider();
            this.hNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.hLabel = new Krypton.Toolkit.KryptonLabel();
            this.hslLabel = new Krypton.Toolkit.KryptonLabel();
            this.aNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.aColorBar = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.aLabel = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // rgbHeaderLabel
            // 
            this.rgbHeaderLabel.AutoSize = true;
            this.rgbHeaderLabel.Location = new System.Drawing.Point(-3, 0);
            this.rgbHeaderLabel.Name = "rgbHeaderLabel";
            this.rgbHeaderLabel.Size = new System.Drawing.Size(33, 13);
            this.rgbHeaderLabel.TabIndex = 0;
            this.rgbHeaderLabel.Text = "RGB:";
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Location = new System.Drawing.Point(3, 13);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(18, 13);
            this.rLabel.TabIndex = 1;
            this.rLabel.Text = "R:";
            // 
            // rNumericUpDown
            // 
            this.rNumericUpDown.Location = new System.Drawing.Point(105, 11);
            this.rNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.rNumericUpDown.Name = "rNumericUpDown";
            this.rNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.rNumericUpDown.TabIndex = 2;
            this.rNumericUpDown.TextAlign = HorizontalAlignment.Right;
            this.rNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // rColorBar
            // 
            this.rColorBar.Location = new System.Drawing.Point(27, 13);
            this.rColorBar.Name = "rColorBar";
            this.rColorBar.Size = new System.Drawing.Size(72, 20);
            this.rColorBar.TabIndex = 3;
            this.rColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // gLabel
            // 
            this.gLabel.AutoSize = true;
            this.gLabel.Location = new System.Drawing.Point(3, 39);
            this.gLabel.Name = "gLabel";
            this.gLabel.Size = new System.Drawing.Size(18, 13);
            this.gLabel.TabIndex = 4;
            this.gLabel.Text = "G:";
            // 
            // gColorBar
            // 
            this.gColorBar.Channel = Cyotek.Windows.Forms.RgbaChannel.Green;
            this.gColorBar.Location = new System.Drawing.Point(27, 39);
            this.gColorBar.Name = "gColorBar";
            this.gColorBar.Size = new System.Drawing.Size(72, 20);
            this.gColorBar.TabIndex = 6;
            this.gColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // gNumericUpDown
            // 
            this.gNumericUpDown.Location = new System.Drawing.Point(105, 37);
            this.gNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.gNumericUpDown.Name = "gNumericUpDown";
            this.gNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.gNumericUpDown.TabIndex = 5;
            this.gNumericUpDown.TextAlign = HorizontalAlignment.Right;
            this.gNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // bLabel
            // 
            this.bLabel.AutoSize = true;
            this.bLabel.Location = new System.Drawing.Point(3, 65);
            this.bLabel.Name = "bLabel";
            this.bLabel.Size = new System.Drawing.Size(17, 13);
            this.bLabel.TabIndex = 7;
            this.bLabel.Text = "B:";
            // 
            // bColorBar
            // 
            this.bColorBar.Channel = Cyotek.Windows.Forms.RgbaChannel.Blue;
            this.bColorBar.Location = new System.Drawing.Point(27, 65);
            this.bColorBar.Name = "bColorBar";
            this.bColorBar.Size = new System.Drawing.Size(72, 20);
            this.bColorBar.TabIndex = 9;
            this.bColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // bNumericUpDown
            // 
            this.bNumericUpDown.Location = new System.Drawing.Point(105, 65);
            this.bNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.bNumericUpDown.Name = "bNumericUpDown";
            this.bNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.bNumericUpDown.TabIndex = 8;
            this.bNumericUpDown.TextAlign = HorizontalAlignment.Right;
            this.bNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // hexLabel
            // 
            this.hexLabel.AutoSize = true;
            this.hexLabel.Location = new System.Drawing.Point(3, 94);
            this.hexLabel.Name = "hexLabel";
            this.hexLabel.Size = new System.Drawing.Size(29, 13);
            this.hexLabel.TabIndex = 10;
            this.hexLabel.Text = "Hex:";
            // 
            // hexTextBox
            // 
            this.hexTextBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.hexTextBox.Location = new System.Drawing.Point(105, 91);
            this.hexTextBox.Name = "hexTextBox";
            this.hexTextBox.Size = new System.Drawing.Size(58, 21);
            this.hexTextBox.TabIndex = 11;
            this.hexTextBox.DrawItem += new DrawItemEventHandler(this.hexTextBox_DrawItem);
            this.hexTextBox.DropDown += new System.EventHandler(this.hexTextBox_DropDown);
            this.hexTextBox.SelectedIndexChanged += new System.EventHandler(this.hexTextBox_SelectedIndexChanged);
            this.hexTextBox.TextChanged += new System.EventHandler(this.ValueChangedHandler);
            this.hexTextBox.KeyDown += new KeyEventHandler(this.hexTextBox_KeyDown);
            // 
            // lNumericUpDown
            // 
            this.lNumericUpDown.Location = new System.Drawing.Point(105, 190);
            this.lNumericUpDown.Name = "lNumericUpDown";
            this.lNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.lNumericUpDown.TabIndex = 20;
            this.lNumericUpDown.TextAlign = HorizontalAlignment.Right;
            this.lNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // lColorBar
            // 
            this.lColorBar.Location = new System.Drawing.Point(27, 190);
            this.lColorBar.Name = "lColorBar";
            this.lColorBar.Size = new System.Drawing.Size(72, 20);
            this.lColorBar.TabIndex = 21;
            this.lColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // lLabel
            // 
            this.lLabel.AutoSize = true;
            this.lLabel.Location = new System.Drawing.Point(3, 192);
            this.lLabel.Name = "lLabel";
            this.lLabel.Size = new System.Drawing.Size(16, 13);
            this.lLabel.TabIndex = 19;
            this.lLabel.Text = "L:";
            // 
            // sNumericUpDown
            // 
            this.sNumericUpDown.Location = new System.Drawing.Point(105, 164);
            this.sNumericUpDown.Name = "sNumericUpDown";
            this.sNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.sNumericUpDown.TabIndex = 17;
            this.sNumericUpDown.TextAlign = HorizontalAlignment.Right;
            this.sNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // sColorBar
            // 
            this.sColorBar.Location = new System.Drawing.Point(27, 164);
            this.sColorBar.Name = "sColorBar";
            this.sColorBar.Size = new System.Drawing.Size(72, 20);
            this.sColorBar.TabIndex = 18;
            this.sColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // sLabel
            // 
            this.sLabel.AutoSize = true;
            this.sLabel.Location = new System.Drawing.Point(4, 166);
            this.sLabel.Name = "sLabel";
            this.sLabel.Size = new System.Drawing.Size(17, 13);
            this.sLabel.TabIndex = 16;
            this.sLabel.Text = "S:";
            // 
            // hColorBar
            // 
            this.hColorBar.Location = new System.Drawing.Point(27, 138);
            this.hColorBar.Name = "hColorBar";
            this.hColorBar.Size = new System.Drawing.Size(72, 20);
            this.hColorBar.TabIndex = 15;
            this.hColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // hNumericUpDown
            // 
            this.hNumericUpDown.Location = new System.Drawing.Point(105, 138);
            this.hNumericUpDown.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.hNumericUpDown.Name = "hNumericUpDown";
            this.hNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.hNumericUpDown.TabIndex = 14;
            this.hNumericUpDown.TextAlign = HorizontalAlignment.Right;
            this.hNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // hLabel
            // 
            this.hLabel.AutoSize = true;
            this.hLabel.Location = new System.Drawing.Point(3, 140);
            this.hLabel.Name = "hLabel";
            this.hLabel.Size = new System.Drawing.Size(18, 13);
            this.hLabel.TabIndex = 13;
            this.hLabel.Text = "H:";
            // 
            // hslLabel
            // 
            this.hslLabel.AutoSize = true;
            this.hslLabel.Location = new System.Drawing.Point(3, 117);
            this.hslLabel.Name = "hslLabel";
            this.hslLabel.Size = new System.Drawing.Size(31, 13);
            this.hslLabel.TabIndex = 12;
            this.hslLabel.Text = "HSL:";
            // 
            // aNumericUpDown
            // 
            this.aNumericUpDown.Location = new System.Drawing.Point(105, 216);
            this.aNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aNumericUpDown.Name = "aNumericUpDown";
            this.aNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.aNumericUpDown.TabIndex = 23;
            this.aNumericUpDown.TextAlign = HorizontalAlignment.Right;
            this.aNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // aColorBar
            // 
            this.aColorBar.Channel = Cyotek.Windows.Forms.RgbaChannel.Alpha;
            this.aColorBar.Location = new System.Drawing.Point(27, 216);
            this.aColorBar.Name = "aColorBar";
            this.aColorBar.Size = new System.Drawing.Size(72, 20);
            this.aColorBar.TabIndex = 24;
            this.aColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
            // 
            // aLabel
            // 
            this.aLabel.AutoSize = true;
            this.aLabel.Location = new System.Drawing.Point(3, 218);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(37, 13);
            this.aLabel.TabIndex = 22;
            this.aLabel.Text = "Alpha:";
            // 
            // ColorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = Krypton.Toolkit.KryptonAutoScaleMode.Font;
            this.Controls.Add(this.aLabel);
            this.Controls.Add(this.aNumericUpDown);
            this.Controls.Add(this.aColorBar);
            this.Controls.Add(this.hslLabel);
            this.Controls.Add(this.lNumericUpDown);
            this.Controls.Add(this.lColorBar);
            this.Controls.Add(this.lLabel);
            this.Controls.Add(this.sNumericUpDown);
            this.Controls.Add(this.sColorBar);
            this.Controls.Add(this.sLabel);
            this.Controls.Add(this.hColorBar);
            this.Controls.Add(this.hNumericUpDown);
            this.Controls.Add(this.hLabel);
            this.Controls.Add(this.hexTextBox);
            this.Controls.Add(this.hexLabel);
            this.Controls.Add(this.bNumericUpDown);
            this.Controls.Add(this.bColorBar);
            this.Controls.Add(this.bLabel);
            this.Controls.Add(this.gNumericUpDown);
            this.Controls.Add(this.gColorBar);
            this.Controls.Add(this.gLabel);
            this.Controls.Add(this.rColorBar);
            this.Controls.Add(this.rNumericUpDown);
            this.Controls.Add(this.rLabel);
            this.Controls.Add(this.rgbHeaderLabel);
            this.Name = "ColorEditor";
            this.Size = new System.Drawing.Size(173, 246);
            ((System.ComponentModel.ISupportInitialize)(this.rNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel rgbHeaderLabel;
        private Krypton.Toolkit.KryptonLabel rLabel;
        private Krypton.Toolkit.KryptonNumericUpDown rNumericUpDown;
        private RgbaColorSlider rColorBar;
        private Krypton.Toolkit.KryptonLabel gLabel;
        private RgbaColorSlider gColorBar;
        private Krypton.Toolkit.KryptonNumericUpDown gNumericUpDown;
        private Krypton.Toolkit.KryptonLabel bLabel;
        private RgbaColorSlider bColorBar;
        private Krypton.Toolkit.KryptonNumericUpDown bNumericUpDown;
        private Krypton.Toolkit.KryptonLabel hexLabel;
        private Krypton.Toolkit.KryptonComboBox hexTextBox;
        private Krypton.Toolkit.KryptonNumericUpDown lNumericUpDown;
        private LightnessColorSlider lColorBar;
        private Krypton.Toolkit.KryptonLabel lLabel;
        private Krypton.Toolkit.KryptonNumericUpDown sNumericUpDown;
        private SaturationColorSlider sColorBar;
        private Krypton.Toolkit.KryptonLabel sLabel;
        private HueColorSlider hColorBar;
        private Krypton.Toolkit.KryptonNumericUpDown hNumericUpDown;
        private Krypton.Toolkit.KryptonLabel hLabel;
        private Krypton.Toolkit.KryptonLabel hslLabel;
        private Krypton.Toolkit.KryptonNumericUpDown aNumericUpDown;
        private RgbaColorSlider aColorBar;
        private Krypton.Toolkit.KryptonLabel aLabel;
        #endregion

        #region Constants

        private static readonly object _eventColorChanged = new object();

        private static readonly object _eventOrientationChanged = new object();

        private static readonly object _eventShowAlphaChannelChanged = new object();

        private static readonly object _eventShowColorSpaceLabelsChanged = new object();

        private const int _minimumBarWidth = 30;

        #endregion

        #region Fields

        private Color _colour;

        private HslColour _hslColour;

        private Orientation _orientation;

        private bool _showAlphaChannel;

        private bool _showColorSpaceLabels;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColourEditor"/> class.
        /// </summary>
        public ColourEditor()
        {
            this.InitializeComponent();

            _colour = Color.Black;
            _orientation = Orientation.Vertical;
            this.Size = new Size(200, 260);
            _showAlphaChannel = true;
            _showColorSpaceLabels = true;
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
        /// Occurs when the ShowColorSpaceLabels property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ShowColorSpaceLabelsChanged
        {
            add { this.Events.AddHandler(_eventShowColorSpaceLabelsChanged, value); }
            remove { this.Events.RemoveHandler(_eventShowColorSpaceLabelsChanged, value); }
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
                        this.OnColorChanged(EventArgs.Empty);
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

                    this.OnShowColorSpaceLabelsChanged(EventArgs.Empty);
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
        /// Raises the <see cref="ColorChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorChanged(EventArgs e)
        {
            EventHandler handler;

            this.UpdateFields(false);

            handler = (EventHandler)this.Events[_eventColorChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:Krypton.Toolkit.KryptonControl.DockChanged" /> event.
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
        /// Raises the <see cref="E:Krypton.Toolkit.KryptonUserControl.Load" /> event.
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
        /// Raises the <see cref="E:Krypton.Toolkit.KryptonControl.PaddingChanged" /> event.
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
        /// Raises the <see cref="ShowColorSpaceLabelsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowColorSpaceLabelsChanged(EventArgs e)
        {
            EventHandler handler;

            this.SetControlStates();
            this.ResizeComponents();

            handler = (EventHandler)this.Events[_eventShowColorSpaceLabelsChanged];

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
                int colorBarOffset;
                int editOffset;
                int barHorizontalOffset;

                top = this.Padding.Top;
                innerMargin = 3;
                editWidth = TextRenderer.MeasureText("0000W", this.Font).Width + 6; // magic 6 for interior spacing+borders
                rowHeight = Math.Max(Math.Max(rLabel.Height, rColorBar.Height), rNumericUpDown.Height);
                labelOffset = (rowHeight - rLabel.Height) >> 1;
                colorBarOffset = (rowHeight - rColorBar.Height) >> 1;
                editOffset = (rowHeight - rNumericUpDown.Height) >> 1;
                barHorizontalOffset = _showAlphaChannel ? aLabel.Width : hLabel.Width;

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
                    rgbHeaderLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                    top += rowHeight + innerMargin;
                }

                // R row
                rLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                rColorBar.SetBounds(group1BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                rNumericUpDown.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // G row
                gLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                gColorBar.SetBounds(group1BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                gNumericUpDown.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // B row
                bLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                bColorBar.SetBounds(group1BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                bNumericUpDown.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // Hex row
                hexLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                hexTextBox.SetBounds(hexLabel.Right + innerMargin, top + colorBarOffset, barWidth + editOffset + editWidth - (hexLabel.Right - group1BarLeft), 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // reset top
                if (this.Orientation == Orientation.Horizontal)
                {
                    top = this.Padding.Top;
                }

                // HSL header
                if (_showColorSpaceLabels)
                {
                    hslLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                    top += rowHeight + innerMargin;
                }

                // H row
                hLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                hColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                hNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // S row
                sLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                sColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                sNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // L row
                lLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                lColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                lNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // A row
                aLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                aColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                aNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
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
                    if (!(userAction && rNumericUpDown.Focused))
                    {
                        rNumericUpDown.Value = this.Colour.R;
                    }
                    if (!(userAction && gNumericUpDown.Focused))
                    {
                        gNumericUpDown.Value = this.Colour.G;
                    }
                    if (!(userAction && bNumericUpDown.Focused))
                    {
                        bNumericUpDown.Value = this.Colour.B;
                    }
                    rColorBar.Value = this.Colour.R;
                    rColorBar.Color = this.Colour;
                    gColorBar.Value = this.Colour.G;
                    gColorBar.Color = this.Colour;
                    bColorBar.Value = this.Colour.B;
                    bColorBar.Color = this.Colour;

                    // HTML
                    if (!(userAction && hexTextBox.Focused))
                    {
                        hexTextBox.Text = this.Colour.IsNamedColor ? this.Colour.Name : string.Format("{0:X2}{1:X2}{2:X2}", this.Colour.R, this.Colour.G, this.Colour.B);
                    }

                    // HSL
                    if (!(userAction && hNumericUpDown.Focused))
                    {
                        hNumericUpDown.Value = (int)this.HslColour.H;
                    }
                    if (!(userAction && sNumericUpDown.Focused))
                    {
                        sNumericUpDown.Value = (int)(this.HslColour.S * 100);
                    }
                    if (!(userAction && lNumericUpDown.Focused))
                    {
                        lNumericUpDown.Value = (int)(this.HslColour.L * 100);
                    }
                    hColorBar.Value = (int)this.HslColour.H;
                    sColorBar.Color = this.Colour;
                    sColorBar.Value = (int)(this.HslColour.S * 100);
                    lColorBar.Color = this.Colour;
                    lColorBar.Value = (int)(this.HslColour.L * 100);

                    // Alpha
                    if (!(userAction && aNumericUpDown.Focused))
                    {
                        aNumericUpDown.Value = this.Colour.A;
                    }
                    aColorBar.Color = this.Colour;
                    aColorBar.Value = this.Colour.A;
                }
                finally
                {
                    this.LockUpdates = false;
                }
            }
        }

        private void AddColorProperties<T>()
        {
            Type type;
            Type colorType;

            type = typeof(T);
            colorType = typeof(Color);

            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                if (property.PropertyType == colorType)
                {
                    Color color;

                    color = (Color)property.GetValue(type, null);
                    if (!color.IsEmpty)
                    {
                        hexTextBox.Items.Add(color.Name);
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

        private void FillNamedColors()
        {
            this.AddColorProperties<SystemColors>();
            this.AddColorProperties<Color>();
            this.SetDropDownWidth();
        }

        private void hexTextBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // TODO: Really, this should be another control - ColorComboBox or ColorListBox etc.

            if (e.Index != -1)
            {
                Rectangle colorBox;
                string name;
                Color color;

                e.DrawBackground();

                name = (string)hexTextBox.Items[e.Index];
                color = Color.FromName(name);
                colorBox = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1, e.Bounds.Height - 3, e.Bounds.Height - 3);

                using (Brush brush = new SolidBrush(color))
                {
                    e.Graphics.FillRectangle(brush, colorBox);
                }
                e.Graphics.DrawRectangle(SystemPens.ControlText, colorBox);

                TextRenderer.DrawText(e.Graphics, this.AddSpaces(name), this.Font, new Point(colorBox.Right + 3, colorBox.Top), e.ForeColor);

                //if (color == Color.Transparent && (e.State & DrawItemState.Selected) != DrawItemState.Selected)
                //  e.Graphics.DrawLine(SystemPens.ControlText, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);

                e.DrawFocusRectangle();
            }
        }

        private void hexTextBox_DropDown(object sender, EventArgs e)
        {
            if (hexTextBox.Items.Count == 0)
            {
                this.FillNamedColors();
            }
        }

        private void hexTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.PageUp:
                case Keys.PageDown:
                    if (hexTextBox.Items.Count == 0)
                    {
                        this.FillNamedColors();
                    }
                    break;
            }
        }

        private void hexTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hexTextBox.SelectedIndex != -1)
            {
                this.LockUpdates = true;
                this.Colour = Color.FromName((string)hexTextBox.SelectedItem);
                this.LockUpdates = false;
            }
        }

        private void SetBarStates(bool visible)
        {
            rColorBar.Visible = visible;
            gColorBar.Visible = visible;
            bColorBar.Visible = visible;
            hColorBar.Visible = visible;
            sColorBar.Visible = visible;
            lColorBar.Visible = visible;
            aColorBar.Visible = _showAlphaChannel && visible;
        }

        private void SetControlStates()
        {
            aLabel.Visible = _showAlphaChannel;
            aColorBar.Visible = _showAlphaChannel;
            aNumericUpDown.Visible = _showAlphaChannel;

            rgbHeaderLabel.Visible = _showColorSpaceLabels;
            hslLabel.Visible = _showColorSpaceLabels;
        }

        private void SetDropDownWidth()
        {
            if (hexTextBox.Items.Count != 0)
            {
                hexTextBox.DropDownWidth = hexTextBox.ItemHeight * 2 + hexTextBox.Items.Cast<string>().Max(s => TextRenderer.MeasureText(s, this.Font).Width);
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

                if (sender == hexTextBox)
                {
                    string text;
                    int namedIndex;

                    text = hexTextBox.Text;
                    if (text.StartsWith("#"))
                    {
                        text = text.Substring(1);
                    }

                    if (hexTextBox.Items.Count == 0)
                    {
                        this.FillNamedColors();
                    }

                    namedIndex = hexTextBox.FindStringExact(text);

                    if (namedIndex != -1 || text.Length == 6 || text.Length == 8)
                    {
                        try
                        {
                            Color color;

                            color = namedIndex != -1 ? Color.FromName(text) : ColorTranslator.FromHtml("#" + text);
                            aNumericUpDown.Value = color.A;
                            rNumericUpDown.Value = color.R;
                            bNumericUpDown.Value = color.B;
                            gNumericUpDown.Value = color.G;

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
                else if (sender == aColorBar || sender == rColorBar || sender == gColorBar || sender == bColorBar)
                {
                    aNumericUpDown.Value = (int)aColorBar.Value;
                    rNumericUpDown.Value = (int)rColorBar.Value;
                    gNumericUpDown.Value = (int)gColorBar.Value;
                    bNumericUpDown.Value = (int)bColorBar.Value;

                    useRgb = true;
                }
                else if (sender == aNumericUpDown || sender == rNumericUpDown || sender == gNumericUpDown || sender == bNumericUpDown)
                {
                    useRgb = true;
                }
                else if (sender == hColorBar || sender == lColorBar || sender == sColorBar)
                {
                    hNumericUpDown.Value = (int)hColorBar.Value;
                    sNumericUpDown.Value = (int)sColorBar.Value;
                    lNumericUpDown.Value = (int)lColorBar.Value;

                    useHsl = true;
                }
                else if (sender == hNumericUpDown || sender == sNumericUpDown || sender == lNumericUpDown)
                {
                    useHsl = true;
                }

                if (useRgb || useNamed)
                {
                    Color color;

                    color = useNamed ? Colour.FromName(hexTextBox.Text) : Color.FromArgb((int)aNumericUpDown.Value, (int)rNumericUpDown.Value, (int)gNumericUpDown.Value, (int)bNumericUpDown.Value);

                    this.Colour = color;
                    this.HslColour = new HslColour(color);
                }
                else if (useHsl)
                {
                    HslColour color;

                    color = new HslColour((int)aNumericUpDown.Value, (double)hNumericUpDown.Value, (double)sNumericUpDown.Value / 100, (double)lNumericUpDown.Value / 100);
                    this.HslColour = color;
                    this.Colour = color.ToRgbColor();
                }

                this.LockUpdates = false;
                this.UpdateFields(true);
            }
        }

        #endregion

        #region IColorEditor Interface

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add { this.Events.AddHandler(_eventColorChanged, value); }
            remove { this.Events.RemoveHandler(_eventColorChanged, value); }
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
                        this.OnColorChanged(EventArgs.Empty);
                    }
                }
            }
        }

        #endregion
    }
}