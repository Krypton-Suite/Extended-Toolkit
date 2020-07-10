using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [System.Drawing.ToolboxBitmapAttribute(typeof(System.Windows.Forms.Timer)),
    DefaultEvent("ValueInRangeChanged"),
    Description("Displays a value on an analog gauge. Raises an event if the value enters one of the definable ranges."), ToolboxItem(true)]
    public partial class Gauge : Control
    {
        #region Designer Code
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
            components = new System.ComponentModel.Container();
        }

        #endregion
        #endregion

        #region ... enum, var, delegate, event
        public enum NeedleColorEnum
        {
            Gray = 0,
            Red = 1,
            Green = 2,
            Blue = 3,
            Yellow = 4,
            Violet = 5,
            Magenta = 6
        };

        private const Byte ZERO = 0;
        private const Byte NUMOFCAPS = 5;
        private const Byte NUMOFRANGES = 5;

        private Single fontBoundY1;
        private Single fontBoundY2;
        private Bitmap gaugeBitmap;
        private Boolean drawGaugeBackground = true;

        private Single m_value;
        private Boolean[] m_valueIsInRange = { false, false, false, false, false };
        private Byte m_CapIdx = 1;
        private Color[] m_CapColor = { Color.Black, Color.Black, Color.Black, Color.Black, Color.Black };
        private String[] m_CapText = { "", "", "", "", "" };
        private Point[] m_CapPosition = { new Point(10, 10), new Point(10, 10), new Point(10, 10), new Point(10, 10), new Point(10, 10) };
        private Point m_Center = new Point(100, 100);
        private Single m_MinValue = -100;
        private Single m_MaxValue = 400;

        private Color m_BaseArcColor = Color.Gray;
        private Int32 m_BaseArcRadius = 80;
        private Int32 m_BaseArcStart = 135;
        private Int32 m_BaseArcSweep = 270;
        private Int32 m_BaseArcWidth = 2;

        private Color m_ScaleLinesInterColor = Color.Black;
        private Int32 m_ScaleLinesInterInnerRadius = 73;
        private Int32 m_ScaleLinesInterOuterRadius = 80;
        private Int32 m_ScaleLinesInterWidth = 1;

        private Int32 m_ScaleLinesMinorNumOf = 9;
        private Color m_ScaleLinesMinorColor = Color.Gray;
        private Int32 m_ScaleLinesMinorInnerRadius = 75;
        private Int32 m_ScaleLinesMinorOuterRadius = 80;
        private Int32 m_ScaleLinesMinorWidth = 1;

        private Single m_ScaleLinesMajorStepValue = 50.0f;
        private Color m_ScaleLinesMajorColor = Color.Black;
        private Int32 m_ScaleLinesMajorInnerRadius = 70;
        private Int32 m_ScaleLinesMajorOuterRadius = 80;
        private Int32 m_ScaleLinesMajorWidth = 2;

        private Byte m_RangeIdx;
        private Boolean[] m_RangeEnabled = { true, true, false, false, false };
        private Color[] m_RangeColor = { Color.LightGreen, Color.Red, Color.FromKnownColor(KnownColor.Control), Color.FromKnownColor(KnownColor.Control), Color.FromKnownColor(KnownColor.Control) };
        private Single[] m_RangeStartValue = { -100.0f, 300.0f, 0.0f, 0.0f, 0.0f };
        private Single[] m_RangeEndValue = { 300.0f, 400.0f, 0.0f, 0.0f, 0.0f };
        private Int32[] m_RangeInnerRadius = { 70, 70, 70, 70, 70 };
        private Int32[] m_RangeOuterRadius = { 80, 80, 80, 80, 80 };

        private Int32 m_ScaleNumbersRadius = 95;
        private Color m_ScaleNumbersColor = Color.Black;
        private String m_ScaleNumbersFormat;
        private Int32 m_ScaleNumbersStartScaleLine;
        private Int32 m_ScaleNumbersStepScaleLines = 1;
        private Int32 m_ScaleNumbersRotation = 0;

        private Int32 m_NeedleType = 0;
        private Int32 m_NeedleRadius = 80;
        private NeedleColorEnum m_NeedleColor1 = NeedleColorEnum.Gray;
        private Color m_NeedleColor2 = Color.DimGray;
        private Int32 m_NeedleWidth = 2;

        public class ValueInRangeChangedEventArgs : EventArgs
        {
            public Int32 valueInRange;

            public ValueInRangeChangedEventArgs(Int32 valueInRange)
            {
                this.valueInRange = valueInRange;
            }
        }

        public delegate void ValueInRangeChangedDelegate(Object sender, ValueInRangeChangedEventArgs e);
        [Description("This event is raised if the value falls into a defined range.")]
        public event ValueInRangeChangedDelegate ValueInRangeChanged;
        #endregion

        #region ... hidden , overridden inherited properties
        public new Boolean AllowDrop
        {
            get
            {
                return false;
            }
            set
            {

            }
        }
        public new Boolean AutoSize
        {
            get
            {
                return false;
            }
            set
            {

            }
        }
        public new Boolean ForeColor
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
        public new Boolean ImeMode
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public override System.Drawing.Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                drawGaugeBackground = true;
                Refresh();
            }
        }
        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                drawGaugeBackground = true;
                Refresh();
            }
        }
        public override System.Windows.Forms.ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
                drawGaugeBackground = true;
                Refresh();
            }
        }
        #endregion

        public Gauge()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //Design Mode
            _designMode = (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
        }

        #region ... properties ...
        ///
        /// Indicates if the current view is being utilized in the VS.NET IDE or not.
        ///
        private bool _designMode;
        public new bool DesignMode
        {
            get
            {
                //return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
                return _designMode; ;
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The value.")]
        public Single Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (m_value != value)
                {
                    m_value = Math.Min(Math.Max(value, m_MinValue), m_MaxValue);

                    if (this.DesignMode)
                    {
                        drawGaugeBackground = true;
                    }

                    for (Int32 counter = 0; counter < NUMOFRANGES - 1; counter++)
                    {
                        if ((m_RangeStartValue[counter] <= m_value)
                        && (m_value <= m_RangeEndValue[counter])
                        && (m_RangeEnabled[counter]))
                        {
                            if (!m_valueIsInRange[counter])
                            {
                                if (ValueInRangeChanged != null)
                                {
                                    ValueInRangeChanged(this, new ValueInRangeChangedEventArgs(counter));
                                }
                            }
                        }
                        else
                        {
                            m_valueIsInRange[counter] = false;
                        }
                    }
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        RefreshProperties(RefreshProperties.All),
        Description("The caption index. set this to a value of 0 up to 4 to change the corresponding caption's properties.")]
        public Byte Cap_Idx
        {
            get
            {
                return m_CapIdx;
            }
            set
            {
                if ((m_CapIdx != value)
                && (0 <= value)
                && (value < 5))
                {
                    m_CapIdx = value;
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The color of the caption text.")]
        private Color CapColor
        {
            get
            {
                return m_CapColor[m_CapIdx];
            }
            set
            {
                if (m_CapColor[m_CapIdx] != value)
                {
                    m_CapColor[m_CapIdx] = value;
                    CapColors = m_CapColor;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(false)]
        public Color[] CapColors
        {
            get
            {
                return m_CapColor;
            }
            set
            {
                m_CapColor = value;
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The text of the caption.")]
        public String CapText
        {
            get
            {
                return m_CapText[m_CapIdx];
            }
            set
            {
                if (m_CapText[m_CapIdx] != value)
                {
                    m_CapText[m_CapIdx] = value;
                    CapsText = m_CapText;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(false)]
        public String[] CapsText
        {
            get
            {
                return m_CapText;
            }
            set
            {
                for (Int32 counter = 0; counter < 5; counter++)
                {
                    m_CapText[counter] = value[counter];
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The position of the caption.")]
        public Point CapPosition
        {
            get
            {
                return m_CapPosition[m_CapIdx];
            }
            set
            {
                if (m_CapPosition[m_CapIdx] != value)
                {
                    m_CapPosition[m_CapIdx] = value;
                    CapsPosition = m_CapPosition;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(false)]
        public Point[] CapsPosition
        {
            get
            {
                return m_CapPosition;
            }
            set
            {
                m_CapPosition = value;
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The center of the gauge (in the control's client area).")]
        public Point Center
        {
            get
            {
                return m_Center;
            }
            set
            {
                if (m_Center != value)
                {
                    m_Center = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The minimum value to show on the scale.")]
        public Single MinValue
        {
            get
            {
                return m_MinValue;
            }
            set
            {
                if ((m_MinValue != value)
                && (value < m_MaxValue))
                {
                    m_MinValue = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The maximum value to show on the scale.")]
        public Single MaxValue
        {
            get
            {
                return m_MaxValue;
            }
            set
            {
                if ((m_MaxValue != value)
                && (value > m_MinValue))
                {
                    m_MaxValue = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The color of the base arc.")]
        public Color BaseArcColor
        {
            get
            {
                return m_BaseArcColor;
            }
            set
            {
                if (m_BaseArcColor != value)
                {
                    m_BaseArcColor = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The radius of the base arc.")]
        public Int32 BaseArcRadius
        {
            get
            {
                return m_BaseArcRadius;
            }
            set
            {
                if (m_BaseArcRadius != value)
                {
                    m_BaseArcRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The start angle of the base arc.")]
        public Int32 BaseArcStart
        {
            get
            {
                return m_BaseArcStart;
            }
            set
            {
                if (m_BaseArcStart != value)
                {
                    m_BaseArcStart = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The sweep angle of the base arc.")]
        public Int32 BaseArcSweep
        {
            get
            {
                return m_BaseArcSweep;
            }
            set
            {
                if (m_BaseArcSweep != value)
                {
                    m_BaseArcSweep = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The width of the base arc.")]
        public Int32 BaseArcWidth
        {
            get
            {
                return m_BaseArcWidth;
            }
            set
            {
                if (m_BaseArcWidth != value)
                {
                    m_BaseArcWidth = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The color of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Color ScaleLinesInterColor
        {
            get
            {
                return m_ScaleLinesInterColor;
            }
            set
            {
                if (m_ScaleLinesInterColor != value)
                {
                    m_ScaleLinesInterColor = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The inner radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Int32 ScaleLinesInterInnerRadius
        {
            get
            {
                return m_ScaleLinesInterInnerRadius;
            }
            set
            {
                if (m_ScaleLinesInterInnerRadius != value)
                {
                    m_ScaleLinesInterInnerRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The outer radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Int32 ScaleLinesInterOuterRadius
        {
            get
            {
                return m_ScaleLinesInterOuterRadius;
            }
            set
            {
                if (m_ScaleLinesInterOuterRadius != value)
                {
                    m_ScaleLinesInterOuterRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The width of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        public Int32 ScaleLinesInterWidth
        {
            get
            {
                return m_ScaleLinesInterWidth;
            }
            set
            {
                if (m_ScaleLinesInterWidth != value)
                {
                    m_ScaleLinesInterWidth = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The number of minor scale lines.")]
        public Int32 ScaleLinesMinorNumOf
        {
            get
            {
                return m_ScaleLinesMinorNumOf;
            }
            set
            {
                if (m_ScaleLinesMinorNumOf != value)
                {
                    m_ScaleLinesMinorNumOf = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The color of the minor scale lines.")]
        public Color ScaleLinesMinorColor
        {
            get
            {
                return m_ScaleLinesMinorColor;
            }
            set
            {
                if (m_ScaleLinesMinorColor != value)
                {
                    m_ScaleLinesMinorColor = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The inner radius of the minor scale lines.")]
        public Int32 ScaleLinesMinorInnerRadius
        {
            get
            {
                return m_ScaleLinesMinorInnerRadius;
            }
            set
            {
                if (m_ScaleLinesMinorInnerRadius != value)
                {
                    m_ScaleLinesMinorInnerRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The outer radius of the minor scale lines.")]
        public Int32 ScaleLinesMinorOuterRadius
        {
            get
            {
                return m_ScaleLinesMinorOuterRadius;
            }
            set
            {
                if (m_ScaleLinesMinorOuterRadius != value)
                {
                    m_ScaleLinesMinorOuterRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The width of the minor scale lines.")]
        public Int32 ScaleLinesMinorWidth
        {
            get
            {
                return m_ScaleLinesMinorWidth;
            }
            set
            {
                if (m_ScaleLinesMinorWidth != value)
                {
                    m_ScaleLinesMinorWidth = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The step value of the major scale lines.")]
        public Single ScaleLinesMajorStepValue
        {
            get
            {
                return m_ScaleLinesMajorStepValue;
            }
            set
            {
                if ((m_ScaleLinesMajorStepValue != value) && (value > 0))
                {
                    m_ScaleLinesMajorStepValue = Math.Max(Math.Min(value, m_MaxValue), m_MinValue);
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The color of the major scale lines.")]
        public Color ScaleLinesMajorColor
        {
            get
            {
                return m_ScaleLinesMajorColor;
            }
            set
            {
                if (m_ScaleLinesMajorColor != value)
                {
                    m_ScaleLinesMajorColor = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The inner radius of the major scale lines.")]
        public Int32 ScaleLinesMajorInnerRadius
        {
            get
            {
                return m_ScaleLinesMajorInnerRadius;
            }
            set
            {
                if (m_ScaleLinesMajorInnerRadius != value)
                {
                    m_ScaleLinesMajorInnerRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The outer radius of the major scale lines.")]
        public Int32 ScaleLinesMajorOuterRadius
        {
            get
            {
                return m_ScaleLinesMajorOuterRadius;
            }
            set
            {
                if (m_ScaleLinesMajorOuterRadius != value)
                {
                    m_ScaleLinesMajorOuterRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The width of the major scale lines.")]
        public Int32 ScaleLinesMajorWidth
        {
            get
            {
                return m_ScaleLinesMajorWidth;
            }
            set
            {
                if (m_ScaleLinesMajorWidth != value)
                {
                    m_ScaleLinesMajorWidth = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        RefreshProperties(RefreshProperties.All),
        Description("The range index. set this to a value of 0 up to 4 to change the corresponding range's properties.")]
        public Byte Range_Idx
        {
            get
            {
                return m_RangeIdx;
            }
            set
            {
                if ((m_RangeIdx != value)
                && (0 <= value)
                && (value < NUMOFRANGES))
                {
                    m_RangeIdx = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("Enables or disables the range selected by Range_Idx.")]
        public Boolean RangeEnabled
        {
            get
            {
                return m_RangeEnabled[m_RangeIdx];
            }
            set
            {
                if (m_RangeEnabled[m_RangeIdx] != value)
                {
                    m_RangeEnabled[m_RangeIdx] = value;
                    RangesEnabled = m_RangeEnabled;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }


        [Browsable(false)]
        public Boolean[] RangesEnabled
        {
            get
            {
                return m_RangeEnabled;
            }
            set
            {
                m_RangeEnabled = value;
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The color of the range.")]
        public Color RangeColor
        {
            get
            {
                return m_RangeColor[m_RangeIdx];
            }
            set
            {
                if (m_RangeColor[m_RangeIdx] != value)
                {
                    m_RangeColor[m_RangeIdx] = value;
                    RangesColor = m_RangeColor;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(false)]
        public Color[] RangesColor
        {
            get
            {
                return m_RangeColor;
            }
            set
            {
                m_RangeColor = value;
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The start value of the range, must be less than RangeEndValue.")]
        public Single RangeStartValue
        {
            get
            {
                return m_RangeStartValue[m_RangeIdx];
            }
            set
            {
                if ((m_RangeStartValue[m_RangeIdx] != value)
                && (value < m_RangeEndValue[m_RangeIdx]))
                {
                    m_RangeStartValue[m_RangeIdx] = value;
                    RangesStartValue = m_RangeStartValue;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(false)]
        public Single[] RangesStartValue
        {
            get
            {
                return m_RangeStartValue;
            }
            set
            {
                m_RangeStartValue = value;
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The end value of the range. Must be greater than RangeStartValue.")]
        public Single RangeEndValue
        {
            get
            {
                return m_RangeEndValue[m_RangeIdx];
            }
            set
            {
                if ((m_RangeEndValue[m_RangeIdx] != value)
                && (m_RangeStartValue[m_RangeIdx] < value))
                {
                    m_RangeEndValue[m_RangeIdx] = value;
                    RangesEndValue = m_RangeEndValue;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(false)]
        public Single[] RangesEndValue
        {
            get
            {
                return m_RangeEndValue;
            }
            set
            {
                m_RangeEndValue = value;
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The inner radius of the range.")]
        public Int32 RangeInnerRadius
        {
            get
            {
                return m_RangeInnerRadius[m_RangeIdx];
            }
            set
            {
                if (m_RangeInnerRadius[m_RangeIdx] != value)
                {
                    m_RangeInnerRadius[m_RangeIdx] = value;
                    RangesInnerRadius = m_RangeInnerRadius;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(false)]
        public Int32[] RangesInnerRadius
        {
            get
            {
                return m_RangeInnerRadius;
            }
            set
            {
                m_RangeInnerRadius = value;
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The inner radius of the range.")]
        public Int32 RangeOuterRadius
        {
            get
            {
                return m_RangeOuterRadius[m_RangeIdx];
            }
            set
            {
                if (m_RangeOuterRadius[m_RangeIdx] != value)
                {
                    m_RangeOuterRadius[m_RangeIdx] = value;
                    RangesOuterRadius = m_RangeOuterRadius;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(false)]
        public Int32[] RangesOuterRadius
        {
            get
            {
                return m_RangeOuterRadius;
            }
            set
            {
                m_RangeOuterRadius = value;
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The radius of the scale numbers.")]
        public Int32 ScaleNumbersRadius
        {
            get
            {
                return m_ScaleNumbersRadius;
            }
            set
            {
                if (m_ScaleNumbersRadius != value)
                {
                    m_ScaleNumbersRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The color of the scale numbers.")]
        public Color ScaleNumbersColor
        {
            get
            {
                return m_ScaleNumbersColor;
            }
            set
            {
                if (m_ScaleNumbersColor != value)
                {
                    m_ScaleNumbersColor = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The format of the scale numbers.")]
        public String ScaleNumbersFormat
        {
            get
            {
                return m_ScaleNumbersFormat;
            }
            set
            {
                if (m_ScaleNumbersFormat != value)
                {
                    m_ScaleNumbersFormat = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The number of the scale line to start writing numbers next to.")]
        public Int32 ScaleNumbersStartScaleLine
        {
            get
            {
                return m_ScaleNumbersStartScaleLine;
            }
            set
            {
                if (m_ScaleNumbersStartScaleLine != value)
                {
                    m_ScaleNumbersStartScaleLine = Math.Max(value, 1);
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The number of scale line steps for writing numbers.")]
        public Int32 ScaleNumbersStepScaleLines
        {
            get
            {
                return m_ScaleNumbersStepScaleLines;
            }
            set
            {
                if (m_ScaleNumbersStepScaleLines != value)
                {
                    m_ScaleNumbersStepScaleLines = Math.Max(value, 1);
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The angle relative to the tangent of the base arc at a scale line that is used to rotate numbers. set to 0 for no rotation or e.g. set to 90.")]
        public Int32 ScaleNumbersRotation
        {
            get
            {
                return m_ScaleNumbersRotation;
            }
            set
            {
                if (m_ScaleNumbersRotation != value)
                {
                    m_ScaleNumbersRotation = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The type of the needle, currently only type 0 and 1 are supported. Type 0 looks nicers but if you experience performance problems you might consider using type 1.")]
        public Int32 NeedleType
        {
            get
            {
                return m_NeedleType;
            }
            set
            {
                if (m_NeedleType != value)
                {
                    m_NeedleType = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The radius of the needle.")]
        public Int32 NeedleRadius
        {
            get
            {
                return m_NeedleRadius;
            }
            set
            {
                if (m_NeedleRadius != value)
                {
                    m_NeedleRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The first color of the needle.")]
        public NeedleColorEnum NeedleColor1
        {
            get
            {
                return m_NeedleColor1;
            }
            set
            {
                if (m_NeedleColor1 != value)
                {
                    m_NeedleColor1 = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The second color of the needle.")]
        public Color NeedleColor2
        {
            get
            {
                return m_NeedleColor2;
            }
            set
            {
                if (m_NeedleColor2 != value)
                {
                    m_NeedleColor2 = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("Appearance-Extended"),
        Description("The width of the needle.")]
        public Int32 NeedleWidth
        {
            get
            {
                return m_NeedleWidth;
            }
            set
            {
                if (m_NeedleWidth != value)
                {
                    m_NeedleWidth = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region ... helper
        private void FindFontBounds()
        {
            //find upper and lower bounds for numeric characters
            Int32 c1;
            Int32 c2;
            Boolean boundfound;
            Bitmap b;
            Graphics g;
            SolidBrush backBrush = new SolidBrush(Color.White);
            SolidBrush foreBrush = new SolidBrush(Color.Black);
            SizeF boundingBox;

            b = new Bitmap(5, 5);
            g = Graphics.FromImage(b);
            boundingBox = g.MeasureString("0123456789", Font, -1, StringFormat.GenericTypographic);
            b = new Bitmap((Int32)(boundingBox.Width), (Int32)(boundingBox.Height));
            g = Graphics.FromImage(b);
            g.FillRectangle(backBrush, 0.0F, 0.0F, boundingBox.Width, boundingBox.Height);
            g.DrawString("0123456789", Font, foreBrush, 0.0F, 0.0F, StringFormat.GenericTypographic);

            fontBoundY1 = 0;
            fontBoundY2 = 0;
            c1 = 0;
            boundfound = false;
            while ((c1 < b.Height) && (!boundfound))
            {
                c2 = 0;
                while ((c2 < b.Width) && (!boundfound))
                {
                    if (b.GetPixel(c2, c1) != backBrush.Color)
                    {
                        fontBoundY1 = c1;
                        boundfound = true;
                    }
                    c2++;
                }
                c1++;
            }

            c1 = b.Height - 1;
            boundfound = false;
            while ((0 < c1) && (!boundfound))
            {
                c2 = 0;
                while ((c2 < b.Width) && (!boundfound))
                {
                    if (b.GetPixel(c2, c1) != backBrush.Color)
                    {
                        fontBoundY2 = c1;
                        boundfound = true;
                    }
                    c2++;
                }
                c1--;
            }
        }
        #endregion

        #region ... base member overrides
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if ((Width < 10) || (Height < 10))
            {
                return;
            }

            if (drawGaugeBackground)
            {
                drawGaugeBackground = false;

                FindFontBounds();

                gaugeBitmap = new Bitmap(Width, Height, pe.Graphics);
                Graphics ggr = Graphics.FromImage(gaugeBitmap);
                ggr.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

                if (BackgroundImage != null)
                {
                    switch (BackgroundImageLayout)
                    {
                        case ImageLayout.Center:
                            ggr.DrawImageUnscaled(BackgroundImage, Width / 2 - BackgroundImage.Width / 2, Height / 2 - BackgroundImage.Height / 2);
                            break;
                        case ImageLayout.None:
                            ggr.DrawImageUnscaled(BackgroundImage, 0, 0);
                            break;
                        case ImageLayout.Stretch:
                            ggr.DrawImage(BackgroundImage, 0, 0, Width, Height);
                            break;
                        case ImageLayout.Tile:
                            Int32 pixelOffsetX = 0;
                            Int32 pixelOffsetY = 0;
                            while (pixelOffsetX < Width)
                            {
                                pixelOffsetY = 0;
                                while (pixelOffsetY < Height)
                                {
                                    ggr.DrawImageUnscaled(BackgroundImage, pixelOffsetX, pixelOffsetY);
                                    pixelOffsetY += BackgroundImage.Height;
                                }
                                pixelOffsetX += BackgroundImage.Width;
                            }
                            break;
                        case ImageLayout.Zoom:
                            if ((Single)(BackgroundImage.Width / Width) < (Single)(BackgroundImage.Height / Height))
                            {
                                ggr.DrawImage(BackgroundImage, 0, 0, Height, Height);
                            }
                            else
                            {
                                ggr.DrawImage(BackgroundImage, 0, 0, Width, Width);
                            }
                            break;
                    }
                }

                ggr.SmoothingMode = SmoothingMode.HighQuality;
                ggr.PixelOffsetMode = PixelOffsetMode.HighQuality;

                GraphicsPath gp = new GraphicsPath();
                Single rangeStartAngle;
                Single rangeSweepAngle;
                for (Int32 counter = 0; counter < NUMOFRANGES; counter++)
                {
                    if (m_RangeEndValue[counter] > m_RangeStartValue[counter]
                    && m_RangeEnabled[counter])
                    {
                        rangeStartAngle = m_BaseArcStart + (m_RangeStartValue[counter] - m_MinValue) * m_BaseArcSweep / (m_MaxValue - m_MinValue);
                        rangeSweepAngle = (m_RangeEndValue[counter] - m_RangeStartValue[counter]) * m_BaseArcSweep / (m_MaxValue - m_MinValue);
                        gp.Reset();
                        gp.AddPie(new Rectangle(m_Center.X - m_RangeOuterRadius[counter], m_Center.Y - m_RangeOuterRadius[counter], 2 * m_RangeOuterRadius[counter], 2 * m_RangeOuterRadius[counter]), rangeStartAngle, rangeSweepAngle);
                        gp.Reverse();
                        gp.AddPie(new Rectangle(m_Center.X - m_RangeInnerRadius[counter], m_Center.Y - m_RangeInnerRadius[counter], 2 * m_RangeInnerRadius[counter], 2 * m_RangeInnerRadius[counter]), rangeStartAngle, rangeSweepAngle);
                        gp.Reverse();
                        ggr.SetClip(gp);
                        ggr.FillPie(new SolidBrush(m_RangeColor[counter]), new Rectangle(m_Center.X - m_RangeOuterRadius[counter], m_Center.Y - m_RangeOuterRadius[counter], 2 * m_RangeOuterRadius[counter], 2 * m_RangeOuterRadius[counter]), rangeStartAngle, rangeSweepAngle);
                    }
                }

                ggr.SetClip(ClientRectangle);
                if (m_BaseArcRadius > 0)
                {
                    ggr.DrawArc(new Pen(m_BaseArcColor, m_BaseArcWidth), new Rectangle(m_Center.X - m_BaseArcRadius, m_Center.Y - m_BaseArcRadius, 2 * m_BaseArcRadius, 2 * m_BaseArcRadius), m_BaseArcStart, m_BaseArcSweep);
                }

                String valueText = "";
                SizeF boundingBox;
                Single countValue = 0;
                Int32 counter1 = 0;
                while (countValue <= (m_MaxValue - m_MinValue))
                {
                    valueText = (m_MinValue + countValue).ToString(m_ScaleNumbersFormat);
                    ggr.ResetTransform();
                    boundingBox = ggr.MeasureString(valueText, Font, -1, StringFormat.GenericTypographic);

                    gp.Reset();
                    gp.AddEllipse(new Rectangle(m_Center.X - m_ScaleLinesMajorOuterRadius, m_Center.Y - m_ScaleLinesMajorOuterRadius, 2 * m_ScaleLinesMajorOuterRadius, 2 * m_ScaleLinesMajorOuterRadius));
                    gp.Reverse();
                    gp.AddEllipse(new Rectangle(m_Center.X - m_ScaleLinesMajorInnerRadius, m_Center.Y - m_ScaleLinesMajorInnerRadius, 2 * m_ScaleLinesMajorInnerRadius, 2 * m_ScaleLinesMajorInnerRadius));
                    gp.Reverse();
                    ggr.SetClip(gp);

                    ggr.DrawLine(new Pen(m_ScaleLinesMajorColor, m_ScaleLinesMajorWidth),
                    (Single)(Center.X),
                    (Single)(Center.Y),
                    (Single)(Center.X + 2 * m_ScaleLinesMajorOuterRadius * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0)),
                    (Single)(Center.Y + 2 * m_ScaleLinesMajorOuterRadius * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0)));

                    gp.Reset();
                    gp.AddEllipse(new Rectangle(m_Center.X - m_ScaleLinesMinorOuterRadius, m_Center.Y - m_ScaleLinesMinorOuterRadius, 2 * m_ScaleLinesMinorOuterRadius, 2 * m_ScaleLinesMinorOuterRadius));
                    gp.Reverse();
                    gp.AddEllipse(new Rectangle(m_Center.X - m_ScaleLinesMinorInnerRadius, m_Center.Y - m_ScaleLinesMinorInnerRadius, 2 * m_ScaleLinesMinorInnerRadius, 2 * m_ScaleLinesMinorInnerRadius));
                    gp.Reverse();
                    ggr.SetClip(gp);

                    if (countValue < (m_MaxValue - m_MinValue))
                    {
                        for (Int32 counter2 = 1; counter2 <= m_ScaleLinesMinorNumOf; counter2++)
                        {
                            if (((m_ScaleLinesMinorNumOf % 2) == 1) && ((Int32)(m_ScaleLinesMinorNumOf / 2) + 1 == counter2))
                            {
                                gp.Reset();
                                gp.AddEllipse(new Rectangle(m_Center.X - m_ScaleLinesInterOuterRadius, m_Center.Y - m_ScaleLinesInterOuterRadius, 2 * m_ScaleLinesInterOuterRadius, 2 * m_ScaleLinesInterOuterRadius));
                                gp.Reverse();
                                gp.AddEllipse(new Rectangle(m_Center.X - m_ScaleLinesInterInnerRadius, m_Center.Y - m_ScaleLinesInterInnerRadius, 2 * m_ScaleLinesInterInnerRadius, 2 * m_ScaleLinesInterInnerRadius));
                                gp.Reverse();
                                ggr.SetClip(gp);

                                ggr.DrawLine(new Pen(m_ScaleLinesInterColor, m_ScaleLinesInterWidth),
                                (Single)(Center.X),
                                (Single)(Center.Y),
                                (Single)(Center.X + 2 * m_ScaleLinesInterOuterRadius * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / (((Single)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue)) * (m_ScaleLinesMinorNumOf + 1))) * Math.PI / 180.0)),
                                (Single)(Center.Y + 2 * m_ScaleLinesInterOuterRadius * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / (((Single)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue)) * (m_ScaleLinesMinorNumOf + 1))) * Math.PI / 180.0)));

                                gp.Reset();
                                gp.AddEllipse(new Rectangle(m_Center.X - m_ScaleLinesMinorOuterRadius, m_Center.Y - m_ScaleLinesMinorOuterRadius, 2 * m_ScaleLinesMinorOuterRadius, 2 * m_ScaleLinesMinorOuterRadius));
                                gp.Reverse();
                                gp.AddEllipse(new Rectangle(m_Center.X - m_ScaleLinesMinorInnerRadius, m_Center.Y - m_ScaleLinesMinorInnerRadius, 2 * m_ScaleLinesMinorInnerRadius, 2 * m_ScaleLinesMinorInnerRadius));
                                gp.Reverse();
                                ggr.SetClip(gp);
                            }
                            else
                            {
                                ggr.DrawLine(new Pen(m_ScaleLinesMinorColor, m_ScaleLinesMinorWidth),
                                (Single)(Center.X),
                                (Single)(Center.Y),
                                (Single)(Center.X + 2 * m_ScaleLinesMinorOuterRadius * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / (((Single)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue)) * (m_ScaleLinesMinorNumOf + 1))) * Math.PI / 180.0)),
                                (Single)(Center.Y + 2 * m_ScaleLinesMinorOuterRadius * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / (((Single)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue)) * (m_ScaleLinesMinorNumOf + 1))) * Math.PI / 180.0)));
                            }
                        }
                    }

                    ggr.SetClip(ClientRectangle);

                    if (m_ScaleNumbersRotation != 0)
                    {
                        ggr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        ggr.RotateTransform(90.0F + m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue));
                    }

                    ggr.TranslateTransform((Single)(Center.X + m_ScaleNumbersRadius * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0f)),
                                           (Single)(Center.Y + m_ScaleNumbersRadius * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0f)),
                                           System.Drawing.Drawing2D.MatrixOrder.Append);


                    if (counter1 >= ScaleNumbersStartScaleLine - 1)
                    {
                        ggr.DrawString(valueText, Font, new SolidBrush(m_ScaleNumbersColor), -boundingBox.Width / 2, -fontBoundY1 - (fontBoundY2 - fontBoundY1 + 1) / 2, StringFormat.GenericTypographic);
                    }

                    countValue += m_ScaleLinesMajorStepValue;
                    counter1++;
                }

                ggr.ResetTransform();
                ggr.SetClip(ClientRectangle);

                if (m_ScaleNumbersRotation != 0)
                {
                    ggr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
                }

                for (Int32 counter = 0; counter < NUMOFCAPS; counter++)
                {
                    if (m_CapText[counter] != "")
                    {
                        ggr.DrawString(m_CapText[counter], Font, new SolidBrush(m_CapColor[counter]), m_CapPosition[counter].X, m_CapPosition[counter].Y, StringFormat.GenericTypographic);
                    }
                }
            }

            pe.Graphics.DrawImageUnscaled(gaugeBitmap, 0, 0);
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Single brushAngle = (Int32)(m_BaseArcStart + (m_value - m_MinValue) * m_BaseArcSweep / (m_MaxValue - m_MinValue)) % 360;
            Double needleAngle = brushAngle * Math.PI / 180;

            switch (m_NeedleType)
            {
                case 0:
                    PointF[] points = new PointF[3];
                    Brush brush1 = Brushes.White;
                    Brush brush2 = Brushes.White;
                    Brush brush3 = Brushes.White;
                    Brush brush4 = Brushes.White;

                    Brush brushBucket = Brushes.White;
                    Int32 subcol = (Int32)(((brushAngle + 225) % 180) * 100 / 180);
                    Int32 subcol2 = (Int32)(((brushAngle + 135) % 180) * 100 / 180);

                    pe.Graphics.FillEllipse(new SolidBrush(m_NeedleColor2), Center.X - m_NeedleWidth * 3, Center.Y - m_NeedleWidth * 3, m_NeedleWidth * 6, m_NeedleWidth * 6);
                    switch (m_NeedleColor1)
                    {
                        case NeedleColorEnum.Gray:
                            brush1 = new SolidBrush(Color.FromArgb(80 + subcol, 80 + subcol, 80 + subcol));
                            brush2 = new SolidBrush(Color.FromArgb(180 - subcol, 180 - subcol, 180 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(80 + subcol2, 80 + subcol2, 80 + subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(180 - subcol2, 180 - subcol2, 180 - subcol2));
                            pe.Graphics.DrawEllipse(Pens.Gray, Center.X - m_NeedleWidth * 3, Center.Y - m_NeedleWidth * 3, m_NeedleWidth * 6, m_NeedleWidth * 6);
                            break;
                        case NeedleColorEnum.Red:
                            brush1 = new SolidBrush(Color.FromArgb(145 + subcol, subcol, subcol));
                            brush2 = new SolidBrush(Color.FromArgb(245 - subcol, 100 - subcol, 100 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(145 + subcol2, subcol2, subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(245 - subcol2, 100 - subcol2, 100 - subcol2));
                            pe.Graphics.DrawEllipse(Pens.Red, Center.X - m_NeedleWidth * 3, Center.Y - m_NeedleWidth * 3, m_NeedleWidth * 6, m_NeedleWidth * 6);
                            break;
                        case NeedleColorEnum.Green:
                            brush1 = new SolidBrush(Color.FromArgb(subcol, 145 + subcol, subcol));
                            brush2 = new SolidBrush(Color.FromArgb(100 - subcol, 245 - subcol, 100 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(subcol2, 145 + subcol2, subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(100 - subcol2, 245 - subcol2, 100 - subcol2));
                            pe.Graphics.DrawEllipse(Pens.Green, Center.X - m_NeedleWidth * 3, Center.Y - m_NeedleWidth * 3, m_NeedleWidth * 6, m_NeedleWidth * 6);
                            break;
                        case NeedleColorEnum.Blue:
                            brush1 = new SolidBrush(Color.FromArgb(subcol, subcol, 145 + subcol));
                            brush2 = new SolidBrush(Color.FromArgb(100 - subcol, 100 - subcol, 245 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(subcol2, subcol2, 145 + subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(100 - subcol2, 100 - subcol2, 245 - subcol2));
                            pe.Graphics.DrawEllipse(Pens.Blue, Center.X - m_NeedleWidth * 3, Center.Y - m_NeedleWidth * 3, m_NeedleWidth * 6, m_NeedleWidth * 6);
                            break;
                        case NeedleColorEnum.Magenta:
                            brush1 = new SolidBrush(Color.FromArgb(subcol, 145 + subcol, 145 + subcol));
                            brush2 = new SolidBrush(Color.FromArgb(100 - subcol, 245 - subcol, 245 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(subcol2, 145 + subcol2, 145 + subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(100 - subcol2, 245 - subcol2, 245 - subcol2));
                            pe.Graphics.DrawEllipse(Pens.Magenta, Center.X - m_NeedleWidth * 3, Center.Y - m_NeedleWidth * 3, m_NeedleWidth * 6, m_NeedleWidth * 6);
                            break;
                        case NeedleColorEnum.Violet:
                            brush1 = new SolidBrush(Color.FromArgb(145 + subcol, subcol, 145 + subcol));
                            brush2 = new SolidBrush(Color.FromArgb(245 - subcol, 100 - subcol, 245 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(145 + subcol2, subcol2, 145 + subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(245 - subcol2, 100 - subcol2, 245 - subcol2));
                            pe.Graphics.DrawEllipse(Pens.Violet, Center.X - m_NeedleWidth * 3, Center.Y - m_NeedleWidth * 3, m_NeedleWidth * 6, m_NeedleWidth * 6);
                            break;
                        case NeedleColorEnum.Yellow:
                            brush1 = new SolidBrush(Color.FromArgb(145 + subcol, 145 + subcol, subcol));
                            brush2 = new SolidBrush(Color.FromArgb(245 - subcol, 245 - subcol, 100 - subcol));
                            brush3 = new SolidBrush(Color.FromArgb(145 + subcol2, 145 + subcol2, subcol2));
                            brush4 = new SolidBrush(Color.FromArgb(245 - subcol2, 245 - subcol2, 100 - subcol2));
                            pe.Graphics.DrawEllipse(Pens.Violet, Center.X - m_NeedleWidth * 3, Center.Y - m_NeedleWidth * 3, m_NeedleWidth * 6, m_NeedleWidth * 6);
                            break;
                    }

                    if (Math.Floor((Single)(((brushAngle + 225) % 360) / 180.0)) == 0)
                    {
                        brushBucket = brush1;
                        brush1 = brush2;
                        brush2 = brushBucket;
                    }

                    if (Math.Floor((Single)(((brushAngle + 135) % 360) / 180.0)) == 0)
                    {
                        brush4 = brush3;
                    }

                    points[0].X = (Single)(Center.X + m_NeedleRadius * Math.Cos(needleAngle));
                    points[0].Y = (Single)(Center.Y + m_NeedleRadius * Math.Sin(needleAngle));
                    points[1].X = (Single)(Center.X - m_NeedleRadius / 20 * Math.Cos(needleAngle));
                    points[1].Y = (Single)(Center.Y - m_NeedleRadius / 20 * Math.Sin(needleAngle));
                    points[2].X = (Single)(Center.X - m_NeedleRadius / 5 * Math.Cos(needleAngle) + m_NeedleWidth * 2 * Math.Cos(needleAngle + Math.PI / 2));
                    points[2].Y = (Single)(Center.Y - m_NeedleRadius / 5 * Math.Sin(needleAngle) + m_NeedleWidth * 2 * Math.Sin(needleAngle + Math.PI / 2));
                    pe.Graphics.FillPolygon(brush1, points);

                    points[2].X = (Single)(Center.X - m_NeedleRadius / 5 * Math.Cos(needleAngle) + m_NeedleWidth * 2 * Math.Cos(needleAngle - Math.PI / 2));
                    points[2].Y = (Single)(Center.Y - m_NeedleRadius / 5 * Math.Sin(needleAngle) + m_NeedleWidth * 2 * Math.Sin(needleAngle - Math.PI / 2));
                    pe.Graphics.FillPolygon(brush2, points);

                    points[0].X = (Single)(Center.X - (m_NeedleRadius / 20 - 1) * Math.Cos(needleAngle));
                    points[0].Y = (Single)(Center.Y - (m_NeedleRadius / 20 - 1) * Math.Sin(needleAngle));
                    points[1].X = (Single)(Center.X - m_NeedleRadius / 5 * Math.Cos(needleAngle) + m_NeedleWidth * 2 * Math.Cos(needleAngle + Math.PI / 2));
                    points[1].Y = (Single)(Center.Y - m_NeedleRadius / 5 * Math.Sin(needleAngle) + m_NeedleWidth * 2 * Math.Sin(needleAngle + Math.PI / 2));
                    points[2].X = (Single)(Center.X - m_NeedleRadius / 5 * Math.Cos(needleAngle) + m_NeedleWidth * 2 * Math.Cos(needleAngle - Math.PI / 2));
                    points[2].Y = (Single)(Center.Y - m_NeedleRadius / 5 * Math.Sin(needleAngle) + m_NeedleWidth * 2 * Math.Sin(needleAngle - Math.PI / 2));
                    pe.Graphics.FillPolygon(brush4, points);

                    points[0].X = (Single)(Center.X - m_NeedleRadius / 20 * Math.Cos(needleAngle));
                    points[0].Y = (Single)(Center.Y - m_NeedleRadius / 20 * Math.Sin(needleAngle));
                    points[1].X = (Single)(Center.X + m_NeedleRadius * Math.Cos(needleAngle));
                    points[1].Y = (Single)(Center.Y + m_NeedleRadius * Math.Sin(needleAngle));

                    pe.Graphics.DrawLine(new Pen(m_NeedleColor2), Center.X, Center.Y, points[0].X, points[0].Y);
                    pe.Graphics.DrawLine(new Pen(m_NeedleColor2), Center.X, Center.Y, points[1].X, points[1].Y);
                    break;
                case 1:
                    Point startPoint = new Point((Int32)(Center.X - m_NeedleRadius / 8 * Math.Cos(needleAngle)),
                                               (Int32)(Center.Y - m_NeedleRadius / 8 * Math.Sin(needleAngle)));
                    Point endPoint = new Point((Int32)(Center.X + m_NeedleRadius * Math.Cos(needleAngle)),
                                             (Int32)(Center.Y + m_NeedleRadius * Math.Sin(needleAngle)));

                    pe.Graphics.FillEllipse(new SolidBrush(m_NeedleColor2), Center.X - m_NeedleWidth * 3, Center.Y - m_NeedleWidth * 3, m_NeedleWidth * 6, m_NeedleWidth * 6);

                    switch (m_NeedleColor1)
                    {
                        case NeedleColorEnum.Gray:
                            pe.Graphics.DrawLine(new Pen(Color.DarkGray, m_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            pe.Graphics.DrawLine(new Pen(Color.DarkGray, m_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case NeedleColorEnum.Red:
                            pe.Graphics.DrawLine(new Pen(Color.Red, m_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            pe.Graphics.DrawLine(new Pen(Color.Red, m_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case NeedleColorEnum.Green:
                            pe.Graphics.DrawLine(new Pen(Color.Green, m_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            pe.Graphics.DrawLine(new Pen(Color.Green, m_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case NeedleColorEnum.Blue:
                            pe.Graphics.DrawLine(new Pen(Color.Blue, m_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            pe.Graphics.DrawLine(new Pen(Color.Blue, m_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case NeedleColorEnum.Magenta:
                            pe.Graphics.DrawLine(new Pen(Color.Magenta, m_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            pe.Graphics.DrawLine(new Pen(Color.Magenta, m_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case NeedleColorEnum.Violet:
                            pe.Graphics.DrawLine(new Pen(Color.Violet, m_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            pe.Graphics.DrawLine(new Pen(Color.Violet, m_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                        case NeedleColorEnum.Yellow:
                            pe.Graphics.DrawLine(new Pen(Color.Yellow, m_NeedleWidth), Center.X, Center.Y, endPoint.X, endPoint.Y);
                            pe.Graphics.DrawLine(new Pen(Color.Yellow, m_NeedleWidth), Center.X, Center.Y, startPoint.X, startPoint.Y);
                            break;
                    }
                    break;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            drawGaugeBackground = true;
            Refresh();
        }
        #endregion

    }
}